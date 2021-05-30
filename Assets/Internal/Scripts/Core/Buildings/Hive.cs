using System;
using UnityEngine;
using Utils;

public class Hive : MonoBehaviourBase
{
    public static Hive Instance;
    
    public Vector3 Position => _transform.position;

    private Transform _transform;

    private void Awake()
    {
        InitFields();
    }

    private void InitFields()
    {
        Instance = this;
        _transform = transform;
    }
}