using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public bool isStart;
    public bool isQuit;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonUp(0))
        {
            Mouse();
        }
	}

    private void Mouse()
    {
        
        if (isQuit)
        {
            Debug.Log("okooo");
            Application.Quit();
        }
        if (isStart)
        {
            Debug.Log("2222");
            SceneManager.LoadScene("SampleScene");
        }  
    }
}
