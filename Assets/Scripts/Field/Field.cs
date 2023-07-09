using UnityEngine;

public class Field : MonoBehaviour
{
    [SerializeField] private GameObject _borders;
    [SerializeField] private GameCamera _gameCamera;

    [SerializeField] private float _sizeForFirstWave;
    [SerializeField] private float _leftSideFirstWave;
    [SerializeField] private float _rightSideFirstWave;
    
    [SerializeField] private float _sizeBorder;
    [SerializeField] private float _leftBorder;
    [SerializeField] private float _rightBorder;

    public void SetupFirstWaveSize()
    {
        var scale = _borders.transform.localScale;
        _borders.transform.localScale = new Vector3(_sizeForFirstWave, scale.y, scale.z);
        _gameCamera.SetRestrictions(_leftSideFirstWave, _rightSideFirstWave);
    }
    
    public void SetupFullSize()
    {
        var scale = _borders.transform.localScale;
        _borders.transform.localScale = new Vector3(_sizeBorder, scale.y, scale.z);
        _gameCamera.SetRestrictions(_leftSideFirstWave, _rightSideFirstWave);
    }

    public void SetupTarget(Transform target)
    {
        _gameCamera.SetTarget(target);
    }
}
