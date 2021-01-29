using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    private Health m_health;
    [SerializeField] private Image m_healthBarImage = null;

    private void Awake()
    {
        m_health = GetComponent<Health>();
        m_health.ClientOnHealthChanged += HandleHealthChanged;
    }

    private void OnDestroy()
    {
        m_health.ClientOnHealthChanged -= HandleHealthChanged;
    }

    private void HandleHealthChanged(float currentHealth, float maxHealth) 
    {
        m_healthBarImage.fillAmount = currentHealth / maxHealth; 

        float value = GetHSV(currentHealth, maxHealth, 0, 125, 0);

        m_healthBarImage.color = Color.HSVToRGB(value / 360, 1.0f, 1.0f);
    }

    private static float GetHSV(float value, float fromSource, float toSource, float fromTarget, float toTarget)
    {
        return (value - fromSource) / (toSource - fromSource) * (toTarget - fromTarget) + fromTarget;
    }
}
