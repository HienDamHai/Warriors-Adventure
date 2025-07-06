using UnityEngine;

public class SkillManager : MonoBehaviour
{
    private void OnEnable()
    {
        SkillSlot.OnAbilityPointSpent += HandleAbilityPointSpent;
    }

    private void OnDisable()
    {
        SkillSlot.OnAbilityPointSpent -= HandleAbilityPointSpent;
    }

    private void HandleAbilityPointSpent(SkillSlot slot)
    {
        string skillName = slot.skillSO.skillName;
        switch(skillName)
        {
            case "Max Health Boost":
                StatsManager.Instance.UpdateMaxHealth(1);
                break;
            case "Damage Boost":
                StatsManager.Instance.UpdateDamage(1);
                break;
            case "Attack Speed Boost":
                StatsManager.Instance.UpdateAttackSpeed(1); 
                break;
            case "Run Speed Boost":
                StatsManager.Instance.UpdateRunSpeed(0.5f);
                break;
            default:
                Debug.LogWarning("Unknow skill: " + skillName);
                break; 
        }
    }
}
