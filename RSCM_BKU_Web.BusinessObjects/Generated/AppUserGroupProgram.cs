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
	abstract public class esAppUserGroupProgramCollection : esEntityCollection
	{
		public esAppUserGroupProgramCollection()
		{

		}

		protected override string GetCollectionName()
		{
			return "AppUserGroupProgramCollection";
		}

		#region Query Logic
		protected void InitQuery(esAppUserGroupProgramQuery query)
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
			this.InitQuery(query as esAppUserGroupProgramQuery);
		}
		#endregion
		
		virtual public AppUserGroupProgram DetachEntity(AppUserGroupProgram entity)
		{
			return base.DetachEntity(entity) as AppUserGroupProgram;
		}
		
		virtual public AppUserGroupProgram AttachEntity(AppUserGroupProgram entity)
		{
			return base.AttachEntity(entity) as AppUserGroupProgram;
		}
		
		virtual public void Combine(AppUserGroupProgramCollection collection)
		{
			base.Combine(collection);
		}
		
		new public AppUserGroupProgram this[int index]
		{
			get
			{
				return base[index] as AppUserGroupProgram;
			}
		}

		public override Type GetEntityType()
		{
			return typeof(AppUserGroupProgram);
		}
	}



	[Serializable]
	abstract public class esAppUserGroupProgram : esEntity
	{
		/// <summary>
		/// Used internally by the entity's DynamicQuery mechanism.
		/// </summary>
		virtual protected esAppUserGroupProgramQuery GetDynamicQuery()
		{
			return null;
		}

		public esAppUserGroupProgram()
		{

		}

		public esAppUserGroupProgram(DataRow row)
			: base(row)
		{

		}
		
		#region LoadByPrimaryKey
		public virtual bool LoadByPrimaryKey(System.String userGroupID, System.String programID)
		{
			if(this.es.Connection.SqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(userGroupID, programID);
			else
				return LoadByPrimaryKeyStoredProcedure(userGroupID, programID);
		}

		public virtual bool LoadByPrimaryKey(esSqlAccessType sqlAccessType, System.String userGroupID, System.String programID)
		{
			if (sqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(userGroupID, programID);
			else
				return LoadByPrimaryKeyStoredProcedure(userGroupID, programID);
		}

		private bool LoadByPrimaryKeyDynamic(System.String userGroupID, System.String programID)
		{
			esAppUserGroupProgramQuery query = this.GetDynamicQuery();
			query.Where(query.UserGroupID == userGroupID, query.ProgramID == programID);
			return query.Load();
		}

		private bool LoadByPrimaryKeyStoredProcedure(System.String userGroupID, System.String programID)
		{
			esParameters parms = new esParameters();
			parms.Add("UserGroupID",userGroupID);			parms.Add("ProgramID",programID);
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
						case "UserGroupID": this.str.UserGroupID = (string)value; break;							
						case "ProgramID": this.str.ProgramID = (string)value; break;							
						case "IsUserGroupAddAble": this.str.IsUserGroupAddAble = (string)value; break;							
						case "IsUserGroupEditAble": this.str.IsUserGroupEditAble = (string)value; break;							
						case "IsUserGroupDeleteAble": this.str.IsUserGroupDeleteAble = (string)value; break;							
						case "IsUserGroupApprovalAble": this.str.IsUserGroupApprovalAble = (string)value; break;							
						case "IsUserGroupUnApprovalAble": this.str.IsUserGroupUnApprovalAble = (string)value; break;							
						case "IsUserGroupVoidAble": this.str.IsUserGroupVoidAble = (string)value; break;							
						case "IsUserGroupUnVoidAble": this.str.IsUserGroupUnVoidAble = (string)value; break;							
						case "IsUserGroupExportAble": this.str.IsUserGroupExportAble = (string)value; break;							
						case "LastUpdateDateTime": this.str.LastUpdateDateTime = (string)value; break;							
						case "LastUpdateByUserID": this.str.LastUpdateByUserID = (string)value; break;
					}
				}
				else
				{
					switch (name)
					{	
						case "IsUserGroupAddAble":
						
							if (value == null || value is System.Boolean)
								this.IsUserGroupAddAble = (System.Boolean?)value;
							break;
						
						case "IsUserGroupEditAble":
						
							if (value == null || value is System.Boolean)
								this.IsUserGroupEditAble = (System.Boolean?)value;
							break;
						
						case "IsUserGroupDeleteAble":
						
							if (value == null || value is System.Boolean)
								this.IsUserGroupDeleteAble = (System.Boolean?)value;
							break;
						
						case "IsUserGroupApprovalAble":
						
							if (value == null || value is System.Boolean)
								this.IsUserGroupApprovalAble = (System.Boolean?)value;
							break;
						
						case "IsUserGroupUnApprovalAble":
						
							if (value == null || value is System.Boolean)
								this.IsUserGroupUnApprovalAble = (System.Boolean?)value;
							break;
						
						case "IsUserGroupVoidAble":
						
							if (value == null || value is System.Boolean)
								this.IsUserGroupVoidAble = (System.Boolean?)value;
							break;
						
						case "IsUserGroupUnVoidAble":
						
							if (value == null || value is System.Boolean)
								this.IsUserGroupUnVoidAble = (System.Boolean?)value;
							break;
						
						case "IsUserGroupExportAble":
						
							if (value == null || value is System.Boolean)
								this.IsUserGroupExportAble = (System.Boolean?)value;
							break;
						
						case "LastUpdateDateTime":
						
							if (value == null || value is System.DateTime)
								this.LastUpdateDateTime = (System.DateTime?)value;
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
		/// Maps to AppUserGroupProgram.UserGroupID
		/// </summary>
		virtual public System.String UserGroupID
		{
			get
			{
				return base.GetSystemString(AppUserGroupProgramMetadata.ColumnNames.UserGroupID);
			}
			
			set
			{
				base.SetSystemString(AppUserGroupProgramMetadata.ColumnNames.UserGroupID, value);
			}
		}
		
		/// <summary>
		/// Maps to AppUserGroupProgram.ProgramID
		/// </summary>
		virtual public System.String ProgramID
		{
			get
			{
				return base.GetSystemString(AppUserGroupProgramMetadata.ColumnNames.ProgramID);
			}
			
			set
			{
				base.SetSystemString(AppUserGroupProgramMetadata.ColumnNames.ProgramID, value);
			}
		}
		
		/// <summary>
		/// Maps to AppUserGroupProgram.IsUserGroupAddAble
		/// </summary>
		virtual public System.Boolean? IsUserGroupAddAble
		{
			get
			{
				return base.GetSystemBoolean(AppUserGroupProgramMetadata.ColumnNames.IsUserGroupAddAble);
			}
			
			set
			{
				base.SetSystemBoolean(AppUserGroupProgramMetadata.ColumnNames.IsUserGroupAddAble, value);
			}
		}
		
		/// <summary>
		/// Maps to AppUserGroupProgram.IsUserGroupEditAble
		/// </summary>
		virtual public System.Boolean? IsUserGroupEditAble
		{
			get
			{
				return base.GetSystemBoolean(AppUserGroupProgramMetadata.ColumnNames.IsUserGroupEditAble);
			}
			
			set
			{
				base.SetSystemBoolean(AppUserGroupProgramMetadata.ColumnNames.IsUserGroupEditAble, value);
			}
		}
		
		/// <summary>
		/// Maps to AppUserGroupProgram.IsUserGroupDeleteAble
		/// </summary>
		virtual public System.Boolean? IsUserGroupDeleteAble
		{
			get
			{
				return base.GetSystemBoolean(AppUserGroupProgramMetadata.ColumnNames.IsUserGroupDeleteAble);
			}
			
			set
			{
				base.SetSystemBoolean(AppUserGroupProgramMetadata.ColumnNames.IsUserGroupDeleteAble, value);
			}
		}
		
		/// <summary>
		/// Maps to AppUserGroupProgram.IsUserGroupApprovalAble
		/// </summary>
		virtual public System.Boolean? IsUserGroupApprovalAble
		{
			get
			{
				return base.GetSystemBoolean(AppUserGroupProgramMetadata.ColumnNames.IsUserGroupApprovalAble);
			}
			
			set
			{
				base.SetSystemBoolean(AppUserGroupProgramMetadata.ColumnNames.IsUserGroupApprovalAble, value);
			}
		}
		
		/// <summary>
		/// Maps to AppUserGroupProgram.IsUserGroupUnApprovalAble
		/// </summary>
		virtual public System.Boolean? IsUserGroupUnApprovalAble
		{
			get
			{
				return base.GetSystemBoolean(AppUserGroupProgramMetadata.ColumnNames.IsUserGroupUnApprovalAble);
			}
			
			set
			{
				base.SetSystemBoolean(AppUserGroupProgramMetadata.ColumnNames.IsUserGroupUnApprovalAble, value);
			}
		}
		
		/// <summary>
		/// Maps to AppUserGroupProgram.IsUserGroupVoidAble
		/// </summary>
		virtual public System.Boolean? IsUserGroupVoidAble
		{
			get
			{
				return base.GetSystemBoolean(AppUserGroupProgramMetadata.ColumnNames.IsUserGroupVoidAble);
			}
			
			set
			{
				base.SetSystemBoolean(AppUserGroupProgramMetadata.ColumnNames.IsUserGroupVoidAble, value);
			}
		}
		
		/// <summary>
		/// Maps to AppUserGroupProgram.IsUserGroupUnVoidAble
		/// </summary>
		virtual public System.Boolean? IsUserGroupUnVoidAble
		{
			get
			{
				return base.GetSystemBoolean(AppUserGroupProgramMetadata.ColumnNames.IsUserGroupUnVoidAble);
			}
			
			set
			{
				base.SetSystemBoolean(AppUserGroupProgramMetadata.ColumnNames.IsUserGroupUnVoidAble, value);
			}
		}
		
		/// <summary>
		/// Maps to AppUserGroupProgram.IsUserGroupExportAble
		/// </summary>
		virtual public System.Boolean? IsUserGroupExportAble
		{
			get
			{
				return base.GetSystemBoolean(AppUserGroupProgramMetadata.ColumnNames.IsUserGroupExportAble);
			}
			
			set
			{
				base.SetSystemBoolean(AppUserGroupProgramMetadata.ColumnNames.IsUserGroupExportAble, value);
			}
		}
		
		/// <summary>
		/// Maps to AppUserGroupProgram.LastUpdateDateTime
		/// </summary>
		virtual public System.DateTime? LastUpdateDateTime
		{
			get
			{
				return base.GetSystemDateTime(AppUserGroupProgramMetadata.ColumnNames.LastUpdateDateTime);
			}
			
			set
			{
				base.SetSystemDateTime(AppUserGroupProgramMetadata.ColumnNames.LastUpdateDateTime, value);
			}
		}
		
		/// <summary>
		/// Maps to AppUserGroupProgram.LastUpdateByUserID
		/// </summary>
		virtual public System.String LastUpdateByUserID
		{
			get
			{
				return base.GetSystemString(AppUserGroupProgramMetadata.ColumnNames.LastUpdateByUserID);
			}
			
			set
			{
				base.SetSystemString(AppUserGroupProgramMetadata.ColumnNames.LastUpdateByUserID, value);
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
			public esStrings(esAppUserGroupProgram entity)
			{
				this.entity = entity;
			}
			
	
			public System.String UserGroupID
			{
				get
				{
					System.String data = entity.UserGroupID;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.UserGroupID = null;
					else entity.UserGroupID = Convert.ToString(value);
				}
			}
				
			public System.String ProgramID
			{
				get
				{
					System.String data = entity.ProgramID;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.ProgramID = null;
					else entity.ProgramID = Convert.ToString(value);
				}
			}
				
			public System.String IsUserGroupAddAble
			{
				get
				{
					System.Boolean? data = entity.IsUserGroupAddAble;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.IsUserGroupAddAble = null;
					else entity.IsUserGroupAddAble = Convert.ToBoolean(value);
				}
			}
				
			public System.String IsUserGroupEditAble
			{
				get
				{
					System.Boolean? data = entity.IsUserGroupEditAble;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.IsUserGroupEditAble = null;
					else entity.IsUserGroupEditAble = Convert.ToBoolean(value);
				}
			}
				
			public System.String IsUserGroupDeleteAble
			{
				get
				{
					System.Boolean? data = entity.IsUserGroupDeleteAble;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.IsUserGroupDeleteAble = null;
					else entity.IsUserGroupDeleteAble = Convert.ToBoolean(value);
				}
			}
				
			public System.String IsUserGroupApprovalAble
			{
				get
				{
					System.Boolean? data = entity.IsUserGroupApprovalAble;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.IsUserGroupApprovalAble = null;
					else entity.IsUserGroupApprovalAble = Convert.ToBoolean(value);
				}
			}
				
			public System.String IsUserGroupUnApprovalAble
			{
				get
				{
					System.Boolean? data = entity.IsUserGroupUnApprovalAble;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.IsUserGroupUnApprovalAble = null;
					else entity.IsUserGroupUnApprovalAble = Convert.ToBoolean(value);
				}
			}
				
			public System.String IsUserGroupVoidAble
			{
				get
				{
					System.Boolean? data = entity.IsUserGroupVoidAble;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.IsUserGroupVoidAble = null;
					else entity.IsUserGroupVoidAble = Convert.ToBoolean(value);
				}
			}
				
			public System.String IsUserGroupUnVoidAble
			{
				get
				{
					System.Boolean? data = entity.IsUserGroupUnVoidAble;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.IsUserGroupUnVoidAble = null;
					else entity.IsUserGroupUnVoidAble = Convert.ToBoolean(value);
				}
			}
				
			public System.String IsUserGroupExportAble
			{
				get
				{
					System.Boolean? data = entity.IsUserGroupExportAble;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.IsUserGroupExportAble = null;
					else entity.IsUserGroupExportAble = Convert.ToBoolean(value);
				}
			}
				
			public System.String LastUpdateDateTime
			{
				get
				{
					System.DateTime? data = entity.LastUpdateDateTime;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.LastUpdateDateTime = null;
					else entity.LastUpdateDateTime = Convert.ToDateTime(value);
				}
			}
				
			public System.String LastUpdateByUserID
			{
				get
				{
					System.String data = entity.LastUpdateByUserID;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.LastUpdateByUserID = null;
					else entity.LastUpdateByUserID = Convert.ToString(value);
				}
			}
			

			private esAppUserGroupProgram entity;
		}
		#endregion

		#region Query Logic
		protected void InitQuery(esAppUserGroupProgramQuery query)
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
				throw new Exception("esAppUserGroupProgram can only hold one record of data");
			}

			return dataFound;
		}
		#endregion
		
		[NonSerialized]
		private esStrings esstrings;
	}


	
	public partial class AppUserGroupProgram : esAppUserGroupProgram
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
	abstract public class esAppUserGroupProgramQuery : esDynamicQuery
	{
		override protected IMetadata Meta
		{
			get
			{
				return AppUserGroupProgramMetadata.Meta();
			}
		}	
		

		public esQueryItem UserGroupID
		{
			get
			{
				return new esQueryItem(this, AppUserGroupProgramMetadata.ColumnNames.UserGroupID, esSystemType.String);
			}
		} 
		
		public esQueryItem ProgramID
		{
			get
			{
				return new esQueryItem(this, AppUserGroupProgramMetadata.ColumnNames.ProgramID, esSystemType.String);
			}
		} 
		
		public esQueryItem IsUserGroupAddAble
		{
			get
			{
				return new esQueryItem(this, AppUserGroupProgramMetadata.ColumnNames.IsUserGroupAddAble, esSystemType.Boolean);
			}
		} 
		
		public esQueryItem IsUserGroupEditAble
		{
			get
			{
				return new esQueryItem(this, AppUserGroupProgramMetadata.ColumnNames.IsUserGroupEditAble, esSystemType.Boolean);
			}
		} 
		
		public esQueryItem IsUserGroupDeleteAble
		{
			get
			{
				return new esQueryItem(this, AppUserGroupProgramMetadata.ColumnNames.IsUserGroupDeleteAble, esSystemType.Boolean);
			}
		} 
		
		public esQueryItem IsUserGroupApprovalAble
		{
			get
			{
				return new esQueryItem(this, AppUserGroupProgramMetadata.ColumnNames.IsUserGroupApprovalAble, esSystemType.Boolean);
			}
		} 
		
		public esQueryItem IsUserGroupUnApprovalAble
		{
			get
			{
				return new esQueryItem(this, AppUserGroupProgramMetadata.ColumnNames.IsUserGroupUnApprovalAble, esSystemType.Boolean);
			}
		} 
		
		public esQueryItem IsUserGroupVoidAble
		{
			get
			{
				return new esQueryItem(this, AppUserGroupProgramMetadata.ColumnNames.IsUserGroupVoidAble, esSystemType.Boolean);
			}
		} 
		
		public esQueryItem IsUserGroupUnVoidAble
		{
			get
			{
				return new esQueryItem(this, AppUserGroupProgramMetadata.ColumnNames.IsUserGroupUnVoidAble, esSystemType.Boolean);
			}
		} 
		
		public esQueryItem IsUserGroupExportAble
		{
			get
			{
				return new esQueryItem(this, AppUserGroupProgramMetadata.ColumnNames.IsUserGroupExportAble, esSystemType.Boolean);
			}
		} 
		
		public esQueryItem LastUpdateDateTime
		{
			get
			{
				return new esQueryItem(this, AppUserGroupProgramMetadata.ColumnNames.LastUpdateDateTime, esSystemType.DateTime);
			}
		} 
		
		public esQueryItem LastUpdateByUserID
		{
			get
			{
				return new esQueryItem(this, AppUserGroupProgramMetadata.ColumnNames.LastUpdateByUserID, esSystemType.String);
			}
		} 
		
	}



    [System.Diagnostics.DebuggerDisplay("Count = {Count}")]
	[Serializable]
	[XmlType("AppUserGroupProgramCollection")]
	public partial class AppUserGroupProgramCollection : esAppUserGroupProgramCollection, IEnumerable<AppUserGroupProgram>
	{
		public AppUserGroupProgramCollection()
		{

		}
		
		public static implicit operator List<AppUserGroupProgram>(AppUserGroupProgramCollection coll)
		{
			List<AppUserGroupProgram> list = new List<AppUserGroupProgram>();
			
			foreach (AppUserGroupProgram emp in coll)
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
				return  AppUserGroupProgramMetadata.Meta();
			}
		}
		
		
		
		override protected esDynamicQuery GetDynamicQuery()
		{
			if (this.query == null)
			{
				this.query = new AppUserGroupProgramQuery();
				this.InitQuery(query);
			}
			return this.query;
		}
		
		override protected esEntity CreateEntityForCollection(DataRow row)
		{
			return new AppUserGroupProgram(row);
		}

		override protected esEntity CreateEntity()
		{
			return new AppUserGroupProgram();
		}
		
		
		#endregion


		[BrowsableAttribute( false )]
		public AppUserGroupProgramQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new AppUserGroupProgramQuery();
					base.InitQuery(this.query);
				}

				return this.query;
			}
		}

		public void QueryReset()
		{
			this.query = null;
		}

		public bool Load(AppUserGroupProgramQuery query)
		{
			this.query = query;
			base.InitQuery(this.query);
			return this.Query.Load();
		}
		
		public AppUserGroupProgram AddNew()
		{
			AppUserGroupProgram entity = base.AddNewEntity() as AppUserGroupProgram;
			
			return entity;
		}

		public AppUserGroupProgram FindByPrimaryKey(System.String userGroupID, System.String programID)
		{
			return base.FindByPrimaryKey(userGroupID, programID) as AppUserGroupProgram;
		}


		#region IEnumerable<AppUserGroupProgram> Members

		IEnumerator<AppUserGroupProgram> IEnumerable<AppUserGroupProgram>.GetEnumerator()
		{
			System.Collections.IEnumerable enumer = this as System.Collections.IEnumerable;
			System.Collections.IEnumerator iterator = enumer.GetEnumerator();

			while(iterator.MoveNext())
			{
				yield return iterator.Current as AppUserGroupProgram;
			}
		}

		#endregion
		
		private AppUserGroupProgramQuery query;
	}


	/// <summary>
	/// Encapsulates the 'AppUserGroupProgram' table
	/// </summary>

    [System.Diagnostics.DebuggerDisplay("AppUserGroupProgram ({UserGroupID},{ProgramID})")]
	[Serializable]
	public partial class AppUserGroupProgram : esAppUserGroupProgram
	{
		public AppUserGroupProgram()
		{

		}
	
		public AppUserGroupProgram(DataRow row)
			: base(row)
		{

		}
		
		#region Housekeeping methods
		override protected IMetadata Meta
		{
			get
			{
				return AppUserGroupProgramMetadata.Meta();
			}
		}
		
		
		
		override protected esAppUserGroupProgramQuery GetDynamicQuery()
		{
			if (this.query == null)
			{
				this.query = new AppUserGroupProgramQuery();
				this.InitQuery(query);
			}
			return this.query;
		}
		#endregion
		



		[BrowsableAttribute( false )]
		public AppUserGroupProgramQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new AppUserGroupProgramQuery();
					base.InitQuery(this.query);
				}

				return this.query;
			}
		}

		public void QueryReset()
		{
			this.query = null;
		}
		

		public bool Load(AppUserGroupProgramQuery query)
		{
			this.query = query;
			base.InitQuery(this.query);
			return this.Query.Load();
		}
		
		private AppUserGroupProgramQuery query;
	}



    [System.Diagnostics.DebuggerDisplay("LastQuery = {es.LastQuery}")]
	[Serializable]
		
	public partial class AppUserGroupProgramQuery : esAppUserGroupProgramQuery
	{
		public AppUserGroupProgramQuery()
		{

		}		
		
		public AppUserGroupProgramQuery(string joinAlias)
		{
			this.es.JoinAlias = joinAlias;
		}	

        override protected string GetQueryName()
        {
            return "AppUserGroupProgramQuery";
        }
		
			
	}


	[Serializable]
	public partial class AppUserGroupProgramMetadata : esMetadata, IMetadata
	{
		#region Protected Constructor
		protected AppUserGroupProgramMetadata()
		{
			_columns = new esColumnMetadataCollection();
			esColumnMetadata c;

			c = new esColumnMetadata(AppUserGroupProgramMetadata.ColumnNames.UserGroupID, 0, typeof(System.String), esSystemType.String);
			c.PropertyName = AppUserGroupProgramMetadata.PropertyNames.UserGroupID;
			c.IsInPrimaryKey = true;
			c.CharacterMaxLength = 50;
			_columns.Add(c);
				
			c = new esColumnMetadata(AppUserGroupProgramMetadata.ColumnNames.ProgramID, 1, typeof(System.String), esSystemType.String);
			c.PropertyName = AppUserGroupProgramMetadata.PropertyNames.ProgramID;
			c.IsInPrimaryKey = true;
			c.CharacterMaxLength = 50;
			_columns.Add(c);
				
			c = new esColumnMetadata(AppUserGroupProgramMetadata.ColumnNames.IsUserGroupAddAble, 2, typeof(System.Boolean), esSystemType.Boolean);
			c.PropertyName = AppUserGroupProgramMetadata.PropertyNames.IsUserGroupAddAble;
			c.IsNullable = true;
			_columns.Add(c);
				
			c = new esColumnMetadata(AppUserGroupProgramMetadata.ColumnNames.IsUserGroupEditAble, 3, typeof(System.Boolean), esSystemType.Boolean);
			c.PropertyName = AppUserGroupProgramMetadata.PropertyNames.IsUserGroupEditAble;
			c.IsNullable = true;
			_columns.Add(c);
				
			c = new esColumnMetadata(AppUserGroupProgramMetadata.ColumnNames.IsUserGroupDeleteAble, 4, typeof(System.Boolean), esSystemType.Boolean);
			c.PropertyName = AppUserGroupProgramMetadata.PropertyNames.IsUserGroupDeleteAble;
			c.IsNullable = true;
			_columns.Add(c);
				
			c = new esColumnMetadata(AppUserGroupProgramMetadata.ColumnNames.IsUserGroupApprovalAble, 5, typeof(System.Boolean), esSystemType.Boolean);
			c.PropertyName = AppUserGroupProgramMetadata.PropertyNames.IsUserGroupApprovalAble;
			c.IsNullable = true;
			_columns.Add(c);
				
			c = new esColumnMetadata(AppUserGroupProgramMetadata.ColumnNames.IsUserGroupUnApprovalAble, 6, typeof(System.Boolean), esSystemType.Boolean);
			c.PropertyName = AppUserGroupProgramMetadata.PropertyNames.IsUserGroupUnApprovalAble;
			c.IsNullable = true;
			_columns.Add(c);
				
			c = new esColumnMetadata(AppUserGroupProgramMetadata.ColumnNames.IsUserGroupVoidAble, 7, typeof(System.Boolean), esSystemType.Boolean);
			c.PropertyName = AppUserGroupProgramMetadata.PropertyNames.IsUserGroupVoidAble;
			c.IsNullable = true;
			_columns.Add(c);
				
			c = new esColumnMetadata(AppUserGroupProgramMetadata.ColumnNames.IsUserGroupUnVoidAble, 8, typeof(System.Boolean), esSystemType.Boolean);
			c.PropertyName = AppUserGroupProgramMetadata.PropertyNames.IsUserGroupUnVoidAble;
			c.IsNullable = true;
			_columns.Add(c);
				
			c = new esColumnMetadata(AppUserGroupProgramMetadata.ColumnNames.IsUserGroupExportAble, 9, typeof(System.Boolean), esSystemType.Boolean);
			c.PropertyName = AppUserGroupProgramMetadata.PropertyNames.IsUserGroupExportAble;
			c.IsNullable = true;
			_columns.Add(c);
				
			c = new esColumnMetadata(AppUserGroupProgramMetadata.ColumnNames.LastUpdateDateTime, 10, typeof(System.DateTime), esSystemType.DateTime);
			c.PropertyName = AppUserGroupProgramMetadata.PropertyNames.LastUpdateDateTime;
			c.IsNullable = true;
			_columns.Add(c);
				
			c = new esColumnMetadata(AppUserGroupProgramMetadata.ColumnNames.LastUpdateByUserID, 11, typeof(System.String), esSystemType.String);
			c.PropertyName = AppUserGroupProgramMetadata.PropertyNames.LastUpdateByUserID;
			c.CharacterMaxLength = 50;
			c.IsNullable = true;
			_columns.Add(c);
				
		}
		#endregion	
	
		static public AppUserGroupProgramMetadata Meta()
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
			 public const string UserGroupID = "UserGroupID";
			 public const string ProgramID = "ProgramID";
			 public const string IsUserGroupAddAble = "IsUserGroupAddAble";
			 public const string IsUserGroupEditAble = "IsUserGroupEditAble";
			 public const string IsUserGroupDeleteAble = "IsUserGroupDeleteAble";
			 public const string IsUserGroupApprovalAble = "IsUserGroupApprovalAble";
			 public const string IsUserGroupUnApprovalAble = "IsUserGroupUnApprovalAble";
			 public const string IsUserGroupVoidAble = "IsUserGroupVoidAble";
			 public const string IsUserGroupUnVoidAble = "IsUserGroupUnVoidAble";
			 public const string IsUserGroupExportAble = "IsUserGroupExportAble";
			 public const string LastUpdateDateTime = "LastUpdateDateTime";
			 public const string LastUpdateByUserID = "LastUpdateByUserID";
		}
		#endregion	
		
		#region PropertyNames
		public class PropertyNames
		{ 
			 public const string UserGroupID = "UserGroupID";
			 public const string ProgramID = "ProgramID";
			 public const string IsUserGroupAddAble = "IsUserGroupAddAble";
			 public const string IsUserGroupEditAble = "IsUserGroupEditAble";
			 public const string IsUserGroupDeleteAble = "IsUserGroupDeleteAble";
			 public const string IsUserGroupApprovalAble = "IsUserGroupApprovalAble";
			 public const string IsUserGroupUnApprovalAble = "IsUserGroupUnApprovalAble";
			 public const string IsUserGroupVoidAble = "IsUserGroupVoidAble";
			 public const string IsUserGroupUnVoidAble = "IsUserGroupUnVoidAble";
			 public const string IsUserGroupExportAble = "IsUserGroupExportAble";
			 public const string LastUpdateDateTime = "LastUpdateDateTime";
			 public const string LastUpdateByUserID = "LastUpdateByUserID";
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
			lock (typeof(AppUserGroupProgramMetadata))
			{
				if(AppUserGroupProgramMetadata.mapDelegates == null)
				{
					AppUserGroupProgramMetadata.mapDelegates = new Dictionary<string,MapToMeta>();
				}
				
				if (AppUserGroupProgramMetadata.meta == null)
				{
					AppUserGroupProgramMetadata.meta = new AppUserGroupProgramMetadata();
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
				

				meta.AddTypeMap("UserGroupID", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("ProgramID", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("IsUserGroupAddAble", new esTypeMap("bit", "System.Boolean"));
				meta.AddTypeMap("IsUserGroupEditAble", new esTypeMap("bit", "System.Boolean"));
				meta.AddTypeMap("IsUserGroupDeleteAble", new esTypeMap("bit", "System.Boolean"));
				meta.AddTypeMap("IsUserGroupApprovalAble", new esTypeMap("bit", "System.Boolean"));
				meta.AddTypeMap("IsUserGroupUnApprovalAble", new esTypeMap("bit", "System.Boolean"));
				meta.AddTypeMap("IsUserGroupVoidAble", new esTypeMap("bit", "System.Boolean"));
				meta.AddTypeMap("IsUserGroupUnVoidAble", new esTypeMap("bit", "System.Boolean"));
				meta.AddTypeMap("IsUserGroupExportAble", new esTypeMap("bit", "System.Boolean"));
				meta.AddTypeMap("LastUpdateDateTime", new esTypeMap("datetime", "System.DateTime"));
				meta.AddTypeMap("LastUpdateByUserID", new esTypeMap("nvarchar", "System.String"));			
				
				
				
				meta.Source = "AppUserGroupProgram";
				meta.Destination = "AppUserGroupProgram";
				
				meta.spInsert = "proc_AppUserGroupProgramInsert";				
				meta.spUpdate = "proc_AppUserGroupProgramUpdate";		
				meta.spDelete = "proc_AppUserGroupProgramDelete";
				meta.spLoadAll = "proc_AppUserGroupProgramLoadAll";
				meta.spLoadByPrimaryKey = "proc_AppUserGroupProgramLoadByPrimaryKey";
				
				this._providerMetadataMaps["esDefault"] = meta;
			}
			
			return this._providerMetadataMaps["esDefault"];
		}

		#endregion

		static private AppUserGroupProgramMetadata meta;
		static protected Dictionary<string, MapToMeta> mapDelegates;
		static private int _esDefault = RegisterDelegateesDefault();
	}
}
