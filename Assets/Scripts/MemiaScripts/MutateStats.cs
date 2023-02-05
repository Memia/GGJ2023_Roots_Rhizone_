using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//This script mutates and saves changes to player/boss stats using text mesh pro
public class MutateStats : MonoBehaviour
{

    [SerializeField] GameManagement gameManager;
    [SerializeField] TMP_InputField input;

    #region Display UI
    [SerializeField] GameObject integerUI;
    [SerializeField] GameObject selectIconUI;
    [SerializeField] GameObject oneCharacterUI;
    [SerializeField] GameObject shortStringUI;
    #endregion
    int number;

    #region Mutation Types
    enum InputMutationTypes
    {
        Integer,
        OneCharacter,
        ShortString
    }

    enum IconMutationTypes
    {
        Rainy,
        UwUBoss,
        DrUnkAF
    }


    enum IntegerMutationTypes
    {
        BossHealth,
        PlayerDamage,
        
    }

    enum OneCharacterMutationTypes
    {
        MovementUp,
        MovementDown,
        MovementLeft,
        MovementRight
    }
    enum ShortStringMutationTypes
    {
        BossName
    }

    InputMutationTypes inputMutationType;
    IconMutationTypes iconMutationType;
    
    IntegerMutationTypes intergerMutationType;
    OneCharacterMutationTypes oneCharacterMutationType;
    ShortStringMutationTypes shortStringMutationType;
    #endregion

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    #region Define Mutation Content
    #region Mutations
    //Int mutations
    void MutateBossHealth()
    {

        integerUI.SetActive(true);

    }

    public void ChangeBossHealth()
    {
        string var = integerUI.GetComponentInChildren<TMP_InputField>().text;
        BossCharacter.Stats.Health += int.Parse(var);
        
        // BossCharacter.Stats.Health += int.Parse(integerUI.GetComponentInChildren<TMP_InputField>().text.ToString());
    }
    void MutatePlayerDamage()
    {

        integerUI.SetActive(true);
       
    }

    public void ChangePlayerDamage()
    {
        PlayerCharacter.Stats.Damage = int.Parse(integerUI.GetComponentInChildren<TMP_InputField>().text.ToString());
        Debug.Log(PlayerCharacter.Stats.Health);
    }

        //Icon mutations
        void TurnRainy()
    {

    }

    void BossUwU()
    {

    }

    void SoDrunk()
    {

    }
   // [SerializeField] private InputActionReference _movement;
    //Letter mutations
    void ChangeUpKey()
    {
        char letter = oneCharacterUI.GetComponentInChildren<TMP_InputField>().text[0];
    }

    void ChangeDownKey()
    {
        char letter = oneCharacterUI.GetComponentInChildren<TMP_InputField>().text[0];
    }

    void ChangeLeftKey()
    {
        char letter = oneCharacterUI.GetComponentInChildren<TMP_InputField>().text[0];
    }

    void ChangeRightKey()
    {
        char letter = oneCharacterUI.GetComponentInChildren<TMP_InputField>().text[0];
    }

     void ChangeBossName()
    {
        string newName = shortStringUI.GetComponentInChildren<TMP_InputField>().text;
        BossCharacter.Stats.Name = newName;
        //Debug.Log(BossCharacter.Stats.Name);
        gameManager.SetBossName();
        

    }
    //String mutations

    #endregion

    void DefineIntMutation()
    {
        //Display the int input UI panel
        integerUI.SetActive(true);
        //Select a random mutation type that is affected by int
        int typeCount = InputMutationTypes.GetValues(typeof(IntegerMutationTypes)).Length - 1;
        intergerMutationType = (IntegerMutationTypes)Random.Range(0, typeCount);



    }

    void IntMutate()
    {
        //Trigger the functionality based on the current mutation type
        switch (intergerMutationType)
        {
            case IntegerMutationTypes.BossHealth:
                MutateBossHealth();
                break;
            case IntegerMutationTypes.PlayerDamage:
                MutatePlayerDamage();
                break;
            default:
                break;
        }
    }
    
