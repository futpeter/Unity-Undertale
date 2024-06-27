using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FighterAction : MonoBehaviour
{
    private GameObject enemy;
    private GameObject heart;

    [SerializeField]
    private GameObject fightPrefab;

    [SerializeField]
    private GameObject actPrefab;

    [SerializeField]
    private GameObject itemPrefab;

    [SerializeField]
    private GameObject mercyPrefab;

    [SerializeField]
    private GameObject faceIcon;

    private GameObject currentAttack;

    private GameObject actOption;
    private GameObject itemOption;
    private GameObject mercyOption;

    void Start()
    {
        heart = GameObject.FindGameObjectWithTag("Heart");
        enemy = GameObject.FindGameObjectWithTag("Enemy");
    }

    public void SelectAttack(string btn)
    {
        GameObject victim = heart;
        if (tag == "Heart")
        {
            victim = enemy;
        }
        if (btn.CompareTo("fight") == 0)
        {
            fightPrefab.GetComponent<AttackScript>().Attack(victim);
        }
        else if (btn.CompareTo("act") == 0)
        {
            Debug.Log("Heart Makes Act");
        }
        else if (btn.CompareTo("item") == 0)
        {
            Debug.Log("Heart Makes Item");
        }
        else if (btn.CompareTo("mercy") == 0)
        {
            Debug.Log("Heart Makes Mercy");
        }

    }
  
}
