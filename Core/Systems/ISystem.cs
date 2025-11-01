using System.Collections.Generic;
using Engine.Core;

namespace Engine.Core.Systems;

public interface ISystem
{

    public void Update(IEnumerable<Entity> entities)
    {
    
    }
}