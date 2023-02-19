using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int health = 50;
    [SerializeField] private ParticleSystem hitEffect;

    [SerializeField] private bool applyCameraShake;
    private CameraShake cameraShake;

    private void Awake() 
    {
        this.cameraShake = Camera.main.GetComponent<CameraShake>();    
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        DamageDealer damageDealer = other.GetComponent<DamageDealer>();

        if (damageDealer != null)
        {
            this.TakeDamage(damageDealer.GetDamage());
            this.PlayHitEffect();
            this.ShakeCamera();
            damageDealer.Hit();
        }    
    }

    private void TakeDamage(int damage)
    {
        this.health -= damage;
        if (this.health <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void PlayHitEffect()
    {
        if (this.hitEffect != null)
        {
            ParticleSystem instance = Instantiate(this.hitEffect, this.transform.position, Quaternion.identity);
            Destroy(instance.gameObject, instance.main.duration + instance.main.startLifetime.constantMax);
        }
    }

    private void ShakeCamera()
    {
        if (this.cameraShake != null && this.applyCameraShake)
        {
            this.cameraShake.Play();
        }
    }
}
