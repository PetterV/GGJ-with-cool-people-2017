using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{

    public float moveSpeed = 5;
    public float rotationSpeed = 10;

    public int numRays = 20;
    public float coneWidthDegrees = 60f;
    public float sonarDist = 20;
    [HideInInspector]
    public float turnAxisInput;

    private CharacterController CC;
    // Use this for initialization
    void Awake()
    {
        CC = transform.GetComponent<CharacterController>();

    }

    private void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        MoveCharacter();
    }

    void MoveCharacter()
    {
        Vector3 moveVector = transform.forward * moveSpeed * Time.deltaTime;
        transform.Rotate( Vector3.up * turnAxisInput * rotationSpeed * Time.deltaTime );

        CC.Move( moveVector );
    }

    public void SonarPulse()
    {
        List<Ray> Rays = new List<Ray>();
        for( int i = 0; i < numRays; ++i )
        {
            Vector3 origin = transform.position;
            Vector3 direction = transform.forward;
            float angle = ( coneWidthDegrees / numRays ) * i;
            direction = Quaternion.Euler( 0, angle, 0 ) * direction;

            Ray ray = new Ray( origin, direction );
            Rays.Add( ray );
        }
        foreach( Ray ray in Rays )
        {
            RaycastHit rayHit;
            Physics.Raycast( ray, out rayHit, sonarDist );
            if (rayHit.transform)
            {
                rayHit.transform.SendMessage( "OnSonarHit" );
                Debug.Log( "Hit " + rayHit.transform.gameObject.name );
            }
        }
        Debug.Log( "Send Pulse" );
        
        return;
    }

}