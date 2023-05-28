using System.Collections;
using System.Collections.Generic;
using JFramework;
using UnityEngine;

public class ViewPort : BaseSingleton<ViewPort>
{
    private const int DefaultSize = 10;
    private Bounds _moveBound;

    public ViewPort()
    {
        _moveBound = new Bounds(Vector3.zero,
            new Vector3((float)Screen.currentResolution.width / Screen.currentResolution.height * DefaultSize, 0,
                DefaultSize));
    }

    public bool GetPlayerMoveAblePosition(ref Vector3 playerPos)
    {
        if (_moveBound.Contains(playerPos))
            return true;
        playerPos = _moveBound.ClosestPoint(playerPos);
        return false;
    }

    public Vector3 GetRandomPosInBound()
    {
        Vector3 center = _moveBound.center;

        center.x += (Random.value < 0.5f ? 1 : -1) * Random.Range(0, _moveBound.extents.x);
        center.z += (Random.value < 0.5f ? 1 : -1) * Random.Range(0, _moveBound.extents.z);


        return center;
    }


    public Vector3 GetRandomPosOutOfBound()
    {
        Vector3 center = _moveBound.center;

        bool right = Random.value < 0.5f;

        bool up = Random.value < 0.5f;

        if (right)
        {
            center.x += _moveBound.extents.x + Random.value ;
        }
        else
        {
            center.x -= _moveBound.extents.x + Random.value ;
        }


        if (up)
        {
            center.z += _moveBound.extents.z + Random.value ;
        }
        else
        {
            center.z -= _moveBound.extents.z + Random.value ;
        }


        return center;
    }
}