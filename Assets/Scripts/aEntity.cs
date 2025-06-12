using Unity.VisualScripting;
using UnityEngine;

public abstract class aEntity : MonoBehaviour
{

    [Header("Basic Stats")]

    [SerializeField] protected float MaxHealth = 100;
    protected float Health { get; set; } = 0;
    [SerializeField] protected float Attack = 10;
    [SerializeField] protected float Shield = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Health = MaxHealth;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public bool Damage(float dmg)
    {

        if (dmg > 0)
        {
            // Todo Calculations for def and health

            Shield -= dmg;

            if (Shield < 0)
            {
                dmg = -Shield;
                Shield = 0;
            }

            Health -= dmg;
        }


        return false;
    }

    public bool Heal(float heal)
    {

        // * Debuff Checks

        if (heal > 0)
        {
            Health += heal;
        }

        return false;

    }

    protected bool Die()
    {

        // Todo if player can revive return false

        return true;
    }

}
