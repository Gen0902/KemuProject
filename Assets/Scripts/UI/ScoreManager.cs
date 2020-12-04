using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ScoreManager : MonoBehaviour
{
    [Header("Preview Panel")]
    [SerializeField] GameObject[] tileIconSet1;
    [SerializeField] GameObject[] tileIconSet2;


    [Header("Score Panel")]
    [SerializeField] TextMeshProUGUI[] scoreTexts1;
    [SerializeField] TextMeshProUGUI[] scoreTexts2;
    [SerializeField] TextMeshProUGUI timerText;

    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.Instance.tileSet1.Length != tileIconSet1.Length)
            Debug.LogError("TileSet1 and TileIconSet1 arrays doesn't match");
        if (GameManager.Instance.tileSet2.Length != tileIconSet2.Length)
            Debug.LogError("TileSet2 and TileIconSet2 arrays doesn't match");
    }

    public void UpdateTimer(float time)
    {
        timerText.text = time.ToString("00");
    }

    public void UpdateScore(int score1, int score2)
    {
        foreach (TextMeshProUGUI textMesh in scoreTexts1)
            textMesh.text = score1.ToString() ;

        foreach (TextMeshProUGUI textMesh in scoreTexts2)
            textMesh.text = score2.ToString() ;
    }

    public void UpdateTileIcons()
    {
        for (int i = 0; i < tileIconSet1.Length; i++)
        {
            tileIconSet1[i].GetComponent<Image>().enabled = GameManager.Instance.tileSet1[i] != null && GameManager.Instance.tileSet1[i].gameObject.activeSelf;
        }

        for (int i = 0; i < tileIconSet2.Length; i++)
        {
            tileIconSet2[i].GetComponent<Image>().enabled = GameManager.Instance.tileSet2[i] != null && GameManager.Instance.tileSet2[i].gameObject.activeSelf;
        }
    }

    public void ResetPanels()
    {
        UpdateScore(0, 0);
        for (int i = 0; i < tileIconSet1.Length; i++)
            tileIconSet1[i].SetActive(true);
        for (int i = 0; i < tileIconSet2.Length; i++)
            tileIconSet2[i].SetActive(true);
    }
}


