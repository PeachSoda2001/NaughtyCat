using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerManager : MonoBehaviour
{
    public float triggerCount = 0;
    public int triggerThreshold;
    public Slider uiSlider; // 引用UI上的Slider组件
    public GameObject attackObjectInstance; // 攻击对象实例

    void Start()
    {
        // 初始设置Slider的值
        if (uiSlider != null)
        {
            uiSlider.value = triggerCount;
        }
    }

    public void UpdateTriggerCount()
    {
        triggerCount++; // 增加计数
        CheckTriggerThreshold(); // 检查是否达到阈值
        UpdateSliderValue(); // 更新Slider的值
    }

    void CheckTriggerThreshold()
    {
        if (triggerCount >= triggerThreshold)
        {
            TriggerEffect();
        }
    }

    void TriggerEffect()
    {
        Debug.Log("触发效果：触发器计数已达到 " + triggerThreshold);
        attackObjectInstance.GetComponent<HumanMove>().StartAttack();
    }

    void UpdateSliderValue()
    {
        if (uiSlider != null)
        {
            uiSlider.value = triggerCount;
        }
    }
}
