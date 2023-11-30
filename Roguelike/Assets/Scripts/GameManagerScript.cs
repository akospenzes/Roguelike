using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public PowerUpScript powerUpManager;
    public GameObject map;
    public GameObject player;
    public GameObject enemyPrefab;
    public float waveTime;
    public int enemyPerWave;
    public GameObject EndGameUI;
    public TextMeshProUGUI scoreText;
    public float spawnRadius;
    public GameObject healthPickUpPrefab;
    public List<GameObject> obstacles;
    public TMPro.TMP_Text waveText;
    public TMPro.TMP_Text enemiesLeftText;

    //public GameObject enemySpawnPoint;
 
    private int waveCount = 1;
    private List<GameObject> enemies;
    private bool waveActive = false;
    private bool windowActive;
    private bool enemiesSpawning = false;
    private int spawnedEnemiesCount;
    private PlayerController pc;
    void Start()
    {
        enemies = new List<GameObject>();
        pc = player.GetComponent<PlayerController>();

        waveTime = MenuManager.WaveTime * 1.0f;
        enemyPerWave = MenuManager.EnemiesPerWave;

        if (waveTime == 0.0f)
        {
            waveTime = 60.0f;
        }
        if (enemyPerWave == 0)
        {
            enemyPerWave = 10;
        }
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
            windowActive = true;
            EndGame();
        }

        UpdatePlayerUI();
    }

    private void StartWave()
    {
        enemiesSpawning = true;
        waveActive = true;
        enemies.Clear();
        spawnedEnemiesCount = 0;
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

        GameObject enemy = Instantiate(enemyPrefab, enemySpawn, Quaternion.identity);
        EnemyController ec = enemy.GetComponent<EnemyController>();
        ec.SetAIDestination(player);
        ec.SetMaxHealth(100.0f + waveCount - 1 * 10.0f);
        ec.IncreaseDamage(waveCount - 1 * 3);
        enemies.Add(enemy);
        spawnedEnemiesCount++;
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

        GameObject enemy = Instantiate(enemyPrefab, enemySpawn, Quaternion.identity);
        EnemyController ec = enemy.GetComponent<EnemyController>();
        ec.SetAIDestination(player);
        ec.SetMaxHealth(100.0f + waveCount * 10.0f);
        enemies.Add(enemy);
        enemiesSpawning = false;
        spawnedEnemiesCount++;
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

        foreach (GameObject o in obstacles)
        {
            if (pos.x < o.transform.position.x + o.transform.localScale.x / 2.0f
                && pos.x > o.transform.position.x - o.transform.localScale.x / 2.0f
                && pos.y < o.transform.position.y + o.transform.localScale.y / 2.0f
                && pos.y > o.transform.position.y - o.transform.localScale.y / 2.0f)
            {
                pos.x -= o.transform.localScale.x / 2.0f;
            }
        }

        GameObject healthPickUp = Instantiate(healthPickUpPrefab, pos, Quaternion.identity);
        healthPickUp.gameObject.GetComponent<HealthPickUpScript>().SetHealthAmount(healthAmount);
    }

    private void UpdatePlayerUI()
    {
        waveText.text = "Wave : " + waveCount.ToString();
        int e_left = waveCount * enemyPerWave - spawnedEnemiesCount + CountEnemies();
        enemiesLeftText.text = "Enemies left : " + e_left.ToString();
    }
}
