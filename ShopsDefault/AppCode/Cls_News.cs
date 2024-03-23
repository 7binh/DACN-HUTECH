//----------------------------------------------------------------
//Tên Class: Cls_News
//Người thực hiện: Heo95konichiwa
//----------------------------------------------------------------
using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;

namespace Librari {
	public partial class Cls_News
	{
		protected string sSQL;
		#region Tham số cho Procedure
		//Tham số cho Procudure
		protected const string st_tbNewsCatalogs_Insert = "st_tbNewsCatalogs_Insert";
		protected const string st_tbNewsCatalogs_Update = "st_tbNewsCatalogs_Update";
		protected const string st_tbNewsCatalogs_SelectAll_Active_LikeKey = "st_tbNewsCatalogs_SelectAll_Active_LikeKey";
		protected const string st_tbNewsCatalogs_SelectAll_LikeKey = "st_tbNewsCatalogs_SelectAll_LikeKey";
		protected const string st_tbNewsCatalogs_Delete = "st_tbNewsCatalogs_Delete";
		protected const string st_tbNewsCatalogs_SelectByID = "st_tbNewsCatalogs_SelectByID";
		protected const string st_tbNewsCatalogs_SelectAll = "st_tbNewsCatalogs_SelectAll";
		protected const string st_tbNewsCatalogs_Count = "st_tbNewsCatalogs_Count";
		protected const string st_tbNewsCatalogs_Count_Key = "st_tbNewsCatalogs_Count_Key";
		protected const string st_tbNews_Insert = "st_tbNews_Insert";
		protected const string st_tbNews_Update = "st_tbNews_Update";
		protected const string st_tbNews_SelectAll_Active_LikeKey = "st_tbNews_SelectAll_Active_LikeKey";
		protected const string st_tbNews_SelectAll_LikeKey = "st_tbNews_SelectAll_LikeKey";
		protected const string st_tbNews_Delete = "st_tbNews_Delete";
		protected const string st_tbNews_SelectByID = "st_tbNews_SelectByID";
		protected const string st_tbNews_SelectAll = "st_tbNews_SelectAll";
		protected const string st_tbNews_Count = "st_tbNews_Count";
		protected const string st_tbNews_Count_Key = "st_tbNews_Count_Key";
		protected const string TABLE_NAME = "tbNews";
		#endregion Tham số cho Procedure

		#region Các tên filed của table.
		//Các tên filed của table.
		public const string fn_ID_News = "ID_News";
		public const int len_ID_News = 4;

		public const string fn_ID_Catalog = "ID_Catalog";
		public const int len_ID_Catalog = 4;

		public const string fn_Title = "Title";
		public const int len_Title = 400;

		public const string fn_Image = "Image";
		public const int len_Image = 200;

		public const string fn_SummaryContent = "SummaryContent";
		public const int len_SummaryContent = 1000;

		public const string fn_Description = "Description";
		public const int len_Description = 16;

		public const string fn_TitleWeb = "TitleWeb";
		public const int len_TitleWeb = 400;

		public const string fn_LinkSEO = "LinkSEO";
		public const int len_LinkSEO = 200;

		public const string fn_H1SEO = "H1SEO";
		public const int len_H1SEO = 400;

		public const string fn_KeywordSEO = "KeywordSEO";
		public const int len_KeywordSEO = 16;

		public const string fn_AddTime = "AddTime";
		public const int len_AddTime = 8;

		public const string fn_EditTime = "EditTime";
		public const int len_EditTime = 8;

		public const string fn_Hidden = "Hidden";
		public const int len_Hidden = 1;

		//Các tên filed của table.
		private int _iD_News_find;
		private int _iD_News;
		private int _iD_Catalog;
		private string _title;
		private string _image;
		private string _summaryContent;
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
		//Thuộc tínhID_News_find
		public int ID_News_find
		{
			get{return this._iD_News_find;}
			set{this._iD_News_find = value;}
		}

		//Thuộc tínhID_News
		public int ID_News
		{
			get{return this._iD_News;}
			set{this._iD_News = value;}
		}

		//Thuộc tínhID_Catalog
		public int ID_Catalog
		{
			get{return this._iD_Catalog;}
			set{this._iD_Catalog = value;}
		}

		//Thuộc tínhTitle
		public string Title
		{
			get{return this._title;}
			set{this._title = value;}
		}

		//Thuộc tínhImage
		public string Image
		{
			get{return this._image;}
			set{this._image = value;}
		}

