using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public Transform damagePoint;
    public LayerMask enemyLayer;
    public float attackRadius;

    private void Update()
    {
        Collider[] hit = Physics.OverlapSphere(damagePoint.position, attackRadius, enemyLayer);
        if(hit.Length >0)
        {
            foreach(Collider col in hit)
            {
                Destroy(col.gameObject);
            }
        }
    }
}
