using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotesMaker : MonoBehaviour {

    [SerializeField]
    private GameObject StandardNotes;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(StandardNotes, new Vector3(0, 0, 0), Quaternion.identity);
        }
	}
}
