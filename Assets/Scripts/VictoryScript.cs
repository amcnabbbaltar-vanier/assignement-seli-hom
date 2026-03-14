using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VictoryScript : MonoBehaviour
{
    public Text finalTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (finalTime.text != null)
        {
            finalTime.text = "Final Time: " + GameManager.Instance.GetTotalTime().ToString();
        }
    }
}
