using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaDestroyProjectile : MonoBehaviour
{
    public string player1Projectile;
    public string player2Projectile;

    void OnTriggerEnter(Collider trig)
    {
        if (trig.gameObject.name == player1Projectile || trig.gameObject.name == player2Projectile)
        {
            Destroy(trig.gameObject);
        }
    }
}
