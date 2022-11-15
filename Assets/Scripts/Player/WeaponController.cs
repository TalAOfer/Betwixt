using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public GameEvent OnShoot;
    public GameEvent OnChangeAttackStatus;

    private Animator anim;

    private bool canAttack = true;
    private bool isPressingAttack;
    private bool isAttacking = false;
    [SerializeField] private float attackSpeed = 1;

    private float nextAttackTime;
    public float attackDelay = 0.5f;

    void Start()
    {
        anim = GetComponent<Animator>();
        nextAttackTime = Time.time;
        attackDelay /= attackSpeed;
    }

    void Update()
    {
        if (Time.time > nextAttackTime)
        {
            canAttack = true;
        }

        if (isPressingAttack)
        {
            PerformAttack();
        }

        anim.SetBool("isAttacking", isAttacking);
    }

    public void UpdateAttackInput(Component sender, object data)
    {
        isPressingAttack = (bool)data;
    }

    private void PerformAttack()
    {
        if (canAttack)
        {
            isAttacking= true;
            OnChangeAttackStatus.Raise(this, true);
            OnShoot.Raise();
            canAttack = false;
            nextAttackTime = Time.time + attackDelay;
        }
    }

    public void FinishAttack()
    {
        isAttacking = false;
        OnChangeAttackStatus.Raise(this, false);
    }

    public void UpdateAttackSpeed(float amount)
    {
        anim.speed = amount;
    }



}
