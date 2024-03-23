//----------------------------------------------------------------
//Tên Class: Cls_Logs
//Người thực hiện: Heo95konichiwa
//----------------------------------------------------------------
using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;

namespace Librari {
	public partial class Cls_Logs
	{
		protected string sSQL;
		#region Tham số cho Procedure
		//Tham số cho Procudure
		protected const string st_tbLogs_Insert = "st_tbLogs_Insert";
		protected const string st_tbLogs_Update = "st_tbLogs_Update";
		protected const string st_tbLogs_SelectAll_Active_LikeKey = "st_tbLogs_SelectAll_Active_LikeKey";
		protected const string st_tbLogs_SelectAll_LikeKey = "st_tbLogs_SelectAll_LikeKey";
		protected const string st_tbLogs_Delete = "st_tbLogs_Delete";
		protected const string st_tbLogs_SelectByID = "st_tbLogs_SelectByID";
		protected const string st_tbLogs_SelectAll = "st_tbLogs_SelectAll";
		protected const string st_tbLogs_Count = "st_tbLogs_Count";
		protected const string st_tbLogs_Count_Key = "st_tbLogs_Count_Key";
		protected const string TABLE_NAME = "tbLogs";
		#endregion Tham số cho Procedure

		#region Các tên filed của table.
		//Các tên filed của table.
		public const string fn_ID_Log = "ID_Log";
		public const int len_ID_Log = 4;

		public const string fn_ID_User = "ID_User";
		public const int len_ID_User = 4;

		public const string fn_Description = "Description";
		public const int len_Description = 16;

		public const string fn_AddTime = "AddTime";
		public const int len_AddTime = 8;

		public const string fn_Hidden = "Hidden";
		public const int len_Hidden = 1;

		//Các tên filed của table.
		private int _iD_Log_find;
		private int _iD_Log;
		private int _iD_User;
		private string _description;
		private DateTime _addTime;
		private bool _hidden;
		#endregion Các tên filed của table.

		#region Các phương thức cho table.
		//Thuộc tínhID_Log_find
		public int ID_Log_find
		{
			get{return this._iD_Log_find;}
			set{this._iD_Log_find = value;}
		}

		//Thuộc tínhID_Log
		public int ID_Log
		{
			get{return this._iD_Log;}
			set{this._iD_Log = value;}
		}

		//Thuộc tínhID_User
		public int ID_User
		{
			get{return this._iD_User;}
			set{this._iD_User = value;}
		}

		//Thuộc tínhDescription
		public string Description
		{
			get{return this._description;}
			set{this._description = value;}
		}

		//Thuộc tínhAddTime
		public DateTime AddTime
		{
			get{return this._addTime;}
			set{this._addTime = value;}
		}

		//Thuộc tínhHidden
		public bool Hidden
		{
			get{return this._hidden;}
			set{this._hidden = value;}
		}
		#endregion Các phương thức cho table.

		/// <summary>
		/// Hàm khởi tạo không có tham số.
		/// </summary>
		public Cls_Logs()
		{
		}

		/// <summary>
		/// Hàm khởi tạo có tham số.
		/// </summary>
		public Cls_Logs(int id_log, int id_user, string description, DateTime addtime, bool hidden)
		{
			this._iD_Log = id_log;
			this._iD_User = id_user;
			this._description = description;
			this._addTime = addtime;
			this._hidden = hidden;
		}

		/// <summary>
		/// Đếm tổng số bảng ghi.
		/// </summary>
		/// <returns></returns>
		public static int countRows(bool Hidden)
		{
			SqlConnection conn = new AccessDB().get_Conn();
			SqlCommand sqlComm = new SqlCommand("st_tbLogs_Count", conn);
			sqlComm.CommandType = CommandType.StoredProcedure;
			sqlComm.Parameters.Add("@Hidden", SqlDbType.Bit).Value = Hidden;
			try
			{
				conn.Open();
				int intResult= (int)sqlComm.ExecuteScalar();
				return intResult;
			}
			catch (SqlException ex)
			{
				throw ex;
			}
			finally
			{
				if (sqlComm != null) sqlComm.Dispose();
				if (conn != null) conn.Close();
			}
		}

