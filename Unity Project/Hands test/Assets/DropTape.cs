using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropTape : MonoBehaviour {

    public GameObject fixedCasette;
    public GameObject grabCasette;
    public GameObject playButton;
    GameObject instTape;
	void Start ()
    {
		
	}
    void OnTriggerEnter(Collider collider)
    {
        Debug.Log("Object in collider");
        if (collider.gameObject.name.Contains("GrabCasette"))
        {
            Debug.Log("Object is Tape");
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
            instTape.GetComponent<TapeIntoDeck>().disengageTape();
            var trans = instTape.transform;
            Debug.Log(instTape.name);
            Destroy(instTape);
            Debug.Log("Poof!");
            var myCasette = Instantiate(grabCasette, trans);
            myCasette.GetComponent<Rigidbody>().AddForce(Vector3.forward, ForceMode.Impulse);
            var script = playButton.GetComponent<PlayTape>();
            script.stopCassette();

            

        }
    }
    // Update is called once per frame
    void Update ()
    {
		

	}
}
