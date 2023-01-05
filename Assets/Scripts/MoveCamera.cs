using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public GameObject head;
    private float damping = 10f;
    private Death death;
    private bool gameOver;

    // Start is called before the first frame update
    void Start()
    {
        death = head.GetComponent<Death>();
    }

    // Update is called once per frame
    void Update()
    {
        gameOver = death.gameOver;
    }

    void LateUpdate()
    {
        if (!gameOver) 
        {
            transform.position = head.transform.position + head.transform.up - 8f * head.transform.forward;
            var lookpos = head.transform.position - transform.position;
            //lookpos.y = 0;
            var rotation = Quaternion.LookRotation(lookpos);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * damping);
        }
        else
        {
            transform.LookAt(head.transform);
        }
        

    }
}
