using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class WeaponPivot : MonoBehaviour
{
    private Transform weapon;
    private Player playerMovementScript;

    private bool isFacingRight = true;
    private bool isAttacking = false;

    private float weaponAngle;
    private void Start()
    {
        weapon = GetComponentInChildren<Transform>();
        playerMovementScript = GetComponentInParent<Player>();
    }

    private void FixedUpdate()
    {
        if (!isAttacking)
        {
            Rotate();
        }
    }

    private void Rotate()
    {
        transform.rotation = Quaternion.Euler(0, 0, weaponAngle);

        if (weaponAngle < -90)
        {
            transform.localRotation = Quaternion.Euler(180, 0, -weaponAngle);
        }

        if (weaponAngle > 90)
        {
            transform.localRotation = Quaternion.Euler(180, 0, -weaponAngle);
        }

        //else if (weaponAngle > 115 && isFacingRight)
        //{
        //    transform.localRotation = Quaternion.Euler(180, 0, -weaponAngle);
        //}

        //else if (weaponAngle > 75 && !isFacingRight)
        //{
        //    transform.localRotation = Quaternion.Euler(180, 0, -weaponAngle);
        //}
    }

    public void UpdateAngle(Component sender, object data)
    {
        weaponAngle = (float)data;
    }

    public void UpdateIsAttacking(Component sender, object data)
    {
        isAttacking = (bool) data;
    }

    public void Flip()
    {
        isFacingRight = !isFacingRight;
    }
}
