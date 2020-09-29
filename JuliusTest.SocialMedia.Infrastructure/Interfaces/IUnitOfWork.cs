using Microsoft.EntityFrameworkCore.Storage;

using System.Threading.Tasks;

namespace JuliusTest.SocialMedia.Infrastructure.Interfaces
{
	/// <summary>
	/// Interface IUnitOfWork
	/// Implements the <see cref="IDisposable" />
	/// </summary>
	/// <seealso cref="IDisposable" />
	public interface IUnitOfWork
	{
		/// <summary>
		/// Gets or sets the user repository.
		/// </summary>
		/// <value>The user repository.</value>
		IUsuarioRepository UsuarioRepository { get; }

		/// <summary>
		/// Gets the linea repository.
		/// </summary>
		/// <value>The linea repository.</value>
		IPublicacionRepository PublicacionRepository { get; }

		/// <summary>
		/// Saves the changes.
		/// </summary>
		void SaveChanges();

		/// <summary>
		/// Saves the changes asynchronous.
		/// </summary>
		/// <returns>Task.</returns>
		Task SaveChangesAsync();

		/// <summary>
		/// Detects the changes.
		/// </summary>
		void DetectChanges();

		/// <summary>
		/// Begins the transaction.
		/// </summary>
		/// <returns>IDbContextTransaction.</returns>
		IDbContextTransaction BeginTransaction();

		/// <summary>
		/// Begins the transaction asynchronous.
		/// </summary>
		/// <returns>Task&lt;IDbContextTransaction&gt;.</returns>
		Task<IDbContextTransaction> BeginTransactionAsync();

		/// <summary>
		/// Commits the transaction.
		/// </summary>
		void CommitTransaction();

		/// <summary>
		/// Rollbacks the transaction.
		/// </summary>
		void RollbackTransaction();
	}
}
