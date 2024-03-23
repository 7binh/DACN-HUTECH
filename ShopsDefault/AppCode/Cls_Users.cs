//----------------------------------------------------------------
//Tên Class: Cls_Users
//Người thực hiện: Heo95konichiwa
//----------------------------------------------------------------
using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;

namespace Librari {
	public partial class Cls_Users
	{
		protected string sSQL;
		#region Tham số cho Procedure
		//Tham số cho Procudure
		protected const string st_tbUsersCatalogs_Insert = "st_tbUsersCatalogs_Insert";
		protected const string st_tbUsersCatalogs_Update = "st_tbUsersCatalogs_Update";
		protected const string st_tbUsersCatalogs_SelectAll_Active_LikeKey = "st_tbUsersCatalogs_SelectAll_Active_LikeKey";
		protected const string st_tbUsersCatalogs_SelectAll_LikeKey = "st_tbUsersCatalogs_SelectAll_LikeKey";
		protected const string st_tbUsersCatalogs_Delete = "st_tbUsersCatalogs_Delete";
		protected const string st_tbUsersCatalogs_SelectByID = "st_tbUsersCatalogs_SelectByID";
		protected const string st_tbUsersCatalogs_SelectAll = "st_tbUsersCatalogs_SelectAll";
		protected const string st_tbUsersCatalogs_Count = "st_tbUsersCatalogs_Count";
		protected const string st_tbUsersCatalogs_Count_Key = "st_tbUsersCatalogs_Count_Key";
		protected const string st_tbUsers_Insert = "st_tbUsers_Insert";
		protected const string st_tbUsers_Update = "st_tbUsers_Update";
		protected const string st_tbUsers_SelectAll_Active_LikeKey = "st_tbUsers_SelectAll_Active_LikeKey";
		protected const string st_tbUsers_SelectAll_LikeKey = "st_tbUsers_SelectAll_LikeKey";
		protected const string st_tbUsers_Delete = "st_tbUsers_Delete";
		protected const string st_tbUsers_SelectByID = "st_tbUsers_SelectByID";
		protected const string st_tbUsers_SelectAll = "st_tbUsers_SelectAll";
		protected const string st_tbUsers_Count = "st_tbUsers_Count";
		protected const string st_tbUsers_Count_Key = "st_tbUsers_Count_Key";
		protected const string TABLE_NAME = "tbUsers";
		#endregion Tham số cho Procedure

		#region Các tên filed của table.
		//Các tên filed của table.
		public const string fn_ID_User = "ID_User";
		public const int len_ID_User = 4;

		public const string fn_ID_Catalog = "ID_Catalog";
		public const int len_ID_Catalog = 4;

		public const string fn_UserName = "UserName";
		public const int len_UserName = 100;

		public const string fn_Password = "Password";
		public const int len_Password = 50;

		public const string fn_FullName = "FullName";
		public const int len_FullName = 200;

		public const string fn_Image = "Image";
		public const int len_Image = 200;

		public const string fn_Gender = "Gender";
		public const int len_Gender = 40;

		public const string fn_Email = "Email";
		public const int len_Email = 100;

		public const string fn_PhoneNumber = "PhoneNumber";
		public const int len_PhoneNumber = 20;

		public const string fn_Description = "Description";
		public const int len_Description = 16;

		public const string fn_TitleWeb = "TitleWeb";
		public const int len_TitleWeb = 200;

		public const string fn_LinkSEO = "LinkSEO";
		public const int len_LinkSEO = 100;

		public const string fn_H1SEO = "H1SEO";
		public const int len_H1SEO = 200;

		public const string fn_KeywordSEO = "KeywordSEO";
		public const int len_KeywordSEO = 16;

		public const string fn_AddTime = "AddTime";
		public const int len_AddTime = 8;

		public const string fn_EditTime = "EditTime";
		public const int len_EditTime = 8;

		public const string fn_Hidden = "Hidden";
		public const int len_Hidden = 1;

		//Các tên filed của table.
		private int _iD_User_find;
		private int _iD_User;
		private int _iD_Catalog;
		private string _userName;
		private string _password;
		private string _fullName;
		private string _image;
		private string _gender;
		private string _email;
		private string _phoneNumber;
		private string _description;
		private string _titleWeb;
		private string _linkSEO;
		private string _h1SEO;
		private string _keywordSEO;
		private DateTime _addTime;
		private DateTime _editTime;
		private bool _hidden;
		#endregion Các tên filed của table.

		#region Các phương thức cho table.
		//Thuộc tínhID_User_find
		public int ID_User_find
		{
			get{return this._iD_User_find;}
			set{this._iD_User_find = value;}
		}

