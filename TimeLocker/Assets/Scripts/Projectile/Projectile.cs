using System.Collections;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;

    [SerializeField] private Vector3 _moveDir;

    public float startTime { get; private set; }
    

    private void OnEnable()
    {
        StartCoroutine(MoveDirectly());
        startTime = Time.time;
    }

    IEnumerator MoveDirectly()
    {
        while (gameObject.activeSelf)
        {
            transform.Translate(_moveSpeed * _moveDir * Time.deltaTime);
            yield return null;
        }
    }
}