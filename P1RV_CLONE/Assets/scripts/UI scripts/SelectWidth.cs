using UnityEngine;
using System.Collections;
using Leap.Unity.DetectionExamples;

// sélectionne la largeur du trait de dessin libre, ce script modifie l'épaisseur du trait dans l'objet pinchDrawing de la scène
public class SelectWidth : MonoBehaviour {
	public GameObject PinchDrawing;
	public string Width;
	// Use this for initialization
	void Start () {
	
	}

	public void Click()
	{
		switch (Width) {
		case "thin":
			PinchDrawing.GetComponent<PinchDraw> ().DrawRadius = 0.002f;
			break;
		case "medium":
			PinchDrawing.GetComponent<PinchDraw> ().DrawRadius = 0.01f;
			break;
		case "thick":
			PinchDrawing.GetComponent<PinchDraw> ().DrawRadius = 0.02f;
			break;
		case "plus":
			PinchDrawing.GetComponent<PinchDraw> ().DrawRadius += 0.002f;
			break;
		case "moins":
			PinchDrawing.GetComponent<PinchDraw> ().DrawRadius -= 0.002f;
			break;
		}

	}
	// Update is called once per frame
	void Update () {
	
	}
}
