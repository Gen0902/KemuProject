using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Text_Manager : MonoBehaviour
{
    // ce script va géré les allé et venu du texte ainsi que son contenu

    string containText;
    [SerializeField] TextMesh mTextMesh;

    public float delay;// delai entre le changement de text
    float timer;
    public float DistanceVanish; // distance ou le text dois disparaitre
    float DistanceFinal;
    public float speed;
    enum textStep
    {
        Stop,
        Vanish,
        Invisible,
        Apparition
    }
    [SerializeField]
    textStep m_step;


    // Start is called before the first frame update
    void Start()
    {
        //ChangeText();
        m_step = textStep.Stop;
        timer = 0;
        DistanceFinal = mTextMesh.transform.position.z;
        ChangeText("Wait");
    }

    // Update is called once per frame
    void Update()
    {
        switch (m_step)
        {
            case textStep.Stop:
                return;
                break;
            case textStep.Vanish:
                mTextMesh.transform.position = new Vector3(mTextMesh.transform.position.x, mTextMesh.transform.position.y, mTextMesh.transform.position.z - speed);
                mTextMesh.color = new Color(1, 1, 1, transform.position.z / DistanceVanish);
                if(mTextMesh.transform.position.z < DistanceVanish)
                {
                    m_step = textStep.Invisible;
                    mTextMesh.color = new Color(1, 1, 1, 0);
                    mTextMesh.text = containText;
                }
                break;
            case textStep.Invisible:
                timer += Time.deltaTime;
                if(timer > delay)
                {
                    timer = 0;
                    m_step = textStep.Apparition;
                }
                break;
            case textStep.Apparition:
                mTextMesh.transform.position = new Vector3(mTextMesh.transform.position.x, mTextMesh.transform.position.y, mTextMesh.transform.position.z + speed);
                mTextMesh.color = new Color(1, 1, 1, transform.position.z / DistanceFinal);
                if (mTextMesh.transform.position.z >= DistanceFinal)
                {
                    m_step = textStep.Stop;
                    mTextMesh.color = new Color(1, 1, 1, 1);
                }
                break;
        }       
    }

    public void ChangeText(string newText)
    {
        containText = newText;
        m_step = textStep.Vanish;
    }


}
