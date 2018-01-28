using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropTape : MonoBehaviour {

    public GameObject fixedCasette;
    GameObject instTape;
	void Start ()
    {
		
	}
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.name == "GrabCasette")
        {
            var trans = collider.gameObject.transform;
            Destroy(collider.gameObject);
            instTape = Instantiate(fixedCasette, trans.position, trans.rotation);
            instTape.transform.parent = this.transform;
            instTape.transform.localPosition = new Vector3(0, 0.1f, -0.26f);
            instTape.transform.localRotation = Quaternion.identity;
            instTape.transform.RotateAround(transform.position, transform.right, 90);

        }
    }
    public void DestroyMyTape()
    {
        Debug.Log("destroying tape");
        if (instTape != null)
        {
            Debug.Log(instTape.name);
            Destroy(instTape);
            Debug.Log("Poof!");
        }
    }
    // Update is called once per frame
    void Update ()
    {
		

	}
}
