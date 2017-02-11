using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class MovePlayerfromPrefab : NetworkBehaviour
{
    public GameObject Leap;
    // Use this for initialization
    void Start()
    {
	
    }

    public override void OnStartLocalPlayer()
    {
        Leap = GameObject.Find("LMHeadMountedRig");
    }
    // Update is called once per frame
    void Update()
    {
        if (!isLocalPlayer)
        {
            return; 
        }
        if (Leap == null)
        {
            Leap = GameObject.Find("LMHeadMountedRig");
        }
        transform.position = Leap.transform.position;

    }
}
