using System;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour {

	public static AudioManager instance;

	public Sound[] sounds;

	void Awake ()
	{
		if (instance != null)
		{
			Destroy(gameObject);
			return;
		} else
		{
			instance = this;
			DontDestroyOnLoad(gameObject);
		}

		foreach (Sound s in sounds)
		{
			s.source = gameObject.AddComponent<AudioSource>();
			s.source.clip = s.clip;
			s.source.volume = optionsCotrol.options.volume.value;
			s.source.pitch = s.pitch;
			s.source.loop = s.loop;
		}
	}
    private void Update()
    {
		foreach (Sound s in sounds)
		{			
			s.source.volume = optionsCotrol.options.volume.value;			
		}
	}

    public void Play(string sound)
	{
		Sound s = Array.Find(sounds, item => item.name == sound);
		s.source.Play();
	}
	public void Stop(string sound)
	{
		Sound s = Array.Find(sounds, item => item.name == sound);
		s.source.Stop();
	}
	public void Volume(string sound,float volume)
	{
		Sound s = Array.Find(sounds, item => item.name == sound);
		s.volume = volume;
	}

}
