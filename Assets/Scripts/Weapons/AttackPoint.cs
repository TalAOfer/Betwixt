using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPoint : MonoBehaviour
{
    [SerializeField] private PlayerChoices playerChoices;

    private void Start()
    {
        UpdateAttackPoint();
    }

    public void Rotate(float rotation)
    {
        transform.Rotate(rotation,0,0);
    }

    public void UpdateAttackPoint()
    {
        transform.localPosition = playerChoices.chosenWeapon.attackPoint;
    }
}
