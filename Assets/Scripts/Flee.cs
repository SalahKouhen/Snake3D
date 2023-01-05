using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flee : MonoBehaviour
{
    // assign a random velocity vector every second to the food
    // send out a sphere to detect what is around it
    // if there is a boundary or player add velocity the opposite direction
    // if there is other food, find the center of that food and go towards it
    // if you are too close to another move away from it

    private Rigidbody rb;
    private IEnumerator boid;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        rb.velocity = 3f * randomDir();


        boid = WhereIAm();
        StartCoroutine(boid);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator WhereIAm()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f);

            //they always try to move forward a bit
            //rb.velocity += randomDir();
            
            // first get away from others
            Collider[] nearbyCo = Physics.OverlapSphere(transform.position, 3f);

            foreach (var co in nearbyCo)
            {
                if (co.tag == "Bound")
                {
                    rb.velocity += Vector3.up;

                }
                else if(co.tag == "Player")
                {
                    rb.velocity -= 5f*(co.gameObject.transform.position - transform.position).normalized;
                }
                else if(co.tag == "SnakeFood")
                {
                    rb.velocity -= 0.1f*(co.gameObject.transform.position - transform.position).normalized;
                }


            }

            // then seek refuge in crowd
            Collider[] farbyCo = Physics.OverlapSphere(transform.position, 10f);
            Vector3 flockCtr = new Vector3(0f, 0f, 0f);
            Vector3 flockVel = new Vector3(0f, 0f, 0f);
            int flockSize = 0;
            foreach (var co in farbyCo)
            {
                if (co.tag == "SnakeFood")
                {
                    flockCtr += co.gameObject.transform.position;
                    flockVel += co.gameObject.GetComponent<Rigidbody>().velocity;
                    flockSize += 1;
                }
            }

            flockCtr = flockCtr / flockSize;
            flockVel = flockVel / flockSize;
            rb.velocity += 10f*(flockCtr -transform.position).normalized;
            rb.velocity += 10f*flockVel.normalized;



            rb.velocity = 9f * rb.velocity.normalized;
        }
    }

    Vector3 randomDir()
    {
        return new Vector3(Mathf.Ceil(Random.Range(-1, 1)), Mathf.Ceil(Random.Range(-1, 1)), Mathf.Ceil(Random.Range(-1, 1)));
    }
}
