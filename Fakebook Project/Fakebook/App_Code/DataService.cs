using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for DataService
/// </summary>
public class DataService
{
    static private string path;//מסלול

    static public string Path
    {
        set { path = value; }
        get { return path; }
    }//פעולה המאחזרת / מעדכנת את המסלול

    static public string ConnectionString
    {
        get
        {
            return @"Data Source=.\SQLEXPRESS;AttachDbFilename=" + DataService.path + @";Integrated Security=True;User Instance=True";
        }
    }//Connection Stringפעולה המאחזרת את ה

    static public object ExecuteScalar(string strSql)
    {
        object obj = null;
        SqlConnection connection = new SqlConnection(DataService.ConnectionString);
        SqlCommand command = new SqlCommand(strSql,connection);
        try
        {
            connection.Open();
            obj = command.ExecuteScalar();
        }
        catch(Exception ex)
        {
            return null;
        }
        finally
        {
            connection.Close();
        }

        return obj;
    }//פעולת בחירה שמחזירה ערך בודד

    static public int ExecuteNonQuery(string strSql)
    {
        int rowsAffected;
        SqlConnection connection = new SqlConnection(DataService.ConnectionString);
        SqlCommand command = new SqlCommand(strSql, connection);
        try
        {
            connection.Open();
            rowsAffected = command.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            return -1;
        }
        finally
        {
            connection.Close();
        }

        return rowsAffected;
    }//פעולת עדכון/הוספה/מחיקה

        static public object ExecuteReader(string strSql)
        {
            string output="";
            SqlConnection connection = new SqlConnection(DataService.ConnectionString);
            SqlDataReader dr = null;
            SqlCommand command = new SqlCommand(strSql, connection);
            try
            {
                connection.Open();
                dr = command.ExecuteReader();
                while (dr.Read())
                {
                    output += dr["FirstName"].ToString();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                connection.Close();
            }

            if (output == "")
                return null;
            return output;
        }//פעולה אחזור ליותר מנתון אחד

        public static DataSet GetDataSet(string sql, string tblName)
        {
            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection(DataService.ConnectionString);
            SqlCommand cmd = new SqlCommand(sql, connection);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);

            try
            {
                ad.Fill(ds, tblName);
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {

            }
            if (ds.Tables[0].Rows.Count == 0)
                return null;
            return ds;
        }

	public DataService()
	{
		//
		// TODO: Add constructor logic here
		//
	}
}