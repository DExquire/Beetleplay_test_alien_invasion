using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float attackRange = 2f;
    public int attackDamage = 10; 

    public LayerMask enemyLayers; 
    public Transform attackPoint; 

    public int maxEnemiesAttack;

    public void Attack()
    {
        Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayers);

        for (int i = 0; i < hitEnemies.Length; i++)
        {
            if (i < maxEnemiesAttack)
            {
                EnemyController enemyController = hitEnemies[i].GetComponent<EnemyController>();
                if (enemyController != null)
                {
                    enemyController.TakeDamage(attackDamage);
                }
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}