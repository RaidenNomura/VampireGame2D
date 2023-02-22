using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManagement : MonoBehaviour
{

    #region Exposed



    #endregion

    #region Unity Lifecycle

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }

    #endregion

    #region Methods



    #endregion

    #region Private & Protected



    #endregion

}