		/// <summary>
		/// Xác định Khóa chính có tồn tại dữ liệu.
		/// </summary>
		/// <returns>Truy: Có; False: Không</returns>
		public bool Exits_Key()
		{
			SqlConnection conn = new AccessDB().get_Conn();
			SqlCommand sqlComm = new SqlCommand("st_tbLogs_Count_Key", conn);
			sqlComm.CommandType = CommandType.StoredProcedure;
			try
			{
				sqlComm.Parameters.Add("@ID_Log", SqlDbType.Int).Value = ID_Log;
				conn.Open();
				if (((int)sqlComm.ExecuteScalar()) == 1) return true;
				else return false;
			}
			catch (SqlException ex)
			{
				throw ex;
				return false;
			}
			finally
			{
				if (sqlComm != null) sqlComm.Dispose();
				if (conn != null) conn.Close();
			}
		}

		/// <summary>
		/// Xác định Khóa chính có tồn tại dữ liệu.
		/// </summary>
		/// <returns>Truy: Có; False: Không</returns>
		public static bool Exits_Key(int key_ID_Log)
		{
			SqlConnection conn = new AccessDB().get_Conn();
			SqlCommand sqlComm = new SqlCommand("st_tbLogs_Count_Key", conn);
			sqlComm.CommandType = CommandType.StoredProcedure;
			try
			{
				sqlComm.Parameters.Add("@ID_Log", SqlDbType.Int).Value = key_ID_Log;
				conn.Open();
				if (((int)sqlComm.ExecuteScalar()) == 1) return true;
				else return false;
			}
			catch (SqlException ex)
			{
				throw ex;
				return false;
			}
			finally
			{
				if (sqlComm != null) sqlComm.Dispose();
				if (conn != null) conn.Close();
			}
		}

		/// <summary>
		/// Get max ID auto.
		/// </summary>
		/// <returns></returns>
		public static int getMaxIdAuto()
		{
			SqlConnection conn = new AccessDB().get_Conn();
			string sSQL = "Select MAX(ID_Log) From tbLogs";
			SqlCommand sqlComm = new SqlCommand(sSQL, conn);
			sqlComm.CommandType = CommandType.Text;
			try
			{
				conn.Open();
				return (int)sqlComm.ExecuteScalar();
			}
			catch (SqlException ex)
			{
				throw ex;
			}
			finally
			{
				if (sqlComm != null) sqlComm.Dispose();
				if (conn != null) conn.Close();
			}
		}

		/// <summary>
		/// Get DataTable NULL với table class.
		/// </summary>
		/// <returns></returns>
		public static DataTable getDataTable_NULL()
		{
			SqlConnection conn = new AccessDB().get_Conn();
			string sSQL = "Select Top 0 * From tbLogs";
			SqlCommand sqlComm = new SqlCommand(sSQL, conn);
			sqlComm.CommandType = CommandType.Text;
			try
			{
				SqlDataAdapter sqlDTA = new SqlDataAdapter(sqlComm);
				DataTable dt = new DataTable();
				conn.Open();
				sqlDTA.Fill(dt);
				return dt;
			}
			catch (SqlException ex)
			{
				throw ex;
			}
			finally
			{
				if (sqlComm != null) sqlComm.Dispose();
				if (conn != null) conn.Close();
			}
		}

