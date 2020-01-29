﻿// =======================================================================================
// Wovencore
// by Weaver (Fhiz)
// MIT licensed
// =======================================================================================

using Wovencode;
using Wovencode.Database;
using UnityEngine;
using System;
using System.IO;
using System.Collections.Generic;
using SQLite;

namespace Wovencode.Database
{
	
	// ===================================================================================
	// Database
	// ===================================================================================
	[DisallowMultipleComponent]
	public partial class DatabaseManager : BaseDatabaseManager, IAbstractableDatabase
	{
		
		[Header("Settings")]
		public DatabaseType databaseType = DatabaseType.SQLite;
		[Tooltip("Player data save interval in seconds (0 to disable).")]
		public float saveInterval = 60f;
		[Tooltip("Deleted user prune interval in seconds (0 to disable).")]
		public float deleteInterval = 240f;
		
		public static DatabaseManager singleton;
		
		protected DatabaseType _databaseType = DatabaseType.SQLite;
		
#if wMYSQL
		[Header("Database Layer - mySQL")]
		public DatabaseLayerMySQL databaseLayer;
#else
		[Header("Database Layer - SQLite")]
		public DatabaseLayerSQLite databaseLayer;
#endif
		
		protected const string _defineSQLite 	= "wSQLITE";
		protected const string _defineMySQL 	= "wMYSQL";
		
		// -------------------------------------------------------------------------------
		// OnValidate
		// updates the define to set the database layer depending of chosen database type
		// -------------------------------------------------------------------------------
		void OnValidate()
		{
#if UNITY_EDITOR
			if (databaseType == DatabaseType.mySQL && databaseType != _databaseType)
			{
				EditorTools.RemoveScriptingDefine(_defineSQLite);
				EditorTools.AddScriptingDefine(_defineMySQL);
				_databaseType = databaseType;
			}
			else if (databaseType == DatabaseType.SQLite && databaseType != _databaseType)
			{
				EditorTools.RemoveScriptingDefine(_defineMySQL);
				EditorTools.AddScriptingDefine(_defineSQLite);
				_databaseType = databaseType;
			}
			
			this.InvokeInstanceDevExtMethods(nameof(OnValidate));
#endif
		}
		
		// -------------------------------------------------------------------------------
		// DeleteUsers
		// hard deletes all users that have been soft deleted before
		// -------------------------------------------------------------------------------
		void DeleteUsers()
		{
		
			/*
				When using "Wovencode.PlayerComponent", the database will automatically
				prune all users that have been soft deleted after a certain amount of time.
				This process will also remove all characters of that user from the database
				as well.
				
				If you don't use "Wovencode.PlayerComponent", you will have to provide
				your own pruning functionality using the hook below, or nothing will
				happen.
					
			*/
			
			this.InvokeInstanceDevExtMethods(nameof(DeleteUsers));
			
		}
		
		// -------------------------------------------------------------------------------
		// SavePlayers
		// same function as below but without parameters (for Invoke)
		// -------------------------------------------------------------------------------
		void SavePlayers()
		{
			SavePlayers(true);
		}
		
		// -------------------------------------------------------------------------------
		// SavePlayers
		// -------------------------------------------------------------------------------
		void SavePlayers(bool online = true)
    	{

			/*
				When using "Wovencode.Network", the database will automatically save
				all online players. If you use any other solution, you will have to
				replace the code below with your own.
			
				In case of a single-player game, you will have to provide your own
				code in order to save the current player to the database. You can
				use the hook below to move the save process to another file, or
				add your own code right here if preferred.
				
				Don't care about transaction or anything else at this point.
			
			*/
			
			this.InvokeInstanceDevExtMethods(nameof(SavePlayers), online);
			
    	}
    	
    	// =========================== DEFAULT EVENTS ====================================
		
		// -------------------------------------------------------------------------------
		// OnApplicationQuit
		// -------------------------------------------------------------------------------
		void OnApplicationQuit()
		{
			Destruct();
		}
    	
		// -------------------------------------------------------------------------------

	}

}

// =======================================================================================