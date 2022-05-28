using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefab;

    public Transform spawnPoint;

    public float timeBetweenWaves = 5f;
    private float countdown = 2f;

    public TMP_Text waveCountdownText;

    private int WaveNumber = 0;

    void Update(){
        if (countdown <= 0f){
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }

        countdown-= Time.deltaTime;

        waveCountdownText.text = Mathf.Round(countdown).ToString();
    }

    IEnumerator SpawnWave(){
        Debug.Log("Wave Incomming!");
        WaveNumber ++;
        for (int i = 0; i < WaveNumber; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
        
    }

    void SpawnEnemy(){
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }

    
}
