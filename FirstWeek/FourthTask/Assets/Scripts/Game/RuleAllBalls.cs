using System.Collections.Generic;
using System.Linq;
using TMPro;

public class RuleAllBalls : GameRule
{
    private int _totalBallsCount = -1;
    private int _count = 0;

    public RuleAllBalls(TextMeshPro ruleText, List<Ball> balls, Game game) : base(ruleText, balls, game)
    {
        ruleText.text = "Destroy ALL balls!";
    }

    public override void OnClick(BallType type)
    {
        if (_totalBallsCount == -1)
            _totalBallsCount = BallTypeCounts.Values.Sum();
        _count++;
        if (_totalBallsCount <= _count)
            Win();
    }
}