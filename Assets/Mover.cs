using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public float speed = 1.5f;

    Vector2 _direction;

    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(2.0f, 5.0f);
        _direction = new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f)) - new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f));
        _direction.Normalize();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 offset = _direction;
        transform.position += (speed * offset * Time.deltaTime);

        Vector2 screenPoint = Camera.main.WorldToScreenPoint(transform.position);
        if (screenPoint.x < .0f || screenPoint.x >= Camera.main.pixelWidth)
        {
            _direction.x = -1 * _direction.x;
        }
        if(screenPoint.y < .0f || screenPoint.y >= Camera.main.pixelHeight)
        {
            _direction.y = -1 * _direction.y;
        }
    }
}
