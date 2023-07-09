using System;
using System.Collections;
using Enemy;
using GMTK2023.Enemy;
using Statistics;
using TMPro;
using UnityEngine;

public class WavesLoop : MonoBehaviour
{
    [SerializeField] private Pistol _pistol;
    [SerializeField] private Sniper _sniper;
    [SerializeField] private Tank _tank;
    [SerializeField] private BombFactory _bombFactory;
    [SerializeField] private Score _score;
    [SerializeField] private Field _field;
    [SerializeField] private int _shotsToStartNextWave = 5;
    [SerializeField] private float _betweenPistolShotsTime;

    private Transform _duck;

    public void Initialize(Field field, Transform duck)
    {
        _field = field;
        _duck = duck ? duck : throw new ArgumentNullException(nameof(duck));
        _score.OnCountChanged += TryStartNextWave;
    }

    private void TryStartNextWave(int score)
    {
        if (score == 2400)
            StartCoroutine(StartFirstWave());

        if (score == 2300)
            _sniper.Initialize(_duck);

        if (score == 1800)
        {
            //artillery
        }

        if (score == 1200)
            _tank.Initialize(_duck);

        if (score == 600)
            StartCoroutine(CreateBombs());
    }

    public void StopWaves()
    {
        StopAllCoroutines();
    }

    private IEnumerator StartFirstWave()
    {
        _field.SetupFirstWaveSize();
        _pistol.Initialize(_duck);
        int shotsCount = 0;

        while (shotsCount < _shotsToStartNextWave)
        {
            yield return new WaitForSeconds(_betweenPistolShotsTime);
            yield return StartCoroutine(_pistol.Shoot());
            shotsCount++;
        }
        
        _field.SetupFullSize();
    }

    private IEnumerator CreateBombs()
    {
        while (true)
        {
            yield return new WaitForSeconds(10);
            _bombFactory.Create();
        }
    }

    private void OnDestroy()
    {
        _score.OnCountChanged -= TryStartNextWave;
    }
}