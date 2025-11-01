

using Microsoft.Xna.Framework;

namespace Engine.Geometry;

public struct CollideInfo
{
    public Vector2 mtv;
    public float overlap;
    public Vector2 axis;

    public static CollideInfo empty
    {
        get
        {
            return new CollideInfo(Vector2.Zero, 0, Vector2.Zero);
        }
    }
    public CollideInfo(Vector2 mtv_, float overlap_, Vector2 axis_)
    {
        this.mtv = mtv_;
        this.overlap = overlap_;
        this.axis = axis_;
    }


}