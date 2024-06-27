using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour
{
    public GameObject owner;

   // [SerializeField]
   // private string animationName;

    [SerializeField]
    private bool magicAttack;
    
    [SerializeField]
    private float magicCost;

    [SerializeField]
    private float minAttackMultiplier;

    [SerializeField]
    private float maxAttackMultiplier;

    [SerializeField]
    private float minDefenseMultiplier;

    [SerializeField]
    private float maxDefenseMultiplier;

    private HeartStats attackerStats;
    private HeartStats targetStats;
    private float damage = 0.0f;
    private float xMagicNewScale;
    private Vector2 magicScale;

    private void Start()
    {
        magicScale = GameObject.Find("HeroMagicFill").GetComponent<RectTransform>().localScale;
    }
   
    public void Attack(GameObject victim)
    {
        attackerStats = owner.GetComponent<HeartStats>();
        targetStats = victim.GetComponent<HeartStats>();
        
      if(attackerStats.magic >= magicCost)
      {
          float multiplier = Random.Range(minAttackMultiplier, maxAttackMultiplier);
          
          if (magicCost > 0)
          {  
               attackerStats.updateMagicFill(magicCost);
          }
            
            damage = multiplier * attackerStats.attack;
         
          if(magicAttack)
          {
              damage = multiplier * attackerStats.magic;
              attackerStats.magic -= magicCost;
          }

          float defenseMultiplier = Random.Range(minDefenseMultiplier, maxDefenseMultiplier);
          damage = Mathf.Max(0, damage - (defenseMultiplier * targetStats.defense));
          //owner.GetComponent<Animator>().Play(animationName);
          targetStats.ReceiveDamage(damage);
      }
    }
    
}
