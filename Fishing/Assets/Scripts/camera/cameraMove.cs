using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UIElements;

public class cameraMove : MonoBehaviour
{
    public float speed = 1;
    public bool ismove=false;
    public bool isback =false;
    public bool Under=false;
    public float lerpDuration;
    public Vector3 targetPosition;
    private Vector3 StartPosition;
   
    private void Start()
    {
        StartPosition = transform.position;
        
    }
    private void Update()
    {
        
    }
    private void FixedUpdate()
    {
        if (ismove&&transform.position!=targetPosition)
        {
            MoveCameraPostation();
        }
        if (isback && transform.position != StartPosition)
        {
            MoveCameraPostationBack();
        }
    }
    private void MoveCameraPostation()
    {
        transform.position = Vector3.Lerp(transform.position,targetPosition,speed*Time.deltaTime/lerpDuration);
        if(transform.position == targetPosition)
        ismove = false;
    }
    private void MoveCameraPostationBack()
    {
        transform.position = Vector3.Lerp(transform.position, StartPosition, speed * Time.deltaTime / lerpDuration);
        if (transform.position == StartPosition)
            isback = false;
    }
    public void setMove()
    {
        ismove = true;
        Under = true;
    }
    public void setBack()
    {
        isback = true;
        Under =false;
    }
}
