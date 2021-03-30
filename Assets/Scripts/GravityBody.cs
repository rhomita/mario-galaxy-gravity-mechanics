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
    }

    public void SetGravityDirection(Vector3 direction)
    {
        Debug.Log($"Setting gravity of {gameObject.name} to {direction}");
        direction = direction.normalized; // It is probably normalized, we do it again just in case.
        GravityDirection = direction;
    }
}