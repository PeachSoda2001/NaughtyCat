using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerManager : MonoBehaviour
{
    public float triggerCount = 0;
    public int triggerThreshold;
    public Slider uiSlider; // ����UI�ϵ�Slider���
    public GameObject attackObjectInstance; // ��������ʵ��

    void Start()
    {
        // ��ʼ����Slider��ֵ
        if (uiSlider != null)
        {
            uiSlider.value = triggerCount;
        }
    }

    public void UpdateTriggerCount()
    {
        triggerCount++; // ���Ӽ���
        CheckTriggerThreshold(); // ����Ƿ�ﵽ��ֵ
        UpdateSliderValue(); // ����Slider��ֵ
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
        Debug.Log("����Ч���������������Ѵﵽ " + triggerThreshold);
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