		/// <summary>
		/// Get TOP DataRows với table class.
		/// </summary>
		/// <returns></returns>
		public static DataTable getDataTable_ByTop(string top)
		{
			SqlConnection conn = new AccessDB().get_Conn();
			string sSQL = "Select Top " + top + " * From  tbLogs";
			SqlCommand sqlComm = new SqlCommand(sSQL, conn);
			sqlComm.CommandType = CommandType.Text;
			try
			{
				SqlDataAdapter sqlDTA = new SqlDataAdapter(sqlComm);
				DataTable dt = new DataTable();
				conn.Open();
				sqlDTA.Fill(dt);
				return dt;
			}
			catch (SqlException ex)
			{
				throw ex;
			}
			finally
			{
				if (sqlComm != null) sqlComm.Dispose();
				if (conn != null) conn.Close();
			}
		}

		/// <summary>
		/// Get DataTable với Where time.
		/// </summary>
		/// <param name="strWhere">Where get ucChonNgay</param>
		/// <returns></returns>
		public static DataTable getDataTable_Time(string strWhere)
		{
			try
			{
				string sSQL = "SELECT * FROM tbLogs" + strWhere;
				return getDataTable_SQL_pro(sSQL);
			}
			catch (SqlException ex)
			{
			return null;
			}
		}

		/// <summary>
		/// Get DataTable với Where and FieldSort.
		/// </summary>
		/// <returns></returns>
		public static DataTable getDataTable_Where(string strWhere,string FieldSort)
		{
			try
			{
				if (FieldSort.Trim().Length == 0) FieldSort = "";
				else FieldSort = " Order By " + FieldSort;
				if (strWhere.Trim().Length == 0) strWhere = "";
				else strWhere = " WHERE " + strWhere;
				string sSQL = "SELECT * FROM tbLogs" + strWhere + FieldSort;
				return getDataTable_SQL_pro(sSQL);
			}
			catch (SqlException ex)
			{
			return null;
			}
		}

		/// <summary>
		/// Get DataTable với Where.
		/// </summary>
		/// <returns></returns>
		public static DataTable getDataTable_Where(string strWhere)
		{
			try
			{
				if (strWhere.Trim().Length == 0) strWhere = "";
				else strWhere = " WHERE " + strWhere;
				string sSQL = "SELECT * FROM tbLogs" + strWhere;
				return getDataTable_SQL_pro(sSQL);
			}
			catch (SqlException ex)
			{
			return null;
			}
		}

		/// <summary>
		/// Get DataTable ProcessSQL với table class.
		/// </summary>
		/// <param name="ID">ID</param>
		/// <returns></returns>
		public static DataTable getDataTable_SQL_pro(string sSQL)
		{
			SqlConnection conn = new AccessDB().get_Conn();
			SqlCommand sqlComm = new SqlCommand("st_processSQL", conn);
			sqlComm.CommandType = CommandType.StoredProcedure;
			DataTable dt = new DataTable();
			try
			{
				sqlComm.Parameters.Add("@sSQL", SqlDbType.Bit).Value = sSQL;
				SqlDataAdapter sqlDTA = new SqlDataAdapter(sqlComm);
				conn.Open();
				sqlDTA.Fill(dt);
				return dt;
			}
			catch (SqlException ex)
			{
				throw ex;
			}
			finally
			{
				if (dt != null) dt.Dispose();
				if (sqlComm != null) sqlComm.Dispose();
				if (conn != null) conn.Close();
			}
		}

		/// <summary>
		/// Get DataTable My với table class.
		/// </summary>
		/// <param name="ID">ID</param>
		/// <returns></returns>
		public static DataTable getDataTable_My()
		{
			SqlConnection conn = new AccessDB().get_Conn();
			SqlCommand sqlComm = new SqlCommand(st_tbLogs_SelectAll, conn);
			sqlComm.CommandType = CommandType.StoredProcedure;
			SqlDataAdapter sqlDTA = new SqlDataAdapter(sqlComm);
			DataTable dt = new DataTable();
			try
			{
				conn.Open();
				sqlDTA.Fill(dt);
				return dt;
			}
			catch (SqlException ex)
			{
				throw ex;
			}
			finally
			{
				if (dt != null) dt.Dispose();
				if (sqlComm != null) sqlComm.Dispose();
				if (conn != null) conn.Close();
			}
		}

