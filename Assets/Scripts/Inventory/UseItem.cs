using System.Collections;
using UnityEngine;

public class UseItem : MonoBehaviour
{
    public void ApplyItemEffect(ItemSO itemSO)
    {
        if (itemSO.currentHealth > 0)
        {
            StatsManager.Instance.UpdateHealth(itemSO.currentHealth);
        }
        if (itemSO.maxHealth > 0)
        {
            StatsManager.Instance.UpdateMaxHealth(itemSO.maxHealth);
        }
        if (itemSO.damage > 0)
        {
            StatsManager.Instance.UpdateDamage(itemSO.damage);
        }

        if (itemSO.speed > 0)
        {
            StatsManager.Instance.UpdateRunSpeed(itemSO.speed);
        }

        if (itemSO.duration > 0)
        {
            StartCoroutine(EffectTimer(itemSO, itemSO.duration));
        }

        if (itemSO.exp > 0)
        {
            ExpManager.Instance.GainExperience(itemSO.exp, 0);
        }
    }
    private IEnumerator EffectTimer(ItemSO itemSO, float duration)
    {
        Debug.Log("Effect will last for: " + duration + " seconds");
        yield return new WaitForSeconds(duration);

        if (itemSO.currentHealth > 0)
        {
            StatsManager.Instance.UpdateHealth(-itemSO.currentHealth);
        }
        if (itemSO.maxHealth > 0)
        {
            StatsManager.Instance.UpdateMaxHealth(-itemSO.maxHealth);
        }
        if (itemSO.speed > 0)
        {
            StatsManager.Instance.UpdateRunSpeed(-itemSO.speed);
        }
        if (itemSO.damage > 0)
        {
            StatsManager.Instance.UpdateDamage(-itemSO.damage);
        }
    }
}

