using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactDestroyProjectile : MonoBehaviour
{
    public string projectileName;

    void OnTriggerEnter(Collider trig)
    {
        if (trig.gameObject.name == projectileName)
        {
            Destroy(trig.gameObject);
        }
    }
}