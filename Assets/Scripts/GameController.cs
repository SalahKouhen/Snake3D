using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameController : MonoBehaviour
{
    // stores gamestate and other scripts come here to find if the game has started or been reset.
    public bool startScreen = true;
    public GameObject starthud;
    public GameObject gamehud;
    

    void Start()
    {

    }

    void Update()
    {
        
    }

    public void StartGame()
    {
        starthud.SetActive(false);
        gamehud.SetActive(true);
        startScreen = false;
    }
}
