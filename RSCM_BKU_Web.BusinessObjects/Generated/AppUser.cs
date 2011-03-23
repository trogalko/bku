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
	abstract public class esAppUserCollection : esEntityCollection
	{
		public esAppUserCollection()
		{

		}

		protected override string GetCollectionName()
		{
			return "AppUserCollection";
		}

		#region Query Logic
		protected void InitQuery(esAppUserQuery query)
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
			this.InitQuery(query as esAppUserQuery);
		}
		#endregion
		
		virtual public AppUser DetachEntity(AppUser entity)
		{
			return base.DetachEntity(entity) as AppUser;
		}
		
		virtual public AppUser AttachEntity(AppUser entity)
		{
			return base.AttachEntity(entity) as AppUser;
		}
		
		virtual public void Combine(AppUserCollection collection)
		{
			base.Combine(collection);
		}
		
		new public AppUser this[int index]
		{
			get
			{
				return base[index] as AppUser;
			}
		}

		public override Type GetEntityType()
		{
			return typeof(AppUser);
		}
	}



	[Serializable]
	abstract public class esAppUser : esEntity
	{
		/// <summary>
		/// Used internally by the entity's DynamicQuery mechanism.
		/// </summary>
		virtual protected esAppUserQuery GetDynamicQuery()
		{
			return null;
		}

		public esAppUser()
		{

		}

		public esAppUser(DataRow row)
			: base(row)
		{

		}
		
		#region LoadByPrimaryKey
		public virtual bool LoadByPrimaryKey(System.String userID)
		{
			if(this.es.Connection.SqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(userID);
			else
				return LoadByPrimaryKeyStoredProcedure(userID);
		}

		public virtual bool LoadByPrimaryKey(esSqlAccessType sqlAccessType, System.String userID)
		{
			if (sqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(userID);
			else
				return LoadByPrimaryKeyStoredProcedure(userID);
		}

		private bool LoadByPrimaryKeyDynamic(System.String userID)
		{
			esAppUserQuery query = this.GetDynamicQuery();
			query.Where(query.UserID == userID);
			return query.Load();
		}

		private bool LoadByPrimaryKeyStoredProcedure(System.String userID)
		{
			esParameters parms = new esParameters();
			parms.Add("UserID",userID);
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
						case "UserName": this.str.UserName = (string)value; break;							
						case "Password": this.str.Password = (string)value; break;							
						case "SRLanguage": this.str.SRLanguage = (string)value; break;							
						case "ActiveDate": this.str.ActiveDate = (string)value; break;							
						case "ExpireDate": this.str.ExpireDate = (string)value; break;							
						case "LastUpdateDateTime": this.str.LastUpdateDateTime = (string)value; break;							
						case "LastUpdateByUserID": this.str.LastUpdateByUserID = (string)value; break;
					}
				}
				else
				{
					switch (name)
					{	
						case "ActiveDate":
						
							if (value == null || value is System.DateTime)
								this.ActiveDate = (System.DateTime?)value;
							break;
						
						case "ExpireDate":
						
							if (value == null || value is System.DateTime)
								this.ExpireDate = (System.DateTime?)value;
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
		/// Maps to AppUser.UserID
		/// </summary>
		virtual public System.String UserID
		{
			get
			{
				return base.GetSystemString(AppUserMetadata.ColumnNames.UserID);
			}
			
			set
			{
				base.SetSystemString(AppUserMetadata.ColumnNames.UserID, value);
			}
		}
		
		/// <summary>
		/// Maps to AppUser.UserName
		/// </summary>
		virtual public System.String UserName
		{
			get
			{
				return base.GetSystemString(AppUserMetadata.ColumnNames.UserName);
			}
			
			set
			{
				base.SetSystemString(AppUserMetadata.ColumnNames.UserName, value);
			}
		}
		
		/// <summary>
		/// Maps to AppUser.Password
		/// </summary>
		virtual public System.String Password
		{
			get
			{
				return base.GetSystemString(AppUserMetadata.ColumnNames.Password);
			}
			
			set
			{
				base.SetSystemString(AppUserMetadata.ColumnNames.Password, value);
			}
		}
		
		/// <summary>
		/// Maps to AppUser.SRLanguage
		/// </summary>
		virtual public System.String SRLanguage
		{
			get
			{
				return base.GetSystemString(AppUserMetadata.ColumnNames.SRLanguage);
			}
			
			set
			{
				base.SetSystemString(AppUserMetadata.ColumnNames.SRLanguage, value);
			}
		}
		
		/// <summary>
		/// Maps to AppUser.ActiveDate
		/// </summary>
		virtual public System.DateTime? ActiveDate
		{
			get
			{
				return base.GetSystemDateTime(AppUserMetadata.ColumnNames.ActiveDate);
			}
			
			set
			{
				base.SetSystemDateTime(AppUserMetadata.ColumnNames.ActiveDate, value);
			}
		}
		
		/// <summary>
		/// Maps to AppUser.ExpireDate
		/// </summary>
		virtual public System.DateTime? ExpireDate
		{
			get
			{
				return base.GetSystemDateTime(AppUserMetadata.ColumnNames.ExpireDate);
			}
			
			set
			{
				base.SetSystemDateTime(AppUserMetadata.ColumnNames.ExpireDate, value);
			}
		}
		
		/// <summary>
		/// Maps to AppUser.LastUpdateDateTime
		/// </summary>
		virtual public System.DateTime? LastUpdateDateTime
		{
			get
			{
				return base.GetSystemDateTime(AppUserMetadata.ColumnNames.LastUpdateDateTime);
			}
			
			set
			{
				base.SetSystemDateTime(AppUserMetadata.ColumnNames.LastUpdateDateTime, value);
			}
		}
		
		/// <summary>
		/// Maps to AppUser.LastUpdateByUserID
		/// </summary>
		virtual public System.String LastUpdateByUserID
		{
			get
			{
				return base.GetSystemString(AppUserMetadata.ColumnNames.LastUpdateByUserID);
			}
			
			set
			{
				base.SetSystemString(AppUserMetadata.ColumnNames.LastUpdateByUserID, value);
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
			public esStrings(esAppUser entity)
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
				
			public System.String UserName
			{
				get
				{
					System.String data = entity.UserName;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.UserName = null;
					else entity.UserName = Convert.ToString(value);
				}
			}
				
			public System.String Password
			{
				get
				{
					System.String data = entity.Password;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.Password = null;
					else entity.Password = Convert.ToString(value);
				}
			}
				
			public System.String SRLanguage
			{
				get
				{
					System.String data = entity.SRLanguage;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.SRLanguage = null;
					else entity.SRLanguage = Convert.ToString(value);
				}
			}
				
			public System.String ActiveDate
			{
				get
				{
					System.DateTime? data = entity.ActiveDate;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.ActiveDate = null;
					else entity.ActiveDate = Convert.ToDateTime(value);
				}
			}
				
			public System.String ExpireDate
			{
				get
				{
					System.DateTime? data = entity.ExpireDate;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.ExpireDate = null;
					else entity.ExpireDate = Convert.ToDateTime(value);
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
			

			private esAppUser entity;
		}
		#endregion

		#region Query Logic
		protected void InitQuery(esAppUserQuery query)
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
				throw new Exception("esAppUser can only hold one record of data");
			}

			return dataFound;
		}
		#endregion
		
		[NonSerialized]
		private esStrings esstrings;
	}


	
	public partial class AppUser : esAppUser
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
	abstract public class esAppUserQuery : esDynamicQuery
	{
		override protected IMetadata Meta
		{
			get
			{
				return AppUserMetadata.Meta();
			}
		}	
		

		public esQueryItem UserID
		{
			get
			{
				return new esQueryItem(this, AppUserMetadata.ColumnNames.UserID, esSystemType.String);
			}
		} 
		
		public esQueryItem UserName
		{
			get
			{
				return new esQueryItem(this, AppUserMetadata.ColumnNames.UserName, esSystemType.String);
			}
		} 
		
		public esQueryItem Password
		{
			get
			{
				return new esQueryItem(this, AppUserMetadata.ColumnNames.Password, esSystemType.String);
			}
		} 
		
		public esQueryItem SRLanguage
		{
			get
			{
				return new esQueryItem(this, AppUserMetadata.ColumnNames.SRLanguage, esSystemType.String);
			}
		} 
		
		public esQueryItem ActiveDate
		{
			get
			{
				return new esQueryItem(this, AppUserMetadata.ColumnNames.ActiveDate, esSystemType.DateTime);
			}
		} 
		
		public esQueryItem ExpireDate
		{
			get
			{
				return new esQueryItem(this, AppUserMetadata.ColumnNames.ExpireDate, esSystemType.DateTime);
			}
		} 
		
		public esQueryItem LastUpdateDateTime
		{
			get
			{
				return new esQueryItem(this, AppUserMetadata.ColumnNames.LastUpdateDateTime, esSystemType.DateTime);
			}
		} 
		
		public esQueryItem LastUpdateByUserID
		{
			get
			{
				return new esQueryItem(this, AppUserMetadata.ColumnNames.LastUpdateByUserID, esSystemType.String);
			}
		} 
		
	}



    [System.Diagnostics.DebuggerDisplay("Count = {Count}")]
	[Serializable]
	[XmlType("AppUserCollection")]
	public partial class AppUserCollection : esAppUserCollection, IEnumerable<AppUser>
	{
		public AppUserCollection()
		{

		}
		
		public static implicit operator List<AppUser>(AppUserCollection coll)
		{
			List<AppUser> list = new List<AppUser>();
			
			foreach (AppUser emp in coll)
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
				return  AppUserMetadata.Meta();
			}
		}
		
		
		
		override protected esDynamicQuery GetDynamicQuery()
		{
			if (this.query == null)
			{
				this.query = new AppUserQuery();
				this.InitQuery(query);
			}
			return this.query;
		}
		
		override protected esEntity CreateEntityForCollection(DataRow row)
		{
			return new AppUser(row);
		}

		override protected esEntity CreateEntity()
		{
			return new AppUser();
		}
		
		
		#endregion


		[BrowsableAttribute( false )]
		public AppUserQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new AppUserQuery();
					base.InitQuery(this.query);
				}

				return this.query;
			}
		}

		public void QueryReset()
		{
			this.query = null;
		}

		public bool Load(AppUserQuery query)
		{
			this.query = query;
			base.InitQuery(this.query);
			return this.Query.Load();
		}
		
		public AppUser AddNew()
		{
			AppUser entity = base.AddNewEntity() as AppUser;
			
			return entity;
		}

		public AppUser FindByPrimaryKey(System.String userID)
		{
			return base.FindByPrimaryKey(userID) as AppUser;
		}


		#region IEnumerable<AppUser> Members

		IEnumerator<AppUser> IEnumerable<AppUser>.GetEnumerator()
		{
			System.Collections.IEnumerable enumer = this as System.Collections.IEnumerable;
			System.Collections.IEnumerator iterator = enumer.GetEnumerator();

			while(iterator.MoveNext())
			{
				yield return iterator.Current as AppUser;
			}
		}

		#endregion
		
		private AppUserQuery query;
	}


	/// <summary>
	/// Encapsulates the 'AppUser' table
	/// </summary>

    [System.Diagnostics.DebuggerDisplay("AppUser ({UserID})")]
	[Serializable]
	public partial class AppUser : esAppUser
	{
		public AppUser()
		{

		}
	
		public AppUser(DataRow row)
			: base(row)
		{

		}
		
		#region Housekeeping methods
		override protected IMetadata Meta
		{
			get
			{
				return AppUserMetadata.Meta();
			}
		}
		
		
		
		override protected esAppUserQuery GetDynamicQuery()
		{
			if (this.query == null)
			{
				this.query = new AppUserQuery();
				this.InitQuery(query);
			}
			return this.query;
		}
		#endregion
		



		[BrowsableAttribute( false )]
		public AppUserQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new AppUserQuery();
					base.InitQuery(this.query);
				}

				return this.query;
			}
		}

		public void QueryReset()
		{
			this.query = null;
		}
		

		public bool Load(AppUserQuery query)
		{
			this.query = query;
			base.InitQuery(this.query);
			return this.Query.Load();
		}
		
		private AppUserQuery query;
	}



    [System.Diagnostics.DebuggerDisplay("LastQuery = {es.LastQuery}")]
	[Serializable]
		
	public partial class AppUserQuery : esAppUserQuery
	{
		public AppUserQuery()
		{

		}		
		
		public AppUserQuery(string joinAlias)
		{
			this.es.JoinAlias = joinAlias;
		}	

        override protected string GetQueryName()
        {
            return "AppUserQuery";
        }
		
			
	}


	[Serializable]
	public partial class AppUserMetadata : esMetadata, IMetadata
	{
		#region Protected Constructor
		protected AppUserMetadata()
		{
			_columns = new esColumnMetadataCollection();
			esColumnMetadata c;

			c = new esColumnMetadata(AppUserMetadata.ColumnNames.UserID, 0, typeof(System.String), esSystemType.String);
			c.PropertyName = AppUserMetadata.PropertyNames.UserID;
			c.IsInPrimaryKey = true;
			c.CharacterMaxLength = 50;
			_columns.Add(c);
				
			c = new esColumnMetadata(AppUserMetadata.ColumnNames.UserName, 1, typeof(System.String), esSystemType.String);
			c.PropertyName = AppUserMetadata.PropertyNames.UserName;
			c.CharacterMaxLength = 50;
			_columns.Add(c);
				
			c = new esColumnMetadata(AppUserMetadata.ColumnNames.Password, 2, typeof(System.String), esSystemType.String);
			c.PropertyName = AppUserMetadata.PropertyNames.Password;
			c.CharacterMaxLength = 50;
			_columns.Add(c);
				
			c = new esColumnMetadata(AppUserMetadata.ColumnNames.SRLanguage, 3, typeof(System.String), esSystemType.String);
			c.PropertyName = AppUserMetadata.PropertyNames.SRLanguage;
			c.CharacterMaxLength = 50;
			c.HasDefault = true;
			c.Default = @"('id-ID')";
			c.IsNullable = true;
			_columns.Add(c);
				
			c = new esColumnMetadata(AppUserMetadata.ColumnNames.ActiveDate, 4, typeof(System.DateTime), esSystemType.DateTime);
			c.PropertyName = AppUserMetadata.PropertyNames.ActiveDate;
			c.IsNullable = true;
			_columns.Add(c);
				
			c = new esColumnMetadata(AppUserMetadata.ColumnNames.ExpireDate, 5, typeof(System.DateTime), esSystemType.DateTime);
			c.PropertyName = AppUserMetadata.PropertyNames.ExpireDate;
			c.IsNullable = true;
			_columns.Add(c);
				
			c = new esColumnMetadata(AppUserMetadata.ColumnNames.LastUpdateDateTime, 6, typeof(System.DateTime), esSystemType.DateTime);
			c.PropertyName = AppUserMetadata.PropertyNames.LastUpdateDateTime;
			c.IsNullable = true;
			_columns.Add(c);
				
			c = new esColumnMetadata(AppUserMetadata.ColumnNames.LastUpdateByUserID, 7, typeof(System.String), esSystemType.String);
			c.PropertyName = AppUserMetadata.PropertyNames.LastUpdateByUserID;
			c.CharacterMaxLength = 50;
			c.IsNullable = true;
			_columns.Add(c);
				
		}
		#endregion	
	
		static public AppUserMetadata Meta()
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
			 public const string UserName = "UserName";
			 public const string Password = "Password";
			 public const string SRLanguage = "SRLanguage";
			 public const string ActiveDate = "ActiveDate";
			 public const string ExpireDate = "ExpireDate";
			 public const string LastUpdateDateTime = "LastUpdateDateTime";
			 public const string LastUpdateByUserID = "LastUpdateByUserID";
		}
		#endregion	
		
		#region PropertyNames
		public class PropertyNames
		{ 
			 public const string UserID = "UserID";
			 public const string UserName = "UserName";
			 public const string Password = "Password";
			 public const string SRLanguage = "SRLanguage";
			 public const string ActiveDate = "ActiveDate";
			 public const string ExpireDate = "ExpireDate";
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
			lock (typeof(AppUserMetadata))
			{
				if(AppUserMetadata.mapDelegates == null)
				{
					AppUserMetadata.mapDelegates = new Dictionary<string,MapToMeta>();
				}
				
				if (AppUserMetadata.meta == null)
				{
					AppUserMetadata.meta = new AppUserMetadata();
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
				meta.AddTypeMap("UserName", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("Password", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("SRLanguage", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("ActiveDate", new esTypeMap("datetime", "System.DateTime"));
				meta.AddTypeMap("ExpireDate", new esTypeMap("datetime", "System.DateTime"));
				meta.AddTypeMap("LastUpdateDateTime", new esTypeMap("datetime", "System.DateTime"));
				meta.AddTypeMap("LastUpdateByUserID", new esTypeMap("nvarchar", "System.String"));			
				
				
				
				meta.Source = "AppUser";
				meta.Destination = "AppUser";
				
				meta.spInsert = "proc_AppUserInsert";				
				meta.spUpdate = "proc_AppUserUpdate";		
				meta.spDelete = "proc_AppUserDelete";
				meta.spLoadAll = "proc_AppUserLoadAll";
				meta.spLoadByPrimaryKey = "proc_AppUserLoadByPrimaryKey";
				
				this._providerMetadataMaps["esDefault"] = meta;
			}
			
			return this._providerMetadataMaps["esDefault"];
		}

		#endregion

		static private AppUserMetadata meta;
		static protected Dictionary<string, MapToMeta> mapDelegates;
		static private int _esDefault = RegisterDelegateesDefault();
	}
}
