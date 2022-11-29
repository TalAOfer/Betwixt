using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timebending : MonoBehaviour
{
    private bool isTimebend;
    private Animator anim;
    private bool isFacingRight = true;

    [SerializeField] private GameObject echoPrefabRight;
    [SerializeField] private GameObject echoPrefabLeft;
    private GameObject echoPrefab;

    private float timer;

    private void Start()
    {
        anim = GetComponent<Animator>();
        echoPrefab = echoPrefabRight;

    }
    public void OnTimebend(Component sender, object data)
    {
        isTimebend = (bool)data;

        if (isTimebend)
        {
            Time.timeScale = 0.5f;
            anim.speed = 2f;
        } else
        {
            Time.timeScale = 1.0f;
            anim.speed = 1f;
        }
    }

    private void Update()
    {
        if (isTimebend)
        {
            timer += Time.deltaTime;

            if (timer > 0.10f)
            {
                Pooler.Spawn(echoPrefab, transform.position, transform.rotation);
                timer = 0;
            }
        }
        
    }

    public void UpdateFacingDirection()
    {
        isFacingRight = !isFacingRight;

        if (isFacingRight)
        {
            echoPrefab = echoPrefabRight;
        } else
        {
            echoPrefab = echoPrefabLeft;
        }
    }
}
