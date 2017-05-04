﻿using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
    public float Time = 1.0f;

    void Update()
    {
        if (Time < 0)
            Destroy(gameObject);
        Time -= UnityEngine.Time.deltaTime;
    }
}