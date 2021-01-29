using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    [SerializeField] private float m_currentHealth;
    [SerializeField] private float m_maxHealth = 100;

    public event Action<float, float> ClientOnHealthChanged;


    private void Awake() => m_currentHealth = m_maxHealth;

    void Update()
    {
        if (m_currentHealth <= 0)
        {
            Debug.Log("Dead");
            Destroy(gameObject);
        }
    }

    public void AdjustHealth(float adj) {

        m_currentHealth += adj;
        ClientOnHealthChanged?.Invoke(m_currentHealth, m_maxHealth);        
    } 
}
