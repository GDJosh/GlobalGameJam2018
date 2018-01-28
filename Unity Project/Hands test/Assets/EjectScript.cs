using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EjectScript : MonoBehaviour {

    public GameObject TapePlayer;
	// Use this for initialization
	void Start () {
		
	}
    void OnTriggerEnter(Collider collider)
    {
        Debug.Log("Eject Pressed");
        var script = TapePlayer.GetComponent<DropTape>();

        if (script != null)
        {
            Debug.Log("script exists");
            script.DestroyMyTape();
        }
    }
    // Update is called once per frame
    void Update () {
		
	}
}
