using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Pause : MonoBehaviour
{
    private TextMeshProUGUI pauseDisplay;
    // Start is called before the first frame update
    void Start()
    {
        pauseDisplay = GameObject.Find("PauseDisplay").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
