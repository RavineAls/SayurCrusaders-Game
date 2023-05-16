using UnityEngine;
using TMPro;

public class WaveCounter : MonoBehaviour
{
    public TMP_Text waveCountText;

    private void Start()
    {
        UpdateWaveCount(0);
    }

    private void UpdateWaveCount(int currentWave)
    {
        waveCountText.text = "Wave: " + (currentWave).ToString();
    }

    public void WaveStart(int currentWave)
    {
        UpdateWaveCount(currentWave);
    }
}
