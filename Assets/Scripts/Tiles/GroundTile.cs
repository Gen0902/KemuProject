using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTile : MonoBehaviour
{
    [Header("Material Settings")]
    [SerializeField] new MeshRenderer renderer;
    [SerializeField] Material hitMaterial;

    [Header("Team")]
    public ETeam team;

    private Material baseMaterial;
    private int hit = 0;

    private void Start()
    {
        baseMaterial = renderer.material;
    }

    public bool HandleHit(ETeam ballTeam)
    {
        if (ballTeam == TeamUtils.GetOppositeTeam(team))
        {
            if (GameManager.Instance.rules.hitsToDestroyTiles > 0)
            {
                hit++;
                if (hit >= GameManager.Instance.rules.hitsToDestroyTiles)
                {
                    if (GameManager.Instance.rules.scoreIfDestroyTile)
                        GameManager.Instance.IncrementScore(ballTeam);
                    DisableTile();
                }
                else
                    renderer.material = hitMaterial;
            }
            else if (GameManager.Instance.rules.scoreIfDestroyTile)
                GameManager.Instance.IncrementScore(ballTeam);

            return true;
        }
        else //Ball hit tile of same team
        {
            return false;
            //Start glow effect
        }


    }

    public void ResetTile()
    {
        renderer.material = baseMaterial;
        hit = 0;
        gameObject.SetActive(true);
    }

    private void DisableTile()
    {
        gameObject.SetActive(false);
    }
}
