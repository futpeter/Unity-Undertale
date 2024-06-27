using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Transactions;
using UnityEngine.SocialPlatforms;
using UnityEditor.Experimental.GraphView;

public class BattleController : MonoBehaviour
{ 
    //enemy spawners able to spawn add as many as u like
    public EnemySpawner enemySpawner0;
    public EnemySpawner enemySpawner1;
    public EnemySpawner enemySpawner2;
    public EnemySpawner enemySpawner3;
    public EnemySpawner enemySpawner4;
    public EnemySpawner enemySpawner5;

    public Animator animatorAtk1Obj1;

    public int xEnemyRandomAttack = 9;

    private List<HeartStats> fighterStats;

    [SerializeField]
    public GameObject battleMenu;

    public Text battleText;

    private void Awake()
    {
        battleMenu = GameObject.Find("ActionMenu");
    }

    void Start()
    {
        fighterStats = new List<HeartStats>();
        GameObject heart = GameObject.FindGameObjectWithTag("Heart");
        HeartStats currentFighterStats = heart.GetComponent<HeartStats>();
        currentFighterStats.CalculateNextTurn(0);
        fighterStats.Add(currentFighterStats);

        GameObject enemy = GameObject.FindGameObjectWithTag("Enemy");
        HeartStats currentEnemyStats = enemy.GetComponent<HeartStats>();
        currentEnemyStats.CalculateNextTurn(0);
        fighterStats.Add(currentEnemyStats);

        fighterStats.Sort();
        this.battleMenu.SetActive(false);

        fighterStats.Sort();

        NextTurn();
    }

    

    // Update is called once per frame
    public void NextTurn()
    {
        HeartStats currentFighterStats = fighterStats[0];
        fighterStats.Remove(currentFighterStats);
        if (!currentFighterStats.GetDead())
        {
            GameObject currentUnit = currentFighterStats.gameObject;
            currentFighterStats.CalculateNextTurn(currentFighterStats.nextActTurn);
            fighterStats.Add(currentFighterStats);
            fighterStats.Sort();
            if(currentUnit.tag == "Heart") 
            {
                //remember to add this here
                enemySpawner0.enemyCanSpawn = false;
                enemySpawner1.enemyCanSpawn = false;
                enemySpawner2.enemyCanSpawn = false;
                enemySpawner3.enemyCanSpawn = false;
                //enemySpawner4.enemyCanSpawn = false;
                //enemySpawner5.enemyCanSpawn = false;
                animatorAtk1Obj1.SetBool("PlayATK", false);

                this.battleMenu.SetActive(true);
            }
            else
            {
                this.battleMenu.SetActive(false);
                string attackType = Random.Range(0, 2) == 1 ? "attack" : "attack";
                currentUnit.GetComponent<FighterAction>().SelectAttack(attackType);

                xEnemyRandomAttack = Random.Range(1, 5);

                // random attacks against opponents can be expanded to contain all attacks /checking animation attacks now
                if (xEnemyRandomAttack == 0)
                {
                    enemySpawner0.enemyCanSpawn = true;
                    Invoke("ContinueGame", 4);
                } else if(xEnemyRandomAttack == 1)
                {
                    enemySpawner1.enemyCanSpawn = true;
                    Invoke("ContinueGame", 4);
                } else if(xEnemyRandomAttack == 2)
                {
                    enemySpawner2.enemyCanSpawn = true;
                    Invoke("ContinueGame", 4);
                } else if(xEnemyRandomAttack == 3)
                {
                    enemySpawner3.enemyCanSpawn = true;
                    Invoke("ContinueGame", 4);
                } else if(xEnemyRandomAttack == 4)
                {
                    animatorAtk1Obj1.SetBool("PlayATK", true);
                    Invoke("ContinueGame", 4);
                }
                else
                {
                    enemySpawner0.enemyCanSpawn = false;
                    enemySpawner1.enemyCanSpawn = false;
                    enemySpawner2.enemyCanSpawn = false;
                    enemySpawner3.enemyCanSpawn = false;
                    animatorAtk1Obj1.SetBool("PlayATK", false);
                    //enemySpawner2.enemyCanSpawn = true;
                    //enemySpawner3.enemyCanSpawn = true;
                    //enemySpawner4.enemyCanSpawn = true;
                    //enemySpawner5.enemyCanSpawn = true;
                    Invoke("ContinueGame", 2);
                }

            }
        }
        else
        {
            NextTurn();
        }

    }
    public void ContinueGame()
    {
        battleMenu.SetActive(false);
        GameObject.Find("BattleControllerObject").GetComponent<BattleController>().NextTurn();
    }
    
}
