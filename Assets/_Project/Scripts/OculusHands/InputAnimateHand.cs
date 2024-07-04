using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class InputAnimateHand : MonoBehaviour
{
    #region Private Field
    private float _triggerValue;
    private float _gripValue;
    #region Editor Field
    [Header("Animator")]
    [SerializeField] private Animator _handAnimatorController;
    [Header("XR Input")]
    [SerializeField] private InputActionProperty _pinchAnimationAction;
    [SerializeField] private InputActionProperty _gripAnimationAction;
    #endregion
    #endregion

    #region MonoBehaviour Callback
    private void Start()
    {
        if(_handAnimatorController == null) 
        {
            _handAnimatorController = GetComponent<Animator>();
        }
    }
    private void Update()
    {
        GetInputValues();
        SetValuesToAnimator();
    }
    #endregion

    #region Private Methods
    private void GetInputValues() 
    {
        _triggerValue = _pinchAnimationAction.action.ReadValue<float>();
        _gripValue = _gripAnimationAction.action.ReadValue<float>();
    }
    private void SetValuesToAnimator() 
    {
        if (_handAnimatorController != null) 
        {
            _handAnimatorController.SetFloat("Grip", _gripValue);
            _handAnimatorController.SetFloat("Trigger",_triggerValue);
        }
    }
    #endregion
}
