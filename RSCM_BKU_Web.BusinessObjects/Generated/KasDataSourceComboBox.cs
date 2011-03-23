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
	abstract public class esKasDataSourceComboBoxCollection : esEntityCollection
	{
		public esKasDataSourceComboBoxCollection()
		{

		}

		protected override string GetCollectionName()
		{
			return "KasDataSourceComboBoxCollection";
		}

		#region Query Logic
		protected void InitQuery(esKasDataSourceComboBoxQuery query)
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
			this.InitQuery(query as esKasDataSourceComboBoxQuery);
		}
		#endregion
		
		virtual public KasDataSourceComboBox DetachEntity(KasDataSourceComboBox entity)
		{
			return base.DetachEntity(entity) as KasDataSourceComboBox;
		}
		
		virtual public KasDataSourceComboBox AttachEntity(KasDataSourceComboBox entity)
		{
			return base.AttachEntity(entity) as KasDataSourceComboBox;
		}
		
		virtual public void Combine(KasDataSourceComboBoxCollection collection)
		{
			base.Combine(collection);
		}
		
		new public KasDataSourceComboBox this[int index]
		{
			get
			{
				return base[index] as KasDataSourceComboBox;
			}
		}

		public override Type GetEntityType()
		{
			return typeof(KasDataSourceComboBox);
		}
	}



	[Serializable]
	abstract public class esKasDataSourceComboBox : esEntity
	{
		/// <summary>
		/// Used internally by the entity's DynamicQuery mechanism.
		/// </summary>
		virtual protected esKasDataSourceComboBoxQuery GetDynamicQuery()
		{
			return null;
		}

		public esKasDataSourceComboBox()
		{

		}

		public esKasDataSourceComboBox(DataRow row)
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
						case "KaCode": this.str.KaCode = (string)value; break;							
						case "KaName": this.str.KaName = (string)value; break;
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
		/// Maps to Kas_DataSource_ComboBox.KA_CODE
		/// </summary>
		virtual public System.String KaCode
		{
			get
			{
				return base.GetSystemString(KasDataSourceComboBoxMetadata.ColumnNames.KaCode);
			}
			
			set
			{
				base.SetSystemString(KasDataSourceComboBoxMetadata.ColumnNames.KaCode, value);
			}
		}
		
		/// <summary>
		/// Maps to Kas_DataSource_ComboBox.KA_NAME
		/// </summary>
		virtual public System.String KaName
		{
			get
			{
				return base.GetSystemString(KasDataSourceComboBoxMetadata.ColumnNames.KaName);
			}
			
			set
			{
				base.SetSystemString(KasDataSourceComboBoxMetadata.ColumnNames.KaName, value);
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
			public esStrings(esKasDataSourceComboBox entity)
			{
				this.entity = entity;
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
			

			private esKasDataSourceComboBox entity;
		}
		#endregion

		#region Query Logic
		protected void InitQuery(esKasDataSourceComboBoxQuery query)
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
				throw new Exception("esKasDataSourceComboBox can only hold one record of data");
			}

			return dataFound;
		}
		#endregion
		
		[NonSerialized]
		private esStrings esstrings;
	}



	[Serializable]
	abstract public class esKasDataSourceComboBoxQuery : esDynamicQuery
	{
		override protected IMetadata Meta
		{
			get
			{
				return KasDataSourceComboBoxMetadata.Meta();
			}
		}	
		

		public esQueryItem KaCode
		{
			get
			{
				return new esQueryItem(this, KasDataSourceComboBoxMetadata.ColumnNames.KaCode, esSystemType.String);
			}
		} 
		
		public esQueryItem KaName
		{
			get
			{
				return new esQueryItem(this, KasDataSourceComboBoxMetadata.ColumnNames.KaName, esSystemType.String);
			}
		} 
		
	}



    [System.Diagnostics.DebuggerDisplay("Count = {Count}")]
	[Serializable]
	[XmlType("KasDataSourceComboBoxCollection")]
	public partial class KasDataSourceComboBoxCollection : esKasDataSourceComboBoxCollection, IEnumerable<KasDataSourceComboBox>
	{
		public KasDataSourceComboBoxCollection()
		{

		}
		
		public static implicit operator List<KasDataSourceComboBox>(KasDataSourceComboBoxCollection coll)
		{
			List<KasDataSourceComboBox> list = new List<KasDataSourceComboBox>();
			
			foreach (KasDataSourceComboBox emp in coll)
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
				return  KasDataSourceComboBoxMetadata.Meta();
			}
		}
		
		
		
		override protected esDynamicQuery GetDynamicQuery()
		{
			if (this.query == null)
			{
				this.query = new KasDataSourceComboBoxQuery();
				this.InitQuery(query);
			}
			return this.query;
		}
		
		override protected esEntity CreateEntityForCollection(DataRow row)
		{
			return new KasDataSourceComboBox(row);
		}

		override protected esEntity CreateEntity()
		{
			return new KasDataSourceComboBox();
		}
		
		
		override public bool LoadAll()
		{
			return base.LoadAll(esSqlAccessType.DynamicSQL);
		}	
		
		#endregion


		[BrowsableAttribute( false )]
		public KasDataSourceComboBoxQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new KasDataSourceComboBoxQuery();
					base.InitQuery(this.query);
				}

				return this.query;
			}
		}

		public void QueryReset()
		{
			this.query = null;
		}

		public bool Load(KasDataSourceComboBoxQuery query)
		{
			this.query = query;
			base.InitQuery(this.query);
			return this.Query.Load();
		}
		
		public KasDataSourceComboBox AddNew()
		{
			KasDataSourceComboBox entity = base.AddNewEntity() as KasDataSourceComboBox;
			
			return entity;
		}


		#region IEnumerable<KasDataSourceComboBox> Members

		IEnumerator<KasDataSourceComboBox> IEnumerable<KasDataSourceComboBox>.GetEnumerator()
		{
			System.Collections.IEnumerable enumer = this as System.Collections.IEnumerable;
			System.Collections.IEnumerator iterator = enumer.GetEnumerator();

			while(iterator.MoveNext())
			{
				yield return iterator.Current as KasDataSourceComboBox;
			}
		}

		#endregion
		
		private KasDataSourceComboBoxQuery query;
	}


	/// <summary>
	/// Encapsulates the 'Kas_DataSource_ComboBox' view
	/// </summary>

    [System.Diagnostics.DebuggerDisplay("KasDataSourceComboBox ()")]
	[Serializable]
	public partial class KasDataSourceComboBox : esKasDataSourceComboBox
	{
		public KasDataSourceComboBox()
		{

		}
	
		public KasDataSourceComboBox(DataRow row)
			: base(row)
		{

		}
		
		#region Housekeeping methods
		override protected IMetadata Meta
		{
			get
			{
				return KasDataSourceComboBoxMetadata.Meta();
			}
		}
		
		
		
		override protected esKasDataSourceComboBoxQuery GetDynamicQuery()
		{
			if (this.query == null)
			{
				this.query = new KasDataSourceComboBoxQuery();
				this.InitQuery(query);
			}
			return this.query;
		}
		#endregion
		



		[BrowsableAttribute( false )]
		public KasDataSourceComboBoxQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new KasDataSourceComboBoxQuery();
					base.InitQuery(this.query);
				}

				return this.query;
			}
		}

		public void QueryReset()
		{
			this.query = null;
		}
		

		public bool Load(KasDataSourceComboBoxQuery query)
		{
			this.query = query;
			base.InitQuery(this.query);
			return this.Query.Load();
		}
		
		private KasDataSourceComboBoxQuery query;
	}



    [System.Diagnostics.DebuggerDisplay("LastQuery = {es.LastQuery}")]
	[Serializable]
		
	public partial class KasDataSourceComboBoxQuery : esKasDataSourceComboBoxQuery
	{
		public KasDataSourceComboBoxQuery()
		{

		}		
		
		public KasDataSourceComboBoxQuery(string joinAlias)
		{
			this.es.JoinAlias = joinAlias;
		}	

        override protected string GetQueryName()
        {
            return "KasDataSourceComboBoxQuery";
        }
		
			
	}


	[Serializable]
	public partial class KasDataSourceComboBoxMetadata : esMetadata, IMetadata
	{
		#region Protected Constructor
		protected KasDataSourceComboBoxMetadata()
		{
			_columns = new esColumnMetadataCollection();
			esColumnMetadata c;

			c = new esColumnMetadata(KasDataSourceComboBoxMetadata.ColumnNames.KaCode, 0, typeof(System.String), esSystemType.String);
			c.PropertyName = KasDataSourceComboBoxMetadata.PropertyNames.KaCode;
			c.CharacterMaxLength = 15;
			_columns.Add(c);
				
			c = new esColumnMetadata(KasDataSourceComboBoxMetadata.ColumnNames.KaName, 1, typeof(System.String), esSystemType.String);
			c.PropertyName = KasDataSourceComboBoxMetadata.PropertyNames.KaName;
			c.CharacterMaxLength = 256;
			_columns.Add(c);
				
		}
		#endregion	
	
		static public KasDataSourceComboBoxMetadata Meta()
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
			 public const string KaCode = "KA_CODE";
			 public const string KaName = "KA_NAME";
		}
		#endregion	
		
		#region PropertyNames
		public class PropertyNames
		{ 
			 public const string KaCode = "KaCode";
			 public const string KaName = "KaName";
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
			lock (typeof(KasDataSourceComboBoxMetadata))
			{
				if(KasDataSourceComboBoxMetadata.mapDelegates == null)
				{
					KasDataSourceComboBoxMetadata.mapDelegates = new Dictionary<string,MapToMeta>();
				}
				
				if (KasDataSourceComboBoxMetadata.meta == null)
				{
					KasDataSourceComboBoxMetadata.meta = new KasDataSourceComboBoxMetadata();
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
				

				meta.AddTypeMap("KaCode", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("KaName", new esTypeMap("nvarchar", "System.String"));			
				
				
				
				meta.Source = "Kas_DataSource_ComboBox";
				meta.Destination = "Kas_DataSource_ComboBox";
				
				meta.spInsert = "proc_Kas_DataSource_ComboBoxInsert";				
				meta.spUpdate = "proc_Kas_DataSource_ComboBoxUpdate";		
				meta.spDelete = "proc_Kas_DataSource_ComboBoxDelete";
				meta.spLoadAll = "proc_Kas_DataSource_ComboBoxLoadAll";
				meta.spLoadByPrimaryKey = "proc_Kas_DataSource_ComboBoxLoadByPrimaryKey";
				
				this._providerMetadataMaps["esDefault"] = meta;
			}
			
			return this._providerMetadataMaps["esDefault"];
		}

		#endregion

		static private KasDataSourceComboBoxMetadata meta;
		static protected Dictionary<string, MapToMeta> mapDelegates;
		static private int _esDefault = RegisterDelegateesDefault();
	}
}
