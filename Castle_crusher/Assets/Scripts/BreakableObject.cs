using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableObject : MonoBehaviour
{
    [SerializeField]
    GameObject my_breakable;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ball")
        {
            SwitchBreak();
        }
    }


    public void SwitchBreak()
    {
        GetComponent<Collider>().isTrigger = true;
        Instantiate(my_breakable, transform.position, transform.rotation, transform.parent);
        Destroy(this.gameObject);
    }

}
