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
	abstract public class esMonthlyBalanceCollection : esEntityCollection
	{
		public esMonthlyBalanceCollection()
		{

		}

		protected override string GetCollectionName()
		{
			return "MonthlyBalanceCollection";
		}

		#region Query Logic
		protected void InitQuery(esMonthlyBalanceQuery query)
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
			this.InitQuery(query as esMonthlyBalanceQuery);
		}
		#endregion
		
		virtual public MonthlyBalance DetachEntity(MonthlyBalance entity)
		{
			return base.DetachEntity(entity) as MonthlyBalance;
		}
		
		virtual public MonthlyBalance AttachEntity(MonthlyBalance entity)
		{
			return base.AttachEntity(entity) as MonthlyBalance;
		}
		
		virtual public void Combine(MonthlyBalanceCollection collection)
		{
			base.Combine(collection);
		}
		
		new public MonthlyBalance this[int index]
		{
			get
			{
				return base[index] as MonthlyBalance;
			}
		}

		public override Type GetEntityType()
		{
			return typeof(MonthlyBalance);
		}
	}



	[Serializable]
	abstract public class esMonthlyBalance : esEntity
	{
		/// <summary>
		/// Used internally by the entity's DynamicQuery mechanism.
		/// </summary>
		virtual protected esMonthlyBalanceQuery GetDynamicQuery()
		{
			return null;
		}

		public esMonthlyBalance()
		{

		}

		public esMonthlyBalance(DataRow row)
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
			esMonthlyBalanceQuery query = this.GetDynamicQuery();
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
						case "Month": this.str.Month = (string)value; break;							
						case "Year": this.str.Year = (string)value; break;							
						case "InitBalance": this.str.InitBalance = (string)value; break;							
						case "Debit": this.str.Debit = (string)value; break;							
						case "Kredit": this.str.Kredit = (string)value; break;							
						case "FinalBalance": this.str.FinalBalance = (string)value; break;							
						case "UserInsert": this.str.UserInsert = (string)value; break;							
						case "UserUpdate": this.str.UserUpdate = (string)value; break;							
						case "TglInsert": this.str.TglInsert = (string)value; break;							
						case "TglUpdate": this.str.TglUpdate = (string)value; break;
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
						
						case "InitBalance":
						
							if (value == null || value is System.Decimal)
								this.InitBalance = (System.Decimal?)value;
							break;
						
						case "Debit":
						
							if (value == null || value is System.Decimal)
								this.Debit = (System.Decimal?)value;
							break;
						
						case "Kredit":
						
							if (value == null || value is System.Decimal)
								this.Kredit = (System.Decimal?)value;
							break;
						
						case "FinalBalance":
						
							if (value == null || value is System.Decimal)
								this.FinalBalance = (System.Decimal?)value;
							break;
						
						case "TglInsert":
						
							if (value == null || value is System.DateTime)
								this.TglInsert = (System.DateTime?)value;
							break;
						
						case "TglUpdate":
						
							if (value == null || value is System.DateTime)
								this.TglUpdate = (System.DateTime?)value;
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
		/// Maps to Monthly_Balance.id
		/// </summary>
		virtual public System.Int64? Id
		{
			get
			{
				return base.GetSystemInt64(MonthlyBalanceMetadata.ColumnNames.Id);
			}
			
			set
			{
				base.SetSystemInt64(MonthlyBalanceMetadata.ColumnNames.Id, value);
			}
		}
		
		/// <summary>
		/// Maps to Monthly_Balance.KA_CODE
		/// </summary>
		virtual public System.String KaCode
		{
			get
			{
				return base.GetSystemString(MonthlyBalanceMetadata.ColumnNames.KaCode);
			}
			
			set
			{
				base.SetSystemString(MonthlyBalanceMetadata.ColumnNames.KaCode, value);
			}
		}
		
		/// <summary>
		/// Maps to Monthly_Balance.MONTH
		/// </summary>
		virtual public System.String Month
		{
			get
			{
				return base.GetSystemString(MonthlyBalanceMetadata.ColumnNames.Month);
			}
			
			set
			{
				base.SetSystemString(MonthlyBalanceMetadata.ColumnNames.Month, value);
			}
		}
		
		/// <summary>
		/// Maps to Monthly_Balance.YEAR
		/// </summary>
		virtual public System.String Year
		{
			get
			{
				return base.GetSystemString(MonthlyBalanceMetadata.ColumnNames.Year);
			}
			
			set
			{
				base.SetSystemString(MonthlyBalanceMetadata.ColumnNames.Year, value);
			}
		}
		
		/// <summary>
		/// Maps to Monthly_Balance.INIT_BALANCE
		/// </summary>
		virtual public System.Decimal? InitBalance
		{
			get
			{
				return base.GetSystemDecimal(MonthlyBalanceMetadata.ColumnNames.InitBalance);
			}
			
			set
			{
				base.SetSystemDecimal(MonthlyBalanceMetadata.ColumnNames.InitBalance, value);
			}
		}
		
		/// <summary>
		/// Maps to Monthly_Balance.DEBIT
		/// </summary>
		virtual public System.Decimal? Debit
		{
			get
			{
				return base.GetSystemDecimal(MonthlyBalanceMetadata.ColumnNames.Debit);
			}
			
			set
			{
				base.SetSystemDecimal(MonthlyBalanceMetadata.ColumnNames.Debit, value);
			}
		}
		
		/// <summary>
		/// Maps to Monthly_Balance.KREDIT
		/// </summary>
		virtual public System.Decimal? Kredit
		{
			get
			{
				return base.GetSystemDecimal(MonthlyBalanceMetadata.ColumnNames.Kredit);
			}
			
			set
			{
				base.SetSystemDecimal(MonthlyBalanceMetadata.ColumnNames.Kredit, value);
			}
		}
		
		/// <summary>
		/// Maps to Monthly_Balance.FINAL_BALANCE
		/// </summary>
		virtual public System.Decimal? FinalBalance
		{
			get
			{
				return base.GetSystemDecimal(MonthlyBalanceMetadata.ColumnNames.FinalBalance);
			}
			
			set
			{
				base.SetSystemDecimal(MonthlyBalanceMetadata.ColumnNames.FinalBalance, value);
			}
		}
		
		/// <summary>
		/// Maps to Monthly_Balance.USER_INSERT
		/// </summary>
		virtual public System.String UserInsert
		{
			get
			{
				return base.GetSystemString(MonthlyBalanceMetadata.ColumnNames.UserInsert);
			}
			
			set
			{
				base.SetSystemString(MonthlyBalanceMetadata.ColumnNames.UserInsert, value);
			}
		}
		
		/// <summary>
		/// Maps to Monthly_Balance.USER_UPDATE
		/// </summary>
		virtual public System.String UserUpdate
		{
			get
			{
				return base.GetSystemString(MonthlyBalanceMetadata.ColumnNames.UserUpdate);
			}
			
			set
			{
				base.SetSystemString(MonthlyBalanceMetadata.ColumnNames.UserUpdate, value);
			}
		}
		
		/// <summary>
		/// Maps to Monthly_Balance.TGL_INSERT
		/// </summary>
		virtual public System.DateTime? TglInsert
		{
			get
			{
				return base.GetSystemDateTime(MonthlyBalanceMetadata.ColumnNames.TglInsert);
			}
			
			set
			{
				base.SetSystemDateTime(MonthlyBalanceMetadata.ColumnNames.TglInsert, value);
			}
		}
		
		/// <summary>
		/// Maps to Monthly_Balance.TGL_UPDATE
		/// </summary>
		virtual public System.DateTime? TglUpdate
		{
			get
			{
				return base.GetSystemDateTime(MonthlyBalanceMetadata.ColumnNames.TglUpdate);
			}
			
			set
			{
				base.SetSystemDateTime(MonthlyBalanceMetadata.ColumnNames.TglUpdate, value);
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
			public esStrings(esMonthlyBalance entity)
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
				
			public System.String Month
			{
				get
				{
					System.String data = entity.Month;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.Month = null;
					else entity.Month = Convert.ToString(value);
				}
			}
				
			public System.String Year
			{
				get
				{
					System.String data = entity.Year;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.Year = null;
					else entity.Year = Convert.ToString(value);
				}
			}
				
			public System.String InitBalance
			{
				get
				{
					System.Decimal? data = entity.InitBalance;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.InitBalance = null;
					else entity.InitBalance = Convert.ToDecimal(value);
				}
			}
				
			public System.String Debit
			{
				get
				{
					System.Decimal? data = entity.Debit;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.Debit = null;
					else entity.Debit = Convert.ToDecimal(value);
				}
			}
				
			public System.String Kredit
			{
				get
				{
					System.Decimal? data = entity.Kredit;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.Kredit = null;
					else entity.Kredit = Convert.ToDecimal(value);
				}
			}
				
			public System.String FinalBalance
			{
				get
				{
					System.Decimal? data = entity.FinalBalance;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.FinalBalance = null;
					else entity.FinalBalance = Convert.ToDecimal(value);
				}
			}
				
			public System.String UserInsert
			{
				get
				{
					System.String data = entity.UserInsert;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.UserInsert = null;
					else entity.UserInsert = Convert.ToString(value);
				}
			}
				
			public System.String UserUpdate
			{
				get
				{
					System.String data = entity.UserUpdate;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.UserUpdate = null;
					else entity.UserUpdate = Convert.ToString(value);
				}
			}
				
			public System.String TglInsert
			{
				get
				{
					System.DateTime? data = entity.TglInsert;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.TglInsert = null;
					else entity.TglInsert = Convert.ToDateTime(value);
				}
			}
				
			public System.String TglUpdate
			{
				get
				{
					System.DateTime? data = entity.TglUpdate;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.TglUpdate = null;
					else entity.TglUpdate = Convert.ToDateTime(value);
				}
			}
			

			private esMonthlyBalance entity;
		}
		#endregion

		#region Query Logic
		protected void InitQuery(esMonthlyBalanceQuery query)
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
				throw new Exception("esMonthlyBalance can only hold one record of data");
			}

			return dataFound;
		}
		#endregion
		
		[NonSerialized]
		private esStrings esstrings;
	}


	
	public partial class MonthlyBalance : esMonthlyBalance
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
	abstract public class esMonthlyBalanceQuery : esDynamicQuery
	{
		override protected IMetadata Meta
		{
			get
			{
				return MonthlyBalanceMetadata.Meta();
			}
		}	
		

		public esQueryItem Id
		{
			get
			{
				return new esQueryItem(this, MonthlyBalanceMetadata.ColumnNames.Id, esSystemType.Int64);
			}
		} 
		
		public esQueryItem KaCode
		{
			get
			{
				return new esQueryItem(this, MonthlyBalanceMetadata.ColumnNames.KaCode, esSystemType.String);
			}
		} 
		
		public esQueryItem Month
		{
			get
			{
				return new esQueryItem(this, MonthlyBalanceMetadata.ColumnNames.Month, esSystemType.String);
			}
		} 
		
		public esQueryItem Year
		{
			get
			{
				return new esQueryItem(this, MonthlyBalanceMetadata.ColumnNames.Year, esSystemType.String);
			}
		} 
		
		public esQueryItem InitBalance
		{
			get
			{
				return new esQueryItem(this, MonthlyBalanceMetadata.ColumnNames.InitBalance, esSystemType.Decimal);
			}
		} 
		
		public esQueryItem Debit
		{
			get
			{
				return new esQueryItem(this, MonthlyBalanceMetadata.ColumnNames.Debit, esSystemType.Decimal);
			}
		} 
		
		public esQueryItem Kredit
		{
			get
			{
				return new esQueryItem(this, MonthlyBalanceMetadata.ColumnNames.Kredit, esSystemType.Decimal);
			}
		} 
		
		public esQueryItem FinalBalance
		{
			get
			{
				return new esQueryItem(this, MonthlyBalanceMetadata.ColumnNames.FinalBalance, esSystemType.Decimal);
			}
		} 
		
		public esQueryItem UserInsert
		{
			get
			{
				return new esQueryItem(this, MonthlyBalanceMetadata.ColumnNames.UserInsert, esSystemType.String);
			}
		} 
		
		public esQueryItem UserUpdate
		{
			get
			{
				return new esQueryItem(this, MonthlyBalanceMetadata.ColumnNames.UserUpdate, esSystemType.String);
			}
		} 
		
		public esQueryItem TglInsert
		{
			get
			{
				return new esQueryItem(this, MonthlyBalanceMetadata.ColumnNames.TglInsert, esSystemType.DateTime);
			}
		} 
		
		public esQueryItem TglUpdate
		{
			get
			{
				return new esQueryItem(this, MonthlyBalanceMetadata.ColumnNames.TglUpdate, esSystemType.DateTime);
			}
		} 
		
	}



    [System.Diagnostics.DebuggerDisplay("Count = {Count}")]
	[Serializable]
	[XmlType("MonthlyBalanceCollection")]
	public partial class MonthlyBalanceCollection : esMonthlyBalanceCollection, IEnumerable<MonthlyBalance>
	{
		public MonthlyBalanceCollection()
		{

		}
		
		public static implicit operator List<MonthlyBalance>(MonthlyBalanceCollection coll)
		{
			List<MonthlyBalance> list = new List<MonthlyBalance>();
			
			foreach (MonthlyBalance emp in coll)
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
				return  MonthlyBalanceMetadata.Meta();
			}
		}
		
		
		
		override protected esDynamicQuery GetDynamicQuery()
		{
			if (this.query == null)
			{
				this.query = new MonthlyBalanceQuery();
				this.InitQuery(query);
			}
			return this.query;
		}
		
		override protected esEntity CreateEntityForCollection(DataRow row)
		{
			return new MonthlyBalance(row);
		}

		override protected esEntity CreateEntity()
		{
			return new MonthlyBalance();
		}
		
		
		#endregion


		[BrowsableAttribute( false )]
		public MonthlyBalanceQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new MonthlyBalanceQuery();
					base.InitQuery(this.query);
				}

				return this.query;
			}
		}

		public void QueryReset()
		{
			this.query = null;
		}

		public bool Load(MonthlyBalanceQuery query)
		{
			this.query = query;
			base.InitQuery(this.query);
			return this.Query.Load();
		}
		
		public MonthlyBalance AddNew()
		{
			MonthlyBalance entity = base.AddNewEntity() as MonthlyBalance;
			
			return entity;
		}

		public MonthlyBalance FindByPrimaryKey(System.Int64 id)
		{
			return base.FindByPrimaryKey(id) as MonthlyBalance;
		}


		#region IEnumerable<MonthlyBalance> Members

		IEnumerator<MonthlyBalance> IEnumerable<MonthlyBalance>.GetEnumerator()
		{
			System.Collections.IEnumerable enumer = this as System.Collections.IEnumerable;
			System.Collections.IEnumerator iterator = enumer.GetEnumerator();

			while(iterator.MoveNext())
			{
				yield return iterator.Current as MonthlyBalance;
			}
		}

		#endregion
		
		private MonthlyBalanceQuery query;
	}


	/// <summary>
	/// Encapsulates the 'Monthly_Balance' table
	/// </summary>

    [System.Diagnostics.DebuggerDisplay("MonthlyBalance ({Id})")]
	[Serializable]
	public partial class MonthlyBalance : esMonthlyBalance
	{
		public MonthlyBalance()
		{

		}
	
		public MonthlyBalance(DataRow row)
			: base(row)
		{

		}
		
		#region Housekeeping methods
		override protected IMetadata Meta
		{
			get
			{
				return MonthlyBalanceMetadata.Meta();
			}
		}
		
		
		
		override protected esMonthlyBalanceQuery GetDynamicQuery()
		{
			if (this.query == null)
			{
				this.query = new MonthlyBalanceQuery();
				this.InitQuery(query);
			}
			return this.query;
		}
		#endregion
		



		[BrowsableAttribute( false )]
		public MonthlyBalanceQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new MonthlyBalanceQuery();
					base.InitQuery(this.query);
				}

				return this.query;
			}
		}

		public void QueryReset()
		{
			this.query = null;
		}
		

		public bool Load(MonthlyBalanceQuery query)
		{
			this.query = query;
			base.InitQuery(this.query);
			return this.Query.Load();
		}
		
		private MonthlyBalanceQuery query;
	}



    [System.Diagnostics.DebuggerDisplay("LastQuery = {es.LastQuery}")]
	[Serializable]
		
	public partial class MonthlyBalanceQuery : esMonthlyBalanceQuery
	{
		public MonthlyBalanceQuery()
		{

		}		
		
		public MonthlyBalanceQuery(string joinAlias)
		{
			this.es.JoinAlias = joinAlias;
		}	

        override protected string GetQueryName()
        {
            return "MonthlyBalanceQuery";
        }
		
			
	}


	[Serializable]
	public partial class MonthlyBalanceMetadata : esMetadata, IMetadata
	{
		#region Protected Constructor
		protected MonthlyBalanceMetadata()
		{
			_columns = new esColumnMetadataCollection();
			esColumnMetadata c;

			c = new esColumnMetadata(MonthlyBalanceMetadata.ColumnNames.Id, 0, typeof(System.Int64), esSystemType.Int64);
			c.PropertyName = MonthlyBalanceMetadata.PropertyNames.Id;
			c.IsInPrimaryKey = true;
			c.IsAutoIncrement = true;
			c.NumericPrecision = 19;
			_columns.Add(c);
				
			c = new esColumnMetadata(MonthlyBalanceMetadata.ColumnNames.KaCode, 1, typeof(System.String), esSystemType.String);
			c.PropertyName = MonthlyBalanceMetadata.PropertyNames.KaCode;
			c.CharacterMaxLength = 15;
			_columns.Add(c);
				
			c = new esColumnMetadata(MonthlyBalanceMetadata.ColumnNames.Month, 2, typeof(System.String), esSystemType.String);
			c.PropertyName = MonthlyBalanceMetadata.PropertyNames.Month;
			c.CharacterMaxLength = 2;
			_columns.Add(c);
				
			c = new esColumnMetadata(MonthlyBalanceMetadata.ColumnNames.Year, 3, typeof(System.String), esSystemType.String);
			c.PropertyName = MonthlyBalanceMetadata.PropertyNames.Year;
			c.CharacterMaxLength = 4;
			_columns.Add(c);
				
			c = new esColumnMetadata(MonthlyBalanceMetadata.ColumnNames.InitBalance, 4, typeof(System.Decimal), esSystemType.Decimal);
			c.PropertyName = MonthlyBalanceMetadata.PropertyNames.InitBalance;
			c.NumericPrecision = 18;
			c.NumericScale = 2;
			c.HasDefault = true;
			c.Default = @"((0))";
			_columns.Add(c);
				
			c = new esColumnMetadata(MonthlyBalanceMetadata.ColumnNames.Debit, 5, typeof(System.Decimal), esSystemType.Decimal);
			c.PropertyName = MonthlyBalanceMetadata.PropertyNames.Debit;
			c.NumericPrecision = 18;
			c.NumericScale = 2;
			c.HasDefault = true;
			c.Default = @"((0))";
			_columns.Add(c);
				
			c = new esColumnMetadata(MonthlyBalanceMetadata.ColumnNames.Kredit, 6, typeof(System.Decimal), esSystemType.Decimal);
			c.PropertyName = MonthlyBalanceMetadata.PropertyNames.Kredit;
			c.NumericPrecision = 18;
			c.NumericScale = 2;
			c.HasDefault = true;
			c.Default = @"((0))";
			_columns.Add(c);
				
			c = new esColumnMetadata(MonthlyBalanceMetadata.ColumnNames.FinalBalance, 7, typeof(System.Decimal), esSystemType.Decimal);
			c.PropertyName = MonthlyBalanceMetadata.PropertyNames.FinalBalance;
			c.NumericPrecision = 18;
			c.NumericScale = 2;
			c.HasDefault = true;
			c.Default = @"((0))";
			_columns.Add(c);
				
			c = new esColumnMetadata(MonthlyBalanceMetadata.ColumnNames.UserInsert, 8, typeof(System.String), esSystemType.String);
			c.PropertyName = MonthlyBalanceMetadata.PropertyNames.UserInsert;
			c.CharacterMaxLength = 50;
			c.IsNullable = true;
			_columns.Add(c);
				
			c = new esColumnMetadata(MonthlyBalanceMetadata.ColumnNames.UserUpdate, 9, typeof(System.String), esSystemType.String);
			c.PropertyName = MonthlyBalanceMetadata.PropertyNames.UserUpdate;
			c.CharacterMaxLength = 50;
			c.IsNullable = true;
			_columns.Add(c);
				
			c = new esColumnMetadata(MonthlyBalanceMetadata.ColumnNames.TglInsert, 10, typeof(System.DateTime), esSystemType.DateTime);
			c.PropertyName = MonthlyBalanceMetadata.PropertyNames.TglInsert;
			c.IsNullable = true;
			_columns.Add(c);
				
			c = new esColumnMetadata(MonthlyBalanceMetadata.ColumnNames.TglUpdate, 11, typeof(System.DateTime), esSystemType.DateTime);
			c.PropertyName = MonthlyBalanceMetadata.PropertyNames.TglUpdate;
			c.IsNullable = true;
			_columns.Add(c);
				
		}
		#endregion	
	
		static public MonthlyBalanceMetadata Meta()
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
			 public const string Month = "MONTH";
			 public const string Year = "YEAR";
			 public const string InitBalance = "INIT_BALANCE";
			 public const string Debit = "DEBIT";
			 public const string Kredit = "KREDIT";
			 public const string FinalBalance = "FINAL_BALANCE";
			 public const string UserInsert = "USER_INSERT";
			 public const string UserUpdate = "USER_UPDATE";
			 public const string TglInsert = "TGL_INSERT";
			 public const string TglUpdate = "TGL_UPDATE";
		}
		#endregion	
		
		#region PropertyNames
		public class PropertyNames
		{ 
			 public const string Id = "Id";
			 public const string KaCode = "KaCode";
			 public const string Month = "Month";
			 public const string Year = "Year";
			 public const string InitBalance = "InitBalance";
			 public const string Debit = "Debit";
			 public const string Kredit = "Kredit";
			 public const string FinalBalance = "FinalBalance";
			 public const string UserInsert = "UserInsert";
			 public const string UserUpdate = "UserUpdate";
			 public const string TglInsert = "TglInsert";
			 public const string TglUpdate = "TglUpdate";
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
			lock (typeof(MonthlyBalanceMetadata))
			{
				if(MonthlyBalanceMetadata.mapDelegates == null)
				{
					MonthlyBalanceMetadata.mapDelegates = new Dictionary<string,MapToMeta>();
				}
				
				if (MonthlyBalanceMetadata.meta == null)
				{
					MonthlyBalanceMetadata.meta = new MonthlyBalanceMetadata();
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
				meta.AddTypeMap("Month", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("Year", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("InitBalance", new esTypeMap("numeric", "System.Decimal"));
				meta.AddTypeMap("Debit", new esTypeMap("numeric", "System.Decimal"));
				meta.AddTypeMap("Kredit", new esTypeMap("numeric", "System.Decimal"));
				meta.AddTypeMap("FinalBalance", new esTypeMap("numeric", "System.Decimal"));
				meta.AddTypeMap("UserInsert", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("UserUpdate", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("TglInsert", new esTypeMap("datetime", "System.DateTime"));
				meta.AddTypeMap("TglUpdate", new esTypeMap("datetime", "System.DateTime"));			
				
				
				
				meta.Source = "Monthly_Balance";
				meta.Destination = "Monthly_Balance";
				
				meta.spInsert = "proc_Monthly_BalanceInsert";				
				meta.spUpdate = "proc_Monthly_BalanceUpdate";		
				meta.spDelete = "proc_Monthly_BalanceDelete";
				meta.spLoadAll = "proc_Monthly_BalanceLoadAll";
				meta.spLoadByPrimaryKey = "proc_Monthly_BalanceLoadByPrimaryKey";
				
				this._providerMetadataMaps["esDefault"] = meta;
			}
			
			return this._providerMetadataMaps["esDefault"];
		}

		#endregion

		static private MonthlyBalanceMetadata meta;
		static protected Dictionary<string, MapToMeta> mapDelegates;
		static private int _esDefault = RegisterDelegateesDefault();
	}
}
