using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public int playerhealth;
    public int playerDamage;
    public float playerAttackRange;
    public float playerSpeed;
    public float playerAttackCooldown;
    public bool playerCanAttack = true;
    public bool isPlayerAlive = true;
    public float distFromBoss;

    public GameObject player;
    public GameObject boss;
    public BossBehaviour bossScript;

    // Start is called before the first frame update
    void Start()
    {
        //player = GetComponent<GameObject>();
        boss = GameObject.Find("Boss");
        bossScript = boss.GetComponent<BossBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        distFromBoss = Vector3.Distance(player.transform.position, boss.transform.position);
        CheckIfDead();
        Attack();
    }

    void CheckIfDead()
    {
        if(playerhealth <= 0)
        {
            print("player is dead");
            isPlayerAlive = false;
            //play death animation
            //start new "run"
        }
    }

    void Attack()
    {
        if(Input.GetMouseButtonDown(0))
        {
            //swing sword
            print("attacking boss");
            if(distFromBoss <= playerAttackRange && playerCanAttack)
            {
                StartCoroutine(DamageBoss());
            }
        }
    }

    IEnumerator DamageBoss ()
    {
        playerCanAttack = false;
        print("damaged boss");
        bossScript.health -= playerDamage;
        yield return new WaitForSeconds(playerAttackCooldown);
        playerCanAttack = true;
    }
}
