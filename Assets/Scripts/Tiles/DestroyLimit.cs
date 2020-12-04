﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyLimit : MonoBehaviour
{
    public ETeam team;
    public bool destroyPlayer = false;

    private void OnTriggerEnter(Collider other)
    {
        Ball ball = other.gameObject.GetComponent<Ball>();
        if (ball != null)
        {
            if (ball.teamAllegiance != ETeam.None && GameManager.Instance.rules.scoreIfBallFalls && ball.teamAllegiance == TeamUtils.GetOppositeTeam(team))
            {
                GameManager.Instance.IncrementScore(ball.teamAllegiance);
            }
            Destroy(ball.gameObject);
            return;
        }

        PlayerController player = other.gameObject.GetComponent<PlayerController>();
        if (player != null && destroyPlayer)
        {
            if (player.team != ETeam.None && GameManager.Instance.rules.scoreIfPlayerFalls)
            {
                GameManager.Instance.IncrementScore(TeamUtils.GetOppositeTeam(player.team));
            }
            GameManager.Instance.ReplacePlayer(player);
            return;
        }

    }
}
