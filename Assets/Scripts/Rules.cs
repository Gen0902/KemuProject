using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RulesData", menuName = "ScriptableObjects/Rules", order = 1)]
[SerializeField]
public class Rules : ScriptableObject
{
    public int hitsToDestroyTiles = 0;
    //public bool playerStunIfBallHit = false;
    public bool scoreIfHitPlayer = false;
    public bool scoreIfHitGround = false;
    public bool scoreIfPlayerFalls = false;
    public bool scoreIfBallFalls = false;
    public int scoreMax = 3;
    public int timeMax = 120;
}
