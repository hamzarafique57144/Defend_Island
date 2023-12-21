using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private float spawnRange = 9f;
    public GameObject enemyPrefab;
    public int enemyCount;
    private int waveNumber = 1;
    public GameObject powerUpPrefab;
    PlayerController playerController;
    private void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        if(playerController.isGameRunnig)
        {
            Instantiate(powerUpPrefab, GenerateSpawnPos(), powerUpPrefab.transform.rotation);
            SpawnEnemyWave(waveNumber);

        }

    }
    private void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;
        Debug.Log(enemyCount);
        if(enemyCount==0 && playerController.isGameRunnig)
        {
            Instantiate(powerUpPrefab, GenerateSpawnPos(), powerUpPrefab.transform.rotation);
            waveNumber++;
            SpawnEnemyWave(waveNumber);
            
      
        }
    }
    private Vector3 GenerateSpawnPos()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 spawnPos = new Vector3(spawnPosX, 0, spawnPosZ);
        return spawnPos;
    }
    private void SpawnEnemyWave(int enemyToSpawn)
    {
        for(int i=0; i< enemyToSpawn;i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPos(), enemyPrefab.transform.rotation);
        }
        
    }
}
