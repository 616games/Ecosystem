using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Fly : Animal
{
    private float _perlinNoiseTimer;

    private float _perlinNoiseRecalculationTime = .1f;

    private Vector3 _velocity;

    private Vector3 _acceleration;

    private Transform _transform;

    [SerializeField]
    private Transform _target;

    private Vector3 _direction;

    private void Start()
    {
        Init();
    }

    private void Update()
    {
        Move();
    }

    protected override void Move()
    {
        //if (!_isMoving) return;

        _perlinNoiseTimer += Time.deltaTime;

        if (_perlinNoiseTimer > _perlinNoiseRecalculationTime)
        {
            _velocity = PerlinNoise.GetPerlinNoise();
            _perlinNoiseTimer = 0;
        }

        _direction = (_target.position - transform.position).normalized;
        

        _transform.position += (_velocity + _direction) * _moveSpeed * Time.deltaTime;
        PreventCollision();
    }

    protected override void PreventCollision()
    {
        RaycastHit _hit;
        if (Physics.Raycast(_transform.position, _velocity, out _hit, 7f, 1 << 6))
        {
            Debug.Log(1);
            _velocity = Vector3.Reflect(_velocity, _hit.normal);
        }
    }

    protected override void Init()
    {
        _isMoving = true;
        _transform = transform;
        _velocity = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f));
    }
}
