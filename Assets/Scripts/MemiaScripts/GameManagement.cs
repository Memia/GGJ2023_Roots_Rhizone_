using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManagement : MonoBehaviour
{
    [SerializeField] MutateStats mutateStats;
    [SerializeField] TextMeshProUGUI bossName;
    string nameVar;
    bool mutated;

    float timer = 1;
    // Start is called before the first frame update
    void Start()
    {


        nameVar = bossName.text;
        if (BossCharacter.Stats.Name == null)
        {
            BossCharacter.Stats.Name = nameVar;
            Debug.Log(BossCharacter.Stats.Name);
        }
        else
        {
            bossName.text = BossCharacter.Stats.Name;
        }
            

       // SetBossName();


    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerCharacter.Stats.isAlive == false)
        {
            timer -= Time.deltaTime;
            if (!mutated && timer <= 0)
            {
                Cursor.lockState = CursorLockMode.None;
                mutateStats.BeginMutateProcess();
                mutated = true;
            }
        }


    }   
    
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void SetBossName()
    {
 
        nameVar = BossCharacter.Stats.Name;
        bossName.text = nameVar;
    }
}
