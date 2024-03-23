//----------------------------------------------------------------
//Tên Class: Cls_ShopsPayments
//Người thực hiện: Heo95konichiwa
//----------------------------------------------------------------
using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;

namespace Librari {
	public partial class Cls_ShopsPayments
	{
		protected string sSQL;
		#region Tham số cho Procedure
		//Tham số cho Procudure
		protected const string st_tbShopsPayments_Insert = "st_tbShopsPayments_Insert";
		protected const string st_tbShopsPayments_Update = "st_tbShopsPayments_Update";
		protected const string st_tbShopsPayments_SelectAll_Active_LikeKey = "st_tbShopsPayments_SelectAll_Active_LikeKey";
		protected const string st_tbShopsPayments_SelectAll_LikeKey = "st_tbShopsPayments_SelectAll_LikeKey";
		protected const string st_tbShopsPayments_Delete = "st_tbShopsPayments_Delete";
		protected const string st_tbShopsPayments_SelectByID = "st_tbShopsPayments_SelectByID";
		protected const string st_tbShopsPayments_SelectAll = "st_tbShopsPayments_SelectAll";
		protected const string st_tbShopsPayments_Count = "st_tbShopsPayments_Count";
		protected const string st_tbShopsPayments_Count_Key = "st_tbShopsPayments_Count_Key";
		protected const string TABLE_NAME = "tbShopsPayments";
		#endregion Tham số cho Procedure

		#region Các tên filed của table.
		//Các tên filed của table.
		public const string fn_ID_Payment = "ID_Payment";
		public const int len_ID_Payment = 4;

		public const string fn_PaymentName = "PaymentName";
		public const int len_PaymentName = 200;

		public const string fn_Description = "Description";
		public const int len_Description = 16;

		public const string fn_AddTime = "AddTime";
		public const int len_AddTime = 8;

		public const string fn_EditTime = "EditTime";
		public const int len_EditTime = 8;

		public const string fn_Hidden = "Hidden";
		public const int len_Hidden = 1;

		//Các tên filed của table.
		private int _iD_Payment_find;
		private int _iD_Payment;
		private string _paymentName;
		private string _description;
		private DateTime _addTime;
		private DateTime _editTime;
		private bool _hidden;
		#endregion Các tên filed của table.

		#region Các phương thức cho table.
		//Thuộc tínhID_Payment_find
		public int ID_Payment_find
		{
			get{return this._iD_Payment_find;}
			set{this._iD_Payment_find = value;}
		}

		//Thuộc tínhID_Payment
		public int ID_Payment
		{
			get{return this._iD_Payment;}
			set{this._iD_Payment = value;}
		}

