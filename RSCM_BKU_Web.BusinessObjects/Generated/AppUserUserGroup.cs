/*
===============================================================================
                    EntitySpaces 2009 by EntitySpaces, LLC
             Persistence Layer and Business Objects for Microsoft .NET
             EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
                          http://www.entityspaces.net
===============================================================================
EntitySpaces Version : 2009.2.1214.0
EntitySpaces Driver  : SQL
Date Generated       : 10/03/2011 10:05:35
===============================================================================
*/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.ComponentModel;
using System.Xml.Serialization;


using EntitySpaces.Core;
using EntitySpaces.Interfaces;
using EntitySpaces.DynamicQuery;



namespace RSCM_BKU_Web.BusinessObjects
{

	[Serializable]
	abstract public class esAppUserUserGroupCollection : esEntityCollection
	{
		public esAppUserUserGroupCollection()
		{

		}

		protected override string GetCollectionName()
		{
			return "AppUserUserGroupCollection";
		}

		#region Query Logic
		protected void InitQuery(esAppUserUserGroupQuery query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			query.es2.Connection = ((IEntityCollection)this).Connection;
		}

		protected bool OnQueryLoaded(DataTable table)
		{
			this.PopulateCollection(table);
			return (this.RowCount > 0) ? true : false;
		}
		
		protected override void HookupQuery(esDynamicQuery query)
		{
			this.InitQuery(query as esAppUserUserGroupQuery);
		}
		#endregion
		
		virtual public AppUserUserGroup DetachEntity(AppUserUserGroup entity)
		{
			return base.DetachEntity(entity) as AppUserUserGroup;
		}
		
		virtual public AppUserUserGroup AttachEntity(AppUserUserGroup entity)
		{
			return base.AttachEntity(entity) as AppUserUserGroup;
		}
		
		virtual public void Combine(AppUserUserGroupCollection collection)
		{
			base.Combine(collection);
		}
		
		new public AppUserUserGroup this[int index]
		{
			get
			{
				return base[index] as AppUserUserGroup;
			}
		}

		public override Type GetEntityType()
		{
			return typeof(AppUserUserGroup);
		}
	}



	[Serializable]
	abstract public class esAppUserUserGroup : esEntity
	{
		/// <summary>
		/// Used internally by the entity's DynamicQuery mechanism.
		/// </summary>
		virtual protected esAppUserUserGroupQuery GetDynamicQuery()
		{
			return null;
		}

		public esAppUserUserGroup()
		{

		}

		public esAppUserUserGroup(DataRow row)
			: base(row)
		{

		}
		
