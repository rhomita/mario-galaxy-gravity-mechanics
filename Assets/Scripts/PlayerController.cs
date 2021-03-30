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

    void Update()
    {
    }
}
