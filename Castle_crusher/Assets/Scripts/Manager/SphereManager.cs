using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereManager : MonoBehaviour
{
    [SerializeField]
    Material[] Ball_mat;
    [SerializeField]
    TrowBall m_player;
    MeshRenderer[] me_balls;


    // Start is called before the first frame update
    void Start()
    {
        me_balls = GetComponentsInChildren<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        foreach (MeshRenderer m in me_balls)
        {
            m.material = Ball_mat[m_player.index_ball];
        }
    }
}
