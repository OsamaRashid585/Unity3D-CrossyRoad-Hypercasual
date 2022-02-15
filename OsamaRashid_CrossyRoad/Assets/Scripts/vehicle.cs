using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vehicle : MonoBehaviour
{
    [SerializeField] private float _leftMoveSpeed = 0.03f;
    void Update()
    {
        Movement();
    }
    private void Movement()
    {
        transform.Translate(Vector3.left * _leftMoveSpeed);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("End"))
        {
            Destroy(gameObject);
        }
    }
}
