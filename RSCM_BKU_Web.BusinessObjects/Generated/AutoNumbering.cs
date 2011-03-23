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
	abstract public class esAutoNumberingCollection : esEntityCollection
	{
		public esAutoNumberingCollection()
		{

		}

		protected override string GetCollectionName()
		{
			return "AutoNumberingCollection";
		}

		#region Query Logic
		protected void InitQuery(esAutoNumberingQuery query)
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
			this.InitQuery(query as esAutoNumberingQuery);
		}
		#endregion
		
		virtual public AutoNumbering DetachEntity(AutoNumbering entity)
		{
			return base.DetachEntity(entity) as AutoNumbering;
		}
		
		virtual public AutoNumbering AttachEntity(AutoNumbering entity)
		{
			return base.AttachEntity(entity) as AutoNumbering;
		}
		
		virtual public void Combine(AutoNumberingCollection collection)
		{
			base.Combine(collection);
		}
		
		new public AutoNumbering this[int index]
		{
			get
			{
				return base[index] as AutoNumbering;
			}
		}

		public override Type GetEntityType()
		{
			return typeof(AutoNumbering);
		}
	}



	[Serializable]
	abstract public class esAutoNumbering : esEntity
	{
		/// <summary>
		/// Used internally by the entity's DynamicQuery mechanism.
		/// </summary>
		virtual protected esAutoNumberingQuery GetDynamicQuery()
		{
			return null;
		}

		public esAutoNumbering()
		{

		}

		public esAutoNumbering(DataRow row)
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
			esAutoNumberingQuery query = this.GetDynamicQuery();
			query.Where(query.Id == id);
			return query.Load();
		}

		private bool LoadByPrimaryKeyStoredProcedure(System.Int64 id)
		{
			esParameters parms = new esParameters();
			parms.Add("ID",id);
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
						case "KaYear": this.str.KaYear = (string)value; break;							
						case "KaMonth": this.str.KaMonth = (string)value; break;							
						case "LastNumber": this.str.LastNumber = (string)value; break;							
						case "Prefix": this.str.Prefix = (string)value; break;							
						case "PrefixNumber": this.str.PrefixNumber = (string)value; break;
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
						
						case "LastNumber":
						
							if (value == null || value is System.Int32)
								this.LastNumber = (System.Int32?)value;
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
		/// Maps to AUTO_NUMBERING.ID
		/// </summary>
		virtual public System.Int64? Id
		{
			get
			{
				return base.GetSystemInt64(AutoNumberingMetadata.ColumnNames.Id);
			}
			
			set
			{
				base.SetSystemInt64(AutoNumberingMetadata.ColumnNames.Id, value);
			}
		}
		
		/// <summary>
		/// Maps to AUTO_NUMBERING.KA_CODE
		/// </summary>
		virtual public System.String KaCode
		{
			get
			{
				return base.GetSystemString(AutoNumberingMetadata.ColumnNames.KaCode);
			}
			
			set
			{
				base.SetSystemString(AutoNumberingMetadata.ColumnNames.KaCode, value);
			}
		}
		
		/// <summary>
		/// Maps to AUTO_NUMBERING.KA_YEAR
		/// </summary>
		virtual public System.String KaYear
		{
			get
			{
				return base.GetSystemString(AutoNumberingMetadata.ColumnNames.KaYear);
			}
			
			set
			{
				base.SetSystemString(AutoNumberingMetadata.ColumnNames.KaYear, value);
			}
		}
		
		/// <summary>
		/// Maps to AUTO_NUMBERING.KA_MONTH
		/// </summary>
		virtual public System.String KaMonth
		{
			get
			{
				return base.GetSystemString(AutoNumberingMetadata.ColumnNames.KaMonth);
			}
			
			set
			{
				base.SetSystemString(AutoNumberingMetadata.ColumnNames.KaMonth, value);
			}
		}
		
		/// <summary>
		/// Maps to AUTO_NUMBERING.LAST_NUMBER
		/// </summary>
		virtual public System.Int32? LastNumber
		{
			get
			{
				return base.GetSystemInt32(AutoNumberingMetadata.ColumnNames.LastNumber);
			}
			
			set
			{
				base.SetSystemInt32(AutoNumberingMetadata.ColumnNames.LastNumber, value);
			}
		}
		
		/// <summary>
		/// Maps to AUTO_NUMBERING.PREFIX
		/// </summary>
		virtual public System.String Prefix
		{
			get
			{
				return base.GetSystemString(AutoNumberingMetadata.ColumnNames.Prefix);
			}
			
			set
			{
				base.SetSystemString(AutoNumberingMetadata.ColumnNames.Prefix, value);
			}
		}
		
		/// <summary>
		/// Maps to AUTO_NUMBERING.PREFIX_NUMBER
		/// </summary>
		virtual public System.String PrefixNumber
		{
			get
			{
				return base.GetSystemString(AutoNumberingMetadata.ColumnNames.PrefixNumber);
			}
			
			set
			{
				base.SetSystemString(AutoNumberingMetadata.ColumnNames.PrefixNumber, value);
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
			public esStrings(esAutoNumbering entity)
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
				
			public System.String KaYear
			{
				get
				{
					System.String data = entity.KaYear;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.KaYear = null;
					else entity.KaYear = Convert.ToString(value);
				}
			}
				
			public System.String KaMonth
			{
				get
				{
					System.String data = entity.KaMonth;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.KaMonth = null;
					else entity.KaMonth = Convert.ToString(value);
				}
			}
				
			public System.String LastNumber
			{
				get
				{
					System.Int32? data = entity.LastNumber;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.LastNumber = null;
					else entity.LastNumber = Convert.ToInt32(value);
				}
			}
				
			public System.String Prefix
			{
				get
				{
					System.String data = entity.Prefix;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.Prefix = null;
					else entity.Prefix = Convert.ToString(value);
				}
			}
				
			public System.String PrefixNumber
			{
				get
				{
					System.String data = entity.PrefixNumber;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.PrefixNumber = null;
					else entity.PrefixNumber = Convert.ToString(value);
				}
			}
			

			private esAutoNumbering entity;
		}
		#endregion

		#region Query Logic
		protected void InitQuery(esAutoNumberingQuery query)
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
				throw new Exception("esAutoNumbering can only hold one record of data");
			}

			return dataFound;
		}
		#endregion
		
		[NonSerialized]
		private esStrings esstrings;
	}


	
	public partial class AutoNumbering : esAutoNumbering
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
	abstract public class esAutoNumberingQuery : esDynamicQuery
	{
		override protected IMetadata Meta
		{
			get
			{
				return AutoNumberingMetadata.Meta();
			}
		}	
		

		public esQueryItem Id
		{
			get
			{
				return new esQueryItem(this, AutoNumberingMetadata.ColumnNames.Id, esSystemType.Int64);
			}
		} 
		
		public esQueryItem KaCode
		{
			get
			{
				return new esQueryItem(this, AutoNumberingMetadata.ColumnNames.KaCode, esSystemType.String);
			}
		} 
		
		public esQueryItem KaYear
		{
			get
			{
				return new esQueryItem(this, AutoNumberingMetadata.ColumnNames.KaYear, esSystemType.String);
			}
		} 
		
		public esQueryItem KaMonth
		{
			get
			{
				return new esQueryItem(this, AutoNumberingMetadata.ColumnNames.KaMonth, esSystemType.String);
			}
		} 
		
		public esQueryItem LastNumber
		{
			get
			{
				return new esQueryItem(this, AutoNumberingMetadata.ColumnNames.LastNumber, esSystemType.Int32);
			}
		} 
		
		public esQueryItem Prefix
		{
			get
			{
				return new esQueryItem(this, AutoNumberingMetadata.ColumnNames.Prefix, esSystemType.String);
			}
		} 
		
		public esQueryItem PrefixNumber
		{
			get
			{
				return new esQueryItem(this, AutoNumberingMetadata.ColumnNames.PrefixNumber, esSystemType.String);
			}
		} 
		
	}



    [System.Diagnostics.DebuggerDisplay("Count = {Count}")]
	[Serializable]
	[XmlType("AutoNumberingCollection")]
	public partial class AutoNumberingCollection : esAutoNumberingCollection, IEnumerable<AutoNumbering>
	{
		public AutoNumberingCollection()
		{

		}
		
		public static implicit operator List<AutoNumbering>(AutoNumberingCollection coll)
		{
			List<AutoNumbering> list = new List<AutoNumbering>();
			
			foreach (AutoNumbering emp in coll)
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
				return  AutoNumberingMetadata.Meta();
			}
		}
		
		
		
		override protected esDynamicQuery GetDynamicQuery()
		{
			if (this.query == null)
			{
				this.query = new AutoNumberingQuery();
				this.InitQuery(query);
			}
			return this.query;
		}
		
		override protected esEntity CreateEntityForCollection(DataRow row)
		{
			return new AutoNumbering(row);
		}

		override protected esEntity CreateEntity()
		{
			return new AutoNumbering();
		}
		
		
		#endregion


		[BrowsableAttribute( false )]
		public AutoNumberingQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new AutoNumberingQuery();
					base.InitQuery(this.query);
				}

				return this.query;
			}
		}

		public void QueryReset()
		{
			this.query = null;
		}

		public bool Load(AutoNumberingQuery query)
		{
			this.query = query;
			base.InitQuery(this.query);
			return this.Query.Load();
		}
		
		public AutoNumbering AddNew()
		{
			AutoNumbering entity = base.AddNewEntity() as AutoNumbering;
			
			return entity;
		}

		public AutoNumbering FindByPrimaryKey(System.Int64 id)
		{
			return base.FindByPrimaryKey(id) as AutoNumbering;
		}


		#region IEnumerable<AutoNumbering> Members

		IEnumerator<AutoNumbering> IEnumerable<AutoNumbering>.GetEnumerator()
		{
			System.Collections.IEnumerable enumer = this as System.Collections.IEnumerable;
			System.Collections.IEnumerator iterator = enumer.GetEnumerator();

			while(iterator.MoveNext())
			{
				yield return iterator.Current as AutoNumbering;
			}
		}

		#endregion
		
		private AutoNumberingQuery query;
	}


	/// <summary>
	/// Encapsulates the 'AUTO_NUMBERING' table
	/// </summary>

    [System.Diagnostics.DebuggerDisplay("AutoNumbering ({Id})")]
	[Serializable]
	public partial class AutoNumbering : esAutoNumbering
	{
		public AutoNumbering()
		{

		}
	
		public AutoNumbering(DataRow row)
			: base(row)
		{

		}
		
		#region Housekeeping methods
		override protected IMetadata Meta
		{
			get
			{
				return AutoNumberingMetadata.Meta();
			}
		}
		
		
		
		override protected esAutoNumberingQuery GetDynamicQuery()
		{
			if (this.query == null)
			{
				this.query = new AutoNumberingQuery();
				this.InitQuery(query);
			}
			return this.query;
		}
		#endregion
		



		[BrowsableAttribute( false )]
		public AutoNumberingQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new AutoNumberingQuery();
					base.InitQuery(this.query);
				}

				return this.query;
			}
		}

		public void QueryReset()
		{
			this.query = null;
		}
		

		public bool Load(AutoNumberingQuery query)
		{
			this.query = query;
			base.InitQuery(this.query);
			return this.Query.Load();
		}
		
		private AutoNumberingQuery query;
	}



    [System.Diagnostics.DebuggerDisplay("LastQuery = {es.LastQuery}")]
	[Serializable]
		
	public partial class AutoNumberingQuery : esAutoNumberingQuery
	{
		public AutoNumberingQuery()
		{

		}		
		
		public AutoNumberingQuery(string joinAlias)
		{
			this.es.JoinAlias = joinAlias;
		}	

        override protected string GetQueryName()
        {
            return "AutoNumberingQuery";
        }
		
			
	}


	[Serializable]
	public partial class AutoNumberingMetadata : esMetadata, IMetadata
	{
		#region Protected Constructor
		protected AutoNumberingMetadata()
		{
			_columns = new esColumnMetadataCollection();
			esColumnMetadata c;

			c = new esColumnMetadata(AutoNumberingMetadata.ColumnNames.Id, 0, typeof(System.Int64), esSystemType.Int64);
			c.PropertyName = AutoNumberingMetadata.PropertyNames.Id;
			c.IsInPrimaryKey = true;
			c.IsAutoIncrement = true;
			c.NumericPrecision = 19;
			_columns.Add(c);
				
			c = new esColumnMetadata(AutoNumberingMetadata.ColumnNames.KaCode, 1, typeof(System.String), esSystemType.String);
			c.PropertyName = AutoNumberingMetadata.PropertyNames.KaCode;
			c.CharacterMaxLength = 15;
			c.IsNullable = true;
			_columns.Add(c);
				
			c = new esColumnMetadata(AutoNumberingMetadata.ColumnNames.KaYear, 2, typeof(System.String), esSystemType.String);
			c.PropertyName = AutoNumberingMetadata.PropertyNames.KaYear;
			c.CharacterMaxLength = 4;
			_columns.Add(c);
				
			c = new esColumnMetadata(AutoNumberingMetadata.ColumnNames.KaMonth, 3, typeof(System.String), esSystemType.String);
			c.PropertyName = AutoNumberingMetadata.PropertyNames.KaMonth;
			c.CharacterMaxLength = 2;
			_columns.Add(c);
				
			c = new esColumnMetadata(AutoNumberingMetadata.ColumnNames.LastNumber, 4, typeof(System.Int32), esSystemType.Int32);
			c.PropertyName = AutoNumberingMetadata.PropertyNames.LastNumber;
			c.NumericPrecision = 10;
			c.HasDefault = true;
			c.Default = @"((0))";
			_columns.Add(c);
				
			c = new esColumnMetadata(AutoNumberingMetadata.ColumnNames.Prefix, 5, typeof(System.String), esSystemType.String);
			c.PropertyName = AutoNumberingMetadata.PropertyNames.Prefix;
			c.CharacterMaxLength = 10;
			c.IsNullable = true;
			_columns.Add(c);
				
			c = new esColumnMetadata(AutoNumberingMetadata.ColumnNames.PrefixNumber, 6, typeof(System.String), esSystemType.String);
			c.PropertyName = AutoNumberingMetadata.PropertyNames.PrefixNumber;
			c.CharacterMaxLength = 3;
			_columns.Add(c);
				
		}
		#endregion	
	
		static public AutoNumberingMetadata Meta()
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
			 public const string Id = "ID";
			 public const string KaCode = "KA_CODE";
			 public const string KaYear = "KA_YEAR";
			 public const string KaMonth = "KA_MONTH";
			 public const string LastNumber = "LAST_NUMBER";
			 public const string Prefix = "PREFIX";
			 public const string PrefixNumber = "PREFIX_NUMBER";
		}
		#endregion	
		
		#region PropertyNames
		public class PropertyNames
		{ 
			 public const string Id = "Id";
			 public const string KaCode = "KaCode";
			 public const string KaYear = "KaYear";
			 public const string KaMonth = "KaMonth";
			 public const string LastNumber = "LastNumber";
			 public const string Prefix = "Prefix";
			 public const string PrefixNumber = "PrefixNumber";
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
			lock (typeof(AutoNumberingMetadata))
			{
				if(AutoNumberingMetadata.mapDelegates == null)
				{
					AutoNumberingMetadata.mapDelegates = new Dictionary<string,MapToMeta>();
				}
				
				if (AutoNumberingMetadata.meta == null)
				{
					AutoNumberingMetadata.meta = new AutoNumberingMetadata();
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
				meta.AddTypeMap("KaYear", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("KaMonth", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("LastNumber", new esTypeMap("int", "System.Int32"));
				meta.AddTypeMap("Prefix", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("PrefixNumber", new esTypeMap("nvarchar", "System.String"));			
				
				
				
				meta.Source = "AUTO_NUMBERING";
				meta.Destination = "AUTO_NUMBERING";
				
				meta.spInsert = "proc_AUTO_NUMBERINGInsert";				
				meta.spUpdate = "proc_AUTO_NUMBERINGUpdate";		
				meta.spDelete = "proc_AUTO_NUMBERINGDelete";
				meta.spLoadAll = "proc_AUTO_NUMBERINGLoadAll";
				meta.spLoadByPrimaryKey = "proc_AUTO_NUMBERINGLoadByPrimaryKey";
				
				this._providerMetadataMaps["esDefault"] = meta;
			}
			
			return this._providerMetadataMaps["esDefault"];
		}

		#endregion

		static private AutoNumberingMetadata meta;
		static protected Dictionary<string, MapToMeta> mapDelegates;
		static private int _esDefault = RegisterDelegateesDefault();
	}
}
