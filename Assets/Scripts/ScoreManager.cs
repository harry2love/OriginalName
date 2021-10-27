using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    private int score = 0;
    private int health = 5;
    private TextMeshProUGUI scoreDisplay;
    private TextMeshProUGUI healthDisplay;
    
    
    // Start is called before the first frame update
    void Start()
    {
        scoreDisplay = GameObject.Find("ScoreDisplay").GetComponent<TextMeshProUGUI>();
        healthDisplay = GameObject.Find("HealthDisplay").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreDisplay.text = "Score: " + score;
        healthDisplay.text = "Health: " + health;
        if (health <= 0)
        {
            Destroy(GameObject.Find("Player"));
            SceneManager.LoadScene("Scene1");
        }

        
            
    }

    public void AddScore(int score)
    {
        this.score = this.score + score;
    }

    public void DeductScore(int score)
    {
        this.score = this.score - score;
        health = health - 1;
    }

    
}
