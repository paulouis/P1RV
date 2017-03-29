using UnityEngine;
using System.Collections;
using UnityEngine.Networking;


// ATTENTION ///////////////////////////::
// NE FONCTIONNE PAS !!!!!!!!!!!!!!!!!!!!!!!!! //////////////////////////////
//public class TakeClientAuthority : NetworkBehaviour
//{
//
//
//    public NetworkIdentity NetID;
//    public NetworkIdentity ClientIdentity;
//    public GameObject ClientId;
//
//    void start()
//    {
//        ClientId = null;
//    }
//
//    void OnTriggerEnter(Collider other)
//    {
//        Debug.Log("Collision");
//
//        if (other.gameObject.CompareTag("Index"))
//        {
//            ClientId = other.transform.parent.parent.FindChild("ClientID").gameObject;
//            ClientIdentity = ClientId.GetComponent<NetworkIdentity>();
//            if (ClientIdentity.connectionToClient == NetID.clientAuthorityOwner)
//            {
//                Debug.Log("Pouet");
//            }
//            else
//            {
//                CmdRemoveClientAuthority();
//                CmdAddClientAuthority();
//            }
//
//
//        }
//    }
//
//    void OnTriggerExit(Collider other)
//    {
//        if (other.gameObject.CompareTag("Index"))
//        {
//            //sCmdRemoveClientAuthority();
//        }
//
//    }
//
//    [Command]
//    public void CmdAddClientAuthority()
//    {
//        NetID.AssignClientAuthority(ClientIdentity.connectionToClient);
//    }
//
//
//    [Command]
//    public void CmdRemoveClientAuthority()
//    {
//        NetID.RemoveClientAuthority(NetID.clientAuthorityOwner);
//    }
//
//
//
//    [Command]
//    public void CmdTest()
//    {
//        Debug.Log("nb connex");
//        Debug.Log(NetworkServer.connections.Count);
//        for (int i = 0; i < NetworkServer.connections.Count; i++)
//        {
//            if (NetID.connectionToClient == NetworkServer.connections[i])
//            {
//                Debug.Log("c'est la connexion");
//                Debug.Log(i);
//            }
//        }
//    }
//    // Use this for initialization
//    void Start()
//    {
//
//    }
//
//    // Update is called once per frame
//    void Update()
//    {
//
//    }
//}
