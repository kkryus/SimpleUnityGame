using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ZombieBehaviour : MonoBehaviour
{
    public int life = 10;
    private Animator thisAnim;

    private Transform playerTrans = null;
    void Start()
    {
        playerTrans = GameObject.Find("Player").transform;
        thisAnim = GetComponent<Animator>();
    }
    void Update()
    {
        if ((Vector3.Distance(playerTrans.position, this.transform.position) < 30f && life > 0) || (life < 20 && life > 0) && Vector3.Distance(playerTrans.position, this.transform.position) > 1.72f)
        {
            float step = 2.0f * Time.deltaTime;
            Vector3 targetDir = playerTrans.position - transform.position;
            targetDir.y = 0.3f;

            Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0f);

            transform.rotation = Quaternion.LookRotation(newDir);
            var tmpPos = playerTrans.position;
            tmpPos.y = 0.2f;

            this.transform.position = Vector3.MoveTowards(this.transform.position, tmpPos, step);
            transform.position = new Vector3(transform.position.x, 0.2f, transform.position.z);
        }
        if (Vector3.Distance(playerTrans.position, this.transform.position) < 2f && life > 0)
        {
            thisAnim.SetBool("isAttacking", true);
            Player.life -= 1;
            if (Player.life <= 0)
            {
                SceneManager.LoadScene(2);
            }
        }
        else
        {
            thisAnim.SetBool("isAttacking", false);
        }
    }

    public void ChangeHealth(int dmg)
    {
        life += dmg;
        if (life <= 0)
        {
            thisAnim.SetBool("isDead", true);
        }
    }
}
