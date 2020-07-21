using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The audio manager
/// </summary>
public static class AudioManager {
    static bool initialized = false;
    static AudioSource audioSource;
    static Dictionary<AudioClipName, AudioClip> audioClips =
        new Dictionary<AudioClipName, AudioClip>();

    /// <summary>
    /// Gets whether or not the audio manager has been initialized
    /// </summary>
    public static bool Initialized {
        get { return initialized; }
    }

    /// <summary>
    /// Initializes the audio manager
    /// </summary>
    /// <param name="source">audio source</param>
    public static void Initialize(AudioSource source) {
        initialized = true;
        audioSource = source;
        audioClips.Add(AudioClipName.Completado, Resources.Load<AudioClip>("Audios/Completado"));
        audioClips.Add(AudioClipName.Error, Resources.Load<AudioClip>("Audios/Error"));
        audioClips.Add(AudioClipName.GameOver, Resources.Load<AudioClip>("Audios/GameOver"));
        audioClips.Add(AudioClipName.Point, Resources.Load<AudioClip>("Audios/Point"));
        audioClips.Add(AudioClipName.Pelota, Resources.Load<AudioClip>("Audios/Pelota"));
        audioClips.Add(AudioClipName.Click, Resources.Load<AudioClip>("Audios/Click"));
    }

    /// <summary>
    /// Plays the audio clip with the given name
    /// </summary>
    /// <param name="name">name of the audio clip to play</param>
    public static void Play(AudioClipName name) {
        if (audioSource.enabled) {
            audioSource.PlayOneShot(audioClips[name]);
        }
    }
}