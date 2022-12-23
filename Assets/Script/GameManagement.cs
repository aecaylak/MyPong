using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

public class GameManagement : MonoBehaviour
{
    public static GameManagement Instance { get; private set; } //Singleton
    [SerializeField] private Button _button;
    
    [SerializeField] private TextMeshProUGUI _textGameOver;
    [SerializeField] private TextMeshProUGUI _textStart;
    [SerializeField] private TextMeshProUGUI _scoreText;
    private int score;
    private int carpan = 1;
    private void Awake()
    {
        Instance = this;
    }

    public void OnClick_StartButton()
    {
        score = 0;
        carpan = 1;
        _scoreText.text = score.ToString();
        _button.enabled = false;
        _textGameOver.enabled = false;
        _textStart.enabled = false;
        BallMovement.Instance.OnStart(); //ballmovement deki onstart calısacak.
    }

    public void Gameover()
    {
        
        _button.enabled = true;
        Debug.Log("go");
        _textGameOver.enabled = true;
        _textStart.enabled = false;
    }

    public void YouWin()
    {
        carpan++;
        BallMovement.Instance.OnStart();
    }

    public void Score()
    {
        
        score = score + (1 * carpan);
        _scoreText.text = score.ToString();

    }

}

