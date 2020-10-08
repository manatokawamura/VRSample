using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetUIManager : MonoBehaviour
{
    [SerializeField] private Text nameTxt;
    [SerializeField] private GameObject meterObj;
    [SerializeField] private Image meter;

    void Start()
    {
        nameTxt.gameObject.SetActive(false);
        meterObj.SetActive(false);
        meter.fillAmount = 0;
    }

    public bool UIShow(float time, float maxTime)
    {
        nameTxt.gameObject.SetActive(true);
        meterObj.SetActive(true);

        meter.fillAmount = time / maxTime;    
        if(meter.fillAmount == 1)
        {
            return true;
        }
        return false;
    }

    public void UIHide()
    {
        if(nameTxt.gameObject.activeSelf || meterObj.activeSelf)
        {
            nameTxt.gameObject.SetActive(false);
            meterObj.SetActive(false);
        }
    }
}
