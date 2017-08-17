using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoopController : MonoBehaviour {

    public ParticleSystem myPart;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<BallScript>() != null)
        {
            myPart.Stop();
            myPart.Play();
            FindObjectOfType<ScoreController>().Score(1);
            GetComponent<Collider>().enabled = false;

        }
    }
}
