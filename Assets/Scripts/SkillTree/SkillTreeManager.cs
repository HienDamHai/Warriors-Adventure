using TMPro;
using UnityEngine;

public class SkillTreeManager : MonoBehaviour
{
    public static SkillTreeManager Instance { get; private set; }

    public SkillSlot[] skillSlots;
    public TMP_Text pointsText;
    public int availablePoints = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void OnEnable()
    {
        SkillSlot.OnAbilityPointSpent += HandleAbilityPointsSpent;
        SkillSlot.OnSkillMaxed += HandleSkillMaxed;
    }

    private void OnDisable()
    {
        SkillSlot.OnAbilityPointSpent -= HandleAbilityPointsSpent;
        SkillSlot.OnSkillMaxed -= HandleSkillMaxed;
    }

    private void Start()
    {
        foreach (SkillSlot slot in skillSlots)
        {
            if (slot == null)
            {
                Debug.LogWarning("[SkillTreeManager] One of the skillSlots is null.");
                continue;
            }

            if (slot.skillButton != null)
            {
                SkillSlot currentSlot = slot;
                currentSlot.skillButton.onClick.AddListener(() => CheckAvailablePoints(currentSlot));
            }
            else
            {
                Debug.LogWarning($"[SkillTreeManager] {slot.name} is missing skillButton.");
            }
        }

        UpdatePointsText();
    }

    private void CheckAvailablePoints(SkillSlot slot)
    {
        if (availablePoints > 0)
        {
            slot.TryUpgradeSkill();
        }
    }

    private void HandleAbilityPointsSpent(SkillSlot skillSlot)
    {
        if (availablePoints > 0)
        {
            availablePoints -= 1;
            UpdatePointsText();
        }
    }

    private void HandleSkillMaxed(SkillSlot skillSlot)
    {
        foreach (SkillSlot slot in skillSlots)
        {
            if (!slot.isUnlocked && slot.CanUnlockSkill())
            {
                slot.Unlock();
            }
        }
    }

    public void AddPoints(int amount)
    {
        availablePoints += amount;
        UpdatePointsText();
    }

    private void UpdatePointsText()
    {
        pointsText.text = "Points: " + availablePoints;
    }
}
