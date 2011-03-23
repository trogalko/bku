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
	abstract public class esKasCollection : esEntityCollection
	{
		public esKasCollection()
		{

		}

		protected override string GetCollectionName()
		{
			return "KasCollection";
		}

		#region Query Logic
		protected void InitQuery(esKasQuery query)
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
			this.InitQuery(query as esKasQuery);
		}
		#endregion
		
		virtual public Kas DetachEntity(Kas entity)
		{
			return base.DetachEntity(entity) as Kas;
		}
		
		virtual public Kas AttachEntity(Kas entity)
		{
			return base.AttachEntity(entity) as Kas;
		}
		
		virtual public void Combine(KasCollection collection)
		{
			base.Combine(collection);
		}
		
		new public Kas this[int index]
		{
			get
			{
				return base[index] as Kas;
			}
		}

		public override Type GetEntityType()
		{
			return typeof(Kas);
		}
	}



	[Serializable]
	abstract public class esKas : esEntity
	{
		/// <summary>
		/// Used internally by the entity's DynamicQuery mechanism.
		/// </summary>
		virtual protected esKasQuery GetDynamicQuery()
		{
			return null;
		}

		public esKas()
		{

		}

		public esKas(DataRow row)
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
			esKasQuery query = this.GetDynamicQuery();
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
						case "KaName": this.str.KaName = (string)value; break;							
						case "SaldoAwal": this.str.SaldoAwal = (string)value; break;							
						case "PeriodeId": this.str.PeriodeId = (string)value; break;
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
						
						case "SaldoAwal":
						
							if (value == null || value is System.Decimal)
								this.SaldoAwal = (System.Decimal?)value;
							break;
						
						case "PeriodeId":
						
							if (value == null || value is System.Int64)
								this.PeriodeId = (System.Int64?)value;
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
		/// Maps to KAS.id
		/// </summary>
		virtual public System.Int64? Id
		{
			get
			{
				return base.GetSystemInt64(KasMetadata.ColumnNames.Id);
			}
			
			set
			{
				base.SetSystemInt64(KasMetadata.ColumnNames.Id, value);
			}
		}
		
		/// <summary>
		/// Maps to KAS.KA_CODE
		/// </summary>
		virtual public System.String KaCode
		{
			get
			{
				return base.GetSystemString(KasMetadata.ColumnNames.KaCode);
			}
			
			set
			{
				base.SetSystemString(KasMetadata.ColumnNames.KaCode, value);
			}
		}
		
		/// <summary>
		/// Maps to KAS.KA_NAME
		/// </summary>
		virtual public System.String KaName
		{
			get
			{
				return base.GetSystemString(KasMetadata.ColumnNames.KaName);
			}
			
			set
			{
				base.SetSystemString(KasMetadata.ColumnNames.KaName, value);
			}
		}
		
		/// <summary>
		/// Maps to KAS.SALDO_AWAL
		/// </summary>
		virtual public System.Decimal? SaldoAwal
		{
			get
			{
				return base.GetSystemDecimal(KasMetadata.ColumnNames.SaldoAwal);
			}
			
			set
			{
				base.SetSystemDecimal(KasMetadata.ColumnNames.SaldoAwal, value);
			}
		}
		
		/// <summary>
		/// Maps to KAS.PERIODE_ID
		/// </summary>
		virtual public System.Int64? PeriodeId
		{
			get
			{
				return base.GetSystemInt64(KasMetadata.ColumnNames.PeriodeId);
			}
			
			set
			{
				if(base.SetSystemInt64(KasMetadata.ColumnNames.PeriodeId, value))
				{
					this._UpToPeriodeAnggaranByPeriodeId = null;
				}
			}
		}
		
		[CLSCompliant(false)]
		internal protected PeriodeAnggaran _UpToPeriodeAnggaranByPeriodeId;
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
			public esStrings(esKas entity)
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
				
			public System.String KaName
			{
				get
				{
					System.String data = entity.KaName;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.KaName = null;
					else entity.KaName = Convert.ToString(value);
				}
			}
				
			public System.String SaldoAwal
			{
				get
				{
					System.Decimal? data = entity.SaldoAwal;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.SaldoAwal = null;
					else entity.SaldoAwal = Convert.ToDecimal(value);
				}
			}
				
			public System.String PeriodeId
			{
				get
				{
					System.Int64? data = entity.PeriodeId;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.PeriodeId = null;
					else entity.PeriodeId = Convert.ToInt64(value);
				}
			}
			

			private esKas entity;
		}
		#endregion

		#region Query Logic
		protected void InitQuery(esKasQuery query)
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
				throw new Exception("esKas can only hold one record of data");
			}

			return dataFound;
		}
		#endregion
		
		[NonSerialized]
		private esStrings esstrings;
	}


	
	public partial class Kas : esKas
	{

				
		#region UpToPeriodeAnggaranByPeriodeId - Many To One
		/// <summary>
		/// Many to One
		/// Foreign Key Name - FK_KAS_PeriodeAnggaran
		/// </summary>

		[XmlIgnore]
		public PeriodeAnggaran UpToPeriodeAnggaranByPeriodeId
		{
			get
			{
				if(this._UpToPeriodeAnggaranByPeriodeId == null
					&& PeriodeId != null					)
				{
					this._UpToPeriodeAnggaranByPeriodeId = new PeriodeAnggaran();
					this._UpToPeriodeAnggaranByPeriodeId.es.Connection.Name = this.es.Connection.Name;
					this.SetPreSave("UpToPeriodeAnggaranByPeriodeId", this._UpToPeriodeAnggaranByPeriodeId);
					this._UpToPeriodeAnggaranByPeriodeId.Query.Where(this._UpToPeriodeAnggaranByPeriodeId.Query.Id == this.PeriodeId);
					this._UpToPeriodeAnggaranByPeriodeId.Query.Load();
				}

				return this._UpToPeriodeAnggaranByPeriodeId;
			}
			
			set
			{
				this.RemovePreSave("UpToPeriodeAnggaranByPeriodeId");
				

				if(value == null)
				{
					this.PeriodeId = null;
					this._UpToPeriodeAnggaranByPeriodeId = null;
				}
				else
				{
					this.PeriodeId = value.Id;
					this._UpToPeriodeAnggaranByPeriodeId = value;
					this.SetPreSave("UpToPeriodeAnggaranByPeriodeId", this._UpToPeriodeAnggaranByPeriodeId);
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
			if(!this.es.IsDeleted && this._UpToPeriodeAnggaranByPeriodeId != null)
			{
				this.PeriodeId = this._UpToPeriodeAnggaranByPeriodeId.Id;
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
	abstract public class esKasQuery : esDynamicQuery
	{
		override protected IMetadata Meta
		{
			get
			{
				return KasMetadata.Meta();
			}
		}	
		

		public esQueryItem Id
		{
			get
			{
				return new esQueryItem(this, KasMetadata.ColumnNames.Id, esSystemType.Int64);
			}
		} 
		
		public esQueryItem KaCode
		{
			get
			{
				return new esQueryItem(this, KasMetadata.ColumnNames.KaCode, esSystemType.String);
			}
		} 
		
		public esQueryItem KaName
		{
			get
			{
				return new esQueryItem(this, KasMetadata.ColumnNames.KaName, esSystemType.String);
			}
		} 
		
		public esQueryItem SaldoAwal
		{
			get
			{
				return new esQueryItem(this, KasMetadata.ColumnNames.SaldoAwal, esSystemType.Decimal);
			}
		} 
		
		public esQueryItem PeriodeId
		{
			get
			{
				return new esQueryItem(this, KasMetadata.ColumnNames.PeriodeId, esSystemType.Int64);
			}
		} 
		
	}



    [System.Diagnostics.DebuggerDisplay("Count = {Count}")]
	[Serializable]
	[XmlType("KasCollection")]
	public partial class KasCollection : esKasCollection, IEnumerable<Kas>
	{
		public KasCollection()
		{

		}
		
		public static implicit operator List<Kas>(KasCollection coll)
		{
			List<Kas> list = new List<Kas>();
			
			foreach (Kas emp in coll)
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
				return  KasMetadata.Meta();
			}
		}
		
		
		
		override protected esDynamicQuery GetDynamicQuery()
		{
			if (this.query == null)
			{
				this.query = new KasQuery();
				this.InitQuery(query);
			}
			return this.query;
		}
		
		override protected esEntity CreateEntityForCollection(DataRow row)
		{
			return new Kas(row);
		}

		override protected esEntity CreateEntity()
		{
			return new Kas();
		}
		
		
		#endregion


		[BrowsableAttribute( false )]
		public KasQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new KasQuery();
					base.InitQuery(this.query);
				}

				return this.query;
			}
		}

		public void QueryReset()
		{
			this.query = null;
		}

		public bool Load(KasQuery query)
		{
			this.query = query;
			base.InitQuery(this.query);
			return this.Query.Load();
		}
		
		public Kas AddNew()
		{
			Kas entity = base.AddNewEntity() as Kas;
			
			return entity;
		}

		public Kas FindByPrimaryKey(System.Int64 id)
		{
			return base.FindByPrimaryKey(id) as Kas;
		}


		#region IEnumerable<Kas> Members

		IEnumerator<Kas> IEnumerable<Kas>.GetEnumerator()
		{
			System.Collections.IEnumerable enumer = this as System.Collections.IEnumerable;
			System.Collections.IEnumerator iterator = enumer.GetEnumerator();

			while(iterator.MoveNext())
			{
				yield return iterator.Current as Kas;
			}
		}

		#endregion
		
		private KasQuery query;
	}


	/// <summary>
	/// Encapsulates the 'KAS' table
	/// </summary>

    [System.Diagnostics.DebuggerDisplay("Kas ({Id})")]
	[Serializable]
	public partial class Kas : esKas
	{
		public Kas()
		{

		}
	
		public Kas(DataRow row)
			: base(row)
		{

		}
		
		#region Housekeeping methods
		override protected IMetadata Meta
		{
			get
			{
				return KasMetadata.Meta();
			}
		}
		
		
		
		override protected esKasQuery GetDynamicQuery()
		{
			if (this.query == null)
			{
				this.query = new KasQuery();
				this.InitQuery(query);
			}
			return this.query;
		}
		#endregion
		



		[BrowsableAttribute( false )]
		public KasQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new KasQuery();
					base.InitQuery(this.query);
				}

				return this.query;
			}
		}

		public void QueryReset()
		{
			this.query = null;
		}
		

		public bool Load(KasQuery query)
		{
			this.query = query;
			base.InitQuery(this.query);
			return this.Query.Load();
		}
		
		private KasQuery query;
	}



    [System.Diagnostics.DebuggerDisplay("LastQuery = {es.LastQuery}")]
	[Serializable]
		
	public partial class KasQuery : esKasQuery
	{
		public KasQuery()
		{

		}		
		
		public KasQuery(string joinAlias)
		{
			this.es.JoinAlias = joinAlias;
		}	

        override protected string GetQueryName()
        {
            return "KasQuery";
        }
		
			
	}


	[Serializable]
	public partial class KasMetadata : esMetadata, IMetadata
	{
		#region Protected Constructor
		protected KasMetadata()
		{
			_columns = new esColumnMetadataCollection();
			esColumnMetadata c;

			c = new esColumnMetadata(KasMetadata.ColumnNames.Id, 0, typeof(System.Int64), esSystemType.Int64);
			c.PropertyName = KasMetadata.PropertyNames.Id;
			c.IsInPrimaryKey = true;
			c.IsAutoIncrement = true;
			c.NumericPrecision = 19;
			_columns.Add(c);
				
			c = new esColumnMetadata(KasMetadata.ColumnNames.KaCode, 1, typeof(System.String), esSystemType.String);
			c.PropertyName = KasMetadata.PropertyNames.KaCode;
			c.CharacterMaxLength = 15;
			_columns.Add(c);
				
			c = new esColumnMetadata(KasMetadata.ColumnNames.KaName, 2, typeof(System.String), esSystemType.String);
			c.PropertyName = KasMetadata.PropertyNames.KaName;
			c.CharacterMaxLength = 256;
			_columns.Add(c);
				
			c = new esColumnMetadata(KasMetadata.ColumnNames.SaldoAwal, 3, typeof(System.Decimal), esSystemType.Decimal);
			c.PropertyName = KasMetadata.PropertyNames.SaldoAwal;
			c.NumericPrecision = 15;
			c.NumericScale = 2;
			_columns.Add(c);
				
			c = new esColumnMetadata(KasMetadata.ColumnNames.PeriodeId, 4, typeof(System.Int64), esSystemType.Int64);
			c.PropertyName = KasMetadata.PropertyNames.PeriodeId;
			c.NumericPrecision = 19;
			_columns.Add(c);
				
		}
		#endregion	
	
		static public KasMetadata Meta()
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
			 public const string KaName = "KA_NAME";
			 public const string SaldoAwal = "SALDO_AWAL";
			 public const string PeriodeId = "PERIODE_ID";
		}
		#endregion	
		
		#region PropertyNames
		public class PropertyNames
		{ 
			 public const string Id = "Id";
			 public const string KaCode = "KaCode";
			 public const string KaName = "KaName";
			 public const string SaldoAwal = "SaldoAwal";
			 public const string PeriodeId = "PeriodeId";
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
			lock (typeof(KasMetadata))
			{
				if(KasMetadata.mapDelegates == null)
				{
					KasMetadata.mapDelegates = new Dictionary<string,MapToMeta>();
				}
				
				if (KasMetadata.meta == null)
				{
					KasMetadata.meta = new KasMetadata();
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
				meta.AddTypeMap("KaName", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("SaldoAwal", new esTypeMap("numeric", "System.Decimal"));
				meta.AddTypeMap("PeriodeId", new esTypeMap("bigint", "System.Int64"));			
				
				
				
				meta.Source = "KAS";
				meta.Destination = "KAS";
				
				meta.spInsert = "proc_KASInsert";				
				meta.spUpdate = "proc_KASUpdate";		
				meta.spDelete = "proc_KASDelete";
				meta.spLoadAll = "proc_KASLoadAll";
				meta.spLoadByPrimaryKey = "proc_KASLoadByPrimaryKey";
				
				this._providerMetadataMaps["esDefault"] = meta;
			}
			
			return this._providerMetadataMaps["esDefault"];
		}

		#endregion

		static private KasMetadata meta;
		static protected Dictionary<string, MapToMeta> mapDelegates;
		static private int _esDefault = RegisterDelegateesDefault();
	}
}
