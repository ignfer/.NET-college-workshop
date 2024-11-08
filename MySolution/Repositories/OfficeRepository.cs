using System;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;
using MySolution.Models;

namespace MySolution.Repositories
{
	public class OfficeRepository
	{
		private string _connectionString = "Data Source=sqlite-database.db";

		public List<Office> GetOffices()
		{
			var offices = new List<Office>();
			var c = new SqliteConnection(_connectionString);
			using (var connection = new SqliteConnection(_connectionString))
			{
				connection.Open();
				string query = "SELECT Id, Name FROM offices";

				using (var command = new SqliteCommand(query, connection))
				using (var reader = command.ExecuteReader())
				{
					while (reader.Read())
					{
						var office = new Office(
							id: reader.GetInt32(0),            
							name: reader.GetString(1),
							inProgressDesks: new List<Desk>(),
							waitingClients: new List<Client>()
						);

						offices.Add(office);
					}
				}
			}

			return offices;
		}
	}
}