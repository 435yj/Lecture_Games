using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManageer : MonoBehaviour
{
    private AudioSource audioSource;

    private float volume = .5f;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();  
        audioSource.volume = volume;
    }

    public void InceraseVolume()
    {
        volume += .1f;
        volume = Mathf.Clamp01(volume);
        audioSource.volume = volume;
    }
    public void DecreaseVolume()
    {
        volume -= .1f;
        volume = Mathf.Clamp01(volume);
        audioSource.volume = volume;
    }
    public float GetVolume()
    {
        return volume;
    }
}
