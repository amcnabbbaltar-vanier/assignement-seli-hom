using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitApplication()
    {
        Application.Quit();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
