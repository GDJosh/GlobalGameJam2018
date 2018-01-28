using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayTape : MonoBehaviour {

	public AudioClip[] audioTracks = new AudioClip[3];
	public static bool cassettePlaying = false;
	public static float countdown = 0;
	public static int tracksPlayed = 0;
	
	void FixedUpdate(){
		if((TapeIntoDeck.tapeEngaged == true)&&(cassettePlaying == false)){
			playCassette();
			cassettePlaying = true;
			//Debug.Log("Cassette On!");
			countdown = 30f;
		}
		if(countdown > 0){
			countdown -= 0.01677f;
		} else {
			stopCassette();
		}
	}
	
	void OnGUI (){
		GUI.Label(new Rect(10, 60, 200, 100), countdown + "s");	
	}
	
	void playCassette(){
		AudioSource audio = GetComponent<AudioSource>();
		audio.clip = audioTracks[tracksPlayed];
		audio.Play();
		MainGUI.listeners.TapePlayerPlaying = true;
		tracksPlayed++;
	}
	void stopCassette(){
		AudioSource audio = GetComponent<AudioSource>();
		audio.Stop();
		MainGUI.listeners.TapePlayerPlaying = false;
	}
}
