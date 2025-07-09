using UnityEngine;

[CreateAssetMenu(fileName = "NPC Dialog", menuName = "NPC Dialog/Dialog")]
public class NPCDialog : ScriptableObject
{
    public DialogLine[] lines;
    public DialogChoice[] choices;
}

[System.Serializable]
public class DialogLine
{
    public NPCActor actor;
    [TextArea(3, 5)] public string text;
}

[System.Serializable]
public class DialogChoice
{
    public string choiceText;
    public NPCDialog nextDialog;
}
