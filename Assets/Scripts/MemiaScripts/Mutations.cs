using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mutations : MonoBehaviour
{
    public static Mutations Stats;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


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
