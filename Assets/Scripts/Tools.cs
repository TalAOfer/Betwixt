using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Tools
{
    public static bool didSucceed(int chance)
    {
        int rand = Random.Range(0, 100);
        return (chance > rand);
    }
}
