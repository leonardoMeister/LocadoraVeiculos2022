namespace LocadoraVeiculos.Dominio.shared
{
    public interface IContextoPersistencia
    {
        void GravarDados();
        void DesfazerAlteracoes();
    }
}
