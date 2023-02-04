using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public float gameTimer;
    public float respawnTimer;
    public bool canSelectMutation;

    public GameObject playerObject;
    public GameObject bossObject;
    public PlayerBehaviour playerScript;
    public BossBehaviour bossScript;
    public MutationSelectionText mSTextScript;
    public System.Action[] m;

    public TMPro.TMP_Text addPlayerHealthText;
    public TMPro.TMP_InputField addPlayerhealthInput;

    public float floatInput;
    public int intInput;
    void Start()
    {
        playerObject = GameObject.Find("Player");
        playerScript = playerObject.GetComponent<PlayerBehaviour>();
        bossObject = GameObject.Find("Boss");
        bossScript = bossObject.GetComponent<BossBehaviour>();
        mSTextScript = GetComponent<MutationSelectionText>();
    }

    
    void Update()
    {
        
    }

    IEnumerator RestartRun()
    {
        yield return new WaitForSeconds(5f);
        canSelectMutation = true;
        //load random UI to select mutations
        if(canSelectMutation == true)
        {
            System.Action[] mutations = new System.Action[] { AddPlayerHealth,/* MinusPlayerHealth, AddBossHealth, MinusBossHealth, AddPlayerSpeed, MinusPlayerSpeed, AddBossSpeed, MinusBossSpeed */};
            int randomMutation = Random.Range(0, mutations.Length);
            mutations[randomMutation]();
            canSelectMutation = false;
        }
       
        //apply mutations to game
        //"Spawn" player again
        //new run starts
        StopCoroutine("RestartRun");
        yield return null;
       
    }

    #region Mutation Functions
    //Player and Boss health adjustment
    void AddPlayerHealth()
    {
        print("addplayerhealth");
        addPlayerHealthText.gameObject.SetActive(true);
        addPlayerhealthInput.gameObject.SetActive(true);
        
        playerScript.isPlayerAlive = true;
        playerScript.playerhealth += int.Parse(addPlayerhealthInput.text);
        canSelectMutation = false;
        StopCoroutine("RestartRun");
        //playerScript.playerhealth += intInput;
    }
    void MinusPlayerHealth()
    {
        print("minusplayerhealth");
        playerScript.isPlayerAlive = true;
        playerScript.playerhealth += 20;
        canSelectMutation = false;
        StopCoroutine("RestartRun");
        //playerScript.playerhealth -= intInput;
    }

    void AddBossHealth()
    {
        print("addbosshealth");
        playerScript.isPlayerAlive = true;
        playerScript.playerhealth += 20;
        canSelectMutation = false;
        StopCoroutine("RestartRun");
        //bossScript.health += intInput;
    }
    void MinusBossHealth()
    {
        print("minusbosshealth");
        playerScript.isPlayerAlive = true;
        playerScript.playerhealth += 20;
        canSelectMutation = false;
        StopCoroutine("RestartRun");
        //bossScript.health -= intInput;
    }

    //Player and Boss speed adjustment
    void AddPlayerSpeed()
    {
        print("addplayerspeed");
        playerScript.isPlayerAlive = true;
        playerScript.playerhealth += 20;
        canSelectMutation = false;
        StopCoroutine("RestartRun");
        //playerScript.playerSpeed += floatInput;
    }
    void MinusPlayerSpeed()
    {
        print("minusplayerspeed");
        playerScript.isPlayerAlive = true;
        playerScript.playerhealth += 20;
        canSelectMutation = false;
        StopCoroutine("RestartRun");
        //playerScript.playerSpeed -= floatInput;
    }
    void AddBossSpeed()
    {
        print("addbossspeed");
        playerScript.isPlayerAlive = true;
        playerScript.playerhealth += 20;
        canSelectMutation = false;
        StopCoroutine("RestartRun");
        //bossScript.speed += floatInput;
    }
    void MinusBossSpeed()
    {
        print("minusbossspeed");
        playerScript.isPlayerAlive = true;
        playerScript.playerhealth += 20;
        canSelectMutation = false;
        StopCoroutine("RestartRun");
        //bossScript.speed -= floatInput;
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
