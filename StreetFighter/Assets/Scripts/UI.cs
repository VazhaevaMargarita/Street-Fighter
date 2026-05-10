using System;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class UI : MonoBehaviour
{ 

    [SerializeField] private Image fillEn;
    [SerializeField] private Image fillPl;

    private void Awake()
    {
        fillEn.color = Color.green;
        fillEn.fillAmount = 1f;
        fillPl.color = Color.green;
        fillPl.fillAmount = 1f;
    }

    public void SetHealthPl(float current, float max)
    {
        float ratio = current / max;

        fillPl.fillAmount = ratio;
        fillPl.color = Color.Lerp(Color.red, Color.green, ratio);
    }
    public void SetHealthEn(float current, float max)
    {
        float ratio = current / max;

        fillEn.fillAmount = ratio;
        fillEn.color = Color.Lerp(Color.red, Color.green, ratio);
    }
}
