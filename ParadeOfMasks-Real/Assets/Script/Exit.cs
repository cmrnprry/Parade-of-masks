using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    private GameObject player;
    private ObtainingFlowers flowerScript;

    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("Player");
        flowerScript = player.GetComponent<ObtainingFlowers>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player" && flowerScript.flowerCount == 3)
        {
            SceneManager.LoadScene("Calendar", LoadSceneMode.Single);
        }
    }
}
