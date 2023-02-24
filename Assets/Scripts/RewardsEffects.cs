using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventVector3 : UnityEvent<Vector3>{}

public class RewardsEffects : MonoBehaviour
{
    #region Exposed

    public EventVector3 MonEvent; //MonEvent = ShootEnemyEvent
    public UnityEvent toto;
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private float _speedBullet = 30;

    #endregion

    #region Unity Lifecycle

    private void Awake()
    {

    }

    private void Start()
    {
        MonEvent = new EventVector3();
    }

    #endregion

    #region Methods

    public void LogMessage()
    {
        Debug.Log("Invoke done");
    }

    public void ShootEnemy(Vector3 position)
    {
        _bullet = Instantiate(_bulletPrefab, position, transform.rotation);
        _bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(-1, 2), Random.Range(-1, 2)) * _speedBullet;
        Destroy(_bullet, 3);
    }

    public void UpgradeShootEnemy()
    {
        //MonEvent.AddListener(ShootEnemy);
        toto.AddListener(LogMessage);
        Debug.Log("Listener");
    }

    #endregion

    #region Private & Protected

    private GameObject _bullet;
    private Vector2 _dirRandom;

    #endregion
}
