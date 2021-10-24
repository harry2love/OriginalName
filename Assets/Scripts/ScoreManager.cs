using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    private int score = 0;
    private TextMeshProUGUI scoreDisplay;
    // Start is called before the first frame update
    void Start()
    {
        scoreDisplay = GameObject.Find("ScoreDisplay").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreDisplay.text = "Score: " + score;
        if(score < 0) Destroy(GameObject.Find("Player"));
    }

    public void AddScore(int score)
    {
        this.score = this.score + score;
    }

    public void DeductScore(int score)
    {
        this.score = this.score - score;
    }

    
}
