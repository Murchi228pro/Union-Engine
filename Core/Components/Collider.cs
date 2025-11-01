
using Microsoft.Xna.Framework;
using Engine.Geometry;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Engine.Core.Components;

public class Collider : Component
{
    public Shape ThisShape;
    public Collider(Shape shape)
    {
        ThisShape = shape;
    }
    public bool isColliding(Shape otherShape, Transform transform, Transform otherTransform)
    {
        List<Vector2> axes = GetAxes(otherShape, transform, otherTransform);

        foreach (Vector2 axis in axes)
        {
            axis.Normalize();
            (float Min1, float Max1) = ThisShape.GetProjection(axis, transform.Position, transform.Rotation);
            (float Min2, float Max2) = otherShape.GetProjection(axis, otherTransform.Position, otherTransform.Rotation);

            if (Max1 < Min2 || Max2 < Min1)
            {
                return false;
            }
        }
        return true;
    }

    public CollideInfo GetCollideInfo(Shape otherShape, Transform transform, Transform otherTransform)
    {
        if (!isColliding(otherShape, transform, otherTransform))
        {
            return CollideInfo.empty;
        }
        List<Vector2> axes = GetAxes(otherShape, transform, otherTransform);

        float minOverlap = float.PositiveInfinity;
        Vector2 minAxis = Vector2.Zero;

        foreach (Vector2 axis in axes)
        {
            axis.Normalize();
            (float Min1, float Max1) = ThisShape.GetProjection(axis, transform.Position, transform.Rotation);
            (float Min2, float Max2) = otherShape.GetProjection(axis, otherTransform.Position, otherTransform.Rotation);

            float overlap = Math.Min(Max1 - Min2, Max2 - Min1);

            if (overlap < minOverlap)
            {
                minOverlap = overlap;
                minAxis = axis;
            }
        }

        Vector2 direction = otherShape.GetPos(otherTransform.Position) - otherShape.GetPos(transform.Position);
        int mtvDirection = Vector2.Dot(direction, minAxis) > 0 ? -1 : 1;

        var collideInfo = new CollideInfo(minAxis * mtvDirection * minOverlap,
            minOverlap,
            minAxis
        );



        return collideInfo;
    }

    protected List<Vector2> GetAxes(Shape otherShape, Transform transform, Transform otherTransform)
    {
        List<Vector2> axes = new List<Vector2>();
        axes.AddRange(ThisShape.GetNormalAxes(transform.Rotation));
        axes.AddRange(otherShape.GetNormalAxes(otherTransform.Rotation));
        axes.Add(Vector2.Normalize(ThisShape.GetPos(transform.Position) - otherShape.GetPos(otherTransform.Position)));
        
        return axes;
    }
}
