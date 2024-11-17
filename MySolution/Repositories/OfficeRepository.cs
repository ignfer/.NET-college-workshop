using System;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;
using MySolution.Models;

namespace MySolution.Repositories
{
	public class OfficeRepository
	{
		private string _connectionString = "Data Source=sqlite-database.db";

		public List<OfficePrev> GetOffices()
		{
			var offices = new List<OfficePrev>();
			var c = new SqliteConnection(_connectionString);
			using (var connection = new SqliteConnection(_connectionString))
			{
				connection.Open();
				string query = "SELECT id, Name FROM office";

				using (var command = new SqliteCommand(query, connection))
				using (var reader = command.ExecuteReader())
				{
					while (reader.Read())
					{
						var office = new OfficePrev(
							id: reader.GetInt32(0),            
							name: reader.GetString(1),
							inProgressDesks: new List<DeskPrev>(),
							waitingClients: new List<ClientPrev>()
						);

						offices.Add(office);
					}
				}
			}

			return offices;
		}
	}
}