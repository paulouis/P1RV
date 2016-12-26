using UnityEngine;
using System.Collections;

public class GravitySwitch : MonoBehaviour {
	public bool GravityIsOn;
	// Use this for initialization
	void Start () {
		GravityIsOn = false; 
	}
	public void Activate()
	{
		GravityIsOn = true; 
	}
	public void Deactivate()
	{
		GravityIsOn = false; 
	}
	// Update is called once per frame
	void Update () {
	
	}
}
