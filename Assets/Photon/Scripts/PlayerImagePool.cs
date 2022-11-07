using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerImagePool : BaseObjectPool<PlayerImagePool, GameObject>
{
    [SerializeField] private GameObject playerImage = null;

    protected override GameObject getPrefab()
    {
        return playerImage;
    }

    protected override GameObject Create()
    {
        return base.Create();
    }

    public override GameObject Get(Vector3 position)
    {
        return base.Get(position);  
    }
    public override void Release(GameObject obj)
    {
        base.Release(obj);
    }
}
