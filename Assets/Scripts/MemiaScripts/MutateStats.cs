using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//This script mutates and saves changes to player/boss stats using text mesh pro
public class MutateStats : MonoBehaviour
{
    [SerializeField] TMP_InputField input;
    int number;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void BeginMutateProcess()
    {
        //Setactive the mutation prompt

    }

    public void SaveData()
    {
        number = int.Parse(input.text.ToString());


        MutateHealth();//Tempo for testing purposes, remove or change the code
        
    }

    public void MutateHealth()//Tempo for testing purposes, remove or change the code depending on what suits
    {
        PlayerCharacter.Stats.Health += number;
        Debug.Log(PlayerCharacter.Stats.Health);
    }
    
}
