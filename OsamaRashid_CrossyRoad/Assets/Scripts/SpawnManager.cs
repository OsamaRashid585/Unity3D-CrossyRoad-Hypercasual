using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject _vehicle;
     private float _xRight = 35f;
     private float _xLeft = -35f;

    [SerializeField] private float _zRight = 0f;
    [SerializeField] private float _zLeft = 10f;

    [SerializeField] private int _spawnTimeR;
    [SerializeField] private int _spawnTimeL;

     private Vector3 _rightPos;
     private Vector3 _leftPos;
     private GameManager _gameManager;

    private void Awake()
    {
        _gameManager = FindObjectOfType<GameManager>();
    }

    private void Start()
    {

         InvokeRepeating("VehicleRightSideSpawn", 3, _spawnTimeR);
         InvokeRepeating("VehicleLeftSideSpawn", 3, _spawnTimeL);
    }
    private void VehicleRightSideSpawn()
    {
        if(_gameManager.IsGameOver != true)
        {
            _rightPos = new Vector3(_xRight, 1, _zRight);
            Instantiate(_vehicle, _rightPos, Quaternion.identity);
        }
    }
    private void VehicleLeftSideSpawn()
    {
        if(_gameManager.IsGameOver != true)
        {
            _leftPos = new Vector3(_xLeft, 1, _zLeft);
            Instantiate(_vehicle, _leftPos, Quaternion.Euler(0f, 180f, 0f));
        }
    }
}
