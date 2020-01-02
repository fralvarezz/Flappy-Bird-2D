using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{

    public static GameControl instance;
    public GameObject gameOverText;
    public Text scoreText;
    public bool gameOver = false;
    public float scrollSpeed = -1.5f;
    private int score = 0;
    private float timeSinceLastSpeedChange = 0;
    public float speedChangeRate = 2f;
    public float columnSpawnRate = 2f;
    
    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastSpeedChange += Time.deltaTime;
        if (!gameOver && timeSinceLastSpeedChange >= speedChangeRate)
        {
            timeSinceLastSpeedChange = 0;
            this.scrollSpeed -= 0.2f;
            columnSpawnRate = -10 / scrollSpeed;
        }
        
        if (gameOver && Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void BirdScored()
    {
        if (gameOver)
        {
            return;
        }

        score++;
        scoreText.text = "Score: " + score.ToString();
    }
    public void BirdDied()
    {
        gameOverText.SetActive(true);
        gameOver = true;
    }
}
