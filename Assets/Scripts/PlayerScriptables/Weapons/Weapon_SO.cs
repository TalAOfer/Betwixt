using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Config/Weapon")]
public class Weapon_SO : ScriptableObject
{
    public Sprite icon;

    public Sprite sprite;

    //IN SHOOTING
    public int bulletAmount;
    [Range(0f, 360f)]
    public int spread;
    public Vector3 attackPoint;
    public float attackDuration;
    public Bullet_SO defaultBullet;

    //IN WEAPON CONTROLLER
    public float attackSpeed;
    public AnimatorOverrideController overrideAnim;
}
