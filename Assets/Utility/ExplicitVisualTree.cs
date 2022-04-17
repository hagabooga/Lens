using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using UnityEngine.UIElements;
using System.Linq;
using System;

public abstract class ExplicitVisualTree
{
    static readonly MethodInfo Q = typeof(UQueryExtensions)
        .GetMethods(BindingFlags.Public | BindingFlags.Static)
        .Where(x => x.Name == "Q")
        .First();
    public VisualElement Root { get; }
    public ExplicitVisualTree(VisualElement root)
    {
        Root = root;
        LoadElements(Root);
    }

    public static implicit operator VisualElement(ExplicitVisualTree p) => p.Root;

    private void LoadElements(VisualElement root)
    {
        var fields = GetType().GetFields(BindingFlags.Instance | BindingFlags.Public);
        foreach (var field in fields)
        {
            var qTyped = Q.MakeGenericMethod(field.FieldType);
            var parameters = new object[] { root, field.Name, null };
            object value = qTyped.Invoke(null, parameters);
            field.SetValue(this, value);
        }
    }
}