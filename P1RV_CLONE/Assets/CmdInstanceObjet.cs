using UnityEngine;
using System.Collections;

public class CmdInstanceObjet : MonoBehaviour
{
    public bool Instancier;
    public GameObject Prefab;
    // Use this for initialization
    void Start()
    {
        Instancier = false;
    }

    public void Vrai()
    {
        Instancier = true;
    }

    public void Faux()
    {
        Instancier = false; 
    }
    // Update is called once per frame
    void Update()
    {
	
    }
}
