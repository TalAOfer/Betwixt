using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public InterimBulletData InterimBulletData;
    public PlayerChoices playerChoices;
    public EnemyStatManager enemyStatManager;

    public GameObject YouWin;
    public GameObject YouLost;

    public GameEvent OnPlayerWin;

    private float timer;
    public float minutesToWin = 1f;

    void Start()
    {
        Pooler.ClearPools();
        FMODUnity.RuntimeManager.PlayOneShot("event:/Music",GetComponent<Transform>().position);  
        InterimBulletData.Init(playerChoices.chosenWeapon.defaultBullet);
        enemyStatManager.Init(1, false, false);
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer > 60 * minutesToWin)
        {
            OnPlayerWin.Raise();

            var foundEnemyObjects = FindObjectsOfType<Enemy>();
            foreach (Enemy enemy in foundEnemyObjects)
            {
                enemy.KillSelf();
            }

            YouWin.SetActive(true);
        };
    }


    public void EnableYouLost()
    {
        YouLost.SetActive(true);
    }
}
