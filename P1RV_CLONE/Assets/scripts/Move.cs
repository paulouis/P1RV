﻿using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {
	public Transform m_ObjectTransform ; 
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = m_ObjectTransform.position; 
	}
}
