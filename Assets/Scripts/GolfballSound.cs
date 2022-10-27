using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolfballSound : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (GetComponent<AudioSource>().enabled == true) { GetComponent<AudioSource>().Play(); }
    }
}
