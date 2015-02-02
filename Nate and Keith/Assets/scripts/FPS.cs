using UnityEngine;
using System.Collections;

public class FPS : MonoBehaviour {

	public GameObject Bullet_prefab;
	float bulletImpulse = 200.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	if(Input.GetButton("Fire1"))
		{
			Camera cam = Camera.main;
			GameObject thebullet = (GameObject)Instantiate(Bullet_prefab, cam.transform.position + cam.transform.forward , cam.transform.rotation);
			thebullet.rigidbody.AddForce(cam.transform.forward * bulletImpulse, ForceMode.Impulse);
		}
	}
}


