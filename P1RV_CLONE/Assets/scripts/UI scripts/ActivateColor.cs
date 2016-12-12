using UnityEngine;
using System.Collections;
using Leap.Unity.DetectionExamples;
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