		/// <summary>
		/// Get DataTable My có parameter với table class.
		/// </summary>
		/// <param name="ID">ID</param>
		/// <returns></returns>
		public static DataTable getDataTable_My(int key_ID_Log)
		{
			SqlConnection conn = new AccessDB().get_Conn();
			SqlCommand sqlComm = new SqlCommand(st_tbLogs_SelectByID, conn);
			sqlComm.CommandType = CommandType.StoredProcedure;
			DataTable dt = new DataTable();
			try
			{
				conn.Open();
				sqlComm.Parameters.Add("@ID_Log", SqlDbType.Int).Value = key_ID_Log;
				SqlDataAdapter sqlDTA = new SqlDataAdapter(sqlComm);
				sqlDTA.Fill(dt);
				return dt;
			}
			catch (SqlException ex)
			{
				throw ex;
			}
			finally
			{
				if (dt != null) dt.Dispose();
				if (sqlComm != null) sqlComm.Dispose();
				if (conn != null) conn.Close();
			}
		}

		/// <summary>
		/// Get DataTable Like Key với table class.
		/// </summary>
		/// <param name="ID">ID</param>
		/// <returns></returns>
		public static DataTable getDataTable_LikeKey(string Key)
		{
			SqlConnection conn = new AccessDB().get_Conn();
			SqlCommand sqlComm = new SqlCommand(st_tbLogs_SelectAll_LikeKey, conn);
			sqlComm.CommandType = CommandType.StoredProcedure;
			sqlComm.Parameters.Add("@Key", SqlDbType.NVarChar).Value = Key;
			SqlDataAdapter sqlDTA = new SqlDataAdapter(sqlComm);
			DataTable dt = new DataTable();
			try
			{
				conn.Open();
				sqlDTA.Fill(dt);
				return dt;
			}
			catch (SqlException ex)
			{
				throw ex;
			}
			finally
			{
				if (dt != null) dt.Dispose();
				if (sqlComm != null) sqlComm.Dispose();
				if (conn != null) conn.Close();
			}
		}

		/// <summary>
		/// Get DataTable Hidden với table class.
		/// </summary>
		/// <returns></returns>
		public static DataTable getDataTable_Hidden(bool Hidden)
		{
			SqlConnection conn = new AccessDB().get_Conn();
			SqlCommand sqlComm = new SqlCommand("st_tbLogsSelectAll_Hidden", conn);
			sqlComm.CommandType = CommandType.StoredProcedure;
			SqlDataAdapter sqlDTA = new SqlDataAdapter(sqlComm);
			DataTable dt = new DataTable();
			try
			{
				conn.Open();
				sqlDTA.Fill(dt);
				return dt;
			}
			catch (SqlException ex)
			{
				throw ex;
			}
			finally
			{
				if (dt != null) dt.Dispose();
				if (sqlComm != null) sqlComm.Dispose();
				if (conn != null) conn.Close();
			}
		}

		/// <summary>
		/// Get DataTable với tbUserstable class.
		/// </summary>
		/// <param name="ID">ID</param>
		/// <returns></returns>
		public static DataTable getDataTableJoinUsers()
		{
			SqlConnection conn = new AccessDB().get_Conn();
			SqlCommand sqlComm = new SqlCommand("st_tbLogs_SelectJointbUsers", conn);
			sqlComm.CommandType = CommandType.StoredProcedure;
			SqlDataAdapter sqlDTA = new SqlDataAdapter(sqlComm);
			DataTable dt = new DataTable();
			try
			{
				conn.Open();
				sqlDTA.Fill(dt);
				return dt;
			}
			catch (SqlException ex)
			{
				throw ex;
			}
			finally
			{
				if (dt != null) dt.Dispose();
				if (sqlComm != null) sqlComm.Dispose();
				if (conn != null) conn.Close();
			}
		}

