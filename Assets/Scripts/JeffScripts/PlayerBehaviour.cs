using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CameraShake;


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
    public GameObject gameManager;
    public GameManager GMScript;

    [SerializeField] Animator cameraAnimator;
    // Start is called before the first frame update
    void Start()
    {
        //player = GetComponent<GameObject>();
        boss = GameObject.Find("Boss");
        bossScript = boss.GetComponent<BossBehaviour>();
        gameManager = GameObject.Find("GameManager");
        GMScript = gameManager.GetComponent<GameManager>();

        PlayerCharacter.Stats.isAlive = true;
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
            //print("player is dead");
            GMScript.StartCoroutine("RestartRun");
            PlayerCharacter.Stats.isAlive = false;
            isPlayerAlive = false;
            //play death animation
            //start new "run"
        }
        if(playerhealth > 0)
        {
            isPlayerAlive = true;
        }
    }

    void Attack()
    {
        if(Input.GetMouseButtonDown(0))
        {
            //swing sword
           //  cameraAnimator.SetTrigger("Shake_Slap"); //Screenshake
            //CameraShaker.Presets.ShortShake3D();
            // print("attacking boss");
            if (distFromBoss <= playerAttackRange && playerCanAttack)
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
