using System;
using JFramework;
using UnityEngine;
using UnityEngine.InputSystem;

public class Role : Entity
{
    [SerializeField] private GameObject _model;

    [SerializeField] private Animator _animator;

    public MovementController MoveCtrl { get; private set; }

    public AttributeControl AttrCtrl { get; private set; }


    protected override void OnEnable()
    {
        base.OnEnable();

        if (MoveCtrl == null)
        {
            MoveCtrl = Get<MovementController>();
        }

        if (AttrCtrl == null)
        {
            AttrCtrl = Get<AttributeControl>();
        }
    }

    protected override void OnDisable()
    {
        base.OnDisable();
    }
}