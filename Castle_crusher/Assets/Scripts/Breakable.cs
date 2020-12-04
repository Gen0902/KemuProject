using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakable : MonoBehaviour
{
    Rigidbody m_rb;
    // Start is called before the first frame update
    void Start()
    {
        m_rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        //if(collision.gameObject.tag == "Ball")
        if (m_rb != null && collision.gameObject.GetComponent<Rigidbody>() && collision.gameObject.GetComponent<Rigidbody>().velocity.z > 0.01)
        {
            m_rb.isKinematic = false;
        }
    }
}
