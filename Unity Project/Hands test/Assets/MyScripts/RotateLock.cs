using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateLock : MonoBehaviour {
    
    public float MaxRotationValue = 0.5f;
    public float MinRotationValue = -0.5f;
    public char rotateAxis = 'x';
    Rigidbody rigidbody;
	// Use this for initialization
	void Start () {
        rigidbody = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update ()
    {

        switch (rotateAxis)
        {
            case ('x'):

                float angleX = 0.0F;
                float tempvect = transform.localEulerAngles.x;
                if(tempvect > 90 || tempvect < -90)
                {
                    var joint = GetComponent<FixedJoint>();
                    if (joint != null)
                    {
                        joint.connectedBody = null;
                        Destroy(joint);
                        rigidbody.useGravity = true;
                    }
                }
                angleX = Mathf.Clamp(tempvect, -90F, 90F);
                Quaternion quatAngle = Quaternion.AngleAxis(angleX, Vector3.right);
                rigidbody.rotation = quatAngle;
                break;
            case ('y'):
                float angleY= 0.0F;
                float tempvect2 = transform.localEulerAngles.y;
                if (tempvect2 > 90 || tempvect2 < -90)
                {
                    var joint = GetComponent<FixedJoint>();
                    if (joint != null)
                    {
                        joint.connectedBody = null;
                        Destroy(joint);
                        rigidbody.useGravity = true;
                    }
                }
                angleY = Mathf.Clamp(tempvect2, -90F, 90F);
                Quaternion quatAngle2 = Quaternion.AngleAxis(angleY, Vector3.up);
                rigidbody.rotation = quatAngle2;
                break;
            case ('z'):
                float angleZ = 0.0F;
                float tempvect3 = transform.localEulerAngles.z;
                if (tempvect3 > 90 || tempvect3 < -90)
                {
                    var joint = GetComponent<FixedJoint>();
                    if (joint != null)
                    {
                        joint.connectedBody = null;
                        Destroy(joint);
                        rigidbody.useGravity = true;
                    }
                }
                angleZ = Mathf.Clamp(tempvect3, -90F, 90F);
                Quaternion quatAngle3 = Quaternion.AngleAxis(angleZ, Vector3.forward);
                rigidbody.rotation = quatAngle3;
                break;
        }
        
	}
}
