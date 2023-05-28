using System;
using System.Collections;
using JFramework;
using JFramework.Core;
using UnityEngine;

public class Projectile : Entity
{
    [SerializeField] private float _moveSpeed;

    [SerializeField] private Vector3 _moveDir;

    [SerializeField] private float _duration;

    [SerializeField] private string _hitEffectName;

    public bool NeedRecycle { get; protected set; }

    public float StartTime { get; private set; }


    protected override void OnEnable()
    {
        base.OnEnable();
        NeedRecycle = false;
        StartCoroutine(MoveDirectly());
        StartTime = Time.time;
    }

    protected override void OnUpdate()
    {
        base.OnUpdate();

        if (Time.time - StartTime >= _duration)
        {
            NeedRecycle = true;
        }

        if (NeedRecycle)
        {
            PoolManager.Push(gameObject);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (!NeedRecycle)
        {
            PoolManager.Pop(_hitEffectName, (o => { o.transform.position = transform.position; }));
        }


        NeedRecycle = true;
    }


    IEnumerator MoveDirectly()
    {
        while (gameObject.activeSelf)
        {
            transform.Translate(_moveSpeed * _moveDir * Time.deltaTime);
            yield return null;
        }
    }
}