
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using Engine.Tools;
using Microsoft.Xna.Framework;

namespace Engine.Core;

public class Entity
{
    private uint _rid;
    private Entity _parent;
    private List<Entity> _children;
    private HashSet<string> _groups;
    private Dictionary<Type, Component> _components;

    public Entity()
    {
        _children = new();
        _groups = new();
        _components = new();
    }

    public T GetComponent<T>() where T : Component
    {
        if (_components.ContainsKey(typeof(T)))
        {
            return (T)_components[typeof(T)];
        }
        return null;
    }

    public bool HasComponent<T>() where T : Component
    {
        if (_components.ContainsKey(typeof(T)))
        {
            return true;
        }
        return false;
    }

    public void AddComponent<T>(T component) where T : Component
    {
        if (_components.ContainsKey(typeof(T)))
        {

        }
        else
        {
            _components.Add(typeof(T), component);
        }
    }
    public void RemoveComponent<T>() where T : Component
    {
        if (_components.ContainsKey(typeof(T)))
        {
            _components.Remove(typeof(T));
        }
        else
        {
            
        }
    }
}