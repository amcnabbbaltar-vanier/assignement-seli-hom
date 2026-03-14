using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TrapManager : MonoBehaviour
{
    public List<GameObject> traps;
    // Start is called before the first frame update
    void Start()
    {
        //traps = GameObject.FindGameObjectsWithTag("Trap");
      
        foreach (GameObject trap in traps)
        {
            StartCoroutine(TrapTimer(trap));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private IEnumerator TrapTimer(GameObject trap)
    {
        while (true)
        {
            yield return new WaitForSeconds(2f); // visible for 3 seconds
            if (trap != null)
            {
                Debug.Log("Trap active: " + trap.activeSelf);
                trap.SetActive(!trap.activeSelf);
        }

    }
    }
}
