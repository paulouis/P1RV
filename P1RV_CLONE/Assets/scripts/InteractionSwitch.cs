using UnityEngine;
using System.Collections;
using Leap.Unity;
using Leap.Unity.Interaction; 



/// ///test

public class InteractionSwitch : MonoBehaviour {
	public GameObject Interaction;
	public GameObject Leap;
	private bool Switch ; 
	// Use this for initialization
	void Start () {
		//Interaction.SetActive(true);
		Leap.GetComponent<HandPool>().DisableGroup("Collision");
		Leap.GetComponent<HandPool> ().EnableGroup ("Brush");
		Switch = true;

	}
	public void Activer()
	{
		Interaction.GetComponent<InteractionManager> ().GraspingEnabled = false; 
		Leap.GetComponent<HandPool>().DisableGroup("Brush");
		Leap.GetComponent<HandPool> ().EnableGroup ("Collision");
	}
	public void Desactiver()
	{
		//Interaction.SetActive(true); 
		Interaction.GetComponent<InteractionManager> ().GraspingEnabled = true; 
		Leap.GetComponent<HandPool>().DisableGroup("Collision");
		Leap.GetComponent<HandPool> ().EnableGroup ("Brush");
	}
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("InteractionSwitch") && Switch) {
			Activer ();
			Switch = false; 
		} 
		else if (Input.GetButtonDown ("InteractionSwitch") && !Switch) {
			Desactiver ();
			Switch = true; 
		}
		
	}
}
