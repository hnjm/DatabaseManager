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
using Mirror;

namespace Wovencode.Database
{
	
	// ===================================================================================
	// DatabaseManager
	// ===================================================================================
	public partial class DatabaseManager
	{
		
		// ============================= PUBLIC METHODS ==================================
		
    	// -------------------------------------------------------------------------------
		// CreateDefaultData
		// called when a new player is registered, the hook is executed on all modules and
		// used to parse default data onto the player (like starting Equipment etc.).
		// -------------------------------------------------------------------------------
		public void CreateDefaultData(GameObject player)
		{
			this.InvokeInstanceDevExtMethods(nameof(CreateDefaultData), player);
		}
		
		// -------------------------------------------------------------------------------
		// LoadData
		// called when a player is loaded from the database, the hooks are executed on
		// all modules and used to load additional player data.
		// -------------------------------------------------------------------------------
		public GameObject LoadData(GameObject prefab, string _name)
		{
			GameObject player = Instantiate(prefab);
			player.name = _name;
			this.InvokeInstanceDevExtMethods("LoadDataWithPriority", player);
			this.InvokeInstanceDevExtMethods(nameof(LoadData), player);
			return player;
		}
		
		// -------------------------------------------------------------------------------
		// SaveDataUser
		// called when a user is saved to the database, the hook is executed on all
		// modules and used to save additional data.
		// -------------------------------------------------------------------------------
		public void SaveDataUser(string username, bool isOnline=true, bool useTransaction = true)
		{
			if (useTransaction)
				databaseLayer.BeginTransaction();
			
			this.InvokeInstanceDevExtMethods(nameof(SaveDataUser), username, isOnline);
			
			if (useTransaction)
				databaseLayer.Commit();
		}
		
		// -------------------------------------------------------------------------------
		// SaveDataPlayer
		// called when a player is saved to the database, the hook is executed on all
		// modules and used to save additional data.
		// -------------------------------------------------------------------------------
		public void SaveDataPlayer(GameObject player, bool isOnline=true, bool useTransaction = true)
		{
			if (useTransaction)
				databaseLayer.BeginTransaction();
			
			this.InvokeInstanceDevExtMethods(nameof(SaveDataPlayer), player, isOnline);
			
			if (useTransaction)
				databaseLayer.Commit();
		}
		
		// -------------------------------------------------------------------------------
		// LoginUser
		// @NetworkManager
		// -------------------------------------------------------------------------------
		public void LoginUser(string name)
		{
			this.InvokeInstanceDevExtMethods(nameof(LoginUser), name);
		}
		
		// -------------------------------------------------------------------------------
		// LogoutUser
		// @NetworkManager
		// -------------------------------------------------------------------------------
		public void LogoutUser(string name)
		{
			SaveDataUser(name, false);
			this.InvokeInstanceDevExtMethods(nameof(LogoutUser), name);
		}
		
		// -------------------------------------------------------------------------------
		// LoginPlayer
		// @NetworkManager
		// -------------------------------------------------------------------------------
		public void LoginPlayer(string name)
		{
			this.InvokeInstanceDevExtMethods(nameof(LoginPlayer), name);
		}
		
		// -------------------------------------------------------------------------------
		// LogoutPlayer
		// @NetworkManager
		// -------------------------------------------------------------------------------
		public void LogoutPlayer(GameObject player)
		{
			SaveDataPlayer(player, false);
			this.InvokeInstanceDevExtMethods(nameof(LogoutPlayer), player);
		}
		
		// -------------------------------------------------------------------------------

	}

}

// =======================================================================================