using System.Collections;
using System.Collections.Generic;
using JFramework;
using UnityEngine;

public class EnemyEntity : Role
{
    private Vector3 _targetPos;

    private Player _targetPlayer;


    protected override void OnEnable()
    {
        base.OnEnable();

        _targetPlayer = GameObject.FindWithTag("Player").GetComponent<Player>();


        transform.position = ViewPort.Instance.GetRandomPosOutOfBound();

        _targetPos = _targetPlayer.transform.position;

        MoveCtrl.Move((_targetPos - transform.position).normalized, false);
    }

    protected override void OnUpdate()
    {
        Vector3 offset = _targetPos - transform.position;

        if (offset.sqrMagnitude < 1)
        {
            Vector3 pos = transform.position;


            if (ViewPort.Instance.GetPlayerMoveAblePosition(ref pos))
            {
                _targetPos = ViewPort.Instance.GetRandomPosOutOfBound();
                MoveCtrl.Move((_targetPos - transform.position).normalized, false);
            }
            else
            {
                
            }
        }
    }
}