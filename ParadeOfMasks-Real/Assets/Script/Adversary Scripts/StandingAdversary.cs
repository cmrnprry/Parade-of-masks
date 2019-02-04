using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandingAdversary : MonoBehaviour
{

    // how long they look one way
    private float counter;
    public float count;

    // which way they are facing
    public bool isFacingRight;

    void Start()
    {
        counter = count;
        isFacingRight = false;

    }

    // flips the adversay sprite when they turn
    private void Flip()
    {
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }


    void Update()
    {
        // makes them turn left and right evey X amount of seconds
        counter -= Time.deltaTime;

        if (counter <= 0)
        {
            Flip();
            isFacingRight = !isFacingRight;
            counter = count;
        }

    }
}
