using UnityEngine;
using System.Collections;
using UnityEngine.UI;
// script permettant d'instancier un objet lorsque la fonction créer est appelée par un bouton de l'UI
public class InstanceObjet : MonoBehaviour {
	public GameObject Objet;
	public Transform m_ObjectTransform;
	private Transform m_ObjectTransformRandom;
	private GameObject NouveauCube; 
	public GameObject FeatureM;
	// Use this for initialization
	void Start () {
		m_ObjectTransformRandom = m_ObjectTransform;
		FeatureM = GameObject.Find ("FeaturesManager");
	}
	public void Creer()
	{
		// la position de l'objet crée est aléatoire devant l'utilisateur
		Vector3 offset = new Vector3 (Random.Range (-0.3f, 0.3f), 0f, 0f);
		m_ObjectTransformRandom.position = m_ObjectTransform.position + offset;
		GameObject NouveauCube = Instantiate (Objet.gameObject, m_ObjectTransformRandom.position, Quaternion.identity) as GameObject;
		if (FeatureM.GetComponent<GravitySwitch> ().GravityIsOn) { // tentative de changer la présence de gravité ou non sur l'objet
			NouveauCube.GetComponent<Rigidbody> ().useGravity = true; 
			NouveauCube.GetComponent<Rigidbody> ().isKinematic = false; 
		}
		
	}
	// Update is called once per frame
	void Update () {
	}
}
