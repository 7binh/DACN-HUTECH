//----------------------------------------------------------------
//Tên Class: Cls_ShopsImages
//Người thực hiện: Heo95konichiwa
//----------------------------------------------------------------
using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;

namespace Librari {
	public partial class Cls_ShopsImages
	{
		protected string sSQL;
		#region Tham số cho Procedure
		//Tham số cho Procudure
		protected const string st_tbShopsImages_Insert = "st_tbShopsImages_Insert";
		protected const string st_tbShopsImages_Update = "st_tbShopsImages_Update";
		protected const string st_tbShopsImages_SelectAll_Active_LikeKey = "st_tbShopsImages_SelectAll_Active_LikeKey";
		protected const string st_tbShopsImages_SelectAll_LikeKey = "st_tbShopsImages_SelectAll_LikeKey";
		protected const string st_tbShopsImages_Delete = "st_tbShopsImages_Delete";
		protected const string st_tbShopsImages_SelectByID = "st_tbShopsImages_SelectByID";
		protected const string st_tbShopsImages_SelectAll = "st_tbShopsImages_SelectAll";
		protected const string st_tbShopsImages_Count = "st_tbShopsImages_Count";
		protected const string st_tbShopsImages_Count_Key = "st_tbShopsImages_Count_Key";
		protected const string TABLE_NAME = "tbShopsImages";
		#endregion Tham số cho Procedure

		#region Các tên filed của table.
		//Các tên filed của table.
		public const string fn_ID_ImageProduct = "ID_ImageProduct";
		public const int len_ID_ImageProduct = 4;

		public const string fn_ID_Product = "ID_Product";
		public const int len_ID_Product = 4;

		public const string fn_ImageProductName = "ImageProductName";
		public const int len_ImageProductName = 200;

		public const string fn_UrlImage = "UrlImage";
		public const int len_UrlImage = 200;

		public const string fn_Description = "Description";
		public const int len_Description = 16;

		public const string fn_AddTime = "AddTime";
		public const int len_AddTime = 8;

		public const string fn_EditTime = "EditTime";
		public const int len_EditTime = 8;

		public const string fn_Hidden = "Hidden";
		public const int len_Hidden = 1;

		//Các tên filed của table.
		private int _iD_ImageProduct_find;
		private int _iD_ImageProduct;
		private int _iD_Product;
		private string _imageProductName;
		private string _urlImage;
		private string _description;
		private DateTime _addTime;
		private DateTime _editTime;
		private bool _hidden;
		#endregion Các tên filed của table.

		#region Các phương thức cho table.
		//Thuộc tínhID_ImageProduct_find
		public int ID_ImageProduct_find
		{
			get{return this._iD_ImageProduct_find;}
			set{this._iD_ImageProduct_find = value;}
		}

		//Thuộc tínhID_ImageProduct
		public int ID_ImageProduct
		{
			get{return this._iD_ImageProduct;}
			set{this._iD_ImageProduct = value;}
		}

		//Thuộc tínhID_Product
		public int ID_Product
		{
			get{return this._iD_Product;}
			set{this._iD_Product = value;}
		}

		//Thuộc tínhImageProductName
		public string ImageProductName
		{
			get{return this._imageProductName;}
			set{this._imageProductName = value;}
		}

