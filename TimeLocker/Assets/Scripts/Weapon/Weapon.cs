using System.Collections;
using System.Collections.Generic;
using GameManager;
using JFramework;
using JFramework.Core;
using UnityEngine;
using UnityEngine.Serialization;

public class Weapon : Entity
{
    [SerializeField] private string _projectileUrl;

    [SerializeField] private float _shootDuration = 0.1f;
    
    private Queue<Projectile> _projectiles = new Queue<Projectile>();

    protected Coroutine curShootCoroutine;
    

    protected override void OnEnable()
    {
        base.OnEnable();
        EventManager.Listen(MsgID.OnGameStateChange, OnGameStateChange);
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        EventManager.Remove(MsgID.OnGameStateChange, OnGameStateChange);
    }


    private void OnGameStateChange(object[] obj)
    {
        GameState state = (GameState)obj[0];

        if (state == GameState.GameState_Run)
        {
            curShootCoroutine = StartCoroutine(StartShoot());
        }
        else
        {
            if (curShootCoroutine != null)
            {
                StopCoroutine(curShootCoroutine);
            }
        }
    }
    
    protected IEnumerator StartShoot()
    {
        while (true)
        {
            yield return new WaitForSeconds(_shootDuration);

            PoolManager.Pop(_projectileUrl, (projectile =>
            {
                projectile.transform.SetPositionAndRotation(transform.position, transform.rotation);
                _projectiles.Enqueue(projectile.GetComponent<Projectile>());
            }));
        }
    }
    
    private void OnDestroy()
    {
    }
}