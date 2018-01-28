using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapeIntoDeck : MonoBehaviour {

	public static bool tapeEngaging = false;
	public static bool tapeEngaged = false;

	 void OnTriggerEnter(Collider collider) {
        if (collider.gameObject.name == "CassettePlayer")
        {
            this.transform.parent = collider.transform;
            this.transform.localPosition = new Vector3(0, 0.26f, 0.2f);
            this.transform.localRotation = Quaternion.identity;
            this.transform.RotateAround(transform.position, transform.right, 90);
            tapeEngaging = true;
        }
    }
	public bool tapeBusy()
    {
        return (tapeEngaging || tapeEngaged);
    }
	void Update(){
		if(tapeEngaging == true){
			this.transform.Translate(0,-0.15f,0);
			tapeEngaging = false;
			tapeEngaged = true;
		}
	}
}
