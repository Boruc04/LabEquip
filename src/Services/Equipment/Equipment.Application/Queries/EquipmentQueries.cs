using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Boruc.LabEquip.Services.Equipment.Application.Queries
{
	public class EquipmentQueries : IEquipmentQueries
	{
		private readonly string _connectionString;

		public EquipmentQueries(string connectionString)
		{
			_connectionString = !string.IsNullOrWhiteSpace(connectionString)
				? connectionString
				: throw new ArgumentException(nameof(connectionString));
		}

		public async Task<IEnumerable<Equipment>> GetEquipmentsAsync()
		{
			using (var connection = new SqlConnection(_connectionString))
			{
				connection.Open();

				var result = await connection.QueryAsync<Equipment>(@"SELECT [Id]
																	      ,[AddedOnUTC]
																	      ,[BookId]
																	      ,[Name]
																	      ,[Number]
																		FROM [Boruc.LabEquip.Equipment].[equipment].[equipments]");
				return result;
			}
		}

		public async Task<Equipment> GetEquipmentAsync(int equipmentId)
		{
			using (var connection = new SqlConnection(_connectionString))
			{
				connection.Open();

				var result = await connection.QueryAsync<Equipment>(@"SELECT [Id]
																	      ,[AddedOnUTC]
																	      ,[BookId]
																	      ,[Name]
																	      ,[Number]
																		FROM [Boruc.LabEquip.Equipment].[equipment].[equipments] 
																		WHERE [Id] = @id", new { id = equipmentId });
				if (result.AsList().Count == 0)
					throw new KeyNotFoundException();

				return result.AsList()[0];
			}
		}
	}
}
