using UnityEngine;
using System.Collections;
using Leap.Unity;
using Leap.Unity.Interaction; 
// permet de basculer entre les différentes techniques de manipulation
public class InteractionSwitch : MonoBehaviour {
	public GameObject Interaction;
	public GameObject Leap;
	private bool Switch ; 
	// Use this for initialization
	void Start () {
		
		Leap.GetComponent<HandPool>().DisableGroup("Brush"); 
		Leap.GetComponent<HandPool> ().EnableGroup ("Collision"); 
		Interaction.GetComponent<InteractionManager> ().GraspingEnabled = false; // 
		Switch = false;

	}
	public void Activer() // active les groupes de mains associées à la rotation et au scale
	{
		Interaction.GetComponent<InteractionManager> ().GraspingEnabled = false; 
		Leap.GetComponent<HandPool>().DisableGroup("Brush"); // mains nécessaires à l'interaction engine
		Leap.GetComponent<HandPool> ().EnableGroup ("Collision"); // mains nécessaires aux autres tehchniques
	}
	public void Desactiver() // désactive les groupes de mains associées au scaling et à la rotation
	{
		//Interaction.SetActive(true); 
		Interaction.GetComponent<InteractionManager> ().GraspingEnabled = true; 
		Leap.GetComponent<HandPool>().DisableGroup("Collision");
		Leap.GetComponent<HandPool> ().EnableGroup ("Brush");
	}
	// Update is called once per frame
	void Update () { // obsolète, permet de switcher les interactions avec le clavier.
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
