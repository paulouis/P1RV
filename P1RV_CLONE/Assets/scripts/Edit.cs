using UnityEngine;
using System.Collections;

// le FeaturesManager sert de lien entre l'UI et les objets manipulables de la scène.
// étant donné que chaque objet emporte avec lui les scripts permettant sa manipulation, on ira chercher dans ce script ci dessous
// les booléens indiquant quelle méthode de manipulation est active.
// le FeaturesManager gère aussi les différents matériaux appliqués aux objets à travers ce script
public class Edit : MonoBehaviour
{
    public bool IsRotating;
    public bool IsTranslating;
    public bool IsScaling;
    public bool SetMaterial;
    public Material mat;
    // Use this for initialization
    void Start()
    {
        IsRotating = false;
        IsScaling = false; 
        IsTranslating = false; 
        SetMaterial = false;
    }

    public void Rotate()
    {
        IsRotating = true;
        IsScaling = false; 
        IsTranslating = false; 
    }
    // Update is called once per frame
    void Update()
    {
	
    }
}
