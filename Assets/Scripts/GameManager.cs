using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject obstacle;
    public float maxX;
    public Transform spawnPoint;
    public float spawnRate;

    bool gameStarted = false;
    

    public GameObject tapText;
    public TextMeshProUGUI scoreText;

    int score = 0;
    
   

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

        Instantiate( obstacle, spawnPos, Quaternion.identity );

        score++;

        scoreText.text = "Score: " + score.ToString();
    }
}
