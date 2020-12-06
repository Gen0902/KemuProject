using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Text_script : MonoBehaviour
{

    public Font m_font;
    public MeshFilter planeMesh;

    public string the_text;


    private void Awake()
    {
        planeMesh.GetComponent<MeshRenderer>().material.mainTexture = m_font.material.mainTexture;
    }

    // Start is called before the first frame update
    void Start()
    {
        Display_Text();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void Display_Text()
    {

        m_font.RequestCharactersInTexture(the_text);

        for(int i =0; i < the_text.Length; i++)
        {
            CharacterInfo character;
            m_font.GetCharacterInfo(the_text[i], out character);

            Vector2[] uvs = new Vector2[4];
            uvs[0] = character.uvBottomLeft;
            uvs[1] = character.uvTopRight;
            uvs[2] = character.uvBottomRight;
            uvs[3] = character.uvTopLeft;

            planeMesh.mesh.uv = uvs;

            Vector3 newScale = planeMesh.transform.localScale;
            newScale.x = character.glyphWidth * 0.02f;

            planeMesh.transform.localScale = newScale;

        }

    }
}
