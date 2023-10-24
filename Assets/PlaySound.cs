using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour {

    [SerializeField] private Animator myAnimationController; 
    private AudioSource source;

	// Use this for initialization
	void Start () {
        source = GetComponent<AudioSource>();
	}

    private void Update()
    {
       
    }

    private void OnTriggerEnter(Collider other)
    {

        myAnimationController.SetBool("press_tom2", true);
        source.volume = other.gameObject.GetComponent<TrackSpeed>().speed;
        ActivateSound();
        
    }

    private void OnTriggerExit(Collider other)
    {  
        myAnimationController.SetBool("press_tom2", false);  
    }

    private void ActivateSound()
    {
        //source.pitch = Random.Range(0.8f, 1.2f);
        source.Play();
    }

    

}
