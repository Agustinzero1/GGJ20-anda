using System;
using System.Collections;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public float fadeRate;
    public Sound[] songs;
    public Sound[] fx;
    private float currentMusicVolume = 1;
    private float currentFxVolume = 1;
    public static AudioManager instance;
    public bool muteMusic;
    public bool muteSFX;

    private void Awake()
    {
        if (instance==null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach (Sound s in songs)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }

        foreach (Sound s in fx)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    //public void ApplyPreferences()
    //{
    //    muteMusic = CLoadManager.Instance.GetMutePreferences("music");
    //    muteSFX = CLoadManager.Instance.GetMutePreferences("sfx");
    //    if (muteMusic) MuteMusic(); else UnMuteMusic();
    //    if (muteSFX) MuteSFX(); else UnMuteSFX();
    //}
    private void Start()
    {
        instance.PlayMusic("0");
    }
    public void MuteMusic()
    {
        foreach (Sound s in songs)
        {
           s.source.volume = 0;            
        }
        muteMusic = true;
    }

    public void UnMuteMusic()
    {
        foreach (Sound s in songs)
        {
            s.source.volume = 1;
        }
        muteMusic = false;
    }

    public void MuteSFX()
    {
        foreach (Sound s in fx)
        {
            s.source.volume = 0;
        }
        muteSFX = true;
    }

    public void UnMuteSFX()
    {
        foreach (Sound s in fx)
        {
            s.source.volume = 1;
        }
        muteSFX = false;
    }

    public void PlayMusic(string name)
    {
        StopAllSounds();
        Sound s = Array.Find(songs, sound => sound.name == name);
       
        if (s==null)
        {
            return;
        }

        if (s.source != null)
        {
            s.source.Play();
        }
    }

    public void PlayFx(string name)
    {
        Sound s = Array.Find(fx, fx => fx.name == name);

        if (s == null)
        {
            return;
        }
        if (s.source != null)
        {
            StartCoroutine(WaitForAllFxEnd());
            s.source.Play();

        }
       
    }

    public void StopFx(string name)
    {
        Sound s = Array.Find(fx, fx => fx.name == name);

        if (s == null)
        {
            return;
        }
        if (s.source != null)
        {
            s.source.Stop();

        }
    }

    public void StopMusic(string name)
    {
        Sound s = Array.Find(songs, sound => sound.name == name);

        if (s == null)
        {
            return;
        }
        if (s.source != null)
        {
            s.source.Stop();

        }
    }

    public bool IsPlayingMusic(string name)
    {
        Sound s = Array.Find(songs, sound => sound.name == name);

        if (s == null)
        {
            return false;
        }
        if (s.source != null)
        {
            return s.source.isPlaying;
        }
        else
        {
            return false;
        }
    }

    public bool IsPlayingMusic()
    {
        return Array.Find(songs, sound => sound.source.isPlaying) != null;
    }

    public bool IsPlayingFx(string name)
    {
        Sound s = Array.Find(fx, fx => fx.name == name);

        if (s == null)
        {
            return false;
        }
        if (s.source != null)
        {
            return s.source.isPlaying;

        }
        else
        {
            return false;
        }
    }

    public Sound PlayingFx()
    {
        foreach (Sound s in fx)
        {
            if (s.source.isPlaying) return s;
        }
        return null;
    }

    public void StopAllSounds()
    {
        foreach (Sound s in songs)
        {
            if (s.source!=null)
            {
                s.source.Stop();

            }
        }
        foreach (Sound s in fx)
        {
            if (s.source != null)
            {
                s.source.Stop();
            }
        }
    }

    public void SetMusicVolume(string name, float volume)
    {
        Sound s = Array.Find(songs, sound => sound.name == name);
        if (s == null)
        {
            return;
        }
        s.source.volume = volume;
    }

    public void AdjustMainVolumeMusic(float volume)
    {
        currentMusicVolume = volume;
        foreach (Sound s in songs)
        {
            s.source.volume = volume;
        }
    }

    public void AdjustMainVolumeFx(float volume)
    {
        currentFxVolume = volume;
        foreach (Sound s in fx)
        {
            s.source.volume = volume;
        }
    }

    public float GetMusicVolume()
    {
        return currentMusicVolume;
    }

    public float GetFxVolume()
    {
        return currentFxVolume;
    }

    private IEnumerator WaitForAllFxEnd()
    {
        Sound s = PlayingFx();
        if (s != null) yield return new WaitWhile(() => s.source.isPlaying);
    }

    public string GetLength(string name)
    {
        Sound s = Array.Find(songs, sound => sound.name == name);

        if (s == null)
        {
            return "";
        }
        return s.source.time.ToString() + "/" + s.clip.length.ToString(); //si seteo time arranca desde ahi
    }

    public void ChangeSong(string newSong)
    {
        Sound currentSong = Array.Find(songs, sound => sound.source.isPlaying);
        if (!muteMusic)
        {
            if (currentSong != null && currentSong.name != newSong)
                StartCoroutine(FadeOutAndIn(newSong));
        }
        else
        {
            Sound newS = Array.Find(songs, sound => sound.name == newSong);
            newS.source.volume = 0;
            newS.source.time = currentSong.source.time;
            currentSong.source.Stop();
            newS.source.Play();
        }
    }

    private IEnumerator FadeOutAndIn(string name)
    {
        Sound s = Array.Find(songs, sound => sound.source.isPlaying);

        if(s != null)
        {
            while (s.source.volume > 0.01)
            {
                s.source.volume = Mathf.Lerp(s.source.volume, 0, fadeRate * Time.deltaTime);
                yield return null;
            }
            s.source.volume = 0;
            Sound newS = Array.Find(songs, sound => sound.name == name);
            newS.source.time = s.source.time;
            s.source.Stop();
            StartCoroutine(FadeIn(name));
        }
    }

    private IEnumerator FadeIn(string name)
    {
        Sound s = Array.Find(songs, sound => sound.name == name);
        s.source.volume = 0;
        s.source.Play();
        while (s.source.volume < 0.95)
        {
            s.source.volume = Mathf.Lerp(s.source.volume, 1, fadeRate * Time.deltaTime);
            yield return null;
        }
        s.source.volume = 1;
    }
}
