using TMPro;
using UnityEngine;


/* Это тестовая компонента , в конца надо удалить */
public class WaveStateUI : MonoBehaviour
{
  public TMP_Text textField;
  public GameObject rulesPanel;
  public WaveController waveController;
  void Start()
  {
    ShowGameState(waveController.CurrentWaveState);

    waveController.OnWaveStateChanged += ShowGameState;
    waveController.OnWavePreparing += OpenRules;
  }

  void OnDisable()
  {
    waveController.OnWaveStateChanged -= ShowGameState;
  }
  public void OpenRules()
  {

  }
  public void ShowGameState(WaveController.WaveState state)
  {
    textField.text = state.ToString();

    bool active = state == WaveController.WaveState.Preparing;
    rulesPanel.SetActive(active);
  }
}