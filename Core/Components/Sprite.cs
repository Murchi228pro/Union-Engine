using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Engine.Core.Components;

public class Sprite : Component
{
    public Sprite SpriteTexture;

    public Color Modulate;

    public Vector2 PositionOffset = Vector2.Zero;

    public float RotationOffset = 0;
}