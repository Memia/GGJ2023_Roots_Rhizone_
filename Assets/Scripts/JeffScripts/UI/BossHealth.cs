using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BossHealth : MonoBehaviour
{
    public TMP_Text healthText;
    public TMP_Text nameText;

    public GameObject boss;
    public BossBehaviour bossScript;
    
    // Start is called before the first frame update
    void Start()
    {
        boss = GameObject.Find("Boss");
        bossScript = boss.gameObject.GetComponent<BossBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = "HP:    " + bossScript.health.ToString();
        if(bossScript.health <= 0)
        {
            healthText.text = "HP:    0";
        }
    }
}
