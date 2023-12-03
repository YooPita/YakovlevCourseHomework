using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Game : MonoBehaviour, IButtonClient
{
    [SerializeField] private Button _buttonAllBalls;
    [SerializeField] private Button _buttonOneColorOnly;
    [SerializeField] private Button _buttonReset;
    [SerializeField] private TextMeshPro _finalText;
    [SerializeField] private TextMeshPro _ruleText;
    [SerializeField] private List<GameObject> _ballsPrefabs = new();
    [SerializeField] private Vector2Int _fieldSize = new();
    [SerializeField] private float _interval = 2.0f;
    private GameRule _currentGame;

    private void Awake()
    {
        _buttonAllBalls.Subscribe(this);
        _buttonOneColorOnly.Subscribe(this);
        _buttonReset.Subscribe(this);
    }

    public void OnClick(Button button)
    {
        if (button == _buttonAllBalls)
        {
            HideButtons();
            List<Ball> balls = SpawnBalls();
            _currentGame = new RuleAllBalls(_ruleText, balls, this);
            _currentGame.StartGame();
        }
        else if (button == _buttonOneColorOnly)
        {
            HideButtons();
            List<Ball> balls = SpawnBalls();
            _currentGame = new RuleOneColorOnly(_ruleText, balls, this);
            _currentGame.StartGame();
        }
        else
        {
            ShowButtons();
            _finalText.gameObject.SetActive(false);
            _buttonReset.Disable();
        }
    }

    public void Win()
    {
        _currentGame.EndGame();
        _finalText.gameObject.SetActive(true);
        _finalText.text = "You WIN!";
        _buttonReset.Enable();
    }

    public void Lose()
    {
        _currentGame.EndGame();
        _finalText.gameObject.SetActive(true);
        _finalText.text = "You LOSE!";
        _buttonReset.Enable();
    }

    private void HideButtons()
    {
        _buttonAllBalls.Disable();
        _buttonOneColorOnly.Disable();
    }

    private void ShowButtons()
    {
        _buttonAllBalls.Enable();
        _buttonOneColorOnly.Enable();
    }

    private List<Ball> SpawnBalls()
    {
        float offsetX = _fieldSize.x * _interval / 2 - _interval / 2;
        float offsetY = _fieldSize.y * _interval / 2 - _interval / 2;

        List<Ball> result = new();
        for (int i = 0; i < _fieldSize.x; i++)
        {
            for (int j = 0; j < _fieldSize.y; j++)
            {
                Vector3 spawnPosition = new Vector3(i * _interval - offsetX, j * _interval - offsetY, 0);
                result.Add(CreateBall(spawnPosition));
            }
        }
        return result;
    }

    private Ball CreateBall(Vector3 position)
    {
        int randomIndex = Random.Range(0, _ballsPrefabs.Count);
        GameObject ballPrefab = _ballsPrefabs[randomIndex];
        Ball ball = Instantiate(ballPrefab, position, Quaternion.identity).GetComponent<Ball>();
        return ball;
    }
}
