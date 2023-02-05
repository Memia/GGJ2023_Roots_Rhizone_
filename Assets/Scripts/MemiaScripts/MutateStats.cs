using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//This script mutates and saves changes to player/boss stats using text mesh pro
public class MutateStats : MonoBehaviour
{
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



    void SelectMutationType()
    {
        //Get the number of mutation types
        int typeCount = MutationTypes.GetValues(typeof(MutationTypes)).Length -1;
        mutationType = (MutationTypes)Random.Range(0, typeCount);
    }




    #region Define Mutation Content
    #region Mutations
    //Int mutations
    void MutateBossHealth()
    {
        
        BossCharacter.Stats.Health += int.Parse(input.text);
        
    }

    void MutatePlayerDamage()
    {
        PlayerCharacter.Stats.Damage = int.Parse(input.text);

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
    //Letter mutations
    void ChangeUpKey()
    {

    }

    void ChangeDownKey()
    {

    }

    void ChangeLeftKey()
    { }

    void ChangeRightKey()
    { }
     
    void ChangeBossName()
    { }
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
        int typeCount = MutationTypes.GetValues(typeof(OneCharacterMutationTypes)).Length - 1;
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
                ChangeBossName();
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
        //Display UI
    }
    #endregion

    public void SaveData()
    {
      //  number = int.Parse(input.text.ToString());
      
    }

    public void BeginMutateProcess()
    {
        SelectMutationType();
        //Select type of mutation
        //Setactive the mutation prompt
        DefineMutationContent();
    }

}
