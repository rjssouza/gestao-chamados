using Core.Domain.Entities;

namespace Chamados.Domain.Entity
{
    /// <summary>
    ///
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class AuditoryEntity<TEntity> : Entity<TEntity>
        where TEntity : Entity<TEntity>
    {
        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public DateTime DtReg { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public int UsReg { get; set; }
    }
}