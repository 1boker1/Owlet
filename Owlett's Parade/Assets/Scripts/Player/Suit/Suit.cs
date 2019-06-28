using UnityEngine;
using System.Collections;

public class Suit : MonoBehaviour
{
    public enum SuitType { NONE, LIGHT, HEAVY, CC }
    public SuitType suitType;

    public MonoBehaviour passive;
    public Skill attack;
    public Skill ability1;
    public Skill ability2;

    public Animator suitAnimator;

    public bool isInChamber = true;

    [SerializeField] private int maxArmor;
    [SerializeField] private int currentArmor;

    public int MaxArmor { get => maxArmor; set => maxArmor = value; }
    public int CurrentArmor { get => currentArmor; set => currentArmor = value; }

    [SerializeField] private Controller controller;

    public IHealth suitHealthSystem;

    private void Start()
    {
        suitHealthSystem = GetComponent<IHealth>();

    }

    public int DecreaseArmor(int amount)
    {
        if (amount > currentArmor)
        {
            amount -= currentArmor;
            currentArmor = 0;
        }
        else
        {
            currentArmor -= amount;
        }

        return amount;
    }

    public void EquipSuit()
    {
        controller.currentSuit = this;
        controller.suitAnimator = suitAnimator;

        if (suitHealthSystem == null) suitHealthSystem = GetComponent<IHealth>();

        suitHealthSystem.GetHealed(suitHealthSystem.MaxHealth);

        gameObject.SetActive(true);
    }

    public void HealSuit(bool full, int amount)
    {
        currentArmor = full ? maxArmor : currentArmor;

        suitHealthSystem.GetHealed(full ? suitHealthSystem.MaxHealth : amount);
    }
}
