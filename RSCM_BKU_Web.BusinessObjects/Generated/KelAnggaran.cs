/*
===============================================================================
                    EntitySpaces 2009 by EntitySpaces, LLC
             Persistence Layer and Business Objects for Microsoft .NET
             EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
                          http://www.entityspaces.net
===============================================================================
EntitySpaces Version : 2009.2.1214.0
EntitySpaces Driver  : SQL
Date Generated       : 15/03/2011 11:27:32
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
	abstract public class esKelAnggaranCollection : esEntityCollection
	{
		public esKelAnggaranCollection()
		{

		}

		protected override string GetCollectionName()
		{
			return "KelAnggaranCollection";
		}

		#region Query Logic
		protected void InitQuery(esKelAnggaranQuery query)
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
			this.InitQuery(query as esKelAnggaranQuery);
		}
		#endregion
		
		virtual public KelAnggaran DetachEntity(KelAnggaran entity)
		{
			return base.DetachEntity(entity) as KelAnggaran;
		}
		
		virtual public KelAnggaran AttachEntity(KelAnggaran entity)
		{
			return base.AttachEntity(entity) as KelAnggaran;
		}
		
		virtual public void Combine(KelAnggaranCollection collection)
		{
			base.Combine(collection);
		}
		
		new public KelAnggaran this[int index]
		{
			get
			{
				return base[index] as KelAnggaran;
			}
		}

		public override Type GetEntityType()
		{
			return typeof(KelAnggaran);
		}
	}



	[Serializable]
	abstract public class esKelAnggaran : esEntity
	{
		/// <summary>
		/// Used internally by the entity's DynamicQuery mechanism.
		/// </summary>
		virtual protected esKelAnggaranQuery GetDynamicQuery()
		{
			return null;
		}

		public esKelAnggaran()
		{

		}

		public esKelAnggaran(DataRow row)
			: base(row)
		{

		}
		
		#region LoadByPrimaryKey
		public virtual bool LoadByPrimaryKey(System.Int64 kaId)
		{
			if(this.es.Connection.SqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(kaId);
			else
				return LoadByPrimaryKeyStoredProcedure(kaId);
		}

		public virtual bool LoadByPrimaryKey(esSqlAccessType sqlAccessType, System.Int64 kaId)
		{
			if (sqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(kaId);
			else
				return LoadByPrimaryKeyStoredProcedure(kaId);
		}

		private bool LoadByPrimaryKeyDynamic(System.Int64 kaId)
		{
			esKelAnggaranQuery query = this.GetDynamicQuery();
			query.Where(query.KaId == kaId);
			return query.Load();
		}

		private bool LoadByPrimaryKeyStoredProcedure(System.Int64 kaId)
		{
			esParameters parms = new esParameters();
			parms.Add("KA_ID",kaId);
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
						case "KaId": this.str.KaId = (string)value; break;							
						case "KaCode": this.str.KaCode = (string)value; break;							
						case "KaName": this.str.KaName = (string)value; break;							
						case "GtCode": this.str.GtCode = (string)value; break;							
						case "Prefix": this.str.Prefix = (string)value; break;							
						case "IsDetail": this.str.IsDetail = (string)value; break;							
						case "KaLevel": this.str.KaLevel = (string)value; break;							
						case "ParentCode": this.str.ParentCode = (string)value; break;							
						case "Type": this.str.Type = (string)value; break;							
						case "IsActive": this.str.IsActive = (string)value; break;							
						case "IsKas": this.str.IsKas = (string)value; break;							
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
						case "KaId":
						
							if (value == null || value is System.Int64)
								this.KaId = (System.Int64?)value;
							break;
						
						case "IsDetail":
						
							if (value == null || value is System.Boolean)
								this.IsDetail = (System.Boolean?)value;
							break;
						
						case "IsActive":
						
							if (value == null || value is System.Boolean)
								this.IsActive = (System.Boolean?)value;
							break;
						
						case "IsKas":
						
							if (value == null || value is System.Boolean)
								this.IsKas = (System.Boolean?)value;
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
		/// Maps to Kel_anggaran.KA_ID
		/// </summary>
		virtual public System.Int64? KaId
		{
			get
			{
				return base.GetSystemInt64(KelAnggaranMetadata.ColumnNames.KaId);
			}
			
			set
			{
				base.SetSystemInt64(KelAnggaranMetadata.ColumnNames.KaId, value);
			}
		}
		
		/// <summary>
		/// Maps to Kel_anggaran.KA_CODE
		/// </summary>
		virtual public System.String KaCode
		{
			get
			{
				return base.GetSystemString(KelAnggaranMetadata.ColumnNames.KaCode);
			}
			
			set
			{
				base.SetSystemString(KelAnggaranMetadata.ColumnNames.KaCode, value);
			}
		}
		
		/// <summary>
		/// Maps to Kel_anggaran.KA_NAME
		/// </summary>
		virtual public System.String KaName
		{
			get
			{
				return base.GetSystemString(KelAnggaranMetadata.ColumnNames.KaName);
			}
			
			set
			{
				base.SetSystemString(KelAnggaranMetadata.ColumnNames.KaName, value);
			}
		}
		
		/// <summary>
		/// Maps to Kel_anggaran.GT_CODE
		/// </summary>
		virtual public System.String GtCode
		{
			get
			{
				return base.GetSystemString(KelAnggaranMetadata.ColumnNames.GtCode);
			}
			
			set
			{
				if(base.SetSystemString(KelAnggaranMetadata.ColumnNames.GtCode, value))
				{
					this._UpToGroupMAByGtCode = null;
				}
			}
		}
		
		/// <summary>
		/// Maps to Kel_anggaran.PREFIX
		/// </summary>
		virtual public System.String Prefix
		{
			get
			{
				return base.GetSystemString(KelAnggaranMetadata.ColumnNames.Prefix);
			}
			
			set
			{
				base.SetSystemString(KelAnggaranMetadata.ColumnNames.Prefix, value);
			}
		}
		
		/// <summary>
		/// Maps to Kel_anggaran.IS_DETAIL
		/// </summary>
		virtual public System.Boolean? IsDetail
		{
			get
			{
				return base.GetSystemBoolean(KelAnggaranMetadata.ColumnNames.IsDetail);
			}
			
			set
			{
				base.SetSystemBoolean(KelAnggaranMetadata.ColumnNames.IsDetail, value);
			}
		}
		
		/// <summary>
		/// Maps to Kel_anggaran.KA_LEVEL
		/// </summary>
		virtual public System.String KaLevel
		{
			get
			{
				return base.GetSystemString(KelAnggaranMetadata.ColumnNames.KaLevel);
			}
			
			set
			{
				base.SetSystemString(KelAnggaranMetadata.ColumnNames.KaLevel, value);
			}
		}
		
		/// <summary>
		/// Maps to Kel_anggaran.PARENT_CODE
		/// </summary>
		virtual public System.String ParentCode
		{
			get
			{
				return base.GetSystemString(KelAnggaranMetadata.ColumnNames.ParentCode);
			}
			
			set
			{
				base.SetSystemString(KelAnggaranMetadata.ColumnNames.ParentCode, value);
			}
		}
		
		/// <summary>
		/// Maps to Kel_anggaran.TYPE
		/// </summary>
		virtual public System.String Type
		{
			get
			{
				return base.GetSystemString(KelAnggaranMetadata.ColumnNames.Type);
			}
			
			set
			{
				base.SetSystemString(KelAnggaranMetadata.ColumnNames.Type, value);
			}
		}
		
		/// <summary>
		/// Maps to Kel_anggaran.IS_ACTIVE
		/// </summary>
		virtual public System.Boolean? IsActive
		{
			get
			{
				return base.GetSystemBoolean(KelAnggaranMetadata.ColumnNames.IsActive);
			}
			
			set
			{
				base.SetSystemBoolean(KelAnggaranMetadata.ColumnNames.IsActive, value);
			}
		}
		
		/// <summary>
		/// Maps to Kel_anggaran.IS_KAS
		/// </summary>
		virtual public System.Boolean? IsKas
		{
			get
			{
				return base.GetSystemBoolean(KelAnggaranMetadata.ColumnNames.IsKas);
			}
			
			set
			{
				base.SetSystemBoolean(KelAnggaranMetadata.ColumnNames.IsKas, value);
			}
		}
		
		/// <summary>
		/// Maps to Kel_anggaran.USER_INSERT
		/// </summary>
		virtual public System.String UserInsert
		{
			get
			{
				return base.GetSystemString(KelAnggaranMetadata.ColumnNames.UserInsert);
			}
			
			set
			{
				base.SetSystemString(KelAnggaranMetadata.ColumnNames.UserInsert, value);
			}
		}
		
		/// <summary>
		/// Maps to Kel_anggaran.TGL_INSERT
		/// </summary>
		virtual public System.DateTime? TglInsert
		{
			get
			{
				return base.GetSystemDateTime(KelAnggaranMetadata.ColumnNames.TglInsert);
			}
			
			set
			{
				base.SetSystemDateTime(KelAnggaranMetadata.ColumnNames.TglInsert, value);
			}
		}
		
		/// <summary>
		/// Maps to Kel_anggaran.USER_UPDATE
		/// </summary>
		virtual public System.String UserUpdate
		{
			get
			{
				return base.GetSystemString(KelAnggaranMetadata.ColumnNames.UserUpdate);
			}
			
			set
			{
				base.SetSystemString(KelAnggaranMetadata.ColumnNames.UserUpdate, value);
			}
		}
		
		/// <summary>
		/// Maps to Kel_anggaran.TGL_UPDATE
		/// </summary>
		virtual public System.DateTime? TglUpdate
		{
			get
			{
				return base.GetSystemDateTime(KelAnggaranMetadata.ColumnNames.TglUpdate);
			}
			
			set
			{
				base.SetSystemDateTime(KelAnggaranMetadata.ColumnNames.TglUpdate, value);
			}
		}
		
		[CLSCompliant(false)]
		internal protected GroupMA _UpToGroupMAByGtCode;
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
			public esStrings(esKelAnggaran entity)
			{
				this.entity = entity;
			}
			
	
			public System.String KaId
			{
				get
				{
					System.Int64? data = entity.KaId;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.KaId = null;
					else entity.KaId = Convert.ToInt64(value);
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
				
			public System.String IsDetail
			{
				get
				{
					System.Boolean? data = entity.IsDetail;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.IsDetail = null;
					else entity.IsDetail = Convert.ToBoolean(value);
				}
			}
				
			public System.String KaLevel
			{
				get
				{
					System.String data = entity.KaLevel;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.KaLevel = null;
					else entity.KaLevel = Convert.ToString(value);
				}
			}
				
			public System.String ParentCode
			{
				get
				{
					System.String data = entity.ParentCode;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.ParentCode = null;
					else entity.ParentCode = Convert.ToString(value);
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
				
			public System.String IsKas
			{
				get
				{
					System.Boolean? data = entity.IsKas;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.IsKas = null;
					else entity.IsKas = Convert.ToBoolean(value);
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
			

			private esKelAnggaran entity;
		}
		#endregion

		#region Query Logic
		protected void InitQuery(esKelAnggaranQuery query)
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
				throw new Exception("esKelAnggaran can only hold one record of data");
			}

			return dataFound;
		}
		#endregion
		
		[NonSerialized]
		private esStrings esstrings;
	}


	
	public partial class KelAnggaran : esKelAnggaran
	{

				
		#region TransCollectionByKaCode - Zero To Many
		/// <summary>
		/// Zero to Many
		/// Foreign Key Name - FK_Trans_Kel_anggaran
		/// </summary>

		[XmlIgnore]
		public TransCollection TransCollectionByKaCode
		{
			get
			{
				if(this._TransCollectionByKaCode == null)
				{
					this._TransCollectionByKaCode = new TransCollection();
					this._TransCollectionByKaCode.es.Connection.Name = this.es.Connection.Name;
					this.SetPostSave("TransCollectionByKaCode", this._TransCollectionByKaCode);
				
					if(this.KaCode != null)
					{
						this._TransCollectionByKaCode.Query.Where(this._TransCollectionByKaCode.Query.KaCode == this.KaCode);
						this._TransCollectionByKaCode.Query.Load();

						// Auto-hookup Foreign Keys
						this._TransCollectionByKaCode.fks.Add(TransMetadata.ColumnNames.KaCode, this.KaCode);
					}
				}

				return this._TransCollectionByKaCode;
			}
			
			set 
			{ 
				if (value != null) throw new Exception("'value' Must be null"); 
			 
				if (this._TransCollectionByKaCode != null) 
				{ 
					this.RemovePostSave("TransCollectionByKaCode"); 
					this._TransCollectionByKaCode = null;
					
				} 
			} 			
		}

		private TransCollection _TransCollectionByKaCode;
		#endregion

				
		#region UpToGroupMAByGtCode - Many To One
		/// <summary>
		/// Many to One
		/// Foreign Key Name - FK_Kel_anggaran_Group_MA
		/// </summary>

		[XmlIgnore]
		public GroupMA UpToGroupMAByGtCode
		{
			get
			{
				if(this._UpToGroupMAByGtCode == null
					&& GtCode != null					)
				{
					this._UpToGroupMAByGtCode = new GroupMA();
					this._UpToGroupMAByGtCode.es.Connection.Name = this.es.Connection.Name;
					this.SetPreSave("UpToGroupMAByGtCode", this._UpToGroupMAByGtCode);
					this._UpToGroupMAByGtCode.Query.Where(this._UpToGroupMAByGtCode.Query.GtCode == this.GtCode);
					this._UpToGroupMAByGtCode.Query.Load();
				}

				return this._UpToGroupMAByGtCode;
			}
			
			set
			{
				this.RemovePreSave("UpToGroupMAByGtCode");
				

				if(value == null)
				{
					this.GtCode = null;
					this._UpToGroupMAByGtCode = null;
				}
				else
				{
					this.GtCode = value.GtCode;
					this._UpToGroupMAByGtCode = value;
					this.SetPreSave("UpToGroupMAByGtCode", this._UpToGroupMAByGtCode);
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
			
			props.Add(new esPropertyDescriptor(this, "TransCollectionByKaCode", typeof(TransCollection), new Trans()));
		
			return props;
		}	
		
		/// <summary>
		/// Used internally for retrieving AutoIncrementing keys
		/// during hierarchical PreSave.
		/// </summary>
		protected override void ApplyPreSaveKeys()
		{
			if(!this.es.IsDeleted && this._UpToGroupMAByGtCode != null)
			{
				this.GtCode = this._UpToGroupMAByGtCode.GtCode;
			}
		}
		
		/// <summary>
		/// Used internally for retrieving AutoIncrementing keys
		/// during hierarchical PostSave.
		/// </summary>
		protected override void ApplyPostSaveKeys()
		{
			if(this._TransCollectionByKaCode != null)
			{
				foreach(Trans obj in this._TransCollectionByKaCode)
				{
					if(obj.es.IsAdded)
					{
						obj.KaCode = this.KaCode;
					}
				}
			}
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
	abstract public class esKelAnggaranQuery : esDynamicQuery
	{
		override protected IMetadata Meta
		{
			get
			{
				return KelAnggaranMetadata.Meta();
			}
		}	
		

		public esQueryItem KaId
		{
			get
			{
				return new esQueryItem(this, KelAnggaranMetadata.ColumnNames.KaId, esSystemType.Int64);
			}
		} 
		
		public esQueryItem KaCode
		{
			get
			{
				return new esQueryItem(this, KelAnggaranMetadata.ColumnNames.KaCode, esSystemType.String);
			}
		} 
		
		public esQueryItem KaName
		{
			get
			{
				return new esQueryItem(this, KelAnggaranMetadata.ColumnNames.KaName, esSystemType.String);
			}
		} 
		
		public esQueryItem GtCode
		{
			get
			{
				return new esQueryItem(this, KelAnggaranMetadata.ColumnNames.GtCode, esSystemType.String);
			}
		} 
		
		public esQueryItem Prefix
		{
			get
			{
				return new esQueryItem(this, KelAnggaranMetadata.ColumnNames.Prefix, esSystemType.String);
			}
		} 
		
		public esQueryItem IsDetail
		{
			get
			{
				return new esQueryItem(this, KelAnggaranMetadata.ColumnNames.IsDetail, esSystemType.Boolean);
			}
		} 
		
		public esQueryItem KaLevel
		{
			get
			{
				return new esQueryItem(this, KelAnggaranMetadata.ColumnNames.KaLevel, esSystemType.String);
			}
		} 
		
		public esQueryItem ParentCode
		{
			get
			{
				return new esQueryItem(this, KelAnggaranMetadata.ColumnNames.ParentCode, esSystemType.String);
			}
		} 
		
		public esQueryItem Type
		{
			get
			{
				return new esQueryItem(this, KelAnggaranMetadata.ColumnNames.Type, esSystemType.String);
			}
		} 
		
		public esQueryItem IsActive
		{
			get
			{
				return new esQueryItem(this, KelAnggaranMetadata.ColumnNames.IsActive, esSystemType.Boolean);
			}
		} 
		
		public esQueryItem IsKas
		{
			get
			{
				return new esQueryItem(this, KelAnggaranMetadata.ColumnNames.IsKas, esSystemType.Boolean);
			}
		} 
		
		public esQueryItem UserInsert
		{
			get
			{
				return new esQueryItem(this, KelAnggaranMetadata.ColumnNames.UserInsert, esSystemType.String);
			}
		} 
		
		public esQueryItem TglInsert
		{
			get
			{
				return new esQueryItem(this, KelAnggaranMetadata.ColumnNames.TglInsert, esSystemType.DateTime);
			}
		} 
		
		public esQueryItem UserUpdate
		{
			get
			{
				return new esQueryItem(this, KelAnggaranMetadata.ColumnNames.UserUpdate, esSystemType.String);
			}
		} 
		
		public esQueryItem TglUpdate
		{
			get
			{
				return new esQueryItem(this, KelAnggaranMetadata.ColumnNames.TglUpdate, esSystemType.DateTime);
			}
		} 
		
	}



    [System.Diagnostics.DebuggerDisplay("Count = {Count}")]
	[Serializable]
	[XmlType("KelAnggaranCollection")]
	public partial class KelAnggaranCollection : esKelAnggaranCollection, IEnumerable<KelAnggaran>
	{
		public KelAnggaranCollection()
		{

		}
		
		public static implicit operator List<KelAnggaran>(KelAnggaranCollection coll)
		{
			List<KelAnggaran> list = new List<KelAnggaran>();
			
			foreach (KelAnggaran emp in coll)
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
				return  KelAnggaranMetadata.Meta();
			}
		}
		
		
		
		override protected esDynamicQuery GetDynamicQuery()
		{
			if (this.query == null)
			{
				this.query = new KelAnggaranQuery();
				this.InitQuery(query);
			}
			return this.query;
		}
		
		override protected esEntity CreateEntityForCollection(DataRow row)
		{
			return new KelAnggaran(row);
		}

		override protected esEntity CreateEntity()
		{
			return new KelAnggaran();
		}
		
		
		#endregion


		[BrowsableAttribute( false )]
		public KelAnggaranQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new KelAnggaranQuery();
					base.InitQuery(this.query);
				}

				return this.query;
			}
		}

		public void QueryReset()
		{
			this.query = null;
		}

		public bool Load(KelAnggaranQuery query)
		{
			this.query = query;
			base.InitQuery(this.query);
			return this.Query.Load();
		}
		
		public KelAnggaran AddNew()
		{
			KelAnggaran entity = base.AddNewEntity() as KelAnggaran;
			
			return entity;
		}

		public KelAnggaran FindByPrimaryKey(System.Int64 kaId)
		{
			return base.FindByPrimaryKey(kaId) as KelAnggaran;
		}


		#region IEnumerable<KelAnggaran> Members

		IEnumerator<KelAnggaran> IEnumerable<KelAnggaran>.GetEnumerator()
		{
			System.Collections.IEnumerable enumer = this as System.Collections.IEnumerable;
			System.Collections.IEnumerator iterator = enumer.GetEnumerator();

			while(iterator.MoveNext())
			{
				yield return iterator.Current as KelAnggaran;
			}
		}

		#endregion
		
		private KelAnggaranQuery query;
	}


	/// <summary>
	/// Encapsulates the 'Kel_anggaran' table
	/// </summary>

    [System.Diagnostics.DebuggerDisplay("KelAnggaran ({KaId})")]
	[Serializable]
	public partial class KelAnggaran : esKelAnggaran
	{
		public KelAnggaran()
		{

		}
	
		public KelAnggaran(DataRow row)
			: base(row)
		{

		}
		
		#region Housekeeping methods
		override protected IMetadata Meta
		{
			get
			{
				return KelAnggaranMetadata.Meta();
			}
		}
		
		
		
		override protected esKelAnggaranQuery GetDynamicQuery()
		{
			if (this.query == null)
			{
				this.query = new KelAnggaranQuery();
				this.InitQuery(query);
			}
			return this.query;
		}
		#endregion
		



		[BrowsableAttribute( false )]
		public KelAnggaranQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new KelAnggaranQuery();
					base.InitQuery(this.query);
				}

				return this.query;
			}
		}

		public void QueryReset()
		{
			this.query = null;
		}
		

		public bool Load(KelAnggaranQuery query)
		{
			this.query = query;
			base.InitQuery(this.query);
			return this.Query.Load();
		}
		
		private KelAnggaranQuery query;
	}



    [System.Diagnostics.DebuggerDisplay("LastQuery = {es.LastQuery}")]
	[Serializable]
		
	public partial class KelAnggaranQuery : esKelAnggaranQuery
	{
		public KelAnggaranQuery()
		{

		}		
		
		public KelAnggaranQuery(string joinAlias)
		{
			this.es.JoinAlias = joinAlias;
		}	

        override protected string GetQueryName()
        {
            return "KelAnggaranQuery";
        }
		
			
	}


	[Serializable]
	public partial class KelAnggaranMetadata : esMetadata, IMetadata
	{
		#region Protected Constructor
		protected KelAnggaranMetadata()
		{
			_columns = new esColumnMetadataCollection();
			esColumnMetadata c;

			c = new esColumnMetadata(KelAnggaranMetadata.ColumnNames.KaId, 0, typeof(System.Int64), esSystemType.Int64);
			c.PropertyName = KelAnggaranMetadata.PropertyNames.KaId;
			c.IsInPrimaryKey = true;
			c.IsAutoIncrement = true;
			c.NumericPrecision = 19;
			_columns.Add(c);
				
			c = new esColumnMetadata(KelAnggaranMetadata.ColumnNames.KaCode, 1, typeof(System.String), esSystemType.String);
			c.PropertyName = KelAnggaranMetadata.PropertyNames.KaCode;
			c.CharacterMaxLength = 15;
			_columns.Add(c);
				
			c = new esColumnMetadata(KelAnggaranMetadata.ColumnNames.KaName, 2, typeof(System.String), esSystemType.String);
			c.PropertyName = KelAnggaranMetadata.PropertyNames.KaName;
			c.CharacterMaxLength = 256;
			_columns.Add(c);
				
			c = new esColumnMetadata(KelAnggaranMetadata.ColumnNames.GtCode, 3, typeof(System.String), esSystemType.String);
			c.PropertyName = KelAnggaranMetadata.PropertyNames.GtCode;
			c.CharacterMaxLength = 15;
			_columns.Add(c);
				
			c = new esColumnMetadata(KelAnggaranMetadata.ColumnNames.Prefix, 4, typeof(System.String), esSystemType.String);
			c.PropertyName = KelAnggaranMetadata.PropertyNames.Prefix;
			c.CharacterMaxLength = 10;
			c.IsNullable = true;
			_columns.Add(c);
				
			c = new esColumnMetadata(KelAnggaranMetadata.ColumnNames.IsDetail, 5, typeof(System.Boolean), esSystemType.Boolean);
			c.PropertyName = KelAnggaranMetadata.PropertyNames.IsDetail;
			_columns.Add(c);
				
			c = new esColumnMetadata(KelAnggaranMetadata.ColumnNames.KaLevel, 6, typeof(System.String), esSystemType.String);
			c.PropertyName = KelAnggaranMetadata.PropertyNames.KaLevel;
			c.CharacterMaxLength = 10;
			_columns.Add(c);
				
			c = new esColumnMetadata(KelAnggaranMetadata.ColumnNames.ParentCode, 7, typeof(System.String), esSystemType.String);
			c.PropertyName = KelAnggaranMetadata.PropertyNames.ParentCode;
			c.CharacterMaxLength = 15;
			c.IsNullable = true;
			_columns.Add(c);
				
			c = new esColumnMetadata(KelAnggaranMetadata.ColumnNames.Type, 8, typeof(System.String), esSystemType.String);
			c.PropertyName = KelAnggaranMetadata.PropertyNames.Type;
			c.CharacterMaxLength = 1;
			c.HasDefault = true;
			c.Default = @"(N'D')";
			c.IsNullable = true;
			_columns.Add(c);
				
			c = new esColumnMetadata(KelAnggaranMetadata.ColumnNames.IsActive, 9, typeof(System.Boolean), esSystemType.Boolean);
			c.PropertyName = KelAnggaranMetadata.PropertyNames.IsActive;
			_columns.Add(c);
				
			c = new esColumnMetadata(KelAnggaranMetadata.ColumnNames.IsKas, 10, typeof(System.Boolean), esSystemType.Boolean);
			c.PropertyName = KelAnggaranMetadata.PropertyNames.IsKas;
			c.IsNullable = true;
			_columns.Add(c);
				
			c = new esColumnMetadata(KelAnggaranMetadata.ColumnNames.UserInsert, 11, typeof(System.String), esSystemType.String);
			c.PropertyName = KelAnggaranMetadata.PropertyNames.UserInsert;
			c.CharacterMaxLength = 50;
			c.IsNullable = true;
			_columns.Add(c);
				
			c = new esColumnMetadata(KelAnggaranMetadata.ColumnNames.TglInsert, 12, typeof(System.DateTime), esSystemType.DateTime);
			c.PropertyName = KelAnggaranMetadata.PropertyNames.TglInsert;
			c.IsNullable = true;
			_columns.Add(c);
				
			c = new esColumnMetadata(KelAnggaranMetadata.ColumnNames.UserUpdate, 13, typeof(System.String), esSystemType.String);
			c.PropertyName = KelAnggaranMetadata.PropertyNames.UserUpdate;
			c.CharacterMaxLength = 50;
			c.IsNullable = true;
			_columns.Add(c);
				
			c = new esColumnMetadata(KelAnggaranMetadata.ColumnNames.TglUpdate, 14, typeof(System.DateTime), esSystemType.DateTime);
			c.PropertyName = KelAnggaranMetadata.PropertyNames.TglUpdate;
			c.IsNullable = true;
			_columns.Add(c);
				
		}
		#endregion	
	
		static public KelAnggaranMetadata Meta()
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
			 public const string KaId = "KA_ID";
			 public const string KaCode = "KA_CODE";
			 public const string KaName = "KA_NAME";
			 public const string GtCode = "GT_CODE";
			 public const string Prefix = "PREFIX";
			 public const string IsDetail = "IS_DETAIL";
			 public const string KaLevel = "KA_LEVEL";
			 public const string ParentCode = "PARENT_CODE";
			 public const string Type = "TYPE";
			 public const string IsActive = "IS_ACTIVE";
			 public const string IsKas = "IS_KAS";
			 public const string UserInsert = "USER_INSERT";
			 public const string TglInsert = "TGL_INSERT";
			 public const string UserUpdate = "USER_UPDATE";
			 public const string TglUpdate = "TGL_UPDATE";
		}
		#endregion	
		
		#region PropertyNames
		public class PropertyNames
		{ 
			 public const string KaId = "KaId";
			 public const string KaCode = "KaCode";
			 public const string KaName = "KaName";
			 public const string GtCode = "GtCode";
			 public const string Prefix = "Prefix";
			 public const string IsDetail = "IsDetail";
			 public const string KaLevel = "KaLevel";
			 public const string ParentCode = "ParentCode";
			 public const string Type = "Type";
			 public const string IsActive = "IsActive";
			 public const string IsKas = "IsKas";
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
			lock (typeof(KelAnggaranMetadata))
			{
				if(KelAnggaranMetadata.mapDelegates == null)
				{
					KelAnggaranMetadata.mapDelegates = new Dictionary<string,MapToMeta>();
				}
				
				if (KelAnggaranMetadata.meta == null)
				{
					KelAnggaranMetadata.meta = new KelAnggaranMetadata();
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
				

				meta.AddTypeMap("KaId", new esTypeMap("bigint", "System.Int64"));
				meta.AddTypeMap("KaCode", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("KaName", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("GtCode", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("Prefix", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("IsDetail", new esTypeMap("bit", "System.Boolean"));
				meta.AddTypeMap("KaLevel", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("ParentCode", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("Type", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("IsActive", new esTypeMap("bit", "System.Boolean"));
				meta.AddTypeMap("IsKas", new esTypeMap("bit", "System.Boolean"));
				meta.AddTypeMap("UserInsert", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("TglInsert", new esTypeMap("datetime", "System.DateTime"));
				meta.AddTypeMap("UserUpdate", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("TglUpdate", new esTypeMap("datetime", "System.DateTime"));			
				
				
				
				meta.Source = "Kel_anggaran";
				meta.Destination = "Kel_anggaran";
				
				meta.spInsert = "proc_Kel_anggaranInsert";				
				meta.spUpdate = "proc_Kel_anggaranUpdate";		
				meta.spDelete = "proc_Kel_anggaranDelete";
				meta.spLoadAll = "proc_Kel_anggaranLoadAll";
				meta.spLoadByPrimaryKey = "proc_Kel_anggaranLoadByPrimaryKey";
				
				this._providerMetadataMaps["esDefault"] = meta;
			}
			
			return this._providerMetadataMaps["esDefault"];
		}

		#endregion

		static private KelAnggaranMetadata meta;
		static protected Dictionary<string, MapToMeta> mapDelegates;
		static private int _esDefault = RegisterDelegateesDefault();
	}
}
