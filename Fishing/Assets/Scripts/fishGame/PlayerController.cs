using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("滑块设置")]
    public float moveForce = 10f;

    [Header("钓鱼设置")]
    public Transform fish;
    public float catchRange = 0.5f;
    public FishingGameManager gameManager;

    private Rigidbody2D rb;
    private bool isMousePressed = false;
    private Vector3 startPosition;
    private Vector2 mouseDireection;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startPosition = transform.position;
    }

    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;
        // 计算从物体指向鼠标的方向
        mouseDireection = (mousePosition - transform.position).normalized;


        // 鼠标输入检测
        if (Input.GetMouseButtonDown(0))
        {
            isMousePressed = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            isMousePressed = false;
            rb.AddForce(-mouseDireection * moveForce);
        }


    }

    void FixedUpdate()
    {
        // 为滑块施加力
        if (isMousePressed)
        {
            rb.AddForce(mouseDireection * moveForce);
        }
        
    }




}
