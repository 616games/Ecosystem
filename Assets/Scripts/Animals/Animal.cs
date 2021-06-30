using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Animal : MonoBehaviour
{
    [SerializeField]
    protected float _moveSpeed;

    [SerializeField]
    protected float _hunger;

    protected bool _isMoving;

    protected bool _isEating;

    protected abstract void Move();

    protected abstract void PreventCollision();

    protected abstract void Init();
}
