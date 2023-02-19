using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] private float shakeDuration = 1f;
    [SerializeField] private float shakeMagnitude = 0.5f;

    private Vector3 initialPosition;

    void Start()
    {
        this.initialPosition = this.transform.position;
    }

    public void Play()
    {
        StartCoroutine(Shake());
    }

    private IEnumerator Shake()
    {
        float elapsedTime = 0;

        while(elapsedTime < this.shakeDuration)
        {
            this.transform.position = this.initialPosition + (Vector3) UnityEngine.Random.insideUnitCircle * this.shakeMagnitude;

            elapsedTime += Time.deltaTime;

            yield return new WaitForEndOfFrame();
        }

        this.transform.position = this.initialPosition;
    }
}
