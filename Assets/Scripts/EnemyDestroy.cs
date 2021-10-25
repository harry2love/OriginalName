using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestroy : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < -2)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "EnemyKiller")
        {
            Destroy(gameObject);
            GameObject.Find("GameManager").GetComponent<ScoreManager>().AddScore(1);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            GameObject.Find("GameManager").GetComponent<ScoreManager>().DeductScore(10);
            Destroy(gameObject);
        }
    }
}
