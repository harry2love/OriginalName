using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnStartScreenStart : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("Dif1").GetComponentInChildren<Text>().text = "Easy";
        GameObject.Find("Dif2").GetComponentInChildren<Text>().text = "Medium";
        GameObject.Find("Dif3").GetComponentInChildren<Text>().text = "Hard";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
