using System.Collections.Generic;
using UnityEngine;

namespace AG2189
{
    public class ObstacleSpawner : MonoBehaviour
    {
        public Transform spawnPoint;
        public SimpleObstacle simpleObstaclePrefab;
        public RotatingObstacle rotatingObstaclePrefab;
        public GameManager gameManager;

        //public Obstacle simpleObstaclePrefab;
        //public Obstacle rotatingObstaclePrefab;
        //public GameObject simpleObstaclePrefab;
        //public GameObject rotatingObstaclePrefab;

        public float spawnInterval = 1.5f;
        private float timer;

        private List<Obstacle> obstacles = new List<Obstacle>();

        void Update()
        {

            if (gameManager.gameStarted)
            {
                timer += Time.deltaTime;
                if (timer >= spawnInterval)
                {
                    SpawnRandomObstacle();
                    timer = 0f;
                }

                // Communicate with each obstacle
                for (int i = obstacles.Count - 1; i >= 0; i--)
                {
                    if (obstacles[i] == null)
                    {
                        obstacles.RemoveAt(i); // Clean up destroyed obstacles
                    }
                    else
                    {
                        obstacles[i].Fall();
                    }
                }
            }
        }

        void SpawnRandomObstacle()
        {
            Obstacle prefab = Random.value > 0.5f ? (Obstacle)simpleObstaclePrefab : (Obstacle)rotatingObstaclePrefab;
            //Obstacle prefab = Random.value > 0.5f ? simpleObstaclePrefab : rotatingObstaclePrefab;
            //GameObject prefab = Random.value > 0.5f ? simpleObstaclePrefab : rotatingObstaclePrefab;
            float x = Random.Range(-2.5f, 2.5f);
            Vector3 spawnPos = new Vector3(x, Camera.main.orthographicSize + 1f,-0.01f);

            Obstacle newObstacle = Instantiate(prefab, spawnPos, Quaternion.identity);
            obstacles.Add(newObstacle);

            //Vector2 spawnPos = new Vector2(x, Camera.main.orthographicSize + 1f);
            //Instantiate(prefab, spawnPos, Quaternion.identity);
        }
    }
}