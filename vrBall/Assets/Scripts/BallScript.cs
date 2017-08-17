using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour {

    public AudioClip bounce;
    AudioSource aS;

    void Start()
    {
        aS = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision other)
    {
        aS.PlayOneShot(bounce, Random.Range(0, 1.0f));
    }

    public void Throw()
    {

    }
}
