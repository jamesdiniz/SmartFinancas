using SmartFinancas.Domain.Infrastructure;

namespace SmartFinancas.Domain
{
    public class EntityBase : IEntityKey<int>
    {
        public int Id { get; protected set; }
    }
}