using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreqTuner : MonoBehaviour {

	public static float dialAngle;
	public static float frequency;
	public float needlePos;
	public GameObject needle;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		dialAngle = this.transform.eulerAngles.z;
		frequency = (dialAngle / 15f) + 88;
		needlePos = (dialAngle / 1150f) - 0.18f;
		needle.transform.localPosition = new Vector3(needlePos, 0.1899f, -0.245f);
		//Debug.Log(dialAngle + " " + needlePos);
	}
	
	void OnGUI (){
		//GUI.Label(new Rect(10, 10, 200, 100), frequency + "Hz");	
	}
}
