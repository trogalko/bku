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
	abstract public class esDebitKreditCollection : esEntityCollection
	{
		public esDebitKreditCollection()
		{

		}

		protected override string GetCollectionName()
		{
			return "DebitKreditCollection";
		}

		#region Query Logic
		protected void InitQuery(esDebitKreditQuery query)
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
			this.InitQuery(query as esDebitKreditQuery);
		}
		#endregion
		
		virtual public DebitKredit DetachEntity(DebitKredit entity)
		{
			return base.DetachEntity(entity) as DebitKredit;
		}
		
		virtual public DebitKredit AttachEntity(DebitKredit entity)
		{
			return base.AttachEntity(entity) as DebitKredit;
		}
		
		virtual public void Combine(DebitKreditCollection collection)
		{
			base.Combine(collection);
		}
		
		new public DebitKredit this[int index]
		{
			get
			{
				return base[index] as DebitKredit;
			}
		}

		public override Type GetEntityType()
		{
			return typeof(DebitKredit);
		}
	}



	[Serializable]
	abstract public class esDebitKredit : esEntity
	{
		/// <summary>
		/// Used internally by the entity's DynamicQuery mechanism.
		/// </summary>
		virtual protected esDebitKreditQuery GetDynamicQuery()
		{
			return null;
		}

		public esDebitKredit()
		{

		}

		public esDebitKredit(DataRow row)
			: base(row)
		{

		}
		
		#region LoadByPrimaryKey
		public virtual bool LoadByPrimaryKey(System.Int32 id)
		{
			if(this.es.Connection.SqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(id);
			else
				return LoadByPrimaryKeyStoredProcedure(id);
		}

		public virtual bool LoadByPrimaryKey(esSqlAccessType sqlAccessType, System.Int32 id)
		{
			if (sqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(id);
			else
				return LoadByPrimaryKeyStoredProcedure(id);
		}

		private bool LoadByPrimaryKeyDynamic(System.Int32 id)
		{
			esDebitKreditQuery query = this.GetDynamicQuery();
			query.Where(query.Id == id);
			return query.Load();
		}

		private bool LoadByPrimaryKeyStoredProcedure(System.Int32 id)
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
						case "Type": this.str.Type = (string)value; break;
					}
				}
				else
				{
					switch (name)
					{	
						case "Id":
						
							if (value == null || value is System.Int32)
								this.Id = (System.Int32?)value;
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
		/// Maps to DebitKredit.id
		/// </summary>
		virtual public System.Int32? Id
		{
			get
			{
				return base.GetSystemInt32(DebitKreditMetadata.ColumnNames.Id);
			}
			
			set
			{
				base.SetSystemInt32(DebitKreditMetadata.ColumnNames.Id, value);
			}
		}
		
		/// <summary>
		/// Maps to DebitKredit.type
		/// </summary>
		virtual public System.String Type
		{
			get
			{
				return base.GetSystemString(DebitKreditMetadata.ColumnNames.Type);
			}
			
			set
			{
				base.SetSystemString(DebitKreditMetadata.ColumnNames.Type, value);
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
			public esStrings(esDebitKredit entity)
			{
				this.entity = entity;
			}
			
	
			public System.String Id
			{
				get
				{
					System.Int32? data = entity.Id;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.Id = null;
					else entity.Id = Convert.ToInt32(value);
				}
			}
				
			public System.String Type
			{
				get
				{
					System.String data = entity.Type;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.Type = null;
					else entity.Type = Convert.ToString(value);
				}
			}
			

			private esDebitKredit entity;
		}
		#endregion

		#region Query Logic
		protected void InitQuery(esDebitKreditQuery query)
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
				throw new Exception("esDebitKredit can only hold one record of data");
			}

			return dataFound;
		}
		#endregion
		
		[NonSerialized]
		private esStrings esstrings;
	}


	
	public partial class DebitKredit : esDebitKredit
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
	abstract public class esDebitKreditQuery : esDynamicQuery
	{
		override protected IMetadata Meta
		{
			get
			{
				return DebitKreditMetadata.Meta();
			}
		}	
		

		public esQueryItem Id
		{
			get
			{
				return new esQueryItem(this, DebitKreditMetadata.ColumnNames.Id, esSystemType.Int32);
			}
		} 
		
		public esQueryItem Type
		{
			get
			{
				return new esQueryItem(this, DebitKreditMetadata.ColumnNames.Type, esSystemType.String);
			}
		} 
		
	}



    [System.Diagnostics.DebuggerDisplay("Count = {Count}")]
	[Serializable]
	[XmlType("DebitKreditCollection")]
	public partial class DebitKreditCollection : esDebitKreditCollection, IEnumerable<DebitKredit>
	{
		public DebitKreditCollection()
		{

		}
		
		public static implicit operator List<DebitKredit>(DebitKreditCollection coll)
		{
			List<DebitKredit> list = new List<DebitKredit>();
			
			foreach (DebitKredit emp in coll)
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
				return  DebitKreditMetadata.Meta();
			}
		}
		
		
		
		override protected esDynamicQuery GetDynamicQuery()
		{
			if (this.query == null)
			{
				this.query = new DebitKreditQuery();
				this.InitQuery(query);
			}
			return this.query;
		}
		
		override protected esEntity CreateEntityForCollection(DataRow row)
		{
			return new DebitKredit(row);
		}

		override protected esEntity CreateEntity()
		{
			return new DebitKredit();
		}
		
		
		#endregion


		[BrowsableAttribute( false )]
		public DebitKreditQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new DebitKreditQuery();
					base.InitQuery(this.query);
				}

				return this.query;
			}
		}

		public void QueryReset()
		{
			this.query = null;
		}

		public bool Load(DebitKreditQuery query)
		{
			this.query = query;
			base.InitQuery(this.query);
			return this.Query.Load();
		}
		
		public DebitKredit AddNew()
		{
			DebitKredit entity = base.AddNewEntity() as DebitKredit;
			
			return entity;
		}

		public DebitKredit FindByPrimaryKey(System.Int32 id)
		{
			return base.FindByPrimaryKey(id) as DebitKredit;
		}


		#region IEnumerable<DebitKredit> Members

		IEnumerator<DebitKredit> IEnumerable<DebitKredit>.GetEnumerator()
		{
			System.Collections.IEnumerable enumer = this as System.Collections.IEnumerable;
			System.Collections.IEnumerator iterator = enumer.GetEnumerator();

			while(iterator.MoveNext())
			{
				yield return iterator.Current as DebitKredit;
			}
		}

		#endregion
		
		private DebitKreditQuery query;
	}


	/// <summary>
	/// Encapsulates the 'DebitKredit' table
	/// </summary>

    [System.Diagnostics.DebuggerDisplay("DebitKredit ({Id})")]
	[Serializable]
	public partial class DebitKredit : esDebitKredit
	{
		public DebitKredit()
		{

		}
	
		public DebitKredit(DataRow row)
			: base(row)
		{

		}
		
		#region Housekeeping methods
		override protected IMetadata Meta
		{
			get
			{
				return DebitKreditMetadata.Meta();
			}
		}
		
		
		
		override protected esDebitKreditQuery GetDynamicQuery()
		{
			if (this.query == null)
			{
				this.query = new DebitKreditQuery();
				this.InitQuery(query);
			}
			return this.query;
		}
		#endregion
		



		[BrowsableAttribute( false )]
		public DebitKreditQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new DebitKreditQuery();
					base.InitQuery(this.query);
				}

				return this.query;
			}
		}

		public void QueryReset()
		{
			this.query = null;
		}
		

		public bool Load(DebitKreditQuery query)
		{
			this.query = query;
			base.InitQuery(this.query);
			return this.Query.Load();
		}
		
		private DebitKreditQuery query;
	}



    [System.Diagnostics.DebuggerDisplay("LastQuery = {es.LastQuery}")]
	[Serializable]
		
	public partial class DebitKreditQuery : esDebitKreditQuery
	{
		public DebitKreditQuery()
		{

		}		
		
		public DebitKreditQuery(string joinAlias)
		{
			this.es.JoinAlias = joinAlias;
		}	

        override protected string GetQueryName()
        {
            return "DebitKreditQuery";
        }
		
			
	}


	[Serializable]
	public partial class DebitKreditMetadata : esMetadata, IMetadata
	{
		#region Protected Constructor
		protected DebitKreditMetadata()
		{
			_columns = new esColumnMetadataCollection();
			esColumnMetadata c;

			c = new esColumnMetadata(DebitKreditMetadata.ColumnNames.Id, 0, typeof(System.Int32), esSystemType.Int32);
			c.PropertyName = DebitKreditMetadata.PropertyNames.Id;
			c.IsInPrimaryKey = true;
			c.IsAutoIncrement = true;
			c.NumericPrecision = 10;
			_columns.Add(c);
				
			c = new esColumnMetadata(DebitKreditMetadata.ColumnNames.Type, 1, typeof(System.String), esSystemType.String);
			c.PropertyName = DebitKreditMetadata.PropertyNames.Type;
			c.CharacterMaxLength = 1;
			_columns.Add(c);
				
		}
		#endregion	
	
		static public DebitKreditMetadata Meta()
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
			 public const string Type = "type";
		}
		#endregion	
		
		#region PropertyNames
		public class PropertyNames
		{ 
			 public const string Id = "Id";
			 public const string Type = "Type";
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
			lock (typeof(DebitKreditMetadata))
			{
				if(DebitKreditMetadata.mapDelegates == null)
				{
					DebitKreditMetadata.mapDelegates = new Dictionary<string,MapToMeta>();
				}
				
				if (DebitKreditMetadata.meta == null)
				{
					DebitKreditMetadata.meta = new DebitKreditMetadata();
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
				

				meta.AddTypeMap("Id", new esTypeMap("int", "System.Int32"));
				meta.AddTypeMap("Type", new esTypeMap("nvarchar", "System.String"));			
				
				
				
				meta.Source = "DebitKredit";
				meta.Destination = "DebitKredit";
				
				meta.spInsert = "proc_DebitKreditInsert";				
				meta.spUpdate = "proc_DebitKreditUpdate";		
				meta.spDelete = "proc_DebitKreditDelete";
				meta.spLoadAll = "proc_DebitKreditLoadAll";
				meta.spLoadByPrimaryKey = "proc_DebitKreditLoadByPrimaryKey";
				
				this._providerMetadataMaps["esDefault"] = meta;
			}
			
			return this._providerMetadataMaps["esDefault"];
		}

		#endregion

		static private DebitKreditMetadata meta;
		static protected Dictionary<string, MapToMeta> mapDelegates;
		static private int _esDefault = RegisterDelegateesDefault();
	}
}
