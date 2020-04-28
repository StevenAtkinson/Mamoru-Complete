using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer
{
    public static Quaternion LookAt2D(Vector2 from, Vector2 to)
    {
        Vector3 diff = to - from;
        diff.Normalize();

        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        return Quaternion.Euler(0f, 0f, rot_z - 90);
    }
}
