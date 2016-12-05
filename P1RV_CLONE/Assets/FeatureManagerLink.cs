using UnityEngine;
using System.Collections;

public class FeatureManagerLink : MonoBehaviour {
	public string FunctionName;
	public GameObject FeatureM; 
	public InteractionSwitch InterScript ; 
	public Edit FeatureMScript;
	public bool test;
	// Use this for initialization
	void Start () {
		FeatureM = GameObject.Find ("FeaturesManager");
		InterScript = FeatureM.GetComponent<InteractionSwitch> ();
		FeatureMScript = FeatureM.GetComponent<Edit> ();
		test = false; 
	}

	public void Click()
	{
		switch (FunctionName) 
		{
		case "NaturalMove":
			InterScript.Desactiver ();
			break;
		case "Scale": 
			InterScript.Activer ();
			FeatureMScript.IsScaling = true; 
			FeatureMScript.IsRotating = false;
			FeatureMScript.IsTranslating= false;
			break;
		case "Rotate":
			InterScript.Activer ();
			FeatureMScript.Rotate ();
			test = true;
			break;
		case "Translate":
			InterScript.Activer ();
			FeatureMScript.IsScaling = false; 
			FeatureMScript.IsRotating = false;
			FeatureMScript.IsTranslating = true;
			break;
		default:
			Debug.Log ("error");
			break;
		}
	}
	// Update is called once per frame
	void Update () {
	
	}
}
