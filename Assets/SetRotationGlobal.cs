using System;
using UnityEngine;

public class SetRotationGlobal : MonoBehaviour
{
    void Start()
    {
        var t = this.transform;
        var acos = Mathf.Acos(t.rotation.z * t.parent.rotation.z);
        var acosToDeg = acos * Mathf.Rad2Deg;
        print(acos);
        transform.Rotate(Vector3.forward, acosToDeg ,Space.World);
    }
}
