using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability3 : MonoBehaviour
{

    // Start is called before the first frame update
    
    private float sizeIncrease = 2.5f;
    private Transform player;
    void Start()
    {
        player = GetComponent<Transform>();
        StartCoroutine(DestroyObject());
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = Vector3.Lerp(player.localScale, player.localScale * sizeIncrease, Time.deltaTime);
    }

    IEnumerator DestroyObject()
    {
        yield return new WaitForSeconds(GameObject.Find("Player").GetComponent<PlayerAbilities>().ability2Wait);
        Destroy(gameObject);

    }
}
