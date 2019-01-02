using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ZombieBehaviour : MonoBehaviour
{
    public int life = 20;
    private Animator thisAnim;

    private Transform playerTrans = null;
    void Start()
    {
        playerTrans = GameObject.Find("Player").transform;
        thisAnim = GetComponent<Animator>();
    }
    void Update()
    {
        //Calculate distance between player and door
        if (Vector3.Distance(playerTrans.position, this.transform.position) < 25f && Vector3.Distance(playerTrans.position, this.transform.position) > 1.72f && life > 0)
        {
            float step = 2.0f * Time.deltaTime;
            Vector3 targetDir = playerTrans.position - transform.position;
            targetDir.y = 0.3f;

            // The step size is equal to speed times frame time.
            

            Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0f);
            Debug.DrawRay(transform.position, newDir, Color.red);

            // Move our position a step closer to the target.
            transform.rotation = Quaternion.LookRotation(newDir);
            /* */
             var tmpPos = playerTrans.position;
             tmpPos.y = 0.2f;

             // Move our position a step closer to the target.
             this.transform.position = Vector3.MoveTowards(this.transform.position, tmpPos, step);
            // this.transform.position = Vector3.MoveTowards(this.transform.position, playerTrans.position, step);
             transform.position = new Vector3(transform.position.x, 0.2f, transform.position.z); //*/
        }
        if (Vector3.Distance(playerTrans.position, this.transform.position) < 2f && life > 0)
        {
            thisAnim.SetBool("isAttacking", true);
            Player.life -= 1;
            if(Player.life <= 0)
            {
                SceneManager.LoadScene(0);
            }
        }
        else
        {
            thisAnim.SetBool("isAttacking", false);
        }
        if(life <= 0)
        {
            thisAnim.SetBool("isDead", true);
        }
    }

    public void ChangeHealth(int dmg)
    {
        life += dmg;
        if(life <= 0)
        {
            thisAnim.SetBool("isDead", true);
        }
    }
}
