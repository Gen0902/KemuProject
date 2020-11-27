using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Ball settings")]
    [Range(0.1f, 10)] public float throwForce = 2f;

    [Header("Game Rules")]
    public Rules rules;

    [Space]

    [Header("Menus")]
    [SerializeField] ScoreManager scoreManager;
    [SerializeField] MenuManager menuManager;
    [SerializeField] BallThrower ballThrower;

    [Header("Tiles")]
    public GroundTile[] tileSet1;
    public GroundTile[] tileSet2;

    [Header("Layers")]
    public LayerMask ballLayer;
    public LayerMask groundLayer;
    //public LayerMask tilesLayer;
    //public LayerMask wallLayer;

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

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ballThrower.ThrowBall(throwForce);
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
        ballThrower.ThrowBall(throwForce);
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
    }

    public void ResetGame()
    {
        playTimer = 0;
        scoreManager.ResetPanels();
    }

    public void ReplacePlayer(PlayerController player)
    {

    }

    public void Pause(bool pause)
    {

    }
}
