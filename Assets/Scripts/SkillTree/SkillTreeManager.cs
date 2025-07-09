using TMPro;
using UnityEngine;

public class SkillTreeManager : MonoBehaviour
{
    public SkillSlot[] skillSlots;
    public TMP_Text pointsText;
    public int availablePoints;

    private void OnEnable()
    {
        SkillSlot.OnAbilityPointSpent += HandleAbilityPointsSpent;
        SkillSlot.OnSkillMaxed += HandleSkillMaxed;
        ExpManager.OnLevelUp += UpdateAbilityPoints;
    }

    private void OnDisable()
    {
        SkillSlot.OnAbilityPointSpent -= HandleAbilityPointsSpent;
        SkillSlot.OnSkillMaxed -= HandleSkillMaxed;
        ExpManager.OnLevelUp -= UpdateAbilityPoints;
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

        UpdateAbilityPoints(0);
    }

    private void CheckAvailablePoints(SkillSlot slot)
    {
        Debug.Log($"Checking available points for {slot.name}. Current points: {availablePoints}");
        if (availablePoints > 0)
        {
            slot.TryUpgradeSkill();
        }
    }

    private void HandleAbilityPointsSpent(SkillSlot skillSlot)
    {
        if (availablePoints > 0)
        {
            UpdateAbilityPoints(-1);
        }
    }

    private void HandleSkillMaxed(SkillSlot skillSlot)
    {
        foreach (SkillSlot slot in skillSlots)
        {
            if (!slot.isUnlocked && slot.CanUnlockSkill())
            {
                slot.Unlock(); // đã được bảo vệ bằng SafeUpdateUI
            }
        }
    }

    public void UpdateAbilityPoints(int amount)
    {
        availablePoints += amount;
        pointsText.text = "Points " + availablePoints;
    }
}
