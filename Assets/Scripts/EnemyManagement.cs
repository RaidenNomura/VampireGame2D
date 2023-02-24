using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyManagement: MonoBehaviour
{

    #region Exposed

    [SerializeField] private int _enemyHealth = 3;
    [SerializeField] private float _enemySpeed = 3;
    public RewardsEffects RewardsEffects;

    #endregion

    #region Unity Lifecycle

    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
        _collider = GetComponent<BoxCollider2D>();
    }

    private void Start()
    {
        _moveTarget = GameObject.Find("Player").transform;
    }

    private void Update()
    {
        if (_enemyHealth > 0)
            transform.position = Vector2.MoveTowards(transform.position, _moveTarget.position, _enemySpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            _enemyHealth--;
            if (_enemyHealth <= 0)
            {
                KillCounter._scoreValue += 1;
                _collider.isTrigger = true;
                _animator.SetTrigger("isDead");

                RewardsEffects.ShootEnemy(transform.position);
                //RewardsEffects.MonEvent.Invoke(transform.position);

                Destroy(gameObject, 1);
            }
        }
    }

    #endregion

    #region Methods



    #endregion

    #region Private & Protected

    private Transform _moveTarget;
    private Animator _animator;
    private BoxCollider2D _collider;

    #endregion

}
