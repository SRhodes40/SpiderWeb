using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
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
        Console.WriteLine(SodiumCore.SodiumVersionString());
        //
        // TODO: Add constructor logic here. Maybe further constructors to make it convenient? How will this be used?
        //
    }

    public void CreateUser(String password)
    {
        byte[] salt = GenerateSalt();
        String saltString = Convert.ToBase64String(salt);
        this.password = password;
        var hash = PasswordHash.ScryptHashBinary(password, saltString, PasswordHash.Strength.Medium, OUTPUT_LENGTH);
        String hashString = Convert.ToBase64String(hash);
        // returns the salt and hashed password to be used to update the relevant tables
    }

    public Boolean Verify(String givenPassword, String givenUserName)
    {
        byte[] salt;
        String password;
        string hashedPassword;
        byte[] hashedGiven;
        Boolean passwordIsRight = false;


        hashedPassword = GetPasswordFromDB(givenUserName);
        String saltStringFromDB = GetSaltFromDB(givenUserName);

        // 
        // finds the related salt in the database
        salt = Convert.FromBase64String(saltStringFromDB);
        hashedGiven = PasswordHash.ScryptHashBinary(givenPassword, saltStringFromDB, PasswordHash.Strength.Medium, OUTPUT_LENGTH);

        // runs the hashingFunction with the combination and compares 
        //     the result to the stored hashed password
        return passwordIsRight;


    }

    private String GetSaltFromDB(String user)
    {
        String salt = "";
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
            cmd.CommandText = "SELECT Salt FROM User WHERE Username = " + user;
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

    private String GetPasswordFromDB(String user)
    {
        String salt = "";
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
            cmd.CommandText = "SELECT HashedPassword FROM User WHERE Username = " + user;
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

    // Walkthrough of database connection configuration http://raider.mountunion.edu/csc/CSC410/Spring2018/Labs/Lab6/Lab6.html
    private static string GetConnectionString()
    {
        return ConfigurationManager.ConnectionStrings["SpiderWebConnectionString"].ConnectionString;
    } // end of GetConnectionString

    // Generic Hashing https://bitbeans.gitbooks.io/libsodium-net/content/hashing/generic_hashing.html
    private byte[] HashingFunctionNew(String givenPassword, String givenName)
    {
        String password = givenPassword;
        byte[] salt = GenerateSalt();
        String saltString = Convert.ToBase64String(salt);
        String userName = givenName;
        return GenericHash.HashSaltPersonal(password, null, saltString, userName, 128);
    }


    private byte[] HashingFunctionExisting(String givenPassword, String givenName, byte[] givenSalt)
    {
        String password = givenPassword;
        byte[] salt = givenSalt;
        String userName = givenName;
        return GenericHash.HashSaltPersonal(password, null, salt, userName, 128);
    }

    private byte[] GenerateSalt()
    {
        return SodiumCore.GetRandomBytes(32);
    }

}