using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    private int maxEnemies = 5;
    private int enemyIncrease;
    private float activeTime = 5;
    private float cooldownTimer = 5;
    private bool isOnCooldown = false;
    private bool FreezeIsActive = false;
    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.Find("ButtonScripts").GetComponent<StartScript>().difficulty == 1)
        {
            enemyIncrease = 3;
        }
        else if(GameObject.Find("ButtonScripts").GetComponent<StartScript>().difficulty == 2)
        {
            enemyIncrease = 5;
        }
        else if(GameObject.Find("ButtonScripts").GetComponent<StartScript>().difficulty == 3)
        {
            enemyIncrease = 7;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.FindGameObjectsWithTag("Enemy").Length <= maxEnemies && !isOnCooldown && !FreezeIsActive)
        {
            int maxRange = Random.Range(1, 4);

            if(maxRange == 1)
            {
                for (int i = 0; i < maxEnemies; i++)
                {
                    Instantiate(enemy, new Vector3(Random.Range(40, 50), 0, Random.Range(40, 50)), transform.rotation);
                }
                Debug.Log("1");
            }
            else if(maxRange == 2)
            {
                for (int i = 0; i < maxEnemies; i++)
                {
                    Instantiate(enemy, new Vector3(Random.Range(40, 50), 0, Random.Range(-50, -40)), transform.rotation);
                }
                Debug.Log("2");
            }
            else if(maxRange == 3)
            {
                for (int i = 0; i < maxEnemies; i++)
                {
                    Instantiate(enemy, new Vector3(Random.Range(-50, -40), 0, Random.Range(-50, -40)), transform.rotation);
                }
                Debug.Log("3");
            }
            else if(maxRange == 4)
            {
                for (int i = 0; i < maxEnemies; i++)
                {
                    Instantiate(enemy, new Vector3(Random.Range(-50, -40), 0, Random.Range(40, 50)), transform.rotation);
                }
                Debug.Log("4");
            }
            isOnCooldown = true;
            StartCoroutine(SpawnCooldown());
        }
    }

    public void SetFreezeActive()
    {
        FreezeIsActive = true;
        StartCoroutine(DisableFreeze());
    }

    IEnumerator DisableFreeze()
    {
        yield return new WaitForSeconds(activeTime);
        FreezeIsActive = false;
    }
    IEnumerator SpawnCooldown()
    {
        maxEnemies = maxEnemies + enemyIncrease;
        yield return new WaitForSeconds(cooldownTimer);
        isOnCooldown = false;
    }
}
