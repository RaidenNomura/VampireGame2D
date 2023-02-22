using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerManagement : MonoBehaviour
{
    #region Exposed

    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] GameObject _endScreen;

    [SerializeField] private float _speedPlayer = 3;
    [SerializeField] private float _speedBullet = 30;
    [SerializeField] private float _fireRate = 1f;
    [SerializeField] int _playerHealth = 1;

    #endregion

    #region Unity Lifecycle

    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
    }

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        SetBullet();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            _playerHealth--;
            if (_playerHealth <= 0)
            {
                _endScreen.SetActive(true);
                Debug.Log("pouk");
            }
        }
    }

    #endregion

    #region Methods

    public void Movement(InputAction.CallbackContext context)
    {
        SetVelocity(context.ReadValue<Vector2>());
        _rb.velocity = new Vector2(_horizontal * _speedPlayer, _vertical * _speedPlayer);
    }

    public void Attack(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            SetBullet();
        }
    }

    void SetVelocity(Vector2 _direction)
    {
        _horizontal = _direction.x;
        _vertical = _direction.y;
    }

    void SetBullet()
    {
        if (Time.timeSinceLevelLoad > _reloadTime)
        {
            _animator.SetTrigger("isAttaking");
            for (int i = 0; i <= 3; i++)
            {
                _reloadTime = Time.timeSinceLevelLoad + _fireRate;
                _bullet = Instantiate(_bulletPrefab, transform.position + _dir[i], transform.rotation);
                _bullet.GetComponent<Rigidbody2D>().velocity = _dir[i] * _speedBullet;
                Destroy(_bullet, 3);
            }
        }
    }

    #endregion

    #region Private & Protected

    private Vector3[] _dir = new Vector3[4]
    {
    new Vector2(0, -1),
    new Vector2(0, 1),
    new Vector2(-1, 0),
    new Vector2(1, 0)
    };

    private GameObject _bullet;
    private Rigidbody2D _rb;

    private float _reloadTime;

    private float _horizontal;
    private float _vertical;

    private Animator _animator;

    #endregion
}
