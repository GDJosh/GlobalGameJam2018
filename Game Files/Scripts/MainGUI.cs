using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGUI : MonoBehaviour {

	public static Texture2D phone;
	public GUISkin markerSkin;
	
	public static ScoreManager listeners;
	
	// Use this for initialization
	void Start () {
		listeners = new ScoreManager();
		listeners.Start();
	}
	
	// Update is called once per frame
	void Update () {
		listeners.Update();
	}
	
	void OnGUI() {
		
		GUI.skin = markerSkin;
	
		GUI.Label(new Rect(20, 20, 300, 100), "Listeners " + listeners.CurrentScore.ToString("F0"));
	
		//GUI.DrawTexture(new Rect(10, Screen.height - 410, 394, 423), Resources.Load("PhoneMsg") as Texture);
	}
}
