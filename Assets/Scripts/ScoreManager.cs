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
    private TextMeshProUGUI abilityDisplay;
    private TextMeshProUGUI fortifyDisplay;
    private TextMeshProUGUI bombDisplay;
    public enum activeAbility { Spin, Bomb, Explosion, Fortify};
    
    
    // Start is called before the first frame update
    void Start()
    {
        scoreDisplay = GameObject.Find("ScoreDisplay").GetComponent<TextMeshProUGUI>();
        healthDisplay = GameObject.Find("HealthDisplay").GetComponent<TextMeshProUGUI>();
        abilityDisplay = GameObject.Find("AbilityDisplay").GetComponent<TextMeshProUGUI>();
        fortifyDisplay = GameObject.Find("FortifyDisplay").GetComponent<TextMeshProUGUI>();
        bombDisplay = GameObject.Find("BombDisplay").GetComponent<TextMeshProUGUI>();
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

    public void AddHealth(int health)
    {
        this.health = this.health + health;
    }

    public void DeclareAbility(activeAbility ability)
    {
        if(ability == activeAbility.Explosion)
        {
            abilityDisplay.text = "Ability: Explosion!";
        }
        else if(ability == activeAbility.Spin)
        {
            abilityDisplay.text = "Ability: Spin";
        }
        else
        {
            Debug.Log("Third option");
        }
    }

    public void RemoveAbility()
    {
        abilityDisplay.text = "Ability: None";
    }

    public void DeclareFortify()
    {
        fortifyDisplay.text = "F";
    }

    public void RemoveFortify()
    {
        fortifyDisplay.text = "";
    }


    public void DeclareBomb()
    {
        bombDisplay.text = "B";
    }
    public void RemoveBomb()
    {
        bombDisplay.text = "";
    }
}
