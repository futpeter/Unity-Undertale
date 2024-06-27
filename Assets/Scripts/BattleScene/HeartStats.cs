using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartStats : MonoBehaviour, IComparable
{
   // [SerializeField]
    //private Animator animator;

    [SerializeField]
    private GameObject healthFill;

    [SerializeField]
    private GameObject magicFill;

    [Header("Stats")]
    public float health;
    public float magic;
    public float attack ;
    public float magicRange;
    public float defense;
    public float speed;
    public float experiance;

    private float startHealth;
    private float startMagic;

    [HideInInspector]
    public int nextActTurn;

    private bool dead = false;

    //Resize health bar and magic bar
    private Transform healthTransform;
    private Transform magicTransform;

    private Vector2 healthScale;
    private Vector2 magicScale;

    private float xNewHealthScale;
    private float xNewMagicScale;

    private GameObject BattleControllerObj;

    void Awake()
    {
        healthTransform = healthFill.GetComponent<RectTransform>();
        healthScale = healthFill.transform.localScale;

        magicTransform = magicFill.GetComponent<RectTransform>();
        magicScale = magicFill.transform.localScale;

        startHealth = health;
        startMagic = magic;

        BattleControllerObj = GameObject.Find("BattleControllerObject");
    }
    [SerializeField]
    public void ReceiveDamage(float damage)
    {
        Debug.Log("Damage Recieved");
        health = health - damage;
        //animator.Play("Damage");

        //Set damage text

        if(health <= 0)
        {
            dead = true;
            gameObject.tag = "Dead";
            Destroy(healthFill);
            Destroy(gameObject);
        }
        else if(damage > 0)
        {
            xNewHealthScale = healthScale.x * (health / startHealth);
            healthFill.transform.localScale = new Vector2(xNewHealthScale, healthScale.y);
        }

        Invoke("ContinueGame", (float)0.00005);
    }

    public void updateMagicFill(float cost)
    {
        if(cost > 0)
        {
            magic = magic - cost;
            xNewMagicScale = magicScale.x * (magic / startMagic);
            magicFill.transform.localScale = new Vector2(xNewMagicScale, magicScale.y);
        }
    }

    public bool GetDead()
    {
        return dead;
    }

    public void ContinueGame()
    {
        GameObject.Find("BattleControllerObject").GetComponent<BattleController>().NextTurn();
    }
    public void CalculateNextTurn(int currentTurn)
    {
        nextActTurn = currentTurn + Mathf.CeilToInt(100f / speed);
    }

    public int CompareTo(object otherStats)
    {
        int nex = nextActTurn.CompareTo(((HeartStats)otherStats).nextActTurn);
        return nex;
    }
    public void TakeDamage(int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
        //UpdateHealthDisplay();
        xNewHealthScale = healthScale.x * (health / startHealth);
        healthFill.transform.localScale = new Vector2(xNewHealthScale, healthScale.y);
    }
}
