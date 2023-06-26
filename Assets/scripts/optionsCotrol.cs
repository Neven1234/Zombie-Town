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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        z1.volume = volume.value;
        z2.volume = volume.value;
        z3.volume = volume.value;
        menuMusic.volume = music.value;
        for(int i=0;i< AudioManager.instance.sounds.Length;i++)
        {
            AudioManager.instance.sounds[i].volume = volume.value;
        }
        
    }
}