		#region LoadByPrimaryKey
		public virtual bool LoadByPrimaryKey(System.String userID, System.String userGroupID)
		{
			if(this.es.Connection.SqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(userID, userGroupID);
			else
				return LoadByPrimaryKeyStoredProcedure(userID, userGroupID);
		}

		public virtual bool LoadByPrimaryKey(esSqlAccessType sqlAccessType, System.String userID, System.String userGroupID)
		{
			if (sqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(userID, userGroupID);
			else
				return LoadByPrimaryKeyStoredProcedure(userID, userGroupID);
		}

		private bool LoadByPrimaryKeyDynamic(System.String userID, System.String userGroupID)
		{
			esAppUserUserGroupQuery query = this.GetDynamicQuery();
			query.Where(query.UserID == userID, query.UserGroupID == userGroupID);
			return query.Load();
		}

		private bool LoadByPrimaryKeyStoredProcedure(System.String userID, System.String userGroupID)
		{
			esParameters parms = new esParameters();
			parms.Add("UserID",userID);			parms.Add("UserGroupID",userGroupID);
			return this.Load(esQueryType.StoredProcedure, this.es.spLoadByPrimaryKey, parms);
		}
		#endregion
		
		
		
		#region Properties
		
		
		public override void SetProperties(IDictionary values)
		{
			foreach (string propertyName in values.Keys)
			{
				this.SetProperty(propertyName, values[propertyName]);
			}
		}

		public override void SetProperty(string name, object value)
		{
			if(this.Row == null) this.AddNew();
			
			esColumnMetadata col = this.Meta.Columns.FindByPropertyName(name);
			if (col != null)
			{
				if(value == null || value is System.String)
				{				
					// Use the strongly typed property
					switch (name)
					{							
						case "UserID": this.str.UserID = (string)value; break;							
						case "UserGroupID": this.str.UserGroupID = (string)value; break;							
						case "LastUpdateDateTime": this.str.LastUpdateDateTime = (string)value; break;							
						case "LastUpdateByUserID": this.str.LastUpdateByUserID = (string)value; break;
					}
				}
				else
				{
					switch (name)
					{	
						case "LastUpdateDateTime":
						
							if (value == null || value is System.DateTime)
								this.LastUpdateDateTime = (System.DateTime?)value;
							break;
					

						default:
							break;
					}
				}
			}
			else if(this.Row.Table.Columns.Contains(name))
			{
				this.Row[name] = value;
			}
			else
			{
				throw new Exception("SetProperty Error: '" + name + "' not found");
			}
		}
		
		
		/// <summary>
		/// Maps to AppUserUserGroup.UserID
		/// </summary>
		virtual public System.String UserID
		{
			get
			{
				return base.GetSystemString(AppUserUserGroupMetadata.ColumnNames.UserID);
			}
			
			set
			{
				base.SetSystemString(AppUserUserGroupMetadata.ColumnNames.UserID, value);
			}
		}
		
		/// <summary>
		/// Maps to AppUserUserGroup.UserGroupID
		/// </summary>
		virtual public System.String UserGroupID
		{
			get
			{
				return base.GetSystemString(AppUserUserGroupMetadata.ColumnNames.UserGroupID);
			}
			
			set
			{
				base.SetSystemString(AppUserUserGroupMetadata.ColumnNames.UserGroupID, value);
			}
		}
		
		/// <summary>
		/// Maps to AppUserUserGroup.LastUpdateDateTime
		/// </summary>
		virtual public System.DateTime? LastUpdateDateTime
		{
			get
			{
				return base.GetSystemDateTime(AppUserUserGroupMetadata.ColumnNames.LastUpdateDateTime);
			}
			
			set
			{
				base.SetSystemDateTime(AppUserUserGroupMetadata.ColumnNames.LastUpdateDateTime, value);
			}
		}
		
		/// <summary>
		/// Maps to AppUserUserGroup.LastUpdateByUserID
		/// </summary>
		virtual public System.String LastUpdateByUserID
		{
			get
			{
				return base.GetSystemString(AppUserUserGroupMetadata.ColumnNames.LastUpdateByUserID);
			}
			
			set
			{
				base.SetSystemString(AppUserUserGroupMetadata.ColumnNames.LastUpdateByUserID, value);
			}
		}
		
		#endregion	

		#region String Properties


		[BrowsableAttribute( false )]
		public esStrings str
		{
			get
			{
				if (esstrings == null)
				{
					esstrings = new esStrings(this);
				}
				return esstrings;
			}
		}


		[Serializable]
		sealed public class esStrings
		{
			public esStrings(esAppUserUserGroup entity)
			{
				this.entity = entity;
			}
			
	
			public System.String UserID
			{
				get
				{
					System.String data = entity.UserID;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.UserID = null;
					else entity.UserID = Convert.ToString(value);
				}
			}
				
			public System.String UserGroupID
			{
				get
				{
					System.String data = entity.UserGroupID;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.UserGroupID = null;
					else entity.UserGroupID = Convert.ToString(value);
				}
			}
				
			public System.String LastUpdateDateTime
			{
				get
				{
					System.DateTime? data = entity.LastUpdateDateTime;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.LastUpdateDateTime = null;
					else entity.LastUpdateDateTime = Convert.ToDateTime(value);
				}
			}
				
			public System.String LastUpdateByUserID
			{
				get
				{
					System.String data = entity.LastUpdateByUserID;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.LastUpdateByUserID = null;
					else entity.LastUpdateByUserID = Convert.ToString(value);
				}
			}
			

			private esAppUserUserGroup entity;
		}
		#endregion

		#region Query Logic
		protected void InitQuery(esAppUserUserGroupQuery query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			query.es2.Connection = ((IEntity)this).Connection;
		}

		[System.Diagnostics.DebuggerNonUserCode]
		protected bool OnQueryLoaded(DataTable table)
		{
			bool dataFound = this.PopulateEntity(table);

			if (this.RowCount > 1)
			{
				throw new Exception("esAppUserUserGroup can only hold one record of data");
			}

			return dataFound;
		}
		#endregion
		
		[NonSerialized]
		private esStrings esstrings;
	}


	
	public partial class AppUserUserGroup : esAppUserUserGroup
	{

		
		/// <summary>
		/// Used internally by the entity's hierarchical properties.
		/// </summary>
		protected override List<esPropertyDescriptor> GetHierarchicalProperties()
		{
			List<esPropertyDescriptor> props = new List<esPropertyDescriptor>();
			
		
			return props;
		}	
		
		/// <summary>
		/// Used internally for retrieving AutoIncrementing keys
		/// during hierarchical PreSave.
		/// </summary>
		protected override void ApplyPreSaveKeys()
		{
		}
		
		/// <summary>
		/// Used internally for retrieving AutoIncrementing keys
		/// during hierarchical PostSave.
		/// </summary>
		protected override void ApplyPostSaveKeys()
		{
		}
		
		/// <summary>
		/// Used internally for retrieving AutoIncrementing keys
		/// during hierarchical PostOneToOneSave.
		/// </summary>
		protected override void ApplyPostOneSaveKeys()
		{
		}
		
	}



	[Serializable]
	abstract public class esAppUserUserGroupQuery : esDynamicQuery
	{
		override protected IMetadata Meta
		{
			get
			{
				return AppUserUserGroupMetadata.Meta();
			}
		}	
		

		public esQueryItem UserID
		{
			get
			{
				return new esQueryItem(this, AppUserUserGroupMetadata.ColumnNames.UserID, esSystemType.String);
			}
		} 
		
		public esQueryItem UserGroupID
		{
			get
			{
				return new esQueryItem(this, AppUserUserGroupMetadata.ColumnNames.UserGroupID, esSystemType.String);
			}
		} 
		
		public esQueryItem LastUpdateDateTime
		{
			get
			{
				return new esQueryItem(this, AppUserUserGroupMetadata.ColumnNames.LastUpdateDateTime, esSystemType.DateTime);
			}
		} 
		
		public esQueryItem LastUpdateByUserID
		{
			get
			{
				return new esQueryItem(this, AppUserUserGroupMetadata.ColumnNames.LastUpdateByUserID, esSystemType.String);
			}
		} 
		
	}



    [System.Diagnostics.DebuggerDisplay("Count = {Count}")]
	[Serializable]
	[XmlType("AppUserUserGroupCollection")]
	public partial class AppUserUserGroupCollection : esAppUserUserGroupCollection, IEnumerable<AppUserUserGroup>
	{
		public AppUserUserGroupCollection()
		{

		}
		
		public static implicit operator List<AppUserUserGroup>(AppUserUserGroupCollection coll)
		{
			List<AppUserUserGroup> list = new List<AppUserUserGroup>();
			
			foreach (AppUserUserGroup emp in coll)
			{
				list.Add(emp);
			}
			
			return list;
		}
		
		#region Housekeeping methods
		override protected IMetadata Meta
		{
			get
			{
				return  AppUserUserGroupMetadata.Meta();
			}
		}
		
		
		
		override protected esDynamicQuery GetDynamicQuery()
		{
			if (this.query == null)
			{
				this.query = new AppUserUserGroupQuery();
				this.InitQuery(query);
			}
			return this.query;
		}
		
		override protected esEntity CreateEntityForCollection(DataRow row)
		{
			return new AppUserUserGroup(row);
		}

		override protected esEntity CreateEntity()
		{
			return new AppUserUserGroup();
		}
		
		
		#endregion


		[BrowsableAttribute( false )]
		public AppUserUserGroupQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new AppUserUserGroupQuery();
					base.InitQuery(this.query);
				}

				return this.query;
			}
		}

