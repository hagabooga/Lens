using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using System;
using System.Linq;

[Serializable]
public class ExplicitVisualTreeFactory<T> where T : ExplicitVisualTree
{
    [SerializeField] VisualTreeAsset visualTreeAsset;

    public T Create(params object[] otherParams)
    {
        var args = new object[] { visualTreeAsset.CloneTree() }.Concat(otherParams).ToArray();
        return (T)Activator.CreateInstance(typeof(T), args);
    }
}