using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Do_an_co_so
{
	internal class Modify
	{
		public Modify()
		{
		}

		SqlCommand sqlCommand; // dùng để truy vấn các câu lệnh insert, update, delete,...
		SqlDataReader dataReader; // dùng để đọc dữ liệu trong bảng

		public List<TaiKhoan> TaiKhoan(string query)
		{
			List<TaiKhoan> taikhoans = new List<TaiKhoan>();

			using (SqlConnection sqlConnection = Connection.GetSqlConnection())
			{
				sqlConnection.Open(); // Corrected from SqlConnection.Open() to sqlConnection.Open()
				sqlCommand = new SqlCommand(query, sqlConnection); // Corrected from SqlCommand to sqlCommand
				dataReader = sqlCommand.ExecuteReader();
				while (dataReader.Read())
				{
					taikhoans.Add(new TaiKhoan(dataReader.GetString(0), dataReader.GetString(1)));
				}
				sqlConnection.Close();
			}
			return taikhoans;
		}
	}
}
