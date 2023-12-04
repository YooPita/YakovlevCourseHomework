using System;
using UnityEngine;

public class Level
{
    public event Action Defeat;

    public void Start()
    {
        //Логика старта игры
        Debug.Log("Start level");
    }

    public void Restart()
    {
        //Логика очистки уровни
        Start();
    }

    public void OnDefeat()
    {
        //логика остановки игры
        Defeat?.Invoke();
    }
}

