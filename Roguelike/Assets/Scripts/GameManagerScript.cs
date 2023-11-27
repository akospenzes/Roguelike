using System.Collections;
using System.Collections.Generic;
using TMPro;
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
    public GameObject EndGameUI;
    public TextMeshProUGUI scoreText;
    public float spawnRadius;
    public GameObject healthPickUpPrefab;

    public GameObject enemySpawnPoint;

    private int waveCount = 1;
    private List<GameObject> enemies;
    private bool waveActive = false;
    private bool windowActive;
    private bool enemiesSpawning = false;
    private PlayerController pc;
    void Start()
    {
        enemies = new List<GameObject>();
        pc = player.GetComponent<PlayerController>();
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
        if (pc.currentHealth <= 0)
        {
            EndGame();
        }
    }

    private void StartWave()
    {
        enemiesSpawning = true;
        waveActive = true;
        enemies.Clear();
        for (int i = 0; i < waveCount * enemyPerWave; i++)
        {
            float delay = i * waveTime / enemyPerWave;

            if (i == 0)
            {
                SpawnEnemy();  
            }
            else if (i == waveCount * enemyPerWave - 1)
            {
                Invoke("SpawnLastEnemy", delay);
            }
            else
            {
                Invoke("SpawnEnemy", delay);
            }
        }

        int healthPickUpAmount = waveCount / 3;

        for (int i = 0; i < healthPickUpAmount; i++)
        {
            SpawnHealthPickUp(waveCount * 5);
        }
    }

    private void SpawnEnemy()
    {
        Vector2 playerPoint = player.transform.position;
        float degree = Random.Range(0.0f, 359.9f);

        float dx = spawnRadius * Mathf.Cos(degree);
        float dy = spawnRadius * Mathf.Sin(degree);

        if (playerPoint.x + dx >= 75.0f || playerPoint.x + dx <= -75.0f)
        {
            dx *= -1.0f;
        }
        if (playerPoint.y + dy >= 60.0f || playerPoint.y + dy <= -60.0f)
        {
            dy *= -1.0f;
        }

        Vector2 enemySpawn = new Vector2(playerPoint.x + dx, playerPoint.y + dy);

        foreach (GameObject o in obstacles)
        {
            if (enemySpawn.x < o.transform.position.x + o.transform.localScale.x / 2.0f
                && enemySpawn.x > o.transform.position.x - o.transform.localScale.x / 2.0f
                && enemySpawn.y < o.transform.position.y + o.transform.localScale.y / 2.0f
                && enemySpawn.y > o.transform.position.y - o.transform.localScale.y / 2.0f)
            {
                enemySpawn.x -= o.transform.localScale.x / 2.0f;
            }
        }

        GameObject enemy = Instantiate(enemyPrefab, enemySpawn, enemySpawnPoint.transform.rotation);
        EnemyController ec = enemy.GetComponent<EnemyController>();
        ec.SetAIDestination(player);
        ec.SetMaxHealth(100.0f + waveCount - 1 * 10.0f);
        ec.IncreaseDamage(waveCount - 1 * 3);
        enemies.Add(enemy);
    }

    private void SpawnLastEnemy()
    {
        Vector2 playerPoint = player.transform.position;
        float degree = Random.Range(0.0f, 359.9f);

        float dx = spawnRadius * Mathf.Cos(degree);
        float dy = spawnRadius * Mathf.Sin(degree);

        if (playerPoint.x + dx >= 75.0f || playerPoint.x + dx <= -75.0f)
        {
            dx *= -1.0f;
        }
        if (playerPoint.y + dy >= 60.0f || playerPoint.y + dy <= -60.0f)
        {
            dy *= -1.0f;
        }

        Vector2 enemySpawn = new Vector2(playerPoint.x + dx, playerPoint.y + dy);

        foreach (GameObject o in obstacles)
        {
            if (o.transform.position.x == enemySpawn.x && o.transform.position.y == enemySpawn.y)
            {
                enemySpawn.x -= o.transform.localScale.x;
            }
        }

        GameObject enemy = Instantiate(enemyPrefab, enemySpawnPoint.transform.position, enemySpawnPoint.transform.rotation);
        EnemyController ec = enemy.GetComponent<EnemyController>();
        ec.SetAIDestination(player);
        ec.SetMaxHealth(100.0f + waveCount * 10.0f);
        enemies.Add(enemy);
        enemiesSpawning = false;
    }

    private void EndWave()
    {
        waveCount++;
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

    private void EndGame()
    {
        CreateEndGameWindow();
    }

    private void CreateEndGameWindow()
    {
        EndGameUI.SetActive(true);
        scoreText.text = "Waves survived: \n" + (waveCount - 1);
    }

    private void SpawnHealthPickUp(int healthAmount)
    {
        float x = Random.Range(-75.0f, 75.0f);
        float y = Random.Range(-60.0f, 60.0f);

        Vector2 pos = new Vector2(x, y);

        GameObject healthPickUp = Instantiate(healthPickUpPrefab, pos, enemySpawnPoint.transform.rotation);
        healthPickUp.gameObject.GetComponent<HealthPickUpScript>().SetHealthAmount(healthAmount);
    }
}
