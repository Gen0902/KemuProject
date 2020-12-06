using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Ball settings")]
    [Range(0.1f, 10)] public float throwerForce = 8f;

    [Header("Game Rules")]
    public Rules rules;

    [Space]
    [Header("Menus")]
    [Header("--------------------")]

    [SerializeField] ScoreManager scoreManager;
    [SerializeField] MenuManager menuManager;
    [SerializeField] BallThrower ballThrower;

    [Header("Tiles")]
    public GroundTile[] tileSet1;
    public GroundTile[] tileSet2;

    [Header("Layers")]
    public LayerMask ballLayer;
    public LayerMask groundLayer;

    [Header("Materials")]
    public Material team1Mat;
    public Material team2Mat;


    [Header("Spawn")]
    public Transform player1Spawn;
    public Transform player2Spawn;

    private int scoreTeam1 = 0;
    private int scoreTeam2 = 0;
    private float playTimer = 0f;
    private bool gamePaused = true;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogWarning("More than one instance of GameManager found !");
            return;
        }
        Instance = this;
    }

    void Start()
    {
        for (int i = 0; i < tileSet1.Length; i++)
            tileSet1[i].ResetTile();

        for (int i = 0; i < tileSet2.Length; i++)
            tileSet2[i].ResetTile();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ballThrower.ThrowBall(throwerForce);
        }

        if (!gamePaused)
        {
            playTimer += Time.deltaTime;
            scoreManager.UpdateTimer(playTimer);
        }

    }

    public bool CheckBallPresency()
    {
        Ball ball = FindObjectOfType<Ball>();
        if (ball != null && ball.gameObject.activeSelf)
            return true;
        else return false;
    }

    public void CreateBall()
    {
        ballThrower.ThrowBall(throwerForce);
    }

    public void IncrementScore(ETeam team)
    {
        switch (team)
        {
            case ETeam.Team1:
                scoreTeam1++;
                break;
            case ETeam.Team2:
                scoreTeam2++;
                break;
            default:
                break;
        }
        scoreManager.UpdateScore(scoreTeam1, scoreTeam2);
    }

    public void ResetGame()
    {
        playTimer = 0;
        scoreManager.ResetPanels();
    }

    public void ReplacePlayer(PlayerController player)
    {
        Vector3 spawnPos;
        if (player.team == ETeam.Team2)
        {
            spawnPos = player2Spawn.position;
            for (int i = 0; i < tileSet2.Length; i++)
                tileSet1[i].ResetTile();
        }
        else
        {
            spawnPos = player1Spawn.position;
            for (int i = 0; i < tileSet1.Length; i++)
                tileSet1[i].ResetTile();
        }

        player.Stop();
        player.transform.position = spawnPos;
        
    }

    public void Pause(bool pause)
    {

    }
}
