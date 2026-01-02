using UnityEngine;
using Zenject;

public class FactoryInstaller : MonoInstaller
{
    [Header("Prefab Settings")]
    [SerializeField] private GameObject _logPrefab;
    public override void InstallBindings()
    {
        Container.BindFactory<Log, Log.Factory>()
            .FromComponentInNewPrefab(_logPrefab)
            .AsTransient();
    }
}