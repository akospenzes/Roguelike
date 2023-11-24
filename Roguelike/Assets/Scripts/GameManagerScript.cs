using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public PowerUpScript powerUpManager;
    public GameObject map;
    public List<GameObject> obstacles;
    public GameObject player;
    public GameObject enemyPrefab;
    public float waveTime;
    public int enemyPerWave;

    public GameObject enemySpawnPoint;

    private int wavecount = 1;
    private List<GameObject> enemies;
    private bool waveActive = false;
    private bool windowActive;
    private bool enemiesSpawning = false; 
    void Start()
    {
        enemies = new List<GameObject>();
    }

    private void Update()
    {
        windowActive = powerUpManager.windowActive;

        if (!waveActive && !windowActive)
        {
            StartWave();
        }
        else if (waveActive && !enemiesSpawning)
        {
            if (CountEnemies() == 0)
            {
                EndWave();
            }
        }
    }

    private void StartWave()
    {
        enemiesSpawning = true;
        waveActive = true;
        enemies.Clear();
        for (int i = 0; i < wavecount * enemyPerWave; i++)
        {
            float delay = i * waveTime / enemyPerWave;

            if (i == 0)
            {
                SpawnEnemy();  
            }
            else if (i == wavecount * enemyPerWave - 1)
            {
                Invoke("SpawnLastEnemy", delay);
            }
            else
            {
                Invoke("SpawnEnemy", delay);
            }

        }
        wavecount++;
    }

    private void SpawnEnemy()
    {
        GameObject enemy = Instantiate(enemyPrefab, enemySpawnPoint.transform.position, enemySpawnPoint.transform.rotation);
        enemy.GetComponent<EnemyController>().SetAIDestination(player);
        //hp erosites
        enemies.Add(enemy);
    }

    private void SpawnLastEnemy()       //boss-hoz lehetne hasznalni
    {
        GameObject enemy = Instantiate(enemyPrefab, enemySpawnPoint.transform.position, enemySpawnPoint.transform.rotation);
        enemy.GetComponent<EnemyController>().SetAIDestination(player);
        //hp erosites
        enemies.Add(enemy);
        enemiesSpawning = false;
    }

    private void EndWave()
    {
        waveActive = false;
        powerUpManager.CreatePowerUpWindow();
    }
    private int CountEnemies()
    {
        int cnt = 0;

        foreach (GameObject e in enemies)
        {
            if (e != null) 
            {
                cnt++;
            }
        }
        return cnt;
    }
}
