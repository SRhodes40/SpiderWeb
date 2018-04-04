using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using Sodium;

/// <summary>
/// https://bitbeans.gitbooks.io/libsodium-net/content/generating_random_data/index.html
/// Summary description for Security
/// </summary>
public class Security
{
/*   private static String salt;
    private static String hashedPassword;
    private String password;
    private var salt;

    public Security()
    {
        Console.WriteLine(SodiumCore.SodiumVersionString());
        //
        // TODO: Add constructor logic here
        //
    }

    public void createUser( String password )
    {
        // calls randomSalt() to name a new random salt
        // adds the salt to the end of the password
        // passes the password and salt to the hashingFunction to create a hashed password
        // returns the salt and hashed password to be used to update the relevant tables
    }

    public Boolean verify( String givenPassword, String givenUserName )
    {
        byte[] salt;
        String password;
        byte[] hashedPassword;
        byte[] hashedGiven;
        Boolean passwordIsRight = false;
        // takes the password sent from slient-side for a given user
        // Try/Catch block to see if the user exists in the table, else return an error
            // password = (SELECT password FROM users WHERE (USER == user))
            // salt = (SELECT salt FROM users WHERE (USER == user))
            // hashedPassword = (SELECT hashedPassword FROM users WHERE (USER == user))
            // 
        // finds the related salt in the database
        // appends salt to the password
        // runs the hashingFunction with the combination and compares 
        //     the result to the stored hashed password
        return passwordIsRight;
    }

    // Generic Hashing https://bitbeans.gitbooks.io/libsodium-net/content/hashing/generic_hashing.html
    private byte[] hashingFunctionNew(String givenPassword, String givenName)
    {
        String password = givenPassword;
        byte[] salt = randomSalt();
        String userName = givenName;
        return GenericHash.HashSaltPersonal(password, null, salt, userName, 128);
    }

    private byte[] hashingFunctionExisting(String givenPassword, String givenName, byte[] givenSalt)
    {
        String password = givenPassword;
        byte[] salt = givenSalt;
        String userName = givenName;
        return GenericHash.HashSaltPersonal(password, null, salt, userName, 128);
    }

    private byte[] randomSalt()
    {
        return SodiumCore.GetRandomBytes(64);
    }

    // Walkthrough of database connection configuration http://raider.mountunion.edu/csc/CSC410/Spring2018/Labs/Lab6/Lab6.html
    private static string getConnectionString()
    {
        return ConfigurationManager.ConnectionStrings["SpiderWebConnectionString"].ConnectionString;
    } // end of getConnectionString
    */
}