//----------------------------------------------------------------
//Tên Class: Cls_ShopsCatalogs
//Người thực hiện: Heo95konichiwa
//----------------------------------------------------------------
using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;

namespace Librari {
	public partial class Cls_ShopsCatalogs
	{
		protected string sSQL;
		#region Tham số cho Procedure
		//Tham số cho Procudure
		protected const string st_tbShopsCatalogs_Insert = "st_tbShopsCatalogs_Insert";
		protected const string st_tbShopsCatalogs_Update = "st_tbShopsCatalogs_Update";
        protected const string st_tbShopsCatalogs_SelectAll_Active_Not_Parent = "st_tbShopsCatalogs_SelectAll_Active_Not_Parent";
        protected const string st_tbShopsCatalogs_SelectAll_Active_LikeKey = "st_tbShopsCatalogs_SelectAll_Active_LikeKey";
		protected const string st_tbShopsCatalogs_SelectAll_LikeKey = "st_tbShopsCatalogs_SelectAll_LikeKey";
		protected const string st_tbShopsCatalogs_Delete = "st_tbShopsCatalogs_Delete";
		protected const string st_tbShopsCatalogs_SelectByID = "st_tbShopsCatalogs_SelectByID";
        protected const string st_tbShopsCatalogs_SelectByID_NotDate = "st_tbShopsCatalogs_SelectByID_NotDate";
        protected const string st_tbShopsCatalogs_SelectAll = "st_tbShopsCatalogs_SelectAll";
		protected const string st_tbShopsCatalogs_Count = "st_tbShopsCatalogs_Count";
		protected const string st_tbShopsCatalogs_Count_Key = "st_tbShopsCatalogs_Count_Key";
		protected const string TABLE_NAME = "tbShopsCatalogs";
		#endregion Tham số cho Procedure

		#region Các tên filed của table.
		//Các tên filed của table.
		public const string fn_ID_Catalog = "ID_Catalog";
		public const int len_ID_Catalog = 4;

		public const string fn_ID_Parent = "ID_Parent";
		public const int len_ID_Parent = 4;

		public const string fn_CatalogName = "CatalogName";
		public const int len_CatalogName = 200;

		public const string fn_Image = "Image";
		public const int len_Image = 200;

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
		private int _iD_Catalog_find;
		private int _iD_Catalog;
		private int _iD_Parent;
		private string _catalogName;
		private string _image;
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
		//Thuộc tínhID_Catalog_find
		public int ID_Catalog_find
		{
			get{return this._iD_Catalog_find;}
			set{this._iD_Catalog_find = value;}
		}

		//Thuộc tínhID_Catalog
		public int ID_Catalog
		{
			get{return this._iD_Catalog;}
			set{this._iD_Catalog = value;}
		}

		//Thuộc tínhID_Parent
		public int ID_Parent
		{
			get{return this._iD_Parent;}
			set{this._iD_Parent = value;}
		}

		//Thuộc tínhCatalogName
		public string CatalogName
		{
			get{return this._catalogName;}
			set{this._catalogName = value;}
		}

