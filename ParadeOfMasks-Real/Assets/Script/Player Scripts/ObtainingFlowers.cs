using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class ObtainingFlowers : MonoBehaviour
{
    public Text leaveText;
    public int flowerCount;
    public float counter = 3;

    private void Start()
    {
        leaveText.text = "";
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Flower")
        {
            Destroy(other.gameObject);
            flowerCount += 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (flowerCount == 3)
        {
            counter -= Time.deltaTime;
            leaveText.text = "Time to take the bus home.";
        }

        if (counter <= 0)
        {
            leaveText.text = "";
        }

    }

}
