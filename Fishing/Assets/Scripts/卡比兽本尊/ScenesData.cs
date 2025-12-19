using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenesData : MonoBehaviour
{
   public static ScenesData instance;
    [Header("卡比兽的属性")]
    public int kabiATK;
    public int kabiDEF;
    public Vector3 kabiFAT;
   
    private void Awake()
    {
        if (instance == null)
        {
            instance =this;
            DontDestroyOnLoad(gameObject);
        }
        else 
        {
            Destroy(gameObject);
        }
    }
    public void GetKabiValue(int atk,int def,Vector3 fat)
    {
        kabiATK = atk; kabiDEF = def; kabiFAT = fat;
        Debug.Log("攻击力"+kabiATK+"防御力"+ kabiDEF );
    }
    public int SetKabiAtk()
    {
        return kabiATK;
    }
    public int SetKabiDef()
    {
        return kabiDEF;
    }
    public Vector3 SetKabiFat()
    {
        return kabiFAT;
    }
}
