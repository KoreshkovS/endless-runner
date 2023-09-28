using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject _effect;
    [SerializeField] private Text _healthDisplay;
    [SerializeField] private GameObject _gameOver;
    [SerializeField] private float _yIctrement;
    [SerializeField] private float _speed;
    [SerializeField] private float _maxHeight;
    [SerializeField] private float _minHeight;
    [SerializeField] private int _health;

    [SerializeField] private Vector2 targetPos;

    public int Health { get => _health; set => _health = value; }

    private void Update()
    {
        _healthDisplay.text = $"HP: {_health}";//_health.ToString()

        if (_health <= 0)
        {
            _gameOver.SetActive(true);
            Destroy(gameObject);
        }


        transform.position = Vector2.MoveTowards(transform.position, targetPos, _speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.UpArrow) && transform.position.y < _maxHeight)
        {
            targetPos = new Vector2(transform.position.x, transform.position.y + _yIctrement);
            transform.position = targetPos;
            EffectOnMove();
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) && transform.position.y > _minHeight)
        {
            targetPos = new Vector2(transform.position.x, transform.position.y - _yIctrement);
            transform.position = targetPos;
            EffectOnMove();
        }
    }

    private void EffectOnMove()
    {
        Instantiate(_effect, transform.position, Quaternion.identity);
    }
}
