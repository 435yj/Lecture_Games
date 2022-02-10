using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }
    public enum Sound
    {
        BuildingPlaced,
        BuildingDamaged,
        BuildingDestroyed,
        EnemyDie,
        EnemyHit,
        GameOver,
    }

    private AudioSource audioSource;
    private Dictionary<Sound, AudioClip> soundAuddioClipDictionary;


    private void Awake()
    {
        Instance = this;

        audioSource = GetComponent<AudioSource>();

        soundAuddioClipDictionary = new Dictionary<Sound, AudioClip>();

        foreach(Sound sound in System.Enum.GetValues(typeof(Sound)))
        {
            soundAuddioClipDictionary[sound] = Resources.Load<AudioClip>(sound.ToString());
        }
    }
    public void PlaySound(Sound sound)
    {
        audioSource.PlayOneShot(soundAuddioClipDictionary[sound]);
    }

}
