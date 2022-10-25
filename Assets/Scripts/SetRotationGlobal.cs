using System;
using UnityEngine;

public class SetRotationGlobal : MonoBehaviour
{
    void Start() => transform.rotation = Quaternion.Euler(0,0,0);

    private void OnValidate() => transform.rotation = Quaternion.Euler(0,0,0);
}
