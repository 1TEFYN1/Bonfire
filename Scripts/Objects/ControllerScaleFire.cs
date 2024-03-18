using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControllerScaleFire : MonoBehaviour
{
    [SerializeField] private LogCounter _treeCounter;
    [SerializeField] private Image _scaleFireImage;

    public float _amountFire = 100f;
    private float _amountFirePerSecond = 2f; //seconds = _amountFire / 2 = 50
            
    private void Update()
    {
        UpdateScale();
    }
    private void UpdateScale()
    {
        if (_amountFire >= 0)
        {
            _scaleFireImage.fillAmount = _amountFire / 100f;
            _amountFire -= _amountFirePerSecond * Time.deltaTime;
        }
    }
    public void AddAmountFire()
    {
        int _amountLogNeed = (int)(100 - _amountFire);
        int _amountLogHave = _treeCounter.GetAmountLog() * 5;
        if (_amountLogHave <= _amountLogNeed)
        {
            _amountFire += _amountLogHave * 1f;
            _treeCounter.TakeLog(_amountLogHave / 5);
        }
        if (_amountLogHave >= _amountLogNeed)
        {
            _amountFire += _amountLogNeed * 1f;
            _treeCounter.TakeLog(_amountLogNeed / 5);
        }

    }
    private void FixedUpdate()
    {
        if (_amountFire <= 0)
        {
            SceneManager.LoadScene(1);
        }
    }

}
