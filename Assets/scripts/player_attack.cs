
using System;
using UnityEngine;

public class player_attack : MonoBehaviour
{
    private Animator anim;
    private movement_samourail playerMovement;
    [SerializeField] private float attackCooldown;
    private float cooldownTimer = Mathf.Infinity;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<movement_samourail>();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0) && cooldownTimer > attackCooldown)
        {
            Attack();


            cooldownTimer += Time.deltaTime;
        }
    }

    private void Attack()
    {
        cooldownTimer = 0;
        anim.SetTrigger("attack");
    }
}
