using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeedleMove : MonoBehaviour {

	public static float dialSlide = 0.5f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update() {
        transform.Translate(Vector3.left * Time.deltaTime * dialSlide, Space.World);
		if ((transform.position.x >= 0.15f)||(transform.position.x <= -0.18f)){
			dialSlide = -dialSlide;
		}
    }
}
