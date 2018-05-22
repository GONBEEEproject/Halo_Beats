using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    private static AudioManager instance;
    public static AudioManager Instance
    {
        get
        {
            if (instance == null)
                instance = FindObjectOfType<AudioManager>();
            return instance;
        }
    }


    private AudioSource AS;

    public void PlaySE(AudioClip AC)
    {
        AS.PlayOneShot(AC);
    }




	// Use this for initialization
	void Start () {
        AS = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
