
using System;
using UnityEngine;

public class player_attack : MonoBehaviour
{
    public Animator animator;

    public Transform AttackPoint;
    public LayerMask ennemyLayers;

    public float attackRange = 0.5f;
    public int attackDamage = 100;
   

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Attack();
        }
    }

    void Attack()
    {
        animator.SetTrigger("attack");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(AttackPoint.position, attackRange, ennemyLayers);

        foreach(Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
        }

        

        
    }

     void OnDrawGizmosSelected()
    {
        if( AttackPoint == null)
        {
            return;
        }

        Gizmos.DrawWireSphere(AttackPoint.position, attackRange);
    }
}
