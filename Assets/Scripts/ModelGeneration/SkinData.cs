using UnityEngine;
using System.Collections.Generic;

public class SkinData
{
    private readonly List<Color> _colors;
    private readonly List<Vector2> _uvs;

    public SkinData()
    {
        _colors = new List<Color>();
        _uvs = new List<Vector2>();
    }

    ~SkinData()
    {
        Clear();
    }

    public void Clear()
    {
        _colors.Clear();
        _uvs.Clear();
    }

    public void AddUV(Vector2 uv)
    {
        _uvs.Add(uv);
    }

    public void AddColor(Color color)
    {
        _colors.Add(color);
    }

    public void Add(Vector2 uv, Color color) 
    {
        _uvs.Add(uv);
        _colors.Add(color);
    }

    public void Add(SkinData skinData)
    {
        _colors.AddRange(skinData._colors);
        _uvs.AddRange(skinData._uvs);
    }
}
