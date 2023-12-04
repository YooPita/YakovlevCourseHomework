using UnityEngine;

[CreateAssetMenu(fileName = "CharacterConfig", menuName = "Configs/CharacterConfig")]
public class CharacterConfig : ScriptableObject
{
    [SerializeField] private WalkingStateConfig _runningStateConfig;
    [SerializeField] private WalkingStateConfig _walkingStateConfig;
    [SerializeField] private AirborneStateConfig _fastAirborneStateConfig;
    [SerializeField] private AirborneStateConfig _slowAirborneStateConfig;

    public AirborneStateConfig FastAirborneStateConfig => _fastAirborneStateConfig;
    public AirborneStateConfig SlowAirborneStateConfig => _slowAirborneStateConfig;
    public WalkingStateConfig RunningStateConfig => _runningStateConfig;
    public WalkingStateConfig WalkingStateConfig => _walkingStateConfig;
}
