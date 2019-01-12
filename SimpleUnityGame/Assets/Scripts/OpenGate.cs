using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenGate : MonoBehaviour
{
    private float animationSpeed = 2.5f;
    public GameObject player;
    private Transform playerTransform;

    public AudioSource audioSource;
    public AudioClip gateOpeningClip;

    void Start()
    {
        playerTransform = player.transform;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Vector3.Distance(playerTransform.position, this.transform.position) < 5f)
            {
                StartCoroutine(MoveGate());
            }
        }
    }

    public IEnumerator MoveGate()
    {
        audioSource.PlayOneShot(gateOpeningClip);
        while (transform.localPosition.y > 16.35)
        {
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y - Time.deltaTime * animationSpeed, transform.localPosition.z);
            yield return null;
        }
    }
}


