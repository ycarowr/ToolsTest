using System;

/// <summary>
/// This attribute tells the Editor to draw a for a Method.
/// Since is using reflection it works for private and protected methods too.
/// Ref: https://github.com/dbrizov/NaughtyAttributes
/// </summary>
[AttributeUsage(AttributeTargets.Method)]
public class ButtonAttribute : Attribute
{
    public string Label { get; }

    public ButtonAttribute(string label) : base()
    {
        Label = label;
    }

    public ButtonAttribute() : base()
    {

    }
}
