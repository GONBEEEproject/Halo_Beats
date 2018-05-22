using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotesTimingMaker : MonoBehaviour {

    private AudioSource _audioSource;

    private float _startTime = 0;

    private CSVWriter _CSVWriter;

    private bool _isPlaying = false;

    public GameObject startButton;

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();

        _CSVWriter = GetComponent<CSVWriter>();
    }

    void Update()
    {
        if (_isPlaying)
        {
            DetectKeys();
        }
    }

    void DetectKeys()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            //くろ
            WriteNotesTiming(0);
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            //しろ
            WriteNotesTiming(1);
        }

    }

    void WriteNotesTiming(int num)
    {
        Debug.Log(GetTiming());
        _CSVWriter.WriteCSV(GetTiming().ToString() + "," + num.ToString());
    }

    float GetTiming()
    {
        return Time.time - _startTime;
    }

    public void StartMusic()
    {
        startButton.SetActive(false);
        _audioSource.Play();
        _startTime = Time.time;
        _isPlaying = true;
    }
}
