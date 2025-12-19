using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HUD : MonoBehaviour
{
    public Color lowProgressColor = Color.red;
    public Color highProgressColor = Color.green;//切换颜色


    public Slider PlayerHealth;
    public Slider EnemyHealth;

    public Image FillColorPlayer;
    public Image FillColorEnemy;
    public Unit PlayerUnit;
    public Unit EnemyUnit;
    private void Start()
    {
        PlayerUnit = GameObject.Find("玩家位置").GetComponentInChildren<Unit>();
        EnemyUnit = GameObject.Find("敌人位置").GetComponentInChildren<Unit>();
        PlayerHealth.maxValue= PlayerUnit.MaxUnitHealth;
        EnemyHealth.maxValue= EnemyUnit.MaxUnitHealth;
    }
    private void Update()
    {
       PlayerHealth.value =PlayerUnit.CurrentHealth;
       EnemyHealth.value =EnemyUnit.CurrentHealth;


        float progress1 = PlayerHealth.value / PlayerHealth.maxValue;
        FillColorPlayer.color = Color.Lerp(lowProgressColor, highProgressColor, progress1);
             float progress2 = EnemyHealth.value / EnemyHealth.maxValue;
        FillColorEnemy.color = Color.Lerp(lowProgressColor, highProgressColor, progress2);
    }
}
