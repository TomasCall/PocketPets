using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSystem : MonoBehaviour
{
    public BattleState state;
    Pet player;
    Pet enemy;
    public GameObject playerGameObject;
    public GameObject enemyGameObject;

    // Start is called before the first frame update
    void Start()
    {
        state = BattleState.START;
        StartCoroutine(SetupBattle());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SetupBattle()
    {
        playerGameObject = Instantiate(playerGameObject);
        player = playerGameObject.GetComponent<Pet>();

        enemyGameObject = GameObject.Find("Enemy");
        enemy = enemyGameObject.GetComponent<Pet>();

        yield return new WaitForSeconds(2f);

        state = BattleState.PLAYERS_TURN;
        PlayerTurn();
    }

    void PlayerTurn()
    {

    }

    void EnemyTurn()
    {

    }

    public void OnAttackButton()
    {
        if(state == BattleState.PLAYERS_TURN)
        {
            //StartCoroutine(PlayerAttack());
        }
    }
    /*
    IEnumerator PlayerAttack()
    {
        yield return WaitForSeconds(2f);
    }
    */
}

public enum BattleState
{
    START,
    PLAYERS_TURN,
    ENEMYS_TURN,
    WON,
    LOST
}
