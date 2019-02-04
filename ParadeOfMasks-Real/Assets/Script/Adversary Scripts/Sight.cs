using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sight : MonoBehaviour
{

    public GameObject player;
    private PlayerMovement move;

    public bool seen;

    public float count;
    public float counter;

    // Use this for initialization
    void Start()
    {
        move = player.GetComponent<PlayerMovement>();
        counter = count;
       Debug.Log(this.GetComponent<SpriteRenderer>().color);

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            seen = true;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            seen = true;

            // if the mask is down, do the knockback
            if (!move.isMask && counter <= 0)
            {
                move.knockbackCount = move.knockbackLength;
                move.isKnocked = true;
                move.Knockback();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        counter = count;
        seen = false;
    }

    public void SetTransparency()
    {
        Color current = this.GetComponent<SpriteRenderer>().color;
        Color transparent = current;
        transparent.a = current.a + 0.01f;
        this.GetComponent<SpriteRenderer>().color = transparent;

    }

    public void ReverseTransparency()
    {
        Color current = this.GetComponent<SpriteRenderer>().color;
        Color transparent = current;
        transparent.a = current.a - 0.01f;
        this.GetComponent<SpriteRenderer>().color = transparent;
    }

    // Update is called once per frame
    void Update()
    {

        if (seen)
        {
            SetTransparency();
        }
        if (!seen && this.GetComponent<SpriteRenderer>().color.a > .196f)
        {
            ReverseTransparency();
        }

        if (this.GetComponentInParent<StandingAdversary>().isFacingRight)
        {
            move.knockFromRight = true;
        }
        else
        {
            move.knockFromRight = false;
        }

        if (!move.isMask && seen)
        {
            counter -= Time.deltaTime;
        }

    }
}
