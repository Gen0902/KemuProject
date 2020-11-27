using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallThrower : MonoBehaviour
{
    [SerializeField] GameObject ballPrefab;
    [SerializeField] Transform firePoint;

    public Ball ThrowBall(float throwForce)
    {
        GameObject go = Instantiate(ballPrefab, firePoint.position, Quaternion.identity);
        Ball ball = go.GetComponent<Ball>();
        ball.Launch(firePoint.up, throwForce);
        return ball;
    }

}
