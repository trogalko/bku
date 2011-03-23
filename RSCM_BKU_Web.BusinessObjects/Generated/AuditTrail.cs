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
	abstract public class esAuditTrailCollection : esEntityCollection
	{
		public esAuditTrailCollection()
		{

		}

		protected override string GetCollectionName()
		{
			return "AuditTrailCollection";
		}

		#region Query Logic
		protected void InitQuery(esAuditTrailQuery query)
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
			this.InitQuery(query as esAuditTrailQuery);
		}
		#endregion
		
		virtual public AuditTrail DetachEntity(AuditTrail entity)
		{
			return base.DetachEntity(entity) as AuditTrail;
		}
		
		virtual public AuditTrail AttachEntity(AuditTrail entity)
		{
			return base.AttachEntity(entity) as AuditTrail;
		}
		
		virtual public void Combine(AuditTrailCollection collection)
		{
			base.Combine(collection);
		}
		
		new public AuditTrail this[int index]
		{
			get
			{
				return base[index] as AuditTrail;
			}
		}

		public override Type GetEntityType()
		{
			return typeof(AuditTrail);
		}
	}



	[Serializable]
	abstract public class esAuditTrail : esEntity
	{
		/// <summary>
		/// Used internally by the entity's DynamicQuery mechanism.
		/// </summary>
		virtual protected esAuditTrailQuery GetDynamicQuery()
		{
			return null;
		}

		public esAuditTrail()
		{

		}

		public esAuditTrail(DataRow row)
			: base(row)
		{

		}
		
		#region LoadByPrimaryKey
		public virtual bool LoadByPrimaryKey(System.Int64 atId)
		{
			if(this.es.Connection.SqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(atId);
			else
				return LoadByPrimaryKeyStoredProcedure(atId);
		}

		public virtual bool LoadByPrimaryKey(esSqlAccessType sqlAccessType, System.Int64 atId)
		{
			if (sqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(atId);
			else
				return LoadByPrimaryKeyStoredProcedure(atId);
		}

		private bool LoadByPrimaryKeyDynamic(System.Int64 atId)
		{
			esAuditTrailQuery query = this.GetDynamicQuery();
			query.Where(query.AtId == atId);
			return query.Load();
		}

		private bool LoadByPrimaryKeyStoredProcedure(System.Int64 atId)
		{
			esParameters parms = new esParameters();
			parms.Add("AT_ID",atId);
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
						case "AtId": this.str.AtId = (string)value; break;							
						case "Aksi": this.str.Aksi = (string)value; break;							
						case "ItemAction": this.str.ItemAction = (string)value; break;							
						case "FromBe": this.str.FromBe = (string)value; break;							
						case "ToBe": this.str.ToBe = (string)value; break;							
						case "Userby": this.str.Userby = (string)value; break;							
						case "DateAction": this.str.DateAction = (string)value; break;
					}
				}
				else
				{
					switch (name)
					{	
						case "AtId":
						
							if (value == null || value is System.Int64)
								this.AtId = (System.Int64?)value;
							break;
						
						case "DateAction":
						
							if (value == null || value is System.DateTime)
								this.DateAction = (System.DateTime?)value;
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
		/// Maps to Audit_Trail.AT_ID
		/// </summary>
		virtual public System.Int64? AtId
		{
			get
			{
				return base.GetSystemInt64(AuditTrailMetadata.ColumnNames.AtId);
			}
			
			set
			{
				base.SetSystemInt64(AuditTrailMetadata.ColumnNames.AtId, value);
			}
		}
		
		/// <summary>
		/// Maps to Audit_Trail.AKSI
		/// </summary>
		virtual public System.String Aksi
		{
			get
			{
				return base.GetSystemString(AuditTrailMetadata.ColumnNames.Aksi);
			}
			
			set
			{
				base.SetSystemString(AuditTrailMetadata.ColumnNames.Aksi, value);
			}
		}
		
		/// <summary>
		/// Maps to Audit_Trail.ITEM_ACTION
		/// </summary>
		virtual public System.String ItemAction
		{
			get
			{
				return base.GetSystemString(AuditTrailMetadata.ColumnNames.ItemAction);
			}
			
			set
			{
				base.SetSystemString(AuditTrailMetadata.ColumnNames.ItemAction, value);
			}
		}
		
		/// <summary>
		/// Maps to Audit_Trail.FROM_BE
		/// </summary>
		virtual public System.String FromBe
		{
			get
			{
				return base.GetSystemString(AuditTrailMetadata.ColumnNames.FromBe);
			}
			
			set
			{
				base.SetSystemString(AuditTrailMetadata.ColumnNames.FromBe, value);
			}
		}
		
		/// <summary>
		/// Maps to Audit_Trail.TO_BE
		/// </summary>
		virtual public System.String ToBe
		{
			get
			{
				return base.GetSystemString(AuditTrailMetadata.ColumnNames.ToBe);
			}
			
			set
			{
				base.SetSystemString(AuditTrailMetadata.ColumnNames.ToBe, value);
			}
		}
		
		/// <summary>
		/// Maps to Audit_Trail.USERBY
		/// </summary>
		virtual public System.String Userby
		{
			get
			{
				return base.GetSystemString(AuditTrailMetadata.ColumnNames.Userby);
			}
			
			set
			{
				base.SetSystemString(AuditTrailMetadata.ColumnNames.Userby, value);
			}
		}
		
		/// <summary>
		/// Maps to Audit_Trail.DATE_ACTION
		/// </summary>
		virtual public System.DateTime? DateAction
		{
			get
			{
				return base.GetSystemDateTime(AuditTrailMetadata.ColumnNames.DateAction);
			}
			
			set
			{
				base.SetSystemDateTime(AuditTrailMetadata.ColumnNames.DateAction, value);
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
			public esStrings(esAuditTrail entity)
			{
				this.entity = entity;
			}
			
	
			public System.String AtId
			{
				get
				{
					System.Int64? data = entity.AtId;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.AtId = null;
					else entity.AtId = Convert.ToInt64(value);
				}
			}
				
			public System.String Aksi
			{
				get
				{
					System.String data = entity.Aksi;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.Aksi = null;
					else entity.Aksi = Convert.ToString(value);
				}
			}
				
			public System.String ItemAction
			{
				get
				{
					System.String data = entity.ItemAction;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.ItemAction = null;
					else entity.ItemAction = Convert.ToString(value);
				}
			}
				
			public System.String FromBe
			{
				get
				{
					System.String data = entity.FromBe;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.FromBe = null;
					else entity.FromBe = Convert.ToString(value);
				}
			}
				
			public System.String ToBe
			{
				get
				{
					System.String data = entity.ToBe;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.ToBe = null;
					else entity.ToBe = Convert.ToString(value);
				}
			}
				
			public System.String Userby
			{
				get
				{
					System.String data = entity.Userby;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.Userby = null;
					else entity.Userby = Convert.ToString(value);
				}
			}
				
			public System.String DateAction
			{
				get
				{
					System.DateTime? data = entity.DateAction;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.DateAction = null;
					else entity.DateAction = Convert.ToDateTime(value);
				}
			}
			

			private esAuditTrail entity;
		}
		#endregion

		#region Query Logic
		protected void InitQuery(esAuditTrailQuery query)
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
				throw new Exception("esAuditTrail can only hold one record of data");
			}

			return dataFound;
		}
		#endregion
		
		[NonSerialized]
		private esStrings esstrings;
	}


	
	public partial class AuditTrail : esAuditTrail
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
	abstract public class esAuditTrailQuery : esDynamicQuery
	{
		override protected IMetadata Meta
		{
			get
			{
				return AuditTrailMetadata.Meta();
			}
		}	
		

		public esQueryItem AtId
		{
			get
			{
				return new esQueryItem(this, AuditTrailMetadata.ColumnNames.AtId, esSystemType.Int64);
			}
		} 
		
		public esQueryItem Aksi
		{
			get
			{
				return new esQueryItem(this, AuditTrailMetadata.ColumnNames.Aksi, esSystemType.String);
			}
		} 
		
		public esQueryItem ItemAction
		{
			get
			{
				return new esQueryItem(this, AuditTrailMetadata.ColumnNames.ItemAction, esSystemType.String);
			}
		} 
		
		public esQueryItem FromBe
		{
			get
			{
				return new esQueryItem(this, AuditTrailMetadata.ColumnNames.FromBe, esSystemType.String);
			}
		} 
		
		public esQueryItem ToBe
		{
			get
			{
				return new esQueryItem(this, AuditTrailMetadata.ColumnNames.ToBe, esSystemType.String);
			}
		} 
		
		public esQueryItem Userby
		{
			get
			{
				return new esQueryItem(this, AuditTrailMetadata.ColumnNames.Userby, esSystemType.String);
			}
		} 
		
		public esQueryItem DateAction
		{
			get
			{
				return new esQueryItem(this, AuditTrailMetadata.ColumnNames.DateAction, esSystemType.DateTime);
			}
		} 
		
	}



    [System.Diagnostics.DebuggerDisplay("Count = {Count}")]
	[Serializable]
	[XmlType("AuditTrailCollection")]
	public partial class AuditTrailCollection : esAuditTrailCollection, IEnumerable<AuditTrail>
	{
		public AuditTrailCollection()
		{

		}
		
		public static implicit operator List<AuditTrail>(AuditTrailCollection coll)
		{
			List<AuditTrail> list = new List<AuditTrail>();
			
			foreach (AuditTrail emp in coll)
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
				return  AuditTrailMetadata.Meta();
			}
		}
		
		
		
		override protected esDynamicQuery GetDynamicQuery()
		{
			if (this.query == null)
			{
				this.query = new AuditTrailQuery();
				this.InitQuery(query);
			}
			return this.query;
		}
		
		override protected esEntity CreateEntityForCollection(DataRow row)
		{
			return new AuditTrail(row);
		}

		override protected esEntity CreateEntity()
		{
			return new AuditTrail();
		}
		
		
		#endregion


		[BrowsableAttribute( false )]
		public AuditTrailQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new AuditTrailQuery();
					base.InitQuery(this.query);
				}

				return this.query;
			}
		}

		public void QueryReset()
		{
			this.query = null;
		}

		public bool Load(AuditTrailQuery query)
		{
			this.query = query;
			base.InitQuery(this.query);
			return this.Query.Load();
		}
		
		public AuditTrail AddNew()
		{
			AuditTrail entity = base.AddNewEntity() as AuditTrail;
			
			return entity;
		}

		public AuditTrail FindByPrimaryKey(System.Int64 atId)
		{
			return base.FindByPrimaryKey(atId) as AuditTrail;
		}


		#region IEnumerable<AuditTrail> Members

		IEnumerator<AuditTrail> IEnumerable<AuditTrail>.GetEnumerator()
		{
			System.Collections.IEnumerable enumer = this as System.Collections.IEnumerable;
			System.Collections.IEnumerator iterator = enumer.GetEnumerator();

			while(iterator.MoveNext())
			{
				yield return iterator.Current as AuditTrail;
			}
		}

		#endregion
		
		private AuditTrailQuery query;
	}


	/// <summary>
	/// Encapsulates the 'Audit_Trail' table
	/// </summary>

    [System.Diagnostics.DebuggerDisplay("AuditTrail ({AtId})")]
	[Serializable]
	public partial class AuditTrail : esAuditTrail
	{
		public AuditTrail()
		{

		}
	
		public AuditTrail(DataRow row)
			: base(row)
		{

		}
		
		#region Housekeeping methods
		override protected IMetadata Meta
		{
			get
			{
				return AuditTrailMetadata.Meta();
			}
		}
		
		
		
		override protected esAuditTrailQuery GetDynamicQuery()
		{
			if (this.query == null)
			{
				this.query = new AuditTrailQuery();
				this.InitQuery(query);
			}
			return this.query;
		}
		#endregion
		



		[BrowsableAttribute( false )]
		public AuditTrailQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new AuditTrailQuery();
					base.InitQuery(this.query);
				}

				return this.query;
			}
		}

		public void QueryReset()
		{
			this.query = null;
		}
		

		public bool Load(AuditTrailQuery query)
		{
			this.query = query;
			base.InitQuery(this.query);
			return this.Query.Load();
		}
		
		private AuditTrailQuery query;
	}



    [System.Diagnostics.DebuggerDisplay("LastQuery = {es.LastQuery}")]
	[Serializable]
		
	public partial class AuditTrailQuery : esAuditTrailQuery
	{
		public AuditTrailQuery()
		{

		}		
		
		public AuditTrailQuery(string joinAlias)
		{
			this.es.JoinAlias = joinAlias;
		}	

        override protected string GetQueryName()
        {
            return "AuditTrailQuery";
        }
		
			
	}


	[Serializable]
	public partial class AuditTrailMetadata : esMetadata, IMetadata
	{
		#region Protected Constructor
		protected AuditTrailMetadata()
		{
			_columns = new esColumnMetadataCollection();
			esColumnMetadata c;

			c = new esColumnMetadata(AuditTrailMetadata.ColumnNames.AtId, 0, typeof(System.Int64), esSystemType.Int64);
			c.PropertyName = AuditTrailMetadata.PropertyNames.AtId;
			c.IsInPrimaryKey = true;
			c.IsAutoIncrement = true;
			c.NumericPrecision = 19;
			_columns.Add(c);
				
			c = new esColumnMetadata(AuditTrailMetadata.ColumnNames.Aksi, 1, typeof(System.String), esSystemType.String);
			c.PropertyName = AuditTrailMetadata.PropertyNames.Aksi;
			c.CharacterMaxLength = 50;
			c.IsNullable = true;
			_columns.Add(c);
				
			c = new esColumnMetadata(AuditTrailMetadata.ColumnNames.ItemAction, 2, typeof(System.String), esSystemType.String);
			c.PropertyName = AuditTrailMetadata.PropertyNames.ItemAction;
			c.CharacterMaxLength = 200;
			c.IsNullable = true;
			_columns.Add(c);
				
			c = new esColumnMetadata(AuditTrailMetadata.ColumnNames.FromBe, 3, typeof(System.String), esSystemType.String);
			c.PropertyName = AuditTrailMetadata.PropertyNames.FromBe;
			c.CharacterMaxLength = 100;
			c.IsNullable = true;
			_columns.Add(c);
				
			c = new esColumnMetadata(AuditTrailMetadata.ColumnNames.ToBe, 4, typeof(System.String), esSystemType.String);
			c.PropertyName = AuditTrailMetadata.PropertyNames.ToBe;
			c.CharacterMaxLength = 100;
			c.IsNullable = true;
			_columns.Add(c);
				
			c = new esColumnMetadata(AuditTrailMetadata.ColumnNames.Userby, 5, typeof(System.String), esSystemType.String);
			c.PropertyName = AuditTrailMetadata.PropertyNames.Userby;
			c.CharacterMaxLength = 100;
			c.IsNullable = true;
			_columns.Add(c);
				
			c = new esColumnMetadata(AuditTrailMetadata.ColumnNames.DateAction, 6, typeof(System.DateTime), esSystemType.DateTime);
			c.PropertyName = AuditTrailMetadata.PropertyNames.DateAction;
			c.IsNullable = true;
			_columns.Add(c);
				
		}
		#endregion	
	
		static public AuditTrailMetadata Meta()
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
			 public const string AtId = "AT_ID";
			 public const string Aksi = "AKSI";
			 public const string ItemAction = "ITEM_ACTION";
			 public const string FromBe = "FROM_BE";
			 public const string ToBe = "TO_BE";
			 public const string Userby = "USERBY";
			 public const string DateAction = "DATE_ACTION";
		}
		#endregion	
		
		#region PropertyNames
		public class PropertyNames
		{ 
			 public const string AtId = "AtId";
			 public const string Aksi = "Aksi";
			 public const string ItemAction = "ItemAction";
			 public const string FromBe = "FromBe";
			 public const string ToBe = "ToBe";
			 public const string Userby = "Userby";
			 public const string DateAction = "DateAction";
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
			lock (typeof(AuditTrailMetadata))
			{
				if(AuditTrailMetadata.mapDelegates == null)
				{
					AuditTrailMetadata.mapDelegates = new Dictionary<string,MapToMeta>();
				}
				
				if (AuditTrailMetadata.meta == null)
				{
					AuditTrailMetadata.meta = new AuditTrailMetadata();
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
				

				meta.AddTypeMap("AtId", new esTypeMap("bigint", "System.Int64"));
				meta.AddTypeMap("Aksi", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("ItemAction", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("FromBe", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("ToBe", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("Userby", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("DateAction", new esTypeMap("datetime", "System.DateTime"));			
				
				
				
				meta.Source = "Audit_Trail";
				meta.Destination = "Audit_Trail";
				
				meta.spInsert = "proc_Audit_TrailInsert";				
				meta.spUpdate = "proc_Audit_TrailUpdate";		
				meta.spDelete = "proc_Audit_TrailDelete";
				meta.spLoadAll = "proc_Audit_TrailLoadAll";
				meta.spLoadByPrimaryKey = "proc_Audit_TrailLoadByPrimaryKey";
				
				this._providerMetadataMaps["esDefault"] = meta;
			}
			
			return this._providerMetadataMaps["esDefault"];
		}

		#endregion

		static private AuditTrailMetadata meta;
		static protected Dictionary<string, MapToMeta> mapDelegates;
		static private int _esDefault = RegisterDelegateesDefault();
	}
}
