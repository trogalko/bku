/*
===============================================================================
                    EntitySpaces 2009 by EntitySpaces, LLC
             Persistence Layer and Business Objects for Microsoft .NET
             EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
                          http://www.entityspaces.net
===============================================================================
EntitySpaces Version : 2009.2.1214.0
EntitySpaces Driver  : SQL
Date Generated       : 15/03/2011 3:44:21
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
	abstract public class esSaldoAwalCollection : esEntityCollection
	{
		public esSaldoAwalCollection()
		{

		}

		protected override string GetCollectionName()
		{
			return "SaldoAwalCollection";
		}

		#region Query Logic
		protected void InitQuery(esSaldoAwalQuery query)
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
			this.InitQuery(query as esSaldoAwalQuery);
		}
		#endregion
		
		virtual public SaldoAwal DetachEntity(SaldoAwal entity)
		{
			return base.DetachEntity(entity) as SaldoAwal;
		}
		
		virtual public SaldoAwal AttachEntity(SaldoAwal entity)
		{
			return base.AttachEntity(entity) as SaldoAwal;
		}
		
		virtual public void Combine(SaldoAwalCollection collection)
		{
			base.Combine(collection);
		}
		
		new public SaldoAwal this[int index]
		{
			get
			{
				return base[index] as SaldoAwal;
			}
		}

		public override Type GetEntityType()
		{
			return typeof(SaldoAwal);
		}
	}



	[Serializable]
	abstract public class esSaldoAwal : esEntity
	{
		/// <summary>
		/// Used internally by the entity's DynamicQuery mechanism.
		/// </summary>
		virtual protected esSaldoAwalQuery GetDynamicQuery()
		{
			return null;
		}

		public esSaldoAwal()
		{

		}

		public esSaldoAwal(DataRow row)
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
						case "SaldoAwal": this.str.SaldoAwal = (string)value; break;							
						case "IsClosed": this.str.IsClosed = (string)value; break;
					}
				}
				else
				{
					switch (name)
					{	
						case "SaldoAwal":
						
							if (value == null || value is System.Decimal)
								this.SaldoAwal = (System.Decimal?)value;
							break;
						
						case "IsClosed":
						
							if (value == null || value is System.Boolean)
								this.IsClosed = (System.Boolean?)value;
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
		/// Maps to SaldoAwal.SALDO_AWAL
		/// </summary>
		virtual public System.Decimal? SaldoAwal
		{
			get
			{
				return base.GetSystemDecimal(SaldoAwalMetadata.ColumnNames.SaldoAwal);
			}
			
			set
			{
				base.SetSystemDecimal(SaldoAwalMetadata.ColumnNames.SaldoAwal, value);
			}
		}
		
		/// <summary>
		/// Maps to SaldoAwal.Is_Closed
		/// </summary>
		virtual public System.Boolean? IsClosed
		{
			get
			{
				return base.GetSystemBoolean(SaldoAwalMetadata.ColumnNames.IsClosed);
			}
			
			set
			{
				base.SetSystemBoolean(SaldoAwalMetadata.ColumnNames.IsClosed, value);
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
			public esStrings(esSaldoAwal entity)
			{
				this.entity = entity;
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
				
			public System.String IsClosed
			{
				get
				{
					System.Boolean? data = entity.IsClosed;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.IsClosed = null;
					else entity.IsClosed = Convert.ToBoolean(value);
				}
			}
			

			private esSaldoAwal entity;
		}
		#endregion

		#region Query Logic
		protected void InitQuery(esSaldoAwalQuery query)
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
				throw new Exception("esSaldoAwal can only hold one record of data");
			}

			return dataFound;
		}
		#endregion
		
		[NonSerialized]
		private esStrings esstrings;
	}



	[Serializable]
	abstract public class esSaldoAwalQuery : esDynamicQuery
	{
		override protected IMetadata Meta
		{
			get
			{
				return SaldoAwalMetadata.Meta();
			}
		}	
		

		public esQueryItem SaldoAwal
		{
			get
			{
				return new esQueryItem(this, SaldoAwalMetadata.ColumnNames.SaldoAwal, esSystemType.Decimal);
			}
		} 
		
		public esQueryItem IsClosed
		{
			get
			{
				return new esQueryItem(this, SaldoAwalMetadata.ColumnNames.IsClosed, esSystemType.Boolean);
			}
		} 
		
	}



    [System.Diagnostics.DebuggerDisplay("Count = {Count}")]
	[Serializable]
	[XmlType("SaldoAwalCollection")]
	public partial class SaldoAwalCollection : esSaldoAwalCollection, IEnumerable<SaldoAwal>
	{
		public SaldoAwalCollection()
		{

		}
		
		public static implicit operator List<SaldoAwal>(SaldoAwalCollection coll)
		{
			List<SaldoAwal> list = new List<SaldoAwal>();
			
			foreach (SaldoAwal emp in coll)
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
				return  SaldoAwalMetadata.Meta();
			}
		}
		
		
		
		override protected esDynamicQuery GetDynamicQuery()
		{
			if (this.query == null)
			{
				this.query = new SaldoAwalQuery();
				this.InitQuery(query);
			}
			return this.query;
		}
		
		override protected esEntity CreateEntityForCollection(DataRow row)
		{
			return new SaldoAwal(row);
		}

		override protected esEntity CreateEntity()
		{
			return new SaldoAwal();
		}
		
		
		override public bool LoadAll()
		{
			return base.LoadAll(esSqlAccessType.DynamicSQL);
		}	
		
		#endregion


		[BrowsableAttribute( false )]
		public SaldoAwalQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new SaldoAwalQuery();
					base.InitQuery(this.query);
				}

				return this.query;
			}
		}

		public void QueryReset()
		{
			this.query = null;
		}

		public bool Load(SaldoAwalQuery query)
		{
			this.query = query;
			base.InitQuery(this.query);
			return this.Query.Load();
		}
		
		public SaldoAwal AddNew()
		{
			SaldoAwal entity = base.AddNewEntity() as SaldoAwal;
			
			return entity;
		}


		#region IEnumerable<SaldoAwal> Members

		IEnumerator<SaldoAwal> IEnumerable<SaldoAwal>.GetEnumerator()
		{
			System.Collections.IEnumerable enumer = this as System.Collections.IEnumerable;
			System.Collections.IEnumerator iterator = enumer.GetEnumerator();

			while(iterator.MoveNext())
			{
				yield return iterator.Current as SaldoAwal;
			}
		}

		#endregion
		
		private SaldoAwalQuery query;
	}


	/// <summary>
	/// Encapsulates the 'SaldoAwal' view
	/// </summary>

    [System.Diagnostics.DebuggerDisplay("SaldoAwal ()")]
	[Serializable]
	public partial class SaldoAwal : esSaldoAwal
	{
		public SaldoAwal()
		{

		}
	
		public SaldoAwal(DataRow row)
			: base(row)
		{

		}
		
		#region Housekeeping methods
		override protected IMetadata Meta
		{
			get
			{
				return SaldoAwalMetadata.Meta();
			}
		}
		
		
		
		override protected esSaldoAwalQuery GetDynamicQuery()
		{
			if (this.query == null)
			{
				this.query = new SaldoAwalQuery();
				this.InitQuery(query);
			}
			return this.query;
		}
		#endregion
		



		[BrowsableAttribute( false )]
		public SaldoAwalQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new SaldoAwalQuery();
					base.InitQuery(this.query);
				}

				return this.query;
			}
		}

		public void QueryReset()
		{
			this.query = null;
		}
		

		public bool Load(SaldoAwalQuery query)
		{
			this.query = query;
			base.InitQuery(this.query);
			return this.Query.Load();
		}
		
		private SaldoAwalQuery query;
	}



    [System.Diagnostics.DebuggerDisplay("LastQuery = {es.LastQuery}")]
	[Serializable]
		
	public partial class SaldoAwalQuery : esSaldoAwalQuery
	{
		public SaldoAwalQuery()
		{

		}		
		
		public SaldoAwalQuery(string joinAlias)
		{
			this.es.JoinAlias = joinAlias;
		}	

        override protected string GetQueryName()
        {
            return "SaldoAwalQuery";
        }
		
			
	}


	[Serializable]
	public partial class SaldoAwalMetadata : esMetadata, IMetadata
	{
		#region Protected Constructor
		protected SaldoAwalMetadata()
		{
			_columns = new esColumnMetadataCollection();
			esColumnMetadata c;

			c = new esColumnMetadata(SaldoAwalMetadata.ColumnNames.SaldoAwal, 0, typeof(System.Decimal), esSystemType.Decimal);
			c.PropertyName = SaldoAwalMetadata.PropertyNames.SaldoAwal;
			c.NumericPrecision = 38;
			c.NumericScale = 2;
			c.IsNullable = true;
			_columns.Add(c);
				
			c = new esColumnMetadata(SaldoAwalMetadata.ColumnNames.IsClosed, 1, typeof(System.Boolean), esSystemType.Boolean);
			c.PropertyName = SaldoAwalMetadata.PropertyNames.IsClosed;
			_columns.Add(c);
				
		}
		#endregion	
	
		static public SaldoAwalMetadata Meta()
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
			 public const string SaldoAwal = "SALDO_AWAL";
			 public const string IsClosed = "Is_Closed";
		}
		#endregion	
		
		#region PropertyNames
		public class PropertyNames
		{ 
			 public const string SaldoAwal = "SaldoAwal";
			 public const string IsClosed = "IsClosed";
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
			lock (typeof(SaldoAwalMetadata))
			{
				if(SaldoAwalMetadata.mapDelegates == null)
				{
					SaldoAwalMetadata.mapDelegates = new Dictionary<string,MapToMeta>();
				}
				
				if (SaldoAwalMetadata.meta == null)
				{
					SaldoAwalMetadata.meta = new SaldoAwalMetadata();
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
				

				meta.AddTypeMap("SaldoAwal", new esTypeMap("numeric", "System.Decimal"));
				meta.AddTypeMap("IsClosed", new esTypeMap("bit", "System.Boolean"));			
				
				
				
				meta.Source = "SaldoAwal";
				meta.Destination = "SaldoAwal";
				
				meta.spInsert = "proc_SaldoAwalInsert";				
				meta.spUpdate = "proc_SaldoAwalUpdate";		
				meta.spDelete = "proc_SaldoAwalDelete";
				meta.spLoadAll = "proc_SaldoAwalLoadAll";
				meta.spLoadByPrimaryKey = "proc_SaldoAwalLoadByPrimaryKey";
				
				this._providerMetadataMaps["esDefault"] = meta;
			}
			
			return this._providerMetadataMaps["esDefault"];
		}

		#endregion

		static private SaldoAwalMetadata meta;
		static protected Dictionary<string, MapToMeta> mapDelegates;
		static private int _esDefault = RegisterDelegateesDefault();
	}
}
