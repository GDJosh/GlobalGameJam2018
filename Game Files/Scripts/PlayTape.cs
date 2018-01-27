using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayTape : MonoBehaviour {

		public static bool cassettePlaying = false;

	 void OnTriggerEnter(Collider other) {
    }
	
	void Update(){
		if((TapeIntoDeck.tapeEngaged == true)&&(cassettePlaying == false)){
			playCassette();
			cassettePlaying = true;
			Debug.Log("Cassette On!");
		}
	}
	
	void playCassette(){
		AudioSource audio = GetComponent<AudioSource>();
		audio.Play();
	}
}
