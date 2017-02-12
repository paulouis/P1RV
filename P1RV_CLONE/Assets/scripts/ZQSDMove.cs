using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class ZQSDMove : MonoBehaviour
{
    private float m_MovementXInputValue;
    private float m_MovementZInputValue;
    private float m_MovementYInputValue;
    public float m_speed;
    public GameObject Camera;
    // Use this for initialization
    void Start()
    {
	
    }

    void Move()
    {
        m_MovementXInputValue = Input.GetAxis("Horizontal");
        m_MovementZInputValue = Input.GetAxis("Vertical");
        m_MovementYInputValue = Input.GetAxis("Hauteur");
        Vector3 MovementForward = Camera.transform.forward * m_MovementZInputValue * m_speed * Time.deltaTime; 
        Vector3 MovementDraft = Camera.transform.right * m_MovementXInputValue * m_speed * Time.deltaTime;
        Vector3 MovementUp = transform.up * m_MovementYInputValue * m_speed * Time.deltaTime;
        transform.Translate(MovementDraft, Space.World);
        transform.Translate(MovementForward);
        transform.Translate(MovementUp);
    }
    // Update is called once per frame
    void Update()
    {
      
        Move();
    }
}
