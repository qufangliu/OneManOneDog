using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    private Vector3 campPositionOld;
    private readonly float campThresholdDistance = 1.5f;

    private Wave currentWave;
    private int currentWaveNumber;
    public bool devMode;
    private int enemiesRemainingAlive;

    private int enemiesRemainingToSpawn;
    public Enemy[] enemys;
    public Transform[] spawnPoints;
    
    private bool isDisabled;

    private float nextCampCheckTime;
    private float nextSpawnTime;

    private LivingEntity playerEntity;
    private Transform playerT;

    //Spawn tile material
    public float timeBetweenCampingChecks = 2;
    public Wave[] waves;

    public event Action<int> OnNewWave;

    private void Start()
    {
        transform.position = new Vector3(transform.position.x,0,transform.position.z);
        playerEntity = FindObjectOfType<Player>();
        playerT = playerEntity.transform;
        nextCampCheckTime = timeBetweenCampingChecks + Time.time;
        campPositionOld = playerT.position;
        playerEntity.OnDeath += OnPlayerDeath;
        NextWave();
    }

    // Update is called once per frame
    private void Update()
    {
        if (!isDisabled)
        {
            if (Time.time > nextCampCheckTime)
            {
                nextCampCheckTime = timeBetweenCampingChecks + Time.time;
                campPositionOld = playerT.position;
            }

            if ((enemiesRemainingToSpawn > 0 || currentWave.infinite) && Time.time > nextSpawnTime)
            {
                enemiesRemainingToSpawn--;
                nextSpawnTime = Time.time + currentWave.timeBetweenSpawns;
                StartCoroutine(nameof(SpawnEnemy));
            }
        }

        if (devMode)
            if (Input.GetKeyDown(KeyCode.N))
            {
                StopCoroutine(nameof(SpawnEnemy));
                foreach (var enemy in FindObjectsOfType<Enemy>()) Destroy(enemy.gameObject);
                NextWave();
            }
    }

    private IEnumerator SpawnEnemy()
    {
        float spawnDelay = 1;
        float spawnTimer = 0;
        while (spawnTimer < spawnDelay)
        {
            spawnTimer += Time.deltaTime;
            yield return null;
        }

        var spawnEnemy = Instantiate(enemys[Random.Range(0,enemys.Length)],spawnPoints[Random.Range(0,spawnPoints.Length)].position, Quaternion.identity,transform);
        spawnEnemy.OnDeath += OnEnemyDeath;
        // spawnEnemy.SetCharacteristics(currentWave.moveSpeed, currentWave.enemyDamage, currentWave.enemyHealth,
        //     currentWave.skinColour);
    }

    private void ResetPlayerPosition()
    {
        playerT.position = Vector3.zero;
    }

    private void OnPlayerDeath()
    {
        isDisabled = true;
    }

    private void OnEnemyDeath()
    {
        enemiesRemainingAlive--;
        if (enemiesRemainingAlive == 0)
        {
            print("Wave:" + currentWaveNumber);
            NextWave();
        }
    }

    private void NextWave()
    {
        // if (currentWaveNumber > 0) AudioManager.instance.PlaySound2D("Level Completed");
        currentWaveNumber++;
        if (currentWaveNumber - 1 < waves.Length)
        {
            currentWave = waves[currentWaveNumber - 1];
            enemiesRemainingToSpawn = currentWave.enemyCount;
            enemiesRemainingAlive = enemiesRemainingToSpawn;
            OnNewWave?.Invoke(currentWaveNumber);
            ResetPlayerPosition();
        }
    }

    [Serializable]
    public class Wave
    {
        public int enemyCount;
        public bool infinite;
        public float timeBetweenSpawns;
    }
}