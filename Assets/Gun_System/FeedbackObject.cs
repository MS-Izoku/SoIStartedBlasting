using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.Audio;

[RequireComponent(typeof(ParticleSystem))]
[RequireComponent(typeof(AudioSource))]
public class FeedbackObject : MonoBehaviour
{
    ParticleSystem particle;
    AudioSource audioSource;
    AudioClip audioClip;

    private void Start()
    {
        particle = GetComponent<ParticleSystem>();
        audioSource = GetComponent<AudioSource>();
        audioClip = audioSource.clip;
        this.DoVFX();
    }

    public void DoVFX()
    {
        particle.Play();
        audioSource.Play();

        IEnumerator WaitToDestroy()
        {
            float time = particle.time > audioClip.length ? particle.time : audioClip.length;
            yield return new WaitForSeconds(time);
            Destroy(gameObject);
        }
        StartCoroutine(WaitToDestroy());
    }
}
