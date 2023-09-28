using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private GameObject _effect;
    [SerializeField] private int _damage;
    [SerializeField] private float _speed;


    private void Update()
    {
        transform.Translate(Vector2.left * _speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Instantiate(_effect, transform.position, Quaternion.identity);

            collision.GetComponent<Player>().Health -= _damage;
            Debug.Log(collision.GetComponent<Player>().Health);
            Destroy(gameObject);
        }
    }
}
