using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BPMBasedNotesMaker : MonoBehaviour {


    //プレイ中かどうか
    private bool _isPlaying;

    //生成するノーツ
    [SerializeField]
    private GameObject StandardNote_Black;
    [SerializeField]
    private GameObject StandardNote_White;

    private bool isBlack;

    //曲タイミング
    [SerializeField]
    private int BPM;
    [SerializeField]
    private int Beat;

    //
    private float beatTime;
    private float nextBeat;

    //ノーツ生成用変数達
    private float presetInstantiateTime;
    private float nextInstantiate;

    //メトロノーム用
    //[SerializeField]
    private AudioSource AS;



	// Use this for initialization
	void Start () {
        presetInstantiateTime = (60.0f / BPM)*Beat;
        nextBeat = 60.0f / BPM;
        AS = GetComponent<AudioSource>();

        isBlack = true;

	}
	
	// Update is called once per frame
	void Update () {
        nextInstantiate += Time.deltaTime;
        beatTime += Time.deltaTime;

        if (nextInstantiate > presetInstantiateTime)
        {
            MakeNotes();
            nextInstantiate = 0;
        }

        if (beatTime > nextBeat)
        {
            AS.PlayOneShot(AS.clip);
            beatTime = 0;
        }

        if (_isPlaying)
        {
            CheckNextNotes();
        }

	}

    void CheckNextNotes()
    {
        
    }

    void MakeNotes()
    {
        if (isBlack)
        {
            Instantiate(StandardNote_Black, new Vector3(0, 0, 0), Quaternion.identity);
        }
        else
        {
            Instantiate(StandardNote_White, new Vector3(0, 0, 0), Quaternion.identity);
        }


        isBlack =! isBlack;

    
    }

    

}
