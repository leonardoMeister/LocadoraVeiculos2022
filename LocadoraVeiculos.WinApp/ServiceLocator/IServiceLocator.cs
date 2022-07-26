using LocadoraVeiculos.WinApp.shared;

namespace LocadoraVeiculos.WinApp.ServiceLocator
{
    public interface IServiceLocator
    { 
        T Get<T>() where T : ConfiguracaoBase;
    }
}