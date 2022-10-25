using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjects;

public class AdjustFanMagnitude : MonoBehaviour
{
    public FloatValue fanMagnitude;
    private AreaEffector2D areaEffector;

    private void Awake()
    {
        areaEffector = GetComponent<AreaEffector2D>();
    }

    private void Update()
    {
        areaEffector.forceMagnitude = fanMagnitude.Value;
    }
}
