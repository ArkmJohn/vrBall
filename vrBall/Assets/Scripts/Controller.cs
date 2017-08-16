using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class Controller : MonoBehaviour {

    public GameObject ball;
    public float movementSpeed = 9;
    public GameObject cam;
    public Rigidbody rb;

	// Use this for initialization
	void Start () {
        cam = Camera.main.gameObject;
        
        rb = Player.instance.gameObject.GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }
	
	// Update is called once per frame
	void Update () {
        Use();
	}

    void Use()
    {
        Player player = Player.instance;

        if (!player)
        {
            return;
        }

        // Lets the player interact with other stuff
        if (player.leftController != null || player.rightController != null)
        {
            if (player.rightController.GetPressDown(SteamVR_Controller.ButtonMask.Grip))
            {
                Instantiate(ball, player.rightHand.transform.position, Quaternion.identity);
            }
            else if (player.leftController.GetPressDown(SteamVR_Controller.ButtonMask.Grip))
            {
                Instantiate(ball, player.leftHand.transform.position, Quaternion.identity);

            }
        }
    }

    /*void FixedUpdate()
    {
        //if (isWalking)
        //{
        //    //rb.AddForce(moveDir * movementSpeed * 50, ForceMode.Force);
        //    rb.AddForce(moveDir, ForceMode.VelocityChange);
        //    //Debug.Log(moveDir * movementSpeed);
        //    //rb.velocity = moveDir + Player.instance.transform.position;
        //    Debug.Log("What");
        //}

        Player player = Player.instance;

        if (!player)
        {
            return;
        }

       

        EVRButtonId tPad = EVRButtonId.k_EButton_SteamVR_Touchpad;

        if (player.leftController != null)
        {

            // -- Player Movement -- //
                Quaternion orient = Camera.main.transform.rotation;
                Vector2 tPadVector = ProcessInput();
               

                if ((Mathf.Abs(tPadVector.x) > float.Epsilon || Mathf.Abs(tPadVector.y) > float.Epsilon))
                {
                    Vector3 desVel = cam.transform.forward * tPadVector.y + cam.transform.right * tPadVector.x;
                    desVel.x = desVel.x * currentTargSpeed;
                    desVel.z = desVel.z * currentTargSpeed;
                    desVel.y = desVel.y * currentTargSpeed;

                    if (rb.velocity.sqrMagnitude < currentTargSpeed * currentTargSpeed)
                        rb.AddForce(desVel * SlopeMultiplier(), ForceMode.Impulse);
                }
                rb.drag = 5;
                if (Mathf.Abs(tPadVector.x) < float.Epsilon && Mathf.Abs(tPadVector.y) < float.Epsilon && rb.velocity.magnitude < 1f)
                {
                    rb.Sleep();
                }
            }
        }
    */
    [HideInInspector]
    public float currentTargSpeed = 1;
    public AnimationCurve SlopeCurveModifier = new AnimationCurve(new Keyframe(-90.0f, 1.0f), new Keyframe(0.0f, 1.0f), new Keyframe(90.0f, 0.0f));
    private float SlopeMultiplier()
    {
        float angle = Vector3.Angle(new Vector3(0, 1, 0), Vector3.up);
        return SlopeCurveModifier.Evaluate(angle);
    }
    Vector2 ProcessInput()
    {
        Player player = Player.instance;

        if (!player)
        {
            return Vector2.zero;
        }

        EVRButtonId tPad = EVRButtonId.k_EButton_SteamVR_Touchpad;
        Vector3 tPadVector = player.leftController.GetAxis(tPad);

        Vector2 input = new Vector2(tPadVector.x, tPadVector.y);

        if (input.x > 0 || input.x < 0)
        {
            currentTargSpeed = (movementSpeed * 0.7f);
        }
        if (input.y > 0 || input.y < 0)
        {
            currentTargSpeed = (movementSpeed * 0.7f);
        }

        return input;
    }
}
