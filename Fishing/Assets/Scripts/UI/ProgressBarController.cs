using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarController : MonoBehaviour
{
    public Image fillImage;
    public Color lowProgressColor = Color.red;
    public Color highProgressColor = Color.green;

    private Slider slider;

    void Start()
    {
        slider = GetComponent<Slider>();
    }

    void Update()
    {
        // 根据进度改变颜色
        float progress = slider.value / slider.maxValue;
        fillImage.color = Color.Lerp(lowProgressColor, highProgressColor, progress);
    }
}
