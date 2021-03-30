using System.Collections.Generic;
using UnityEngine;

public class GravityArea : MonoBehaviour
{
    [SerializeField] private Vector3 _center;

    private HashSet<GravityBody> _gravityBodies;

    void Start()
    {
        _gravityBodies = new HashSet<GravityBody>();
    }
    
    void Update()
    {
        foreach (GravityBody gravityBody in _gravityBodies)
        {
            gravityBody.SetGravityDirection((_center - gravityBody.transform.position).normalized);
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out GravityBody gravityBody))
        {
            _gravityBodies.Add(gravityBody);
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out GravityBody gravityBody))
        {
            _gravityBodies.Remove(gravityBody);
        }
    }
}