		//Thuộc tínhSummaryContent
		public string SummaryContent
		{
			get{return this._summaryContent;}
			set{this._summaryContent = value;}
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
		public Cls_News()
		{
		}

		/// <summary>
		/// Hàm khởi tạo có tham số.
		/// </summary>
		public Cls_News(int id_news, int id_catalog, string title, string image, string summarycontent, string description, string titleweb, string linkseo, string h1seo, string keywordseo, DateTime addtime, DateTime edittime, bool hidden)
		{
			this._iD_News = id_news;
			this._iD_Catalog = id_catalog;
			this._title = title;
			this._image = image;
			this._summaryContent = summarycontent;
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
			SqlCommand sqlComm = new SqlCommand("st_tbNews_Count", conn);
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
			SqlCommand sqlComm = new SqlCommand("st_tbNews_Count_Key", conn);
			sqlComm.CommandType = CommandType.StoredProcedure;
			try
			{
				sqlComm.Parameters.Add("@ID_News", SqlDbType.Int).Value = ID_News;
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
		public static bool Exits_Key(int key_ID_News)
		{
			SqlConnection conn = new AccessDB().get_Conn();
			SqlCommand sqlComm = new SqlCommand("st_tbNews_Count_Key", conn);
			sqlComm.CommandType = CommandType.StoredProcedure;
			try
			{
				sqlComm.Parameters.Add("@ID_News", SqlDbType.Int).Value = key_ID_News;
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
			string sSQL = "Select MAX(ID_News) From tbNews";
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
			string sSQL = "Select Top 0 * From tbNews";
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
			string sSQL = "Select Top " + top + " * From  tbNews";
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
				string sSQL = "SELECT * FROM tbNews" + strWhere;
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
				string sSQL = "SELECT * FROM tbNews" + strWhere + FieldSort;
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
				string sSQL = "SELECT * FROM tbNews" + strWhere;
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
			SqlCommand sqlComm = new SqlCommand(st_tbNews_SelectAll, conn);
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
		public static DataTable getDataTable_My(int key_ID_News)
		{
			SqlConnection conn = new AccessDB().get_Conn();
			SqlCommand sqlComm = new SqlCommand(st_tbNews_SelectByID, conn);
			sqlComm.CommandType = CommandType.StoredProcedure;
			DataTable dt = new DataTable();
			try
			{
				conn.Open();
				sqlComm.Parameters.Add("@ID_News", SqlDbType.Int).Value = key_ID_News;
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
			SqlCommand sqlComm = new SqlCommand(st_tbNews_SelectAll_LikeKey, conn);
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
			SqlCommand sqlComm = new SqlCommand("st_tbNewsSelectAll_Hidden", conn);
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
        /// Get DataTable với Where.
        /// </summary>
        /// <returns></returns>
        public static DataTable getDataTableJoinShopsCatalogs(string strWhere)
        {
            try
            {
                if (strWhere.Trim().Length == 0) strWhere = "";
                else strWhere = " WHERE " + strWhere;
                string sSQL = "SELECT * FROM tbNews, tbNewsCatalogs" + strWhere;
                return getDataTable_SQL_pro(sSQL);
            }
            catch (SqlException ex)
            {
                return null;
            }
        }

        /// <summary>
        /// Get DataTable với tbNewsCatalogstable class.
        /// </summary>
        /// <param name="ID">ID</param>
        /// <returns></returns>
        public static DataTable getDataTableJoinNewsCatalogs()
		{
			SqlConnection conn = new AccessDB().get_Conn();
			SqlCommand sqlComm = new SqlCommand("st_tbNews_SelectJointbNewsCatalogs", conn);
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
			SqlCommand sqlComm = new SqlCommand("st_tbNews_SelectByID_Catalog", conn);
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
			SqlCommand sqlComm = new SqlCommand("st_tbNews_SelectByID_Catalog_All", conn);
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
			SqlCommand sqlComm = new SqlCommand("st_tbNews_CountByID_Catalog_All", conn);
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
		/// Count DataTable với ID_NewsCatalogs table class.
		/// </summary>
		/// <param name="ID">ID</param>
		/// <returns></returns>
		public static int Count_With_ID_Catalog(int ID_Catalog)
		{
			SqlConnection conn = new AccessDB().get_Conn();
			SqlCommand sqlComm = new SqlCommand("st_tbNews_CountByID_NewsCatalogs", conn);
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
			SqlCommand sqlComm = new SqlCommand(st_tbNews_Insert, conn);
			sqlComm.CommandType = CommandType.StoredProcedure;
			try
			{
				//ID_Catalog
				sqlComm.Parameters.Add("@ID_Catalog", SqlDbType.Int).Value = ID_Catalog;
				//Title
				sqlComm.Parameters.Add("@Title", SqlDbType.NVarChar).Value = Title;
				//Image
				sqlComm.Parameters.Add("@Image", SqlDbType.NVarChar).Value = Image;
				//SummaryContent
				sqlComm.Parameters.Add("@SummaryContent", SqlDbType.NVarChar).Value = SummaryContent;
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
			SqlCommand sqlComm = new SqlCommand(st_tbNews_Update, conn);
			sqlComm.CommandType = CommandType.StoredProcedure;
			try
			{
				conn.Open();
				//ID_News
				sqlComm.Parameters.Add("@ID_News_find", SqlDbType.Int).Value = ID_News_find;
				//ID_Catalog
				sqlComm.Parameters.Add("@ID_Catalog", SqlDbType.Int).Value = ID_Catalog;
				//Title
				if (Title != null)
					sqlComm.Parameters.Add("@Title", SqlDbType.NVarChar).Value = Title;
				else
					sqlComm.Parameters.Add("@Title", SqlDbType.NVarChar).Value = DBNull.Value;
				//Image
				if (Image != null)
					sqlComm.Parameters.Add("@Image", SqlDbType.NVarChar).Value = Image;
				else
					sqlComm.Parameters.Add("@Image", SqlDbType.NVarChar).Value = DBNull.Value;
				//SummaryContent
				if (SummaryContent != null)
					sqlComm.Parameters.Add("@SummaryContent", SqlDbType.NVarChar).Value = SummaryContent;
				else
					sqlComm.Parameters.Add("@SummaryContent", SqlDbType.NVarChar).Value = DBNull.Value;
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
		public int doUpdate_KEY(string Key_ID_News_Old, string Key_ID_News_New)
		{
			SqlConnection conn = new AccessDB().get_Conn();
			string sql = "Update tbNews Set ID_News=@ID_News_New Where ID_News=@ID_News_old";
			SqlCommand sqlComm = new SqlCommand(sql, conn);
			sqlComm.CommandType = CommandType.Text;
			try
			{
				sqlComm.Parameters.Add("@ID_News_New", SqlDbType.Int).Value = Key_ID_News_New;
				sqlComm.Parameters.Add("@ID_News_old", SqlDbType.Int).Value = Key_ID_News_Old;
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
			SqlCommand sqlComm = new SqlCommand(st_tbNews_Delete, conn);
			sqlComm.CommandType = CommandType.StoredProcedure;
			try
			{
				sqlComm.Parameters.Add("@ID_News", SqlDbType.Int).Value = ID_News_find;
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
		public static Cls_News converDataRow_To_Object(DataRow dr)
		{
			Cls_News _Object = new Cls_News();
			//ID_News
			if(dr.Table.Columns.Contains(fn_ID_News))
			if(dr[fn_ID_News]!= DBNull.Value)
			_Object.ID_News =  (int)dr[fn_ID_News];

			//ID_Catalog
			if(dr.Table.Columns.Contains(fn_ID_Catalog))
			if(dr[fn_ID_Catalog]!= DBNull.Value)
			_Object.ID_Catalog =  (int)dr[fn_ID_Catalog];

			//Title
			if(dr.Table.Columns.Contains(fn_Title))
			if(dr[fn_Title]!= DBNull.Value)
			_Object.Title =  (string)dr[fn_Title];

			//Image
			if(dr.Table.Columns.Contains(fn_Image))
			if(dr[fn_Image]!= DBNull.Value)
			_Object.Image =  (string)dr[fn_Image];

			//SummaryContent
			if(dr.Table.Columns.Contains(fn_SummaryContent))
			if(dr[fn_SummaryContent]!= DBNull.Value)
			_Object.SummaryContent =  (string)dr[fn_SummaryContent];

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
		public static Cls_News getOject_Key(int key_ID_News)
		{
			DataTable dt = getDataTable_My(key_ID_News);
			if (dt.Rows.Count > 0)
				return converDataRow_To_Object(dt.Rows[0]);
			else
				return null;
		}

		/// <summary>
		/// Get Array object class có parameter.
		/// </summary>
		/// <returns></returns>
		public static Cls_News[] getArrayObject(DataTable dt)
		{
			if (dt.Rows.Count == 0) return null;
			Cls_News[] arr = new Cls_News[dt.Rows.Count];
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
		public static Cls_News[] getArrayObject()
		{
			return getArrayObject(getDataTable_My());
		}
	}
}
