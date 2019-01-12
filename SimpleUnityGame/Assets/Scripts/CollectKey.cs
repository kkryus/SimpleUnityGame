using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectKey : MonoBehaviour {

    public GameObject key;
    private Transform playerTrans = null;
    void Start()
    {
        playerTrans = GameObject.Find("Player").transform;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Vector3.Distance(playerTrans.position, this.transform.position) < 5f)
            {
                Player.hasKey = true;
                Destroy(key);
            }
        }
    }
}
