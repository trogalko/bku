/*
===============================================================================
                    EntitySpaces 2009 by EntitySpaces, LLC
             Persistence Layer and Business Objects for Microsoft .NET
             EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
                          http://www.entityspaces.net
===============================================================================
EntitySpaces Version : 2009.2.1214.0
EntitySpaces Driver  : SQL
Date Generated       : 10/03/2011 10:05:36
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
	abstract public class esRabCollection : esEntityCollection
	{
		public esRabCollection()
		{

		}

		protected override string GetCollectionName()
		{
			return "RabCollection";
		}

		#region Query Logic
		protected void InitQuery(esRabQuery query)
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
			this.InitQuery(query as esRabQuery);
		}
		#endregion
		
		virtual public Rab DetachEntity(Rab entity)
		{
			return base.DetachEntity(entity) as Rab;
		}
		
		virtual public Rab AttachEntity(Rab entity)
		{
			return base.AttachEntity(entity) as Rab;
		}
		
		virtual public void Combine(RabCollection collection)
		{
			base.Combine(collection);
		}
		
		new public Rab this[int index]
		{
			get
			{
				return base[index] as Rab;
			}
		}

		public override Type GetEntityType()
		{
			return typeof(Rab);
		}
	}



	[Serializable]
	abstract public class esRab : esEntity
	{
		/// <summary>
		/// Used internally by the entity's DynamicQuery mechanism.
		/// </summary>
		virtual protected esRabQuery GetDynamicQuery()
		{
			return null;
		}

		public esRab()
		{

		}

		public esRab(DataRow row)
			: base(row)
		{

		}
		
		#region LoadByPrimaryKey
		public virtual bool LoadByPrimaryKey(System.Int64 id)
		{
			if(this.es.Connection.SqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(id);
			else
				return LoadByPrimaryKeyStoredProcedure(id);
		}

		public virtual bool LoadByPrimaryKey(esSqlAccessType sqlAccessType, System.Int64 id)
		{
			if (sqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(id);
			else
				return LoadByPrimaryKeyStoredProcedure(id);
		}

		private bool LoadByPrimaryKeyDynamic(System.Int64 id)
		{
			esRabQuery query = this.GetDynamicQuery();
			query.Where(query.Id == id);
			return query.Load();
		}

		private bool LoadByPrimaryKeyStoredProcedure(System.Int64 id)
		{
			esParameters parms = new esParameters();
			parms.Add("id",id);
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
						case "Id": this.str.Id = (string)value; break;							
						case "KaCode": this.str.KaCode = (string)value; break;							
						case "PeriodId": this.str.PeriodId = (string)value; break;							
						case "Rab": this.str.Rab = (string)value; break;
					}
				}
				else
				{
					switch (name)
					{	
						case "Id":
						
							if (value == null || value is System.Int64)
								this.Id = (System.Int64?)value;
							break;
						
						case "PeriodId":
						
							if (value == null || value is System.Int64)
								this.PeriodId = (System.Int64?)value;
							break;
						
						case "Rab":
						
							if (value == null || value is System.Decimal)
								this.Rab = (System.Decimal?)value;
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
		/// Maps to RAB.id
		/// </summary>
		virtual public System.Int64? Id
		{
			get
			{
				return base.GetSystemInt64(RabMetadata.ColumnNames.Id);
			}
			
			set
			{
				base.SetSystemInt64(RabMetadata.ColumnNames.Id, value);
			}
		}
		
		/// <summary>
		/// Maps to RAB.KA_CODE
		/// </summary>
		virtual public System.String KaCode
		{
			get
			{
				return base.GetSystemString(RabMetadata.ColumnNames.KaCode);
			}
			
			set
			{
				base.SetSystemString(RabMetadata.ColumnNames.KaCode, value);
			}
		}
		
		/// <summary>
		/// Maps to RAB.PERIOD_ID
		/// </summary>
		virtual public System.Int64? PeriodId
		{
			get
			{
				return base.GetSystemInt64(RabMetadata.ColumnNames.PeriodId);
			}
			
			set
			{
				if(base.SetSystemInt64(RabMetadata.ColumnNames.PeriodId, value))
				{
					this._UpToPeriodeAnggaranByPeriodId = null;
				}
			}
		}
		
		/// <summary>
		/// Maps to RAB.RAB
		/// </summary>
		virtual public System.Decimal? Rab
		{
			get
			{
				return base.GetSystemDecimal(RabMetadata.ColumnNames.Rab);
			}
			
			set
			{
				base.SetSystemDecimal(RabMetadata.ColumnNames.Rab, value);
			}
		}
		
		[CLSCompliant(false)]
		internal protected PeriodeAnggaran _UpToPeriodeAnggaranByPeriodId;
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
			public esStrings(esRab entity)
			{
				this.entity = entity;
			}
			
	
			public System.String Id
			{
				get
				{
					System.Int64? data = entity.Id;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.Id = null;
					else entity.Id = Convert.ToInt64(value);
				}
			}
				
			public System.String KaCode
			{
				get
				{
					System.String data = entity.KaCode;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.KaCode = null;
					else entity.KaCode = Convert.ToString(value);
				}
			}
				
			public System.String PeriodId
			{
				get
				{
					System.Int64? data = entity.PeriodId;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.PeriodId = null;
					else entity.PeriodId = Convert.ToInt64(value);
				}
			}
				
			public System.String Rab
			{
				get
				{
					System.Decimal? data = entity.Rab;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.Rab = null;
					else entity.Rab = Convert.ToDecimal(value);
				}
			}
			

			private esRab entity;
		}
		#endregion

		#region Query Logic
		protected void InitQuery(esRabQuery query)
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
				throw new Exception("esRab can only hold one record of data");
			}

			return dataFound;
		}
		#endregion
		
		[NonSerialized]
		private esStrings esstrings;
	}


	
	public partial class Rab : esRab
	{

				
		#region UpToPeriodeAnggaranByPeriodId - Many To One
		/// <summary>
		/// Many to One
		/// Foreign Key Name - FK_RAB_PeriodeAnggaran
		/// </summary>

		[XmlIgnore]
		public PeriodeAnggaran UpToPeriodeAnggaranByPeriodId
		{
			get
			{
				if(this._UpToPeriodeAnggaranByPeriodId == null
					&& PeriodId != null					)
				{
					this._UpToPeriodeAnggaranByPeriodId = new PeriodeAnggaran();
					this._UpToPeriodeAnggaranByPeriodId.es.Connection.Name = this.es.Connection.Name;
					this.SetPreSave("UpToPeriodeAnggaranByPeriodId", this._UpToPeriodeAnggaranByPeriodId);
					this._UpToPeriodeAnggaranByPeriodId.Query.Where(this._UpToPeriodeAnggaranByPeriodId.Query.Id == this.PeriodId);
					this._UpToPeriodeAnggaranByPeriodId.Query.Load();
				}

				return this._UpToPeriodeAnggaranByPeriodId;
			}
			
			set
			{
				this.RemovePreSave("UpToPeriodeAnggaranByPeriodId");
				

				if(value == null)
				{
					this.PeriodId = null;
					this._UpToPeriodeAnggaranByPeriodId = null;
				}
				else
				{
					this.PeriodId = value.Id;
					this._UpToPeriodeAnggaranByPeriodId = value;
					this.SetPreSave("UpToPeriodeAnggaranByPeriodId", this._UpToPeriodeAnggaranByPeriodId);
				}
				
			}
		}
		#endregion
		

		
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
			if(!this.es.IsDeleted && this._UpToPeriodeAnggaranByPeriodId != null)
			{
				this.PeriodId = this._UpToPeriodeAnggaranByPeriodId.Id;
			}
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
	abstract public class esRabQuery : esDynamicQuery
	{
		override protected IMetadata Meta
		{
			get
			{
				return RabMetadata.Meta();
			}
		}	
		

		public esQueryItem Id
		{
			get
			{
				return new esQueryItem(this, RabMetadata.ColumnNames.Id, esSystemType.Int64);
			}
		} 
		
		public esQueryItem KaCode
		{
			get
			{
				return new esQueryItem(this, RabMetadata.ColumnNames.KaCode, esSystemType.String);
			}
		} 
		
		public esQueryItem PeriodId
		{
			get
			{
				return new esQueryItem(this, RabMetadata.ColumnNames.PeriodId, esSystemType.Int64);
			}
		} 
		
		public esQueryItem Rab
		{
			get
			{
				return new esQueryItem(this, RabMetadata.ColumnNames.Rab, esSystemType.Decimal);
			}
		} 
		
	}



    [System.Diagnostics.DebuggerDisplay("Count = {Count}")]
	[Serializable]
	[XmlType("RabCollection")]
	public partial class RabCollection : esRabCollection, IEnumerable<Rab>
	{
		public RabCollection()
		{

		}
		
		public static implicit operator List<Rab>(RabCollection coll)
		{
			List<Rab> list = new List<Rab>();
			
			foreach (Rab emp in coll)
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
				return  RabMetadata.Meta();
			}
		}
		
		
		
		override protected esDynamicQuery GetDynamicQuery()
		{
			if (this.query == null)
			{
				this.query = new RabQuery();
				this.InitQuery(query);
			}
			return this.query;
		}
		
		override protected esEntity CreateEntityForCollection(DataRow row)
		{
			return new Rab(row);
		}

		override protected esEntity CreateEntity()
		{
			return new Rab();
		}
		
		
		#endregion


		[BrowsableAttribute( false )]
		public RabQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new RabQuery();
					base.InitQuery(this.query);
				}

				return this.query;
			}
		}

		public void QueryReset()
		{
			this.query = null;
		}

		public bool Load(RabQuery query)
		{
			this.query = query;
			base.InitQuery(this.query);
			return this.Query.Load();
		}
		
		public Rab AddNew()
		{
			Rab entity = base.AddNewEntity() as Rab;
			
			return entity;
		}

		public Rab FindByPrimaryKey(System.Int64 id)
		{
			return base.FindByPrimaryKey(id) as Rab;
		}


		#region IEnumerable<Rab> Members

		IEnumerator<Rab> IEnumerable<Rab>.GetEnumerator()
		{
			System.Collections.IEnumerable enumer = this as System.Collections.IEnumerable;
			System.Collections.IEnumerator iterator = enumer.GetEnumerator();

			while(iterator.MoveNext())
			{
				yield return iterator.Current as Rab;
			}
		}

		#endregion
		
		private RabQuery query;
	}


	/// <summary>
	/// Encapsulates the 'RAB' table
	/// </summary>

    [System.Diagnostics.DebuggerDisplay("Rab ({Id})")]
	[Serializable]
	public partial class Rab : esRab
	{
		public Rab()
		{

		}
	
		public Rab(DataRow row)
			: base(row)
		{

		}
		
		#region Housekeeping methods
		override protected IMetadata Meta
		{
			get
			{
				return RabMetadata.Meta();
			}
		}
		
		
		
		override protected esRabQuery GetDynamicQuery()
		{
			if (this.query == null)
			{
				this.query = new RabQuery();
				this.InitQuery(query);
			}
			return this.query;
		}
		#endregion
		



		[BrowsableAttribute( false )]
		public RabQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new RabQuery();
					base.InitQuery(this.query);
				}

				return this.query;
			}
		}

		public void QueryReset()
		{
			this.query = null;
		}
		

		public bool Load(RabQuery query)
		{
			this.query = query;
			base.InitQuery(this.query);
			return this.Query.Load();
		}
		
		private RabQuery query;
	}



    [System.Diagnostics.DebuggerDisplay("LastQuery = {es.LastQuery}")]
	[Serializable]
		
	public partial class RabQuery : esRabQuery
	{
		public RabQuery()
		{

		}		
		
		public RabQuery(string joinAlias)
		{
			this.es.JoinAlias = joinAlias;
		}	

        override protected string GetQueryName()
        {
            return "RabQuery";
        }
		
			
	}


	[Serializable]
	public partial class RabMetadata : esMetadata, IMetadata
	{
		#region Protected Constructor
		protected RabMetadata()
		{
			_columns = new esColumnMetadataCollection();
			esColumnMetadata c;

			c = new esColumnMetadata(RabMetadata.ColumnNames.Id, 0, typeof(System.Int64), esSystemType.Int64);
			c.PropertyName = RabMetadata.PropertyNames.Id;
			c.IsInPrimaryKey = true;
			c.IsAutoIncrement = true;
			c.NumericPrecision = 19;
			_columns.Add(c);
				
			c = new esColumnMetadata(RabMetadata.ColumnNames.KaCode, 1, typeof(System.String), esSystemType.String);
			c.PropertyName = RabMetadata.PropertyNames.KaCode;
			c.CharacterMaxLength = 15;
			_columns.Add(c);
				
			c = new esColumnMetadata(RabMetadata.ColumnNames.PeriodId, 2, typeof(System.Int64), esSystemType.Int64);
			c.PropertyName = RabMetadata.PropertyNames.PeriodId;
			c.NumericPrecision = 19;
			_columns.Add(c);
				
			c = new esColumnMetadata(RabMetadata.ColumnNames.Rab, 3, typeof(System.Decimal), esSystemType.Decimal);
			c.PropertyName = RabMetadata.PropertyNames.Rab;
			c.NumericPrecision = 15;
			c.NumericScale = 2;
			_columns.Add(c);
				
		}
		#endregion	
	
		static public RabMetadata Meta()
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
			 public const string Id = "id";
			 public const string KaCode = "KA_CODE";
			 public const string PeriodId = "PERIOD_ID";
			 public const string Rab = "RAB";
		}
		#endregion	
		
		#region PropertyNames
		public class PropertyNames
		{ 
			 public const string Id = "Id";
			 public const string KaCode = "KaCode";
			 public const string PeriodId = "PeriodId";
			 public const string Rab = "Rab";
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
			lock (typeof(RabMetadata))
			{
				if(RabMetadata.mapDelegates == null)
				{
					RabMetadata.mapDelegates = new Dictionary<string,MapToMeta>();
				}
				
				if (RabMetadata.meta == null)
				{
					RabMetadata.meta = new RabMetadata();
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
				

				meta.AddTypeMap("Id", new esTypeMap("bigint", "System.Int64"));
				meta.AddTypeMap("KaCode", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("PeriodId", new esTypeMap("bigint", "System.Int64"));
				meta.AddTypeMap("Rab", new esTypeMap("numeric", "System.Decimal"));			
				
				
				
				meta.Source = "RAB";
				meta.Destination = "RAB";
				
				meta.spInsert = "proc_RABInsert";				
				meta.spUpdate = "proc_RABUpdate";		
				meta.spDelete = "proc_RABDelete";
				meta.spLoadAll = "proc_RABLoadAll";
				meta.spLoadByPrimaryKey = "proc_RABLoadByPrimaryKey";
				
				this._providerMetadataMaps["esDefault"] = meta;
			}
			
			return this._providerMetadataMaps["esDefault"];
		}

		#endregion

		static private RabMetadata meta;
		static protected Dictionary<string, MapToMeta> mapDelegates;
		static private int _esDefault = RegisterDelegateesDefault();
	}
}