    void DefineSelectionIconMutation()
    {
        //Display UI: Choose 2 of the 3 icons and set them as display
        selectIconUI.SetActive(true);

        int typeCount = InputMutationTypes.GetValues(typeof(IconMutationTypes)).Length - 1;
        iconMutationType = (IconMutationTypes)Random.Range(0, typeCount);

        //Trigger the functionality based on the current mutation type
        switch (iconMutationType)
        {
            case IconMutationTypes.Rainy:
                TurnRainy();
                break;
            case IconMutationTypes.UwUBoss:
                BossUwU();

                break;
            case IconMutationTypes.DrUnkAF:
                SoDrunk();
                break;
            default:
                break;
        }

    }
    

    void DefineOneCharacterMutation()
    {
        //Display UI: 
        oneCharacterUI.SetActive(true);
    }
    void CharMutate() //Choose which control to mutate
    {
        switch (oneCharacterMutationType)
        {
            case OneCharacterMutationTypes.MovementUp:
                ChangeUpKey();
                //Change in scene WASD display accordingly
                break;
            case OneCharacterMutationTypes.MovementDown:
                ChangeDownKey();
                //Change in scene WASD display accordingly
                break;
            case OneCharacterMutationTypes.MovementLeft:
                ChangeLeftKey();
                //Change in scene WASD display accordingly
                break;
            case OneCharacterMutationTypes.MovementRight:
                ChangeRightKey();
                //Change in scene WASD display accordingly
                break;
            default:
                break;
        }
    }
    void ChangeKeyMutation() //Execute mutation
    {
        int typeCount = InputMutationTypes.GetValues(typeof(OneCharacterMutationTypes)).Length;
        oneCharacterMutationType = (OneCharacterMutationTypes)Random.Range(0, typeCount);


    }

    void DefineShortStringMutation()
    {

        //Display UI
        shortStringUI.SetActive(true);
        int typeCount = InputMutationTypes.GetValues(typeof(ShortStringMutationTypes)).Length - 1;
        shortStringMutationType = (ShortStringMutationTypes)Random.Range(0, typeCount);
        switch (shortStringMutationType)
        {
            case ShortStringMutationTypes.BossName:
                shortStringUI.SetActive(true);
                break;
            default:
                break;
        }

    }


    public void SelectInputMutateType()
    {
        switch (inputMutationType)
        {
            case InputMutationTypes.Integer:
                //Display UI for integer mutation
                DefineIntMutation();
                break;
            case InputMutationTypes.OneCharacter:
                //Display UI for character mutation
                DefineOneCharacterMutation();
                break;
            case InputMutationTypes.ShortString:
                //Display UI for string mutation
                DefineShortStringMutation();
                break;
            default:
                break;
        }

    }

    void SelectIconMutateType() 
    { 
        //Change this code, it needs to choose 2 from the pool of the icons
        switch(iconMutationType)
        {
            case IconMutationTypes.Rainy:
                break;
            case IconMutationTypes.UwUBoss:
                break;
            case IconMutationTypes.DrUnkAF:
                break;
            default:
                break;
                
        }
    
    }

    //Select either input type of mutation or icon type of mutation as the next step in mutation
    void SelectMutationType()
    {
        //A quick and dirty way to randomly select the type of mutation      Delete or change this randomizer as needed
        int randomizer = 0;//Random.Range(0, 1);
        if (randomizer == 0)
        {
            int typeCount = InputMutationTypes.GetValues(typeof(InputMutationTypes)).Length;
            inputMutationType = (InputMutationTypes)Random.Range(0, typeCount);
            SelectInputMutateType();
        
        }
        else
        {
            SelectIconMutateType();
        }
        
        Debug.Log("Picked a type and now picking mutation");
        //Get the number of mutation types

        //Choose one main mutation type
        
        
    }  


    //Display UI

    public void SaveData()
    {
        //  number = int.Parse(input.text.ToString());

    }
    #endregion


    public void InputMutate()
    {
        switch (inputMutationType)
        {
            case (InputMutationTypes.Integer):            
            IntMutate();
                break;
            case (InputMutationTypes.OneCharacter):
                CharMutate();
                break;
            case (InputMutationTypes.ShortString):
                ChangeBossName(); //this is spaghetti, change or delete later!
                break;
            default:
                break;
                
    }
        }

    public void BeginMutateProcess()
    {
        SelectMutationType();
        //Select type of mutation
        //Setactive the mutation prompt

    }
}






