using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class GravityBody : MonoBehaviour
{
    private Rigidbody _rigidbody;
    public Vector3 GravityDirection { get; private set; }

    void Start()
    {
        _rigidbody = transform.GetComponent<Rigidbody>();
    }
    
    void FixedUpdate()
    {
        _rigidbody.AddForce(GravityDirection * (200 * Time.fixedDeltaTime), ForceMode.Acceleration);

        Quaternion upRotation = Quaternion.FromToRotation(transform.up, -GravityDirection);
        Quaternion newRotation = Quaternion.Slerp(_rigidbody.rotation, upRotation * _rigidbody.rotation, Time.fixedDeltaTime * 3f);;
        _rigidbody.MoveRotation(newRotation);
    }

    public void SetGravityDirection(Vector3 direction)
    {
        direction = direction.normalized; // It is probably normalized, we do it again just in case.
        GravityDirection = direction;
    }
}