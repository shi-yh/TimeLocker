using System;
using JFramework;
using UnityEngine;
using UnityEngine.InputSystem;

public class Role : Entity
{
    [SerializeField] private GameObject _model;

    [SerializeField] private Animator _animator;

    public MovementController MoveCtrl => Get<MovementController>();

    public AttributeControl AttrCtrl => Get<AttributeControl>();


    protected override void OnEnable()
    {
        base.OnEnable();
        
        Debug.Log(MoveCtrl);
        Debug.Log(AttrCtrl);
        
        
    }

    protected override void OnDisable()
    {
        base.OnDisable();
    }
}