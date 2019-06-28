using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuitHealthSystem : MonoBehaviour, IHealth
{
    [SerializeField] private int maxHealth;
    [SerializeField] private int currentHealth;

    public int MaxHealth { get => maxHealth; set => maxHealth = value; }
    public int CurrentHealth { get => currentHealth; set => currentHealth = value; }

    [SerializeField] private Controller controller;

    public void GetDamaged(int amount)
    {
        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        if (currentHealth == 0) OutOfHealth();
    }

    public void GetHealed(int amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
    }

    public void OutOfHealth()
    {
        controller.currentSuit = null;

        if (controller.chamberSuit != null) controller.chamberSuit.EquipSuit();

        gameObject.SetActive(false);
    }

}
