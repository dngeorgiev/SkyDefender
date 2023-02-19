using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] private int damage = 10;

    public int GetDamage()
    {
        return this.damage;
    }

    public void Hit()
    {
        Destroy(this.gameObject);
    }
}
