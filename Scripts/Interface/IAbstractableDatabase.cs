// =======================================================================================
// IAbstractableDatabase
// by Weaver (Fhiz)
// MIT licensed
//
//
// =======================================================================================

using System;
using System.Collections.Generic;
using UnityEngine;
using wovencode;

namespace wovencode
{
	// ===================================================================================
	// IAbstractableDatabase
	// ===================================================================================
	public interface IAbstractableDatabase
	{
		
		void Awake();
		
		void OpenConnection();
		void CloseConnection();
		
		void BeginTransaction();
		void Commit();
		
		
		void CreateTable<T>();
		void CreateIndex(string tableName, string[] columnNames, bool unique = false);
		T FindWithQuery<T>(string query, params object[] args) where T : new();
		
		void Insert(object obj);
		
		List<T> Query<T>(string query, params object[] args) where T : new();
		void Execute(string query, params object[] args);
		
		void InsertOrReplace(object obj);
		
	}
		
}

// =======================================================================================