using System;
using Microsoft.Xna.Framework;

namespace Engine.Geometry;

public abstract class Shape
{
    public Vector2 PositionOffset;

    public float RotationOffset;

    public abstract (float, float) GetProjection(Vector2 axis, Vector2 position, float rotation);

    public abstract Vector2[] GetNormalAxes(float rotation);

    public virtual Vector2 GetPos(Vector2 position)
    {
        return position + PositionOffset;
    }

    public virtual float GetRot(float rotation)
    {
        return rotation + RotationOffset;
    }
}