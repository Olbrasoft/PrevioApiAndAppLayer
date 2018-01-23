using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;

namespace Moon.Globalization.DAL.SQL
{
	public abstract class BaseSqlCultureReadOnlyRepository : IEnableCultureReadOnlyRepository
	{
		private List<CultureInfo> _cultures;
		private readonly string _conectionStringName;
		private readonly string _storedProcedureName;

		/// <summary>
		/// Predavame nazev ConectionStringu a Nazev procedury  
		/// Stored procedura musi vracet pole LanguageId typu int
		/// Tim ze nutime k predani Sp name zajistime ze Sql dotazy budou u databaze
		/// Tim ze nutime predat nameConectionString nutime ze connectionstring bude ve Web.config /App.config
		/// </summary>
		/// <param name="conectionStringName">nazev conectionStringu v configuracnim souboru</param>
		/// <param name="storedProcedureName">nazev procedury vracejici pole LanguageId typu int</param>
		protected BaseSqlCultureReadOnlyRepository(string conectionStringName, string storedProcedureName) {
			_conectionStringName = conectionStringName;
			_storedProcedureName = storedProcedureName;
		}

		/// <summary>
		/// Vraci interni kolekci IEnumerable Culture.
		/// Pokud je prazdna, nacte ji z databaze, pomoci Sp jejiz jmeno je predane v construktoru
		/// </summary>
		/// <param name="includeProperties">Not Implemented</param>
		/// <returns>Vraci interni kolekci pokud neni nactena nacte z databaze</returns>
		public IQueryable<CultureInfo> GetQuery(params Expression<Func<CultureInfo, object>>[] includeProperties) {
			if (includeProperties.Any())
				throw new NotImplementedException("This repository doesn't support includeProperties.");

			if (_cultures != null) {
				return _cultures.AsQueryable();
			}

			using (var con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings[_conectionStringName].ConnectionString)) {
				var cmd = con.CreateCommand();
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = _storedProcedureName;

				_cultures = new List<CultureInfo>();
				con.Open();
				var dr = cmd.ExecuteReader();

				while (dr.Read()) {
					_cultures.Add(new CultureInfo((int)dr["LanguageId"]));

				}

				con.Close();
				cmd.Dispose();

			}
			return _cultures.AsQueryable();
		}
	}
}
