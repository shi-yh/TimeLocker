using System.Collections;
using System.Collections.Generic;
using GameManager;
using JFramework.Core;
using UnityEngine;
using UnityEngine.Serialization;

public class Weapon : MonoBehaviour
{
    [SerializeField] private string _projectileUrl;

    [SerializeField] private float _shootDuration = 0.1f;

    [SerializeField] private float _projectileLifeTime = 4f;

    private Queue<Projectile> _projectiles = new Queue<Projectile>();

    protected Coroutine curShootCoroutine;

    protected Coroutine curProjectileRecycleCoroutine;

    private void Awake()
    {
        EventManager.Listen(MsgID.OnGameStateChange, OnGameStateChange);
        // MsgManager.Instance.Register(MsgID.OnGameStateChange, OnGameStateChange);
    }

    private void OnGameStateChange(object[] obj)
    {
        GameState state = (GameState)obj[0];

        if (state == GameState.GameState_Run)
        {
            curShootCoroutine = StartCoroutine(StartShoot());
            curProjectileRecycleCoroutine = StartCoroutine(RecycleProjectile());
        }
        else
        {
            if (curShootCoroutine != null)
            {
                StopCoroutine(curShootCoroutine);
            }

            if (curProjectileRecycleCoroutine != null)
            {
                StopCoroutine(curProjectileRecycleCoroutine);
            }
        }
    }

    private IEnumerator RecycleProjectile()
    {
        while (true)
        {
            yield return new WaitForSeconds(_shootDuration);

            while (_projectiles.Count > 0)
            {
                float time = Time.time;

                Projectile projectile = _projectiles.Peek();

                if (time - projectile.startTime >= _projectileLifeTime)
                {
                    PoolManager.Push(projectile.gameObject);
                    _projectiles.Dequeue();
                }
                else
                {
                    break;
                }
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
        EventManager.Remove(MsgID.OnGameStateChange, OnGameStateChange);
    }
}