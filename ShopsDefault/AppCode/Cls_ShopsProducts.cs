//----------------------------------------------------------------
//Tên Class: Cls_ShopsProducts
//Người thực hiện: Heo95konichiwa
//----------------------------------------------------------------
using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;

namespace Librari {
	public partial class Cls_ShopsProducts
	{
		protected string sSQL;
		#region Tham số cho Procedure
		//Tham số cho Procudure
		protected const string st_tbShopsProducts_Insert = "st_tbShopsProducts_Insert";
		protected const string st_tbShopsProducts_Update = "st_tbShopsProducts_Update";
		protected const string st_tbShopsProducts_SelectAll_Active_LikeKey = "st_tbShopsProducts_SelectAll_Active_LikeKey";
		protected const string st_tbShopsProducts_SelectAll_LikeKey = "st_tbShopsProducts_SelectAll_LikeKey";
		protected const string st_tbShopsProducts_Delete = "st_tbShopsProducts_Delete";
		protected const string st_tbShopsProducts_SelectByID = "st_tbShopsProducts_SelectByID";
        protected const string st_tbShopsProducts_SelectByID_NotDate = "st_tbShopsProducts_SelectByID_NotDate";
        protected const string st_tbShopsProducts_ShopsCatalog_SelectByID = "st_tbShopsProducts_ShopsCatalog_SelectByID";
        protected const string st_tbShopsProducts_SelectAll = "st_tbShopsProducts_SelectAll";
		protected const string st_tbShopsProducts_Count = "st_tbShopsProducts_Count";
		protected const string st_tbShopsProducts_Count_Key = "st_tbShopsProducts_Count_Key";
		protected const string TABLE_NAME = "tbShopsProducts";
		#endregion Tham số cho Procedure

		#region Các tên filed của table.
		//Các tên filed của table.
		public const string fn_ID_Product = "ID_Product";
		public const int len_ID_Product = 4;

		public const string fn_ID_Catalog = "ID_Catalog";
		public const int len_ID_Catalog = 4;

		public const string fn_ID_Manufacture = "ID_Manufacture";
		public const int len_ID_Manufacture = 4;

		public const string fn_ID_CurrencyUnit = "ID_CurrencyUnit";
		public const int len_ID_CurrencyUnit = 4;

		public const string fn_ProductName = "ProductName";
		public const int len_ProductName = 400;

		public const string fn_ProductCode = "ProductCode";
		public const int len_ProductCode = 20;

		public const string fn_Image = "Image";
		public const int len_Image = 200;

		public const string fn_PriceIn = "PriceIn";
		public const int len_PriceIn = 8;

		public const string fn_PriceOut = "PriceOut";
		public const int len_PriceOut = 8;

		public const string fn_PriceDiscount = "PriceDiscount";
		public const int len_PriceDiscount = 8;

		public const string fn_PriceShow = "PriceShow";
		public const int len_PriceShow = 1;

		public const string fn_Weight = "Weight";
		public const int len_Weight = 8;

		public const string fn_Color = "Color";
		public const int len_Color = 60;

		public const string fn_Amount = "Amount";
		public const int len_Amount = 4;

		public const string fn_MfgDate = "MfgDate";
		public const int len_MfgDate = 8;

		public const string fn_ExpDate = "ExpDate";
		public const int len_ExpDate = 8;

		public const string fn_SummaryContent = "SummaryContent";
		public const int len_SummaryContent = 1000;

		public const string fn_VAT = "VAT";
		public const int len_VAT = 1;

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
		private int _iD_Product_find;
		private int _iD_Product;
		private int _iD_Catalog;
		private int _iD_Manufacture;
		private int _iD_CurrencyUnit;
		private string _productName;
		private string _productCode;
		private string _image;
		private Double _priceIn;
		private Double _priceOut;
		private Double _priceDiscount;
		private bool _priceShow;
		private Double _weight;
		private string _color;
		private int _amount;
		private DateTime _mfgDate;
		private DateTime _expDate;
		private string _summaryContent;
		private bool _vAT;
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
		//Thuộc tínhID_Product_find
		public int ID_Product_find
		{
			get{return this._iD_Product_find;}
			set{this._iD_Product_find = value;}
		}

