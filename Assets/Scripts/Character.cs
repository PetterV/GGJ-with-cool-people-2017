using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

    public float moveSpeed = 5;
    public float rotationSpeed = 10;
    [HideInInspector]
    public float turnAxisInput;

    private CharacterController CC;
	// Use this for initialization
	void Awake ()
    {
        CC = transform.GetComponent<CharacterController>(); 

    }

    private void Start()
    {

    }
	
	// Update is called once per frame
	void Update () {
        MoveCharacter();
    }

    void MoveCharacter()
    {
        Vector3 moveVector = transform.forward * moveSpeed * Time.deltaTime;
        transform.Rotate( Vector3.up * turnAxisInput * rotationSpeed * Time.deltaTime);


        CC.Move( moveVector );
    }
    
}
