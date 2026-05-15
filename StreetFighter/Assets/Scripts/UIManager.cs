using System;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{ 
    [SerializeField]private GameObject prefab;
    
    [SerializeField] private Image fillPl;

    private void Awake()
    {
        

        fillPl.color = Color.green;
        fillPl.fillAmount = 1f;
    }

    public void SetHealthPl(float current, float max)
    {
        float ratio = current / max;

        fillPl.fillAmount = ratio;
        fillPl.color = Color.Lerp(Color.red, Color.green, ratio);
    }
}
