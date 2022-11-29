using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEcho : MonoBehaviour
{
    float timer = 0;

    private void OnEnable()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.unscaledDeltaTime;

        if (timer > 0.5)
        {
            Pooler.Despawn(gameObject);
        }
    }
}
