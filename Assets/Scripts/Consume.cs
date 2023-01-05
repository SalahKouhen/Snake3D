using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Consume : MonoBehaviour
{
    public int score;
    public TextMeshProUGUI scoreGame;

    public GameObject body;
    private ExtendBody extendbody;

    // Start is called before the first frame update
    void Start()
    {
        extendbody = body.GetComponent<ExtendBody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "SnakeFood")
        {
            Destroy(collision.gameObject);
            score++;
            scoreGame.text = "Score: " + score;
            extendbody.ExtendSnake();
        }
    }
}
