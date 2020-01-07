using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour {

    private bool paused = false;
    private bool victory=  true;

    private AudioSource music;

    public AudioClip backgroundMusic;
    public AudioClip victoryMusic;
    public GameObject panel; 


    void Awake()
    {
        music = GetComponent<AudioSource>();
        music.clip = backgroundMusic;
        music.Play();
    }

    // Update is called once per frame
    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(paused)
            {
                Time.timeScale = 1;
                AudioListener.pause = false;
                panel.SetActive(false);
                
            }
            else
            {
                Time.timeScale = 0;
                AudioListener.pause = true;
                panel.SetActive(true);
            }
            paused = !paused;
            
        }

        if(PlayerMovement.count >= 24 && victory)
        {
            music.clip = victoryMusic;
            music.Play();
            victory = false;
        }
	}
}
