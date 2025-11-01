// Capsule - Shape inherinstanced class
using Microsoft.Xna.Framework;
using System;

namespace Engine.Geometry;

class Capsule : Shape
{
    public float Height;
    public float Radius;

    public override (float, float) GetProjection(Vector2 axis, Vector2 position, float rotation)
    {
        Vector2 rotatedVector = GeometryHelper.RotateAtY(1, rotation + RotationOffset);
        Vector2 circleCenter1 = GetPos(position) + rotatedVector * Height / 2;
        Vector2 circleCenter2 = GetPos(position) + rotatedVector * (-Height / 2);
        Vector2[] points = {
            circleCenter1 + Radius * axis,
            circleCenter1 - Radius * axis,
            circleCenter2 + Radius * axis,
            circleCenter2 - Radius * axis
        };

        float Min = float.PositiveInfinity;
        float Max = float.NegativeInfinity;

        foreach (Vector2 point in points)
        {
            Min = Math.Min(Min, Vector2.Dot(point, axis));
            Max = Math.Max(Max, Vector2.Dot(point, axis));
        }
        return (Min, Max);
    }

    public override Vector2[] GetNormalAxes(float rotation)
    {
        Vector2 axis = GeometryHelper.RotateAtY(1, GetRot(rotation));
        return new Vector2[] { GeometryHelper.GetNormal(axis) };
    }

}