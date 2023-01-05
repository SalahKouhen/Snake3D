using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawn : MonoBehaviour
{
    public GameObject food;
    public int foodConst = 100;
    public int foodNum = 0;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < foodConst; i++)
        {
            Instantiate(food, randomSpawn(), food.transform.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (foodNum < foodConst)
        {
            Instantiate(food, randomSpawn(), food.transform.rotation);
            foodNum += 1;
        }
    }

    Vector3 randomSpawn()
    {
        return new Vector3(Mathf.Ceil(Random.Range(-10, 10)), Mathf.Ceil(Random.Range(-10, 10)), Mathf.Ceil(Random.Range(-10, 10))) + 10f * Vector3.back;
    }
}
