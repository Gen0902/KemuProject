using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderBottom : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Totem"))
        {
            GameManager.instance.TotemTomber(other.transform.position);
            Destroy(other.gameObject);
        }
    }
}
