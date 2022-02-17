using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject _vehicle;

    [SerializeField] private float _zRight = 0f;
    [SerializeField] private float _zLeft = 10f;

     private Vector3 _rightPos;
     private Vector3 _leftPos;

    private void Start()
    {
         InvokeRepeating("VehicleRightSideSpawn", 3, 5);
         InvokeRepeating("VehicleLeftSideSpawn", 3, 5);
    }
    private void VehicleRightSideSpawn()
    {
        _rightPos = new Vector3(35, 1, _zRight);
        Instantiate(_vehicle, _rightPos, Quaternion.identity);
    }
    private void VehicleLeftSideSpawn()
    {
        _leftPos = new Vector3(-35, 1, _zLeft);
        Instantiate(_vehicle, _leftPos, Quaternion.Euler(0f, 180f, 0f));
    }
}
