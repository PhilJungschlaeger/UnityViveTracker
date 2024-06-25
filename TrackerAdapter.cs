using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class TrackerAdapter : MonoBehaviour
{
    public int id=1;
    public float lerpPos=1.0f;
    public float lerpRot=1.0f;
    private VRController ctr;

    public Vector3 eulerRotation = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        ctr = (VRController)FindObjectOfType(typeof(VRController));
        if(ctr==null)
        {
            Debug.Log("ERROR: VR CONTROLLER NOT FOUND!");
        }
        if(ctr.trackerList[id - 1] == null)
        {
            Debug.Log("ERROR: Adapter does not find entry for id ("+id+") !");
        }
    }

    // Update is called once per frame
    void Update()
    {
        var (pos, rot) = Utils.ApplyMirroredTransform(ctr.trackedOrigin.transform, ctr.trackerList[id - 1].transform, ctr.sceneOrigin.transform );
        this.transform.position = Vector3.Lerp(this.transform.position, pos, lerpPos);
        this.transform.rotation = Quaternion.Lerp(this.transform.rotation, rot * Quaternion.Euler(eulerRotation), lerpPos);
    }
}
