using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject experienceDrop;
    [SerializeField] GameObject bulletExplosion;
    [SerializeField] private EnemyStatManager enemyStatManager;
    [SerializeField] private EnemyData_SO enemyData;

    private Animator anim;
    private float currentHealth;
    private float maxHealth;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private BoxCollider2D coll;
    private float defaultSpeed;
    private float movementSpeed;
    private Vector3 lastPosition;
    private bool isFacingRight = true;
    private bool didWin = false;

    private Vector3 playerPosition;
    public bool isDead = false;
    private void OnEnable()
    {
        maxHealth = enemyData.maxHp;
        defaultSpeed = enemyData.speed;
        lastPosition = Vector3.zero;
        isDead = false;

        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();

        coll.enabled = true;

        currentHealth = maxHealth;
        movementSpeed = defaultSpeed * enemyStatManager.speedMultiplier;
        
        playerPosition = GameObject.FindWithTag("Player").transform.position;
    }

    private void OnDisable()
    {
        currentHealth = maxHealth;
        coll.enabled = true;
        
    }

    private void Update()
    {
        movementSpeed = defaultSpeed * enemyStatManager.speedMultiplier;
        anim.SetBool("isDead", isDead);
    }

    private void FixedUpdate()
    {
        if (!isDead)
        {
            transform.position = Vector3.MoveTowards(transform.position, playerPosition, movementSpeed * 0.01f);
        }
        
        if (isFacingRight && playerPosition.x < transform.position.x)
        {
            sr.flipX = true;
            isFacingRight = false;
        }

        else if (!isFacingRight && playerPosition.x > transform.position.x)
        {
            sr.flipX = false;
            isFacingRight = true;
        }
    }

    public void UpdatePlayerPosition(Component sender, object data)
    {
        playerPosition = (Vector3) data;
        
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        anim.SetTrigger("Hurt");

        if (currentHealth < 0)
        {
            coll.enabled = false;
            isDead = true;
            Die();
        }
    }

    private void Die()
    {
        if (!didWin)
        {
            FMODUnity.RuntimeManager.PlayOneShot("event:/Explosion", GetComponent<Transform>().position);
            Pooler.Spawn(experienceDrop, transform.position, transform.rotation);
        }

        StartCoroutine(Destroy());
    }

    private IEnumerator Destroy()
    {
        yield return new WaitForSeconds(0.5f);
        Pooler.Despawn(gameObject);
    }

    public void KillSelf()
    {
        didWin = true;
        TakeDamage(1000);
    }
}
