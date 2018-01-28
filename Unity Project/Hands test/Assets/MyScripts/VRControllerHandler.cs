using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRControllerHandler : MonoBehaviour
{

    private SteamVR_TrackedObject trackedObj;
    private GameObject collidingObject;
    public GameObject objectInHand;
    private SteamVR_Controller.Device Controller
    {
        get { return SteamVR_Controller.Input((int)trackedObj.index); }
    }
    void Awake()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
    }
    private void SetCollidingObject(Collider col)
    {
        if (collidingObject || !col.GetComponent<Rigidbody>())
        {
            return;
        }
        collidingObject = col.gameObject;
    }
    public void OnTriggerEnter(Collider other)
    {
        SetCollidingObject(other);
    }

    public void OnTriggerStay(Collider other)
    {
        SetCollidingObject(other);
    }

    public void OnTriggerExit(Collider other)
    {
        if (!collidingObject)
        {
            return;
        }
        collidingObject = null;
    }
    private void GrabObject()
    {
        objectInHand = collidingObject;
        objectInHand.GetComponent<Rigidbody>().useGravity = false;
        collidingObject = null;
        var joint = AddFixedJoint();
        joint.connectedBody = objectInHand.GetComponent<Rigidbody>();
    }
    public void ReleaseObject()
    {
        Debug.Log("Releasing");
        if (GetComponent<FixedJoint>())
        {
            Debug.Log("Has Joint");
            if (GetComponent<FixedJoint>().connectedBody.name == "Me-ScannerKNob")
            {
                Debug.Log("Release Knob");
                var obj = GetComponent<FixedJoint>().connectedBody;
                Destroy(GetComponent<FixedJoint>());
            }
            else
            {
                GetComponent<FixedJoint>().connectedBody = null;

                Destroy(GetComponent<FixedJoint>());
                objectInHand.GetComponent<Rigidbody>().useGravity = true;
                objectInHand.GetComponent<Rigidbody>().velocity = Controller.velocity;
                objectInHand.GetComponent<Rigidbody>().angularVelocity = Controller.angularVelocity;
            }
        }
        objectInHand = null;
    }
    private FixedJoint AddFixedJoint()
    {
        FixedJoint fx = gameObject.AddComponent<FixedJoint>();
        
        return fx;
    }
    // Update is called once per frame
    void Update()
    {

        // 2
        if (Controller.GetHairTriggerDown())
        {
            Debug.Log(gameObject.name + " Trigger Press");
        }

        // 3
        if (Controller.GetHairTriggerUp())
        {
            Debug.Log(gameObject.name + " Trigger Release");
        }

        // 4
        if (Controller.GetPressDown(SteamVR_Controller.ButtonMask.Grip))
        {
            if (collidingObject)
            {
                try
                {
                    var tapeScript = objectInHand.GetComponent<TapeIntoDeck>();
                    if (!tapeScript.tapeBusy())
                    {
                        GrabObject();
                    }
                    else
                    {
                        GetComponent<Rigidbody>().useGravity = false;
                        ReleaseObject();
                    }
                }
                catch
                {
                    GrabObject();
                }
            }
        }

        // 5
        if (Controller.GetPressUp(SteamVR_Controller.ButtonMask.Grip))
        {
                ReleaseObject();            
        }
    }
}
