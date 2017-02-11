using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class colorplayer : NetworkBehaviour
{

    // Use this for initialization
    void Start()
    {
	
    }

    public override void OnStartLocalPlayer()
    {
        GetComponent<MeshRenderer>().material.color = Color.blue;
    }
    // Update is called once per frame
    void Update()
    {
        if (!isLocalPlayer)
        {
            return;
        }
    }
}
