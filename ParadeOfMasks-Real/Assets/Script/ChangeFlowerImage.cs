using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeFlowerImage : MonoBehaviour
{
    public GameObject player;
    private ObtainingFlowers obtain;

    public Sprite one_flower;
    public Sprite two_flower;
    public Sprite three_flower;

    public Image flower;
 
    // Use this for initialization
    void Start()
    {
        obtain = player.GetComponent<ObtainingFlowers>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (obtain.flowerCount)
        {
            case 1:
                flower.sprite = one_flower;
                break;
            case 2:
                flower.sprite = two_flower;
                break;
            case 3:
                flower.sprite = three_flower;
                break;
            default:
                break;
        }
    }
}
