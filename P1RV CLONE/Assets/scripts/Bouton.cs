using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Bouton : MonoBehaviour {
	public GameObject Cube;
	public Button Bout ; 
	// Use this for initialization
	void Start () {
		
	}
	void OnPointerEnter(){
		Cube.SetActive (false);
	}
	void OnPointerExit()
	{
		Cube.SetActive (true);
	}
	// Update is called once per frame
	void Update () {
		

	}
}
