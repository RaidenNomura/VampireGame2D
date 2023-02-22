using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KillCounter : MonoBehaviour
{
    #region Exposed

    [SerializeField] private TextMeshProUGUI _scoreDisplay;
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
    }

    #endregion

    #region Methods

    public void AddScore()
    {
        _scoreDisplay.text = "Kills : " + _scoreValue;
    }

    #endregion

    #region Private & Protected



    #endregion
}
