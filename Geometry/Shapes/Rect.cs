using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.Xna.Framework;

namespace Engine.Geometry;

public class Rect : Shape
{

    public float Width;
    public float Height;


    public Rect(float width, float height)
    {
        this.Width = width;
        this.Height = height;
    }

    public Vector2[] GetVertices(Vector2 position, float rotation)
    {
        float cos = (float)Math.Cos(GetRot(rotation));
        float sin = (float)Math.Sin(GetRot(rotation));

        float halfWidth = this.Width / 2;
        float halfHeight = this.Height / 2;

        Vector2[] vertices = {
            new Vector2(-halfWidth, -halfHeight),
            new Vector2(-halfWidth, halfHeight),
            new Vector2(halfWidth, halfHeight),
            new Vector2(halfWidth, -halfHeight)
        };

        for (int i = 0; i < vertices.Length; i++)
        {
            Vector2 rotatedVertice = GeometryHelper.Rotate(vertices[i], GetRot(rotation + RotationOffset));
            vertices[i] = new Vector2(GetPos(position).X + rotatedVertice.X, GetPos(position).Y + rotatedVertice.Y);
        }

        
        return vertices;
    }
    public override (float, float) GetProjection(Vector2 axis, Vector2 position, float rotation)
    {
        Vector2[] vertices = GetVertices(position, rotation);

        float min = float.PositiveInfinity;
        float max = float.NegativeInfinity;

        for (int i = 0; i < vertices.Length; i++)
        {
            min = Math.Min(min, Vector2.Dot(vertices[i], axis));
            max = Math.Max(max, Vector2.Dot(vertices[i], axis));
        }

        return (min, max);
    }
    public override Vector2[] GetNormalAxes(float rotation)
    {

        Vector2[] normals = {
            GeometryHelper.RotateAtX(1, GetRot(rotation)),
            GeometryHelper.RotateAtY(1, GetRot(rotation))
        };
        return normals;
    }
}