		//Thuộc tínhID_User
		public int ID_User
		{
			get{return this._iD_User;}
			set{this._iD_User = value;}
		}

		//Thuộc tínhID_Catalog
		public int ID_Catalog
		{
			get{return this._iD_Catalog;}
			set{this._iD_Catalog = value;}
		}

		//Thuộc tínhUserName
		public string UserName
		{
			get{return this._userName;}
			set{this._userName = value;}
		}

		//Thuộc tínhPassword
		public string Password
		{
			get{return this._password;}
			set{this._password = value;}
		}

		//Thuộc tínhFullName
		public string FullName
		{
			get{return this._fullName;}
			set{this._fullName = value;}
		}

		//Thuộc tínhImage
		public string Image
		{
			get{return this._image;}
			set{this._image = value;}
		}

		//Thuộc tínhGender
		public string Gender
		{
			get{return this._gender;}
			set{this._gender = value;}
		}

		//Thuộc tínhEmail
		public string Email
		{
			get{return this._email;}
			set{this._email = value;}
		}

		//Thuộc tínhPhoneNumber
		public string PhoneNumber
		{
			get{return this._phoneNumber;}
			set{this._phoneNumber = value;}
		}

		//Thuộc tínhDescription
		public string Description
		{
			get{return this._description;}
			set{this._description = value;}
		}

		//Thuộc tínhTitleWeb
		public string TitleWeb
		{
			get{return this._titleWeb;}
			set{this._titleWeb = value;}
		}

		//Thuộc tínhLinkSEO
		public string LinkSEO
		{
			get{return this._linkSEO;}
			set{this._linkSEO = value;}
		}

		//Thuộc tínhH1SEO
		public string H1SEO
		{
			get{return this._h1SEO;}
			set{this._h1SEO = value;}
		}

