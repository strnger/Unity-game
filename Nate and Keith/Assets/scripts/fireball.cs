using UnityEngine;
using System.Collections;

public class fireball : MonoBehaviour {

	public GameObject fireBall_prefab;
	Vector3 fireBallPos = Vector3.zero;
	float fireImpulse = 50.0f;

	bool FirstSignWeaved = false;
	bool SecondsignWeaved = false;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		Camera cam = Camera.main;
		Quaternion temp = cam.transform.rotation;
		
		//the next 3 "if" statements see if the sign "iop" is weaved, and if so, throw the first meteor
		if (Input.GetKeyDown ("j")) 
		{
			FirstSignWeaved = true;
		} 
		
		if(FirstSignWeaved == true && Input.GetKeyDown ("k"))
		{
			SecondsignWeaved = true;
		}
		
		if(SecondsignWeaved == true && Input.GetKeyDown ("l"))
		{
			temp = cam.transform.rotation;
			fireBallPos = cam.transform.position;
			fireBallPos += cam.transform.forward * 2;
			fireBallPos.y = 1;

			GameObject fireball = (GameObject)Instantiate(fireBall_prefab, cam.transform.position + cam.transform.forward , cam.transform.rotation);
			fireball.rigidbody.AddForce(cam.transform.forward * fireImpulse, ForceMode.Impulse);

			FirstSignWeaved = false;
			SecondsignWeaved = false;

			while(Input.GetKeyDown ("l"))
			{
				//wait
			}

			Destroy (fireball);

		}

		//This lets the user escape from the current sequence of signs
		if (Input.GetButtonDown ("z"))
		{
			FirstSignWeaved = false;
			SecondsignWeaved = false;
		}
		
	}
}
