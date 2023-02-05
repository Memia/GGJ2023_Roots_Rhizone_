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
    bool mutated;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        /*if (PlayerCharacter.Stats.isAlive == false)
        {
            if (!mutated)
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

    public void StopTimer()
    {
        scoreText.gameObject.SetActive(true);
        nameInput.gameObject.SetActive(true);
        timeScore = gameTimer;
        scoreText.text = "You Win!   Time:   " + timeScore;
    }
}
