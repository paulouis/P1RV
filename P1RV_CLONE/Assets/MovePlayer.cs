using UnityEngine;
using System.Collections;

public class MovePlayer : MonoBehaviour
{
    public GameObject player;
    private Vector3 Offset;
    // Use this for initialization
    void Start()
    {
        Offset = player.transform.position - transform.position;
        if (player == null)
        {
            player = GameObject.Find("Player(Clone)");
        }
    }
	
    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            player = GameObject.Find("Player(Clone)");
            Offset = new Vector3(-1f, -1f, -1f);
        }
        player.transform.position = transform.position + Offset;
    }
}
