﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldBehavior : MonoBehaviour
{        
    public List<GameObject> IgnoredColliders;
    public GameObject RootObject;

    public Vector2 MyColliderOffset;
    public Vector2 MyColliderSize;

    public ShieldConfig _ShieldConfig;

    public IBlockable CurrentShield;

    public void Initialize()
    {
        _ShieldConfig = Instantiate(_ShieldConfig);       
        _ShieldConfig.Initialize(this.gameObject);
        CurrentShield = _ShieldConfig;

        MyColliderOffset = GetComponent<BoxCollider2D>().offset;
        MyColliderSize = GetComponent<BoxCollider2D>().size;

        if (RootObject)
            return;

        IgnoredColliders.Add(RootObject);
        if (!RootObject)
            return;
        foreach (var collider in RootObject.GetComponentsInChildren<Collider2D>())
        {
            if (collider != this.GetComponent<Collider2D>())
            {
                IgnoredColliders.Add(collider.gameObject);
            }
        }        
    }    

    public void DoBlock(GameObject go)
    {        
        if (IgnoredColliders.Contains(go))
            return;
        CurrentShield.Block(go);
        if(_ShieldConfig.ShieldGrowth < 1)
        {
            GetComponent<BoxCollider2D>().offset = MyColliderOffset * 2;
            GetComponent<BoxCollider2D>().size = MyColliderSize * 2;
        }                        
    }
    
    public void StopBlock(GameObject go)
    {
        if (IgnoredColliders.Contains(go))
            return;
        CurrentShield.StopBlock();
        GetComponent<BoxCollider2D>().offset = MyColliderOffset;
        GetComponent<BoxCollider2D>().size = MyColliderSize;
    }
}
