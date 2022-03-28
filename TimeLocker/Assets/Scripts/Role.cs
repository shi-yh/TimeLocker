using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Role : MonoBehaviour
{
    public float speed;

    [SerializeField]
    private GameObject _model;

    [SerializeField]
    private Animator _animator;

    /// <summary>
    /// 是否死亡
    /// </summary>
    private bool _death;

    /// <summary>
    /// 是否可控制
    /// </summary>
    private bool _canControl;


    public event Action<bool> onDeath;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Enemy")
        {
            SetDeath(true);
        }
    }

    public void SetCanControl(bool canControl)
    {
        if (_canControl==canControl)
        {
            return;
        }

        _canControl = canControl;
    }


    private void SetDeath(bool death)
    {
        if (_death==death)
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
        Vector3 mousePos = GetMovePos();

        if (!_death&&_canControl)
        {
            CheckFaceTo(mousePos);

            transform.Translate(mousePos * Time.deltaTime * speed, Space.Self);
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
