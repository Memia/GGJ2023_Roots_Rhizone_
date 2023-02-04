using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float gameTimer;
    public float respawnTimer;

    public GameObject playerObject;
    public GameObject bossObject;
    public PlayerBehaviour playerScript;
    public BossBehaviour bossScript;

    public float floatInput;
    public int intInput;
    void Start()
    {
        playerObject = GameObject.Find("Player");
        playerScript = playerObject.GetComponent<PlayerBehaviour>();
        bossObject = GameObject.Find("Boss");
        bossScript = bossObject.GetComponent<BossBehaviour>();
    }

    
    void Update()
    {
        
    }

    IEnumerator RestartRun()
    {
        //load UI to select mutations
        //apply mutations to game
        //"Spawn" player again
        //new run starts
        yield return null;
    }

    #region Mutation Functions
    //Player and Boss health adjustment
    void AddPlayerHealth()
    {
        playerScript.playerhealth += intInput;
    }
    void MinusPlayerHealth()
    {
        playerScript.playerhealth -= intInput;
    }

    void AddBossHealth()
    {
        bossScript.health += intInput;
    }
    void MinusBossHealth()
    {
        bossScript.health -= intInput;
    }

    //Player and Boss speed adjustment
    void AddPlayerSpeed()
    {
        playerScript.playerSpeed += floatInput;
    }
    void MinusPlayerSpeed()
    {
        playerScript.playerSpeed -= floatInput;
    }
    void AddBossSpeed()
    {
        bossScript.speed += floatInput;
    }
    void MinusBossSpeed()
    {
        bossScript.speed -= floatInput;
    }

    //Boss Size
    void AddBossSize()
    {
        bossObject.transform.localScale += new Vector3(intInput, intInput, intInput);
    }
    void MinusBossSize()
    {
        bossObject.transform.localScale -= new Vector3(intInput, intInput, intInput);
    }

    //Player gravity

    //Boss Shoots Projectiles

    //Spawn multiple bosses
    void SpawnMultipleBosses()
    {
        Instantiate(bossObject);
    }
    #endregion
}
