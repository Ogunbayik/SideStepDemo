using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class SpawnManager : IInitializable, ITickable
{
    private Log.Factory _logFactory;

    public SpawnManager(Log.Factory logFactory) => _logFactory = logFactory;

    public void Initialize()
    {
        throw new System.NotImplementedException();
    }

    public void Tick()
    {

    }
}
