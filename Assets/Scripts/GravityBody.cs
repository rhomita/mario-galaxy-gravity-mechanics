using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class GravityBody : MonoBehaviour
{
    public Vector3 GravityDirection
    {
        get
        {
            if (_gravityAreas.Count == 0) return Vector3.zero;
            return _gravityAreas.Last().GetGravityDirection(this);
        }
    }

    private Rigidbody _rigidbody;
    private List<GravityArea> _gravityAreas;

    void Start()
    {
        _rigidbody = transform.GetComponent<Rigidbody>();
        _gravityAreas = new List<GravityArea>();
    }
    
    void FixedUpdate()
    {
        _rigidbody.AddForce(GravityDirection * (200 * Time.fixedDeltaTime), ForceMode.Acceleration);

        Quaternion upRotation = Quaternion.FromToRotation(transform.up, -GravityDirection);
        Quaternion newRotation = Quaternion.Slerp(_rigidbody.rotation, upRotation * _rigidbody.rotation, Time.fixedDeltaTime * 3f);;
        _rigidbody.MoveRotation(newRotation);
    }

    public void AddGravityArea(GravityArea gravityArea)
    {
        _gravityAreas.Add(gravityArea);
    }

    public void RemoveGravityArea(GravityArea gravityArea)
    {
        _gravityAreas.Remove(gravityArea);
    }
}