		/// <summary>
		/// Get DataTable với ID_User table class.
		/// </summary>
		/// <param name="ID">ID</param>
		/// <param name="Hidden">Hidden</param>
		/// <returns></returns>
		public static DataTable getDataTable_With_ID_User(int ID_User, bool Hidden)
		{
			SqlConnection conn = new AccessDB().get_Conn();
			SqlCommand sqlComm = new SqlCommand("st_tbLogs_SelectByID_User", conn);
			sqlComm.CommandType = CommandType.StoredProcedure;
			sqlComm.Parameters.Add("@ID_User", SqlDbType.Int).Value = ID_User;
			sqlComm.Parameters.Add("@Hidden", SqlDbType.Bit).Value = Hidden;
			try
			{
				conn.Open();
				SqlDataAdapter sqlDTA = new SqlDataAdapter(sqlComm);
				DataTable dt = new DataTable();
				sqlDTA.Fill(dt);
				return dt;
			}
			catch (SqlException ex)
			{
				throw ex;
			}
			finally
			{
				if (sqlComm != null) sqlComm.Dispose();
				if (conn != null) conn.Close();
			}
		}

		/// <summary>
		/// Get All DataTable với ID_User table class.
		/// </summary>
		/// <param name="ID">ID</param>
		/// <returns></returns>
		public static DataTable getDataTable_With_ID_User(int ID_User)
		{
			SqlConnection conn = new AccessDB().get_Conn();
			SqlCommand sqlComm = new SqlCommand("st_tbLogs_SelectByID_User_All", conn);
			sqlComm.CommandType = CommandType.StoredProcedure;
			sqlComm.Parameters.Add("@ID_User", SqlDbType.Int).Value = ID_User;
			try
			{
				conn.Open();
				SqlDataAdapter sqlDTA = new SqlDataAdapter(sqlComm);
				DataTable dt = new DataTable();
				sqlDTA.Fill(dt);
				return dt;
			}
			catch (SqlException ex)
			{
				throw ex;
			}
			finally
			{
				if (sqlComm != null) sqlComm.Dispose();
				if (conn != null) conn.Close();
			}
		}

		/// <summary>
		/// Count record DataTable với ID ID_Usertable class.
		/// </summary>
		/// <param name="ID">ID</param>
		/// <param name="Hidden">Hidden</param>
		/// <returns></returns>
		public static int CountByID_User(int ID_User, bool Hidden)
		{
			SqlConnection conn = new AccessDB().get_Conn();
			SqlCommand sqlComm = new SqlCommand("st_tbLogs_CountByID_User_All", conn);
			sqlComm.CommandType = CommandType.StoredProcedure;
			sqlComm.Parameters.Add("@ID_User", SqlDbType.Int).Value = ID_User;
			sqlComm.Parameters.Add("@Hidden", SqlDbType.Bit).Value = Hidden;
			try
			{
				conn.Open();
				return (int)sqlComm.ExecuteScalar();
			}
			catch (SqlException ex)
			{
				throw ex;
			}
			finally
			{
				if (sqlComm != null) sqlComm.Dispose();
				if (conn != null) conn.Close();
			}
		}

		/// <summary>
		/// Count DataTable với ID_Users table class.
		/// </summary>
		/// <param name="ID">ID</param>
		/// <returns></returns>
		public static int Count_With_ID_User(int ID_User)
		{
			SqlConnection conn = new AccessDB().get_Conn();
			SqlCommand sqlComm = new SqlCommand("st_tbLogs_CountByID_Users", conn);
			sqlComm.CommandType = CommandType.StoredProcedure;
			sqlComm.Parameters.Add("@ID_User", SqlDbType.Int).Value = ID_User;
			try
			{
				conn.Open();
				return (int)sqlComm.ExecuteScalar();
			}
			catch (SqlException ex)
			{
				throw ex;
			}
			finally
			{
				if (sqlComm != null) sqlComm.Dispose();
				if (conn != null) conn.Close();
			}
		}

