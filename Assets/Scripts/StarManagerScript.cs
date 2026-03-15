using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarScript : MonoBehaviour
{
    public List<GameObject> stars;
    // Start is called before the first frame update
    void Start()
    {
        //stars = GameObject.FindGameObjectsWithTag("Star");
        foreach (GameObject star in stars)
        {
             StartCoroutine(StarTimer(star));
        }

    }

    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator StarTimer(GameObject star)
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f); // visible for 3 seconds
            if (star != null) { 
                star.SetActive(!star.activeSelf);
        }

    }
    }
}
