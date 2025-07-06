using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkillSlot : MonoBehaviour
{
    public List<SkillSlot> prerequisiteSkillSlots;
    public SkillSO skillSO;

    public int currentLevel;
    public bool isUnlocked;
    public TMP_Text skillLevelText;
    public Image skillIcon;
    public Button skillButton;

    public static event Action<SkillSlot> OnAbilityPointSpent;
    public static event Action<SkillSlot> OnSkillMaxed;

    private void OnValidate()
    {
        // Tự gán Button nếu quên
        if (skillButton == null)
            skillButton = GetComponent<Button>();

        // Cảnh báo nếu thiếu thông tin
        if (skillSO == null)
            Debug.LogWarning($"[SkillSlot] {name}: Missing SkillSO");

        if (skillIcon == null || skillLevelText == null)
            Debug.LogWarning($"[SkillSlot] {name}: Missing UI component(s)");

        SafeUpdateUI();
    }

    public void TryUpgradeSkill()
    {
        if (isUnlocked && currentLevel < skillSO.maxLevel)
        {
            currentLevel++;
            OnAbilityPointSpent?.Invoke(this);
            if (currentLevel >= skillSO.maxLevel)
            {
                OnSkillMaxed?.Invoke(this);
            }
            SafeUpdateUI();
        }
    }

    public bool CanUnlockSkill()
    {
        foreach (SkillSlot slot in prerequisiteSkillSlots)
        {
            if (!slot.isUnlocked || slot.currentLevel < slot.skillSO.maxLevel)
                return false;
        }
        return true;
    }

    public void Unlock()
    {
        isUnlocked = true;
        SafeUpdateUI();
    }

    private void SafeUpdateUI()
    {
        if (skillSO == null || skillIcon == null || skillLevelText == null || skillButton == null)
        {
            Debug.LogWarning($"[SkillSlot] {name}: Cannot update UI due to missing references.");
            return;
        }

        skillIcon.sprite = skillSO.skillIcon;

        if (isUnlocked)
        {
            skillLevelText.text = $"{currentLevel}/{skillSO.maxLevel}";
            skillIcon.color = Color.white;
            skillButton.interactable = currentLevel < skillSO.maxLevel;
        }
        else
        {
            skillLevelText.text = "Locked";
            skillIcon.color = Color.grey;
            skillButton.interactable = false;
        }
    }
}
