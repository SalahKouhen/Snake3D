using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtendBody : MonoBehaviour
{
    public GameObject lastSegment;
    public GameObject tail;
    public GameObject bodySegmentPrefab;
    public Transform parentBody;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ExtendSnake();
        }
    }

    public void ExtendSnake()
    {
        GameObject newSegment = Instantiate
        (
            bodySegmentPrefab, 
            lastSegment.transform.position + (lastSegment.transform.up * -2), //Use vector addition to set a position slightly behind the last segment
            lastSegment.transform.rotation, //Copy the last segment's orientation
            parentBody
        );

        //Swap the spring joint in the previous segment to hold the new one
        SpringJoint lastSpring = (lastSegment.GetComponent(typeof(SpringJoint)) as SpringJoint);
        lastSpring.connectedBody = (newSegment.GetComponent(typeof(Rigidbody)) as Rigidbody);
        Vector3 connector = lastSpring.connectedAnchor;
        connector.y = 1;
        lastSpring.connectedAnchor = connector;

        //Move tail backwards and connect new segment's spring joint to it
        tail.transform.position += (lastSegment.transform.up * -2);
        SpringJoint newSpring = (newSegment.GetComponent(typeof(SpringJoint)) as SpringJoint);
        newSpring.connectedBody = (tail.GetComponent(typeof(Rigidbody)) as Rigidbody);

        //Change reference to lastSegment so we can recurse this process
        lastSegment = newSegment;
    }
}
