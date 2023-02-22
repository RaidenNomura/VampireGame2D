using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KillCounter : MonoBehaviour
{
    #region Exposed

    [SerializeField] private TextMeshProUGUI scoreDisplay;
    public static int scoreValue;

    #endregion

    #region Unity Lifecycle

    void Start()
    {
        scoreDisplay = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        AddScore();
    }

    #endregion

    #region Methods

    public void AddScore()
    {
        scoreDisplay.text = "Kills : " + scoreValue;
    }

    #endregion

    #region Private & Protected



    #endregion
}