		//Thuộc tínhID_Product
		public int ID_Product
		{
			get{return this._iD_Product;}
			set{this._iD_Product = value;}
		}

		//Thuộc tínhID_Catalog
		public int ID_Catalog
		{
			get{return this._iD_Catalog;}
			set{this._iD_Catalog = value;}
		}

		//Thuộc tínhID_Manufacture
		public int ID_Manufacture
		{
			get{return this._iD_Manufacture;}
			set{this._iD_Manufacture = value;}
		}

		//Thuộc tínhID_CurrencyUnit
		public int ID_CurrencyUnit
		{
			get{return this._iD_CurrencyUnit;}
			set{this._iD_CurrencyUnit = value;}
		}

		//Thuộc tínhProductName
		public string ProductName
		{
			get{return this._productName;}
			set{this._productName = value;}
		}

		//Thuộc tínhProductCode
		public string ProductCode
		{
			get{return this._productCode;}
			set{this._productCode = value;}
		}

		//Thuộc tínhImage
		public string Image
		{
			get{return this._image;}
			set{this._image = value;}
		}

		//Thuộc tínhPriceIn
		public Double PriceIn
		{
			get{return this._priceIn;}
			set{this._priceIn = value;}
		}

		//Thuộc tínhPriceOut
		public Double PriceOut
		{
			get{return this._priceOut;}
			set{this._priceOut = value;}
		}

		//Thuộc tínhPriceDiscount
		public Double PriceDiscount
		{
			get{return this._priceDiscount;}
			set{this._priceDiscount = value;}
		}

		//Thuộc tínhPriceShow
		public bool PriceShow
		{
			get{return this._priceShow;}
			set{this._priceShow = value;}
		}

		//Thuộc tính Weight
		public Double Weight
		{
			get{return this._weight;}
			set{this._weight = value;}
		}

		//Thuộc tínhColor
		public string Color
		{
			get{return this._color;}
			set{this._color = value;}
		}

		//Thuộc tínhAmount
		public int Amount
		{
			get{return this._amount;}
			set{this._amount = value;}
		}

		//Thuộc tínhMfgDate
		public DateTime MfgDate
		{
			get{return this._mfgDate;}
			set{this._mfgDate = value;}
		}

		//Thuộc tínhExpDate
		public DateTime ExpDate
		{
			get{return this._expDate;}
			set{this._expDate = value;}
		}

		//Thuộc tínhSummaryContent
		public string SummaryContent
		{
			get{return this._summaryContent;}
			set{this._summaryContent = value;}
		}

