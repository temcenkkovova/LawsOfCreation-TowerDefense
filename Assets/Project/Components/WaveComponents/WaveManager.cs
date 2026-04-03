using UnityEngine;

public class WaveManager : MonoBehaviour
{
  public WaveController waveController;
  void Start()
  {
    if (!waveController) return;
    waveController.OnWaveFinished += HandleFinishWave;
    waveController.OnWavePreparing += HandlePreparingWave;
  }
  public void HandleFinishWave()
  {
    Debug.Log("FinishWave and set rewards");
    waveController.WavePreparing();
  }
  public void HandlePreparingWave()
  {
    Debug.Log("Preparing wave");

  }
}