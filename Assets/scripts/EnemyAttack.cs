using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAttack : MonoBehaviour
{
    public float range = 10f;
    public Transform attackPoint;
    public LayerMask PlayerLayer;
    bool playerCheck;
    public float damage = 1f;

    public float AttackSpeed = 1;
    float nextAttack = 0f;

    // Update is called once per frame
    void Update()
    {
        playerCheck = Physics.CheckSphere(attackPoint.position, range, PlayerLayer);

        if (playerCheck == true && Time.time >= nextAttack)
        {
            Attack();
            nextAttack = Time.time + 1f / AttackSpeed;
        }
    }

    void Attack()
    {
        FindObjectOfType<PlayerHealth>().Health -= damage;

        if (FindObjectOfType<PlayerHealth>().Health <= 0)
        {
            FindObjectOfType<PlayerHealth>().GameOver();
        }
        UnityEngine.Debug.Log("Damage Taken");
    }
}
