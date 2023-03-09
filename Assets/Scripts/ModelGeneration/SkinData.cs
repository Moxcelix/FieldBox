using UnityEngine;
using System.Collections.Generic;

public class SkinData
{
    public List<Color> Colors { get; }
    public List<Vector2> UVs { get; }

    public SkinData()
    {
        Colors = new List<Color>();
        UVs = new List<Vector2>();
    }

    ~SkinData()
    {
        Clear();
    }

    public void Clear()
    {
        Colors.Clear();
        UVs.Clear();
    }

    public void AddUV(Vector2 uv)
    {
        UVs.Add(uv);
    }

    public void AddColor(Color color)
    {
        Colors.Add(color);
    }

    public void Add(Vector2 uv, Color color)
    {
        UVs.Add(uv);
        Colors.Add(color);
    }

    public void Add(SkinData skinData)
    {
        Colors.AddRange(skinData.Colors);
        UVs.AddRange(skinData.UVs);
    }
}
