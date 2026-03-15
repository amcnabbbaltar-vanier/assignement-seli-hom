using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelAnnouncement : MonoBehaviour
{
    public GameObject levelAnnouncementUI;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(RemoveAnnouncement());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator RemoveAnnouncement()
    {
        yield return new WaitForSeconds(0.2f);
        levelAnnouncementUI.SetActive(false);
    }
}
