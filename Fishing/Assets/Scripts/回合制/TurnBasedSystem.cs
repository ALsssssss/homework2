using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TurnBasedSystem : MonoBehaviour
{
    public enum TurnState { StartTurn,PlayerTurn,EnemyTurn,WIN,LOST}
    [Header("对局设置")]
    private TurnState currentState;
    [Header("位置")]
    public Transform Player;
    public Transform Enemy;
    [Header("预制体")]
    public GameObject PlayerPrefab;
    public GameObject EnemyPrefab;
    private Unit PlayerUnit;
    private Unit EnemyUnit;

    public Text PlayerText;
    private void Start()
    {
        currentState= TurnState.StartTurn;
        StartCoroutine(InitGame());
    }
    IEnumerator  InitGame()
    {
        GameObject PlayerFight=Instantiate(PlayerPrefab,Player);
        PlayerUnit=PlayerFight.GetComponent<Unit>();
        GameObject EnemyFight= Instantiate(EnemyPrefab,Enemy);
        EnemyUnit=EnemyFight.GetComponent<Unit>();

        //设置UI
        yield return new WaitForSeconds(2f);

        //可以增加判定速度，决定先手回合
        currentState = TurnState.PlayerTurn;
    }

    public void AttackByButton()
    {
        if (currentState == TurnState.PlayerTurn)
        {
            PlayerUnit.PlayerTakeDamage();
            CheckHealth();


            if (EnemyUnit.Die==true)
            {
                currentState = TurnState.WIN;
                EnemyPrefab.SetActive(false);
                StartCoroutine(GameOver());
            }
            if(EnemyUnit.Die==false) 
            {
                currentState = TurnState.EnemyTurn;
                StartCoroutine(AttackByEnemy());
            }
        }
    }
    public void DefenseButton()
    {
        if (currentState == TurnState.PlayerTurn)
        {
            PlayerUnit.TakeDefense();
            CheckHealth();


            if (EnemyUnit.Die == true)
            {
                currentState = TurnState.WIN;
                EnemyPrefab.SetActive(false);
                StartCoroutine(GameOver());
            }
            if (EnemyUnit.Die == false)
            {
                currentState = TurnState.EnemyTurn;
                StartCoroutine(AttackByEnemy());
            }
        }
    }
    public IEnumerator AttackByEnemy() 
    { 
    if(currentState == TurnState.EnemyTurn)
        {
            yield return new WaitForSeconds(2f);
            EnemyUnit.EnemyTakeDamage();
            CheckHealth();
            if (PlayerUnit.Die==true) 
            { 
                currentState =TurnState.LOST;
                PlayerPrefab.SetActive(false);
                StartCoroutine(GameOver());
            }
            if (EnemyUnit.Die==false)
            {
                currentState = TurnState.PlayerTurn;
            }
            
        }
    }
    public IEnumerator GameOver()
    {
        PlayerText.text="游戏结束";
        yield return new WaitForSeconds(2f);
        Application.Quit();
    }
    private void CheckHealth()
    {
        if (PlayerUnit.CurrentHealth <= 0)
        {
            PlayerUnit.Die = true;
        }
        if(EnemyUnit.CurrentHealth <= 0) 
        {
            EnemyUnit.Die = true;
        }
    }
}
