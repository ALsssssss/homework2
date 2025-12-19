using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public bool IsEnemy=false;//是否为敌人
    [Header("玩家的基础数值")]
    public int UnitAtk=10;
    public int UnitDefense=15;
    public Vector3 UnitFat;
    [Header("体积增长倍率")]
    public float Fatnum=1;
    [Header("生命值")]
    public int MaxUnitHealth = 100;
    public int CurrentHealth;
    public bool Die;
    public ScenesData Scenesdata;
    private Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
        Scenesdata = GameObject.Find("DataManger").GetComponent<ScenesData>();
        if (!IsEnemy) 
        {
            InitPlayer();

        }
        

        CurrentHealth = MaxUnitHealth;
        Debug.Log(UnitAtk);
        
    }
    public void PlayerTakeDamage()
    {
        Unit EnemyUnit =GameObject.Find("敌人位置").GetComponentInChildren<Unit>();
        EnemyUnit.CurrentHealth -= UnitAtk;
        Debug.Log(EnemyUnit.CurrentHealth);
        animator.SetTrigger("attack");
    }
    public void EnemyTakeDamage()
    {
        Unit PlayerUnit = GameObject.Find("玩家位置").GetComponentInChildren<Unit>();
        PlayerUnit.CurrentHealth -= UnitAtk;
        Debug.Log(PlayerUnit.CurrentHealth);
        animator.SetTrigger("attack");
    }
    public void TakeDefense()
    {
        CurrentHealth += UnitDefense;//根据吃的食物放大
    }
    public void Skill()
    {
        //调用特殊技能
    }

    private void InitPlayer()
    {
        UnitAtk = ScenesData.instance.SetKabiAtk();
        UnitDefense = ScenesData.instance.SetKabiDef();
        UnitFat = ScenesData.instance.SetKabiFat();
        transform.localScale += UnitFat*Fatnum;
    }
}
