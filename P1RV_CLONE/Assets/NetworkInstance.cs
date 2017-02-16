﻿using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class NetworkInstance : NetworkBehaviour
{
    public GameObject Objet;
    public Transform m_ObjectTransform;
    private Transform m_ObjectTransformRandom;
    private GameObject NouveauCube;
    public Transform SpawnObjets;
    // Use this for initialization
    void Start()
    {
        m_ObjectTransform = GameObject.Find("LMHeadMountedRig/ObjectTransform").transform;
        m_ObjectTransformRandom = m_ObjectTransform;

    }

    [Command]
    public void CmdCreer()
    {
        // la position de l'objet crée est aléatoire devant l'utilisateur
        Vector3 offset = new Vector3(Random.Range(-0.3f, 0.3f), 0f, 0f);
        m_ObjectTransformRandom.position = m_ObjectTransform.position + offset;
        GameObject NouveauCube = Instantiate(Objet.gameObject, SpawnObjets.position, Quaternion.identity) as GameObject;
        NetworkServer.Spawn(NouveauCube);

        //Network.Instantiate(Objet.gameObject, m_ObjectTransformRandom.position, Quaternion.identity, 0);
    }
    // Update is called once per frame
    void Update()
    {
        if (isLocalPlayer)
        {
            if (Input.GetKeyDown(KeyCode.I))
            {
                Debug.Log("instantiation !! ");
                CmdCreer();
            }
        }
    }
}
