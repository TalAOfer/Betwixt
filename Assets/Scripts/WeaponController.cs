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

    private float nextAttackTime;
    private float attackDelay = 0.5f;

    void Start()
    {
        anim = GetComponent<Animator>();
        nextAttackTime = Time.time;
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
    }

    public void UpdateAttackInput(Component sender, object data)
    {
        isPressingAttack = (bool)data;
    }

    private void PerformAttack()
    {
        if (canAttack)
        {
            OnChangeAttackStatus.Raise(this, true);
            anim.SetTrigger("Attack");
            OnShoot.Raise();
            canAttack = false;
            nextAttackTime = Time.time + attackDelay;
        }
    }

    public void FinishAttack()
    {
        OnChangeAttackStatus.Raise(this, false);
    }

}