		//Thuộc tínhImage
		public string Image
		{
			get{return this._image;}
			set{this._image = value;}
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
		public Cls_ShopsCatalogs()
		{
		}

		/// <summary>
		/// Hàm khởi tạo có tham số.
		/// </summary>
		public Cls_ShopsCatalogs(int id_catalog, int id_parent, string catalogname, string image, string description, string titleweb, string linkseo, string h1seo, string keywordseo, DateTime addtime, DateTime edittime, bool hidden)
		{
			this._iD_Catalog = id_catalog;
			this._iD_Parent = id_parent;
			this._catalogName = catalogname;
			this._image = image;
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
			SqlCommand sqlComm = new SqlCommand("st_tbShopsCatalogs_Count", conn);
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
			SqlCommand sqlComm = new SqlCommand("st_tbShopsCatalogs_Count_Key", conn);
			sqlComm.CommandType = CommandType.StoredProcedure;
			try
			{
				sqlComm.Parameters.Add("@ID_Catalog", SqlDbType.Int).Value = ID_Catalog;
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
		public static bool Exits_Key(int key_ID_Catalog)
		{
			SqlConnection conn = new AccessDB().get_Conn();
			SqlCommand sqlComm = new SqlCommand("st_tbShopsCatalogs_Count_Key", conn);
			sqlComm.CommandType = CommandType.StoredProcedure;
			try
			{
				sqlComm.Parameters.Add("@ID_Catalog", SqlDbType.Int).Value = key_ID_Catalog;
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
			string sSQL = "Select MAX(ID_Catalog) From tbShopsCatalogs";
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
			string sSQL = "Select Top 0 * From tbShopsCatalogs";
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
			string sSQL = "Select Top " + top + " * From  tbShopsCatalogs";
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
				string sSQL = "SELECT * FROM tbShopsCatalogs" + strWhere;
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
				string sSQL = "SELECT * FROM tbShopsCatalogs" + strWhere + FieldSort;
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
				string sSQL = "SELECT * FROM tbShopsCatalogs" + strWhere;
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
			SqlCommand sqlComm = new SqlCommand(st_tbShopsCatalogs_SelectAll, conn);
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
		public static DataTable getDataTable_My(int key_ID_Catalog)
		{
			SqlConnection conn = new AccessDB().get_Conn();
			SqlCommand sqlComm = new SqlCommand(st_tbShopsCatalogs_SelectByID, conn);
			sqlComm.CommandType = CommandType.StoredProcedure;
			DataTable dt = new DataTable();
			try
			{
				conn.Open();
				sqlComm.Parameters.Add("@ID_Catalog", SqlDbType.Int).Value = key_ID_Catalog;
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
        /// Get DataTable My có parameter với table class.
        /// </summary>
        /// <param name="ID">ID</param>
        /// <returns></returns>
        public static DataTable getDataTable_My_NotDate(int key_ID_Catalog)
        {
            SqlConnection conn = new AccessDB().get_Conn();
            SqlCommand sqlComm = new SqlCommand(st_tbShopsCatalogs_SelectByID_NotDate, conn);
            sqlComm.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            try
            {
                conn.Open();
                sqlComm.Parameters.Add("@ID_Catalog", SqlDbType.Int).Value = key_ID_Catalog;
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
			SqlCommand sqlComm = new SqlCommand(st_tbShopsCatalogs_SelectAll_LikeKey, conn);
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
			SqlCommand sqlComm = new SqlCommand("st_tbShopsCatalogsSelectAll_Hidden", conn);
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
			SqlCommand sqlComm = new SqlCommand(st_tbShopsCatalogs_Insert, conn);
			sqlComm.CommandType = CommandType.StoredProcedure;
			try
			{
				//ID_Parent
				sqlComm.Parameters.Add("@ID_Parent", SqlDbType.Int).Value = ID_Parent;
				//CatalogName
				sqlComm.Parameters.Add("@CatalogName", SqlDbType.NVarChar).Value = CatalogName;
				//Image
				sqlComm.Parameters.Add("@Image", SqlDbType.NVarChar).Value = Image;
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
			SqlCommand sqlComm = new SqlCommand(st_tbShopsCatalogs_Update, conn);
			sqlComm.CommandType = CommandType.StoredProcedure;
			try
			{
				conn.Open();
				//ID_Catalog
				sqlComm.Parameters.Add("@ID_Catalog_find", SqlDbType.Int).Value = ID_Catalog_find;
				//ID_Parent
				sqlComm.Parameters.Add("@ID_Parent", SqlDbType.Int).Value = ID_Parent;
				//CatalogName
				if (CatalogName != null)
					sqlComm.Parameters.Add("@CatalogName", SqlDbType.NVarChar).Value = CatalogName;
				else
					sqlComm.Parameters.Add("@CatalogName", SqlDbType.NVarChar).Value = DBNull.Value;
				//Image
				if (Image != null)
					sqlComm.Parameters.Add("@Image", SqlDbType.NVarChar).Value = Image;
				else
					sqlComm.Parameters.Add("@Image", SqlDbType.NVarChar).Value = DBNull.Value;
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
		public int doUpdate_KEY(string Key_ID_Catalog_Old, string Key_ID_Catalog_New)
		{
			SqlConnection conn = new AccessDB().get_Conn();
			string sql = "Update tbShopsCatalogs Set ID_Catalog=@ID_Catalog_New Where ID_Catalog=@ID_Catalog_old";
			SqlCommand sqlComm = new SqlCommand(sql, conn);
			sqlComm.CommandType = CommandType.Text;
			try
			{
				sqlComm.Parameters.Add("@ID_Catalog_New", SqlDbType.Int).Value = Key_ID_Catalog_New;
				sqlComm.Parameters.Add("@ID_Catalog_old", SqlDbType.Int).Value = Key_ID_Catalog_Old;
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
			SqlCommand sqlComm = new SqlCommand(st_tbShopsCatalogs_Delete, conn);
			sqlComm.CommandType = CommandType.StoredProcedure;
			try
			{
				sqlComm.Parameters.Add("@ID_Catalog", SqlDbType.Int).Value = ID_Catalog_find;
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
		public static Cls_ShopsCatalogs converDataRow_To_Object(DataRow dr)
		{
			Cls_ShopsCatalogs _Object = new Cls_ShopsCatalogs();
			//ID_Catalog
			if(dr.Table.Columns.Contains(fn_ID_Catalog))
			if(dr[fn_ID_Catalog]!= DBNull.Value)
			_Object.ID_Catalog =  (int)dr[fn_ID_Catalog];

			//ID_Parent
			if(dr.Table.Columns.Contains(fn_ID_Parent))
			if(dr[fn_ID_Parent]!= DBNull.Value)
			_Object.ID_Parent =  (int)dr[fn_ID_Parent];

			//CatalogName
			if(dr.Table.Columns.Contains(fn_CatalogName))
			if(dr[fn_CatalogName]!= DBNull.Value)
			_Object.CatalogName =  (string)dr[fn_CatalogName];

			//Image
			if(dr.Table.Columns.Contains(fn_Image))
			if(dr[fn_Image]!= DBNull.Value)
			_Object.Image =  (string)dr[fn_Image];

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
		public static Cls_ShopsCatalogs getOject_Key(int key_ID_Catalog)
		{
			DataTable dt = getDataTable_My(key_ID_Catalog);
			if (dt.Rows.Count > 0)
				return converDataRow_To_Object(dt.Rows[0]);
			else
				return null;
        }

        /// <summary>
        /// Get Oject Key.
        /// </summary>
        /// <param name="ID">ID</param>
        /// <returns></returns>
        public static Cls_ShopsCatalogs getOject_Key_Not_Date(int key_ID_Catalog)
        {
            DataTable dt = getDataTable_My_NotDate(key_ID_Catalog);
            if (dt.Rows.Count > 0)
                return converDataRow_To_Object(dt.Rows[0]);
            else
                return null;
        }

        /// <summary>
        /// Get Array object class có parameter.
        /// </summary>
        /// <returns></returns>
        public static Cls_ShopsCatalogs[] getArrayObject(DataTable dt)
		{
			if (dt.Rows.Count == 0) return null;
			Cls_ShopsCatalogs[] arr = new Cls_ShopsCatalogs[dt.Rows.Count];
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
		public static Cls_ShopsCatalogs[] getArrayObject()
		{
			return getArrayObject(getDataTable_My());
		}
	}
}
