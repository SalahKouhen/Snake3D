using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtendBody : MonoBehaviour
{
    public Transform lastSegment;
    public Transform tail;
    public GameObject bodySegmentPrefab;

    void ExtendSnake()
    {
        Vector3 backwards = lastSegment.up * -1;
    }
}
