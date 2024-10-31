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
    /// ����HEALTH�ٷֱ�
    /// </summary>
    /// <param name="persentage">�ٷֱȣ�Currnet/Max</param>
    public void OnHealthChange(float persentage)
    {
        healthImage.fillAmount = persentage;
    }
}
