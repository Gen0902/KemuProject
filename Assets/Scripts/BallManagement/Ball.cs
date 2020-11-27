using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody rb;
    [SerializeField] Light light;
    [SerializeField] Renderer renderer;

    [HideInInspector] public ETeam teamAllegiance;

    // Start is called before the first frame update
    void Start()
    {
        ChangeAllegiance(ETeam.None);
    }

    private void OnCollisionEnter(Collision collision)
    {
        GroundTile tile = collision.gameObject.GetComponent<GroundTile>();
        if (tile != null)
        {
            tile.HandleHit(teamAllegiance);
            Disintegrate();
            return;
        }

        PlayerController player = collision.gameObject.GetComponent<PlayerController>();
        if (player != null && player.team == TeamUtils.GetOppositeTeam(teamAllegiance))
        {
            if (GameManager.Instance.rules.scoreIfHitPlayer)
                GameManager.Instance.IncrementScore(teamAllegiance);
            Disintegrate();
            return;
        }
    }

    public void ChangeAllegiance(ETeam team)
    {
        switch (team)
        {
            case ETeam.None:
                SetEmisionColor(Color.white);
                break;
            case ETeam.Team1:
                SetEmisionColor(Color.red);
                break;
            case ETeam.Team2:
                SetEmisionColor(Color.blue);
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
        Debug.Log("Destroy ball");
        //Destroy(gameObject);
    }
}
