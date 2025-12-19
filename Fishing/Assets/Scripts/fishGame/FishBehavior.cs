using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class FishBehavior : MonoBehaviour
{
    [Header("物体信息")]
    public ItemData item;
    public int count;
    public InventoryItem currentItem;
    private SpriteRenderer spriteRenderer;
    private bool IsFlip;
    [Header("移动设置")]
    public float moveSpeed = 2f;
    public float moveRange = 3f;
    public float changeDirectionTime = 2f;

    private Vector3 startPosition;
    private Vector3 targetPosition;
    private float directionTimer;
    [Header("钓鱼进度")]
    public float fishProgress=0f;//当前鱼的进度
    public float thisfishProgress = 0f;//保存当前这条鱼的钓鱼进度
    public FishingGameManager gameManager;
    private void Awake()
    {
        gameManager =FindAnyObjectByType<FishingGameManager>();
        spriteRenderer=GetComponent<SpriteRenderer>();
    }
    void Start()
    {
        InventoryItem currentitem = new InventoryItem(item,count);
        currentItem=currentitem;
        startPosition = transform.position;
        SetNewTargetPosition();
    }

    void Update()
    {
        // 移动鱼
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        // 定时改变方向
        directionTimer += Time.deltaTime;
        if (directionTimer >= changeDirectionTime || Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            SetNewTargetPosition();
            if(IsFlip!=true)
            spriteRenderer.flipX = true;
           

            directionTimer = 0f;
        }
        if(gameManager.isFishingSuccess==true) 
        { 
        Destroy(this.gameObject);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "player")
        {
            gameManager.IncreaseProgress();

            FishBehavior fish = transform.GetComponent<FishBehavior>();
            gameManager.GetFishProgress(fish);
            thisfishProgress = fishProgress;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag =="player")
        {
            gameManager.currentProgress = thisfishProgress;
        }
    }
    void SetNewTargetPosition()
    {
        float randomX = Random.Range(-moveRange, moveRange);
        float randomY = Random.Range(-moveRange, moveRange);

        targetPosition = startPosition + new Vector3(randomX, randomY, 0);

        // 限制鱼在指定区域内
        targetPosition.y = Mathf.Clamp(targetPosition.y, -moveRange, moveRange);
        targetPosition.x = Mathf.Clamp(targetPosition.x, -moveRange, moveRange);
    }
}
