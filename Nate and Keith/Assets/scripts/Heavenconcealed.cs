using UnityEngine;
using System.Collections;

public class Heavenconcealed : MonoBehaviour {

	float secondMeteorTime = 10.0f;
	bool second_available = false;
	bool second_fired  = false;
	public GameObject Meteor1_prefab;
	public GameObject Meteor2_prefab;
	Vector3 meteorpos = Vector3.zero;

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
		if (Input.GetKeyDown ("i") && !second_available) 
		{
			FirstSignWeaved = true;
		} 

		if(FirstSignWeaved == true && Input.GetKeyDown ("o") && !second_available)
		{
			SecondsignWeaved = true;
		}

		if(SecondsignWeaved == true && Input.GetKeyDown ("p") && !second_available)
		{
			temp = cam.transform.rotation;
			meteorpos = cam.transform.position;
			meteorpos += cam.transform.forward * 100;
			meteorpos.y = 300;
			
			GameObject meteor1 = (GameObject)Instantiate (Meteor1_prefab, meteorpos, temp);
			meteor1.rigidbody.AddForce (0, 0, 0);
			second_available = true;
		}

		//Second meteor
		if(Input.GetButtonDown ("p") && second_available && secondMeteorTime > 0 && secondMeteorTime < 6 && !second_fired)
		{
			meteorpos.y += 1000;
			GameObject meteor2 = (GameObject)Instantiate (Meteor2_prefab, meteorpos, temp);
			meteor2.rigidbody.AddForce (0, 0, 0);
			second_fired = true;
		}

		//This lets the user escape from the current sequence of signs
		if (Input.GetButtonDown ("z") && !second_available /*this is needed, otherwise the player could hit Z after firing the first meteor, the fire another first one*/)
		{
			second_available = false;
			second_fired = false;
			secondMeteorTime = 10.0f;
			FirstSignWeaved = false;
			SecondsignWeaved = false;
		}

		//This prevents the player from firing the second immediately
		if (second_available) {
			
			secondMeteorTime -= Time.deltaTime;
		}

		//This resets the meteor timer and signs, letting the player use them again
		if (secondMeteorTime <= 0 && second_available) 
		{
			second_available = false;
			second_fired = false;
			secondMeteorTime = 10.0f;
			FirstSignWeaved = false;
			SecondsignWeaved = false;
		}


	}
}