using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieBehaviour : MonoBehaviour
{

    private Animator thisAnim;

    private Transform playerTrans = null;
    void Start()
    {
        playerTrans = GameObject.Find("Player").transform;
        thisAnim = GetComponent<Animator>();
    }
    void Update()
    {
        Debug.Log(Vector3.Distance(playerTrans.position, this.transform.position));
        Debug.Log(Vector3.Distance(playerTrans.position, this.transform.position) > 1.5f);
        //Calculate distance between player and door
        if (Vector3.Distance(playerTrans.position, this.transform.position) < 25f && Vector3.Distance(playerTrans.position, this.transform.position) > 1.72f)
        {
            Vector3 targetDir = playerTrans.position - transform.position;
           // targetDir.y = 0.1f;

            // The step size is equal to speed times frame time.
            float step = 2.0f * Time.deltaTime;

            Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0f);
            Debug.DrawRay(transform.position, newDir, Color.red);

            // Move our position a step closer to the target.
            transform.rotation = Quaternion.LookRotation(newDir);

            var tmpPos = playerTrans.position;
            tmpPos.y = 0.3f;

            // Move our position a step closer to the target.
             this.transform.position = Vector3.MoveTowards(this.transform.position, tmpPos, step);
           // this.transform.position = Vector3.MoveTowards(this.transform.position, playerTrans.position, step);
            transform.position = new Vector3(transform.position.x, 0.3f, transform.position.z);
        }
        if(Vector3.Distance(playerTrans.position, this.transform.position) < 1.72f)
        {
            thisAnim.SetBool("isAttacking", true);
        }
        else
        {
            thisAnim.SetBool("isAttacking", false);
        }
        if(Time.deltaTime > 20f)
        {
            thisAnim.SetBool("isDead", true);
        }
    }
}
