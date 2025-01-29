using Unity.VisualScripting;
using UnityEngine;

public class PlayerDestructable : MonoBehaviour, I_Damagable
{
    [SerializeField] float health = 20;

    bool destroyed = false;

    public float Health { get { return health; } set { health = (value < 0) ? 0 : value; } }

    void I_Damagable.ApplyDamage(float damage)
    {
        if (destroyed) return;

        health -= damage;
    }
}
