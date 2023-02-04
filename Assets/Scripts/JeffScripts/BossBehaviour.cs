using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehaviour : MonoBehaviour
{
    public float speed;
    public int health;
    public int damage;
    public float attackRange;
    public float attackCooldown = 3f;
    public bool attackIsOnCooldown = false;
    public float distBetweenPlayer;
    public GameObject boss;
    public Rigidbody bossRB;
    public Animator bossAnim;

    //public bool isPlayerAlive;
    public GameObject player;
    public PlayerBehaviour pBScript;
    

    //Sound
    [SerializeField] AudioClip[] crabSounds;
    // Start is called before the first frame update
    void Start()
    {
        //boss = gameObject.GetComponent<GameObject>();
        player = GameObject.Find("Player");
        pBScript = player.GetComponent<PlayerBehaviour>();
        bossRB = GetComponent<Rigidbody>();
        bossAnim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //bossRB.constraints = RigidbodyConstraints.FreezeRotationX;
        //bossRB.constraints = RigidbodyConstraints.FreezeRotationZ;
        if (pBScript.isPlayerAlive == true)
        {
            ChasePlayer();
        }
        else if(pBScript.isPlayerAlive == false)
        {
            StartCoroutine(LookforPrey());
        }
        Die();
    }

    IEnumerator LookforPrey()
    {
        //start moving away from player
        print("looking for prey");
        //move away from player death game object
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, -(speed * Time.deltaTime));
        yield return new WaitForSeconds(10f);
        
    }

    void ChasePlayer()
    {
        transform.LookAt(player.transform);

        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);

        distBetweenPlayer = Vector3.Distance(boss.transform.position, player.transform.position);
        //if cooldown inactive and if in range, AttackPlayer(); coroutine start
        if (attackIsOnCooldown == false && distBetweenPlayer <= attackRange)
        {
            print("Player is in range");
            StartCoroutine(AttackPlayer());
        }
    }

    IEnumerator AttackPlayer()
    {
        print("attacking player");
        bossAnim.Play("Armature|Attack_1");
        pBScript.playerhealth -= 10;
        attackIsOnCooldown = true;
        yield return new WaitForSeconds(attackCooldown);
        attackIsOnCooldown = false;
    }

    void Die()
    {
        if(health <= 0)
        {
            print("boss is dead");
            Destroy(this.gameObject);
        }
    }
}
