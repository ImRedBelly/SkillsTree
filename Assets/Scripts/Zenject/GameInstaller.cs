using Services;
using UnityEngine;

namespace Zenject
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private DialogHelper _dialogHelper;

        public override void InstallBindings()
        {
            Container.Bind<DialogHelper>().FromInstance(_dialogHelper).AsSingle();
            Container.BindInterfacesAndSelfTo<DataHelper>().AsSingle();
        }
    }
}