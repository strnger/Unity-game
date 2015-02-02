using UnityEngine;
using System.Collections;

[RequireComponent (typeof(CharacterController))]
public class firstPersonController : MonoBehaviour {

	const float ORIGINAL_MOVEMENT_SPEED = 15.0f;

	public float movementSpeed = ORIGINAL_MOVEMENT_SPEED;
	public float mouseSensitivity = 4.0f;


	float verticalRotation = 0;
	public float upDownRange = 60.0f;

	float verticalVelocity = 0;

	float jumpSpeed = 10;

	CharacterController charactercontroller;

	// Use this for initialization
	void Start () {
		Screen.lockCursor = true;

	 charactercontroller = GetComponent<CharacterController> ();
	}
	
	// Update is called once per frame
	void Update () {


		//rotation

		float rotLeftRight = Input.GetAxis ("Mouse X") * mouseSensitivity;
		transform.Rotate(0, rotLeftRight, 0);

		verticalRotation -= Input.GetAxis ("Mouse Y") * mouseSensitivity;
		verticalRotation = Mathf.Clamp (verticalRotation, -upDownRange, (upDownRange+20));
		Camera.main.transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);

		//movement

		if (Input.GetButton ("Fire2")) {
			if(charactercontroller.isGrounded)
			{
				movementSpeed = 2 * ORIGINAL_MOVEMENT_SPEED;
			}
			else
			{
				movementSpeed = ORIGINAL_MOVEMENT_SPEED/2;
			}
		} 
		else  
		{
			if(charactercontroller.isGrounded)
			{
				movementSpeed = ORIGINAL_MOVEMENT_SPEED;
			}
			else
			{
				movementSpeed = ORIGINAL_MOVEMENT_SPEED/2;
			}
		} 

		float forwardSpeed = Input.GetAxis ("Vertical") * movementSpeed;
		float sideSpeed = Input.GetAxis ("Horizontal") * movementSpeed;

		verticalVelocity += Physics.gravity.y * Time.deltaTime;

		if (Input.GetButton ("Jump") && charactercontroller.isGrounded ) {
			verticalVelocity = jumpSpeed;
		
		}

		Vector3 speed = new Vector3 (sideSpeed, verticalVelocity, forwardSpeed);

		speed = transform.rotation * speed;


			charactercontroller.Move (speed * Time.deltaTime);

	}
}
