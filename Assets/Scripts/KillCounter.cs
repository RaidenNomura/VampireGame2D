using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KillCounter : MonoBehaviour
{
    #region Exposed

    [SerializeField] private TextMeshProUGUI _scoreDisplay;
    [SerializeField] GameObject _bonusPanel;
    public static int _scoreValue = 0;

    #endregion

    #region Unity Lifecycle

    void Start()
    {
        _scoreDisplay = GetComponent<TextMeshProUGUI>();
        _scoreValue = 0;
    }

    private void Update()
    {
        AddScore();
        if (_scoreValue == count)
        {
            PauseGame();
            count += 10;
        }
    }

    #endregion

    #region Methods

    public void AddScore()
    {
        _scoreDisplay.text = "Kills : " + _scoreValue;
    }

    private void PauseGame()
    {
        Time.timeScale = 0f;
        _bonusPanel.SetActive(true);
    }

    public void PlayGame()
    {
        Time.timeScale = 1f;
        _bonusPanel.SetActive(false);
    }

    #endregion

    #region Private & Protected

    private int count = 5;

    #endregion
}
