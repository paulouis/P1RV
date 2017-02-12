using UnityEngine;
using System.Collections;

public class FollowHand : MonoBehaviour {
	public GameObject Paume ; 
	private Transform offset ; 
	// Use this for initialization
	void Start () {
		offset.position = new Vector3 (10.1f, 0.0f, 0.40f); 
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = Paume.transform.position;
		transform.position += offset.position;
		transform.rotation = Paume.transform.rotation * Quaternion.AngleAxis(90, new Vector3(1.0f,0.0f,0.0f)); 
	}
}
