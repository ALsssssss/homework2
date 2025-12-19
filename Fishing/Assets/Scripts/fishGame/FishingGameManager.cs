using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class FishingGameManager : MonoBehaviour
{
    [Header("UI设置")]
    public Slider progressSlider;
    
    public Text successText;

    [Header("游戏设置")]
    public float catchProgressSpeed = 0.1f;
    public float progressDecaySpeed = 0.05f;
    public float maxProgress = 100f;
    public float currentProgress=0;
    public bool isFishingSuccess = false;
    [Header("计时器设置")]
    public float totalTime = 30f; // 总时间30秒
    private float currentTime;    // 当前剩余时间
    public Text Timetext;
    public bool TimeOver;
    public cameraMove cam;//引用相机，修改相机移动
   
    [Header("事件")]
    public UnityEvent DiveEvent;//暂时用不到，用按钮组件替代了
    public UnityEvent RiseEvent;
    [Header("BOSS")]
    public int BossTurn = 0;//BOSS会出现的具体次数
    public GameObject BOSS;


    private FishBehavior FishBehavior;
    void Start()
    {
        
        progressSlider.maxValue = maxProgress;
        progressSlider.value = 0f;
        currentTime = totalTime;
    }

    void Update()
    {
        if(cam.Under==true)
        {
            isFishingSuccess=false;
            Timer();
        }


        if (FishBehavior != null)
        {
            FishBehavior.fishProgress = currentProgress;
        }
       
            // 进度条自然衰减
            if (currentProgress > 0)
            {
                currentProgress -= progressDecaySpeed * Time.deltaTime;
                currentProgress = Mathf.Max(0, currentProgress);
                UpdateProgressBar();
            }
     
    }

    public void IncreaseProgress()
    {
        
            currentProgress += catchProgressSpeed * Time.deltaTime * 100f;
            
            UpdateProgressBar();

            if (currentProgress >= maxProgress)
            {
                FishingSuccess();
            }
        
    }


    void UpdateProgressBar()
    {
        if(FishBehavior!=null)
        progressSlider.value =FishBehavior.fishProgress;
    }

    void FishingSuccess()
    {
        
        //successPanel.SetActive(true);
        InventoryManager.Instance.AddItem(FishBehavior.currentItem);
        Destroy(FishBehavior.gameObject);
    }

    /// <summary>
    /// 获取鱼行为组件
    /// </summary>
    /// <param name="fish"></param>
    public void GetFishProgress(FishBehavior fish)
    {
        
        FishBehavior = fish;

    }

    public void Timer()
    {
        Timetext.gameObject.SetActive(true);
        currentTime -=Time.deltaTime;
        
        TimerUI();
        if(currentTime < 0)
        {
            completeTime();
            currentTime = totalTime;
            Timetext.gameObject.SetActive(false);
        }

    }
    private void TimerUI()
    {
        Timetext.text = Mathf.CeilToInt(currentTime).ToString();
    }
    private void completeTime()
    {
        isFishingSuccess = true;
        BossTurn++;
        //cam.setBack();
        RiseEvent.Invoke();
        if(BossTurn>=3)
        {
            BOSS.gameObject.SetActive(true);
        }
    }
    public void NEXTscene()
    {
        SceneManager.LoadScene("回合制战斗");
    }
}