		/// <summary>
		/// Thực hiện doSQL dữ liệu.
		/// </summary>
		/// <returns></returns>
		public static bool doSQL(string sSQL)
		{
			SqlConnection conn = new AccessDB().get_Conn();
			SqlCommand sqlComm = new SqlCommand("st_processSQL", conn);
			sqlComm.CommandType = CommandType.StoredProcedure;
			sqlComm.Parameters.Add("@sSQL", SqlDbType.Bit).Value = sSQL;
			try
			{
				conn.Open();
				sqlComm.ExecuteNonQuery();
				return true;
			}
			catch (SqlException ex)
			{
				throw ex;
			}
			finally
			{
				if (sqlComm != null) sqlComm.Dispose();
				if (conn != null) conn.Close();
			}
		}

		/// <summary>
		/// Thực hiện doInsert dữ liệu.
		/// </summary>
		/// <returns></returns>
		public int doInsert()
		{
			SqlConnection conn = new AccessDB().get_Conn();
			SqlCommand sqlComm = new SqlCommand(st_tbLogs_Insert, conn);
			sqlComm.CommandType = CommandType.StoredProcedure;
			try
			{
				//ID_User
				sqlComm.Parameters.Add("@ID_User", SqlDbType.Int).Value = ID_User;
				//Description
				sqlComm.Parameters.Add("@Description", SqlDbType.NText).Value = Description;
				//AddTime
				if (AddTime.Year == 1)
					sqlComm.Parameters.Add("@AddTime", SqlDbType.DateTime).Value = DBNull.Value;
				else
					sqlComm.Parameters.Add("@AddTime", SqlDbType.DateTime).Value = AddTime;
				//Hidden
				sqlComm.Parameters.Add("@Hidden", SqlDbType.Bit).Value = Hidden;
				conn.Open();
				sqlComm.ExecuteNonQuery();
				return 1;
			}
			catch (SqlException ex)
			{
				throw ex;
			}
			finally
			{
				if (sqlComm != null) sqlComm.Dispose();
				if (conn != null) conn.Close();
			}
		}

		/// <summary>
		/// Thực hiện doUpdate dữ liệu.
		/// </summary>
		/// <returns></returns>
		public int doUpdate()
		{
			SqlConnection conn = new AccessDB().get_Conn();
			SqlCommand sqlComm = new SqlCommand(st_tbLogs_Update, conn);
			sqlComm.CommandType = CommandType.StoredProcedure;
			try
			{
				conn.Open();
				//ID_Log
				sqlComm.Parameters.Add("@ID_Log_find", SqlDbType.Int).Value = ID_Log_find;
				//ID_User
				sqlComm.Parameters.Add("@ID_User", SqlDbType.Int).Value = ID_User;
				//Description
				if (Description != null)
					sqlComm.Parameters.Add("@Description", SqlDbType.NText).Value = Description;
				else
					sqlComm.Parameters.Add("@Description", SqlDbType.NText).Value = DBNull.Value;
				//AddTime
				if (AddTime.Year == 1)
					sqlComm.Parameters.Add("@AddTime", SqlDbType.DateTime).Value = DBNull.Value;
				else
					sqlComm.Parameters.Add("@AddTime", SqlDbType.DateTime).Value = AddTime;
				//Hidden
				sqlComm.Parameters.Add("@Hidden", SqlDbType.Bit).Value = Hidden;
				sqlComm.ExecuteNonQuery();
				return 1;
			}
			catch (SqlException ex)
			{
				throw ex;
			}
			finally
			{
				if (sqlComm != null) sqlComm.Dispose();
				if (conn != null) conn.Close();
			}
		}

