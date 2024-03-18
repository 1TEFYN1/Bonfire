using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonFire : MonoBehaviour
{
    [SerializeField] private ControllerScaleFire _controllerScaleFire;
    private void OnTriggerEnter()
    {
        _controllerScaleFire.AddAmountFire();
    }
}
