using System.Collections;
using System.Collections.Generic;
using JFramework;
using UnityEngine;

public class EnemyEntity : Role
{
    private Vector3 _targetPos;

    protected override void OnEnable()
    {
        base.OnEnable();

        transform.position = ViewPort.Instance.GetRandomPosOutOfBound();

        _targetPos = ViewPort.Instance.GetRandomPosInBound();
        MoveCtrl.Move((_targetPos-transform.position).normalized,false);
    }

    protected override void OnUpdate()
    {
        Vector3 offset = _targetPos - transform.position;

        if (offset.sqrMagnitude < 1)
        {
            _targetPos = ViewPort.Instance.GetRandomPosInBound();
            MoveCtrl.Move((_targetPos-transform.position).normalized,false);
        }
    }
}