		/// <summary>
		/// Thực hiện doUpdate Key dữ liệu.
		/// </summary>
		/// <returns></returns>
		public int doUpdate_KEY(string Key_ID_Log_Old, string Key_ID_Log_New)
		{
			SqlConnection conn = new AccessDB().get_Conn();
			string sql = "Update tbLogs Set ID_Log=@ID_Log_New Where ID_Log=@ID_Log_old";
			SqlCommand sqlComm = new SqlCommand(sql, conn);
			sqlComm.CommandType = CommandType.Text;
			try
			{
				sqlComm.Parameters.Add("@ID_Log_New", SqlDbType.Int).Value = Key_ID_Log_New;
				sqlComm.Parameters.Add("@ID_Log_old", SqlDbType.Int).Value = Key_ID_Log_Old;
				conn.Open();
				sqlComm.ExecuteNonQuery();
				return 1;
			}
			catch (SqlException ex)
			{
				throw ex;
			}
			finally
			{
				if (sqlComm != null) sqlComm.Dispose();
				if (conn != null) conn.Close();
			}
		}

		/// <summary>
		/// Thực hiện doDelete dữ liệu.
		/// </summary>
		/// <returns></returns>
		public int doDelete()
		{
			SqlConnection conn = new AccessDB().get_Conn();
			SqlCommand sqlComm = new SqlCommand(st_tbLogs_Delete, conn);
			sqlComm.CommandType = CommandType.StoredProcedure;
			try
			{
				sqlComm.Parameters.Add("@ID_Log", SqlDbType.Int).Value = ID_Log_find;
				conn.Open();
				sqlComm.ExecuteNonQuery();
				return 1;
			}
			catch (SqlException ex)
			{
				throw ex;
			}
			finally
			{
				if (sqlComm != null) sqlComm.Dispose();
				if (conn != null) conn.Close();
			}
		}

		/// <summary>
		/// Converter DataRow sang Object.
		/// </summary>
		/// <returns></returns>
		public static Cls_Logs converDataRow_To_Object(DataRow dr)
		{
			Cls_Logs _Object = new Cls_Logs();
			//ID_Log
			if(dr.Table.Columns.Contains(fn_ID_Log))
			if(dr[fn_ID_Log]!= DBNull.Value)
			_Object.ID_Log =  (int)dr[fn_ID_Log];

			//ID_User
			if(dr.Table.Columns.Contains(fn_ID_User))
			if(dr[fn_ID_User]!= DBNull.Value)
			_Object.ID_User =  (int)dr[fn_ID_User];

			//Description
			if(dr.Table.Columns.Contains(fn_Description))
			if(dr[fn_Description]!= DBNull.Value)
			_Object.Description =  (string)dr[fn_Description];

			//AddTime
			if(dr.Table.Columns.Contains(fn_AddTime))
			if(dr[fn_AddTime]!= DBNull.Value)
			_Object.AddTime =  (DateTime)dr[fn_AddTime];

			//Hidden
			if(dr.Table.Columns.Contains(fn_Hidden))
			if(dr[fn_Hidden]!= DBNull.Value)
			_Object.Hidden =  (bool)dr[fn_Hidden];

			return _Object;
		}

		/// <summary>
		/// Get Oject Key.
		/// </summary>
		/// <param name="ID">ID</param>
		/// <returns></returns>
		public static Cls_Logs getOject_Key(int key_ID_Log)
		{
			DataTable dt = getDataTable_My(key_ID_Log);
			if (dt.Rows.Count > 0)
				return converDataRow_To_Object(dt.Rows[0]);
			else
				return null;
		}

		/// <summary>
		/// Get Array object class có parameter.
		/// </summary>
		/// <returns></returns>
		public static Cls_Logs[] getArrayObject(DataTable dt)
		{
			if (dt.Rows.Count == 0) return null;
			Cls_Logs[] arr = new Cls_Logs[dt.Rows.Count];
			int i = 0;
			foreach (DataRow dr in dt.Rows)
			{
				arr[i] = converDataRow_To_Object(dr);
				i++;
			}
			return arr;
		}

		/// <summary>
		/// Get Array object class.
		/// </summary>
		/// <returns></returns>
		public static Cls_Logs[] getArrayObject()
		{
			return getArrayObject(getDataTable_My());
		}
	}
}
