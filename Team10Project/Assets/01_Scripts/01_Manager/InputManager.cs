using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Axis
{
    Horizontal,
    Vertical
}

public enum Key
{
    Left,
    Right,
    Up,
    Down,
    Jump,
    Dash,
    RopeMouse0
}

public static class InputManager
{
    static Dictionary<Key, KeyCode> keys = new Dictionary<Key, KeyCode>();

    static InputManager()
    {
        keys.Add(Key.Left, KeyCode.A);
        keys.Add(Key.Right, KeyCode.D);
        keys.Add(Key.Up, KeyCode.W);
        keys.Add(Key.Down, KeyCode.S);
        keys.Add(Key.Jump, KeyCode.Space);
        //Init Skills
        keys.Add(Key.Dash, KeyCode.LeftShift);
        keys.Add(Key.RopeMouse0, KeyCode.Mouse0);
    }

    public static float GetAxisRaw(Axis axis)
    {
        float value = 0f;

        if (axis == Axis.Horizontal)
        {
            value = GetHorizontalAxis();
        }

        else if (axis == Axis.Vertical)
        {
            value = GetVerticalAxis();
        }

        return value;
    }

    public static bool GetKey(Key key)
    {
        if (!keys.ContainsKey(key)) return false;

        return Input.GetKey(keys[key]);
    }

    public static bool GetKeyDown(Key key)
    {
        if (!keys.ContainsKey(key)) return false;

        return Input.GetKeyDown(keys[key]);
    }

    public static bool GetKeyUp(Key key)
    {
        if (!keys.ContainsKey(key)) return false;

        return Input.GetKeyUp(keys[key]);
    }

    static float GetHorizontalAxis()
    {
        float value = 0f;

        if (GetKey(Key.Left))
        {
            value = -1f;
        }

        else if (GetKey(Key.Right))
        {
            value = 1f;
        }

        if (GetKey(Key.Right) && GetKey(Key.Left))
        {
            value = 0f;
        }

        return value;
    }

    static float GetVerticalAxis()
    {
        float value = 0f;

        if (GetKey(Key.Down))
        {
            value = -1f;
        }

        else if (GetKey(Key.Up))
        {
            value = 1f;
        }

        if (GetKey(Key.Up) && GetKey(Key.Down))
        {
            value = 0f;
        }

        return value;
    }
}
