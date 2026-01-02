using UnityEngine;
using Zenject;

public class DataInstaller : MonoInstaller
{
    [Header("Data Settings")]
    [SerializeField] private TurretDataSO _turretDataSO;
    [SerializeField] private PlayerDataSO _playerDataSO;
    public override void InstallBindings()
    {
        Container.BindInstance(_turretDataSO).AsSingle();
        Container.BindInstance(_playerDataSO).AsSingle();

        Container.Bind<PlayerMovement>().FromComponentInHierarchy().AsSingle();
    }
}