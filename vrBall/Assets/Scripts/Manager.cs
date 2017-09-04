using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour {

    public GameObject subCamObject, vrCamObject;
    public GameObject earthLight;
    public GameObject earthToCamTansform;
    public GameObject lightning, spark, box1, box2;

    public float speed = 1f;

    public enum camMovementState
    {
        NotMoving,
        ToEarthPos
    }

    public camMovementState camState;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetButtonDown("Jump"))
        {
            camState = camMovementState.ToEarthPos;
        }

        if(Input.GetKeyDown(KeyCode.L))
        {
            Activate(lightning);
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            Activate(spark);
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Activate(box1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Activate(box2);
        }
        if (camState != camMovementState.NotMoving)
        {
            switch (camState)
            {
                case camMovementState.ToEarthPos:
                    MoveToPosCamera(earthToCamTansform);
                    break;
            }
        }
	}

    void Activate(GameObject go)
    {
        if (!go.activeSelf)
        {
            go.SetActive(true);
        }
        else
            go.SetActive(false);
    }

    void MoveToPosCamera(GameObject pos)
    {
        if (subCamObject.activeSelf)
        {
            if (pos.transform.position != subCamObject.transform.position)
            {
                subCamObject.transform.position = Vector3.MoveTowards(subCamObject.transform.position, pos.transform.position, speed * Time.deltaTime);
                subCamObject.GetComponent<Camera>().farClipPlane = 500;
                earthLight.SetActive(true);
            }
            else
            {

                camState = camMovementState.NotMoving;
            }
        }
        else
        {
            if (pos.transform.position != vrCamObject.transform.position)
            {
                vrCamObject.transform.position = Vector3.MoveTowards(vrCamObject.transform.position, pos.transform.position, speed * Time.deltaTime);
            }
            else
            {
                camState = camMovementState.NotMoving;
            }
        }
    }
}
