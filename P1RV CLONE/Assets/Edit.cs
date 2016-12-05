using UnityEngine;
using System.Collections;

public class Edit : MonoBehaviour {
	public bool IsRotating;
	public bool IsTranslating;
	public bool IsScaling ; 
	// Use this for initialization
	void Start () {
		IsRotating = false;
		IsScaling = false; 
		IsTranslating = false; 
	}

	public void Rotate()
	{
		IsRotating = true;
		IsScaling = false; 
		IsTranslating = false; 
	}
	// Update is called once per frame
	void Update () {
	
	}
}
