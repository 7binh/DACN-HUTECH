//----------------------------------------------------------------
//Tên Class: Cls_ShopsOrdersDetail
//Người thực hiện: Heo95konichiwa
//----------------------------------------------------------------
using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;

namespace Librari {
	public partial class Cls_ShopsOrdersDetail
	{
		protected string sSQL;
		#region Tham số cho Procedure
		//Tham số cho Procudure
		protected const string st_tbShopsOrdersDetail_Insert = "st_tbShopsOrdersDetail_Insert";
		protected const string st_tbShopsOrdersDetail_Update = "st_tbShopsOrdersDetail_Update";
        protected const string st_tbShopsOrdersDetail_UpdateHidden = "st_tbShopsOrdersDetail_UpdateHidden";
        protected const string st_tbShopsOrdersDetail_UpdateStatus = "st_tbShopsOrdersDetail_UpdateStatus";
        protected const string st_tbShopsOrdersDetail_SelectAll_Active_LikeKey = "st_tbShopsOrdersDetail_SelectAll_Active_LikeKey";
		protected const string st_tbShopsOrdersDetail_SelectAll_LikeKey = "st_tbShopsOrdersDetail_SelectAll_LikeKey";
		protected const string st_tbShopsOrdersDetail_Delete = "st_tbShopsOrdersDetail_Delete";
		protected const string st_tbShopsOrdersDetail_SelectByID = "st_tbShopsOrdersDetail_SelectByID";
		protected const string st_tbShopsOrdersDetail_SelectAll = "st_tbShopsOrdersDetail_SelectAll";
		protected const string st_tbShopsOrdersDetail_Count = "st_tbShopsOrdersDetail_Count";
		protected const string st_tbShopsOrdersDetail_Count_Key = "st_tbShopsOrdersDetail_Count_Key";
		protected const string TABLE_NAME = "tbShopsOrdersDetail";
		#endregion Tham số cho Procedure

		#region Các tên filed của table.
		//Các tên filed của table.
		public const string fn_ID_OrderProduct = "ID_OrderProduct";
		public const int len_ID_OrderProduct = 4;

		public const string fn_ID_Payment = "ID_Payment";
		public const int len_ID_Payment = 4;

		public const string fn_ID_User = "ID_User";
		public const int len_ID_User = 4;

		public const string fn_OrdersName = "OrdersName";
		public const int len_OrdersName = 200;

		public const string fn_UserName = "UserName";
		public const int len_UserName = 200;

		public const string fn_UserEmail = "UserEmail";
		public const int len_UserEmail = 200;

		public const string fn_UserAddress = "UserAddress";
		public const int len_UserAddress = 200;

		public const string fn_UserPhone = "UserPhone";
		public const int len_UserPhone = 200;

		public const string fn_Status = "Status";
		public const int len_Status = 200;

		public const string fn_DayIn = "DayIn";
		public const int len_DayIn = 8;

		public const string fn_DayOut = "DayOut";
		public const int len_DayOut = 8;

		public const string fn_Description = "Description";
		public const int len_Description = 16;

		public const string fn_AddTime = "AddTime";
		public const int len_AddTime = 8;

		public const string fn_EditTime = "EditTime";
		public const int len_EditTime = 8;

		public const string fn_Hidden = "Hidden";
		public const int len_Hidden = 1;

		//Các tên filed của table.
		private int _iD_OrderProduct_find;
		private int _iD_OrderProduct;
		private int _iD_Payment;
		private int _iD_User;
		private string _ordersName;
		private string _userName;
		private string _userEmail;
		private string _userAddress;
		private string _userPhone;
		private string _status;
		private DateTime _dayIn;
		private DateTime _dayOut;
		private string _description;
		private DateTime _addTime;
		private DateTime _editTime;
		private bool _hidden;
		#endregion Các tên filed của table.

		#region Các phương thức cho table.
		//Thuộc tínhID_OrderProduct_find
		public int ID_OrderProduct_find
		{
			get{return this._iD_OrderProduct_find;}
			set{this._iD_OrderProduct_find = value;}
		}

		//Thuộc tínhID_OrderProduct
		public int ID_OrderProduct
		{
			get{return this._iD_OrderProduct;}
			set{this._iD_OrderProduct = value;}
		}

		//Thuộc tínhID_Payment
		public int ID_Payment
		{
			get{return this._iD_Payment;}
			set{this._iD_Payment = value;}
		}

		//Thuộc tínhID_User
		public int ID_User
		{
			get{return this._iD_User;}
			set{this._iD_User = value;}
		}

