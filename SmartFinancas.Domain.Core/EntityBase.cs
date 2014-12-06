using SmartFinancas.Domain.Core.Infrastructure;

namespace SmartFinancas.Domain.Core
{
    public class EntityBase : IEntityKey<int>
    {
        public int Id { get; protected set; }
    }
}