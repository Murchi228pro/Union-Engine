// Circle - Shape inherinstanced class
using System;
using Microsoft.Xna.Framework;

namespace Engine.Geometry
{
    public class Circle : Shape
    {
        public float Radius;
        public Circle(float radius)
        {
            this.Radius = radius;
        }
        public override (float, float) GetProjection(Vector2 axis, Vector2 position, float rotation)
        {
            float proj1 = Vector2.Dot(GetPos(position) + axis * Radius, axis);
            float proj2 = Vector2.Dot(GetPos(position) + (-axis * Radius), axis);
            float min = Math.Min(proj1, proj2);
            float max = Math.Max(proj1, proj2);
            return (min, max);
        }
        public override Vector2[] GetNormalAxes(float rotation)
        {
            return new Vector2[] { };
        }
    }
}

