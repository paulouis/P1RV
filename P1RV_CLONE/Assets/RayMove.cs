using UnityEngine;
using System.Collections;

public class RayMove : MonoBehaviour {
	private Ray ray ;
	private RaycastHit hit;
	public bool Charger ;
	public GameObject Camera;
	public GameObject Portal; 
	// Use this for initialization
	void Start () {
		Charger = false;
	}

	public void OnCharge()
	{
		// Active le lancer de rayon
		Charger = true;
	}

	public void Deactivate()
	{
		
	}
	public void Shoot(){ // téléporte lorsque activé 
		if (Charger) {
			transform.position = hit.point - Camera.transform.forward; 
			Charger = false; 

		}
	}
	// Update is called once per frame
	void Update () { // lancer de rayon
		if (Charger) {
			ray.direction = Camera.transform.forward;
			ray.origin = Camera.transform.position;
			UnityEngine.Debug.DrawRay (ray.origin, ray.direction, Color.blue);
			Physics.Raycast (ray, out hit,30f, 1 << 12);
			Debug.Log (hit.collider.tag);
		}

	}
}
