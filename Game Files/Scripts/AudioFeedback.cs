using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioFeedback : MonoBehaviour {

	public GameObject music;
	public GameObject feedback;
	AudioSource musicSource;
	AudioSource feedbackSource;
	public static float frequency;
	public float freqDist;
	public float[] feedbackRanges = new float[4];

	// Use this for initialization
	void Start () {
		frequency = FreqTuner.frequency;
		feedbackRanges[0] = 104.8f;
		feedbackRanges[1] = 95.4f;
	}
	
	// Update is called once per frame
	void Update () {
		frequency = FreqTuner.frequency;
		for(int i =0;i<2;i++){
			if((frequency > feedbackRanges[i] - 2)&&(frequency < feedbackRanges[i] + 2)){
				MainGUI.listeners.RadioInterference = true;
				freqDist = frequency - feedbackRanges[i];
				if(freqDist < 0){
					freqDist = -freqDist;
				}
				musicSource = music.GetComponent<AudioSource>();
				feedbackSource = feedback.GetComponent<AudioSource>();
				musicSource.volume = freqDist/2;
				feedbackSource.volume = (2 - freqDist)/2;
				break;
				//Debug.Log(musicSource.volume);
			} else {
				freqDist = frequency - feedbackRanges[0];
				//Debug.Log("NOT IN RANGE " + freqDist);
				MainGUI.listeners.RadioInterference = false;
			}
		}
	}
}
