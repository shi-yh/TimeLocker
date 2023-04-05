using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundController : MonoBehaviour
{
    [SerializeField] private float _speed;

    private MeshRenderer _render;
    private MaterialPropertyBlock _block;

    private float _time = 0;


    private void Awake()
    {
        _render = GetComponent<MeshRenderer>();
        _block = new MaterialPropertyBlock();
    }

    private void Update()
    {
        _time -= Time.deltaTime * _speed;

        if (_time <= -10)
        {
            _time = 0;
        }

        _block.SetVector("_MainTex_ST", new Vector4(5, 5, 0, _time));
        _render.SetPropertyBlock(_block);
    }
}