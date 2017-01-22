using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawSonar : MonoBehaviour {

    // Use this for initialization

    public Shader shader;
    private Mesh sonarMesh;
    private Material lmat;
    public float sonarTime = 5.0f;
    public float pulseWidth = 5.0f;
    private float currentSonarTime;
    private bool sonarDirtyFlag = false;
    private List<Vector3> sonarPoints;

    Material mat;
    Mesh mesh;    
    void Awake()
    {
        sonarMesh = new Mesh();
        sonarPoints = new List<Vector3>();
    }

    private void Start()
    {
        mat = gameObject.GetComponent<Renderer>().material;
        mat.SetFloat( "_PulseWidth", ( pulseWidth ));
    } 

    // Update is called once per frame
    void Update()
    {
        if ( currentSonarTime > 0.0f && sonarDirtyFlag )
        {
            mat.SetFloat( "_DistRatio", ( 1.0f - ( currentSonarTime / sonarTime ) ) );
            currentSonarTime -= Time.deltaTime;
        }
        else
        {
            sonarDirtyFlag = false;
            sonarMesh.Clear();
        }
    }

    public void AddPointToSonar( Vector3 point )
    {
        sonarPoints.Add( point );
        sonarDirtyFlag = true;
        currentSonarTime = sonarTime;
    }

    public void RenderSonar( Vector3 charPos, float length )
    {
        mat.SetFloat( "_MaxLength", length );
        mat.SetFloat( "_DistRatio", 0.2f ); 
        List<Vector3> tempV = new List<Vector3>();
        for( int p = 0; p + 1 < sonarPoints.Count; ++p )
        {
            tempV.Add( charPos );
            tempV.Add( sonarPoints[p] );
            tempV.Add( sonarPoints[p + 1] );
        }

        Vector3[] vertices = new Vector3[ tempV.Count ];
        for( int v = 0; v < tempV.Count; ++v )
        {
            vertices[ v ] = tempV[ v ];
        }
        sonarMesh.vertices = vertices;
        int[] triangles = new int[ tempV.Count ];
        for( int t = 0; t < tempV.Count; ++t )
        {
            triangles[ t ] = t;
        }
        sonarMesh.triangles = triangles;

        GetComponent<MeshFilter>().mesh = sonarMesh;

        sonarDirtyFlag = true;
        currentSonarTime = sonarTime;
        //AddLine( sonarMesh, MakeQuad( s, e, w ), false );
    }

}
