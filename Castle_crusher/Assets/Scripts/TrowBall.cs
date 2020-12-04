using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrowBall : MonoBehaviour
{
    [SerializeField]
    GameObject[] Ball;
    public int index_ball;
    public float puissance;

    //Saisir et lancer la ball;
    public Transform main;
    public float speed;
    GameObject BallGrab;
    public float radius = 2;
    bool Saisi;



    // Start is called before the first frame update
    void Start()
    {
        index_ball = 0;
        Saisi = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            /*var temp = Instantiate(Ball[index_ball], new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            temp.GetComponent<Rigidbody>().AddForce(Camera.main.transform.forward * puissance, ForceMode.VelocityChange);*/
            if (Saisi == false)
            {
                Saisi = true;
                Collider[] cols = Physics.OverlapSphere(main.position, radius);
                if (cols != null && cols.Length > 0)
                {
                    float distance_actuelle = Mathf.Infinity;
                    GameObject BalleSaisie = null;
                    foreach (Collider c in cols)
                    {
                        float distance = Vector3.Distance(main.transform.position, c.transform.position);
                        if (distance < distance_actuelle)
                        {
                            BalleSaisie = c.gameObject;
                        }

                    }
                    if(BalleSaisie!= null)
                    {
                        BalleSaisie.transform.position = main.position;
                        BalleSaisie.transform.parent = main;
                        BalleSaisie.GetComponent<Ball_script>().Grab();
                        BallGrab = BalleSaisie;
                    }
                }
            }
        }

        if (Input.GetButtonUp("Fire1"))
        {
            if (BallGrab != null)
            {
                BallGrab.transform.parent = null;
                BallGrab.GetComponent<Ball_script>().Throw(puissance, main.forward);
            }
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {

            transform.position = transform.position + transform.forward * speed;
            Saisi = false;
        }


        if (Input.GetKeyDown(KeyCode.M))
        {
            index_ball++;
            if(index_ball >= Ball.Length)
            {
                index_ball = 0;
            }
        }
    }
}
