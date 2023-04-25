namespace Services.Repositories
{
    public interface IUnitOfWork
    {
        public IUserRepository User { get; }
    }
}
