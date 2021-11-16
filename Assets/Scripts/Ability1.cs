using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability1 : MonoBehaviour
{
    private float rotationSpeed = 50f;
    private int seconds = 4;
    private Vector3 player;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DestroyObject());
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player = GameObject.Find("Player").transform.position;
        transform.Rotate(new Vector3(0, 20, 0) * Time.deltaTime * rotationSpeed);
    }

    IEnumerator DestroyObject()
    {
        yield return new WaitForSeconds(seconds);
        GameObject.Find("GameManager").GetComponent<ScoreManager>().RemoveAbility();
        GameObject.Find("Player").GetComponent<PlayerAbilities>().CooldownRemover();
        Destroy(gameObject);
    }
}
