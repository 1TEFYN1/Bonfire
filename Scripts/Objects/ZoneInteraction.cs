using TMPro;
using UnityEngine;

public class ZoneInteraction : MonoBehaviour
{
    [SerializeField] private TreesController _treeController;
    [SerializeField] private LogCounter _logCounter;
    [SerializeField] private GameObject _textPressE;
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Tree"))
        {
            if (Input.GetKey(KeyCode.E))
            {
                _logCounter.AddLog();
                _treeController.DestroyTree(collision.gameObject); ;
            }
            _textPressE.SetActive(true);
        }
        else _textPressE.SetActive(false);
    }
    private void OnCollisionExit(Collision collision)
    {
        _textPressE.SetActive(false);
    }
}
