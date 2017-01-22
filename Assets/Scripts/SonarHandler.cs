using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonarHandler : MonoBehaviour {

    private List<Vector3> sonarPoints;
    public float sonarTime = 5.0f;
    public float pulseWidth = 5.0f;
    public GameObject sonar;
    public GameObject sonar2;
    private bool uglyHack = false;
    // Use this for initialization
    void Start () {
        sonarPoints = new List<Vector3>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void AddPointToSonar( Vector3 point )
    {
        sonarPoints.Add( point );
    }

    public void CreateSonar( Vector3 charPos, float length )
    {
        var sonarClone = Instantiate( uglyHack ? sonar : sonar2, transform.position, transform.rotation );
        uglyHack = !uglyHack;
        var sonarScript = sonarClone.GetComponent< DrawSonar > ();
        sonarScript.sonarTime = sonarTime;
        sonarScript.pulseWidth = pulseWidth;
        sonarScript.sonarPoints = sonarPoints;
        sonarScript.RenderSonar( charPos, length );
        sonarPoints.Clear();
    }
}
