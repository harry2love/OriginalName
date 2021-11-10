using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupSpawner : MonoBehaviour
{
    private int powerups;
    private int spawncooldown = 15;

    public GameObject Health;
    public GameObject SpawnFreeze;
    public GameObject CooldownReset;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(AbilitySpawner());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator AbilitySpawner()
    {
        yield return new WaitForSeconds(spawncooldown);
        powerups = Random.Range(1, 3);
        Vector3 location = new Vector3(Random.Range(-50, 50), 0.5f, Random.Range(-50, 50));
        if(powerups == 1)
        {
            Instantiate(Health, location, transform.rotation);
        }
        else if(powerups == 2)
        {
            Instantiate(SpawnFreeze, location, transform.rotation);
        }
        else if(powerups == 3)
        {
            Instantiate(CooldownReset, location, transform.rotation);
        }
        StartCoroutine(AbilitySpawner());
    }
}
