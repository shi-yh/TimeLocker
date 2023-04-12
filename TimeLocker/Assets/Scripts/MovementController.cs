using System.Collections;
using JFramework;
using UnityEngine;

public class MovementController : Controller<Role>
{
    private AttributeControl _attributeControl => owner.AttrCtrl;

    private Rigidbody _ownerRig;

    private Coroutine _moveCoroutine;

    protected override void Start()
    {
        _ownerRig = owner.GetComponent<Rigidbody>();
    }

    public void Stop()
    {
        if (_moveCoroutine != null)
        {
            owner.StopCoroutine(_moveCoroutine);
        }

        _moveCoroutine = owner.StartCoroutine(MoveCoroutine(_attributeControl.Deceleration, Vector3.zero));
    }

    public void Move(Vector3 dir)
    {
        if (_moveCoroutine != null)
        {
            owner.StopCoroutine(_moveCoroutine);
        }

        _moveCoroutine =
            owner.StartCoroutine(MoveCoroutine(_attributeControl.Acceleration, _attributeControl.Speed * dir));
    }

    IEnumerator MoveCoroutine(float time, Vector3 moveVelocity)
    {
        float t = 0f;
        while (t < time)
        {
            t += Time.fixedDeltaTime;

            _ownerRig.velocity = Vector3.Lerp(_ownerRig.velocity, moveVelocity, t / time);

            yield return null;
        }
    }
}