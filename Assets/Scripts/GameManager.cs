using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    private const string HIGH_SCORE_KEY = "High Score";

    //public GameObject obstacle;
    public float maxX;
    public Transform spawnPoint;
    public float spawnRate;

    bool gameStarted = false;
    

    public GameObject tapText;
    public TMP_Text scoreText;
    public TMP_Text highScoreText;

    private int score;
    private int _highScore;


    private void Start()
    {
        _highScore = PlayerPrefs.GetInt(HIGH_SCORE_KEY, 0);
        UpdateUI();
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && !gameStarted)
        {
            StartSpawning();

            gameStarted = true;
            tapText.SetActive(false);
        }
        
    }

    private void StartSpawning()
    {
        InvokeRepeating("SpawnObstacle", 0.5f, spawnRate);
    }

    private void SpawnObstacle()
    {
        Vector2 spawnPos = spawnPoint.position;

        spawnPos.x = Random.Range(-maxX, maxX);

        //Instantiate( obstacle, spawnPos, Quaternion.identity );

        score++;
        if (score > _highScore)
        {
            _highScore = score;
            PlayerPrefs.SetInt(HIGH_SCORE_KEY, _highScore);
        }

        UpdateUI();
    }

    private void UpdateUI()
    {
        scoreText.text = $"<color=red>Score</color>: {score}";
        highScoreText.text = $"<color=red>High score</color>: {_highScore}";

    }
}
