using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingScipt : MonoBehaviour
{
    public float rotationSpeed = 100f;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
     rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Quaternion deltaRotation = Quaternion.Euler(0, 0, rotationSpeed * Time.fixedDeltaTime);
        rb.MoveRotation(rb.rotation * deltaRotation);

    }

    private void OnCollisionEnter(Collision collision)
    {
        GameManager.Instance.LoseLife();
    }
}
