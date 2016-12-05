using UnityEngine;
using System.Collections;
using Leap.Unity;

public class ActivationLeapRTS_Prefab : MonoBehaviour {
	public LeapRTS_Prefab LeapRTS_inst; // script du LeapRTS ( pour le scaling de l'objet entre autres)

	public bool actif ;
	// Use this for initialization
	void Start () {
		LeapRTS_inst.enabled = false ;
		actif = false; 

	}
	void OnTriggerEnter(Collider other)
	{
		actif = true;
		if (other.gameObject.CompareTag("Index"))
			{
				Activer ();
				actif = true ;
			}
	}
	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.CompareTag("Index"))
					{
						Desactiver();
						actif = false ; 
					}
		actif = false ; 
	}
	public void Activer()
	{
		LeapRTS_inst.enabled = true; 
		actif = true;
	}
	public void Desactiver()
	{
		LeapRTS_inst.enabled = false;
		actif = false; 
	}
	// Update is called once per frame
	void Update () {
	
	}
}
