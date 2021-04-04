using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;

public class OvertakeDB : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //create database
        string connection = "URI-file:" + Application.persistentDataPath + "/" + "My_Database";

        //Open connection
        IDbConnection dbcon = new SqliteConnection(connection);
        try{
        	dbcon.Open();
        	Console.WriteLine("Connection successful!");	
        } catch (SQLiteException sqle)
        	{
        		Console.WriteLine("Connection to SQLite database failed.");
        	}
        

        //create Players table
        IDbCommand dbcmd;
        dbcmd = dbcon.CreateCommand();
        string q_createTable = "CREATE TABLE IF NOT EXISTS players (name TEXT, id INTEGER PRIMARY KEY, high_score INTEGER)";
    	dbcmd.CommandText = q_createTable;
    	Console.WriteLine("'Players' table created.");
    	
    	//create Session table
    	q_createTable = "CREATE TABLE IF NOT EXISTS session (host_id INTEGER FOREIGN KEY, stage TEXT, winner TEXT)";
    	dbcmd.CommandText = q_createTable;
    	Console.WriteLine("'Session' table created.");

    	dbcmd.ExecuteReader();

    	//insert dummy values into table
    	IDbCommand cmnd = dbcon.CreateCommand();
    	cmnd.CommandText = "INSERT INTO players (name, id, high_score) VALUES (Jane Doe, 123456, 999999)";
    	cmnd.CommandText = "INSERT INTO session (host_id, stage, winner) VALUES (123456, Stage 1, Jane Doe)";

    	//Reads and prints values in table for debugging purposes
    	IDbCommand cmnd_read = dbcon.CreateCommand();
    	IDataReader reader;
    	string query = "SELECT * FROM players, session";
    	cmnd_read.CommandText = query;
    	reader = cmnd_read.ExecuteReader();

    	while (reader.Read())
    	{
    		Console.WriteLine("name: " + reader[0].ToString());
    		Console.WriteLine("id: " + reader[1].ToString());
    		Console.WriteLine("high_score: " + reader[2].ToString());
    		Console.WriteLine("host_id: " + reader[3].ToString());
    		Console.WriteLine("stage: " + reader[4].ToString());
    		Console.WriteLine("winner: " + reader[5].ToString());
    	}

    	//close the connection
    	dbcon.Close();
    }

    // Update is called once per frame
    void Update()
    {
        //TODO: write a trigger that updates personal high scores for all players in session
    }
}
