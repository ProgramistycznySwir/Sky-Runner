﻿using System.Runtime.InteropServices;
using System.Xml.Schema;
using UnityEngine;


public struct ValueInRange
{
    public Range range;
    float _value;
    public float value
    {
        get { return _value; }
        set { _value = range.Clamp(value); }
    }

    ValueInRange(float min, float max, float value)
    { this.range = new Range(min, max); _value = value; }
    ValueInRange(Range range, float value)
    { this.range = range; _value = value; }

    public float Percent
    {
        get { return range.Percent(value); }
    }

    public bool IsMin { get { return _value <= range.min; } }
    public bool IsMax { get { return _value >= range.max; } }
}

public struct Range
{
    public float min;
    public float max;

    public Range(float min, float max)
    { this.min = min; this.max = max; }
    public Range(float max)
    { this.min = 0; this.max = max; }

    public float Evaluate(float t)
    {
        return Mathf.Lerp(min, max, t);
    }
    public float Percent(float value)
    {
        return Mathf.InverseLerp(min, max, value);
    }

    public float Clamp(float value)
    {
        return Mathf.Clamp(value, min, max);
    }

    /// <summary>
    /// Returns random value in range
    /// </summary>
    /// <returns> Random value in range</returns>
    public float Random
    {
        get { return Mathf.Lerp(min, max, UnityEngine.Random.value); }
    }
}
