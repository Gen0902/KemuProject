using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]
public enum ETeam
{
    None,
    Team1,
    Team2
}

public static class TeamUtils
{
    public static ETeam GetOppositeTeam(ETeam team)
    {
        switch (team)
        {
            case ETeam.Team1:
                return ETeam.Team2;
            case ETeam.Team2:
                return ETeam.Team1;
            default:
                return ETeam.None;
        }
    }
}
