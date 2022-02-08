using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    void Awake(){
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    private void Start()
    {
        Play("Theme");
        PlayerPrefs.SetFloat("volume", 0.1f);
    }

    // Update is called once per frame
    public void Play (string name)
    {
       Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.volume = PlayerPrefs.GetFloat("volume");
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + "not found!");
            return;
        }
        s.source.Play();
    }

    public void MuteSound(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Pause();
    }
    //        FindObjectOfType<AudioManager>().Play(" xxxxSoundNamexxx ");    

}
