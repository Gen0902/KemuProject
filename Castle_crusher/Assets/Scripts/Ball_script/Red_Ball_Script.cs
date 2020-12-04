using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Red_Ball_Script : MonoBehaviour
{

    [SerializeField]
    GameObject m_Explosion;
    [SerializeField]
    float forceImpact, radius;


    private void OnCollisionEnter(Collision collision)
    {
        this.GetComponent<SphereCollider>().enabled = false;
        Instantiate(m_Explosion, transform.position, Quaternion.identity);
        //Explosion();
        Destroy(this.gameObject);
    }





    public void Explosion()
    {
        Collider[] colTab = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider col in colTab)
        {
            if (col.GetComponent<Rigidbody>())
            {
                Vector3 dir = (col.transform.position - transform.position).normalized;
                col.GetComponent<Rigidbody>().AddForce(dir * forceImpact);
            }
        }
    }
}
