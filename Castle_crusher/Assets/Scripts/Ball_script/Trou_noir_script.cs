using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Trou_noir_script : MonoBehaviour
{
    [SerializeField]
    GameObject final_explosion;
    public float radius;
    public float impulseForce, ExpluseForce;

    List<Collider> m_col;
    public float delay;
    float time;


    // Start is called before the first frame update
    void Start()
    {
        m_col = new List<Collider>();
        StartCoroutine("Implosion");
        //Implosion();   
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (m_col != null || m_col.Count != 0)
        {
            m_col.Clear();
            var newcoltemp = Physics.OverlapSphere(transform.position, radius);
            m_col = newcoltemp.ToList();
            foreach (Collider col in m_col)
            {
                if (col.GetComponent<Rigidbody>())
                {
                    Vector3 dir = (transform.position - col.transform.position).normalized;
                    col.GetComponent<Rigidbody>().AddForce(dir * impulseForce, ForceMode.Impulse);
                }
            }
        }

        if (time> delay)
        {
            Destroy_Black_hole();
        }
    }


    IEnumerator Implosion()
    {
        yield return new WaitForSeconds(0.1f);
        var coltemp = Physics.OverlapSphere(transform.position, radius);
        m_col.Clear();

        for(int i =0; i < coltemp.Length; i++)
        {
            if (coltemp[i].GetComponent<BreakableObject>())
            {
                coltemp[i].GetComponent<BreakableObject>().SwitchBreak();
                //var tempParcour = Physics.OverlapSphere(transform.position, radius);
                //m_col = tempParcour.ToList();
                //m_col = Physics.OverlapSphere(transform.position, radius);
            }
        }


    }


    void Destroy_Black_hole()
    {
        //GameObject temp  = 
        Instantiate(final_explosion, transform.position, Quaternion.identity);
        //temp.GetComponent<Explosion_impulse>().Explosion(m_col);
        Explosion();
        Destroy(this.gameObject);
    }



    public void Explosion()
    {
        foreach (Collider col in m_col)
        {
            if (col.GetComponent<Rigidbody>())
            {
                Vector3 dir = (col.transform.position - transform.position).normalized;
                col.GetComponent<Rigidbody>().AddForce(dir * ExpluseForce);
            }
        }
    }
}
