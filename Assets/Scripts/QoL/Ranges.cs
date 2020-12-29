using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region >>> Int <<<

[System.Serializable]
public struct ValueInRangeInt
{
    public RangeInt range;
    int __value;
    public int value
    {
        get => __value;
        set => __value = range.Clamp(value);
    }

    public ValueInRangeInt(int min, int max, int value) => (range, __value) = (new RangeInt(min, max), value);
    public ValueInRangeInt(RangeInt range, int value) => (this.range, __value) = (range, value);

    public float Percent => range.Percent(value);

    public bool IsMin => __value <= range.min;
    public bool IsMax => __value >= range.max;
}

[System.Serializable]
public struct RangeInt
{
    public int min;
    public int max;

    public RangeInt(int min, int max) => (this.min, this.max) = (min, max);
    public RangeInt(int max) => (this.min, this.max) = (0, max);

    public float Evaluate(float t) => Mathf.Lerp(min, max, t);
    public float Percent(float value) => Mathf.InverseLerp(min, max, value);
    public int Clamp(int value) => Mathf.Clamp(value, min, max);

    /// <summary>
    /// Returns random float in range
    /// </summary>
    /// <returns> Random float in range</returns>
    public float RandomFloat => Mathf.Lerp(min, max, UnityEngine.Random.value);
    /// <summary>
    /// Returns random int in range
    /// </summary>
    /// <returns> Random int in range</returns>
    public int RandomInt => (int)Mathf.Lerp(min, max, UnityEngine.Random.value);
}

#endregion

#region >>> Float <<<

[System.Serializable]
public struct ValueInRange
{
    public Range range;
    float __value;
    public float value
    {
        get => __value;
        set => __value = range.Clamp(value);
    }

    public ValueInRange(float min, float max, float value) => (range, __value) = (new Range(min, max), value);
    public ValueInRange(Range range, float value) => (this.range, __value) = (range, value);

    public float Percent => range.Percent(value);

    public bool IsMin => __value <= range.min;
    public bool IsMax => __value >= range.max;

    public void MoveTowards(float target, float maxDelta)
    {
        value = Mathf.MoveTowards(__value, target, maxDelta);
    }

    public static implicit operator float(ValueInRange a) => a.value;
    // public static implicit operator Range(ValueInRange a) => a.range;
}

[System.Serializable]
public struct Range
{
    public float min;
    public float max;


    public Range(float min, float max) => (this.min, this.max) = (min, max);
    public Range(float max) => (this.min, this.max) = (0, max);


    public float Evaluate(float t) => Mathf.Lerp(min, max, t);
    public float Percent(float value) => Mathf.InverseLerp(min, max, value);
    public float Clamp(float value) => Mathf.Clamp(value, min, max);

    public bool IsInRange(float value) => (value >= min && value <= max);


    /// <summary>
    /// Returns random value in range
    /// </summary>
    /// <returns> Random value in range</returns>
    public float Random => Mathf.Lerp(min, max, UnityEngine.Random.value);
}

#endregion