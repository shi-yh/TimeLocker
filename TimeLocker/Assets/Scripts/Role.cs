using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Role : MonoBehaviour
{
    [SerializeField] private float _speed;

    [SerializeField] private float _acceleration;

    [SerializeField] private float _deceleration;

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

    private Coroutine _moveCoroutine;


    private void Awake()
    {
        _myActions = new MyActions();
        _myActions.Enable();

        _rigidbody = GetComponent<Rigidbody>();

        _myActions.PlayerMove.Move.performed += Move;
        _myActions.PlayerMove.Move.canceled += Stop;
    }


    public event Action<bool> onDeath;


    private void Stop(InputAction.CallbackContext context)
    {
        if (_moveCoroutine != null)
        {
            StopCoroutine(_moveCoroutine);
        }

        _moveCoroutine = StartCoroutine(MoveCoroutine(_deceleration, Vector3.zero));
    }


    private void Move(InputAction.CallbackContext context)
    {
        if (_moveCoroutine != null)
        {
            StopCoroutine(_moveCoroutine);
        }

        _moveCoroutine = StartCoroutine(MoveCoroutine(_acceleration, _speed * context.ReadValue<Vector3>().normalized));
    }

    IEnumerator MoveCoroutine(float time, Vector3 moveVelocity)
    {
        float t = 0f;
        while (t < time)
        {
            t += Time.fixedDeltaTime;

            _rigidbody.velocity = Vector3.Lerp(_rigidbody.velocity, moveVelocity, t / time);

            yield return null;
        }
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
}