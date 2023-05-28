using JFramework.Core;
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

    private bool temp = true;

    private void Update()
    {
        _time -= Time.deltaTime * _speed;

      

        if (_time <= -2)
        {
            _time = 0;
            SpawnEnemy();
        }

        _block.SetVector("_BaseMap_ST", new Vector4(5, 5, 0, _time));
        _render.SetPropertyBlock(_block);
    }

    private void SpawnEnemy()
    {
        PoolManager.Pop("Prefabs/Enemy", null);
    }
}