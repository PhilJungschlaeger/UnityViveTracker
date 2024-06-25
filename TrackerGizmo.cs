using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

#if UNITY_EDITOR
using UnityEditor;
#endif

[ExecuteInEditMode]
public class TrackerGizmo : MonoBehaviour
{
    private TrackerAdapter ta = null;

    private Vector3 lastPos = new Vector3();

    public Transform cam;
    public bool dead = false;

    public TextMeshPro tmp = null;

    // Start is called before the first frame update
    void Start()
    {
        ta = GetComponent<TrackerAdapter>();
        tmp.SetText(ta.id.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(lastPos, transform.position) == 0) {
            dead = true;
        } else {
            dead = false;
        }
        lastPos = transform.position;
        tmp.SetText(ta.id.ToString());
        tmp.color = dead ? new Color(1, 0, 0, 1) : new Color(0, 1, 0, 1);
    }

    void LateUpdate() {
        if(FindAnyObjectByType<Camera>()){
            transform.LookAt(transform.position + FindAnyObjectByType<Camera>().transform.forward);
        }
    }

#if UNITY_EDITOR
    void OnDrawGizmos()
    {
        if (dead) {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(transform.position, 0.05f);
        } else {
            GUIStyle style = new GUIStyle("Label");
            style.fontSize = 40;
            Handles.Label(transform.position, ta.id.ToString(), style);
            Gizmos.color = Color.green;
            Gizmos.DrawSphere(transform.position, 0.05f);
        }
    }
#endif
}
