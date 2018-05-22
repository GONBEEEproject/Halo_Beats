using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class CSVLoader : MonoBehaviour {

    [SerializeField]
    private GameObject[] notes;

    private float[] timing = new float[1024];
    private int[] noteType = new int[1024];

    [SerializeField]
    private string filePass;
    private int notesCount = 0;

    private AudioSource AS;

    private float startTime = 0;

    
    public float timeOffset = -1.0f;

    private bool isPlaying = false;

	// Use this for initialization
	void Start() {
        LoadCSV();
        AS = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        if (isPlaying)
        {
            CheckNextNotes();
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                StartGame();
            }
        }
	}

    void StartGame()
    {
        startTime = Time.time;
        AS.Play();
        isPlaying = true;
    }

    void CheckNextNotes()
    {
        while (timing[notesCount] + timeOffset < GetMusicTime() && timing[notesCount] != 0)
        {
            SpawnNotes(noteType[notesCount]);
            notesCount++;
        }
    }

    void SpawnNotes(int type)
    {
        Instantiate(notes[type], new Vector3(0, 0, 0), Quaternion.identity);
    }

    float GetMusicTime()
    {
        return Time.time - startTime;
    }

    void LoadCSV()
    {
        int i = 0, j;

        TextAsset csv = Resources.Load(filePass) as TextAsset;

        StringReader reader = new StringReader(csv.text);

        while (reader.Peek() > -1)
        {
            string line = reader.ReadLine();
            string[] values = line.Split(',');

            for (j = 0; j < values.Length; j++)
            {
                timing[i] = float.Parse(values[0]);
                noteType[i] = int.Parse(values[1]);
            }
            i++;
        }
    }
}
