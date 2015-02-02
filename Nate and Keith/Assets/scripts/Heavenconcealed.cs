using UnityEngine;
using System.Collections;

public class Heavenconcealed : MonoBehaviour {

	float secondMeteorTime = 10.0f;
	bool second_available = false;
	bool second_fired  = false;
	public GameObject Meteor1_prefab;
	public GameObject Meteor2_prefab;
	Vector3 meteorpos = Vector3.zero;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		Camera cam = Camera.main;
		Quaternion temp = cam.transform.rotation;

		if (Input.GetButtonDown ("Fire3") && !second_available) 
		{
			temp = cam.transform.rotation;
			meteorpos = cam.transform.position;
			meteorpos += cam.transform.forward * 200;
			meteorpos.y += 200;

			GameObject meteor1 = (GameObject)Instantiate (Meteor1_prefab, meteorpos, temp);
			meteor1.rigidbody.AddForce (0, 0, 0);
			second_available = true;
		} 


		if(Input.GetButtonDown ("Fire3") && second_available && secondMeteorTime > 0 && secondMeteorTime < 6 && !second_fired)
		{
			meteorpos.y += 1000;
			GameObject meteor2 = (GameObject)Instantiate (Meteor2_prefab, meteorpos, temp);
			meteor2.rigidbody.AddForce (0, 0, 0);
			second_fired = true;
		}

		if (second_available) {
			
			secondMeteorTime -= Time.deltaTime;
		}

		if (secondMeteorTime <= 0 && second_available) 
		{
			second_available = false;
			second_fired = false;
			secondMeteorTime = 10.0f;
		}


	}
}