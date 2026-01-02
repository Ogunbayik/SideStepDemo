using UnityEngine;
using Zenject;

public class SignalInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        SignalBusInstaller.Install(Container);
        Container.DeclareSignal<GameSignal.PlayerDeadSignal>();


        Container.Bind<PlayerModel>().AsSingle();

        Container.Bind<IPlayerView>().To<PlayerView>().FromComponentInHierarchy().AsSingle();
        Container.BindInterfacesAndSelfTo<PlayerPresenter>().AsSingle().NonLazy();
    }
}