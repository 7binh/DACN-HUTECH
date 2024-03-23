using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace Librari
{
	public class AccessDB
	{
		public static string sConn = ConfigurationManager.ConnectionStrings["cs_sqlserver"].ToString();

		/// <summary>
		/// Khởi tạo connect
		/// </summary>
		/// <returns></returns>
		public SqlConnection get_Conn()
		{
			try
			{
				return new SqlConnection(sConn);
			}
			catch (Exception ex)
			{
				return null;
			}
		}
	}
}
