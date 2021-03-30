using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _rigidbody;
    
    void Start()
    {
        _rigidbody = transform.GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // Test.
        if (Input.GetKey(KeyCode.A))
        {
            _rigidbody.AddForce(-transform.right * Time.fixedDeltaTime * 2000, ForceMode.Acceleration);
        }
    }
}
