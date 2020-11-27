﻿using System.Collections;
using System.Collections.Generic;
using UnityEditor.Purchasing;
using UnityEngine;

public class BallHandler : MonoBehaviour
{
    public Transform firePoint;

    public float throwForce = 2;
    //public float controlForce;
    public float pickUpRadius = 0.8f;
    private Ball holdingBall;


    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Mouse0))
            ThrowBall();
        //else if (Input.GetKeyDown(KeyCode.Mouse1))
        //    ControlBall();
        else if (Input.GetKeyDown(KeyCode.Mouse2))
            CatchBall();

        if (holdingBall != null)
        {
            holdingBall.transform.position = firePoint.position;
            holdingBall.Stop();
        }
    }

    private void ThrowBall()
    {
        if (holdingBall != null)
        {
            holdingBall.Launch(firePoint.forward, throwForce);
            holdingBall = null;
        }
        else
        {
            Ball ball = DetectBall();
            if (ball != null)
                ball.Launch(firePoint.forward, throwForce);
        }
    }

    //private void ControlBall()
    //{
    //    if (holdingBall != null)
    //    {
    //        holdingBall.Launch(Vector3.up, controlForce);
    //        holdingBall = null;
    //    }
    //    else
    //    {
    //        Ball ball = DetectBall();
    //        if (ball != null)
    //        {
    //            ball.Launch(new Vector3(0, controlForce,0));
    //        }
    //    }
    //}

    private void CatchBall()
    {
        if (holdingBall != null)
            return;

        Ball ball = DetectBall();
        if (ball != null)
        {
            ball.Stop();
            holdingBall = ball;
        }
    }

    private Ball DetectBall()
    {
        var cols = Physics.OverlapSphere(firePoint.position, pickUpRadius, GameManager.Instance.ballLayer);
        foreach (Collider col in cols)
        {
            Ball ball = col.gameObject.GetComponent<Ball>();
            if (ball != null)
                return ball;
        }

        return null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.gray;
        Gizmos.DrawWireSphere(firePoint.position, pickUpRadius);
        Debug.DrawRay(firePoint.position, firePoint.forward);
    }
}
