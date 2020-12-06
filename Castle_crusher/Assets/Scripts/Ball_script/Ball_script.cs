using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_script : MonoBehaviour
{
    bool AEteSaisi;
    bool EstSaisi;
    Rigidbody m_rb;

    private void Start()
    {
        AEteSaisi = false;
        m_rb = GetComponent<Rigidbody>();
        m_rb.isKinematic = true;
    }

    private void FixedUpdate()
    {

    }

    public void Grab()
    {
        if(AEteSaisi == false)
        {
            AEteSaisi = true;
        }
    }

    public void Throw(float vitesse, Vector3 dir)
    {
        m_rb.isKinematic = false;
        m_rb.AddForce(dir * vitesse, ForceMode.Impulse);
    }
}
