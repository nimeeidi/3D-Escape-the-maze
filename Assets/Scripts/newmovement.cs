using UnityEngine;
using System.Collections;

public class newmovement : MonoBehaviour {
    private Rigidbody snowman;
    private float rotateRate = 90f;
    private float walkRate = 3f;

    Quaternion holdsNextRotation; // this is the place you want to turn to
    private float turnInput;
    private float walkInput;

    void Awake()
    {
        snowman = GetComponent<Rigidbody>();
    }

	void Start () {
        snowman = GetComponent<Rigidbody>();
        holdsNextRotation = transform.rotation; //gets current spawn coordinates
        walkInput = 0;
        turnInput = 0; //setting all the current inputs to 0
     
	}

    private void GetInput()
    {
        walkInput = Input.GetAxis("Vertical"); //getAxis returns -1 to 1 
        turnInput = Input.GetAxis("Horizontal"); 

    }
	
	private void Update () {
        GetInput(); //gathers your input in update
        Turn(); //turning does not require physics
        
    }

    private void FixedUpdate()
    {
        Walk();
    }

    private void Walk()
    {
        Vector3 move = transform.forward * walkInput * walkRate;
        snowman.MovePosition(move+snowman.position);
        //transform.forward = moving on the snowman's forward axis
        //walkInput is pos/neg which determines forward/backward movement
        // walkRate multiplies the rate at which u want to go 
    }

    private void Turn()
    {
        //Angle Axis takes angle from 0-360 that you want to turn and axis
        holdsNextRotation *= Quaternion.AngleAxis(rotateRate*turnInput*Time.deltaTime,Vector3.up); //vector3.up is global yaxis
        // multiplying Quarternion bc its like ur adding angles
        transform.rotation = holdsNextRotation;

    }
}
