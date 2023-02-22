using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    #region Exposed

    [SerializeField] int _enemyHealth = 3;

    #endregion

    #region Unity Lifecycle

    void Start()
    {
        //_gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            _enemyHealth--;
            if (_enemyHealth <= 0)
            {
                KillCounter.scoreValue += 1;
                //_gameManager.EnemyDecrement();
                Destroy(gameObject);
            }
        }
    }

    #endregion

    #region Methods



    #endregion

    #region Private & Protected

    //private GameManager _gameManager;

    #endregion

}
