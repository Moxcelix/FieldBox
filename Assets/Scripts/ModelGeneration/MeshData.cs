using UnityEngine;
using System.Collections.Generic;

public class MeshData
{
    private readonly List<Vector3> _vertices;
    private readonly List<int>[] _triangles;

    private readonly int _layerCount;

    public MeshData(int layerCount)
    {
        _layerCount = layerCount;
        _vertices = new List<Vector3>();
        _triangles = new List<int>[layerCount];

        for (int i = 0; i < layerCount; i++)
        {
            _triangles[i] = new List<int>();
        }
    }

    ~MeshData()
    {
        Clear();
    }

    public void Clear() 
    {
        _vertices.Clear();

        for (int i = 0; i < _layerCount; i++)
        {
            _triangles[i].Clear();
        }
    }

    public void AddTriangle(Vector3 a, Vector3 b, Vector3 c, int layer)
    {
        if (layer < 0 || layer >= _layerCount)
        {
            throw new System.ArgumentOutOfRangeException();
        }

        _vertices.Add(a);
        _vertices.Add(b);
        _vertices.Add(c);

        _triangles[layer].Add(_vertices.Count - 3);
        _triangles[layer].Add(_vertices.Count - 2);
        _triangles[layer].Add(_vertices.Count - 1);
    }

    public void AddQuad(Vector3 a, Vector3 b, Vector3 c, Vector3 d, int layer)
    {
        if (layer < 0 || layer >= _layerCount)
        {
            throw new System.ArgumentOutOfRangeException();
        }

        _vertices.Add(a);
        _vertices.Add(b);
        _vertices.Add(c);
        _vertices.Add(d);

        _triangles[layer].Add(_vertices.Count - 4);
        _triangles[layer].Add(_vertices.Count - 3);
        _triangles[layer].Add(_vertices.Count - 2);
        _triangles[layer].Add(_vertices.Count - 2);
        _triangles[layer].Add(_vertices.Count - 3);
        _triangles[layer].Add(_vertices.Count - 1);
    }

    public void Add(MeshData meshData, Vector3 shift) 
    {
        if (meshData._layerCount > _layerCount)
        {
            throw new System.ArgumentOutOfRangeException();
        }

        for(int i = 0; i < meshData._layerCount; i++) 
        {
            for(int j = 0; j < meshData._triangles[i].Count; j++)
            {
                _triangles[i].Add(_vertices.Count + meshData._triangles[i][j]);
            }
        }

        for(int i = 0; i < meshData._vertices.Count; i++)
        {
            _vertices.Add(meshData._vertices[i] + shift);
        }
    }

    public void Add(MeshData meshData)
    {
        Add(meshData, Vector3.zero);
    }
}