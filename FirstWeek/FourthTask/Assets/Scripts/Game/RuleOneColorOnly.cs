using System;
using System.Collections.Generic;
using TMPro;

public class RuleOneColorOnly : GameRule
{
    private int CurrentColorBallsCount => BallTypeCounts[_type];

    private int _count = 0;
    private BallType _type;

    public RuleOneColorOnly(TextMeshPro ruleText, List<Ball> balls, Game game) : base(ruleText, balls, game)
    {
        GetRandomBallType();
        ruleText.text = $"Destroy ONLY {_type} balls!";
    }

    public override void OnClick(BallType type)
    {
        if (type != _type)
            Lose();
        _count++;
        if (CurrentColorBallsCount <= _count)
            Win();
    }

    private void GetRandomBallType()
    {
        Random random = new Random();
        BallType[] values = (BallType[])Enum.GetValues(typeof(BallType));
        _type = values[random.Next(values.Length)];
    }
}