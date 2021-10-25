using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Rigidbody playerRB;
    private Rigidbody enemyRB;

    private float speedMultiplier = 1;
    private float boundryBoost = 5;
    // Start is called before the first frame update
    void Start()
    {
        enemyRB = GetComponent<Rigidbody>();
        playerRB = GameObject.Find("Player").GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        enemyRB.AddForce((new Vector3(playerRB.position.x, 1, playerRB.position.z) - enemyRB.position) * Time.deltaTime * 100 * speedMultiplier);

        if(enemyRB.position.x < -49 || enemyRB.position.x > 49 || enemyRB.position.z < -49 || enemyRB.position.z > 49)
        {
            enemyRB.AddForce((new Vector3(playerRB.position.x, 1, playerRB.position.z) - enemyRB.position) * Time.deltaTime * 100 * speedMultiplier * boundryBoost);
        }
    }
}
