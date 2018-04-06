using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sodium;
using System.Data;            // DataSet
using System.Data.SqlClient;  // SqlConnection, SqlCommand, SqlDataReader
using System.Configuration;   // to get the connection from Web.config
using System.ComponentModel;  // DataObject, DataObjectMethod

/// <summary>
/// https://bitbeans.gitbooks.io/libsodium-net/content/generating_random_data/index.html
/// https://stackoverflow.com/questions/14835338/how-to-store-byte-in-text-field-in-database-and-retrieve-it/14835423
/// Summary description for Security
/// </summary>
public class Security
{
    private static String salt;
    private static String hashedPassword;
    private String password;
    private const long OUTPUT_LENGTH = 512;

    public Security()
    {
        //Console.WriteLine(SodiumCore.SodiumVersionString());
        //
        // TODO: Add constructor logic here. Maybe further constructors to make it convenient? How will this be used?
        //
    }

    public int CreateUser(string password, string username)
    {
        if (password.Length < 4)
        {
            return -1;     // should this be throwing errors, or are we validating user input somewhere else?
        }
        byte[] salt = GenerateSalt();
        string saltString = Convert.ToBase64String(salt);
        this.password = password;
        var hash = PasswordHash.ScryptHashBinary(password, saltString, PasswordHash.Strength.Medium, OUTPUT_LENGTH);
        string hashString = Convert.ToBase64String(hash);
        InsertUser(username, hashString, saltString, "no");
        return 0;
    }

    public int ChangePassword(string user, string newPassword, string oldPassword)
    {
        if (Verify(user, oldPassword))
        {
            return -1;
        }
        if (newPassword.Length < 4)
        {
            return -2;     // should this be throwing errors, or are we validating user input somewhere else?
        }
        byte[] salt = GenerateSalt();
        string saltString = Convert.ToBase64String(salt);
        var hash = PasswordHash.ScryptHashBinary(password, saltString, PasswordHash.Strength.Medium, OUTPUT_LENGTH);
        string hashString = Convert.ToBase64String(hash);

        UpdatePassword(user, newPassword, saltString);

        return 0;
    }

    public Boolean Verify(string givenUserName, string givenPassword)
    {
        string storedPassword = GetPasswordFromDB(givenUserName);
        string saltStringFromDB = GetSaltFromDB(givenUserName);
        byte[] hashedGiven = PasswordHash.ScryptHashBinary(givenPassword, saltStringFromDB, PasswordHash.Strength.Medium, OUTPUT_LENGTH);
        string hashedPassword = Convert.ToBase64String(hashedGiven);
        Boolean passwordIsRight = false;
        
        if (storedPassword.Equals(hashedPassword))
        {
            passwordIsRight = true;
        }

        return passwordIsRight;
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
            cmd.CommandText = "UPDATE Users SET HashedPassword = " + newPassword + ", Salt = " + newSalt + " WHERE Username = " + user;
        }
        finally
        {
            if (conn != null)
            {
                conn.Close();
            }
        }
        
    }

    private string GetSaltFromDB(string user)
    {
        string salt = "";
        SqlConnection conn = new SqlConnection(GetConnectionString());
        SqlCommand cmd;
        SqlDataReader dr = null;

        try
        {

            conn = new SqlConnection(GetConnectionString());
            conn.Open();

            cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT Salt FROM Users WHERE Username = " + user;
            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            while (dr.Read())
            {
                salt = (string)dr["Username"];
            }
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
        string salt = "";
        SqlConnection conn = new SqlConnection(GetConnectionString());
        SqlCommand cmd;
        SqlDataReader dr = null;

        try
        {

            conn = new SqlConnection(GetConnectionString());
            conn.Open();

            cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT HashedPassword FROM Users WHERE Username = " + user;
            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            while (dr.Read())
            {
                salt = (String)dr["Username"];
            }
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
            cmd.CommandText = "IF NOT EXISTS (SELECT * FROM Users WHERE Username = " + user + ")" +
                "BEGIN" +
                " INSERT INTO Users VALUES (" + user + ", " + password + ", " + salt + ", " + admin + ")" +
                " END" +
                " ELSE" +
                " BEGIN" +
                //--do what needs to be done if exists... return an error? Username taken? another method entirely to check first?
                " END";
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

    private byte[] GenerateSalt()
    {
        return SodiumCore.GetRandomBytes(32);
    }

    // Generic Hashing https://bitbeans.gitbooks.io/libsodium-net/content/hashing/generic_hashing.html
    /*private byte[] HashingFunctionNew(String givenPassword, String givenName)
    {
        string password = givenPassword;
        byte[] salt = GenerateSalt();
        string saltString = Convert.ToBase64String(salt);
        string userName = givenName;
        return GenericHash.HashSaltPersonal(password, null, saltString, userName, 128);
    }


    private byte[] HashingFunctionExisting(String givenPassword, String givenName, String givenSalt)
    {
        String password = givenPassword;
        String salt = givenSalt;
        String userName = givenName;
        return GenericHash.HashSaltPersonal(password, null, salt, userName, 128);
    }*/

}