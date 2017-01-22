using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public float moveSpeed = 5;
    public float sonarCoolDown = 2.0f;
    public float rotationSpeed = 10;

    public int numRays = 20;
    public float sonarWidthDegreesBig = 90f;
    public float sonarWidthDegreesSmall = 20f;
    public float sonarDist = 20;
    [HideInInspector]
    public float turnAxisInput;

    private SonarHandler drawSonar;
    private CharacterController CC;

    private float timeStamp;
    // Use this for initialization
    void Awake()
    {
        CC = transform.GetComponent<CharacterController>();

    }

    void Start()
    {
        drawSonar = FindObjectOfType<SonarHandler>();
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

    public void BigSonarPulse()
    {
        if( Time.time > timeStamp )
        {
            timeStamp = Time.time + sonarCoolDown;
            SonarPulse( sonarWidthDegreesBig );
        }
    }

    public void SmallSonarPulse()
    {
        if( Time.time > timeStamp )
        {
            timeStamp = Time.time + sonarCoolDown;
            SonarPulse( sonarWidthDegreesSmall );
        }
    }


    public void SonarPulse( float width )
    {
        List<Ray> Rays = new List<Ray>();
        for( int i = 0; i < numRays; ++i )
        {
            Vector3 origin = transform.position;
            Vector3 direction = transform.forward;
            float angle = ( ( width / numRays ) * i ) - width / 2.0f;
            direction = Quaternion.Euler( 0, angle, 0 ) * direction;

            Ray ray = new Ray( origin, direction );
            Rays.Add( ray );
        }
        
        foreach( Ray ray in Rays )
        {
            RaycastHit rayHit;
            bool hasHitObject = Physics.Raycast( ray, out rayHit, sonarDist );
            if( rayHit.transform )
            {
                rayHit.collider.gameObject.GetComponent<SonarReceiver>().distToCharacter = rayHit.distance;
                rayHit.transform.SendMessage( "OnSonarHit", SendMessageOptions.DontRequireReceiver );
                //Debug.Log( "Hit " + rayHit.transform.gameObject.name );
            }
            //Debug.DrawRay( ray.origin, ray.direction * ( hasHitObject ? rayHit.distance : sonarDist ), Color.red, 1.0f, true );

            Vector3 vertexPoint = hasHitObject ? rayHit.point : transform.position + ( ray.direction.normalized * sonarDist );
            vertexPoint.y = 0.1f;
            drawSonar.AddPointToSonar( vertexPoint );
        }
        Vector3 charPos = transform.position;
        charPos.y = 0.1f;
        drawSonar.CreateSonar( charPos , sonarDist );

        return;
    }

}