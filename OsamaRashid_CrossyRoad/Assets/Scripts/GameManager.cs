using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public bool IsGameOver;
    public GameObject GameoverTXT;

    private void Awake()
    {
        IsGameOver = false;
    }
    private void Update()
    {
        if(IsGameOver == true)
        {
            GameoverTXT.SetActive(true);
        }
    }

}
