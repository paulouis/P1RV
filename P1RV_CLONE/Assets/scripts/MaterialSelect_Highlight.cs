using UnityEngine;
using System.Collections;


public class MaterialSelect_Highlight : MonoBehaviour
{
    public GameObject FeaturesM;
    public Material mat;
    public Shader HighlightShader;
    public Shader StandardShader;
    public bool IsMaterialChanging;
    // Use this for initialization
    void Start()
    {
        FeaturesM = GameObject.Find("FeaturesManager");
        IsMaterialChanging = false;
        // this.gameObject.GetComponent<Renderer>().material = mat;
        //this.gameObject.GetComponent<Renderer>().material.shader = HighlightShader;
       
    }

    void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("Index"))
        {
            IsMaterialChanging = FeaturesM.GetComponent<Edit>().SetMaterial; 
            mat = FeaturesM.GetComponent<Edit>().mat;
            this.gameObject.GetComponent<Renderer>().material.shader = HighlightShader;
            if (IsMaterialChanging)
            {
                this.gameObject.GetComponent<Renderer>().material = mat;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Index"))
        {
            IsMaterialChanging = false;
            this.gameObject.GetComponent<Renderer>().material.shader = StandardShader; 
        }
    }
    // Update is called once per frame
    private int timer = 0;
    private bool truc = true;

    void Update()
    {
        /*
        timer += 1;
        if (timer % 100 == 0 && truc)
        {
            this.gameObject.GetComponent<Renderer>().material.shader = StandardShader; 
            truc = false; 
            timer = 0;
        }
        else if (timer % 100 == 0 && !truc)
        {
            this.gameObject.GetComponent<Renderer>().material.shader = HighlightShader;
            truc = true;
            timer = 0;
        }
        */
    }
}
