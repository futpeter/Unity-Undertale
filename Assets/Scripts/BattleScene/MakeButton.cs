using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MakeButton : MonoBehaviour
{
    [SerializeField]
    private bool physical;

    private GameObject heart;
    // Start is called before the first frame update
    void Start()
    {
        string temp = gameObject.name;
        gameObject.GetComponent<Button>().onClick.AddListener(() => AttachCallback(temp));
        heart = GameObject.FindGameObjectWithTag("Heart");
    }

    private void AttachCallback(string btn)
    {
        if (btn.CompareTo("FightBtn") == 0 )
        {
            heart.GetComponent<FighterAction>().SelectAttack("fight");
        }
        else if (btn.CompareTo("ActBtn") == 0)
        {
            heart.GetComponent<FighterAction>().SelectAttack("act");
        }
        else if (btn.CompareTo("ItemBtn") == 0)
        {
            heart.GetComponent<FighterAction>().SelectAttack("item");
        }
        else if (btn.CompareTo("MercyBtn") == 0)
        {
            heart.GetComponent<FighterAction>().SelectAttack("mercy");
        }
        else
        {
           //Debug.Log("Something dident work fix it lol!!!");
        }
        
    }
}
