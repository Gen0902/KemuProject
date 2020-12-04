using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    [SerializeField]
    Vector3[] BallPosition;


    public void CleanBall()
    {
        foreach(Transform child in this.transform)
        {
            Destroy(child.gameObject, 0.01f);
        }
    }

    public void CreateBall(string code)
    {
        string[] mesCodes = code.Split(' ');
        int index = 0;
        foreach(string c in mesCodes)
        {
            if(Resources.Load("Socle/Socle_ballon_" + c))
            {
                Instantiate(Resources.Load<GameObject>("Socle/Socle_ballon_" + c), BallPosition[index], Quaternion.identity, this.transform);
                index++;
            }            
        }
    }




}
