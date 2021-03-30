using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public abstract class GravityArea : MonoBehaviour
{
    void Start()
    {
        transform.GetComponent<Collider>().isTrigger = true;
    }
    
    public abstract Vector3 GetGravityDirection(GravityBody _gravityBody);
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out GravityBody gravityBody))
        {
            gravityBody.AddGravityArea(this);
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out GravityBody gravityBody))
        {
            gravityBody.RemoveGravityArea(this);
        }
    }
}