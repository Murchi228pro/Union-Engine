
using System.Collections.Generic;
using System.Linq;
using Engine.Core.Components;
using Engine.Geometry;

namespace Engine.Core.Systems;

public class CollidingSystem: ISystem
{
    public void Update(IEnumerable<Entity> entities)
    {
        IEnumerable<Entity> collidables = entities
        .Where(e => e.HasComponent<Transform>())
        .Where(e => e.HasComponent<Collider>());

        foreach(var collidable in collidables)
        {
            Transform transform = collidable.GetComponent<Transform>();
            Collider collider = collidable.GetComponent<Collider>();

            foreach(var colliding in collidables)
            {
                if (collidable == colliding)
                {
                    continue;
                }
                Transform otherTransform = colliding.GetComponent<Transform>();
                Collider otherCollider = collidable.GetComponent<Collider>();

                CollideInfo collideInfo = collider.GetCollideInfo(otherCollider.ThisShape, transform, otherTransform);
                transform.Position += collideInfo.mtv / 2;
                otherTransform.Position += -collideInfo.mtv / 2;
            }
        }
    }
}