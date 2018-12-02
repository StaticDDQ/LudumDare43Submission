using UnityEngine;
using System;

public class AudioManager : MonoBehaviour {

    public static AudioManager instance;
    [SerializeField] private SoundClip[] clips;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach(SoundClip clip in clips)
        {
            clip.source = gameObject.AddComponent<AudioSource>();
            clip.source.clip = clip.clip;

            clip.source.volume = clip.volume;
            clip.source.clip = clip.clip;
            clip.source.loop = clip.isLoop;
        }
    }

    public void PlaySound(string clipName)
    {
        SoundClip s = Array.Find(clips, clip => clip.clipName == clipName);

        if (s != null)
            s.source.Play();
    }

    public void StopSound(string clipName)
    {
        SoundClip s = Array.Find(clips, clip => clip.clipName == clipName);

        if (s != null)
            s.source.Stop();
    }
}
