using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScript : MonoBehaviour
{
    public int difficulty = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame(int number)
    {
        difficulty = number;
        GameObject.Find("ButtonScripts").GetComponent<StartScript>().difficulty = number;
        SceneManager.LoadScene("Scene1");
    }

}
