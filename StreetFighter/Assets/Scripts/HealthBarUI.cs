using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    [SerializeField] private Image fillImage;

    private HealthNew health;

    private void Awake()
    {
        health = GetComponentInParent<HealthNew>();
    }

    private void Start()
    {
        if (health == null)
        {
            Debug.LogError("Health not found");
            return;
        }

        health.HealthChanged += UpdateBar;

        UpdateBar(
            health.CurrentHealth,
            health.MaxHealth);
    }

    private void OnDestroy()
    {
        if (health != null)
        {
            health.HealthChanged -= UpdateBar;
        }
    }

    private void UpdateBar(int current, int max)
    {
        float ratio = (float)current / max;

        fillImage.fillAmount = ratio;

        fillImage.color =
            Color.Lerp(Color.red, Color.green, ratio);
    }
}