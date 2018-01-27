using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGUI : MonoBehaviour {

	public static Texture2D phone;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnGUI() {
		GUI.DrawTexture(new Rect(10, Screen.height - 410, 394, 423), Resources.Load("PhoneMsg") as Texture);
	}
}
