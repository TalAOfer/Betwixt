using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPoint : MonoBehaviour
{
    public void Rotate(float rotation)
    {
        transform.Rotate(rotation,0,0);
    }
}
