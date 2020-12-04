using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blue_ball_script : MonoBehaviour
{
    [SerializeField]
    GameObject mon_trou_noir;

   private void OnCollisionEnter(Collision collision)
    {
        this.GetComponent<SphereCollider>().enabled = false;
        Instantiate(mon_trou_noir, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
