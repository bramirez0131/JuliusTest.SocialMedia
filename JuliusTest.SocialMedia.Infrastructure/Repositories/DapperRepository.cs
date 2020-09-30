using Dapper;

using JuliusTest.SocialMedia.Infrastructure.Interfaces;

using Microsoft.Data.SqlClient;

using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace JuliusTest.SocialMedia.Infrastructure.Repositories
{
    /// <summary>
    /// Class DapperHelper.
    /// </summary>
    public class DapperRepository<T> : IDapperRepository<T> where T : class
	{
		#region Métodos Públicos

		/// <summary>
		/// Ejecutar sentencia sql
		/// </summary>
		/// <typeparam name="T">Entidad para realizar el Mapeo</typeparam>
		/// <param name="cnx">The Connection String.</param>
		/// <param name="query">Quesry SQL a ejecutar.</param>
		/// <param name="filter">Condición que se debe mapear a la sentencia sql server.</param>
		/// <returns>Task&lt;IEnumerable&lt;T&gt;&gt;.</returns>
		/// <exception cref="Exception">Manejo de errores</exception>
		public async Task<IEnumerable<T>> ExecuteQuerySelectAsync(string cnx, string query, object filter = null)
		{
			using var conn = new SqlConnection(cnx);
			conn.Open();
			var result = await conn.QueryAsync<T>(query, filter).ConfigureAwait(false);
			conn.Close();
			conn.Dispose();
			return result;
		}

		/// <summary>
		/// Ejecutar sentencia sql y devuelve un primer registro
		/// </summary>
		/// <typeparam name="T">Entidad para realizar el Mapeo</typeparam>
		/// <param name="cnx">The Connection String.</param>
		/// <param name="query">Quesry SQL a ejecutar.</param>
		/// <param name="filter">Condición que se debe mapear a la sentencia sql server.</param>
		/// <returns>Task&lt;IEnumerable&lt;T&gt;&gt;.</returns>
		/// <exception cref="Exception">Manejo de errores</exception>
		public async Task<T> ExecuteFirstOrDefaultAsync(string cnx, string query, object filter = null)
		{
			using var conn = new SqlConnection(cnx);
			conn.Open();
			var result = await conn.QueryFirstOrDefaultAsync<T>(query, filter).ConfigureAwait(false);
			conn.Close();
			conn.Dispose();
			return result;
		}

		/// <summary>
		///     s the store procedure.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="cnx">The Connection String.</param>
		/// <param name="storeProcedure">The store procedure.</param>
		/// <param name="filter">The filter.</param>
		/// <returns>Task&lt;IEnumerable&lt;T&gt;&gt;.</returns>
		public async Task<IEnumerable<T>> ExecuteStoreProcedureAsync(string cnx, string storeProcedure, object filter = null)
		{
			using var conn = new SqlConnection(cnx);
			conn.Open();
			var result = await conn.QueryAsync<T>(storeProcedure, filter, commandType: CommandType.StoredProcedure).ConfigureAwait(false);
			conn.Close();
			conn.Dispose();
			return result;
		}

		/// <summary>
		///     s the query scalar.
		/// </summary>
		/// <param name="cnx">The Connection String.</param>
		/// <param name="query">The query.</param>
		/// <param name="filter">The filter.</param>
		/// <returns>System.Int32.</returns>
		/// <summary>

		public async Task<int> ExecuteQueryScalarAsync(string cnx, string query, object filter = null)
		{
			using var conn = new SqlConnection(cnx);
			conn.Open();
			var result = await conn.ExecuteScalarAsync<int>(query, filter).ConfigureAwait(false);
			conn.Close();
			conn.Dispose();
			return result;
		}

		#endregion Métodos Públicos
	}
}
