using System;
using UnityEngine;
using UnityEngine.Audio;

public class SFXManager : MonoBehaviour
{
    public static SFXManager instance;
    public SFX[] SoundEffects;
    [SerializeField] private AudioSource SFXObject;
    // Start is called before the first frame update
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
    /// <summary>
    /// Plays <c>audio</c> from temporary <c>AudioSource</c> spawned on <c>spawnTransform</c>
    /// </summary>
    /// <param name="audioName"> string name of audio to be played</param>
    /// <param name="spawnTransform">position of temporary <c>AudioSource</c></param>
    /// <param name="volume">Optional volume in 0f to 1f range</param>
    /// <param name="pitch">Optional pitch modifier</param>
    public void PlaySFX(string audioName, Transform spawnTransform, float volume = float.NaN, float pitch = float.NaN)
    {
        SFX audio = Array.Find(SoundEffects, SFX => SFX.name == audioName);
        // Instantiate audio src
        AudioSource audioSource = Instantiate(SFXObject, spawnTransform.position, Quaternion.identity);
        // Attach audio
        audioSource.clip = audio.clip;
        // Set volume and pitch
        if (float.IsNaN(volume))
        {
            audioSource.volume = audio.volume;
        }
        else
        {
            audioSource.volume = volume;
        }
        if (float.IsNaN(pitch))
        {
            audioSource.pitch = audio.pitch;
        }
        else
        {
            audioSource.pitch = pitch;
        }

        // Play audio
        audioSource.Play();
        // Destroy audio src after full clip duration
        float audioLength = audioSource.clip.length;
        Destroy(audioSource.gameObject, audioLength);
    }

    public void PlaySFXReverse(string audioName, Transform spawnTransform)
    {
        SFX audio = Array.Find(SoundEffects, SFX => SFX.name == audioName);
        AudioSource audioSource = Instantiate(SFXObject, spawnTransform.position, Quaternion.identity);
        audioSource.pitch = -1f;
        audioSource.volume = audio.volume;
        audioSource.clip = audio.clip;
        audioSource.time = audioSource.clip.length - 0.01f;
        audioSource.Play();
        float audioLength = audioSource.clip.length;
        Destroy(audioSource.gameObject, audioLength);
    }



}