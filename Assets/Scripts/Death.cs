using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Death : MonoBehaviour
{
    public bool gameOver;
    public GameObject deathHud;
    public GameObject gameHud;
    public TextMeshProUGUI finalScore;
    private Consume consume;
    private int score;

    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
        consume = GetComponent<Consume>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Body" || collision.gameObject.tag == "Bound")
        {
            gameOver = true;
            gameOverFn();
        }
    }
    void gameOverFn()
    {
        gameHud.SetActive(false);
        deathHud.SetActive(true);
        finalScore.text = "Score: " + consume.score;
    }
}
