using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class FinishGame : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(Wait(4.0f));
    }



    IEnumerator Wait(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene(3);
    }
}
