using UnityEngine;

public class Waiter
{
    private float _endTime = 0;

    public void Wait(float seconds)
    {
        _endTime = Time.time + seconds;
    }

    public bool Check()
    {
        return Time.time >= _endTime;
    }
}