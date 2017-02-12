using UnityEngine;
using System.Collections;

// Permet d'effectuer le lien entre l'UI et le FeaturesManager qui gère les modes d'interaction et de manipulation
public class FeatureManagerLink : MonoBehaviour
{
    public string FunctionName;
    public GameObject FeatureM;
    public InteractionSwitch InterScript;
    public Edit FeatureMScript;
    public bool test;
    // Use this for initialization
    void Start()
    { // initialisation des variables, recherche dans la scène
        FeatureM = GameObject.Find("FeaturesManager");
        InterScript = FeatureM.GetComponent<InteractionSwitch>();
        FeatureMScript = FeatureM.GetComponent<Edit>();
        //test = false; 
    }

    public void Click() // selon le bouton appuyé (Rotate,Edit,Scale) active les fonctions associées
    {
        switch (FunctionName)
        {
            case "NaturalMove":
                InterScript.Desactiver();
                break;
            case "Scale":  // active dans le FeaturesManager le scaling à travers un booléen 
                InterScript.Activer();
                FeatureMScript.IsScaling = true; 
                FeatureMScript.IsRotating = false;
                FeatureMScript.IsTranslating = true;
                break;
            case "Rotate": // active la rotation (toujours des booléens)
                InterScript.Activer();
                FeatureMScript.Rotate();
			//test = true;
                break;
            case "Translate":
                InterScript.Activer();
                FeatureMScript.IsScaling = false; 
                FeatureMScript.IsRotating = false;
                FeatureMScript.IsTranslating = true;
                break;
            default:
                Debug.Log("Erreur, aucun bouton associé");
                break;
        }
    }
    // Update is called once per frame
    void Update()
    {
	
    }
}
