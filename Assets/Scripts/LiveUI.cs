using TMPro;
using UnityEngine;

public class LiveUI : MonoBehaviour
{

    public TMP_Text liveText;
    
    public void UpdateLive(int live)
    {
        Debug.Log("UpdateLive: " + live);
        liveText.SetText(live.ToString());
    }


}