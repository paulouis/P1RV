using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class TakeClientAuthority : NetworkBehaviour
{


    public NetworkIdentity NetID;




    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision");

        if (other.gameObject.CompareTag("Index"))
        {
            Debug.Log("nb connex");
            Debug.Log(NetworkServer.connections.Count);
            CmdTest();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Index"))
        {
             
        }

    }

    [Command]
    public void CmdTest()
    {
        Debug.Log("nb connex");
        Debug.Log(NetworkServer.connections.Count);
        for (int i = 0; i < NetworkServer.connections.Count; i++)
        {
            if (NetID.connectionToClient == NetworkServer.connections[i])
            {
                Debug.Log("c'est la connexion");
                Debug.Log(i);
            }
        }
    }
    // Use this for initialization
    void Start()
    {
	
    }
	
    // Update is called once per frame
    void Update()
    {
	
    }
}