		//Thuộc tínhPaymentName
		public string PaymentName
		{
			get{return this._paymentName;}
			set{this._paymentName = value;}
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

		//Thuộc tínhEditTime
		public DateTime EditTime
		{
			get{return this._editTime;}
			set{this._editTime = value;}
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
		public Cls_ShopsPayments()
		{
		}

		/// <summary>
		/// Hàm khởi tạo có tham số.
		/// </summary>
		public Cls_ShopsPayments(int id_payment, string paymentname, string description, DateTime addtime, DateTime edittime, bool hidden)
		{
			this._iD_Payment = id_payment;
			this._paymentName = paymentname;
			this._description = description;
			this._addTime = addtime;
			this._editTime = edittime;
			this._hidden = hidden;
		}

		/// <summary>
		/// Đếm tổng số bảng ghi.
		/// </summary>
		/// <returns></returns>
		public static int countRows(bool Hidden)
		{
			SqlConnection conn = new AccessDB().get_Conn();
			SqlCommand sqlComm = new SqlCommand("st_tbShopsPayments_Count", conn);
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
			SqlCommand sqlComm = new SqlCommand("st_tbShopsPayments_Count_Key", conn);
			sqlComm.CommandType = CommandType.StoredProcedure;
			try
			{
				sqlComm.Parameters.Add("@ID_Payment", SqlDbType.Int).Value = ID_Payment;
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
		public static bool Exits_Key(int key_ID_Payment)
		{
			SqlConnection conn = new AccessDB().get_Conn();
			SqlCommand sqlComm = new SqlCommand("st_tbShopsPayments_Count_Key", conn);
			sqlComm.CommandType = CommandType.StoredProcedure;
			try
			{
				sqlComm.Parameters.Add("@ID_Payment", SqlDbType.Int).Value = key_ID_Payment;
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
			string sSQL = "Select MAX(ID_Payment) From tbShopsPayments";
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
			string sSQL = "Select Top 0 * From tbShopsPayments";
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
			string sSQL = "Select Top " + top + " * From  tbShopsPayments";
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
				string sSQL = "SELECT * FROM tbShopsPayments" + strWhere;
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
				string sSQL = "SELECT * FROM tbShopsPayments" + strWhere + FieldSort;
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
				string sSQL = "SELECT * FROM tbShopsPayments" + strWhere;
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
				sqlComm.Parameters.Add("@sSQL", SqlDbType.NVarChar).Value = sSQL;
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
			SqlCommand sqlComm = new SqlCommand(st_tbShopsPayments_SelectAll, conn);
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
		public static DataTable getDataTable_My(int key_ID_Payment)
		{
			SqlConnection conn = new AccessDB().get_Conn();
			SqlCommand sqlComm = new SqlCommand(st_tbShopsPayments_SelectByID, conn);
			sqlComm.CommandType = CommandType.StoredProcedure;
			DataTable dt = new DataTable();
			try
			{
				conn.Open();
				sqlComm.Parameters.Add("@ID_Payment", SqlDbType.Int).Value = key_ID_Payment;
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
			SqlCommand sqlComm = new SqlCommand(st_tbShopsPayments_SelectAll_LikeKey, conn);
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
			SqlCommand sqlComm = new SqlCommand("st_tbShopsPaymentsSelectAll_Hidden", conn);
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
			SqlCommand sqlComm = new SqlCommand(st_tbShopsPayments_Insert, conn);
			sqlComm.CommandType = CommandType.StoredProcedure;
			try
			{
				//PaymentName
				sqlComm.Parameters.Add("@PaymentName", SqlDbType.NVarChar).Value = PaymentName;
				//Description
				sqlComm.Parameters.Add("@Description", SqlDbType.NText).Value = Description;
				//AddTime
				if (AddTime.Year == 1)
					sqlComm.Parameters.Add("@AddTime", SqlDbType.DateTime).Value = DBNull.Value;
				else
					sqlComm.Parameters.Add("@AddTime", SqlDbType.DateTime).Value = AddTime;
				//EditTime
				if (EditTime.Year == 1)
					sqlComm.Parameters.Add("@EditTime", SqlDbType.DateTime).Value = DBNull.Value;
				else
					sqlComm.Parameters.Add("@EditTime", SqlDbType.DateTime).Value = EditTime;
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
			SqlCommand sqlComm = new SqlCommand(st_tbShopsPayments_Update, conn);
			sqlComm.CommandType = CommandType.StoredProcedure;
			try
			{
				conn.Open();
				//ID_Payment
				sqlComm.Parameters.Add("@ID_Payment_find", SqlDbType.Int).Value = ID_Payment_find;
				//PaymentName
				if (PaymentName != null)
					sqlComm.Parameters.Add("@PaymentName", SqlDbType.NVarChar).Value = PaymentName;
				else
					sqlComm.Parameters.Add("@PaymentName", SqlDbType.NVarChar).Value = DBNull.Value;
				//Description
				if (Description != null)
					sqlComm.Parameters.Add("@Description", SqlDbType.NText).Value = Description;
				else
					sqlComm.Parameters.Add("@Description", SqlDbType.NText).Value = DBNull.Value;
				//EditTime
				if (EditTime.Year == 1)
					sqlComm.Parameters.Add("@EditTime", SqlDbType.DateTime).Value = DBNull.Value;
				else
					sqlComm.Parameters.Add("@EditTime", SqlDbType.DateTime).Value = EditTime;
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
		public int doUpdate_KEY(string Key_ID_Payment_Old, string Key_ID_Payment_New)
		{
			SqlConnection conn = new AccessDB().get_Conn();
			string sql = "Update tbShopsPayments Set ID_Payment=@ID_Payment_New Where ID_Payment=@ID_Payment_old";
			SqlCommand sqlComm = new SqlCommand(sql, conn);
			sqlComm.CommandType = CommandType.Text;
			try
			{
				sqlComm.Parameters.Add("@ID_Payment_New", SqlDbType.Int).Value = Key_ID_Payment_New;
				sqlComm.Parameters.Add("@ID_Payment_old", SqlDbType.Int).Value = Key_ID_Payment_Old;
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
			SqlCommand sqlComm = new SqlCommand(st_tbShopsPayments_Delete, conn);
			sqlComm.CommandType = CommandType.StoredProcedure;
			try
			{
				sqlComm.Parameters.Add("@ID_Payment", SqlDbType.Int).Value = ID_Payment_find;
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
		public static Cls_ShopsPayments converDataRow_To_Object(DataRow dr)
		{
			Cls_ShopsPayments _Object = new Cls_ShopsPayments();
			//ID_Payment
			if(dr.Table.Columns.Contains(fn_ID_Payment))
			if(dr[fn_ID_Payment]!= DBNull.Value)
			_Object.ID_Payment =  (int)dr[fn_ID_Payment];

			//PaymentName
			if(dr.Table.Columns.Contains(fn_PaymentName))
			if(dr[fn_PaymentName]!= DBNull.Value)
			_Object.PaymentName =  (string)dr[fn_PaymentName];

			//Description
			if(dr.Table.Columns.Contains(fn_Description))
			if(dr[fn_Description]!= DBNull.Value)
			_Object.Description =  (string)dr[fn_Description];

			//AddTime
			if(dr.Table.Columns.Contains(fn_AddTime))
			if(dr[fn_AddTime]!= DBNull.Value)
			_Object.AddTime =  (DateTime)dr[fn_AddTime];

			//EditTime
			if(dr.Table.Columns.Contains(fn_EditTime))
			if(dr[fn_EditTime]!= DBNull.Value)
			_Object.EditTime =  (DateTime)dr[fn_EditTime];

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
		public static Cls_ShopsPayments getOject_Key(int key_ID_Payment)
		{
			DataTable dt = getDataTable_My(key_ID_Payment);
			if (dt.Rows.Count > 0)
				return converDataRow_To_Object(dt.Rows[0]);
			else
				return null;
		}

		/// <summary>
		/// Get Array object class có parameter.
		/// </summary>
		/// <returns></returns>
		public static Cls_ShopsPayments[] getArrayObject(DataTable dt)
		{
			if (dt.Rows.Count == 0) return null;
			Cls_ShopsPayments[] arr = new Cls_ShopsPayments[dt.Rows.Count];
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
		public static Cls_ShopsPayments[] getArrayObject()
		{
			return getArrayObject(getDataTable_My());
		}
	}
}
