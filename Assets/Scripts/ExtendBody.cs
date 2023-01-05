using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtendBody : MonoBehaviour
{
    public GameObject lastSegment;
    public Transform tail;
    public GameObject bodySegmentPrefab;
    public Transform parentBody;

    public void ExtendSnake()
    {
        GameObject newSegment = Instantiate
        (
            bodySegmentPrefab, 
            lastSegment.transform.position + (lastSegment.transform.up * -2), //Use vector addition to set a position slightly behind the last segment
            lastSegment.transform.rotation, //Copy the last segment's orientation
            parentBody
        );

        //Swap the SpringJoint in the previous segment to hold the new one
        SpringJoint lastSpring = (lastSegment.GetComponent(typeof(SpringJoint)) as SpringJoint);
        lastSpring.connectedBody = (newSegment.GetComponent(typeof(Rigidbody)) as Rigidbody);
        Vector3 connector = lastSpring.connectedAnchor;
        connector.y = 1;
        lastSpring.connectedAnchor = connector;

        
    }
}
