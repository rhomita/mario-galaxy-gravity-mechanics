using UnityEngine;

public class GravityAreaUp : GravityArea
{
    public override Vector3 GetGravityDirection(GravityBody _gravityBody)
    {
        return -transform.up;
    }
}