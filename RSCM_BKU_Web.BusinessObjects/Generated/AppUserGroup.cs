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
	abstract public class esAppUserGroupCollection : esEntityCollection
	{
		public esAppUserGroupCollection()
		{

		}

		protected override string GetCollectionName()
		{
			return "AppUserGroupCollection";
		}

		#region Query Logic
		protected void InitQuery(esAppUserGroupQuery query)
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
			this.InitQuery(query as esAppUserGroupQuery);
		}
		#endregion
		
		virtual public AppUserGroup DetachEntity(AppUserGroup entity)
		{
			return base.DetachEntity(entity) as AppUserGroup;
		}
		
		virtual public AppUserGroup AttachEntity(AppUserGroup entity)
		{
			return base.AttachEntity(entity) as AppUserGroup;
		}
		
		virtual public void Combine(AppUserGroupCollection collection)
		{
			base.Combine(collection);
		}
		
		new public AppUserGroup this[int index]
		{
			get
			{
				return base[index] as AppUserGroup;
			}
		}

		public override Type GetEntityType()
		{
			return typeof(AppUserGroup);
		}
	}



	[Serializable]
	abstract public class esAppUserGroup : esEntity
	{
		/// <summary>
		/// Used internally by the entity's DynamicQuery mechanism.
		/// </summary>
		virtual protected esAppUserGroupQuery GetDynamicQuery()
		{
			return null;
		}

		public esAppUserGroup()
		{

		}

		public esAppUserGroup(DataRow row)
			: base(row)
		{

		}
		
		#region LoadByPrimaryKey
		public virtual bool LoadByPrimaryKey(System.String userGroupID)
		{
			if(this.es.Connection.SqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(userGroupID);
			else
				return LoadByPrimaryKeyStoredProcedure(userGroupID);
		}

		public virtual bool LoadByPrimaryKey(esSqlAccessType sqlAccessType, System.String userGroupID)
		{
			if (sqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(userGroupID);
			else
				return LoadByPrimaryKeyStoredProcedure(userGroupID);
		}

		private bool LoadByPrimaryKeyDynamic(System.String userGroupID)
		{
			esAppUserGroupQuery query = this.GetDynamicQuery();
			query.Where(query.UserGroupID == userGroupID);
			return query.Load();
		}

		private bool LoadByPrimaryKeyStoredProcedure(System.String userGroupID)
		{
			esParameters parms = new esParameters();
			parms.Add("UserGroupID",userGroupID);
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
						case "UserGroupID": this.str.UserGroupID = (string)value; break;							
						case "UserGroupName": this.str.UserGroupName = (string)value; break;							
						case "IsEditAble": this.str.IsEditAble = (string)value; break;							
						case "LastUpdateDateTime": this.str.LastUpdateDateTime = (string)value; break;							
						case "LastUpdateByUserID": this.str.LastUpdateByUserID = (string)value; break;
					}
				}
				else
				{
					switch (name)
					{	
						case "IsEditAble":
						
							if (value == null || value is System.Boolean)
								this.IsEditAble = (System.Boolean?)value;
							break;
						
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
		/// Maps to AppUserGroup.UserGroupID
		/// </summary>
		virtual public System.String UserGroupID
		{
			get
			{
				return base.GetSystemString(AppUserGroupMetadata.ColumnNames.UserGroupID);
			}
			
			set
			{
				base.SetSystemString(AppUserGroupMetadata.ColumnNames.UserGroupID, value);
			}
		}
		
		/// <summary>
		/// Maps to AppUserGroup.UserGroupName
		/// </summary>
		virtual public System.String UserGroupName
		{
			get
			{
				return base.GetSystemString(AppUserGroupMetadata.ColumnNames.UserGroupName);
			}
			
			set
			{
				base.SetSystemString(AppUserGroupMetadata.ColumnNames.UserGroupName, value);
			}
		}
		
		/// <summary>
		/// Maps to AppUserGroup.IsEditAble
		/// </summary>
		virtual public System.Boolean? IsEditAble
		{
			get
			{
				return base.GetSystemBoolean(AppUserGroupMetadata.ColumnNames.IsEditAble);
			}
			
			set
			{
				base.SetSystemBoolean(AppUserGroupMetadata.ColumnNames.IsEditAble, value);
			}
		}
		
		/// <summary>
		/// Maps to AppUserGroup.LastUpdateDateTime
		/// </summary>
		virtual public System.DateTime? LastUpdateDateTime
		{
			get
			{
				return base.GetSystemDateTime(AppUserGroupMetadata.ColumnNames.LastUpdateDateTime);
			}
			
			set
			{
				base.SetSystemDateTime(AppUserGroupMetadata.ColumnNames.LastUpdateDateTime, value);
			}
		}
		
		/// <summary>
		/// Maps to AppUserGroup.LastUpdateByUserID
		/// </summary>
		virtual public System.String LastUpdateByUserID
		{
			get
			{
				return base.GetSystemString(AppUserGroupMetadata.ColumnNames.LastUpdateByUserID);
			}
			
			set
			{
				base.SetSystemString(AppUserGroupMetadata.ColumnNames.LastUpdateByUserID, value);
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
			public esStrings(esAppUserGroup entity)
			{
				this.entity = entity;
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
				
			public System.String UserGroupName
			{
				get
				{
					System.String data = entity.UserGroupName;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.UserGroupName = null;
					else entity.UserGroupName = Convert.ToString(value);
				}
			}
				
			public System.String IsEditAble
			{
				get
				{
					System.Boolean? data = entity.IsEditAble;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.IsEditAble = null;
					else entity.IsEditAble = Convert.ToBoolean(value);
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
			

			private esAppUserGroup entity;
		}
		#endregion

		#region Query Logic
		protected void InitQuery(esAppUserGroupQuery query)
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
				throw new Exception("esAppUserGroup can only hold one record of data");
			}

			return dataFound;
		}
		#endregion
		
		[NonSerialized]
		private esStrings esstrings;
	}


	
	public partial class AppUserGroup : esAppUserGroup
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
	abstract public class esAppUserGroupQuery : esDynamicQuery
	{
		override protected IMetadata Meta
		{
			get
			{
				return AppUserGroupMetadata.Meta();
			}
		}	
		

		public esQueryItem UserGroupID
		{
			get
			{
				return new esQueryItem(this, AppUserGroupMetadata.ColumnNames.UserGroupID, esSystemType.String);
			}
		} 
		
		public esQueryItem UserGroupName
		{
			get
			{
				return new esQueryItem(this, AppUserGroupMetadata.ColumnNames.UserGroupName, esSystemType.String);
			}
		} 
		
		public esQueryItem IsEditAble
		{
			get
			{
				return new esQueryItem(this, AppUserGroupMetadata.ColumnNames.IsEditAble, esSystemType.Boolean);
			}
		} 
		
		public esQueryItem LastUpdateDateTime
		{
			get
			{
				return new esQueryItem(this, AppUserGroupMetadata.ColumnNames.LastUpdateDateTime, esSystemType.DateTime);
			}
		} 
		
		public esQueryItem LastUpdateByUserID
		{
			get
			{
				return new esQueryItem(this, AppUserGroupMetadata.ColumnNames.LastUpdateByUserID, esSystemType.String);
			}
		} 
		
	}



    [System.Diagnostics.DebuggerDisplay("Count = {Count}")]
	[Serializable]
	[XmlType("AppUserGroupCollection")]
	public partial class AppUserGroupCollection : esAppUserGroupCollection, IEnumerable<AppUserGroup>
	{
		public AppUserGroupCollection()
		{

		}
		
		public static implicit operator List<AppUserGroup>(AppUserGroupCollection coll)
		{
			List<AppUserGroup> list = new List<AppUserGroup>();
			
			foreach (AppUserGroup emp in coll)
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
				return  AppUserGroupMetadata.Meta();
			}
		}
		
		
		
		override protected esDynamicQuery GetDynamicQuery()
		{
			if (this.query == null)
			{
				this.query = new AppUserGroupQuery();
				this.InitQuery(query);
			}
			return this.query;
		}
		
		override protected esEntity CreateEntityForCollection(DataRow row)
		{
			return new AppUserGroup(row);
		}

		override protected esEntity CreateEntity()
		{
			return new AppUserGroup();
		}
		
		
		#endregion


		[BrowsableAttribute( false )]
		public AppUserGroupQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new AppUserGroupQuery();
					base.InitQuery(this.query);
				}

				return this.query;
			}
		}

		public void QueryReset()
		{
			this.query = null;
		}

		public bool Load(AppUserGroupQuery query)
		{
			this.query = query;
			base.InitQuery(this.query);
			return this.Query.Load();
		}
		
		public AppUserGroup AddNew()
		{
			AppUserGroup entity = base.AddNewEntity() as AppUserGroup;
			
			return entity;
		}

		public AppUserGroup FindByPrimaryKey(System.String userGroupID)
		{
			return base.FindByPrimaryKey(userGroupID) as AppUserGroup;
		}


		#region IEnumerable<AppUserGroup> Members

		IEnumerator<AppUserGroup> IEnumerable<AppUserGroup>.GetEnumerator()
		{
			System.Collections.IEnumerable enumer = this as System.Collections.IEnumerable;
			System.Collections.IEnumerator iterator = enumer.GetEnumerator();

			while(iterator.MoveNext())
			{
				yield return iterator.Current as AppUserGroup;
			}
		}

		#endregion
		
		private AppUserGroupQuery query;
	}


	/// <summary>
	/// Encapsulates the 'AppUserGroup' table
	/// </summary>

    [System.Diagnostics.DebuggerDisplay("AppUserGroup ({UserGroupID})")]
	[Serializable]
	public partial class AppUserGroup : esAppUserGroup
	{
		public AppUserGroup()
		{

		}
	
		public AppUserGroup(DataRow row)
			: base(row)
		{

		}
		
		#region Housekeeping methods
		override protected IMetadata Meta
		{
			get
			{
				return AppUserGroupMetadata.Meta();
			}
		}
		
		
		
		override protected esAppUserGroupQuery GetDynamicQuery()
		{
			if (this.query == null)
			{
				this.query = new AppUserGroupQuery();
				this.InitQuery(query);
			}
			return this.query;
		}
		#endregion
		



		[BrowsableAttribute( false )]
		public AppUserGroupQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new AppUserGroupQuery();
					base.InitQuery(this.query);
				}

				return this.query;
			}
		}

		public void QueryReset()
		{
			this.query = null;
		}
		

		public bool Load(AppUserGroupQuery query)
		{
			this.query = query;
			base.InitQuery(this.query);
			return this.Query.Load();
		}
		
		private AppUserGroupQuery query;
	}



    [System.Diagnostics.DebuggerDisplay("LastQuery = {es.LastQuery}")]
	[Serializable]
		
	public partial class AppUserGroupQuery : esAppUserGroupQuery
	{
		public AppUserGroupQuery()
		{

		}		
		
		public AppUserGroupQuery(string joinAlias)
		{
			this.es.JoinAlias = joinAlias;
		}	

        override protected string GetQueryName()
        {
            return "AppUserGroupQuery";
        }
		
			
	}


	[Serializable]
	public partial class AppUserGroupMetadata : esMetadata, IMetadata
	{
		#region Protected Constructor
		protected AppUserGroupMetadata()
		{
			_columns = new esColumnMetadataCollection();
			esColumnMetadata c;

			c = new esColumnMetadata(AppUserGroupMetadata.ColumnNames.UserGroupID, 0, typeof(System.String), esSystemType.String);
			c.PropertyName = AppUserGroupMetadata.PropertyNames.UserGroupID;
			c.IsInPrimaryKey = true;
			c.CharacterMaxLength = 50;
			_columns.Add(c);
				
			c = new esColumnMetadata(AppUserGroupMetadata.ColumnNames.UserGroupName, 1, typeof(System.String), esSystemType.String);
			c.PropertyName = AppUserGroupMetadata.PropertyNames.UserGroupName;
			c.CharacterMaxLength = 50;
			_columns.Add(c);
				
			c = new esColumnMetadata(AppUserGroupMetadata.ColumnNames.IsEditAble, 2, typeof(System.Boolean), esSystemType.Boolean);
			c.PropertyName = AppUserGroupMetadata.PropertyNames.IsEditAble;
			_columns.Add(c);
				
			c = new esColumnMetadata(AppUserGroupMetadata.ColumnNames.LastUpdateDateTime, 3, typeof(System.DateTime), esSystemType.DateTime);
			c.PropertyName = AppUserGroupMetadata.PropertyNames.LastUpdateDateTime;
			c.IsNullable = true;
			_columns.Add(c);
				
			c = new esColumnMetadata(AppUserGroupMetadata.ColumnNames.LastUpdateByUserID, 4, typeof(System.String), esSystemType.String);
			c.PropertyName = AppUserGroupMetadata.PropertyNames.LastUpdateByUserID;
			c.CharacterMaxLength = 50;
			c.IsNullable = true;
			_columns.Add(c);
				
		}
		#endregion	
	
		static public AppUserGroupMetadata Meta()
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
			 public const string UserGroupID = "UserGroupID";
			 public const string UserGroupName = "UserGroupName";
			 public const string IsEditAble = "IsEditAble";
			 public const string LastUpdateDateTime = "LastUpdateDateTime";
			 public const string LastUpdateByUserID = "LastUpdateByUserID";
		}
		#endregion	
		
		#region PropertyNames
		public class PropertyNames
		{ 
			 public const string UserGroupID = "UserGroupID";
			 public const string UserGroupName = "UserGroupName";
			 public const string IsEditAble = "IsEditAble";
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
			lock (typeof(AppUserGroupMetadata))
			{
				if(AppUserGroupMetadata.mapDelegates == null)
				{
					AppUserGroupMetadata.mapDelegates = new Dictionary<string,MapToMeta>();
				}
				
				if (AppUserGroupMetadata.meta == null)
				{
					AppUserGroupMetadata.meta = new AppUserGroupMetadata();
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
				

				meta.AddTypeMap("UserGroupID", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("UserGroupName", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("IsEditAble", new esTypeMap("bit", "System.Boolean"));
				meta.AddTypeMap("LastUpdateDateTime", new esTypeMap("datetime", "System.DateTime"));
				meta.AddTypeMap("LastUpdateByUserID", new esTypeMap("nvarchar", "System.String"));			
				
				
				
				meta.Source = "AppUserGroup";
				meta.Destination = "AppUserGroup";
				
				meta.spInsert = "proc_AppUserGroupInsert";				
				meta.spUpdate = "proc_AppUserGroupUpdate";		
				meta.spDelete = "proc_AppUserGroupDelete";
				meta.spLoadAll = "proc_AppUserGroupLoadAll";
				meta.spLoadByPrimaryKey = "proc_AppUserGroupLoadByPrimaryKey";
				
				this._providerMetadataMaps["esDefault"] = meta;
			}
			
			return this._providerMetadataMaps["esDefault"];
		}

		#endregion

		static private AppUserGroupMetadata meta;
		static protected Dictionary<string, MapToMeta> mapDelegates;
		static private int _esDefault = RegisterDelegateesDefault();
	}
}
