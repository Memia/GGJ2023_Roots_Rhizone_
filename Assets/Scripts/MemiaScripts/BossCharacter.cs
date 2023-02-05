using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCharacter : MonoBehaviour
{
    public static BossCharacter Stats { get;  set; }
    public int Health { get;  set; }
    public int Damage { get;  set; }
    
    public string Name { get;  set; }
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
