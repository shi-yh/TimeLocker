using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class Role : MonoBehaviour
{
    [SerializeField] private float _speed;

    [SerializeField] private GameObject _model;

    [SerializeField] private Animator _animator;


    /// <summary>
    /// 是否死亡
    /// </summary>
    private bool _death;

    /// <summary>
    /// 是否可控制
    /// </summary>
    private bool _canControl;

    private MyActions _myActions;

    private Rigidbody _rigidbody;


    private void Awake()
    {
        _myActions = new MyActions();
        _myActions.Enable();

        _rigidbody = GetComponent<Rigidbody>();

        _myActions.PlayerMove.Move.performed += OnMovePerformed;
    }

    public event Action<bool> onDeath;


    private void OnMovePerformed(InputAction.CallbackContext context)
    {
        _rigidbody.velocity = _speed * context.ReadValue<Vector3>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            SetDeath(true);
        }
    }

    public void SetCanControl(bool canControl)
    {
        if (_canControl.Equals(canControl))
        {
            return;
        }

        _canControl = canControl;
    }


    private void SetDeath(bool death)
    {
        if (_death == death)
        {
            return;
        }

        _death = death;

        _animator.SetBool("death", _death);

        onDeath?.Invoke(death);
    }


    public void Revive(Vector3 pos)
    {
        transform.position = pos;

        SetDeath(false);
    }


    private void FixedUpdate()
    {
        if (!_death && _canControl)
        {
        }
    }

    private Vector3 GetMovePos()
    {
        Vector3 mousePos = Input.mousePosition;

        mousePos.x -= Screen.width / 2;

        mousePos.y -= Screen.height / 2;

        mousePos.x /= Screen.width;

        mousePos.y /= Screen.height;

        mousePos.z = mousePos.y;

        mousePos.y = 0;

        return mousePos;
    }

    private void CheckFaceTo(Vector3 mousePos)
    {
        Vector3 faceRotate = new Vector3(0, 0 + mousePos.x * 60, 0);
        transform.localRotation = Quaternion.Euler(faceRotate);
    }
}