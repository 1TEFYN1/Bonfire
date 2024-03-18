using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    [SerializeField] private GameObject _pauseCanvas;
    public void Pause()
    {
        _pauseCanvas.SetActive(true);
        Time.timeScale = 0;
    }
    public void Menu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
    public void Game()
    {
        SceneManager.LoadScene(1);
    }
    public void Return()
    {
        _pauseCanvas.SetActive(false);
        Time.timeScale = 1;
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void LowQuality()
    {
        QualitySettings.SetQualityLevel(0);
    }
    public void MediumQuality()
    {
        QualitySettings.SetQualityLevel(1);
    }
    public void HighQuality()
    {
        QualitySettings.SetQualityLevel(2);
    }
    public void UltraQuality()
    {
        QualitySettings.SetQualityLevel(3);
    }
    public void FPSmax300()
    {
        Application.targetFrameRate = 300;
    }
    public void FPSmax0()
    {
        Application.targetFrameRate = 999999;
    }
}
