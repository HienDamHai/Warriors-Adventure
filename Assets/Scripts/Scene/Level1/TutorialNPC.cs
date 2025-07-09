using UnityEngine;

public class TutorialNPC : MonoBehaviour
{
    public Component dialogIndicator;
    public NPCDialog dialog;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collision detected with: " + collision.gameObject.name);
        if (collision.CompareTag("Player"))
        {
            dialogIndicator.gameObject.SetActive(false);
            var dialogManger = DialogManager.Instance;
            if (!dialogManger.isDialogActive)
            {
               dialogManger.StartDialog(dialog);
            }
        }
    }
}
