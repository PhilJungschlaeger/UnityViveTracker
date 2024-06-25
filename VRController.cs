using System.Collections;
using System.Collections.Generic;
using OVRT;
using UnityEngine;
using Valve.VR;


public class VRController : MonoBehaviour
{
    public GameObject   sceneOrigin;
    public GameObject   trackedOrigin;
    public bool fixOrigin = true;
    public List<GameObject> trackerList;

    // Start is called before the first frame update
    void Start()
    {
        if (sceneOrigin == null)
        {
            Debug.Log("ERROR: sceneOrigin not set!");
        }
        if (trackedOrigin == null)
        {
            trackedOrigin = gameObject;//trackerList[0];
            Debug.Log("ERROR: trackedOrigin set to first!");
        }

        if (fixOrigin) {
            StartCoroutine(FixOriginInitial());
        }
    }

    void Update() {
        
    }


    private IEnumerator FixOriginInitial()
    {
        yield return new WaitForSeconds(5);
        if(trackedOrigin.gameObject.transform.GetComponent<OVRT_TrackedObject>() != null)
        {
            trackedOrigin.gameObject.transform.GetComponent<OVRT_TrackedObject>().enabled = false;
        }
    }
}
