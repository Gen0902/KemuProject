using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [Header("Main")]
    public GameObject mainPanel;

    [Header("Game Settings Panel")]
    public GameObject settingsPanel;

    public Toggle playerStunIfBallHit;
    public Toggle scoreIfHitPlayer;
    public Slider hitsToDestroyTiles;
    public Slider scoreMax;
    public Slider timeMax;

    public void ApplySettings()
    {

    }

    public void ShowSettings()
    {

    }
}
