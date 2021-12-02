using UnityEngine;
using TMPro;
using System.Threading;

public class FPSCounter : MonoBehaviour
{
    public int TargetFPS;

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if(Application.targetFrameRate != TargetFPS)
            Application.targetFrameRate = TargetFPS;

        TextMeshProUGUI text = GetComponent<TextMeshProUGUI>();
        int fps = Mathf.RoundToInt(1f / Time.deltaTime);

        if(fps >= 60)
            text.color = new Color32(0,255,0,255);
        else if(fps >= 30)
            text.color = new Color32(255,255,0,255);
        else if(fps >= 10)
            text.color = new Color32(255,0,0,255);

        if(timer > 0.4f)
        {
            timer = 0;
            text.text = fps.ToString();

        }

    }

    void Awake()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = TargetFPS;
    } 
}