		//Thuộc tínhOrdersName
		public string OrdersName
		{
			get{return this._ordersName;}
			set{this._ordersName = value;}
		}

		//Thuộc tínhUserName
		public string UserName
		{
			get{return this._userName;}
			set{this._userName = value;}
		}

		//Thuộc tínhUserEmail
		public string UserEmail
		{
			get{return this._userEmail;}
			set{this._userEmail = value;}
		}

		//Thuộc tínhUserAddress
		public string UserAddress
		{
			get{return this._userAddress;}
			set{this._userAddress = value;}
		}

		//Thuộc tínhUserPhone
		public string UserPhone
		{
			get{return this._userPhone;}
			set{this._userPhone = value;}
		}

		//Thuộc tínhStatus
		public string Status
		{
			get{return this._status;}
			set{this._status = value;}
		}

		//Thuộc tínhDayIn
		public DateTime DayIn
		{
			get{return this._dayIn;}
			set{this._dayIn = value;}
		}

		//Thuộc tínhDayOut
		public DateTime DayOut
		{
			get{return this._dayOut;}
			set{this._dayOut = value;}
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
		public Cls_ShopsOrdersDetail()
		{
		}

		/// <summary>
		/// Hàm khởi tạo có tham số.
		/// </summary>
		public Cls_ShopsOrdersDetail(int id_orderproduct, int id_payment, int id_user, string ordersname, string username, string useremail, string useraddress, string userphone, string status, DateTime dayin, DateTime dayout, string description, DateTime addtime, DateTime edittime, bool hidden)
		{
			this._iD_OrderProduct = id_orderproduct;
			this._iD_Payment = id_payment;
			this._iD_User = id_user;
			this._ordersName = ordersname;
			this._userName = username;
			this._userEmail = useremail;
			this._userAddress = useraddress;
			this._userPhone = userphone;
			this._status = status;
			this._dayIn = dayin;
			this._dayOut = dayout;
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
			SqlCommand sqlComm = new SqlCommand("st_tbShopsOrdersDetail_Count", conn);
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
			SqlCommand sqlComm = new SqlCommand("st_tbShopsOrdersDetail_Count_Key", conn);
			sqlComm.CommandType = CommandType.StoredProcedure;
			try
			{
				sqlComm.Parameters.Add("@ID_OrderProduct", SqlDbType.Int).Value = ID_OrderProduct;
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
		public static bool Exits_Key(int key_ID_OrderProduct)
		{
			SqlConnection conn = new AccessDB().get_Conn();
			SqlCommand sqlComm = new SqlCommand("st_tbShopsOrdersDetail_Count_Key", conn);
			sqlComm.CommandType = CommandType.StoredProcedure;
			try
			{
				sqlComm.Parameters.Add("@ID_OrderProduct", SqlDbType.Int).Value = key_ID_OrderProduct;
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
			string sSQL = "Select MAX(ID_OrderProduct) From tbShopsOrdersDetail";
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
			string sSQL = "Select Top 0 * From tbShopsOrdersDetail";
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
			string sSQL = "Select Top " + top + " * From  tbShopsOrdersDetail";
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
				string sSQL = "SELECT * FROM tbShopsOrdersDetail" + strWhere;
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
				string sSQL = "SELECT * FROM tbShopsOrdersDetail" + strWhere + FieldSort;
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
				string sSQL = "SELECT * FROM tbShopsOrdersDetail" + strWhere;
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
			SqlCommand sqlComm = new SqlCommand(st_tbShopsOrdersDetail_SelectAll, conn);
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
		public static DataTable getDataTable_My(int key_ID_OrderProduct)
		{
			SqlConnection conn = new AccessDB().get_Conn();
			SqlCommand sqlComm = new SqlCommand(st_tbShopsOrdersDetail_SelectByID, conn);
			sqlComm.CommandType = CommandType.StoredProcedure;
			DataTable dt = new DataTable();
			try
			{
				conn.Open();
				sqlComm.Parameters.Add("@ID_OrderProduct", SqlDbType.Int).Value = key_ID_OrderProduct;
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
			SqlCommand sqlComm = new SqlCommand(st_tbShopsOrdersDetail_SelectAll_LikeKey, conn);
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
			SqlCommand sqlComm = new SqlCommand("st_tbShopsOrdersDetailSelectAll_Hidden", conn);
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
		/// Get DataTable với tbShopsPaymentstable class.
		/// </summary>
		/// <param name="ID">ID</param>
		/// <returns></returns>
		public static DataTable getDataTableJoinShopsPayments()
		{
			SqlConnection conn = new AccessDB().get_Conn();
			SqlCommand sqlComm = new SqlCommand("st_tbShopsOrdersDetail_SelectJointbShopsPayments", conn);
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

        public static DataTable getDataTableJoinShopsPayments(string strWhere)
        {
            try
            {
                if (strWhere.Trim().Length == 0) strWhere = "";
                else strWhere = " WHERE " + strWhere;
                string sSQL = "SELECT * FROM tbShopsOrdersDetail, tbShopsPayments" + strWhere;
                return getDataTable_SQL_pro(sSQL);
            }
            catch (SqlException ex)
            {
                return null;
            }
        }

        /// <summary>
        /// Get DataTable với ID_Payment table class.
        /// </summary>
        /// <param name="ID">ID</param>
        /// <param name="Hidden">Hidden</param>
        /// <returns></returns>
        public static DataTable getDataTable_With_ID_Payment(int ID_Payment, bool Hidden)
		{
			SqlConnection conn = new AccessDB().get_Conn();
			SqlCommand sqlComm = new SqlCommand("st_tbShopsOrdersDetail_SelectByID_Payment", conn);
			sqlComm.CommandType = CommandType.StoredProcedure;
			sqlComm.Parameters.Add("@ID_Payment", SqlDbType.Int).Value = ID_Payment;
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
		/// Get All DataTable với ID_Payment table class.
		/// </summary>
		/// <param name="ID">ID</param>
		/// <returns></returns>
		public static DataTable getDataTable_With_ID_Payment(int ID_Payment)
		{
			SqlConnection conn = new AccessDB().get_Conn();
			SqlCommand sqlComm = new SqlCommand("st_tbShopsOrdersDetail_SelectByID_Payment_All", conn);
			sqlComm.CommandType = CommandType.StoredProcedure;
			sqlComm.Parameters.Add("@ID_Payment", SqlDbType.Int).Value = ID_Payment;
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
		/// Count record DataTable với ID ID_Paymenttable class.
		/// </summary>
		/// <param name="ID">ID</param>
		/// <param name="Hidden">Hidden</param>
		/// <returns></returns>
		public static int CountByID_Payment(int ID_Payment, bool Hidden)
		{
			SqlConnection conn = new AccessDB().get_Conn();
			SqlCommand sqlComm = new SqlCommand("st_tbShopsOrdersDetail_CountByID_Payment_All", conn);
			sqlComm.CommandType = CommandType.StoredProcedure;
			sqlComm.Parameters.Add("@ID_Payment", SqlDbType.Int).Value = ID_Payment;
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
		/// Count DataTable với ID_ShopsPayments table class.
		/// </summary>
		/// <param name="ID">ID</param>
		/// <returns></returns>
		public static int Count_With_ID_Payment(int ID_Payment)
		{
			SqlConnection conn = new AccessDB().get_Conn();
			SqlCommand sqlComm = new SqlCommand("st_tbShopsOrdersDetail_CountByID_ShopsPayments", conn);
			sqlComm.CommandType = CommandType.StoredProcedure;
			sqlComm.Parameters.Add("@ID_Payment", SqlDbType.Int).Value = ID_Payment;
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
			SqlCommand sqlComm = new SqlCommand(st_tbShopsOrdersDetail_Insert, conn);
			sqlComm.CommandType = CommandType.StoredProcedure;
			try
			{
				//ID_Payment
				sqlComm.Parameters.Add("@ID_Payment", SqlDbType.Int).Value = ID_Payment;
				//ID_User
				sqlComm.Parameters.Add("@ID_User", SqlDbType.Int).Value = ID_User;
				//OrdersName
				sqlComm.Parameters.Add("@OrdersName", SqlDbType.NVarChar).Value = OrdersName;
				//UserName
				sqlComm.Parameters.Add("@UserName", SqlDbType.NVarChar).Value = UserName;
				//UserEmail
				sqlComm.Parameters.Add("@UserEmail", SqlDbType.NVarChar).Value = UserEmail;
				//UserAddress
				sqlComm.Parameters.Add("@UserAddress", SqlDbType.NVarChar).Value = UserAddress;
				//UserPhone
				sqlComm.Parameters.Add("@UserPhone", SqlDbType.NVarChar).Value = UserPhone;
				//Status
				sqlComm.Parameters.Add("@Status", SqlDbType.NVarChar).Value = Status;
				//DayIn
				if (DayIn.Year == 1)
					sqlComm.Parameters.Add("@DayIn", SqlDbType.DateTime).Value = DBNull.Value;
				else
					sqlComm.Parameters.Add("@DayIn", SqlDbType.DateTime).Value = DayIn;
				//DayOut
				if (DayOut.Year == 1)
					sqlComm.Parameters.Add("@DayOut", SqlDbType.DateTime).Value = DBNull.Value;
				else
					sqlComm.Parameters.Add("@DayOut", SqlDbType.DateTime).Value = DayOut;
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
			SqlCommand sqlComm = new SqlCommand(st_tbShopsOrdersDetail_Update, conn);
			sqlComm.CommandType = CommandType.StoredProcedure;
			try
			{
				conn.Open();
				//ID_OrderProduct
				sqlComm.Parameters.Add("@ID_OrderProduct_find", SqlDbType.Int).Value = ID_OrderProduct_find;
				//ID_Payment
				sqlComm.Parameters.Add("@ID_Payment", SqlDbType.Int).Value = ID_Payment;
				//ID_User
				sqlComm.Parameters.Add("@ID_User", SqlDbType.Int).Value = ID_User;
				//OrdersName
				if (OrdersName != null)
					sqlComm.Parameters.Add("@OrdersName", SqlDbType.NVarChar).Value = OrdersName;
				else
					sqlComm.Parameters.Add("@OrdersName", SqlDbType.NVarChar).Value = DBNull.Value;
				//UserName
				if (UserName != null)
					sqlComm.Parameters.Add("@UserName", SqlDbType.NVarChar).Value = UserName;
				else
					sqlComm.Parameters.Add("@UserName", SqlDbType.NVarChar).Value = DBNull.Value;
				//UserEmail
				if (UserEmail != null)
					sqlComm.Parameters.Add("@UserEmail", SqlDbType.NVarChar).Value = UserEmail;
				else
					sqlComm.Parameters.Add("@UserEmail", SqlDbType.NVarChar).Value = DBNull.Value;
				//UserAddress
				if (UserAddress != null)
					sqlComm.Parameters.Add("@UserAddress", SqlDbType.NVarChar).Value = UserAddress;
				else
					sqlComm.Parameters.Add("@UserAddress", SqlDbType.NVarChar).Value = DBNull.Value;
				//UserPhone
				if (UserPhone != null)
					sqlComm.Parameters.Add("@UserPhone", SqlDbType.NVarChar).Value = UserPhone;
				else
					sqlComm.Parameters.Add("@UserPhone", SqlDbType.NVarChar).Value = DBNull.Value;
				//Status
				if (Status != null)
					sqlComm.Parameters.Add("@Status", SqlDbType.NVarChar).Value = Status;
				else
					sqlComm.Parameters.Add("@Status", SqlDbType.NVarChar).Value = DBNull.Value;
				//DayIn
				if (DayIn.Year == 1)
					sqlComm.Parameters.Add("@DayIn", SqlDbType.DateTime).Value = DBNull.Value;
				else
					sqlComm.Parameters.Add("@DayIn", SqlDbType.DateTime).Value = DayIn;
				//DayOut
				if (DayOut.Year == 1)
					sqlComm.Parameters.Add("@DayOut", SqlDbType.DateTime).Value = DBNull.Value;
				else
					sqlComm.Parameters.Add("@DayOut", SqlDbType.DateTime).Value = DayOut;
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
        /// Thực hiện doUpdate dữ liệu.
        /// </summary>
        /// <returns></returns>
        public int doUpdateHidden()
        {
            SqlConnection conn = new AccessDB().get_Conn();
            SqlCommand sqlComm = new SqlCommand(st_tbShopsOrdersDetail_UpdateHidden, conn);
            sqlComm.CommandType = CommandType.StoredProcedure;
            try
            {
                conn.Open();
                //ID_OrderProduct
                sqlComm.Parameters.Add("@ID_OrderProduct_find", SqlDbType.Int).Value = ID_OrderProduct_find;
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
        /// Thực hiện doUpdate dữ liệu.
        /// </summary>
        /// <returns></returns>
        public int doUpdateStatus()
        {
            SqlConnection conn = new AccessDB().get_Conn();
            SqlCommand sqlComm = new SqlCommand(st_tbShopsOrdersDetail_UpdateStatus, conn);
            sqlComm.CommandType = CommandType.StoredProcedure;
            try
            {
                conn.Open();
                //ID_OrderProduct
                sqlComm.Parameters.Add("@ID_OrderProduct_find", SqlDbType.Int).Value = ID_OrderProduct_find;
                //UserName
                sqlComm.Parameters.Add("@Status", SqlDbType.NVarChar).Value = Status;
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
        public int doUpdate_KEY(string Key_ID_OrderProduct_Old, string Key_ID_OrderProduct_New)
		{
			SqlConnection conn = new AccessDB().get_Conn();
			string sql = "Update tbShopsOrdersDetail Set ID_OrderProduct=@ID_OrderProduct_New Where ID_OrderProduct=@ID_OrderProduct_old";
			SqlCommand sqlComm = new SqlCommand(sql, conn);
			sqlComm.CommandType = CommandType.Text;
			try
			{
				sqlComm.Parameters.Add("@ID_OrderProduct_New", SqlDbType.Int).Value = Key_ID_OrderProduct_New;
				sqlComm.Parameters.Add("@ID_OrderProduct_old", SqlDbType.Int).Value = Key_ID_OrderProduct_Old;
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
			SqlCommand sqlComm = new SqlCommand(st_tbShopsOrdersDetail_Delete, conn);
			sqlComm.CommandType = CommandType.StoredProcedure;
			try
			{
				sqlComm.Parameters.Add("@ID_OrderProduct", SqlDbType.Int).Value = ID_OrderProduct_find;
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
		public static Cls_ShopsOrdersDetail converDataRow_To_Object(DataRow dr)
		{
			Cls_ShopsOrdersDetail _Object = new Cls_ShopsOrdersDetail();
			//ID_OrderProduct
			if(dr.Table.Columns.Contains(fn_ID_OrderProduct))
			if(dr[fn_ID_OrderProduct]!= DBNull.Value)
			_Object.ID_OrderProduct =  (int)dr[fn_ID_OrderProduct];

			//ID_Payment
			if(dr.Table.Columns.Contains(fn_ID_Payment))
			if(dr[fn_ID_Payment]!= DBNull.Value)
			_Object.ID_Payment =  (int)dr[fn_ID_Payment];

			//ID_User
			if(dr.Table.Columns.Contains(fn_ID_User))
			if(dr[fn_ID_User]!= DBNull.Value)
			_Object.ID_User =  (int)dr[fn_ID_User];

			//OrdersName
			if(dr.Table.Columns.Contains(fn_OrdersName))
			if(dr[fn_OrdersName]!= DBNull.Value)
			_Object.OrdersName =  (string)dr[fn_OrdersName];

			//UserName
			if(dr.Table.Columns.Contains(fn_UserName))
			if(dr[fn_UserName]!= DBNull.Value)
			_Object.UserName =  (string)dr[fn_UserName];

			//UserEmail
			if(dr.Table.Columns.Contains(fn_UserEmail))
			if(dr[fn_UserEmail]!= DBNull.Value)
			_Object.UserEmail =  (string)dr[fn_UserEmail];

			//UserAddress
			if(dr.Table.Columns.Contains(fn_UserAddress))
			if(dr[fn_UserAddress]!= DBNull.Value)
			_Object.UserAddress =  (string)dr[fn_UserAddress];

			//UserPhone
			if(dr.Table.Columns.Contains(fn_UserPhone))
			if(dr[fn_UserPhone]!= DBNull.Value)
			_Object.UserPhone =  (string)dr[fn_UserPhone];

			//Status
			if(dr.Table.Columns.Contains(fn_Status))
			if(dr[fn_Status]!= DBNull.Value)
			_Object.Status =  (string)dr[fn_Status];

			//DayIn
			if(dr.Table.Columns.Contains(fn_DayIn))
			if(dr[fn_DayIn]!= DBNull.Value)
			_Object.DayIn =  (DateTime)dr[fn_DayIn];

			//DayOut
			if(dr.Table.Columns.Contains(fn_DayOut))
			if(dr[fn_DayOut]!= DBNull.Value)
			_Object.DayOut =  (DateTime)dr[fn_DayOut];

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
		public static Cls_ShopsOrdersDetail getOject_Key(int key_ID_OrderProduct)
		{
			DataTable dt = getDataTable_My(key_ID_OrderProduct);
			if (dt.Rows.Count > 0)
				return converDataRow_To_Object(dt.Rows[0]);
			else
				return null;
		}

		/// <summary>
		/// Get Array object class có parameter.
		/// </summary>
		/// <returns></returns>
		public static Cls_ShopsOrdersDetail[] getArrayObject(DataTable dt)
		{
			if (dt.Rows.Count == 0) return null;
			Cls_ShopsOrdersDetail[] arr = new Cls_ShopsOrdersDetail[dt.Rows.Count];
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
		public static Cls_ShopsOrdersDetail[] getArrayObject()
		{
			return getArrayObject(getDataTable_My());
		}
	}
}
