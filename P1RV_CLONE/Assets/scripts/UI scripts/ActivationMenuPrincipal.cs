using UnityEngine;
using System.Collections;
// permet d'activer le menu principal à travers le FeatureManager en utilsiant les scripts de détection d'orientation des mains
// fournis par LEap Motion
public class ActivationMenuPrincipal : MonoBehaviour {
	public bool PaumeTournee ; 
	public GameObject Menu ; 
	// Use this for initialization
	void Start () {
	
	}
	public void PaumeActive()
	{
		PaumeTournee = true; 
	}
	public void PaumeInactive()
	{
		PaumeTournee = false;
	}
	public void ToggleMenu()
	{
		
		if (PaumeTournee) 
		{
			Menu.SetActive (!Menu.activeInHierarchy);
		}
	}
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("ShowMenu"))
			{
				Menu.SetActive (!Menu.activeInHierarchy);
			}
	}
}
