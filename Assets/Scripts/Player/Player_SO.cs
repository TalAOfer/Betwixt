using UnityEngine;

[CreateAssetMenu(menuName = "PlayerData")]
public class Player_SO : ScriptableObject
{
    public GameObject playerPrefab;
    public Sprite icon;

    public AnimatorOverrideController overrideAnim;
    public float movementSpeed;
    public int hp;
    public Vector2 hitboxSize;
}