		//Thuộc tínhUrlImage
		public string UrlImage
		{
			get{return this._urlImage;}
			set{this._urlImage = value;}
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
		public Cls_ShopsImages()
		{
		}

		/// <summary>
		/// Hàm khởi tạo có tham số.
		/// </summary>
		public Cls_ShopsImages(int id_imageproduct, int id_product, string imageproductname, string urlimage, string description, DateTime addtime, DateTime edittime, bool hidden)
		{
			this._iD_ImageProduct = id_imageproduct;
			this._iD_Product = id_product;
			this._imageProductName = imageproductname;
			this._urlImage = urlimage;
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
			SqlCommand sqlComm = new SqlCommand("st_tbShopsImages_Count", conn);
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
			SqlCommand sqlComm = new SqlCommand("st_tbShopsImages_Count_Key", conn);
			sqlComm.CommandType = CommandType.StoredProcedure;
			try
			{
				sqlComm.Parameters.Add("@ID_ImageProduct", SqlDbType.Int).Value = ID_ImageProduct;
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
		public static bool Exits_Key(int key_ID_ImageProduct)
		{
			SqlConnection conn = new AccessDB().get_Conn();
			SqlCommand sqlComm = new SqlCommand("st_tbShopsImages_Count_Key", conn);
			sqlComm.CommandType = CommandType.StoredProcedure;
			try
			{
				sqlComm.Parameters.Add("@ID_ImageProduct", SqlDbType.Int).Value = key_ID_ImageProduct;
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
			string sSQL = "Select MAX(ID_ImageProduct) From tbShopsImages";
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
			string sSQL = "Select Top 0 * From tbShopsImages";
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
			string sSQL = "Select Top " + top + " * From  tbShopsImages";
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
				string sSQL = "SELECT * FROM tbShopsImages" + strWhere;
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
				string sSQL = "SELECT * FROM tbShopsImages" + strWhere + FieldSort;
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
				string sSQL = "SELECT * FROM tbShopsImages" + strWhere;
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
			SqlCommand sqlComm = new SqlCommand(st_tbShopsImages_SelectAll, conn);
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
		public static DataTable getDataTable_My(int key_ID_ImageProduct)
		{
			SqlConnection conn = new AccessDB().get_Conn();
			SqlCommand sqlComm = new SqlCommand(st_tbShopsImages_SelectByID, conn);
			sqlComm.CommandType = CommandType.StoredProcedure;
			DataTable dt = new DataTable();
			try
			{
				conn.Open();
				sqlComm.Parameters.Add("@ID_ImageProduct", SqlDbType.Int).Value = key_ID_ImageProduct;
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
			SqlCommand sqlComm = new SqlCommand(st_tbShopsImages_SelectAll_LikeKey, conn);
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
			SqlCommand sqlComm = new SqlCommand("st_tbShopsImagesSelectAll_Hidden", conn);
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
		/// Get DataTable với tbShopsProductstable class.
		/// </summary>
		/// <param name="ID">ID</param>
		/// <returns></returns>
		public static DataTable getDataTableJoinShopsProducts()
		{
			SqlConnection conn = new AccessDB().get_Conn();
			SqlCommand sqlComm = new SqlCommand("st_tbShopsImages_SelectJointbShopsProducts", conn);
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
		/// Get DataTable với ID_Product table class.
		/// </summary>
		/// <param name="ID">ID</param>
		/// <param name="Hidden">Hidden</param>
		/// <returns></returns>
		public static DataTable getDataTable_With_ID_Product(int ID_Product, bool Hidden)
		{
			SqlConnection conn = new AccessDB().get_Conn();
			SqlCommand sqlComm = new SqlCommand("st_tbShopsImages_SelectByID_Product", conn);
			sqlComm.CommandType = CommandType.StoredProcedure;
			sqlComm.Parameters.Add("@ID_Product", SqlDbType.Int).Value = ID_Product;
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
		/// Get All DataTable với ID_Product table class.
		/// </summary>
		/// <param name="ID">ID</param>
		/// <returns></returns>
		public static DataTable getDataTable_With_ID_Product(int ID_Product)
		{
			SqlConnection conn = new AccessDB().get_Conn();
			SqlCommand sqlComm = new SqlCommand("st_tbShopsImages_SelectByID_Product_All", conn);
			sqlComm.CommandType = CommandType.StoredProcedure;
			sqlComm.Parameters.Add("@ID_Product", SqlDbType.Int).Value = ID_Product;
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
		/// Count record DataTable với ID ID_Producttable class.
		/// </summary>
		/// <param name="ID">ID</param>
		/// <param name="Hidden">Hidden</param>
		/// <returns></returns>
		public static int CountByID_Product(int ID_Product, bool Hidden)
		{
			SqlConnection conn = new AccessDB().get_Conn();
			SqlCommand sqlComm = new SqlCommand("st_tbShopsImages_CountByID_Product_All", conn);
			sqlComm.CommandType = CommandType.StoredProcedure;
			sqlComm.Parameters.Add("@ID_Product", SqlDbType.Int).Value = ID_Product;
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
		/// Count DataTable với ID_ShopsProducts table class.
		/// </summary>
		/// <param name="ID">ID</param>
		/// <returns></returns>
		public static int Count_With_ID_Product(int ID_Product)
		{
			SqlConnection conn = new AccessDB().get_Conn();
			SqlCommand sqlComm = new SqlCommand("st_tbShopsImages_CountByID_ShopsProducts", conn);
			sqlComm.CommandType = CommandType.StoredProcedure;
			sqlComm.Parameters.Add("@ID_Product", SqlDbType.Int).Value = ID_Product;
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
			SqlCommand sqlComm = new SqlCommand(st_tbShopsImages_Insert, conn);
			sqlComm.CommandType = CommandType.StoredProcedure;
			try
			{
				//ID_Product
				sqlComm.Parameters.Add("@ID_Product", SqlDbType.Int).Value = ID_Product;
				//ImageProductName
				sqlComm.Parameters.Add("@ImageProductName", SqlDbType.NVarChar).Value = ImageProductName;
				//UrlImage
				sqlComm.Parameters.Add("@UrlImage", SqlDbType.NVarChar).Value = UrlImage;
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
			SqlCommand sqlComm = new SqlCommand(st_tbShopsImages_Update, conn);
			sqlComm.CommandType = CommandType.StoredProcedure;
			try
			{
				conn.Open();
				//ID_ImageProduct
				sqlComm.Parameters.Add("@ID_ImageProduct_find", SqlDbType.Int).Value = ID_ImageProduct_find;
				//ID_Product
				sqlComm.Parameters.Add("@ID_Product", SqlDbType.Int).Value = ID_Product;
				//ImageProductName
				if (ImageProductName != null)
					sqlComm.Parameters.Add("@ImageProductName", SqlDbType.NVarChar).Value = ImageProductName;
				else
					sqlComm.Parameters.Add("@ImageProductName", SqlDbType.NVarChar).Value = DBNull.Value;
				//UrlImage
				if (UrlImage != null)
					sqlComm.Parameters.Add("@UrlImage", SqlDbType.NVarChar).Value = UrlImage;
				else
					sqlComm.Parameters.Add("@UrlImage", SqlDbType.NVarChar).Value = DBNull.Value;
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
		/// Thực hiện doUpdate Key dữ liệu.
		/// </summary>
		/// <returns></returns>
		public int doUpdate_KEY(string Key_ID_ImageProduct_Old, string Key_ID_ImageProduct_New)
		{
			SqlConnection conn = new AccessDB().get_Conn();
			string sql = "Update tbShopsImages Set ID_ImageProduct=@ID_ImageProduct_New Where ID_ImageProduct=@ID_ImageProduct_old";
			SqlCommand sqlComm = new SqlCommand(sql, conn);
			sqlComm.CommandType = CommandType.Text;
			try
			{
				sqlComm.Parameters.Add("@ID_ImageProduct_New", SqlDbType.Int).Value = Key_ID_ImageProduct_New;
				sqlComm.Parameters.Add("@ID_ImageProduct_old", SqlDbType.Int).Value = Key_ID_ImageProduct_Old;
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
			SqlCommand sqlComm = new SqlCommand(st_tbShopsImages_Delete, conn);
			sqlComm.CommandType = CommandType.StoredProcedure;
			try
			{
				sqlComm.Parameters.Add("@ID_ImageProduct", SqlDbType.Int).Value = ID_ImageProduct_find;
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
		public static Cls_ShopsImages converDataRow_To_Object(DataRow dr)
		{
			Cls_ShopsImages _Object = new Cls_ShopsImages();
			//ID_ImageProduct
			if(dr.Table.Columns.Contains(fn_ID_ImageProduct))
			if(dr[fn_ID_ImageProduct]!= DBNull.Value)
			_Object.ID_ImageProduct =  (int)dr[fn_ID_ImageProduct];

			//ID_Product
			if(dr.Table.Columns.Contains(fn_ID_Product))
			if(dr[fn_ID_Product]!= DBNull.Value)
			_Object.ID_Product =  (int)dr[fn_ID_Product];

			//ImageProductName
			if(dr.Table.Columns.Contains(fn_ImageProductName))
			if(dr[fn_ImageProductName]!= DBNull.Value)
			_Object.ImageProductName =  (string)dr[fn_ImageProductName];

			//UrlImage
			if(dr.Table.Columns.Contains(fn_UrlImage))
			if(dr[fn_UrlImage]!= DBNull.Value)
			_Object.UrlImage =  (string)dr[fn_UrlImage];

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
		public static Cls_ShopsImages getOject_Key(int key_ID_ImageProduct)
		{
			DataTable dt = getDataTable_My(key_ID_ImageProduct);
			if (dt.Rows.Count > 0)
				return converDataRow_To_Object(dt.Rows[0]);
			else
				return null;
		}

		/// <summary>
		/// Get Array object class có parameter.
		/// </summary>
		/// <returns></returns>
		public static Cls_ShopsImages[] getArrayObject(DataTable dt)
		{
			if (dt.Rows.Count == 0) return null;
			Cls_ShopsImages[] arr = new Cls_ShopsImages[dt.Rows.Count];
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
		public static Cls_ShopsImages[] getArrayObject()
		{
			return getArrayObject(getDataTable_My());
		}
	}
}
