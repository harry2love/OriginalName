using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    private int maxEnemies = 15;
    private float cooldownTimer = 3;
    private bool isOnCooldown = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.FindGameObjectsWithTag("Enemy").Length <= maxEnemies && !isOnCooldown)
        {
            int maxRange = Random.Range(1, 4);

            if(maxRange == 1)
            {
                for (int i = 0; i < maxEnemies; i++)
                {
                    Instantiate(enemy, new Vector3(Random.Range(40, 50), 0, Random.Range(40, 50)), transform.rotation);
                }
            }
            else if(maxRange == 2)
            {
                for (int i = 0; i < maxEnemies; i++)
                {
                    Instantiate(enemy, new Vector3(Random.Range(-40, 50), 0, Random.Range(-40, 50)), transform.rotation);
                }
            }
            else if(maxRange == 3)
            {
                for (int i = 0; i < maxEnemies; i++)
                {
                    Instantiate(enemy, new Vector3(Random.Range(40, -50), 0, Random.Range(40, -50)), transform.rotation);
                }
            }
            else if(maxRange == 4)
            {
                for (int i = 0; i < maxEnemies; i++)
                {
                    Instantiate(enemy, new Vector3(Random.Range(-40, -50), 0, Random.Range(-40, -50)), transform.rotation);
                }
            }
            isOnCooldown = true;
            StartCoroutine(SpawnCooldown());
        }
    }

    IEnumerator SpawnCooldown()
    {
        yield return new WaitForSeconds(cooldownTimer);
        isOnCooldown = false;
    }
}
