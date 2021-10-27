using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarkerRemover : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Die());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Die()
    {
        yield return new WaitForSeconds(GameObject.Find("Player").GetComponent<PlayerAbilities>().cooldown2);
        Destroy(gameObject);
    }
}
