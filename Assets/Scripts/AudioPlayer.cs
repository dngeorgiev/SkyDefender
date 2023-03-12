using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [Header("Shooting")]
    [SerializeField] AudioClip shootingClip;
    [SerializeField] [Range(0f, 1f)] float shootingVolume = 1f;

    [Header("Taking Damage")]
    [SerializeField] AudioClip takingDamageClip;
    [SerializeField] [Range(0f, 1f)] float takingDamageVolume = 1f;

    public void PlayShootingClip()
    {
        this.PlayClip(this.shootingClip, this.shootingVolume);
    }

    public void PlayTakingDamageClip()
    {
        this.PlayClip(this.takingDamageClip, this.takingDamageVolume);
    }

    private void PlayClip(AudioClip clip, float volume)
    {
        if (clip != null)
        {
            Vector3 cameraPos = Camera.main.transform.position;
            AudioSource.PlayClipAtPoint(clip, cameraPos, volume);
        }
    }
}
