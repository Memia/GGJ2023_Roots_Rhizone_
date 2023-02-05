using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManagement : MonoBehaviour
{
    public float gameTimer;
    public float timeScore;

    public TMP_Text scoreText;
    public TMP_InputField nameInput;

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
        /*if (PlayerCharacter.Stats.isAlive == false)
        {
            timer -= Time.deltaTime;
            if (!mutated && timer <= 0)
            {
                Cursor.lockState = CursorLockMode.None;
                mutateStats.BeginMutateProcess();
                mutated = true;
            }
        }*/ //un-comment this code when ready to hook-up mutations

        gameTimer += Time.deltaTime;
        
    }   
    
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Cursor.lockState = CursorLockMode.Locked;
    }

<<<<<<< HEAD
    public void SetBossName()
    {
 
        nameVar = BossCharacter.Stats.Name;
        bossName.text = nameVar;
=======
    public void StopTimer()
    {
        scoreText.gameObject.SetActive(true);
        nameInput.gameObject.SetActive(true);
        timeScore = gameTimer;
        scoreText.text = "You Win!   Time:   " + timeScore;
>>>>>>> origin/main
    }
}
