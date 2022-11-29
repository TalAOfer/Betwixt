using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public GameEvent OnShoot;
    public GameEvent OnChangeAttackStatus;
    private Weapon_SO currWeapon;

    [SerializeField] PlayerChoices playerChoices;

    private Animator anim;

    private bool canAttack = true;
    private bool isPressingAttack;
    private bool isAttacking = false;
    
    private float attackSpeedBuff = 0;

    private float nextAttackTime;
    public float attackDelay = 0.5f;
    private float finishAttackTime;

    private int ammo = 2;
    private int shotCount = 0;

    void Start()
    {
        currWeapon = playerChoices.chosenWeapon;
        anim = GetComponent<Animator>();
        anim.runtimeAnimatorController = currWeapon.overrideAnim;
        nextAttackTime = Time.time;
    }

    void Update()
    {
        if (Time.time > nextAttackTime)
        {
            canAttack = true;
        }

        if (canAttack && isPressingAttack)
        {
            PerformAttack();
        }

        if (Time.time > finishAttackTime)
        {
            FinishAttack();
        }

        anim.SetBool("isAttacking", isAttacking);
    }

    public void UpdateAttackInput(Component sender, object data)
    {
        isPressingAttack = (bool)data;
    }

    private void PerformAttack()
    {
        shotCount++;
        isAttacking= true;
        OnChangeAttackStatus?.Raise(this, true);
        OnShoot?.Raise();
        canAttack = false;
        finishAttackTime = Time.time + currWeapon.attackDuration;
        nextAttackTime = Time.time + (attackDelay / (currWeapon.attackSpeed + attackSpeedBuff) );
    }


    public void FinishAttack()
    {
        isAttacking = false;
        OnChangeAttackStatus.Raise(this, false);
    }

    public void UpdateAttackSpeed(float amount)
    {
        attackSpeedBuff += amount;
    }

    public void UpdateWeapon(Weapon_SO newWeapon)
    {
        currWeapon = newWeapon;
    }

    private IEnumerator Reload(float reloadTime)
    {
        yield return new WaitForSeconds(reloadTime);
    }
}
