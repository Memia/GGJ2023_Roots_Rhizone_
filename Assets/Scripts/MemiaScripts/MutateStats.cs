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
    enum MutationTypes
    {
        Integer,
        SelectIcon,
        OneCharacter,
        ShortString
    }

    
    enum IntegerMutationTypes
    {
        BossHealth,
        PlayerDamage,
        
    }
    enum SelectIconMutationTypes
    {
        Rainy,
        UwUBoss,
        DrUnkAF
    
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

    MutationTypes mutationType;
    IntegerMutationTypes intergerMutationType;
    SelectIconMutationTypes selectIconMutationType;
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

        public void ChangeBossName()
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
        integerUI.SetActive(true);
        int typeCount = MutationTypes.GetValues(typeof(IntegerMutationTypes)).Length - 1;
        intergerMutationType = (IntegerMutationTypes)Random.Range(0, typeCount);

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

        int typeCount = MutationTypes.GetValues(typeof(SelectIconMutationTypes)).Length - 1;
        selectIconMutationType = (SelectIconMutationTypes)Random.Range(0, typeCount);

        switch (selectIconMutationType)
        {
            case SelectIconMutationTypes.Rainy:
                TurnRainy();
                break;
            case SelectIconMutationTypes.UwUBoss:
                BossUwU();

                break;
            case SelectIconMutationTypes.DrUnkAF:
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
    
    public void ChangeKeyMutation()
    {
        int typeCount = MutationTypes.GetValues(typeof(OneCharacterMutationTypes)).Length;
        oneCharacterMutationType = (OneCharacterMutationTypes)Random.Range(0, typeCount);

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
    void DefineShortStringMutation()
    {

        //Display UI
        shortStringUI.SetActive(true);
        int typeCount = MutationTypes.GetValues(typeof(ShortStringMutationTypes)).Length - 1;
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


    public void DefineMutationContent()
    {
        switch (mutationType)
        {
            case MutationTypes.Integer:
                //Display UI for integer mutation
                DefineIntMutation();
                break;
            case MutationTypes.SelectIcon:
                //Display UI for icon mutation
                DefineSelectionIconMutation();
                break;
            case MutationTypes.OneCharacter:
                //Display UI for character mutation
                DefineOneCharacterMutation();
                break;
            case MutationTypes.ShortString:
                //Display UI for string mutation
                DefineShortStringMutation();
                break;
            default:
                break;
        }
        Debug.Log("I've picked ONE!!!");
    }

      
    void SelectMutationType()
    {
        Debug.Log("Picked a type and now picking mutation");
        //Get the number of mutation types
        int typeCount = MutationTypes.GetValues(typeof(MutationTypes)).Length;
        mutationType = (MutationTypes)Random.Range(0, typeCount);
        //Choose one main mutation type
        
        //Choose a specific mutation
        DefineMutationContent();
    }  


    //Display UI

    public void SaveData()
    {
        //  number = int.Parse(input.text.ToString());

    }
    #endregion



    
    public void BeginMutateProcess()
    {
        SelectMutationType();
        Debug.Log("Begin Choosing Type");
        //Select type of mutation
        //Setactive the mutation prompt

    }




}
