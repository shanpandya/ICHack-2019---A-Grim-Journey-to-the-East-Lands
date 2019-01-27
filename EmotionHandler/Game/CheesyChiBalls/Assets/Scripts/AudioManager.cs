using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
       AudioSource audio =  GameObject.FindGameObjectWithTag("StartMusic").GetComponent<AudioSource>();
        audio.Play();
        UnityEngine.Debug.Log("QAudioi Play");
	}
	
	// Update is called once per frame
	void Update () {
        
	}
    public void playLevelMusic(int Level)
    {
        if(Level == 2)
        {
            AudioSource audio2 = GameObject.FindGameObjectWithTag("SadnessMusic").GetComponent<AudioSource>();
            audio2.Play();
        }
        if(Level == 3)
        {
            AudioSource audio3 = GameObject.FindGameObjectWithTag("AngerMusic").GetComponent<AudioSource>();
            audio3.Play();
        }
        if(Level == 4)
        {
            AudioSource audio4 = GameObject.FindGameObjectWithTag("FinalLevel").GetComponent<AudioSource>();
            audio4.Play();
        }
        if (Level == 5)
        {
            AudioSource audio5 = GameObject.FindGameObjectWithTag("EndingMusic").GetComponent<AudioSource>();
            audio5.Play();
        }
    }
}
