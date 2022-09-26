using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class BattleSystem : MonoBehaviour
{
    public BattleState state;
    Pet player;
    Pet enemy;
    public GameObject playerGameObject;
    public GameObject enemyGameObject;
    public Text playerText;
    public Text enemyText;
    public Text itemText;
    int index;

    void Start()
    {
        state = BattleState.START;
        player = playerGameObject.GetComponent<Pet>();
        enemy = enemyGameObject.GetComponent<Pet>();

        state = BattleState.PLAYERS_TURN;

        index = 0;
        itemText.text = player.items[index];
    }
    
    IEnumerator Turn()
    {
        if(state == BattleState.PLAYERS_TURN)
        {
            state = BattleState.ENEMYS_TURN;
            enemy.TakeDamage(player.GetAttack());
            enemyGameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().color = Color.red;
            enemyText.text = enemy.health.ToString();
            yield return new WaitForSeconds(2f);
        }
        enemyGameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().color = Color.white;
        StartCoroutine(EnemyTurn());
    }

    IEnumerator EnemyTurn()
    {
        System.Random random = new System.Random();
        int number = random.Next(1, 100);
        //If the enemies health less then 50 and the enemy has a healing item it uses it
        if(enemy.health <= 50 && enemy.items.Where(x=>x.Contains("h")).Count() >= 1)
        {
            string item = enemy.items.Where(x => x.Contains("h")).ToList()[0].ToString();
            enemy.UseItem(item);
            enemy.items.Remove(item);
            enemyGameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().color = Color.green;
            enemyText.text = enemy.health.ToString();
            yield return new WaitForSeconds(2f);
            enemyGameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().color = Color.white;
        } // If the random number is less then 50 and enemy has attack modider it uses it
        else if (number<= 40 && enemy.items.Where(x=>x.Contains("a")).Count() >= 1)
        {
            string item = enemy.items.Where(x => x.Contains("a")).ToList()[0].ToString();
            enemy.UseItem(item);
            enemy.items.Remove(item);
            enemyGameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().color = Color.yellow;
            yield return new WaitForSeconds(2f);
            enemyGameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().color = Color.white;
        }//Enemy attacks
        else
        {
            player.TakeDamage(enemy.GetAttack());
            playerGameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().color = Color.red;
            playerText.text = player.health.ToString();
            yield return new WaitForSeconds(2f);
            playerGameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().color = Color.white;
        }
        state = BattleState.PLAYERS_TURN;
    }

    public void OnAttackButton()
    {
        StartCoroutine(Turn());
    }
    
    public void NextItemButton()
    {
        if(player.items.Count() != 0)
        {
            if(index+1 == player.items.Count())
            {
                index = 0;
                itemText.text = player.items[index];
            }
            else
            {
                index++;
                itemText.text = player.items[index];
            }
        }
    }

    public void PreviousItemButton()
    {
        if(player.items.Count() != 0)
        {
            if(index-1 == 0)
            {
                index = 0;
                itemText.text = player.items[index];
            }
            else
            {
                index++;
                itemText.text = player.items[index];
            }
        }
    }

    public void UseItemButton()
    {
        if(player.items.Count() != 0)
        {
            StartCoroutine(UseItem());
        }
    }

    IEnumerator UseItem()
    {
        //Selected Item
        string item = player.items[index];
        
        //Decides which type of modifier did player select and use
        if (player.items[index].Contains("a"))
        {   
            playerGameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().color = Color.yellow;
            player.UseItem(item);
            player.items.Remove(item);
        }
        else
        {
            playerGameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().color = Color.green;
            player.UseItem(item);
            player.items.Remove(item);
            playerText.text = player.health.ToString();
        }

        //Resetting the player object color
        yield return new WaitForSeconds(2f);
        playerGameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().color = Color.white;

        index = 0;
        state = BattleState.ENEMYS_TURN;
        
        //Check if we have anymore items
        if(player.items.Count() == 0)
        {
            itemText.text = "0";
        }
        else
        {
            itemText.text = player.items[index];
        }

        //Starts enemy turn
        yield return new WaitForSeconds(2f);
        StartCoroutine(Turn());
    }
}

public enum BattleState
{
    START,
    PLAYERS_TURN,
    ENEMYS_TURN,
    WON,
    LOST
}
