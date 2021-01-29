using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitAttack : MonoBehaviour
{
    [SerializeField] private float baseDamage = 5.0f;
    private bool m_canAttack = true;
    [SerializeField] private float m_attackDelaySec = 1.5F;
    private Animator m_anim;

    private void Awake()
    {
        m_anim = GetComponent<Animator>();
    }

    public bool CanAttack() => m_canAttack;
    internal void Attack(GameObject target)
    {
        Debug.Log("eh");
        m_canAttack = false;
        
        if (m_anim) m_anim.SetTrigger("Attack");

        float dmg = CalculateDamage();
        target.GetComponent<Health>().AdjustHealth(-dmg);

        StartCoroutine(AttackDelay(m_attackDelaySec));
    }

    private float CalculateDamage()
    {
        return baseDamage; // TODO: weaponDamage, Crit chance, etc
    }

    private IEnumerator AttackDelay(float sec)
    {
        yield return new WaitForSeconds(sec);
        m_canAttack = true;
    }
}
