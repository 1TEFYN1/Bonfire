using TMPro;
using UnityEngine;

public class LogCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textCountLog;

    private int _countLog { get; set; }

    public void AddLog()
    {
        _countLog += Random.Range(2, 6);
        RefreshTextLog();
    }
    public void RefreshTextLog()
    {
        _textCountLog.text = _countLog.ToString();
    }
    public void TakeLog(int count)
    {
        if(_countLog > 0)
        {
            _countLog -= count;
            RefreshTextLog();
        }
        
    }
    public int GetAmountLog()
    {
        return _countLog;
    }
}
