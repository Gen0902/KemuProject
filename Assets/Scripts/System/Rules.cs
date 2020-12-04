using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RulesData", menuName = "ScriptableObjects/Rules", order = 1)]
public class Rules : ScriptableObject
{
    public float playerThrowForce = 10f;

    public int hitsToDestroyTiles = 0;
    //public bool playerStunIfBallHit = false;
    public bool scoreIfHitPlayer = false;
    public bool scoreIfDestroyTile = false;
    public bool scoreIfPlayerFalls = false;
    public bool scoreIfBallFalls = false;
    public bool rampChangeAlliegance = false;
    public int scoreMax = 3;
    public int timeMax = 120;
}
