using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting;
using Zenject;
using Assets.GameState;
namespace Assets.DependencyInjection
{
    public class MyInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<GameStateManager>().AsSingle();

            Container.BindInterfacesAndSelfTo<GlobalTick>().AsSingle();
            Container.Bind<ClientCalls>().AsSingle();
        }
    }
}
