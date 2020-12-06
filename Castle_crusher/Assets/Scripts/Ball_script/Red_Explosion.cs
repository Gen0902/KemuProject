using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Red_Explosion : MonoBehaviour
{

    [SerializeField]
    float forceImpact, radius;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Explosion");
        Destroy(this.gameObject, 2);
    }




    IEnumerator Explosion()
    {
        yield return new WaitForSeconds(0.1f);
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
