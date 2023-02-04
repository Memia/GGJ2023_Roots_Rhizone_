using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    public static PlayerCharacter Stats { get; private set; }
    public int Health { set; get; }
    public int Damage { set; get; }
    public int Speed { set; get; }
    public bool isAlive { set; get; }

    private void Awake()
    {
        if (Stats == null)
        {
            Stats = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

}
