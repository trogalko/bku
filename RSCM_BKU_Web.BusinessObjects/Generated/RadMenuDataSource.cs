/*
===============================================================================
                    EntitySpaces 2009 by EntitySpaces, LLC
             Persistence Layer and Business Objects for Microsoft .NET
             EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
                          http://www.entityspaces.net
===============================================================================
EntitySpaces Version : 2009.2.1214.0
EntitySpaces Driver  : SQL
Date Generated       : 10/03/2011 10:06:03
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
	abstract public class esRadMenuDataSourceCollection : esEntityCollection
	{
		public esRadMenuDataSourceCollection()
		{

		}

		protected override string GetCollectionName()
		{
			return "RadMenuDataSourceCollection";
		}

		#region Query Logic
		protected void InitQuery(esRadMenuDataSourceQuery query)
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
			this.InitQuery(query as esRadMenuDataSourceQuery);
		}
		#endregion
		
		virtual public RadMenuDataSource DetachEntity(RadMenuDataSource entity)
		{
			return base.DetachEntity(entity) as RadMenuDataSource;
		}
		
		virtual public RadMenuDataSource AttachEntity(RadMenuDataSource entity)
		{
			return base.AttachEntity(entity) as RadMenuDataSource;
		}
		
		virtual public void Combine(RadMenuDataSourceCollection collection)
		{
			base.Combine(collection);
		}
		
		new public RadMenuDataSource this[int index]
		{
			get
			{
				return base[index] as RadMenuDataSource;
			}
		}

		public override Type GetEntityType()
		{
			return typeof(RadMenuDataSource);
		}
	}



	[Serializable]
	abstract public class esRadMenuDataSource : esEntity
	{
		/// <summary>
		/// Used internally by the entity's DynamicQuery mechanism.
		/// </summary>
		virtual protected esRadMenuDataSourceQuery GetDynamicQuery()
		{
			return null;
		}

		public esRadMenuDataSource()
		{

		}

		public esRadMenuDataSource(DataRow row)
			: base(row)
		{

		}
		
		#region LoadByPrimaryKey
		
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
						case "ProgramID": this.str.ProgramID = (string)value; break;							
						case "ParentProgramID": this.str.ParentProgramID = (string)value; break;							
						case "ProgramName": this.str.ProgramName = (string)value; break;							
						case "NavigateUrl": this.str.NavigateUrl = (string)value; break;							
						case "UserID": this.str.UserID = (string)value; break;
					}
				}
				else
				{
					switch (name)
					{

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
		/// Maps to RadMenuDataSource.ProgramID
		/// </summary>
		virtual public System.String ProgramID
		{
			get
			{
				return base.GetSystemString(RadMenuDataSourceMetadata.ColumnNames.ProgramID);
			}
			
			set
			{
				base.SetSystemString(RadMenuDataSourceMetadata.ColumnNames.ProgramID, value);
			}
		}
		
		/// <summary>
		/// Maps to RadMenuDataSource.ParentProgramID
		/// </summary>
		virtual public System.String ParentProgramID
		{
			get
			{
				return base.GetSystemString(RadMenuDataSourceMetadata.ColumnNames.ParentProgramID);
			}
			
			set
			{
				base.SetSystemString(RadMenuDataSourceMetadata.ColumnNames.ParentProgramID, value);
			}
		}
		
		/// <summary>
		/// Maps to RadMenuDataSource.ProgramName
		/// </summary>
		virtual public System.String ProgramName
		{
			get
			{
				return base.GetSystemString(RadMenuDataSourceMetadata.ColumnNames.ProgramName);
			}
			
			set
			{
				base.SetSystemString(RadMenuDataSourceMetadata.ColumnNames.ProgramName, value);
			}
		}
		
		/// <summary>
		/// Maps to RadMenuDataSource.NavigateUrl
		/// </summary>
		virtual public System.String NavigateUrl
		{
			get
			{
				return base.GetSystemString(RadMenuDataSourceMetadata.ColumnNames.NavigateUrl);
			}
			
			set
			{
				base.SetSystemString(RadMenuDataSourceMetadata.ColumnNames.NavigateUrl, value);
			}
		}
		
		/// <summary>
		/// Maps to RadMenuDataSource.UserID
		/// </summary>
		virtual public System.String UserID
		{
			get
			{
				return base.GetSystemString(RadMenuDataSourceMetadata.ColumnNames.UserID);
			}
			
			set
			{
				base.SetSystemString(RadMenuDataSourceMetadata.ColumnNames.UserID, value);
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
			public esStrings(esRadMenuDataSource entity)
			{
				this.entity = entity;
			}
			
	
			public System.String ProgramID
			{
				get
				{
					System.String data = entity.ProgramID;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.ProgramID = null;
					else entity.ProgramID = Convert.ToString(value);
				}
			}
				
			public System.String ParentProgramID
			{
				get
				{
					System.String data = entity.ParentProgramID;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.ParentProgramID = null;
					else entity.ParentProgramID = Convert.ToString(value);
				}
			}
				
			public System.String ProgramName
			{
				get
				{
					System.String data = entity.ProgramName;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.ProgramName = null;
					else entity.ProgramName = Convert.ToString(value);
				}
			}
				
			public System.String NavigateUrl
			{
				get
				{
					System.String data = entity.NavigateUrl;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.NavigateUrl = null;
					else entity.NavigateUrl = Convert.ToString(value);
				}
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
			

			private esRadMenuDataSource entity;
		}
		#endregion

		#region Query Logic
		protected void InitQuery(esRadMenuDataSourceQuery query)
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
				throw new Exception("esRadMenuDataSource can only hold one record of data");
			}

			return dataFound;
		}
		#endregion
		
		[NonSerialized]
		private esStrings esstrings;
	}



	[Serializable]
	abstract public class esRadMenuDataSourceQuery : esDynamicQuery
	{
		override protected IMetadata Meta
		{
			get
			{
				return RadMenuDataSourceMetadata.Meta();
			}
		}	
		

		public esQueryItem ProgramID
		{
			get
			{
				return new esQueryItem(this, RadMenuDataSourceMetadata.ColumnNames.ProgramID, esSystemType.String);
			}
		} 
		
		public esQueryItem ParentProgramID
		{
			get
			{
				return new esQueryItem(this, RadMenuDataSourceMetadata.ColumnNames.ParentProgramID, esSystemType.String);
			}
		} 
		
		public esQueryItem ProgramName
		{
			get
			{
				return new esQueryItem(this, RadMenuDataSourceMetadata.ColumnNames.ProgramName, esSystemType.String);
			}
		} 
		
		public esQueryItem NavigateUrl
		{
			get
			{
				return new esQueryItem(this, RadMenuDataSourceMetadata.ColumnNames.NavigateUrl, esSystemType.String);
			}
		} 
		
		public esQueryItem UserID
		{
			get
			{
				return new esQueryItem(this, RadMenuDataSourceMetadata.ColumnNames.UserID, esSystemType.String);
			}
		} 
		
	}



    [System.Diagnostics.DebuggerDisplay("Count = {Count}")]
	[Serializable]
	[XmlType("RadMenuDataSourceCollection")]
	public partial class RadMenuDataSourceCollection : esRadMenuDataSourceCollection, IEnumerable<RadMenuDataSource>
	{
		public RadMenuDataSourceCollection()
		{

		}
		
		public static implicit operator List<RadMenuDataSource>(RadMenuDataSourceCollection coll)
		{
			List<RadMenuDataSource> list = new List<RadMenuDataSource>();
			
			foreach (RadMenuDataSource emp in coll)
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
				return  RadMenuDataSourceMetadata.Meta();
			}
		}
		
		
		
		override protected esDynamicQuery GetDynamicQuery()
		{
			if (this.query == null)
			{
				this.query = new RadMenuDataSourceQuery();
				this.InitQuery(query);
			}
			return this.query;
		}
		
		override protected esEntity CreateEntityForCollection(DataRow row)
		{
			return new RadMenuDataSource(row);
		}

		override protected esEntity CreateEntity()
		{
			return new RadMenuDataSource();
		}
		
		
		override public bool LoadAll()
		{
			return base.LoadAll(esSqlAccessType.DynamicSQL);
		}	
		
		#endregion


		[BrowsableAttribute( false )]
		public RadMenuDataSourceQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new RadMenuDataSourceQuery();
					base.InitQuery(this.query);
				}

				return this.query;
			}
		}

		public void QueryReset()
		{
			this.query = null;
		}

		public bool Load(RadMenuDataSourceQuery query)
		{
			this.query = query;
			base.InitQuery(this.query);
			return this.Query.Load();
		}
		
		public RadMenuDataSource AddNew()
		{
			RadMenuDataSource entity = base.AddNewEntity() as RadMenuDataSource;
			
			return entity;
		}


		#region IEnumerable<RadMenuDataSource> Members

		IEnumerator<RadMenuDataSource> IEnumerable<RadMenuDataSource>.GetEnumerator()
		{
			System.Collections.IEnumerable enumer = this as System.Collections.IEnumerable;
			System.Collections.IEnumerator iterator = enumer.GetEnumerator();

			while(iterator.MoveNext())
			{
				yield return iterator.Current as RadMenuDataSource;
			}
		}

		#endregion
		
		private RadMenuDataSourceQuery query;
	}


	/// <summary>
	/// Encapsulates the 'RadMenuDataSource' view
	/// </summary>

    [System.Diagnostics.DebuggerDisplay("RadMenuDataSource ()")]
	[Serializable]
	public partial class RadMenuDataSource : esRadMenuDataSource
	{
		public RadMenuDataSource()
		{

		}
	
		public RadMenuDataSource(DataRow row)
			: base(row)
		{

		}
		
		#region Housekeeping methods
		override protected IMetadata Meta
		{
			get
			{
				return RadMenuDataSourceMetadata.Meta();
			}
		}
		
		
		
		override protected esRadMenuDataSourceQuery GetDynamicQuery()
		{
			if (this.query == null)
			{
				this.query = new RadMenuDataSourceQuery();
				this.InitQuery(query);
			}
			return this.query;
		}
		#endregion
		



		[BrowsableAttribute( false )]
		public RadMenuDataSourceQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new RadMenuDataSourceQuery();
					base.InitQuery(this.query);
				}

				return this.query;
			}
		}

		public void QueryReset()
		{
			this.query = null;
		}
		

		public bool Load(RadMenuDataSourceQuery query)
		{
			this.query = query;
			base.InitQuery(this.query);
			return this.Query.Load();
		}
		
		private RadMenuDataSourceQuery query;
	}



    [System.Diagnostics.DebuggerDisplay("LastQuery = {es.LastQuery}")]
	[Serializable]
		
	public partial class RadMenuDataSourceQuery : esRadMenuDataSourceQuery
	{
		public RadMenuDataSourceQuery()
		{

		}		
		
		public RadMenuDataSourceQuery(string joinAlias)
		{
			this.es.JoinAlias = joinAlias;
		}	

        override protected string GetQueryName()
        {
            return "RadMenuDataSourceQuery";
        }
		
			
	}


	[Serializable]
	public partial class RadMenuDataSourceMetadata : esMetadata, IMetadata
	{
		#region Protected Constructor
		protected RadMenuDataSourceMetadata()
		{
			_columns = new esColumnMetadataCollection();
			esColumnMetadata c;

			c = new esColumnMetadata(RadMenuDataSourceMetadata.ColumnNames.ProgramID, 0, typeof(System.String), esSystemType.String);
			c.PropertyName = RadMenuDataSourceMetadata.PropertyNames.ProgramID;
			c.CharacterMaxLength = 30;
			_columns.Add(c);
				
			c = new esColumnMetadata(RadMenuDataSourceMetadata.ColumnNames.ParentProgramID, 1, typeof(System.String), esSystemType.String);
			c.PropertyName = RadMenuDataSourceMetadata.PropertyNames.ParentProgramID;
			c.CharacterMaxLength = 50;
			c.IsNullable = true;
			_columns.Add(c);
				
			c = new esColumnMetadata(RadMenuDataSourceMetadata.ColumnNames.ProgramName, 2, typeof(System.String), esSystemType.String);
			c.PropertyName = RadMenuDataSourceMetadata.PropertyNames.ProgramName;
			c.CharacterMaxLength = 100;
			_columns.Add(c);
				
			c = new esColumnMetadata(RadMenuDataSourceMetadata.ColumnNames.NavigateUrl, 3, typeof(System.String), esSystemType.String);
			c.PropertyName = RadMenuDataSourceMetadata.PropertyNames.NavigateUrl;
			c.CharacterMaxLength = 1000;
			c.IsNullable = true;
			_columns.Add(c);
				
			c = new esColumnMetadata(RadMenuDataSourceMetadata.ColumnNames.UserID, 4, typeof(System.String), esSystemType.String);
			c.PropertyName = RadMenuDataSourceMetadata.PropertyNames.UserID;
			c.CharacterMaxLength = 50;
			_columns.Add(c);
				
		}
		#endregion	
	
		static public RadMenuDataSourceMetadata Meta()
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
			 public const string ProgramID = "ProgramID";
			 public const string ParentProgramID = "ParentProgramID";
			 public const string ProgramName = "ProgramName";
			 public const string NavigateUrl = "NavigateUrl";
			 public const string UserID = "UserID";
		}
		#endregion	
		
		#region PropertyNames
		public class PropertyNames
		{ 
			 public const string ProgramID = "ProgramID";
			 public const string ParentProgramID = "ParentProgramID";
			 public const string ProgramName = "ProgramName";
			 public const string NavigateUrl = "NavigateUrl";
			 public const string UserID = "UserID";
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
			lock (typeof(RadMenuDataSourceMetadata))
			{
				if(RadMenuDataSourceMetadata.mapDelegates == null)
				{
					RadMenuDataSourceMetadata.mapDelegates = new Dictionary<string,MapToMeta>();
				}
				
				if (RadMenuDataSourceMetadata.meta == null)
				{
					RadMenuDataSourceMetadata.meta = new RadMenuDataSourceMetadata();
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
				

				meta.AddTypeMap("ProgramID", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("ParentProgramID", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("ProgramName", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("NavigateUrl", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("UserID", new esTypeMap("nvarchar", "System.String"));			
				
				
				
				meta.Source = "RadMenuDataSource";
				meta.Destination = "RadMenuDataSource";
				
				meta.spInsert = "proc_RadMenuDataSourceInsert";				
				meta.spUpdate = "proc_RadMenuDataSourceUpdate";		
				meta.spDelete = "proc_RadMenuDataSourceDelete";
				meta.spLoadAll = "proc_RadMenuDataSourceLoadAll";
				meta.spLoadByPrimaryKey = "proc_RadMenuDataSourceLoadByPrimaryKey";
				
				this._providerMetadataMaps["esDefault"] = meta;
			}
			
			return this._providerMetadataMaps["esDefault"];
		}

		#endregion

		static private RadMenuDataSourceMetadata meta;
		static protected Dictionary<string, MapToMeta> mapDelegates;
		static private int _esDefault = RegisterDelegateesDefault();
	}
}
