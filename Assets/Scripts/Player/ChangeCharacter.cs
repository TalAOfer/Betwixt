using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCharacter : MonoBehaviour
{

    private Animator anim;
    private Player playerScript;
    private void Start()
    {
        anim = GetComponent<Animator>();
        playerScript = GetComponent<Player>();
    }

    public void UpdateCharacter(Player_SO player)
    {
        
    }
}
