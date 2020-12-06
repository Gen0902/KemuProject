using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion_impulse : MonoBehaviour
{
    public Collider[] m_collider;

    private void Start()
    {
        Destroy(this.gameObject, 1);
    }

    public void Explosion(Collider[] colTab)
    {
        foreach(Collider col in colTab)
        {
            if (col.GetComponent<Rigidbody>())
            {
                Vector3 dir = (col.transform.position - transform.position).normalized;
                col.GetComponent<Rigidbody>().AddForce(dir * 5);
            }
        }
        Destroy(this.gameObject, 1);
    }

}
