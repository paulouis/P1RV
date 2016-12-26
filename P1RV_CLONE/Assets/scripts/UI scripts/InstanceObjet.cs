using UnityEngine;
using System.Collections;
using UnityEngine.UI;

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
		Vector3 offset = new Vector3 (Random.Range (-0.3f, 0.3f), 0f, 0f);
		m_ObjectTransformRandom.position = m_ObjectTransform.position + offset;
		GameObject NouveauCube = Instantiate (Objet.gameObject, m_ObjectTransformRandom.position, Quaternion.identity) as GameObject;
		if (FeatureM.GetComponent<GravitySwitch> ().GravityIsOn) {
			NouveauCube.GetComponent<Rigidbody> ().useGravity = true; 
			NouveauCube.GetComponent<Rigidbody> ().isKinematic = false; 
		}
		
	}
	// Update is called once per frame
	void Update () {
	}
}
