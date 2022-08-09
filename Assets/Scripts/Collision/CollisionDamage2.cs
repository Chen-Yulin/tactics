using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDamage2 : MonoBehaviour
{
    private Vector3 impulse;
    private float Impulse;
    //private float Force;

    void OnCollisionEnter(Collision collisionInfo)
    {
        impulse = collisionInfo.impulse;
        DamageDisplay2.CollisionNum += 1;
        Impulse = (Mathf.Sqrt(Mathf.Pow(impulse.x, 2f) + Mathf.Pow(impulse.y, 2f) + Mathf.Pow(impulse.z, 2f))) / 1000;
        //Force = Impulse / Time.fixedDeltaTime;
        DamageDisplay2.ExtentOfDamage += Impulse;
    }
}