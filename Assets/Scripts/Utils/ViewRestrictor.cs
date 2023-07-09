using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

[ExecuteInEditMode] [SaveDuringPlay] [AddComponentMenu("")]
public class ViewRestrictor : CinemachineExtension
{
    [Tooltip("Lock the camera's Y position to this value")]
    [SerializeField] private float _yPosition = -20;
    [SerializeField] private float _leftBorder = -10;
    [SerializeField] private float _rightBorder = -10;

    public void SetupRestrictions(float leftBorder, float rightBorder)
    {
        _leftBorder = leftBorder;
        _rightBorder = rightBorder;
    }
    
    protected override void PostPipelineStageCallback(
        CinemachineVirtualCameraBase vcam,
        CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
    {
        if (stage == CinemachineCore.Stage.Body)
        {
            var pos = state.RawPosition;
            pos.y = _yPosition;
            pos.x = Mathf.Clamp(pos.x, _leftBorder, _rightBorder);
            state.RawPosition = pos;
        }
    }
}
