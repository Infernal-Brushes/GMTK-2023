﻿using System;
using System.Collections;
using Enemy;
using Statistics;
using UnityEngine;

public class WavesLoop : MonoBehaviour
{
    [SerializeField] private Pistol _pistol;
    [SerializeField] private Sniper _sniperPrefab;
    [SerializeField] private MachineGun _machineGunPrefab;
    [SerializeField] private Tank _tankPrefab;
    [SerializeField] private BombFactory _bombFactory;
    [SerializeField] private Score _score;
    [SerializeField] private int _shotsToStartNextWave = 5;
    [SerializeField] private float _betweenPistolShotsTime;
    [SerializeField] private Rect _screenDimensionsInWorld;

    private Transform _duck;

    public void Initialize(Transform duck)
    {
        _duck = duck ? duck : throw new ArgumentNullException(nameof(duck));
        _score.OnCountChanged += TryStartNextWave;
    }

    private void TryStartNextWave(int score)
    {
        if (score == 2400)
            StartCoroutine(StartFirstWave());

        if (score == 2300)
        {
            Sniper sniper = Instantiate(_sniperPrefab);
            sniper.Initialize(_duck);
        }

        if (score == 1800)
        {
            MachineGun machineGun = Instantiate(_machineGunPrefab);
            machineGun.Initialize(_duck, _screenDimensionsInWorld);
        }

        if (score == 1200)
        {
            Tank tank = Instantiate(_tankPrefab);
            tank.Initialize(_duck);
        }

        if (score == 600)
            StartCoroutine(CreateBombs());
    }

    public void StopWaves()
    {
        StopAllCoroutines();
    }

    private IEnumerator StartFirstWave()
    {
        _pistol.Initialize(_duck);
        int shotsCount = 0;

        while (shotsCount < _shotsToStartNextWave)
        {
            yield return new WaitForSeconds(_betweenPistolShotsTime);
            yield return StartCoroutine(_pistol.Shoot());
            shotsCount++;
        }
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