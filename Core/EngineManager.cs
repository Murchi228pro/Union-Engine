
using System.Collections.Generic;
using Engine.Core.Systems;

namespace Engine.Core;

public class EngineManager
{
    public List<Entity> Entities;

    public List<ISystem> Systems;

    public void Update()
    {
        foreach (ISystem system in Systems)
        {
            system.Update(Entities);
        }
    }

}