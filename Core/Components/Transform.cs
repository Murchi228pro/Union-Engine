using Microsoft.Xna.Framework;


namespace Engine.Core.Components;

public class Transform : Component
{
    public Transform(Vector2 position, float rotation)
    {
        Position = position;
        Rotation = rotation;
    }

    public Vector2 Position;

    public float Rotation;
}