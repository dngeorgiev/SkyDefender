using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [Header("General")]
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private float projectileSpeed = 10f;
    [SerializeField] private float projectileLifetime = 5f;
    [SerializeField] private float baseFiringRate = 0.2f;

    [Header("AI")]
    [SerializeField] private bool useAI;
    [SerializeField] private float firingRateVariance = 0.5f;
    [SerializeField] private float minimumFiringRate = 0.2f;

    private Coroutine firingCoroutine;
    private AudioPlayer audioPlayer;
 
    [HideInInspector] public bool isFiring;

    private void Awake()
    {
        this.audioPlayer = FindObjectOfType<AudioPlayer>();    
    }

    private void Start()
    {
        if (this.useAI)
        {
            this.isFiring = true;
        }
    }

    private void Update()
    {
        Fire();
    }

    private void Fire()
    {
        if (this.isFiring && this.firingCoroutine == null)
        {
            this.firingCoroutine = StartCoroutine(FireContinously());
        }
        else if (!isFiring && this.firingCoroutine != null) 
        {
            StopCoroutine(this.firingCoroutine);
            this.firingCoroutine = null;
        }
    }

    private IEnumerator FireContinously()
    {
        while(true)
        {
            GameObject instance = Instantiate(
                this.projectilePrefab, 
                this.transform.position,
                this.projectilePrefab.transform.rotation);

            Rigidbody2D rb = instance.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = this.transform.up * this.projectileSpeed;
            }

            Destroy(instance, this.projectileLifetime);

            this.audioPlayer.PlayShootingClip();

            yield return new WaitForSeconds(this.useAI ? this.GetRandomFiringRate() : this.baseFiringRate);
        }
    }

    private float GetRandomFiringRate()
    {
        float firingTime = UnityEngine.Random.Range(this.baseFiringRate - this.firingRateVariance, 
            this.baseFiringRate + this.firingRateVariance);

        return Mathf.Clamp(firingTime, this.minimumFiringRate, float.MaxValue);
    }
}
