using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class frog_attack : MonoBehaviour
{
    private Animator anim;
    private float cooldownTimer = Mathf.Infinity;
    [SerializeField] private float attackCooldown;
    private AI_chase ennemyMovement;
    private Transform target;

    public Animator animator;

    public Transform AttackPoint;
    public LayerMask ennemyLayers;

    public float attackRange = 0.5f;
    


    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    
    private void Awake()
    {
        anim = GetComponent<Animator>();
       ennemyMovement = GetComponent<AI_chase>();
    }


    private void Update()
    {
        if (Vector2.Distance(transform.position, target.position) < 3 && cooldownTimer > attackCooldown)
        {
            Attack();


            cooldownTimer += Time.deltaTime;
        }
    }

    private void Attack()
    {
        cooldownTimer = 2;
        anim.SetTrigger("tong attack");
       


    }
    void OnDrawGizmosSelected()
    {
        if (AttackPoint == null)
        {
            return;
        }

        Gizmos.DrawWireSphere(AttackPoint.position, attackRange);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            player_health playerHealth = collision.transform.GetComponent<player_health>();
            playerHealth.TakeDamage(10);
        }
    }

    




}