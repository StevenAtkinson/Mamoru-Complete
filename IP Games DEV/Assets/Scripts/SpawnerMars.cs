using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// This is where the enemies are spawned from for the Mars level
public class SpawnerMars : MonoBehaviour
{
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;
    public GameObject enemy4;
    public GameObject boss;
    public GameObject LevelComplete;
    public GameObject GameOverText;
    int spawnActionIndex;
    float randX;
    public float spawnRate = 5f;
    Vector2 spawnPoint;
    float nextSpawn = 0.0f;
    int enemyCounter = 0;
    bool hasAllSpawned = false;
    bool hasBossSpawned = false;
    bool BossDestroyed = false;
    


    // Start is called before the first frame update
    void Awake()
    {
        boss.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // this ends the game is the player has been destroyed 
        if (GameObject.FindWithTag("Player") == null)
        {
            gameOver();
        }
        // this loads the next level if the boss has been spawned and destroyed 
        if (hasBossSpawned && BossDestroyed)
        {
            LevelComplete.SetActive(true);
            Invoke("loadNextLevel", 4);
        }
        // this checks if the boss has been destroyed after it has spawned 
        if (hasBossSpawned)
        {
            if (GameObject.FindWithTag("Boss") == null)
            {
                BossDestroyed = true;
            }


        }

        if (hasAllSpawned)
        {
            return;
        }

        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            randX = Random.Range(-1.5f, 1.5f);
            spawnPoint = new Vector2(randX, transform.position.y);
            Instantiate(enemy1, spawnPoint, Quaternion.identity);
            enemyCounter++;
            Instantiate(enemy2, spawnPoint, Quaternion.identity);
            enemyCounter++;

            if (enemyCounter > 20)
            {
                Instantiate(enemy3, spawnPoint, Quaternion.identity);
                enemyCounter++;
                Instantiate(enemy4, spawnPoint, Quaternion.identity);
                enemyCounter++;
            }
            // if the enemy counter is greater than 30 then stop spawning enemies and spawn the boss 
            if (enemyCounter > 50  )
            {
                Invoke ("spawnBoss", 6);
                hasAllSpawned = true;

            }

        }
        
    }
    // this function spawns the boss 
    private void spawnBoss()
    {
        boss.gameObject.SetActive(true);
        hasBossSpawned = true;

    }
    // this function loads the next level and is called once the boss has been spawned and destroyed 
    private void loadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    // this displays the game over text and returns to the main menu if the player has been destroyed 
    void gameOver()
    {
        GameOverText.SetActive(true);
        Invoke("mainMenu", 5);

    }
    // this loads the main menu 
    void mainMenu()
    {
        SceneManager.LoadScene("Start Screen");
    }

}