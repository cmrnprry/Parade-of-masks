using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Audio : MonoBehaviour
{

    private GameObject player;
    private PlayerMovement script;

  //  private AudioSource sourceOn;
   // private AudioSource sourceOff;

    public AudioMixerSnapshot slow;
    public AudioMixerSnapshot normal;

  //  public AudioClip maskOn;
//    public AudioClip maskOff;

    public float transtionToSlow;
    public float transtionToNormal;

    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("Player");
        script = player.GetComponent<PlayerMovement>();

       // sourceOn = GetComponent<AudioSource>();
        //sourceOff = GetComponent<AudioSource>();
    }


    // Update is called once per frame
    void Update()
    {
        if (script.isMask)
        {

            slow.TransitionTo(transtionToSlow);
        } else { 

            normal.TransitionTo(transtionToNormal);
        }

       /* if (Input.GetKey(KeyCode.X))
        {
            sourceOn.PlayOneShot(maskOn, 3);

        } else
        {
            sourceOff.PlayOneShot(maskOff, 3f);
        }*/

    }
}
