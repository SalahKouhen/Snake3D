using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadMovement : MonoBehaviour
{

    [Header("mouse controls")]
    private Vector3 mouseFirstPos;
    private Vector3 mouseOffset;
    private bool firstClickFlag;
    private float dragSensitivity = 1000f;

    [Header("pitching, yaw and roll")]
    public Vector3 turnTorque = new Vector3(90f, 25f, 5f);
    private Rigidbody rb;
    public float yaw;
    public float pitch;
    public float roll;
    public float forceMult = 1f;
    private float dragFactor = 1f;

    [Header("forward movement")]
    private float thrust = 10f;


    void Start()
    {
        firstClickFlag = true;
        rb = GetComponent<Rigidbody>();

    }
    void Update()
    {
        //Debug.Log(firstClickFlag);
        if (Input.GetMouseButton(0))
        {
            if (firstClickFlag)
            {
                mouseFirstPos = Input.mousePosition;
                firstClickFlag = false;
            }
            mouseOffset = (Input.mousePosition - mouseFirstPos)/dragSensitivity;
            //Debug.Log(mouseOffset.x);

        }
        else
        {
            firstClickFlag = true;
            mouseOffset.x = 0f;
            mouseOffset.y = 0f;
        }

        yaw = mouseOffset.x;
        pitch = mouseOffset.y;
        var agressiveRoll = Mathf.Clamp(mouseOffset.x, -1f, 1f);
        var wingsLevelRoll = transform.right.y;
        var wingsLevelInfluence = Mathf.InverseLerp(0f, 10f, 0.01f);
        roll = Mathf.Lerp(wingsLevelRoll, agressiveRoll, wingsLevelInfluence);

        rb.velocity = thrust * transform.forward;
    }

    void FixedUpdate()
    {
        rb.AddRelativeTorque(new Vector3(-turnTorque.x * pitch,
                                                turnTorque.y * yaw,
                                                -turnTorque.z * roll) * forceMult,
                                    ForceMode.Force);
        //damp the rotation
        rb.AddTorque(-rb.angularVelocity * dragFactor);
    }
    private Quaternion Damp(Quaternion a, Quaternion b, float lambda, float dt)
    {
        return Quaternion.Slerp(a, b, 1 - Mathf.Exp(-lambda * dt));
    }
}
