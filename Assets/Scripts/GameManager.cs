using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{

    public GameObject playerPrefab;
    public GameObject enemyOnePrefab;
    public GameObject cloudPrefab;
    public GameObject powerUp_HealthPrefab;
    public GameObject powerUp_ShieldPrefab;
    public GameObject CoinPrefab;
    public int score;
    public int cloudsMove;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI livesText;
    public TextMeshProUGUI shieldText;
   

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(playerPrefab, transform.position, Quaternion.identity);
        CreateSky();
        InvokeRepeating("SpawnEnemyOne", 1f, 2f);
        InvokeRepeating("CreateCoin", 1f, 10f);
        Instantiate(powerUp_HealthPrefab, transform.position = new Vector3(-15, 0, 0), Quaternion.identity);
        Instantiate(powerUp_ShieldPrefab, transform.position = new Vector3(25, 0, 0), Quaternion.identity);
        cloudsMove = 1;
        score = 0;
        scoreText.text = "Score: " + score;
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    void SpawnEnemyOne()
    {
        Instantiate(enemyOnePrefab, new Vector3(Random.Range(-8, 8), 7.5f, 0), Quaternion.Euler(0, 0, 180));
    }

    void CreateSky()
    {
        for (int i = 0; i < 50; i++)
        {
            Instantiate(cloudPrefab, new Vector3(Random.Range(-11f, 11f), Random.Range(-7.5f, 7.5f), 0), Quaternion.identity);
        }
    }

    void CreateCoin()
    {
        Instantiate(CoinPrefab, new Vector3(Random.Range(-8, 8), 7, 0), Quaternion.identity);
    }


    public void GameOver()
    {
        CancelInvoke();
        cloudsMove = 0;
    }

   
    public void EarnScore(int scoreToAdd)
    {
        score = score + scoreToAdd;
        scoreText.text = "Score: " + score;
    }
}
