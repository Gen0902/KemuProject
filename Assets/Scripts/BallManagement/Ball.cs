using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody rb;
    [SerializeField] Light light;
    [SerializeField] Renderer renderer;

    [HideInInspector] public ETeam teamAllegiance;

    private bool isDestroying = false;

    // Start is called before the first frame update
    void Start()
    {
        ChangeAllegiance(ETeam.None);
        isDestroying = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (isDestroying)
            return;

        GroundTile tile = collision.gameObject.GetComponent<GroundTile>();
        PlayerController player = collision.gameObject.GetComponent<PlayerController>();
        Ramp ramp = collision.gameObject.GetComponent<Ramp>();

        if (tile != null)
        {
            if (tile.HandleHit(teamAllegiance))
                Disintegrate();
        }
        else if (player != null && player.team == TeamUtils.GetOppositeTeam(teamAllegiance))
        {
            if (GameManager.Instance.rules.scoreIfHitPlayer)
            {
                GameManager.Instance.IncrementScore(teamAllegiance);
                Disintegrate();
            }
        }
        else if (ramp != null)
        {
            if (GameManager.Instance.rules.rampChangeAlliegance)
                ChangeAllegiance(ramp.team);
        }
    }

    public void ChangeAllegiance(ETeam team)
    {
        teamAllegiance = team;
        switch (team)
        {
            case ETeam.None:
                SetEmisionColor(Color.white);
                break;
            case ETeam.Team1:
                SetEmisionColor(Color.blue);
                break;
            case ETeam.Team2:
                SetEmisionColor(Color.red);
                break;
            default:
                break;
        }
    }

    private void SetEmisionColor(Color color)
    {
        renderer.material.EnableKeyword("_EMISSION");
        renderer.material.SetColor("_EmissionColor", color * 2f);
        light.color = color;
    }

    public void Stop()
    {
        rb.detectCollisions = false;
        rb.velocity = Vector3.zero;
        rb.rotation = Quaternion.identity;
    }

    public void Launch(Vector3 direction, float force)
    {
        Stop();
        rb.detectCollisions = true;
        rb.AddForce(direction.normalized * force, ForceMode.Impulse);
    }

    public void Launch(Vector3 launchForce)
    {
        Stop();
        rb.detectCollisions = true;
        rb.AddForce(launchForce, ForceMode.Impulse);
    }

    private void Disintegrate()
    {
        isDestroying = true;
        Destroy(gameObject);
    }
}
