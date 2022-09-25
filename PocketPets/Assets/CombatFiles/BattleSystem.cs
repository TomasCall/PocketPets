using System.Collections;
using System.Collections.Generic;
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

    // Start is called before the first frame update
    void Start()
    {
        state = BattleState.START;
        StartCoroutine(SetupBattle());
    }

    IEnumerator SetupBattle()
    {
        playerGameObject = Instantiate(playerGameObject);
        player = playerGameObject.GetComponent<Pet>();

        enemyGameObject = Instantiate(enemyGameObject);
        enemy = enemyGameObject.GetComponent<Pet>();

        yield return new WaitForSeconds(2f);

        state = BattleState.PLAYERS_TURN;
    }

    public void OnAttackButton()
    {
        StartCoroutine(Turn());
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
            enemyGameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().color = Color.white;
            player.TakeDamage(player.GetAttack());
            playerGameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().color = Color.red;
            playerText.text = player.health.ToString();
            yield return new WaitForSeconds(2f);
            playerGameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().color = Color.white;
            state = BattleState.PLAYERS_TURN;
        }
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
