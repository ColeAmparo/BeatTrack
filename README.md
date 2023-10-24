# BeatTrack
[BeatTrack Demo](https://youtu.be/rvxP2L7acO8)


## Overview
I wanted to make a virtual reality game where the player would not only be able to play a working drum set but also learn how to play a simple beat for a popular song. The purpose of this game is not only to be fun, but it can also be an introduction to drumming since the player is playing an actual beat to a song.

BeatTrack has two main components the drum set and the BeatTrack.

### The Drumset
For the drum set, each of the drums and cymbals has its own mesh colliders. The drumsticks are where the player’s hands are, and the tip on the drumstick is a small sphere collider that is a rigid body.

### Sound Control
In order to make the drum louder or softer based on the power of the hit I used two functions, one that tracked the speed of the drumstick, and one that plays the drum sound when the drumstick collided with the drum.

```cs
Speed Tracker:

public class TrackSpeed : MonoBehaviour {
 
   private Vector3 lastPosition;
   public float speed;
 
   // Use this for initialization
   void Start () {
       lastPosition = transform.position;
   }
  
   void FixedUpdate () {
       speed = (((transform.position - lastPosition).magnitude) / Time.deltaTime);
       lastPosition = transform.position;
   }
}
lastPosition is updated every frame and is subtracted from the current position of the drumstick. That magnitude is used to calculate the speed between the two positions.

Sound Trigger:

private void OnTriggerEnter(Collider other)
   {
 
       myAnimationController.SetBool("press_tom2", true);
       source.volume = other.gameObject.GetComponent<TrackSpeed>().speed;
       ActivateSound();
      
   }
```
The speed variable is then used to decide the volume of the drum sound when the drumstick collides with the drum.

## The BeatTrack
The BeatTrack is the gray rectangle with 7 buttons on the bottom of it. The drumset is color coded to match the buttons.

Tom1 is Pink, HiHat cymbal is Yellow, Snare is Blue, Bass is Green, Tom 2 is Red, and Crash is Yellow.

When the drumstick hits a drum/cymbal, the matching button gets pressed down. If a button gets pressed down when a beat hits it, then the player gets a point.

## The Beats
The beats are cylinder objects that go down the BeatTrack and they are color coded to match a drum/cymbal. When a drum/cymbal is hit right when a beat is over a button you get a point, but it also makes a sound that matches the song.

## The Song
I used the song Smells like Teen Spirit by Nirvana. I made sure that the drum kit had sounds that matched the song, and that the order of the beats are correct. To do this I learned a simple drum beat for the song and tested it over and over to make sure it matched the song. Then I made a binary string for each drum.

I was counting each measure in 8ths, a 0 is an offbeat (no beat) and a 1 is an onbeat. The binary strings also showed when a note would be instantiated as well. The outcome is the player drumming along to the song with an actual drum beat.
