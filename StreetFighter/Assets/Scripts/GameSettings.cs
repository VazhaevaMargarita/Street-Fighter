using UnityEngine;

[CreateAssetMenu(menuName = "Game/Game Settings")]
public class GameSettings : ScriptableObject
{
    public int playerDamage = 25;
    public int enemyDamage = 10;
}