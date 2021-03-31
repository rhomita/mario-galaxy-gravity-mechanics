using System.Collections.Generic;
using UnityEngine;

public class GravityAreaPoint : GravityArea
{
    [SerializeField] private Vector3 _center;

    
    public override Vector3 GetGravityDirection(GravityBody _gravityBody)
    {
        return (_center - _gravityBody.transform.position).normalized;
    }
}
