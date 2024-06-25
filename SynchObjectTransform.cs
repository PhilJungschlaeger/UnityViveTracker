using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SynchObjectTransform : MonoBehaviour {
    public GameObject fromObject;
    public bool syncPosition, syncRotation;

    private void FixedUpdate() {
        // prioritizes trackerdata when given
        var tmp = fromObject;
        if(syncPosition)
            transform.position = tmp.transform.position;  
        if(syncRotation)      
            transform.rotation = tmp.transform.rotation;  
    }
}
