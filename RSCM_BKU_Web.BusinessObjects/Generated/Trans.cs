/*
===============================================================================
                    EntitySpaces 2009 by EntitySpaces, LLC
             Persistence Layer and Business Objects for Microsoft .NET
             EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
                          http://www.entityspaces.net
===============================================================================
EntitySpaces Version : 2009.2.1214.0
EntitySpaces Driver  : SQL
Date Generated       : 15/03/2011 11:27:34
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
	abstract public class esTransCollection : esEntityCollection
	{
		public esTransCollection()
		{

		}

		protected override string GetCollectionName()
		{
			return "TransCollection";
		}

		#region Query Logic
		protected void InitQuery(esTransQuery query)
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
			this.InitQuery(query as esTransQuery);
		}
		#endregion
		
		virtual public Trans DetachEntity(Trans entity)
		{
			return base.DetachEntity(entity) as Trans;
		}
		
		virtual public Trans AttachEntity(Trans entity)
		{
			return base.AttachEntity(entity) as Trans;
		}
		
		virtual public void Combine(TransCollection collection)
		{
			base.Combine(collection);
		}
		
		new public Trans this[int index]
		{
			get
			{
				return base[index] as Trans;
			}
		}

		public override Type GetEntityType()
		{
			return typeof(Trans);
		}
	}



	[Serializable]
	abstract public class esTrans : esEntity
	{
		/// <summary>
		/// Used internally by the entity's DynamicQuery mechanism.
		/// </summary>
		virtual protected esTransQuery GetDynamicQuery()
		{
			return null;
		}

		public esTrans()
		{

		}

		public esTrans(DataRow row)
			: base(row)
		{

		}
		
		#region LoadByPrimaryKey
		public virtual bool LoadByPrimaryKey(System.Int64 bkuId)
		{
			if(this.es.Connection.SqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(bkuId);
			else
				return LoadByPrimaryKeyStoredProcedure(bkuId);
		}

		public virtual bool LoadByPrimaryKey(esSqlAccessType sqlAccessType, System.Int64 bkuId)
		{
			if (sqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(bkuId);
			else
				return LoadByPrimaryKeyStoredProcedure(bkuId);
		}

		private bool LoadByPrimaryKeyDynamic(System.Int64 bkuId)
		{
			esTransQuery query = this.GetDynamicQuery();
			query.Where(query.BkuId == bkuId);
			return query.Load();
		}

		private bool LoadByPrimaryKeyStoredProcedure(System.Int64 bkuId)
		{
			esParameters parms = new esParameters();
			parms.Add("BKU_ID",bkuId);
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
						case "BkuId": this.str.BkuId = (string)value; break;							
						case "KaCode": this.str.KaCode = (string)value; break;							
						case "TransNumber": this.str.TransNumber = (string)value; break;							
						case "TransDate": this.str.TransDate = (string)value; break;							
						case "Descript": this.str.Descript = (string)value; break;							
						case "DebitAmount": this.str.DebitAmount = (string)value; break;							
						case "CreditAmount": this.str.CreditAmount = (string)value; break;							
						case "CekBgNumber": this.str.CekBgNumber = (string)value; break;							
						case "PeriodId": this.str.PeriodId = (string)value; break;							
						case "Isverified": this.str.Isverified = (string)value; break;							
						case "IsClosed": this.str.IsClosed = (string)value; break;							
						case "KasId": this.str.KasId = (string)value; break;							
						case "UserInsert": this.str.UserInsert = (string)value; break;							
						case "TglInsert": this.str.TglInsert = (string)value; break;							
						case "UserUpdate": this.str.UserUpdate = (string)value; break;							
						case "TglUpdate": this.str.TglUpdate = (string)value; break;
					}
				}
				else
				{
					switch (name)
					{	
						case "BkuId":
						
							if (value == null || value is System.Int64)
								this.BkuId = (System.Int64?)value;
							break;
						
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
						
						case "PeriodId":
						
							if (value == null || value is System.Int64)
								this.PeriodId = (System.Int64?)value;
							break;
						
						case "Isverified":
						
							if (value == null || value is System.Boolean)
								this.Isverified = (System.Boolean?)value;
							break;
						
						case "IsClosed":
						
							if (value == null || value is System.Boolean)
								this.IsClosed = (System.Boolean?)value;
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
		/// Maps to Trans.BKU_ID
		/// </summary>
		virtual public System.Int64? BkuId
		{
			get
			{
				return base.GetSystemInt64(TransMetadata.ColumnNames.BkuId);
			}
			
			set
			{
				base.SetSystemInt64(TransMetadata.ColumnNames.BkuId, value);
			}
		}
		
		/// <summary>
		/// Maps to Trans.KA_CODE
		/// </summary>
		virtual public System.String KaCode
		{
			get
			{
				return base.GetSystemString(TransMetadata.ColumnNames.KaCode);
			}
			
			set
			{
				if(base.SetSystemString(TransMetadata.ColumnNames.KaCode, value))
				{
					this._UpToKelAnggaranByKaCode = null;
				}
			}
		}
		
		/// <summary>
		/// Maps to Trans.TRANS_NUMBER
		/// </summary>
		virtual public System.String TransNumber
		{
			get
			{
				return base.GetSystemString(TransMetadata.ColumnNames.TransNumber);
			}
			
			set
			{
				base.SetSystemString(TransMetadata.ColumnNames.TransNumber, value);
			}
		}
		
		/// <summary>
		/// Maps to Trans.TRANS_DATE
		/// </summary>
		virtual public System.DateTime? TransDate
		{
			get
			{
				return base.GetSystemDateTime(TransMetadata.ColumnNames.TransDate);
			}
			
			set
			{
				base.SetSystemDateTime(TransMetadata.ColumnNames.TransDate, value);
			}
		}
		
		/// <summary>
		/// Maps to Trans.DESCRIPT
		/// </summary>
		virtual public System.String Descript
		{
			get
			{
				return base.GetSystemString(TransMetadata.ColumnNames.Descript);
			}
			
			set
			{
				base.SetSystemString(TransMetadata.ColumnNames.Descript, value);
			}
		}
		
		/// <summary>
		/// Maps to Trans.DEBIT_AMOUNT
		/// </summary>
		virtual public System.Decimal? DebitAmount
		{
			get
			{
				return base.GetSystemDecimal(TransMetadata.ColumnNames.DebitAmount);
			}
			
			set
			{
				base.SetSystemDecimal(TransMetadata.ColumnNames.DebitAmount, value);
			}
		}
		
		/// <summary>
		/// Maps to Trans.CREDIT_AMOUNT
		/// </summary>
		virtual public System.Decimal? CreditAmount
		{
			get
			{
				return base.GetSystemDecimal(TransMetadata.ColumnNames.CreditAmount);
			}
			
			set
			{
				base.SetSystemDecimal(TransMetadata.ColumnNames.CreditAmount, value);
			}
		}
		
		/// <summary>
		/// Maps to Trans.CEK_BG_NUMBER
		/// </summary>
		virtual public System.String CekBgNumber
		{
			get
			{
				return base.GetSystemString(TransMetadata.ColumnNames.CekBgNumber);
			}
			
			set
			{
				base.SetSystemString(TransMetadata.ColumnNames.CekBgNumber, value);
			}
		}
		
		/// <summary>
		/// Maps to Trans.PERIOD_ID
		/// </summary>
		virtual public System.Int64? PeriodId
		{
			get
			{
				return base.GetSystemInt64(TransMetadata.ColumnNames.PeriodId);
			}
			
			set
			{
				if(base.SetSystemInt64(TransMetadata.ColumnNames.PeriodId, value))
				{
					this._UpToPeriodeAnggaranByPeriodId = null;
				}
			}
		}
		
		/// <summary>
		/// Maps to Trans.ISVERIFIED
		/// </summary>
		virtual public System.Boolean? Isverified
		{
			get
			{
				return base.GetSystemBoolean(TransMetadata.ColumnNames.Isverified);
			}
			
			set
			{
				base.SetSystemBoolean(TransMetadata.ColumnNames.Isverified, value);
			}
		}
		
		/// <summary>
		/// Maps to Trans.IS_CLOSED
		/// </summary>
		virtual public System.Boolean? IsClosed
		{
			get
			{
				return base.GetSystemBoolean(TransMetadata.ColumnNames.IsClosed);
			}
			
			set
			{
				base.SetSystemBoolean(TransMetadata.ColumnNames.IsClosed, value);
			}
		}
		
		/// <summary>
		/// Maps to Trans.KAS_ID
		/// </summary>
		virtual public System.String KasId
		{
			get
			{
				return base.GetSystemString(TransMetadata.ColumnNames.KasId);
			}
			
			set
			{
				base.SetSystemString(TransMetadata.ColumnNames.KasId, value);
			}
		}
		
		/// <summary>
		/// Maps to Trans.USER_INSERT
		/// </summary>
		virtual public System.String UserInsert
		{
			get
			{
				return base.GetSystemString(TransMetadata.ColumnNames.UserInsert);
			}
			
			set
			{
				base.SetSystemString(TransMetadata.ColumnNames.UserInsert, value);
			}
		}
		
		/// <summary>
		/// Maps to Trans.TGL_INSERT
		/// </summary>
		virtual public System.DateTime? TglInsert
		{
			get
			{
				return base.GetSystemDateTime(TransMetadata.ColumnNames.TglInsert);
			}
			
			set
			{
				base.SetSystemDateTime(TransMetadata.ColumnNames.TglInsert, value);
			}
		}
		
		/// <summary>
		/// Maps to Trans.USER_UPDATE
		/// </summary>
		virtual public System.String UserUpdate
		{
			get
			{
				return base.GetSystemString(TransMetadata.ColumnNames.UserUpdate);
			}
			
			set
			{
				base.SetSystemString(TransMetadata.ColumnNames.UserUpdate, value);
			}
		}
		
		/// <summary>
		/// Maps to Trans.TGL_UPDATE
		/// </summary>
		virtual public System.DateTime? TglUpdate
		{
			get
			{
				return base.GetSystemDateTime(TransMetadata.ColumnNames.TglUpdate);
			}
			
			set
			{
				base.SetSystemDateTime(TransMetadata.ColumnNames.TglUpdate, value);
			}
		}
		
		[CLSCompliant(false)]
		internal protected KelAnggaran _UpToKelAnggaranByKaCode;
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
			public esStrings(esTrans entity)
			{
				this.entity = entity;
			}
			
	
			public System.String BkuId
			{
				get
				{
					System.Int64? data = entity.BkuId;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.BkuId = null;
					else entity.BkuId = Convert.ToInt64(value);
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
				
			public System.String CekBgNumber
			{
				get
				{
					System.String data = entity.CekBgNumber;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.CekBgNumber = null;
					else entity.CekBgNumber = Convert.ToString(value);
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
				
			public System.String KasId
			{
				get
				{
					System.String data = entity.KasId;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.KasId = null;
					else entity.KasId = Convert.ToString(value);
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
			

			private esTrans entity;
		}
		#endregion

		#region Query Logic
		protected void InitQuery(esTransQuery query)
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
				throw new Exception("esTrans can only hold one record of data");
			}

			return dataFound;
		}
		#endregion
		
		[NonSerialized]
		private esStrings esstrings;
	}


	
	public partial class Trans : esTrans
	{

				
		#region UpToKelAnggaranByKaCode - Many To One
		/// <summary>
		/// Many to One
		/// Foreign Key Name - FK_Trans_Kel_anggaran
		/// </summary>

		[XmlIgnore]
		public KelAnggaran UpToKelAnggaranByKaCode
		{
			get
			{
				if(this._UpToKelAnggaranByKaCode == null
					&& KaCode != null					)
				{
					this._UpToKelAnggaranByKaCode = new KelAnggaran();
					this._UpToKelAnggaranByKaCode.es.Connection.Name = this.es.Connection.Name;
					this.SetPreSave("UpToKelAnggaranByKaCode", this._UpToKelAnggaranByKaCode);
					this._UpToKelAnggaranByKaCode.Query.Where(this._UpToKelAnggaranByKaCode.Query.KaCode == this.KaCode);
					this._UpToKelAnggaranByKaCode.Query.Load();
				}

				return this._UpToKelAnggaranByKaCode;
			}
			
			set
			{
				this.RemovePreSave("UpToKelAnggaranByKaCode");
				

				if(value == null)
				{
					this.KaCode = null;
					this._UpToKelAnggaranByKaCode = null;
				}
				else
				{
					this.KaCode = value.KaCode;
					this._UpToKelAnggaranByKaCode = value;
					this.SetPreSave("UpToKelAnggaranByKaCode", this._UpToKelAnggaranByKaCode);
				}
				
			}
		}
		#endregion
		

				
		#region UpToPeriodeAnggaranByPeriodId - Many To One
		/// <summary>
		/// Many to One
		/// Foreign Key Name - FK_Trans_PeriodeAnggaran
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
			if(!this.es.IsDeleted && this._UpToKelAnggaranByKaCode != null)
			{
				this.KaCode = this._UpToKelAnggaranByKaCode.KaCode;
			}
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
	abstract public class esTransQuery : esDynamicQuery
	{
		override protected IMetadata Meta
		{
			get
			{
				return TransMetadata.Meta();
			}
		}	
		

		public esQueryItem BkuId
		{
			get
			{
				return new esQueryItem(this, TransMetadata.ColumnNames.BkuId, esSystemType.Int64);
			}
		} 
		
		public esQueryItem KaCode
		{
			get
			{
				return new esQueryItem(this, TransMetadata.ColumnNames.KaCode, esSystemType.String);
			}
		} 
		
		public esQueryItem TransNumber
		{
			get
			{
				return new esQueryItem(this, TransMetadata.ColumnNames.TransNumber, esSystemType.String);
			}
		} 
		
		public esQueryItem TransDate
		{
			get
			{
				return new esQueryItem(this, TransMetadata.ColumnNames.TransDate, esSystemType.DateTime);
			}
		} 
		
		public esQueryItem Descript
		{
			get
			{
				return new esQueryItem(this, TransMetadata.ColumnNames.Descript, esSystemType.String);
			}
		} 
		
		public esQueryItem DebitAmount
		{
			get
			{
				return new esQueryItem(this, TransMetadata.ColumnNames.DebitAmount, esSystemType.Decimal);
			}
		} 
		
		public esQueryItem CreditAmount
		{
			get
			{
				return new esQueryItem(this, TransMetadata.ColumnNames.CreditAmount, esSystemType.Decimal);
			}
		} 
		
		public esQueryItem CekBgNumber
		{
			get
			{
				return new esQueryItem(this, TransMetadata.ColumnNames.CekBgNumber, esSystemType.String);
			}
		} 
		
		public esQueryItem PeriodId
		{
			get
			{
				return new esQueryItem(this, TransMetadata.ColumnNames.PeriodId, esSystemType.Int64);
			}
		} 
		
		public esQueryItem Isverified
		{
			get
			{
				return new esQueryItem(this, TransMetadata.ColumnNames.Isverified, esSystemType.Boolean);
			}
		} 
		
		public esQueryItem IsClosed
		{
			get
			{
				return new esQueryItem(this, TransMetadata.ColumnNames.IsClosed, esSystemType.Boolean);
			}
		} 
		
		public esQueryItem KasId
		{
			get
			{
				return new esQueryItem(this, TransMetadata.ColumnNames.KasId, esSystemType.String);
			}
		} 
		
		public esQueryItem UserInsert
		{
			get
			{
				return new esQueryItem(this, TransMetadata.ColumnNames.UserInsert, esSystemType.String);
			}
		} 
		
		public esQueryItem TglInsert
		{
			get
			{
				return new esQueryItem(this, TransMetadata.ColumnNames.TglInsert, esSystemType.DateTime);
			}
		} 
		
		public esQueryItem UserUpdate
		{
			get
			{
				return new esQueryItem(this, TransMetadata.ColumnNames.UserUpdate, esSystemType.String);
			}
		} 
		
		public esQueryItem TglUpdate
		{
			get
			{
				return new esQueryItem(this, TransMetadata.ColumnNames.TglUpdate, esSystemType.DateTime);
			}
		} 
		
	}



    [System.Diagnostics.DebuggerDisplay("Count = {Count}")]
	[Serializable]
	[XmlType("TransCollection")]
	public partial class TransCollection : esTransCollection, IEnumerable<Trans>
	{
		public TransCollection()
		{

		}
		
		public static implicit operator List<Trans>(TransCollection coll)
		{
			List<Trans> list = new List<Trans>();
			
			foreach (Trans emp in coll)
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
				return  TransMetadata.Meta();
			}
		}
		
		
		
		override protected esDynamicQuery GetDynamicQuery()
		{
			if (this.query == null)
			{
				this.query = new TransQuery();
				this.InitQuery(query);
			}
			return this.query;
		}
		
		override protected esEntity CreateEntityForCollection(DataRow row)
		{
			return new Trans(row);
		}

		override protected esEntity CreateEntity()
		{
			return new Trans();
		}
		
		
		#endregion


		[BrowsableAttribute( false )]
		public TransQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new TransQuery();
					base.InitQuery(this.query);
				}

				return this.query;
			}
		}

		public void QueryReset()
		{
			this.query = null;
		}

		public bool Load(TransQuery query)
		{
			this.query = query;
			base.InitQuery(this.query);
			return this.Query.Load();
		}
		
		public Trans AddNew()
		{
			Trans entity = base.AddNewEntity() as Trans;
			
			return entity;
		}

		public Trans FindByPrimaryKey(System.Int64 bkuId)
		{
			return base.FindByPrimaryKey(bkuId) as Trans;
		}


		#region IEnumerable<Trans> Members

		IEnumerator<Trans> IEnumerable<Trans>.GetEnumerator()
		{
			System.Collections.IEnumerable enumer = this as System.Collections.IEnumerable;
			System.Collections.IEnumerator iterator = enumer.GetEnumerator();

			while(iterator.MoveNext())
			{
				yield return iterator.Current as Trans;
			}
		}

		#endregion
		
		private TransQuery query;
	}


	/// <summary>
	/// Encapsulates the 'Trans' table
	/// </summary>

    [System.Diagnostics.DebuggerDisplay("Trans ({BkuId})")]
	[Serializable]
	public partial class Trans : esTrans
	{
		public Trans()
		{

		}
	
		public Trans(DataRow row)
			: base(row)
		{

		}
		
		#region Housekeeping methods
		override protected IMetadata Meta
		{
			get
			{
				return TransMetadata.Meta();
			}
		}
		
		
		
		override protected esTransQuery GetDynamicQuery()
		{
			if (this.query == null)
			{
				this.query = new TransQuery();
				this.InitQuery(query);
			}
			return this.query;
		}
		#endregion
		



		[BrowsableAttribute( false )]
		public TransQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new TransQuery();
					base.InitQuery(this.query);
				}

				return this.query;
			}
		}

		public void QueryReset()
		{
			this.query = null;
		}
		

		public bool Load(TransQuery query)
		{
			this.query = query;
			base.InitQuery(this.query);
			return this.Query.Load();
		}
		
		private TransQuery query;
	}



    [System.Diagnostics.DebuggerDisplay("LastQuery = {es.LastQuery}")]
	[Serializable]
		
	public partial class TransQuery : esTransQuery
	{
		public TransQuery()
		{

		}		
		
		public TransQuery(string joinAlias)
		{
			this.es.JoinAlias = joinAlias;
		}	

        override protected string GetQueryName()
        {
            return "TransQuery";
        }
		
			
	}


	[Serializable]
	public partial class TransMetadata : esMetadata, IMetadata
	{
		#region Protected Constructor
		protected TransMetadata()
		{
			_columns = new esColumnMetadataCollection();
			esColumnMetadata c;

			c = new esColumnMetadata(TransMetadata.ColumnNames.BkuId, 0, typeof(System.Int64), esSystemType.Int64);
			c.PropertyName = TransMetadata.PropertyNames.BkuId;
			c.IsInPrimaryKey = true;
			c.IsAutoIncrement = true;
			c.NumericPrecision = 19;
			_columns.Add(c);
				
			c = new esColumnMetadata(TransMetadata.ColumnNames.KaCode, 1, typeof(System.String), esSystemType.String);
			c.PropertyName = TransMetadata.PropertyNames.KaCode;
			c.CharacterMaxLength = 15;
			_columns.Add(c);
				
			c = new esColumnMetadata(TransMetadata.ColumnNames.TransNumber, 2, typeof(System.String), esSystemType.String);
			c.PropertyName = TransMetadata.PropertyNames.TransNumber;
			c.CharacterMaxLength = 18;
			_columns.Add(c);
				
			c = new esColumnMetadata(TransMetadata.ColumnNames.TransDate, 3, typeof(System.DateTime), esSystemType.DateTime);
			c.PropertyName = TransMetadata.PropertyNames.TransDate;
			_columns.Add(c);
				
			c = new esColumnMetadata(TransMetadata.ColumnNames.Descript, 4, typeof(System.String), esSystemType.String);
			c.PropertyName = TransMetadata.PropertyNames.Descript;
			c.CharacterMaxLength = 100;
			c.IsNullable = true;
			_columns.Add(c);
				
			c = new esColumnMetadata(TransMetadata.ColumnNames.DebitAmount, 5, typeof(System.Decimal), esSystemType.Decimal);
			c.PropertyName = TransMetadata.PropertyNames.DebitAmount;
			c.NumericPrecision = 15;
			c.NumericScale = 2;
			c.HasDefault = true;
			c.Default = @"((0))";
			c.IsNullable = true;
			_columns.Add(c);
				
			c = new esColumnMetadata(TransMetadata.ColumnNames.CreditAmount, 6, typeof(System.Decimal), esSystemType.Decimal);
			c.PropertyName = TransMetadata.PropertyNames.CreditAmount;
			c.NumericPrecision = 15;
			c.NumericScale = 2;
			c.HasDefault = true;
			c.Default = @"((0))";
			c.IsNullable = true;
			_columns.Add(c);
				
			c = new esColumnMetadata(TransMetadata.ColumnNames.CekBgNumber, 7, typeof(System.String), esSystemType.String);
			c.PropertyName = TransMetadata.PropertyNames.CekBgNumber;
			c.CharacterMaxLength = 15;
			c.IsNullable = true;
			_columns.Add(c);
				
			c = new esColumnMetadata(TransMetadata.ColumnNames.PeriodId, 8, typeof(System.Int64), esSystemType.Int64);
			c.PropertyName = TransMetadata.PropertyNames.PeriodId;
			c.NumericPrecision = 19;
			c.IsNullable = true;
			_columns.Add(c);
				
			c = new esColumnMetadata(TransMetadata.ColumnNames.Isverified, 9, typeof(System.Boolean), esSystemType.Boolean);
			c.PropertyName = TransMetadata.PropertyNames.Isverified;
			c.HasDefault = true;
			c.Default = @"((0))";
			_columns.Add(c);
				
			c = new esColumnMetadata(TransMetadata.ColumnNames.IsClosed, 10, typeof(System.Boolean), esSystemType.Boolean);
			c.PropertyName = TransMetadata.PropertyNames.IsClosed;
			c.HasDefault = true;
			c.Default = @"((0))";
			_columns.Add(c);
				
			c = new esColumnMetadata(TransMetadata.ColumnNames.KasId, 11, typeof(System.String), esSystemType.String);
			c.PropertyName = TransMetadata.PropertyNames.KasId;
			c.CharacterMaxLength = 15;
			_columns.Add(c);
				
			c = new esColumnMetadata(TransMetadata.ColumnNames.UserInsert, 12, typeof(System.String), esSystemType.String);
			c.PropertyName = TransMetadata.PropertyNames.UserInsert;
			c.CharacterMaxLength = 50;
			c.IsNullable = true;
			_columns.Add(c);
				
			c = new esColumnMetadata(TransMetadata.ColumnNames.TglInsert, 13, typeof(System.DateTime), esSystemType.DateTime);
			c.PropertyName = TransMetadata.PropertyNames.TglInsert;
			c.IsNullable = true;
			_columns.Add(c);
				
			c = new esColumnMetadata(TransMetadata.ColumnNames.UserUpdate, 14, typeof(System.String), esSystemType.String);
			c.PropertyName = TransMetadata.PropertyNames.UserUpdate;
			c.CharacterMaxLength = 50;
			c.IsNullable = true;
			_columns.Add(c);
				
			c = new esColumnMetadata(TransMetadata.ColumnNames.TglUpdate, 15, typeof(System.DateTime), esSystemType.DateTime);
			c.PropertyName = TransMetadata.PropertyNames.TglUpdate;
			c.IsNullable = true;
			_columns.Add(c);
				
		}
		#endregion	
	
		static public TransMetadata Meta()
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
			 public const string BkuId = "BKU_ID";
			 public const string KaCode = "KA_CODE";
			 public const string TransNumber = "TRANS_NUMBER";
			 public const string TransDate = "TRANS_DATE";
			 public const string Descript = "DESCRIPT";
			 public const string DebitAmount = "DEBIT_AMOUNT";
			 public const string CreditAmount = "CREDIT_AMOUNT";
			 public const string CekBgNumber = "CEK_BG_NUMBER";
			 public const string PeriodId = "PERIOD_ID";
			 public const string Isverified = "ISVERIFIED";
			 public const string IsClosed = "IS_CLOSED";
			 public const string KasId = "KAS_ID";
			 public const string UserInsert = "USER_INSERT";
			 public const string TglInsert = "TGL_INSERT";
			 public const string UserUpdate = "USER_UPDATE";
			 public const string TglUpdate = "TGL_UPDATE";
		}
		#endregion	
		
		#region PropertyNames
		public class PropertyNames
		{ 
			 public const string BkuId = "BkuId";
			 public const string KaCode = "KaCode";
			 public const string TransNumber = "TransNumber";
			 public const string TransDate = "TransDate";
			 public const string Descript = "Descript";
			 public const string DebitAmount = "DebitAmount";
			 public const string CreditAmount = "CreditAmount";
			 public const string CekBgNumber = "CekBgNumber";
			 public const string PeriodId = "PeriodId";
			 public const string Isverified = "Isverified";
			 public const string IsClosed = "IsClosed";
			 public const string KasId = "KasId";
			 public const string UserInsert = "UserInsert";
			 public const string TglInsert = "TglInsert";
			 public const string UserUpdate = "UserUpdate";
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
			lock (typeof(TransMetadata))
			{
				if(TransMetadata.mapDelegates == null)
				{
					TransMetadata.mapDelegates = new Dictionary<string,MapToMeta>();
				}
				
				if (TransMetadata.meta == null)
				{
					TransMetadata.meta = new TransMetadata();
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
				

				meta.AddTypeMap("BkuId", new esTypeMap("bigint", "System.Int64"));
				meta.AddTypeMap("KaCode", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("TransNumber", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("TransDate", new esTypeMap("datetime", "System.DateTime"));
				meta.AddTypeMap("Descript", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("DebitAmount", new esTypeMap("numeric", "System.Decimal"));
				meta.AddTypeMap("CreditAmount", new esTypeMap("numeric", "System.Decimal"));
				meta.AddTypeMap("CekBgNumber", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("PeriodId", new esTypeMap("bigint", "System.Int64"));
				meta.AddTypeMap("Isverified", new esTypeMap("bit", "System.Boolean"));
				meta.AddTypeMap("IsClosed", new esTypeMap("bit", "System.Boolean"));
				meta.AddTypeMap("KasId", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("UserInsert", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("TglInsert", new esTypeMap("datetime", "System.DateTime"));
				meta.AddTypeMap("UserUpdate", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("TglUpdate", new esTypeMap("datetime", "System.DateTime"));			
				
				
				
				meta.Source = "Trans";
				meta.Destination = "Trans";
				
				meta.spInsert = "proc_TransInsert";				
				meta.spUpdate = "proc_TransUpdate";		
				meta.spDelete = "proc_TransDelete";
				meta.spLoadAll = "proc_TransLoadAll";
				meta.spLoadByPrimaryKey = "proc_TransLoadByPrimaryKey";
				
				this._providerMetadataMaps["esDefault"] = meta;
			}
			
			return this._providerMetadataMaps["esDefault"];
		}

		#endregion

		static private TransMetadata meta;
		static protected Dictionary<string, MapToMeta> mapDelegates;
		static private int _esDefault = RegisterDelegateesDefault();
	}
}
