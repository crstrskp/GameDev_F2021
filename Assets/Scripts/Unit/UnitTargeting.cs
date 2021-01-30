using UnityEngine;

public class UnitTargeting : MonoBehaviour
{
    [SerializeField] private LayerMask m_layerMask = new LayerMask();
    private GameObject m_target;
    [SerializeField] private float m_aggroRange = 10.0f;
    private UnitMovement m_unitMovement;

    private Unit m_unit;

    private void Awake() 
    {
        m_unitMovement = GetComponent<UnitMovement>();
        m_unit = GetComponent<Unit>();
    }

   private void Update()
   {
       m_target = FindClosestTargetInRange();
   }

    public GameObject GetTarget() => m_target;

    private GameObject FindClosestTargetInRange()
    {
        var colliders = Physics.OverlapSphere(transform.position, m_aggroRange, m_layerMask);

        GameObject target = null;
        float distanceToTarget = float.MaxValue;

        foreach (Collider col in colliders)
        {
            var unit = col.GetComponent<Unit>();
            if (unit != null && unit.GetTeam() != m_unit.GetTeam()) // TODO: Store in var
            {
                float dist = Vector3.Distance(transform.position, unit.transform.position);
                if (dist < distanceToTarget)    
                {
                    distanceToTarget = dist;
                    target = unit.gameObject;
                }
            }
        }

        return target;
    }
}