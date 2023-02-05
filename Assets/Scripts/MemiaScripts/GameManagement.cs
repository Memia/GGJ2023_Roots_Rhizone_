using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagement : MonoBehaviour
{
    [SerializeField] MutateStats mutateStats;
    bool mutated;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerCharacter.Stats.isAlive == false)
        {
            if (!mutated)
            {
                mutateStats.BeginMutateProcess();
                mutated = true;
            }
        }


    }   
    
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
