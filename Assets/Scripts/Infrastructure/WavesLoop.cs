using System;
using System.Collections;
using GMTK2023.Enemy;
using UnityEngine;

public class WavesLoop : MonoBehaviour
{
    [SerializeField] private Pistol _pistol;
    [SerializeField] private int _shotsToStartNextWave = 5;
    [SerializeField] private float _betweenPistolShotsTime;
    
    private Transform _duck;

    public void Initialize(Transform duck)
    {
        _duck = duck ? duck : throw new ArgumentNullException(nameof(duck));
        _pistol.Initialize(_duck);
        StartCoroutine(StartFirstWave());
    }

    private IEnumerator StartFirstWave()
    {
        int shotsCount = 0;

        while (shotsCount < _shotsToStartNextWave)
        {
            yield return new WaitForSeconds(_betweenPistolShotsTime);
            yield return StartCoroutine(_pistol.Shoot());
            shotsCount++;
        }
    }
}