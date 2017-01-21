using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawSonar : MonoBehaviour {

    // Use this for initialization

    public Shader shader;
    private Mesh sonarMesh;
    private Material lmat;
    public float sonarTime = 1.0f;
    private float currentSonarTime;
    private bool sonarDirtyFlag = false;
    private List<Vector3> sonarPoints;

    Mesh mesh;    
    void Awake()
    {
        sonarMesh = new Mesh();
        sonarPoints = new List<Vector3>();
    }

    // Update is called once per frame
    void Update()
    {
        if ( currentSonarTime > 0.0f && sonarDirtyFlag )
        {
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

    public void RenderSonar( Vector3 charPos )
    {
        List<Vector3> tempV = new List<Vector3>();
        for( int p = 0; p < sonarPoints.Count; ++p )
        {
            if( p % 2 == 0 )
            {
                tempV.Add( charPos );
            }
            tempV.Add( sonarPoints[p] );
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

    //Vector3[] MakeQuad( Vector3 s, Vector3 e, float w )
    //{
    //    w = w / 2;
    //    Vector3[] q = new Vector3[ 4 ];

    //    Vector3 n = transform.up; // Vector3.Cross( s, e );
    //    Vector3 l = Vector3.Cross( n, e - s );
    //    l.Normalize();

    //    q[ 0 ] = transform.InverseTransformPoint( s + l * w );
    //    q[ 1 ] = transform.InverseTransformPoint( s + l * -w );
    //    q[ 2 ] = transform.InverseTransformPoint( e + l * w );
    //    q[ 3 ] = transform.InverseTransformPoint( e + l * -w );

    //    return q;
    //}

    //void AddLine( Mesh m, Vector3[] quad, bool tmp )
    //{
    //    int vl = m.vertices.Length;

    //    Vector3[] vs = m.vertices;
    //    if( !tmp || vl == 0 ) vs = resizeVertices( vs, 4 );
    //    else vl -= 4;

    //    vs[ vl ] = quad[ 0 ];
    //    vs[ vl + 1 ] = quad[ 1 ];
    //    vs[ vl + 2 ] = quad[ 2 ];
    //    vs[ vl + 3 ] = quad[ 3 ];

    //    int tl = m.triangles.Length;

    //    int[] ts = m.triangles;
    //    if( !tmp || tl == 0 ) ts = resizeTraingles( ts, 6 );
    //    else tl -= 6;
    //    ts[ tl ] = vl;
    //    ts[ tl + 1 ] = vl + 1;
    //    ts[ tl + 2 ] = vl + 2;
    //    ts[ tl + 3 ] = vl + 1;
    //    ts[ tl + 4 ] = vl + 3;
    //    ts[ tl + 5 ] = vl + 2;

    //    m.vertices = vs;
    //    m.triangles = ts;
    //    m.RecalculateBounds();
    //}

    //Vector3[] resizeVertices( Vector3[] ovs, int ns )
    //{
    //    Vector3[] nvs = new Vector3[ ovs.Length + ns ];
    //    for( int i = 0; i < ovs.Length; i++ ) nvs[ i ] = ovs[ i ];
    //    return nvs;
    //}

    //int[] resizeTraingles( int[] ovs, int ns )
    //{
    //    int[] nvs = new int[ ovs.Length + ns ];
    //    for( int i = 0; i < ovs.Length; i++ ) nvs[ i ] = ovs[ i ];
    //    return nvs;
    //}

    //void Draw()
    //{
    //    Graphics.DrawMesh( sonarMesh, transform.localToWorldMatrix, lmat, 0 );
    //}
}