		//Thuộc tínhKeywordSEO
		public string KeywordSEO
		{
			get{return this._keywordSEO;}
			set{this._keywordSEO = value;}
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
		public Cls_Users()
		{
		}

		/// <summary>
		/// Hàm khởi tạo có tham số.
		/// </summary>
		public Cls_Users(int id_user, int id_catalog, string username, string password, string fullname, string image, string gender, string email, string phonenumber, string description, string titleweb, string linkseo, string h1seo, string keywordseo, DateTime addtime, DateTime edittime, bool hidden)
		{
			this._iD_User = id_user;
			this._iD_Catalog = id_catalog;
			this._userName = username;
			this._password = password;
			this._fullName = fullname;
			this._image = image;
			this._gender = gender;
			this._email = email;
			this._phoneNumber = phonenumber;
			this._description = description;
			this._titleWeb = titleweb;
			this._linkSEO = linkseo;
			this._h1SEO = h1seo;
			this._keywordSEO = keywordseo;
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
			SqlCommand sqlComm = new SqlCommand("st_tbUsers_Count", conn);
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
			SqlCommand sqlComm = new SqlCommand("st_tbUsers_Count_Key", conn);
			sqlComm.CommandType = CommandType.StoredProcedure;
			try
			{
				sqlComm.Parameters.Add("@ID_User", SqlDbType.Int).Value = ID_User;
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
		public static bool Exits_Key(int key_ID_User)
		{
			SqlConnection conn = new AccessDB().get_Conn();
			SqlCommand sqlComm = new SqlCommand("st_tbUsers_Count_Key", conn);
			sqlComm.CommandType = CommandType.StoredProcedure;
			try
			{
				sqlComm.Parameters.Add("@ID_User", SqlDbType.Int).Value = key_ID_User;
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
			string sSQL = "Select MAX(ID_User) From tbUsers";
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
			string sSQL = "Select Top 0 * From tbUsers";
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
			string sSQL = "Select Top " + top + " * From  tbUsers";
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
				string sSQL = "SELECT * FROM tbUsers" + strWhere;
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
				string sSQL = "SELECT * FROM tbUsers" + strWhere + FieldSort;
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
				string sSQL = "SELECT * FROM tbUsers" + strWhere;
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
			SqlCommand sqlComm = new SqlCommand(st_tbUsers_SelectAll, conn);
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
		public static DataTable getDataTable_My(int key_ID_User)
		{
			SqlConnection conn = new AccessDB().get_Conn();
			SqlCommand sqlComm = new SqlCommand(st_tbUsers_SelectByID, conn);
			sqlComm.CommandType = CommandType.StoredProcedure;
			DataTable dt = new DataTable();
			try
			{
				conn.Open();
				sqlComm.Parameters.Add("@ID_User", SqlDbType.Int).Value = key_ID_User;
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
			SqlCommand sqlComm = new SqlCommand(st_tbUsers_SelectAll_LikeKey, conn);
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
			SqlCommand sqlComm = new SqlCommand("st_tbUsersSelectAll_Hidden", conn);
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
		/// Get DataTable với tbUsersCatalogstable class.
		/// </summary>
		/// <param name="ID">ID</param>
		/// <returns></returns>
		public static DataTable getDataTableJoinUsersCatalogs()
		{
			SqlConnection conn = new AccessDB().get_Conn();
			SqlCommand sqlComm = new SqlCommand("st_tbUsers_SelectJointbUsersCatalogs", conn);
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
		/// Get DataTable với ID_Catalog table class.
		/// </summary>
		/// <param name="ID">ID</param>
		/// <param name="Hidden">Hidden</param>
		/// <returns></returns>
		public static DataTable getDataTable_With_ID_Catalog(int ID_Catalog, bool Hidden)
		{
			SqlConnection conn = new AccessDB().get_Conn();
			SqlCommand sqlComm = new SqlCommand("st_tbUsers_SelectByID_Catalog", conn);
			sqlComm.CommandType = CommandType.StoredProcedure;
			sqlComm.Parameters.Add("@ID_Catalog", SqlDbType.Int).Value = ID_Catalog;
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
		/// Get All DataTable với ID_Catalog table class.
		/// </summary>
		/// <param name="ID">ID</param>
		/// <returns></returns>
		public static DataTable getDataTable_With_ID_Catalog(int ID_Catalog)
		{
			SqlConnection conn = new AccessDB().get_Conn();
			SqlCommand sqlComm = new SqlCommand("st_tbUsers_SelectByID_Catalog_All", conn);
			sqlComm.CommandType = CommandType.StoredProcedure;
			sqlComm.Parameters.Add("@ID_Catalog", SqlDbType.Int).Value = ID_Catalog;
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
		/// Count record DataTable với ID ID_Catalogtable class.
		/// </summary>
		/// <param name="ID">ID</param>
		/// <param name="Hidden">Hidden</param>
		/// <returns></returns>
		public static int CountByID_Catalog(int ID_Catalog, bool Hidden)
		{
			SqlConnection conn = new AccessDB().get_Conn();
			SqlCommand sqlComm = new SqlCommand("st_tbUsers_CountByID_Catalog_All", conn);
			sqlComm.CommandType = CommandType.StoredProcedure;
			sqlComm.Parameters.Add("@ID_Catalog", SqlDbType.Int).Value = ID_Catalog;
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
		/// Count DataTable với ID_UsersCatalogs table class.
		/// </summary>
		/// <param name="ID">ID</param>
		/// <returns></returns>
		public static int Count_With_ID_Catalog(int ID_Catalog)
		{
			SqlConnection conn = new AccessDB().get_Conn();
			SqlCommand sqlComm = new SqlCommand("st_tbUsers_CountByID_UsersCatalogs", conn);
			sqlComm.CommandType = CommandType.StoredProcedure;
			sqlComm.Parameters.Add("@ID_Catalog", SqlDbType.Int).Value = ID_Catalog;
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
			SqlCommand sqlComm = new SqlCommand(st_tbUsers_Insert, conn);
			sqlComm.CommandType = CommandType.StoredProcedure;
			try
			{
				//ID_Catalog
				sqlComm.Parameters.Add("@ID_Catalog", SqlDbType.Int).Value = ID_Catalog;
				//UserName
				sqlComm.Parameters.Add("@UserName", SqlDbType.NVarChar).Value = UserName;
				//Password
				sqlComm.Parameters.Add("@Password", SqlDbType.VarChar).Value = Password;
				//FullName
				sqlComm.Parameters.Add("@FullName", SqlDbType.NVarChar).Value = FullName;
				//Image
				sqlComm.Parameters.Add("@Image", SqlDbType.NVarChar).Value = Image;
				//Gender
				sqlComm.Parameters.Add("@Gender", SqlDbType.NVarChar).Value = Gender;
				//Email
				sqlComm.Parameters.Add("@Email", SqlDbType.VarChar).Value = Email;
				//PhoneNumber
				sqlComm.Parameters.Add("@PhoneNumber", SqlDbType.VarChar).Value = PhoneNumber;
				//Description
				sqlComm.Parameters.Add("@Description", SqlDbType.NText).Value = Description;
				//TitleWeb
				sqlComm.Parameters.Add("@TitleWeb", SqlDbType.NVarChar).Value = TitleWeb;
				//LinkSEO
				sqlComm.Parameters.Add("@LinkSEO", SqlDbType.VarChar).Value = LinkSEO;
				//H1SEO
				sqlComm.Parameters.Add("@H1SEO", SqlDbType.NVarChar).Value = H1SEO;
				//KeywordSEO
				sqlComm.Parameters.Add("@KeywordSEO", SqlDbType.NText).Value = KeywordSEO;
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
			SqlCommand sqlComm = new SqlCommand(st_tbUsers_Update, conn);
			sqlComm.CommandType = CommandType.StoredProcedure;
			try
			{
				conn.Open();
				//ID_User
				sqlComm.Parameters.Add("@ID_User_find", SqlDbType.Int).Value = ID_User_find;
				//ID_Catalog
				sqlComm.Parameters.Add("@ID_Catalog", SqlDbType.Int).Value = ID_Catalog;
				//UserName
				if (UserName != null)
					sqlComm.Parameters.Add("@UserName", SqlDbType.NVarChar).Value = UserName;
				else
					sqlComm.Parameters.Add("@UserName", SqlDbType.NVarChar).Value = DBNull.Value;
				//Password
				if (Password != null)
					sqlComm.Parameters.Add("@Password", SqlDbType.VarChar).Value = Password;
				else
					sqlComm.Parameters.Add("@Password", SqlDbType.VarChar).Value = DBNull.Value;
				//FullName
				if (FullName != null)
					sqlComm.Parameters.Add("@FullName", SqlDbType.NVarChar).Value = FullName;
				else
					sqlComm.Parameters.Add("@FullName", SqlDbType.NVarChar).Value = DBNull.Value;
				//Image
				if (Image != null)
					sqlComm.Parameters.Add("@Image", SqlDbType.NVarChar).Value = Image;
				else
					sqlComm.Parameters.Add("@Image", SqlDbType.NVarChar).Value = DBNull.Value;
				//Gender
				if (Gender != null)
					sqlComm.Parameters.Add("@Gender", SqlDbType.NVarChar).Value = Gender;
				else
					sqlComm.Parameters.Add("@Gender", SqlDbType.NVarChar).Value = DBNull.Value;
				//Email
				if (Email != null)
					sqlComm.Parameters.Add("@Email", SqlDbType.VarChar).Value = Email;
				else
					sqlComm.Parameters.Add("@Email", SqlDbType.VarChar).Value = DBNull.Value;
				//PhoneNumber
				if (PhoneNumber != null)
					sqlComm.Parameters.Add("@PhoneNumber", SqlDbType.VarChar).Value = PhoneNumber;
				else
					sqlComm.Parameters.Add("@PhoneNumber", SqlDbType.VarChar).Value = DBNull.Value;
				//Description
				if (Description != null)
					sqlComm.Parameters.Add("@Description", SqlDbType.NText).Value = Description;
				else
					sqlComm.Parameters.Add("@Description", SqlDbType.NText).Value = DBNull.Value;
				//TitleWeb
				if (TitleWeb != null)
					sqlComm.Parameters.Add("@TitleWeb", SqlDbType.NVarChar).Value = TitleWeb;
				else
					sqlComm.Parameters.Add("@TitleWeb", SqlDbType.NVarChar).Value = DBNull.Value;
				//LinkSEO
				if (LinkSEO != null)
					sqlComm.Parameters.Add("@LinkSEO", SqlDbType.VarChar).Value = LinkSEO;
				else
					sqlComm.Parameters.Add("@LinkSEO", SqlDbType.VarChar).Value = DBNull.Value;
				//H1SEO
				if (H1SEO != null)
					sqlComm.Parameters.Add("@H1SEO", SqlDbType.NVarChar).Value = H1SEO;
				else
					sqlComm.Parameters.Add("@H1SEO", SqlDbType.NVarChar).Value = DBNull.Value;
				//KeywordSEO
				if (KeywordSEO != null)
					sqlComm.Parameters.Add("@KeywordSEO", SqlDbType.NText).Value = KeywordSEO;
				else
					sqlComm.Parameters.Add("@KeywordSEO", SqlDbType.NText).Value = DBNull.Value;
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
		/// Thực hiện doUpdate Key dữ liệu.
		/// </summary>
		/// <returns></returns>
		public int doUpdate_KEY(string Key_ID_User_Old, string Key_ID_User_New)
		{
			SqlConnection conn = new AccessDB().get_Conn();
			string sql = "Update tbUsers Set ID_User=@ID_User_New Where ID_User=@ID_User_old";
			SqlCommand sqlComm = new SqlCommand(sql, conn);
			sqlComm.CommandType = CommandType.Text;
			try
			{
				sqlComm.Parameters.Add("@ID_User_New", SqlDbType.Int).Value = Key_ID_User_New;
				sqlComm.Parameters.Add("@ID_User_old", SqlDbType.Int).Value = Key_ID_User_Old;
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
			SqlCommand sqlComm = new SqlCommand(st_tbUsers_Delete, conn);
			sqlComm.CommandType = CommandType.StoredProcedure;
			try
			{
				sqlComm.Parameters.Add("@ID_User", SqlDbType.Int).Value = ID_User_find;
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
		public static Cls_Users converDataRow_To_Object(DataRow dr)
		{
			Cls_Users _Object = new Cls_Users();
			//ID_User
			if(dr.Table.Columns.Contains(fn_ID_User))
			if(dr[fn_ID_User]!= DBNull.Value)
			_Object.ID_User =  (int)dr[fn_ID_User];

			//ID_Catalog
			if(dr.Table.Columns.Contains(fn_ID_Catalog))
			if(dr[fn_ID_Catalog]!= DBNull.Value)
			_Object.ID_Catalog =  (int)dr[fn_ID_Catalog];

			//UserName
			if(dr.Table.Columns.Contains(fn_UserName))
			if(dr[fn_UserName]!= DBNull.Value)
			_Object.UserName =  (string)dr[fn_UserName];

			//Password
			if(dr.Table.Columns.Contains(fn_Password))
			if(dr[fn_Password]!= DBNull.Value)
			_Object.Password =  (string)dr[fn_Password];

			//FullName
			if(dr.Table.Columns.Contains(fn_FullName))
			if(dr[fn_FullName]!= DBNull.Value)
			_Object.FullName =  (string)dr[fn_FullName];

			//Image
			if(dr.Table.Columns.Contains(fn_Image))
			if(dr[fn_Image]!= DBNull.Value)
			_Object.Image =  (string)dr[fn_Image];

			//Gender
			if(dr.Table.Columns.Contains(fn_Gender))
			if(dr[fn_Gender]!= DBNull.Value)
			_Object.Gender =  (string)dr[fn_Gender];

			//Email
			if(dr.Table.Columns.Contains(fn_Email))
			if(dr[fn_Email]!= DBNull.Value)
			_Object.Email =  (string)dr[fn_Email];

			//PhoneNumber
			if(dr.Table.Columns.Contains(fn_PhoneNumber))
			if(dr[fn_PhoneNumber]!= DBNull.Value)
			_Object.PhoneNumber =  (string)dr[fn_PhoneNumber];

			//Description
			if(dr.Table.Columns.Contains(fn_Description))
			if(dr[fn_Description]!= DBNull.Value)
			_Object.Description =  (string)dr[fn_Description];

			//TitleWeb
			if(dr.Table.Columns.Contains(fn_TitleWeb))
			if(dr[fn_TitleWeb]!= DBNull.Value)
			_Object.TitleWeb =  (string)dr[fn_TitleWeb];

			//LinkSEO
			if(dr.Table.Columns.Contains(fn_LinkSEO))
			if(dr[fn_LinkSEO]!= DBNull.Value)
			_Object.LinkSEO =  (string)dr[fn_LinkSEO];

			//H1SEO
			if(dr.Table.Columns.Contains(fn_H1SEO))
			if(dr[fn_H1SEO]!= DBNull.Value)
			_Object.H1SEO =  (string)dr[fn_H1SEO];

			//KeywordSEO
			if(dr.Table.Columns.Contains(fn_KeywordSEO))
			if(dr[fn_KeywordSEO]!= DBNull.Value)
			_Object.KeywordSEO =  (string)dr[fn_KeywordSEO];

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
		public static Cls_Users getOject_Key(int key_ID_User)
		{
			DataTable dt = getDataTable_My(key_ID_User);
			if (dt.Rows.Count > 0)
				return converDataRow_To_Object(dt.Rows[0]);
			else
				return null;
		}

		/// <summary>
		/// Get Array object class có parameter.
		/// </summary>
		/// <returns></returns>
		public static Cls_Users[] getArrayObject(DataTable dt)
		{
			if (dt.Rows.Count == 0) return null;
			Cls_Users[] arr = new Cls_Users[dt.Rows.Count];
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
		public static Cls_Users[] getArrayObject()
		{
			return getArrayObject(getDataTable_My());
		}
	}
}
