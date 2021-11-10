using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability2 : MonoBehaviour
{
    // Start is called before the first frame update
    private int seconds = 3;
    private float sizeIncrease = 2;
    private Transform player;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Transform>();
        StartCoroutine(DestroyObject());
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = Vector3.Lerp(player.localScale, new Vector3(player.localScale.x * sizeIncrease, 0.1f, player.localScale.z * sizeIncrease), Time.deltaTime);
    }

    IEnumerator DestroyObject()
    {
        yield return new WaitForSeconds(seconds);
        GameObject.Find("GameManager").GetComponent<ScoreManager>().RemoveBomb();
        Destroy(gameObject);
        GameObject.Find("Player").GetComponent<PlayerAbilities>().CooldownRemover();
    }
}
