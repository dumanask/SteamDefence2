using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;


namespace SD
{
    [System.Serializable]
    public class EnemyStructure
    {
        [HideInInspector] public string Name;
        public GameObject enemyType;
        public float timeToNextEnemy;
    }

    [System.Serializable]
    public class Waves
    {
        [HideInInspector] public string Name;
        [NonReorderable]
        public EnemyStructure[] enemiesInWave;
    }

    public class SpawnManager : MonoBehaviour
    {
        [Header("Waves")]
        [SerializeField]
        private int currentWave;
        [SerializeField]
        private bool spawning;
        [SerializeField]
        private Waves[] totalWaves;

        [Header("Setup")]
        [SerializeField]
        private Transform spawnPosition1;

        [SerializeField]
        private Transform spawnPosition2;
        [SerializeField]
        private Transform enemyHolder;

        [Header("Properties")]
        [SerializeField]
        private float timeBetweenWaves;

        private float waveCountdown;
             

        private void OnValidate()
        {
            RewriteArrays();
        }
        void RewriteArrays()
        {
            for (int i = 0; i < totalWaves.Length; i++)
            {
                totalWaves[i].Name = "Wave " + (i + 1);
                for (int x = 0; x < totalWaves[i].enemiesInWave.Length; x++)
                {
                    totalWaves[i].enemiesInWave[x].Name = "Enemy " + (x + 1);
                }
            }
        }

        private void Start()
        {
            Transform transform = GetComponent<Transform>();
            spawning = false;
            waveCountdown = timeBetweenWaves;
            currentWave = 0;
        }

        private void Update()
        {
            if (!spawning ) // if game is not paused or finished
            {
                waveCountdown -= Time.deltaTime;
                if (waveCountdown <= 0)
                {
                    currentWave++;
                    StartCoroutine(SpawnWave());                    
                }
            }
        }

        IEnumerator SpawnWave()
        {
            int waveIndex = currentWave;
            spawning = true;
            waveCountdown = timeBetweenWaves;
            for (int i = 0; i < totalWaves[waveIndex - 1].enemiesInWave.Length; i++)
            {
                SpawnEnemy(totalWaves[waveIndex -1].enemiesInWave[i].enemyType);
                yield return new WaitForSeconds(totalWaves[waveIndex -1].enemiesInWave[i].timeToNextEnemy);
            }
            spawning = false;          
        }

        void SpawnEnemy(GameObject enemy)
        {
            float xPos = UnityEngine.Random.Range(spawnPosition1.position.x, spawnPosition2.position.x);
            float yPos = UnityEngine.Random.Range(spawnPosition1.position.y, spawnPosition2.position.y);
            float zPos = UnityEngine.Random.Range(spawnPosition1.position.z, spawnPosition2.position.z);

            Vector3 spawnPosition = new Vector3(xPos,yPos,zPos);
            transform.position = spawnPosition;

            GameObject spawnedEnemy = Instantiate(enemy, transform.position, Quaternion.identity);
            spawnedEnemy.transform.SetParent(enemyHolder);
        }
    }
}