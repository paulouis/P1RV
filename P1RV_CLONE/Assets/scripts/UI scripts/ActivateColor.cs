using UnityEngine;
using System.Collections;
using Leap.Unity.DetectionExamples;

// permet de selectionner la couleur du dessin , ce script est simplémenté sur chaque bouton couleur de l'UI et
// change la couleur du dessin sur l'objet PinchDrawing de la scène.
public class ActivateColor : MonoBehaviour {
	public Color Truc;
	public GameObject PinchDrawing;
	// Use this for initialization
	void Start () {
	
	}

	public void SetColor()
	{
		PinchDrawing.GetComponent<PinchDraw>().DrawColor = Truc; 
	}
	// Update is called once per frame
	void Update () {
	
	}
}
