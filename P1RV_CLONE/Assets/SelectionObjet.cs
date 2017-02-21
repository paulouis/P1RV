using UnityEngine;
using System.Collections;

public class SelectionObjet : MonoBehaviour
{
    public GameObject Prefab;
    public GameObject FeaturesM;
    // Use this for initialization
    void Start()
    {
        FeaturesM = GameObject.Find("FeaturesManager");
    }

    public void SendObjetToFeaturesManager()
    {
        FeaturesM.GetComponent<CmdInstanceObjet>().Prefab = Prefab;
        FeaturesM.GetComponent<CmdInstanceObjet>().Vrai();
    }
    // Update is called once per frame
    void Update()
    {
	
    }
}
