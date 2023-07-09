using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class GameCamera : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera _virtualCamera;
    [SerializeField] private ViewRestrictor _restrictor;
    
    private Transform _target;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetRestrictions(float leftBorder, float rightBorder)
    {
        _restrictor.SetupRestrictions(leftBorder, rightBorder);
    }

    public void SetTarget(Transform target)
    {
        _target = target;
        _virtualCamera.Follow = _target;
        _virtualCamera.LookAt = _target;
    }
}
