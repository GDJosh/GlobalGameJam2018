using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateLock : MonoBehaviour
{
    Quaternion myRot;
    Rigidbody rigidbody;
    // Use this for initialization
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        myRot = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        float anglew = 0.0F;
        float tempvect3 = transform.localEulerAngles.z;

        anglew = Mathf.Clamp(tempvect3, -90F, 90F);
        Quaternion quatAngle = Quaternion.AngleAxis(anglew, Vector3.forward);
        var rot = Quaternion.Euler(0, 0, anglew);
        transform.rotation = transform.rotation * rot;
    }
}
