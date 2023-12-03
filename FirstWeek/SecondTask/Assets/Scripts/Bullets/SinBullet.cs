using UnityEngine;

public class SinBullet : Bullet
{
    private float _distanceTraveled = 0f;
    private float _waveFrequency = 1f;
    private float _maxAmplitude = 1f;
    private float _amplitudeGrowth = 0.05f;
    private float _accelerationDistance = 1.5f;

    protected override void OnInitialize()
    {
        _distanceTraveled = 0f;
    }

    protected override Vector2 Movement(Vector2 direction, float speed)
    {
        float accelerationFactor = Mathf.Clamp(_distanceTraveled / _accelerationDistance, 0.1f, 1f);
        float adjustedSpeed = speed * accelerationFactor;

        float currentAmplitude = Mathf.Min(_maxAmplitude, _amplitudeGrowth * _distanceTraveled);
        float waveY = Mathf.Sin(_distanceTraveled * _waveFrequency) * currentAmplitude;
        Vector2 waveDirection = new Vector2(-direction.y, direction.x) * waveY;

        _distanceTraveled += adjustedSpeed * Time.deltaTime;

        return adjustedSpeed * Time.deltaTime * direction + waveDirection;
    }
}