		public void QueryReset()
		{
			this.query = null;
		}

		public bool Load(AppUserUserGroupQuery query)
		{
			this.query = query;
			base.InitQuery(this.query);
			return this.Query.Load();
		}
		
		public AppUserUserGroup AddNew()
		{
			AppUserUserGroup entity = base.AddNewEntity() as AppUserUserGroup;
			
			return entity;
		}

		public AppUserUserGroup FindByPrimaryKey(System.String userID, System.String userGroupID)
		{
			return base.FindByPrimaryKey(userID, userGroupID) as AppUserUserGroup;
		}


		#region IEnumerable<AppUserUserGroup> Members

		IEnumerator<AppUserUserGroup> IEnumerable<AppUserUserGroup>.GetEnumerator()
		{
			System.Collections.IEnumerable enumer = this as System.Collections.IEnumerable;
			System.Collections.IEnumerator iterator = enumer.GetEnumerator();

			while(iterator.MoveNext())
			{
				yield return iterator.Current as AppUserUserGroup;
			}
		}

		#endregion
		
		private AppUserUserGroupQuery query;
	}


	/// <summary>
	/// Encapsulates the 'AppUserUserGroup' table
	/// </summary>

    [System.Diagnostics.DebuggerDisplay("AppUserUserGroup ({UserID},{UserGroupID})")]
	[Serializable]
	public partial class AppUserUserGroup : esAppUserUserGroup
	{
		public AppUserUserGroup()
		{

		}
	
		public AppUserUserGroup(DataRow row)
			: base(row)
		{

		}
		
		#region Housekeeping methods
		override protected IMetadata Meta
		{
			get
			{
				return AppUserUserGroupMetadata.Meta();
			}
		}
		
		
		
		override protected esAppUserUserGroupQuery GetDynamicQuery()
		{
			if (this.query == null)
			{
				this.query = new AppUserUserGroupQuery();
				this.InitQuery(query);
			}
			return this.query;
		}
		#endregion
		



		[BrowsableAttribute( false )]
		public AppUserUserGroupQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new AppUserUserGroupQuery();
					base.InitQuery(this.query);
				}

				return this.query;
			}
		}

		public void QueryReset()
		{
			this.query = null;
		}
		

		public bool Load(AppUserUserGroupQuery query)
		{
			this.query = query;
			base.InitQuery(this.query);
			return this.Query.Load();
		}
		
		private AppUserUserGroupQuery query;
	}



    [System.Diagnostics.DebuggerDisplay("LastQuery = {es.LastQuery}")]
	[Serializable]
		
	public partial class AppUserUserGroupQuery : esAppUserUserGroupQuery
	{
		public AppUserUserGroupQuery()
		{

		}		
		
		public AppUserUserGroupQuery(string joinAlias)
		{
			this.es.JoinAlias = joinAlias;
		}	

        override protected string GetQueryName()
        {
            return "AppUserUserGroupQuery";
        }
		
			
	}


	[Serializable]
	public partial class AppUserUserGroupMetadata : esMetadata, IMetadata
	{
		#region Protected Constructor
		protected AppUserUserGroupMetadata()
		{
			_columns = new esColumnMetadataCollection();
			esColumnMetadata c;

			c = new esColumnMetadata(AppUserUserGroupMetadata.ColumnNames.UserID, 0, typeof(System.String), esSystemType.String);
			c.PropertyName = AppUserUserGroupMetadata.PropertyNames.UserID;
			c.IsInPrimaryKey = true;
			c.CharacterMaxLength = 50;
			_columns.Add(c);
				
			c = new esColumnMetadata(AppUserUserGroupMetadata.ColumnNames.UserGroupID, 1, typeof(System.String), esSystemType.String);
			c.PropertyName = AppUserUserGroupMetadata.PropertyNames.UserGroupID;
			c.IsInPrimaryKey = true;
			c.CharacterMaxLength = 50;
			c.HasDefault = true;
			c.Default = @"((0))";
			_columns.Add(c);
				
			c = new esColumnMetadata(AppUserUserGroupMetadata.ColumnNames.LastUpdateDateTime, 2, typeof(System.DateTime), esSystemType.DateTime);
			c.PropertyName = AppUserUserGroupMetadata.PropertyNames.LastUpdateDateTime;
			c.IsNullable = true;
			_columns.Add(c);
				
			c = new esColumnMetadata(AppUserUserGroupMetadata.ColumnNames.LastUpdateByUserID, 3, typeof(System.String), esSystemType.String);
			c.PropertyName = AppUserUserGroupMetadata.PropertyNames.LastUpdateByUserID;
			c.CharacterMaxLength = 50;
			c.IsNullable = true;
			_columns.Add(c);
				
		}
		#endregion	
	
		static public AppUserUserGroupMetadata Meta()
		{
			return meta;
		}	
		
		public Guid DataID
		{
			get { return base._dataID; }
		}	
		
		public bool MultiProviderMode
		{
			get { return false; }
		}		

		public esColumnMetadataCollection Columns
		{
			get	{ return base._columns; }
		}
		
		#region ColumnNames
		public class ColumnNames
		{ 
			 public const string UserID = "UserID";
			 public const string UserGroupID = "UserGroupID";
			 public const string LastUpdateDateTime = "LastUpdateDateTime";
			 public const string LastUpdateByUserID = "LastUpdateByUserID";
		}
		#endregion	
		
		#region PropertyNames
		public class PropertyNames
		{ 
			 public const string UserID = "UserID";
			 public const string UserGroupID = "UserGroupID";
			 public const string LastUpdateDateTime = "LastUpdateDateTime";
			 public const string LastUpdateByUserID = "LastUpdateByUserID";
		}
		#endregion	

		public esProviderSpecificMetadata GetProviderMetadata(string mapName)
		{
			MapToMeta mapMethod = mapDelegates[mapName];

			if (mapMethod != null)
				return mapMethod(mapName);
			else
				return null;
		}
		
		#region MAP esDefault
		
		static private int RegisterDelegateesDefault()
		{
			// This is only executed once per the life of the application
			lock (typeof(AppUserUserGroupMetadata))
			{
				if(AppUserUserGroupMetadata.mapDelegates == null)
				{
					AppUserUserGroupMetadata.mapDelegates = new Dictionary<string,MapToMeta>();
				}
				
				if (AppUserUserGroupMetadata.meta == null)
				{
					AppUserUserGroupMetadata.meta = new AppUserUserGroupMetadata();
				}
				
				MapToMeta mapMethod = new MapToMeta(meta.esDefault);
				mapDelegates.Add("esDefault", mapMethod);
				mapMethod("esDefault");
			}
			return 0;
		}			

		private esProviderSpecificMetadata esDefault(string mapName)
		{
			if(!_providerMetadataMaps.ContainsKey(mapName))
			{
				esProviderSpecificMetadata meta = new esProviderSpecificMetadata();
				

				meta.AddTypeMap("UserID", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("UserGroupID", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("LastUpdateDateTime", new esTypeMap("datetime", "System.DateTime"));
				meta.AddTypeMap("LastUpdateByUserID", new esTypeMap("nvarchar", "System.String"));			
				
				
				
				meta.Source = "AppUserUserGroup";
				meta.Destination = "AppUserUserGroup";
				
				meta.spInsert = "proc_AppUserUserGroupInsert";				
				meta.spUpdate = "proc_AppUserUserGroupUpdate";		
				meta.spDelete = "proc_AppUserUserGroupDelete";
				meta.spLoadAll = "proc_AppUserUserGroupLoadAll";
				meta.spLoadByPrimaryKey = "proc_AppUserUserGroupLoadByPrimaryKey";
				
				this._providerMetadataMaps["esDefault"] = meta;
			}
			
			return this._providerMetadataMaps["esDefault"];
		}

		#endregion

		static private AppUserUserGroupMetadata meta;
		static protected Dictionary<string, MapToMeta> mapDelegates;
		static private int _esDefault = RegisterDelegateesDefault();
	}
}
