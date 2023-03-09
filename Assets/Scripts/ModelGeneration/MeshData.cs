using UnityEngine;
using System.Collections.Generic;

public class MeshData
{
    public  int LayerCount { get; }
    public List<Vector3> Vertices { get; }
    public List<int>[] Triangles { get; }

    public MeshData(int layerCount)
    {
        Vertices = new List<Vector3>();
        Triangles = new List<int>[layerCount];

        LayerCount = layerCount;

        for (int i = 0; i < Triangles.Length; i++)
        {
            Triangles[i] = new List<int>();
        }
    }

    ~MeshData()
    {
        Clear();
    }

    public void Clear() 
    {
        Vertices.Clear();

        for (int i = 0; i < Triangles.Length; i++)
        {
            Triangles[i].Clear();
        }
    }

    public void AddTriangle(Vector3 a, Vector3 b, Vector3 c, int layer)
    {
        if (layer < 0 || layer >= LayerCount)
        {
            throw new System.ArgumentOutOfRangeException();
        }

        Vertices.Add(a);
        Vertices.Add(b);
        Vertices.Add(c);

        Triangles[layer].Add(Vertices.Count - 3);
        Triangles[layer].Add(Vertices.Count - 2);
        Triangles[layer].Add(Vertices.Count - 1);
    }

    public void AddQuad(Vector3 a, Vector3 b, Vector3 c, Vector3 d, int layer = 0)
    {
        if (layer < 0 || layer >= LayerCount)
        {
            throw new System.ArgumentOutOfRangeException();
        }

        Vertices.Add(a);
        Vertices.Add(b);
        Vertices.Add(c);
        Vertices.Add(d);

        Triangles[layer].Add(Vertices.Count - 4);
        Triangles[layer].Add(Vertices.Count - 3);
        Triangles[layer].Add(Vertices.Count - 2);
        Triangles[layer].Add(Vertices.Count - 2);
        Triangles[layer].Add(Vertices.Count - 3);
        Triangles[layer].Add(Vertices.Count - 1);
    }

    public void Add(MeshData meshData, Vector3 shift) 
    {
        if (meshData.LayerCount > LayerCount)
        {
            throw new System.ArgumentOutOfRangeException();
        }

        for(int i = 0; i < meshData.LayerCount; i++) 
        {
            for(int j = 0; j < meshData.Triangles[i].Count; j++)
            {
                Triangles[i].Add(Vertices.Count + meshData.Triangles[i][j]);
            }
        }

        for(int i = 0; i < meshData.Vertices.Count; i++)
        {
            Vertices.Add(meshData.Vertices[i] + shift);
        }
    }

    public void Add(MeshData meshData)
    {
        Add(meshData, Vector3.zero);
    }
}