using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour {

    public bool playBackAudio;
    public static SoundController Instance;

    public AudioSource source;

	// Use this for initialization
	void Start () {
        if (Instance == null) Instance = GetComponent<SoundController>();
	}
	

    public void PlayClip(AudioClip clip)
    {
        source.PlayOneShot(clip);
    }
}
