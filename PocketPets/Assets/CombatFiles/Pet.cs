using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using TMPro;

public class Pet : MonoBehaviour
{
    public int level;
    public float maxHealth;
    public float health;
    public float attack;
    public float modifier;
    public double criticalChance;
    public List<string> items;

    public float enemyModifier = 1f;
    public float mana;

    private void Start()
    {
        DiffChecker();
        if (gameObject.CompareTag("Player"))
        {
            items = File.ReadAllLines("Assets/Data/inventory.txt").ToList();
        }
    }
    public float GetAttack()
    {
        System.Random random = new System.Random();
        int playerChance = random.Next(0, 100);
        if (gameObject.CompareTag("Enemy"))
        {
            if (criticalChance > playerChance)
            {
                return (attack + modifier) * 1.5f * enemyModifier;
            }
            else
            {
                return (attack + modifier) * enemyModifier;
            }
        }
        else
        {
            if (criticalChance > playerChance)
            {
                return (attack + modifier) * 1.5f;
            }
            return attack + modifier;
        }
    }

    public float getAdvanced()
    {
        float tmp = GetAttack() * 0.5f;
        return GetAttack() + tmp;
    }

    public float getUltimate()
    {
        float tmp = GetAttack() * 0.75f;
        return GetAttack() + tmp;
    }

    public void DiffChecker()
    {
        if (MainMenu.isDiffEasy == true)
        {
            enemyModifier = 0.75f;
        }
        if (MainMenu.isDiffNormal == true)
        {
            enemyModifier = 1f;
        }
        if (MainMenu.isDiffHard == true)
        {
            enemyModifier = 1.25f;
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
                PlayerSetFloatingTextToHeal(modifier);
                EnemySetFloatingTextToHeal(modifier);
            }
            else
            {
                health = maxHealth;
            }
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        PlayerSetFloatingTextToDMG(damage);
        EnemySetFloatingTextToDMG(damage);
    }

    [SerializeField] private TextMeshProUGUI PlayerfloatingText;
    [SerializeField] private TextMeshProUGUI EnemyfloatingText;
    [SerializeField] private TextMeshProUGUI PlayerfloatingTextHeal;
    [SerializeField] private TextMeshProUGUI EnemyfloatingTextHeal;

    public void PlayerSetFloatingTextToDMG(float text)
    {
        if (PlayerfloatingText) 
        {
            PlayerfloatingText.text = text.ToString("-" + "0");
        }
    }

    public void EnemySetFloatingTextToDMG(float text)
    {
        if (EnemyfloatingText)
        {
            EnemyfloatingText.text = text.ToString("-" + "0");
        }
    }

    public void PlayerSetFloatingTextToHeal(float text)
    {
        if (PlayerfloatingTextHeal) 
        {
            PlayerfloatingTextHeal.text = text.ToString("+" + "0");
        }
    }

    public void EnemySetFloatingTextToHeal(float text)
    {
        if (EnemyfloatingTextHeal)
        {
            EnemyfloatingTextHeal.text = text.ToString("+" + "0");
        }
    }
}
