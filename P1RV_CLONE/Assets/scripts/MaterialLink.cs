using UnityEngine;
using System.Collections;

public class MaterialLink : MonoBehaviour
{
    public GameObject FeaturesM;
    public Material BoutonMat;
    // Use this for initialization
    void Start()
    {
        FeaturesM = GameObject.Find("FeaturesManager");
    }

    public void Click()
    {
        FeaturesM.GetComponent<Edit>().mat = BoutonMat;
    }
    // Update is called once per frame
    void Update()
    {
	
    }
}
