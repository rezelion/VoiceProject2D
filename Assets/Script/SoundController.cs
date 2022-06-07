using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public AudioSource audio;

    public AudioClip SpeechFeed;
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    public void PlaySelected(int list)
    {
        if(list == '1')
        {
            audio.PlayOneShot(SpeechFeed);
        }
        
    }
}
