using UnityEngine;
using TMPro;

public class LivesUI : MonoBehaviour
{
    public  TMP_Text livesText;

    // Update is called once per frame
    void Update()
    {
        livesText.text = PlayerStats.Lives + " Lives";
    }
}
