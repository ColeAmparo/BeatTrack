using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notes : MonoBehaviour
{

    [SerializeField] private Animator myAnimationController; 

    public GameObject prefab;
    public string notation;
    public float speed;
    public float slowSpeed;
    public float slowerSpeed;


    private float nextPlayTime;
    private int currentNote;
    

    //This is determined by the song you're trying to sync up to
    public float songBpm;

    //The number of seconds for each song beat
    public float secPerBeat;

    //Current song position, in seconds
    public float songPosition;

    //Current song position, in beats
    public float songPositionInBeats;

    //How many seconds have passed since the song started
    public float dspSongTime;

    //an AudioSource attached to this GameObject that will play the music.
    public AudioSource musicSource;

    // Start is called before the first frame update
    void Start()
    {
        //Load the AudioSource attached to the Conductor GameObject
        musicSource = GetComponent<AudioSource>();

        //Calculate the number of seconds in each beat
        secPerBeat = 60f / songBpm;

        //Record the time when the music starts
        dspSongTime = (float)AudioSettings.dspTime;

        //Start the music
        //musicSource.Play();
    }

    // Update is called once per frame
	void Update () {
        songPosition = (float)(AudioSettings.dspTime - dspSongTime);
        songPositionInBeats = songPosition / secPerBeat;

        if (notation.Length == 0) return;
        

		if(songPosition >= nextPlayTime)
        {
            if(currentNote >= 73 && currentNote < 225)
            {
                if (currentNote > 128 && currentNote < 168) {
                    nextPlayTime = songPosition + slowerSpeed;
                } else {
                    nextPlayTime = songPosition + slowSpeed;
                }

            } else {
                nextPlayTime = songPosition + speed;
            }
            if(notation.Substring(currentNote,1) != "0")
            {
                Debug.Log(currentNote + "Hello");
                CreateNote();
            }
            currentNote++;
            //if (currentNote >= notation.Length) currentNote = 0;
        }
	}

    void CreateNote()
    {
        GameObject tempGO = Instantiate(prefab, transform);
        tempGO.transform.localPosition = new Vector3(0, 0, 30);
        iTween.MoveTo(tempGO, iTween.Hash("position", new Vector3(0, 0, 0), "time", 7f, "easeType", iTween.EaseType.linear, "isLocal", true));
        Destroy(tempGO, 7.2f);
    }

    void OnTriggerEnter(Collider other)
    {
        if(myAnimationController.GetBool("press_tom2"))
        {
            Score.score+=1; 
        }
    }
}

