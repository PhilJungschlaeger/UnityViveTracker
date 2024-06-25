using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utils
{
    public static IEnumerable<T> LoadAllOfType<T>() where T : Object {
        // return Resources.FindObjectsOfTypeAll<T>();
        return Resources.LoadAll<T>("TrackerData");
    }

    public static (Vector3, Quaternion) ApplyMirroredTransform(Transform vrOrigin, Transform vrObject, Transform mirrorOrigin){
        // mirrors and applies the relation between vrOrigin and vrObject to mirrorOrigin and mirrorObject
        // scale is not taken into account
        var inverseMat = vrOrigin.worldToLocalMatrix * vrObject.localToWorldMatrix;
        var mirrorMat = mirrorOrigin.localToWorldMatrix * inverseMat;
        //(Vector3, Vector3) destination;
        //destination.position = mirrorMat.GetColumn(3);
        //destination.rotation = Quaternion.LookRotation(mirrorMat.GetColumn(2), mirrorMat.GetColumn(1));
        return (mirrorMat.GetColumn(3), Quaternion.LookRotation(mirrorMat.GetColumn(2), mirrorMat.GetColumn(1)));
        //destination.localScale = new Vector3(mirrorMat.GetColumn(0).magnitude, mirrorMat.GetColumn(1).magnitude, mirrorMat.GetColumn(2).magnitude);
    }
}
