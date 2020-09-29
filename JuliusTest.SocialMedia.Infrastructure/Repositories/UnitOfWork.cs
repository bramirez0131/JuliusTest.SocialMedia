using JuliusTest.SocialMedia.Infrastructure.DataAccessEntityFrameWork;
using JuliusTest.SocialMedia.Infrastructure.Interfaces;

using Microsoft.EntityFrameworkCore.Storage;

using System.Threading.Tasks;

namespace JuliusTest.SocialMedia.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
	{
		/// <summary>
		/// The context
		/// </summary>
		private readonly SmContext _context;


		/// <summary>
		/// Initializes a new instance of the <see cref="UnitOfWork" /> class.
		/// </summary>
		/// <param name="context">The context.</param>
		public UnitOfWork(SmContext context)
		{
			_context = context;
		}

		/// <summary>
		/// Gets the usuario repository.
		/// </summary>
		/// <value>The usuario repository.</value>
		public IUsuarioRepository UsuarioRepository
		{
			get
			{
				if (this.usuarioRepository == null)
				{
					this.usuarioRepository = new UsuarioRepository(_context);
				}

				return usuarioRepository;
			}
		}

		/// <summary>
		/// The seguridad repository
		/// </summary>
		private IUsuarioRepository usuarioRepository;

		/// <summary>
		/// The linea repository
		/// </summary>
		private IPublicacionRepository publicacionRepository;

		/// <summary>
		/// Gets the linea repository.
		/// </summary>
		/// <value>The linea repository.</value>
		public IPublicacionRepository PublicacionRepository
		{
			get
			{
				if (this.publicacionRepository == null)
				{
					this.publicacionRepository = new PublicacionRepository(_context);
				}

				return publicacionRepository;
			}
		}

		/// <summary>
		/// Begins the transaction.
		/// </summary>
		/// <returns>IDbContextTransaction.</returns>
		public IDbContextTransaction BeginTransaction()
		{
			return _context.Database.BeginTransaction();
		}

		/// <summary>
		/// begin transaction as an asynchronous operation.
		/// </summary>
		/// <returns>Task&lt;IDbContextTransaction&gt;.</returns>
		public async Task<IDbContextTransaction> BeginTransactionAsync()
		{
			return await _context.Database.BeginTransactionAsync();
		}

		/// <summary>
		/// Commits the transaction.
		/// </summary>
		public void CommitTransaction()
		{
			_context.Database.CommitTransaction();
		}

		/// <summary>
		/// Detects the changes.
		/// </summary>
		public void DetectChanges()
		{
			_context.ChangeTracker.DetectChanges();
		}

		/// <summary>
		/// Rollbacks the transaction.
		/// </summary>
		public void RollbackTransaction()
		{
			_context.Database.RollbackTransaction();
		}

		/// <summary>
		/// Saves the changes.
		/// </summary>
		public void SaveChanges()
		{
			_context.SaveChanges();
		}

		/// <summary>
		/// save changes as an asynchronous operation.
		/// </summary>
		/// <returns>Task.</returns>
		public async Task SaveChangesAsync()
		{
			await _context.SaveChangesAsync();
		}
	}
}
