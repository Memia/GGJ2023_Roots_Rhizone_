using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagement : MonoBehaviour
{
    [SerializeField] MutateStats mutateStats;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerCharacter.Stats.isAlive == false)
        {
            mutateStats.BeginMutateProcess();
        }

        //DELETE THIS
        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartGame();
        }

    }   
    
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
