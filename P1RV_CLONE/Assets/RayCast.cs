using UnityEngine;
using System.Collections;

public class RayCast : MonoBehaviour {
	private Ray ray ;
	private RaycastHit hit;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		ray.direction = transform.forward;
		ray.origin = transform.position;
		UnityEngine.Debug.DrawRay (ray.origin, ray.direction, Color.blue);
		Physics.Raycast (ray, out hit);
		Debug.Log (hit.point);
	}
}
