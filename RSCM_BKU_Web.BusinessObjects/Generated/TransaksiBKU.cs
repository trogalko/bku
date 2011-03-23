/*
===============================================================================
                    EntitySpaces 2009 by EntitySpaces, LLC
             Persistence Layer and Business Objects for Microsoft .NET
             EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
                          http://www.entityspaces.net
===============================================================================
EntitySpaces Version : 2009.2.1214.0
EntitySpaces Driver  : SQL
Date Generated       : 15/03/2011 3:33:43
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
	abstract public class esTransaksiBKUCollection : esEntityCollection
	{
		public esTransaksiBKUCollection()
		{

		}

		protected override string GetCollectionName()
		{
			return "TransaksiBKUCollection";
		}

		#region Query Logic
		protected void InitQuery(esTransaksiBKUQuery query)
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
			this.InitQuery(query as esTransaksiBKUQuery);
		}
		#endregion
		
		virtual public TransaksiBKU DetachEntity(TransaksiBKU entity)
		{
			return base.DetachEntity(entity) as TransaksiBKU;
		}
		
		virtual public TransaksiBKU AttachEntity(TransaksiBKU entity)
		{
			return base.AttachEntity(entity) as TransaksiBKU;
		}
		
		virtual public void Combine(TransaksiBKUCollection collection)
		{
			base.Combine(collection);
		}
		
		new public TransaksiBKU this[int index]
		{
			get
			{
				return base[index] as TransaksiBKU;
			}
		}

		public override Type GetEntityType()
		{
			return typeof(TransaksiBKU);
		}
	}



	[Serializable]
	abstract public class esTransaksiBKU : esEntity
	{
		/// <summary>
		/// Used internally by the entity's DynamicQuery mechanism.
		/// </summary>
		virtual protected esTransaksiBKUQuery GetDynamicQuery()
		{
			return null;
		}

		public esTransaksiBKU()
		{

		}

		public esTransaksiBKU(DataRow row)
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
						case "TransNumber": this.str.TransNumber = (string)value; break;							
						case "TransDate": this.str.TransDate = (string)value; break;							
						case "Descript": this.str.Descript = (string)value; break;							
						case "KaCode": this.str.KaCode = (string)value; break;							
						case "KaName": this.str.KaName = (string)value; break;							
						case "GtCode": this.str.GtCode = (string)value; break;							
						case "DebitAmount": this.str.DebitAmount = (string)value; break;							
						case "CreditAmount": this.str.CreditAmount = (string)value; break;							
						case "IsClosed": this.str.IsClosed = (string)value; break;							
						case "Isverified": this.str.Isverified = (string)value; break;							
						case "IsActive": this.str.IsActive = (string)value; break;
					}
				}
				else
				{
					switch (name)
					{	
						case "TransDate":
						
							if (value == null || value is System.DateTime)
								this.TransDate = (System.DateTime?)value;
							break;
						
						case "DebitAmount":
						
							if (value == null || value is System.Decimal)
								this.DebitAmount = (System.Decimal?)value;
							break;
						
						case "CreditAmount":
						
							if (value == null || value is System.Decimal)
								this.CreditAmount = (System.Decimal?)value;
							break;
						
						case "IsClosed":
						
							if (value == null || value is System.Boolean)
								this.IsClosed = (System.Boolean?)value;
							break;
						
						case "Isverified":
						
							if (value == null || value is System.Boolean)
								this.Isverified = (System.Boolean?)value;
							break;
						
						case "IsActive":
						
							if (value == null || value is System.Boolean)
								this.IsActive = (System.Boolean?)value;
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
		/// Maps to transaksiBKU.TRANS_NUMBER
		/// </summary>
		virtual public System.String TransNumber
		{
			get
			{
				return base.GetSystemString(TransaksiBKUMetadata.ColumnNames.TransNumber);
			}
			
			set
			{
				base.SetSystemString(TransaksiBKUMetadata.ColumnNames.TransNumber, value);
			}
		}
		
		/// <summary>
		/// Maps to transaksiBKU.TRANS_DATE
		/// </summary>
		virtual public System.DateTime? TransDate
		{
			get
			{
				return base.GetSystemDateTime(TransaksiBKUMetadata.ColumnNames.TransDate);
			}
			
			set
			{
				base.SetSystemDateTime(TransaksiBKUMetadata.ColumnNames.TransDate, value);
			}
		}
		
		/// <summary>
		/// Maps to transaksiBKU.DESCRIPT
		/// </summary>
		virtual public System.String Descript
		{
			get
			{
				return base.GetSystemString(TransaksiBKUMetadata.ColumnNames.Descript);
			}
			
			set
			{
				base.SetSystemString(TransaksiBKUMetadata.ColumnNames.Descript, value);
			}
		}
		
		/// <summary>
		/// Maps to transaksiBKU.KA_CODE
		/// </summary>
		virtual public System.String KaCode
		{
			get
			{
				return base.GetSystemString(TransaksiBKUMetadata.ColumnNames.KaCode);
			}
			
			set
			{
				base.SetSystemString(TransaksiBKUMetadata.ColumnNames.KaCode, value);
			}
		}
		
		/// <summary>
		/// Maps to transaksiBKU.KA_NAME
		/// </summary>
		virtual public System.String KaName
		{
			get
			{
				return base.GetSystemString(TransaksiBKUMetadata.ColumnNames.KaName);
			}
			
			set
			{
				base.SetSystemString(TransaksiBKUMetadata.ColumnNames.KaName, value);
			}
		}
		
		/// <summary>
		/// Maps to transaksiBKU.GT_CODE
		/// </summary>
		virtual public System.String GtCode
		{
			get
			{
				return base.GetSystemString(TransaksiBKUMetadata.ColumnNames.GtCode);
			}
			
			set
			{
				base.SetSystemString(TransaksiBKUMetadata.ColumnNames.GtCode, value);
			}
		}
		
		/// <summary>
		/// Maps to transaksiBKU.DEBIT_AMOUNT
		/// </summary>
		virtual public System.Decimal? DebitAmount
		{
			get
			{
				return base.GetSystemDecimal(TransaksiBKUMetadata.ColumnNames.DebitAmount);
			}
			
			set
			{
				base.SetSystemDecimal(TransaksiBKUMetadata.ColumnNames.DebitAmount, value);
			}
		}
		
		/// <summary>
		/// Maps to transaksiBKU.CREDIT_AMOUNT
		/// </summary>
		virtual public System.Decimal? CreditAmount
		{
			get
			{
				return base.GetSystemDecimal(TransaksiBKUMetadata.ColumnNames.CreditAmount);
			}
			
			set
			{
				base.SetSystemDecimal(TransaksiBKUMetadata.ColumnNames.CreditAmount, value);
			}
		}
		
		/// <summary>
		/// Maps to transaksiBKU.IS_CLOSED
		/// </summary>
		virtual public System.Boolean? IsClosed
		{
			get
			{
				return base.GetSystemBoolean(TransaksiBKUMetadata.ColumnNames.IsClosed);
			}
			
			set
			{
				base.SetSystemBoolean(TransaksiBKUMetadata.ColumnNames.IsClosed, value);
			}
		}
		
		/// <summary>
		/// Maps to transaksiBKU.ISVERIFIED
		/// </summary>
		virtual public System.Boolean? Isverified
		{
			get
			{
				return base.GetSystemBoolean(TransaksiBKUMetadata.ColumnNames.Isverified);
			}
			
			set
			{
				base.SetSystemBoolean(TransaksiBKUMetadata.ColumnNames.Isverified, value);
			}
		}
		
		/// <summary>
		/// Maps to transaksiBKU.IS_ACTIVE
		/// </summary>
		virtual public System.Boolean? IsActive
		{
			get
			{
				return base.GetSystemBoolean(TransaksiBKUMetadata.ColumnNames.IsActive);
			}
			
			set
			{
				base.SetSystemBoolean(TransaksiBKUMetadata.ColumnNames.IsActive, value);
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
			public esStrings(esTransaksiBKU entity)
			{
				this.entity = entity;
			}
			
	
			public System.String TransNumber
			{
				get
				{
					System.String data = entity.TransNumber;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.TransNumber = null;
					else entity.TransNumber = Convert.ToString(value);
				}
			}
				
			public System.String TransDate
			{
				get
				{
					System.DateTime? data = entity.TransDate;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.TransDate = null;
					else entity.TransDate = Convert.ToDateTime(value);
				}
			}
				
			public System.String Descript
			{
				get
				{
					System.String data = entity.Descript;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.Descript = null;
					else entity.Descript = Convert.ToString(value);
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
				
			public System.String GtCode
			{
				get
				{
					System.String data = entity.GtCode;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.GtCode = null;
					else entity.GtCode = Convert.ToString(value);
				}
			}
				
			public System.String DebitAmount
			{
				get
				{
					System.Decimal? data = entity.DebitAmount;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.DebitAmount = null;
					else entity.DebitAmount = Convert.ToDecimal(value);
				}
			}
				
			public System.String CreditAmount
			{
				get
				{
					System.Decimal? data = entity.CreditAmount;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.CreditAmount = null;
					else entity.CreditAmount = Convert.ToDecimal(value);
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
				
			public System.String Isverified
			{
				get
				{
					System.Boolean? data = entity.Isverified;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.Isverified = null;
					else entity.Isverified = Convert.ToBoolean(value);
				}
			}
				
			public System.String IsActive
			{
				get
				{
					System.Boolean? data = entity.IsActive;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.IsActive = null;
					else entity.IsActive = Convert.ToBoolean(value);
				}
			}
			

			private esTransaksiBKU entity;
		}
		#endregion

		#region Query Logic
		protected void InitQuery(esTransaksiBKUQuery query)
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
				throw new Exception("esTransaksiBKU can only hold one record of data");
			}

			return dataFound;
		}
		#endregion
		
		[NonSerialized]
		private esStrings esstrings;
	}



	[Serializable]
	abstract public class esTransaksiBKUQuery : esDynamicQuery
	{
		override protected IMetadata Meta
		{
			get
			{
				return TransaksiBKUMetadata.Meta();
			}
		}	
		

		public esQueryItem TransNumber
		{
			get
			{
				return new esQueryItem(this, TransaksiBKUMetadata.ColumnNames.TransNumber, esSystemType.String);
			}
		} 
		
		public esQueryItem TransDate
		{
			get
			{
				return new esQueryItem(this, TransaksiBKUMetadata.ColumnNames.TransDate, esSystemType.DateTime);
			}
		} 
		
		public esQueryItem Descript
		{
			get
			{
				return new esQueryItem(this, TransaksiBKUMetadata.ColumnNames.Descript, esSystemType.String);
			}
		} 
		
		public esQueryItem KaCode
		{
			get
			{
				return new esQueryItem(this, TransaksiBKUMetadata.ColumnNames.KaCode, esSystemType.String);
			}
		} 
		
		public esQueryItem KaName
		{
			get
			{
				return new esQueryItem(this, TransaksiBKUMetadata.ColumnNames.KaName, esSystemType.String);
			}
		} 
		
		public esQueryItem GtCode
		{
			get
			{
				return new esQueryItem(this, TransaksiBKUMetadata.ColumnNames.GtCode, esSystemType.String);
			}
		} 
		
		public esQueryItem DebitAmount
		{
			get
			{
				return new esQueryItem(this, TransaksiBKUMetadata.ColumnNames.DebitAmount, esSystemType.Decimal);
			}
		} 
		
		public esQueryItem CreditAmount
		{
			get
			{
				return new esQueryItem(this, TransaksiBKUMetadata.ColumnNames.CreditAmount, esSystemType.Decimal);
			}
		} 
		
		public esQueryItem IsClosed
		{
			get
			{
				return new esQueryItem(this, TransaksiBKUMetadata.ColumnNames.IsClosed, esSystemType.Boolean);
			}
		} 
		
		public esQueryItem Isverified
		{
			get
			{
				return new esQueryItem(this, TransaksiBKUMetadata.ColumnNames.Isverified, esSystemType.Boolean);
			}
		} 
		
		public esQueryItem IsActive
		{
			get
			{
				return new esQueryItem(this, TransaksiBKUMetadata.ColumnNames.IsActive, esSystemType.Boolean);
			}
		} 
		
	}



    [System.Diagnostics.DebuggerDisplay("Count = {Count}")]
	[Serializable]
	[XmlType("TransaksiBKUCollection")]
	public partial class TransaksiBKUCollection : esTransaksiBKUCollection, IEnumerable<TransaksiBKU>
	{
		public TransaksiBKUCollection()
		{

		}
		
		public static implicit operator List<TransaksiBKU>(TransaksiBKUCollection coll)
		{
			List<TransaksiBKU> list = new List<TransaksiBKU>();
			
			foreach (TransaksiBKU emp in coll)
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
				return  TransaksiBKUMetadata.Meta();
			}
		}
		
		
		
		override protected esDynamicQuery GetDynamicQuery()
		{
			if (this.query == null)
			{
				this.query = new TransaksiBKUQuery();
				this.InitQuery(query);
			}
			return this.query;
		}
		
		override protected esEntity CreateEntityForCollection(DataRow row)
		{
			return new TransaksiBKU(row);
		}

		override protected esEntity CreateEntity()
		{
			return new TransaksiBKU();
		}
		
		
		override public bool LoadAll()
		{
			return base.LoadAll(esSqlAccessType.DynamicSQL);
		}	
		
		#endregion


		[BrowsableAttribute( false )]
		public TransaksiBKUQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new TransaksiBKUQuery();
					base.InitQuery(this.query);
				}

				return this.query;
			}
		}

		public void QueryReset()
		{
			this.query = null;
		}

		public bool Load(TransaksiBKUQuery query)
		{
			this.query = query;
			base.InitQuery(this.query);
			return this.Query.Load();
		}
		
		public TransaksiBKU AddNew()
		{
			TransaksiBKU entity = base.AddNewEntity() as TransaksiBKU;
			
			return entity;
		}


		#region IEnumerable<TransaksiBKU> Members

		IEnumerator<TransaksiBKU> IEnumerable<TransaksiBKU>.GetEnumerator()
		{
			System.Collections.IEnumerable enumer = this as System.Collections.IEnumerable;
			System.Collections.IEnumerator iterator = enumer.GetEnumerator();

			while(iterator.MoveNext())
			{
				yield return iterator.Current as TransaksiBKU;
			}
		}

		#endregion
		
		private TransaksiBKUQuery query;
	}


	/// <summary>
	/// Encapsulates the 'transaksiBKU' view
	/// </summary>

    [System.Diagnostics.DebuggerDisplay("TransaksiBKU ()")]
	[Serializable]
	public partial class TransaksiBKU : esTransaksiBKU
	{
		public TransaksiBKU()
		{

		}
	
		public TransaksiBKU(DataRow row)
			: base(row)
		{

		}
		
		#region Housekeeping methods
		override protected IMetadata Meta
		{
			get
			{
				return TransaksiBKUMetadata.Meta();
			}
		}
		
		
		
		override protected esTransaksiBKUQuery GetDynamicQuery()
		{
			if (this.query == null)
			{
				this.query = new TransaksiBKUQuery();
				this.InitQuery(query);
			}
			return this.query;
		}
		#endregion
		



		[BrowsableAttribute( false )]
		public TransaksiBKUQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new TransaksiBKUQuery();
					base.InitQuery(this.query);
				}

				return this.query;
			}
		}

		public void QueryReset()
		{
			this.query = null;
		}
		

		public bool Load(TransaksiBKUQuery query)
		{
			this.query = query;
			base.InitQuery(this.query);
			return this.Query.Load();
		}
		
		private TransaksiBKUQuery query;
	}



    [System.Diagnostics.DebuggerDisplay("LastQuery = {es.LastQuery}")]
	[Serializable]
		
	public partial class TransaksiBKUQuery : esTransaksiBKUQuery
	{
		public TransaksiBKUQuery()
		{

		}		
		
		public TransaksiBKUQuery(string joinAlias)
		{
			this.es.JoinAlias = joinAlias;
		}	

        override protected string GetQueryName()
        {
            return "TransaksiBKUQuery";
        }
		
			
	}


	[Serializable]
	public partial class TransaksiBKUMetadata : esMetadata, IMetadata
	{
		#region Protected Constructor
		protected TransaksiBKUMetadata()
		{
			_columns = new esColumnMetadataCollection();
			esColumnMetadata c;

			c = new esColumnMetadata(TransaksiBKUMetadata.ColumnNames.TransNumber, 0, typeof(System.String), esSystemType.String);
			c.PropertyName = TransaksiBKUMetadata.PropertyNames.TransNumber;
			c.CharacterMaxLength = 18;
			_columns.Add(c);
				
			c = new esColumnMetadata(TransaksiBKUMetadata.ColumnNames.TransDate, 1, typeof(System.DateTime), esSystemType.DateTime);
			c.PropertyName = TransaksiBKUMetadata.PropertyNames.TransDate;
			_columns.Add(c);
				
			c = new esColumnMetadata(TransaksiBKUMetadata.ColumnNames.Descript, 2, typeof(System.String), esSystemType.String);
			c.PropertyName = TransaksiBKUMetadata.PropertyNames.Descript;
			c.CharacterMaxLength = 100;
			c.IsNullable = true;
			_columns.Add(c);
				
			c = new esColumnMetadata(TransaksiBKUMetadata.ColumnNames.KaCode, 3, typeof(System.String), esSystemType.String);
			c.PropertyName = TransaksiBKUMetadata.PropertyNames.KaCode;
			c.CharacterMaxLength = 15;
			_columns.Add(c);
				
			c = new esColumnMetadata(TransaksiBKUMetadata.ColumnNames.KaName, 4, typeof(System.String), esSystemType.String);
			c.PropertyName = TransaksiBKUMetadata.PropertyNames.KaName;
			c.CharacterMaxLength = 256;
			_columns.Add(c);
				
			c = new esColumnMetadata(TransaksiBKUMetadata.ColumnNames.GtCode, 5, typeof(System.String), esSystemType.String);
			c.PropertyName = TransaksiBKUMetadata.PropertyNames.GtCode;
			c.CharacterMaxLength = 15;
			_columns.Add(c);
				
			c = new esColumnMetadata(TransaksiBKUMetadata.ColumnNames.DebitAmount, 6, typeof(System.Decimal), esSystemType.Decimal);
			c.PropertyName = TransaksiBKUMetadata.PropertyNames.DebitAmount;
			c.NumericPrecision = 15;
			c.NumericScale = 2;
			c.IsNullable = true;
			_columns.Add(c);
				
			c = new esColumnMetadata(TransaksiBKUMetadata.ColumnNames.CreditAmount, 7, typeof(System.Decimal), esSystemType.Decimal);
			c.PropertyName = TransaksiBKUMetadata.PropertyNames.CreditAmount;
			c.NumericPrecision = 15;
			c.NumericScale = 2;
			c.IsNullable = true;
			_columns.Add(c);
				
			c = new esColumnMetadata(TransaksiBKUMetadata.ColumnNames.IsClosed, 8, typeof(System.Boolean), esSystemType.Boolean);
			c.PropertyName = TransaksiBKUMetadata.PropertyNames.IsClosed;
			_columns.Add(c);
				
			c = new esColumnMetadata(TransaksiBKUMetadata.ColumnNames.Isverified, 9, typeof(System.Boolean), esSystemType.Boolean);
			c.PropertyName = TransaksiBKUMetadata.PropertyNames.Isverified;
			_columns.Add(c);
				
			c = new esColumnMetadata(TransaksiBKUMetadata.ColumnNames.IsActive, 10, typeof(System.Boolean), esSystemType.Boolean);
			c.PropertyName = TransaksiBKUMetadata.PropertyNames.IsActive;
			_columns.Add(c);
				
		}
		#endregion	
	
		static public TransaksiBKUMetadata Meta()
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
			 public const string TransNumber = "TRANS_NUMBER";
			 public const string TransDate = "TRANS_DATE";
			 public const string Descript = "DESCRIPT";
			 public const string KaCode = "KA_CODE";
			 public const string KaName = "KA_NAME";
			 public const string GtCode = "GT_CODE";
			 public const string DebitAmount = "DEBIT_AMOUNT";
			 public const string CreditAmount = "CREDIT_AMOUNT";
			 public const string IsClosed = "IS_CLOSED";
			 public const string Isverified = "ISVERIFIED";
			 public const string IsActive = "IS_ACTIVE";
		}
		#endregion	
		
		#region PropertyNames
		public class PropertyNames
		{ 
			 public const string TransNumber = "TransNumber";
			 public const string TransDate = "TransDate";
			 public const string Descript = "Descript";
			 public const string KaCode = "KaCode";
			 public const string KaName = "KaName";
			 public const string GtCode = "GtCode";
			 public const string DebitAmount = "DebitAmount";
			 public const string CreditAmount = "CreditAmount";
			 public const string IsClosed = "IsClosed";
			 public const string Isverified = "Isverified";
			 public const string IsActive = "IsActive";
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
			lock (typeof(TransaksiBKUMetadata))
			{
				if(TransaksiBKUMetadata.mapDelegates == null)
				{
					TransaksiBKUMetadata.mapDelegates = new Dictionary<string,MapToMeta>();
				}
				
				if (TransaksiBKUMetadata.meta == null)
				{
					TransaksiBKUMetadata.meta = new TransaksiBKUMetadata();
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
				

				meta.AddTypeMap("TransNumber", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("TransDate", new esTypeMap("datetime", "System.DateTime"));
				meta.AddTypeMap("Descript", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("KaCode", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("KaName", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("GtCode", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("DebitAmount", new esTypeMap("numeric", "System.Decimal"));
				meta.AddTypeMap("CreditAmount", new esTypeMap("numeric", "System.Decimal"));
				meta.AddTypeMap("IsClosed", new esTypeMap("bit", "System.Boolean"));
				meta.AddTypeMap("Isverified", new esTypeMap("bit", "System.Boolean"));
				meta.AddTypeMap("IsActive", new esTypeMap("bit", "System.Boolean"));			
				
				
				
				meta.Source = "transaksiBKU";
				meta.Destination = "transaksiBKU";
				
				meta.spInsert = "proc_transaksiBKUInsert";				
				meta.spUpdate = "proc_transaksiBKUUpdate";		
				meta.spDelete = "proc_transaksiBKUDelete";
				meta.spLoadAll = "proc_transaksiBKULoadAll";
				meta.spLoadByPrimaryKey = "proc_transaksiBKULoadByPrimaryKey";
				
				this._providerMetadataMaps["esDefault"] = meta;
			}
			
			return this._providerMetadataMaps["esDefault"];
		}

		#endregion

		static private TransaksiBKUMetadata meta;
		static protected Dictionary<string, MapToMeta> mapDelegates;
		static private int _esDefault = RegisterDelegateesDefault();
	}
}
