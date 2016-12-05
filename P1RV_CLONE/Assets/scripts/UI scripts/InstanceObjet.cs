using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InstanceObjet : MonoBehaviour {
	public GameObject Objet;
	public Transform m_ObjectTransform;
	private GameObject NouveauCube; 
	// Use this for initialization
	void Start () {
		
	}
	public void Creer()
	{
		GameObject NouveauCube = Instantiate (Objet.gameObject, m_ObjectTransform.position , Quaternion.identity) as GameObject;

	}
		
	
	// Update is called once per frame
	void Update () {
	}
}
