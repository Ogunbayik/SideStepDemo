using UnityEngine;
using Zenject;

public class DataInstaller : MonoInstaller
{
    [SerializeField] private TurretDataSO _turretDataSO;
    public override void InstallBindings()
    {
        Container.BindInstance(_turretDataSO).AsSingle();

        Container.Bind<PlayerMovement>().FromComponentInHierarchy().AsSingle();
    }
}