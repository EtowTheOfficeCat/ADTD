using UnityEngine;
using TMPro;

public class NewWaveUI : MonoBehaviour
{
    private bool isTimerActive; 
    private float timer;
    private TextMeshProUGUI newWaveText;

    void Awake()
    {
        newWaveText = GetComponentInChildren<TextMeshProUGUI>(true);
    }

    private void Update()
    {
        if (!isTimerActive){ return; }

        timer -= Time.deltaTime;
        newWaveText.SetText($"next Wave in:{(int)timer}");
        if (timer <= 0)
        {
            isTimerActive = false;
            newWaveText.gameObject.SetActive(false);
            
        }
    }

    public void SchowCountDown(float startTime)
    {
        timer = startTime; 
        isTimerActive = true;
        newWaveText.gameObject.SetActive(true);

    }
}
