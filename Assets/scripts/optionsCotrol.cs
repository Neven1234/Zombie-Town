using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class optionsCotrol : MonoBehaviour
{
    public AudioSource z1;
    public AudioSource z2;
    public AudioSource z3;
    public AudioSource menuMusic;
    public Slider volume;
    public Slider music;
    Sound s = new Sound();
    // Start is called before the first frame update
    void Start()
    {
        volume.value = PlayerPrefs.GetFloat("volume",0.5f);
        music.value = PlayerPrefs.GetFloat("music",0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        z1.volume = volume.value;
        z2.volume = volume.value;
        z3.volume = volume.value;
        menuMusic.volume = music.value;
        AudioManager.instance.Volume("Pesto", volume.value);
        AudioManager.instance.Volume("Gun2", volume.value);
        AudioManager.instance.Volume("Gun3", volume.value);
        AudioManager.instance.Volume("Gun4", volume.value);
        AudioManager.instance.Volume("MonsterRoor", volume.value);
        s.volume = volume.value;
        PlayerPrefs.SetFloat("volume", volume.value);
        PlayerPrefs.SetFloat("music", music.value);
        PlayerPrefs.Save();



    }
}
