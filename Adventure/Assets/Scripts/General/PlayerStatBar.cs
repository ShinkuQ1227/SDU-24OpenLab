using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatBar : MonoBehaviour
{
    public Image healthImage;
    public Image DelayHealthImage;

    private void Update()
    {
        if (DelayHealthImage.fillAmount > healthImage.fillAmount)
        {
            DelayHealthImage.fillAmount -= Time.deltaTime;
        }
    }
    /// <summary>
    /// 接收HEALTH百分比
    /// </summary>
    /// <param name="persentage">百分比：Currnet/Max</param>
    public void OnHealthChange(float persentage)
    {
        healthImage.fillAmount = persentage;
    }
}
