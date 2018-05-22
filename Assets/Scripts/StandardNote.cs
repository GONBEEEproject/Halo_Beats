using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardNote : MonoBehaviour {

    //[SerializeField]
    private float rotateY;

    private CSVLoader csvl;

    [SerializeField]
    private Collider triggerSphere;

    [SerializeField]
    private AudioClip AC;

    public void Hit()
    {
        AudioManager.Instance.PlaySE(AC);
        Destroy(this.gameObject);
    }




	// Use this for initialization
	void Start () {
        Invoke("TriggerEnabler", 1.0f);
        csvl = GameObject.Find("GameManager").GetComponent<CSVLoader>();
        rotateY = 360 / csvl.timeOffset;
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(0, rotateY * Time.deltaTime, 0);
    }


    void TriggerEnabler()
    {
        triggerSphere.enabled = true;
    }


    private void OnTriggerExit(Collider other)
    {
        Destroy(gameObject);
    }


}