		//Thuộc tínhVAT
		public bool VAT
		{
			get{return this._vAT;}
			set{this._vAT = value;}
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
		public Cls_ShopsProducts()
		{
		}

		/// <summary>
		/// Hàm khởi tạo có tham số.
		/// </summary>
		public Cls_ShopsProducts(int id_product, int id_catalog, int id_manufacture, int id_currencyunit, string productname, string productcode, string image, Double pricein, Double priceout, Double pricediscount, bool priceshow, Double weight, string color, int amount, DateTime mfgdate, DateTime expdate, string summarycontent, bool vat, string description, string titleweb, string linkseo, string h1seo, string keywordseo, DateTime addtime, DateTime edittime, bool hidden)
		{
			this._iD_Product = id_product;
			this._iD_Catalog = id_catalog;
			this._iD_Manufacture = id_manufacture;
			this._iD_CurrencyUnit = id_currencyunit;
			this._productName = productname;
			this._productCode = productcode;
			this._image = image;
			this._priceIn = pricein;
			this._priceOut = priceout;
			this._priceDiscount = pricediscount;
			this._priceShow = priceshow;
			this._weight = weight;
			this._color = color;
			this._amount = amount;
			this._mfgDate = mfgdate;
			this._expDate = expdate;
			this._summaryContent = summarycontent;
			this._vAT = vat;
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
			SqlCommand sqlComm = new SqlCommand("st_tbShopsProducts_Count", conn);
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
			SqlCommand sqlComm = new SqlCommand("st_tbShopsProducts_Count_Key", conn);
			sqlComm.CommandType = CommandType.StoredProcedure;
			try
			{
				sqlComm.Parameters.Add("@ID_Product", SqlDbType.Int).Value = ID_Product;
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
		public static bool Exits_Key(int key_ID_Product)
		{
			SqlConnection conn = new AccessDB().get_Conn();
			SqlCommand sqlComm = new SqlCommand("st_tbShopsProducts_Count_Key", conn);
			sqlComm.CommandType = CommandType.StoredProcedure;
			try
			{
				sqlComm.Parameters.Add("@ID_Product", SqlDbType.Int).Value = key_ID_Product;
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
			string sSQL = "Select MAX(ID_Product) From tbShopsProducts";
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
			string sSQL = "Select Top 0 * From tbShopsProducts";
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
			string sSQL = "Select Top " + top + " * From  tbShopsProducts";
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
				string sSQL = "SELECT * FROM tbShopsProducts" + strWhere;
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
				string sSQL = "SELECT * FROM tbShopsProducts" + strWhere + FieldSort;
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
				string sSQL = "SELECT * FROM tbShopsProducts" + strWhere;
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
			SqlCommand sqlComm = new SqlCommand(st_tbShopsProducts_SelectAll, conn);
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
        public static DataTable getDataTable_My_NotDate(int key_ID_Product)
        {
            SqlConnection conn = new AccessDB().get_Conn();
            SqlCommand sqlComm = new SqlCommand(st_tbShopsProducts_SelectByID_NotDate, conn);
            sqlComm.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            try
            {
                conn.Open();
                sqlComm.Parameters.Add("@ID_Product", SqlDbType.Int).Value = key_ID_Product;
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
        public static DataTable getDataTable_Join_ShopsCatalogs(int key_ID_Product)
        {
            SqlConnection conn = new AccessDB().get_Conn();
            SqlCommand sqlComm = new SqlCommand(st_tbShopsProducts_ShopsCatalog_SelectByID, conn);
            sqlComm.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            try
            {
                conn.Open();
                sqlComm.Parameters.Add("@ID_Product", SqlDbType.Int).Value = key_ID_Product;
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
        public static DataTable getDataTable_My(int key_ID_Product)
		{
			SqlConnection conn = new AccessDB().get_Conn();
			SqlCommand sqlComm = new SqlCommand(st_tbShopsProducts_SelectByID, conn);
			sqlComm.CommandType = CommandType.StoredProcedure;
			DataTable dt = new DataTable();
			try
			{
				conn.Open();
				sqlComm.Parameters.Add("@ID_Product", SqlDbType.Int).Value = key_ID_Product;
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
			SqlCommand sqlComm = new SqlCommand(st_tbShopsProducts_SelectAll_LikeKey, conn);
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
			SqlCommand sqlComm = new SqlCommand("st_tbShopsProductsSelectAll_Hidden", conn);
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
                string sSQL = "SELECT * FROM tbShopsProducts, tbShopsCatalogs" + strWhere;
                return getDataTable_SQL_pro(sSQL);
            }
            catch (SqlException ex)
            {
                return null;
            }
        }

        /// <summary>
        /// Get DataTable với tbShopsCatalogstable class.
        /// </summary>
        /// <param name="ID">ID</param>
        /// <returns></returns>
        public static DataTable getDataTableJoinShopsCatalogs()
		{
			SqlConnection conn = new AccessDB().get_Conn();
			SqlCommand sqlComm = new SqlCommand("st_tbShopsProducts_SelectJointbShopsCatalogs", conn);
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
		/// Get DataTable với tbShopsManufacturetable class.
		/// </summary>
		/// <param name="ID">ID</param>
		/// <returns></returns>
		public static DataTable getDataTableJoinShopsManufacture()
		{
			SqlConnection conn = new AccessDB().get_Conn();
			SqlCommand sqlComm = new SqlCommand("st_tbShopsProducts_SelectJointbShopsManufacture", conn);
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
		/// Get DataTable với tbShopsCurrencyUnittable class.
		/// </summary>
		/// <param name="ID">ID</param>
		/// <returns></returns>
		public static DataTable getDataTableJoinShopsCurrencyUnit()
		{
			SqlConnection conn = new AccessDB().get_Conn();
			SqlCommand sqlComm = new SqlCommand("st_tbShopsProducts_SelectJointbShopsCurrencyUnit", conn);
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
			SqlCommand sqlComm = new SqlCommand("st_tbShopsProducts_SelectByID_Catalog", conn);
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
		/// Get DataTable với ID_Manufacture table class.
		/// </summary>
		/// <param name="ID">ID</param>
		/// <param name="Hidden">Hidden</param>
		/// <returns></returns>
		public static DataTable getDataTable_With_ID_Manufacture(int ID_Manufacture, bool Hidden)
		{
			SqlConnection conn = new AccessDB().get_Conn();
			SqlCommand sqlComm = new SqlCommand("st_tbShopsProducts_SelectByID_Manufacture", conn);
			sqlComm.CommandType = CommandType.StoredProcedure;
			sqlComm.Parameters.Add("@ID_Manufacture", SqlDbType.Int).Value = ID_Manufacture;
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
		/// Get DataTable với ID_CurrencyUnit table class.
		/// </summary>
		/// <param name="ID">ID</param>
		/// <param name="Hidden">Hidden</param>
		/// <returns></returns>
		public static DataTable getDataTable_With_ID_CurrencyUnit(int ID_CurrencyUnit, bool Hidden)
		{
			SqlConnection conn = new AccessDB().get_Conn();
			SqlCommand sqlComm = new SqlCommand("st_tbShopsProducts_SelectByID_CurrencyUnit", conn);
			sqlComm.CommandType = CommandType.StoredProcedure;
			sqlComm.Parameters.Add("@ID_CurrencyUnit", SqlDbType.Int).Value = ID_CurrencyUnit;
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
			SqlCommand sqlComm = new SqlCommand("st_tbShopsProducts_SelectByID_Catalog_All", conn);
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
		/// Get All DataTable với ID_Manufacture table class.
		/// </summary>
		/// <param name="ID">ID</param>
		/// <returns></returns>
		public static DataTable getDataTable_With_ID_Manufacture(int ID_Manufacture)
		{
			SqlConnection conn = new AccessDB().get_Conn();
			SqlCommand sqlComm = new SqlCommand("st_tbShopsProducts_SelectByID_Manufacture_All", conn);
			sqlComm.CommandType = CommandType.StoredProcedure;
			sqlComm.Parameters.Add("@ID_Manufacture", SqlDbType.Int).Value = ID_Manufacture;
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
		/// Get All DataTable với ID_CurrencyUnit table class.
		/// </summary>
		/// <param name="ID">ID</param>
		/// <returns></returns>
		public static DataTable getDataTable_With_ID_CurrencyUnit(int ID_CurrencyUnit)
		{
			SqlConnection conn = new AccessDB().get_Conn();
			SqlCommand sqlComm = new SqlCommand("st_tbShopsProducts_SelectByID_CurrencyUnit_All", conn);
			sqlComm.CommandType = CommandType.StoredProcedure;
			sqlComm.Parameters.Add("@ID_CurrencyUnit", SqlDbType.Int).Value = ID_CurrencyUnit;
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
			SqlCommand sqlComm = new SqlCommand("st_tbShopsProducts_CountByID_Catalog_All", conn);
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
		/// Count record DataTable với ID ID_Manufacturetable class.
		/// </summary>
		/// <param name="ID">ID</param>
		/// <param name="Hidden">Hidden</param>
		/// <returns></returns>
		public static int CountByID_Manufacture(int ID_Manufacture, bool Hidden)
		{
			SqlConnection conn = new AccessDB().get_Conn();
			SqlCommand sqlComm = new SqlCommand("st_tbShopsProducts_CountByID_Manufacture_All", conn);
			sqlComm.CommandType = CommandType.StoredProcedure;
			sqlComm.Parameters.Add("@ID_Manufacture", SqlDbType.Int).Value = ID_Manufacture;
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
		/// Count record DataTable với ID ID_CurrencyUnittable class.
		/// </summary>
		/// <param name="ID">ID</param>
		/// <param name="Hidden">Hidden</param>
		/// <returns></returns>
		public static int CountByID_CurrencyUnit(int ID_CurrencyUnit, bool Hidden)
		{
			SqlConnection conn = new AccessDB().get_Conn();
			SqlCommand sqlComm = new SqlCommand("st_tbShopsProducts_CountByID_CurrencyUnit_All", conn);
			sqlComm.CommandType = CommandType.StoredProcedure;
			sqlComm.Parameters.Add("@ID_CurrencyUnit", SqlDbType.Int).Value = ID_CurrencyUnit;
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
        /// Count DataTable với ID_ShopsCatalogs_ID_ShopsManufacture_ID_ShopsCurrencyUnit table class.
        /// </summary>
        /// <param name="ID">ID</param>
        /// <returns></returns>
        public static int Count_With_ID_Catalog(int ID_Catalog)
        {
            SqlConnection conn = new AccessDB().get_Conn();
            SqlCommand sqlComm = new SqlCommand("st_tbShopsProducts_CountByID_ShopsCatalogs_ID_ShopsManufacture_ID_ShopsCurrencyUnit", conn);
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
		public static int Count_With_ID_Manufacture(int ID_Manufacture)
		{
			SqlConnection conn = new AccessDB().get_Conn();
			SqlCommand sqlComm = new SqlCommand("st_tbShopsProducts_CountByID_ShopsCatalogs_ID_ShopsManufacture_ID_ShopsCurrencyUnit", conn);
			sqlComm.CommandType = CommandType.StoredProcedure;
			sqlComm.Parameters.Add("@ID_Manufacture", SqlDbType.Int).Value = ID_Manufacture;
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
        public static int Count_With_ID_CurrencyUnit(int ID_CurrencyUnit)
		{
			SqlConnection conn = new AccessDB().get_Conn();
			SqlCommand sqlComm = new SqlCommand("st_tbShopsProducts_CountByID_ShopsCatalogs_ID_ShopsManufacture_ID_ShopsCurrencyUnit", conn);
			sqlComm.CommandType = CommandType.StoredProcedure;
			sqlComm.Parameters.Add("@ID_CurrencyUnit", SqlDbType.Int).Value = ID_CurrencyUnit;
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
            SqlCommand sqlComm = new SqlCommand(st_tbShopsProducts_Insert, conn);
            sqlComm.CommandType = CommandType.StoredProcedure;
            try
            {
                //ID_Catalog
                sqlComm.Parameters.Add("@ID_Catalog", SqlDbType.Int).Value = ID_Catalog;
                //ProductName
                sqlComm.Parameters.Add("@ProductName", SqlDbType.NVarChar).Value = ProductName;
                //ProductCode
                sqlComm.Parameters.Add("@ProductCode", SqlDbType.VarChar).Value = ProductCode;
                //Image
                sqlComm.Parameters.Add("@Image", SqlDbType.NVarChar).Value = Image;
                //PriceOut
                sqlComm.Parameters.Add("@PriceOut", SqlDbType.Float).Value = PriceOut;
                //Weight
                sqlComm.Parameters.Add("@Weight", SqlDbType.Float).Value = Weight;
                //Color
                sqlComm.Parameters.Add("@Color", SqlDbType.NVarChar).Value = Color;
                //Amount
                sqlComm.Parameters.Add("@Amount", SqlDbType.Int).Value = Amount;
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
			SqlCommand sqlComm = new SqlCommand(st_tbShopsProducts_Update, conn);
			sqlComm.CommandType = CommandType.StoredProcedure;
			try
			{
				conn.Open();
				//ID_Product
				sqlComm.Parameters.Add("@ID_Product_find", SqlDbType.Int).Value = ID_Product_find;
				//ID_Catalog
				sqlComm.Parameters.Add("@ID_Catalog", SqlDbType.Int).Value = ID_Catalog;
				//ProductName
				if (ProductName != null)
					sqlComm.Parameters.Add("@ProductName", SqlDbType.NVarChar).Value = ProductName;
				else
					sqlComm.Parameters.Add("@ProductName", SqlDbType.NVarChar).Value = DBNull.Value;
				//ProductCode
				if (ProductCode != null)
					sqlComm.Parameters.Add("@ProductCode", SqlDbType.VarChar).Value = ProductCode;
				else
					sqlComm.Parameters.Add("@ProductCode", SqlDbType.VarChar).Value = DBNull.Value;
				//Image
				if (Image != null)
					sqlComm.Parameters.Add("@Image", SqlDbType.NVarChar).Value = Image;
				else
					sqlComm.Parameters.Add("@Image", SqlDbType.NVarChar).Value = DBNull.Value;
				//PriceOut
				sqlComm.Parameters.Add("@PriceOut", SqlDbType.Float).Value = PriceOut;
				//Weight
				sqlComm.Parameters.Add("@Weight", SqlDbType.Float).Value = Weight;
				//Color
				if (Color != null)
					sqlComm.Parameters.Add("@Color", SqlDbType.NVarChar).Value = Color;
				else
					sqlComm.Parameters.Add("@Color", SqlDbType.NVarChar).Value = DBNull.Value;
				//Amount
				sqlComm.Parameters.Add("@Amount", SqlDbType.Int).Value = Amount;
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
		public int doUpdate_KEY(string Key_ID_Product_Old, string Key_ID_Product_New)
		{
			SqlConnection conn = new AccessDB().get_Conn();
			string sql = "Update tbShopsProducts Set ID_Product=@ID_Product_New Where ID_Product=@ID_Product_old";
			SqlCommand sqlComm = new SqlCommand(sql, conn);
			sqlComm.CommandType = CommandType.Text;
			try
			{
				sqlComm.Parameters.Add("@ID_Product_New", SqlDbType.Int).Value = Key_ID_Product_New;
				sqlComm.Parameters.Add("@ID_Product_old", SqlDbType.Int).Value = Key_ID_Product_Old;
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
			SqlCommand sqlComm = new SqlCommand(st_tbShopsProducts_Delete, conn);
			sqlComm.CommandType = CommandType.StoredProcedure;
			try
			{
				sqlComm.Parameters.Add("@ID_Product", SqlDbType.Int).Value = ID_Product_find;
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
		public static Cls_ShopsProducts converDataRow_To_Object(DataRow dr)
		{
			Cls_ShopsProducts _Object = new Cls_ShopsProducts();
			//ID_Product
			if(dr.Table.Columns.Contains(fn_ID_Product))
			if(dr[fn_ID_Product]!= DBNull.Value)
			_Object.ID_Product =  (int)dr[fn_ID_Product];

			//ID_Catalog
			if(dr.Table.Columns.Contains(fn_ID_Catalog))
			if(dr[fn_ID_Catalog]!= DBNull.Value)
			_Object.ID_Catalog =  (int)dr[fn_ID_Catalog];

			//ID_Manufacture
			if(dr.Table.Columns.Contains(fn_ID_Manufacture))
			if(dr[fn_ID_Manufacture]!= DBNull.Value)
			_Object.ID_Manufacture =  (int)dr[fn_ID_Manufacture];

			//ID_CurrencyUnit
			if(dr.Table.Columns.Contains(fn_ID_CurrencyUnit))
			if(dr[fn_ID_CurrencyUnit]!= DBNull.Value)
			_Object.ID_CurrencyUnit =  (int)dr[fn_ID_CurrencyUnit];

			//ProductName
			if(dr.Table.Columns.Contains(fn_ProductName))
			if(dr[fn_ProductName]!= DBNull.Value)
			_Object.ProductName =  (string)dr[fn_ProductName];

			//ProductCode
			if(dr.Table.Columns.Contains(fn_ProductCode))
			if(dr[fn_ProductCode]!= DBNull.Value)
			_Object.ProductCode =  (string)dr[fn_ProductCode];

			//Image
			if(dr.Table.Columns.Contains(fn_Image))
			if(dr[fn_Image]!= DBNull.Value)
			_Object.Image =  (string)dr[fn_Image];

			//PriceIn
			if(dr.Table.Columns.Contains(fn_PriceIn))
			if(dr[fn_PriceIn]!= DBNull.Value)
			_Object.PriceIn =  (Double)dr[fn_PriceIn];

			//PriceOut
			if(dr.Table.Columns.Contains(fn_PriceOut))
			if(dr[fn_PriceOut]!= DBNull.Value)
			_Object.PriceOut =  (Double)dr[fn_PriceOut];

			//PriceDiscount
			if(dr.Table.Columns.Contains(fn_PriceDiscount))
			if(dr[fn_PriceDiscount]!= DBNull.Value)
			_Object.PriceDiscount =  (Double)dr[fn_PriceDiscount];

			//PriceShow
			if(dr.Table.Columns.Contains(fn_PriceShow))
			if(dr[fn_PriceShow]!= DBNull.Value)
			_Object.PriceShow =  (bool)dr[fn_PriceShow];

			//Weight
			if(dr.Table.Columns.Contains(fn_Weight))
			if(dr[fn_Weight]!= DBNull.Value)
			_Object.Weight =  (Double)dr[fn_Weight];

			//Color
			if(dr.Table.Columns.Contains(fn_Color))
			if(dr[fn_Color]!= DBNull.Value)
			_Object.Color =  (string)dr[fn_Color];

			//Amount
			if(dr.Table.Columns.Contains(fn_Amount))
			if(dr[fn_Amount]!= DBNull.Value)
			_Object.Amount =  (int)dr[fn_Amount];

			//MfgDate
			if(dr.Table.Columns.Contains(fn_MfgDate))
			if(dr[fn_MfgDate]!= DBNull.Value)
			_Object.MfgDate =  (DateTime)dr[fn_MfgDate];

			//ExpDate
			if(dr.Table.Columns.Contains(fn_ExpDate))
			if(dr[fn_ExpDate]!= DBNull.Value)
			_Object.ExpDate =  (DateTime)dr[fn_ExpDate];

			//SummaryContent
			if(dr.Table.Columns.Contains(fn_SummaryContent))
			if(dr[fn_SummaryContent]!= DBNull.Value)
			_Object.SummaryContent =  (string)dr[fn_SummaryContent];

			//VAT
			if(dr.Table.Columns.Contains(fn_VAT))
			if(dr[fn_VAT]!= DBNull.Value)
			_Object.VAT =  (bool)dr[fn_VAT];

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
		public static Cls_ShopsProducts getOject_Key(int key_ID_Product)
		{
			DataTable dt = getDataTable_My(key_ID_Product);
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
        public static Cls_ShopsProducts getOject_Key_Not_Date(int key_ID_Product)
        {
            DataTable dt = getDataTable_My_NotDate(key_ID_Product);
            if (dt.Rows.Count > 0)
                return converDataRow_To_Object(dt.Rows[0]);
            else
                return null;
        }

        /// <summary>
        /// Get Array object class có parameter.
        /// </summary>
        /// <returns></returns>
        public static Cls_ShopsProducts[] getArrayObject(DataTable dt)
		{
			if (dt.Rows.Count == 0) return null;
			Cls_ShopsProducts[] arr = new Cls_ShopsProducts[dt.Rows.Count];
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
		public static Cls_ShopsProducts[] getArrayObject()
		{
			return getArrayObject(getDataTable_My());
		}
	}
}
