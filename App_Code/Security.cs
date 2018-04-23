using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using Sodium;
using System.Data;            // DataSet
using System.Data.SqlClient;  // SqlConnection, SqlCommand, SqlDataReader
using System.Configuration;   // to get the connection from Web.config
using System.ComponentModel;  // DataObject, DataObjectMethod
using System.Security.Cryptography;

/// <summary>
/// https://bitbeans.gitbooks.io/libsodium-net/content/generating_random_data/index.html
/// https://stackoverflow.com/questions/14835338/how-to-store-byte-in-text-field-in-database-and-retrieve-it/14835423
/// Summary description for Security
/// </summary>
public class Security
{
    public Security()
    {
    }

    public int CreateUser(string username, string password)
    {
        username = username.ToUpper();
        if (password.Length < 4 || UserExists(username))
        {
            return -1;     // this should never be called, we check it elsewhere
        }
        
        // https://stackoverflow.com/questions/4181198/how-to-hash-a-password/10402129#10402129
        byte[] salt;
        new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);
        string saltString = Convert.ToBase64String(salt);
        var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000);
        byte[] hash = pbkdf2.GetBytes(20);
        string savedPasswordHash = Convert.ToBase64String(hash);
        
        InsertUser(username, savedPasswordHash, saltString, "no");
        return 0;
    }

    public int ChangePassword(string user, string newPassword, string oldPassword)
    {
        user = user.ToUpper();
        if (!Verify(user, oldPassword))
        {
            return -1;
        }
        if (newPassword.Length < 4)
        {
            return -2;     // should this be throwing errors, or are we validating user input somewhere else?
        }

        // https://stackoverflow.com/questions/4181198/how-to-hash-a-password/10402129#10402129
        byte[] salt;
        new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);
        string saltString = Convert.ToBase64String(salt);

        var pbkdf2 = new Rfc2898DeriveBytes(newPassword, salt, 10000);
        byte[] hash = pbkdf2.GetBytes(20);

        string savedPasswordHash = Convert.ToBase64String(hash);

        UpdatePassword(user, savedPasswordHash, saltString);

        return 0;
    }

    public Boolean Verify(string givenUserName, string givenPassword)
    {
        givenUserName = givenUserName.ToUpper();
        if (!IsUserInTable(givenUserName))
        {
            return false;
        }
        string storedPassword = GetPasswordFromDB(givenUserName);
        string saltStringFromDB = GetSaltFromDB(givenUserName);
        
        byte[] salt = Convert.FromBase64String(saltStringFromDB);
        var pbkdf2 = new Rfc2898DeriveBytes(givenPassword, salt, 10000);
        byte[] newHash = pbkdf2.GetBytes(20);
        
        string savedPasswordHash = Convert.ToBase64String(newHash);

        Boolean passwordIsRight = false;
        
        if (storedPassword.Equals(savedPasswordHash))
        {
            passwordIsRight = true;
        }

        return passwordIsRight;
    }

    public Boolean UserExists(String user)
    {
        return IsUserInTable(user);
    }

    public Boolean IsAdmin(string givenUserName)
    {
        givenUserName = givenUserName.ToUpper();

        return GetAdmin(givenUserName).Equals("yes", StringComparison.InvariantCultureIgnoreCase);

    }

    private void UpdatePassword(string user, string newPassword, string newSalt)
    {
        SqlConnection conn = new SqlConnection(GetConnectionString());
        SqlCommand cmd;

        try
        {
            conn = new SqlConnection(GetConnectionString());
            conn.Open();

            cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "UPDATE Users SET HashedPassword = @newPassword, Salt = @newSalt WHERE Username = @user";
            cmd.Parameters.AddWithValue("@newPassword", newPassword);
            cmd.Parameters.AddWithValue("@newSalt", newSalt);
            cmd.Parameters.AddWithValue("@user", user);
            cmd.ExecuteNonQuery();
        }
        finally
        {
            if (conn != null)
            {
                conn.Close();
            }
        }
        
    }

    private string GetAdmin(string user)
    {
        string admin = "";
        SqlConnection conn = new SqlConnection(GetConnectionString());
        SqlCommand cmd;
        SqlDataReader dr = null;
        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter();

        try
        {

            conn = new SqlConnection(GetConnectionString());
            conn.Open();

            cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT Admin FROM Users WHERE Username = @user";
            cmd.Parameters.AddWithValue("@user", user);
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);
            admin = Convert.ToString(ds.Tables[0].Rows[0][0]);
        }
        finally
        {
            if (dr != null)
            {
                dr.Close();
            }
            if (conn != null)
            {
                conn.Close();
            }
        }

        return admin;
    }

    private string GetSaltFromDB(string user)
    {
        string salt = "";
        SqlConnection conn = new SqlConnection(GetConnectionString());
        SqlCommand cmd;
        SqlDataReader dr = null;
        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter();

        try
        {

            conn = new SqlConnection(GetConnectionString());
            conn.Open();

            cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT Salt FROM Users WHERE Username = @user";
            cmd.Parameters.AddWithValue("@user", user);
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);
            salt = Convert.ToString(ds.Tables[0].Rows[0][0]);
        }
        finally
        {
            if (dr != null)
            {
                dr.Close();
            }
            if (conn != null)
            {
                conn.Close();
            }
        }

        return salt;
    }

    private string GetPasswordFromDB(string user)
    {
        string password = "";
        SqlConnection conn = new SqlConnection(GetConnectionString());
        SqlCommand cmd;
        SqlDataReader dr = null;
        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter();

        try
        {

            conn = new SqlConnection(GetConnectionString());
            conn.Open();

            cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT HashedPassword FROM Users WHERE Username = @user";
            cmd.Parameters.AddWithValue("@user", user);
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);
            password = Convert.ToString(ds.Tables[0].Rows[0][0]);
        }
        finally
        {
            if (dr != null)
            {
                dr.Close();
            }
            if (conn != null)
            {
                conn.Close();
            }
        }

        return password;
    }

    private Boolean IsUserInTable(string givenName)
    {
        int numberInTable = 0;
        SqlConnection conn = new SqlConnection(GetConnectionString());
        SqlCommand cmd;

        try
        {
            conn = new SqlConnection(GetConnectionString());
            conn.Open();

            cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT COUNT(*) from Users where Username = @givenName";
            cmd.Parameters.AddWithValue("@givenName", givenName);
            numberInTable = (int) cmd.ExecuteScalar();
        }
        finally
        {
            if (conn != null)
            {
                conn.Close();
            }
        }

        return (numberInTable > 0);
    }

    private string InsertUser(string user, string password, string salt, string admin)
    {
        SqlConnection conn = new SqlConnection(GetConnectionString());
        SqlCommand cmd;

        try
        {

            conn = new SqlConnection(GetConnectionString());
            conn.Open();

            cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "INSERT INTO Users VALUES (@user, @password, @salt, @admin)";
            cmd.Parameters.AddWithValue("@user", user);
            cmd.Parameters.AddWithValue("@password", password);
            cmd.Parameters.AddWithValue("@salt", salt);
            cmd.Parameters.AddWithValue("@admin", admin);
            cmd.ExecuteNonQuery();
        }
        finally
        {
            if (conn != null)
            {
                conn.Close();
            }
        }

        return salt;
    }

    // Walkthrough of database connection configuration http://raider.mountunion.edu/csc/CSC410/Spring2018/Labs/Lab6/Lab6.html
    private static string GetConnectionString()
    {
        return ConfigurationManager.ConnectionStrings["SpiderWebConnectionString"].ConnectionString;
    } // end of GetConnectionString

}