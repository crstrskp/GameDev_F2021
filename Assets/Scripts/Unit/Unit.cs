using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public enum Team { Red, Blue, Green, Yellow, None }
    [SerializeField] private Team m_team;
    [SerializeField] private Renderer m_renderer;

    public Team GetTeam() => m_team;

    private UnitTargeting m_unitTargeting;
    private UnitMovement m_unitMovement;
    private UnitAttack m_unitAttack;
    
    private void Awake()
    {
        m_unitTargeting = GetComponent<UnitTargeting>();
        m_unitMovement = GetComponent<UnitMovement>();
        m_unitAttack = GetComponent<UnitAttack>();

        SetTeamColor();
    }

    private void Update()
    {
        if (!m_unitTargeting.GetTarget())
        {
            m_unitMovement.Wander();
        }
        else 
        {
            float distToTarget = Vector3.Distance(transform.position, m_unitTargeting.GetTarget().transform.position);
            if (distToTarget <= m_unitMovement.GetStoppingDistance())
            {
                Debug.Log("eh2");
                if (m_unitAttack.CanAttack())
                {
                    m_unitAttack.Attack(m_unitTargeting.GetTarget());
                    Debug.Log("eh3");
                }
            }
            else
            {
                m_unitMovement.MoveTo(m_unitTargeting.GetTarget().transform.position);
            }
        }        
    }

    private void SetTeamColor()
    {
        if (!m_renderer) return; 
        switch(m_team)
        {
            case Team.Red:
                m_renderer.material.color = Color.red;
                break;
            case Team.Blue:
                m_renderer.material.color = Color.blue;
                break;
            case Team.Green:
                m_renderer.material.color = Color.green;
                break;
            case Team.Yellow:
                m_renderer.material.color = Color.yellow;
                break;
            case Team.None:
            default:
                Debug.Log("No team set");
                break;
        }
    }
}
