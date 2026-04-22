using UnityEngine;

public class Health : MonoBehaviour
{
    
    public int CalcHealth(int damage, int currentHealth)
    {
        currentHealth -= damage;
        return currentHealth;
    }
}
