using System.Collections.Generic;
using TMPro;

public abstract class GameRule : IBallClient
{
    protected readonly Dictionary<BallType, int> BallTypeCounts = new();

    private readonly TextMeshPro _ruleText;
    private readonly List<Ball> _balls;
    private readonly Game _game;

    public GameRule(TextMeshPro ruleText, List<Ball> balls, Game game)
    {
        _ruleText = ruleText;
        _balls = balls;
        _game = game;
    }

    public abstract void OnClick(BallType type);

    public void StartGame()
    {
        _ruleText.gameObject.SetActive(true);
        foreach (var ball in _balls)
        {
            ball.Subscribe(this);
            if (BallTypeCounts.ContainsKey(ball.Type))
                BallTypeCounts[ball.Type]++;
            else
                BallTypeCounts[ball.Type] = 1;
        }
    }

    public void EndGame()
    {
        _ruleText.gameObject.SetActive(false);
        foreach (var ball in _balls)
            ball.Remove();
    }

    protected void Win() => _game.Win();

    protected void Lose() => _game.Lose();
}