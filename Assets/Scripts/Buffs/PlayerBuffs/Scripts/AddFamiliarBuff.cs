using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Powerups/PlayerBuffs/AddFamiliarBuff")]
public class AddFamiliarBuff : PowerupEffect
{
    public GameObject familiarPrefab;
    private GameObject familiarInstance;
    public override void Apply(GameObject target)
    {
        familiarInstance = Instantiate(familiarPrefab, target.transform);
        familiarInstance.transform.parent = target.transform;
    }
}
