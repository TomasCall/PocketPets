using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Pet : MonoBehaviour
{
    public int level;
    public double maxHealth;
    public double health;
    public double attack;
    public double modifier;
    public double criticalChance;
    public List<string> items;

    private DifficultySetter difficultySetter;
    public double enemyModifier = 1;


    public double GetAttack()
    {
        DiffChecker();
        System.Random random = new System.Random();
        int playerChance = random.Next(0, 100);
        if (gameObject.CompareTag("Enemy") && criticalChance > playerChance)
        {
            return (attack + modifier) * 1.5 * enemyModifier;
        }
        if (criticalChance > playerChance)
        {
            return (attack + modifier) * 1.5;
        }
        if (gameObject.CompareTag("Enemy"))
        {
            return (attack + modifier) * enemyModifier;
        }
        else { 
            return attack + modifier;
        }
    }

    public void DiffChecker()
    {
        if (DifficultySetter.isDiffEasy == true)
        {
            enemyModifier = 0.75;
        }
        if (DifficultySetter.isDiffNormal == true)
        {
            enemyModifier = 1;
        }
        if (DifficultySetter.isDiffHard == true)
        {
            enemyModifier = 1.25;
        }
    }

    public void UseItem(string item)
    {
        string[] selectedItem = items.Where(x=>x.Equals(item)).ToList()[0].ToString().Split('+');
        string typeOfItem = selectedItem[0];
        int valueOfItem = int.Parse(selectedItem[1]);
        if (selectedItem[0].Equals("a"))
        {
            modifier += valueOfItem;
        } 
        else 
        {
            if(maxHealth > modifier + health)
            {
                health += modifier;
            }
            else
            {
                health = maxHealth;
            }
        }
    }

    public void TakeDamage(double damage)
    {
        health -= damage;
    }
}
