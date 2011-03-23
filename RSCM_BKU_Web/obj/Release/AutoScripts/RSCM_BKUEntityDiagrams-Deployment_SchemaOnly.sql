SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Group_MA](
	[GT_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[GT_CODE] [nvarchar](15) COLLATE Latin1_General_CI_AS NOT NULL,
	[USER_INSERT] [nvarchar](50) COLLATE Latin1_General_CI_AS NULL,
	[TGL_INSERT] [datetime] NULL,
	[USER_UPDATE] [nvarchar](50) COLLATE Latin1_General_CI_AS NULL,
	[TGL_UPDATE] [datetime] NULL,
 CONSTRAINT [PK1] PRIMARY KEY NONCLUSTERED 
(
	[GT_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON),
 CONSTRAINT [IX_Group_MA] UNIQUE NONCLUSTERED 
(
	[GT_CODE] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DebitKredit](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[type] [nvarchar](1) COLLATE Latin1_General_CI_AS NOT NULL,
 CONSTRAINT [PK_Type] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AUTO_NUMBERING](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[KA_CODE] [nvarchar](15) COLLATE Latin1_General_CI_AS NULL,
	[KA_YEAR] [nvarchar](4) COLLATE Latin1_General_CI_AS NOT NULL,
	[KA_MONTH] [nvarchar](2) COLLATE Latin1_General_CI_AS NOT NULL,
	[LAST_NUMBER] [int] NOT NULL,
	[PREFIX] [nvarchar](10) COLLATE Latin1_General_CI_AS NULL,
	[PREFIX_NUMBER] [nvarchar](3) COLLATE Latin1_General_CI_AS NOT NULL,
 CONSTRAINT [PK_AUTO_NUMBERING] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Audit_Trail](
	[AT_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[AKSI] [nvarchar](50) COLLATE Latin1_General_CI_AS NULL,
	[ITEM_ACTION] [nvarchar](200) COLLATE Latin1_General_CI_AS NULL,
	[FROM_BE] [nvarchar](100) COLLATE Latin1_General_CI_AS NULL,
	[TO_BE] [nvarchar](100) COLLATE Latin1_General_CI_AS NULL,
	[USERBY] [nvarchar](100) COLLATE Latin1_General_CI_AS NULL,
	[DATE_ACTION] [datetime] NULL,
 CONSTRAINT [PK6] PRIMARY KEY NONCLUSTERED 
(
	[AT_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AppUserUserGroup](
	[UserID] [nvarchar](50) COLLATE Latin1_General_CI_AS NOT NULL,
	[UserGroupID] [nvarchar](50) COLLATE Latin1_General_CI_AS NOT NULL,
	[LastUpdateDateTime] [datetime] NULL,
	[LastUpdateByUserID] [nvarchar](50) COLLATE Latin1_General_CI_AS NULL,
 CONSTRAINT [PK_appUserUserGroup] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC,
	[UserGroupID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AppUserGroupProgram](
	[UserGroupID] [nvarchar](50) COLLATE Latin1_General_CI_AS NOT NULL,
	[ProgramID] [nvarchar](50) COLLATE Latin1_General_CI_AS NOT NULL,
	[IsUserGroupAddAble] [bit] NULL,
	[IsUserGroupEditAble] [bit] NULL,
	[IsUserGroupDeleteAble] [bit] NULL,
	[IsUserGroupApprovalAble] [bit] NULL,
	[IsUserGroupUnApprovalAble] [bit] NULL,
	[IsUserGroupVoidAble] [bit] NULL,
	[IsUserGroupUnVoidAble] [bit] NULL,
	[IsUserGroupExportAble] [bit] NULL,
	[LastUpdateDateTime] [datetime] NULL,
	[LastUpdateByUserID] [nvarchar](50) COLLATE Latin1_General_CI_AS NULL,
 CONSTRAINT [PK_appUserGroupProgram] PRIMARY KEY CLUSTERED 
(
	[UserGroupID] ASC,
	[ProgramID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AppUserGroup](
	[UserGroupID] [nvarchar](50) COLLATE Latin1_General_CI_AS NOT NULL,
	[UserGroupName] [nvarchar](50) COLLATE Latin1_General_CI_AS NOT NULL,
	[IsEditAble] [bit] NOT NULL,
	[LastUpdateDateTime] [datetime] NULL,
	[LastUpdateByUserID] [nvarchar](50) COLLATE Latin1_General_CI_AS NULL,
 CONSTRAINT [PK_appUserGroup] PRIMARY KEY CLUSTERED 
(
	[UserGroupID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AppUser](
	[UserID] [nvarchar](50) COLLATE Latin1_General_CI_AS NOT NULL,
	[UserName] [nvarchar](50) COLLATE Latin1_General_CI_AS NOT NULL,
	[Password] [nvarchar](50) COLLATE Latin1_General_CI_AS NOT NULL,
	[SRLanguage] [nvarchar](50) COLLATE Latin1_General_CI_AS NULL,
	[ActiveDate] [datetime] NULL,
	[ExpireDate] [datetime] NULL,
	[LastUpdateDateTime] [datetime] NULL,
	[LastUpdateByUserID] [nvarchar](50) COLLATE Latin1_General_CI_AS NULL,
 CONSTRAINT [PK_appUser] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AppProgram](
	[ProgramID] [nvarchar](30) COLLATE Latin1_General_CI_AS NOT NULL,
	[ParentProgramID] [nvarchar](50) COLLATE Latin1_General_CI_AS NULL,
	[ProgramName] [nvarchar](100) COLLATE Latin1_General_CI_AS NOT NULL,
	[TopLevelProgramID] [nvarchar](50) COLLATE Latin1_General_CI_AS NULL,
	[RootLevel] [tinyint] NOT NULL,
	[RowIndex] [tinyint] NOT NULL,
	[Note] [nvarchar](1000) COLLATE Latin1_General_CI_AS NULL,
	[IsParentProgram] [bit] NULL,
	[IsProgram] [bit] NULL,
	[IsBeginGroup] [bit] NULL,
	[ProgramType] [varchar](5) COLLATE Latin1_General_CI_AS NULL,
	[IsProgramAddAble] [bit] NULL,
	[IsProgramEditAble] [bit] NULL,
	[IsProgramDeleteAble] [bit] NULL,
	[IsProgramViewAble] [bit] NULL,
	[IsProgramApprovalAble] [bit] NULL,
	[IsProgramUnApprovalAble] [bit] NULL,
	[IsProgramVoidAble] [bit] NULL,
	[IsProgramUnVoidAble] [bit] NULL,
	[IsProgramDirectVoid] [bit] NULL,
	[IsProgramPrintAble] [bit] NULL,
	[IsMenuAddVisible] [bit] NULL,
	[IsMenuHomeVisible] [bit] NULL,
	[IsVisible] [bit] NULL,
	[IsDiscontinue] [bit] NOT NULL,
	[NavigateUrl] [nvarchar](1000) COLLATE Latin1_General_CI_AS NULL,
	[HelpLinkID] [nvarchar](255) COLLATE Latin1_General_CI_AS NULL,
	[AssemblyName] [nvarchar](50) COLLATE Latin1_General_CI_AS NULL,
	[AssemblyClassName] [nvarchar](200) COLLATE Latin1_General_CI_AS NULL,
	[StoreProcedureName] [nvarchar](200) COLLATE Latin1_General_CI_AS NULL,
 CONSTRAINT [PK_appProgram] PRIMARY KEY CLUSTERED 
(
	[ProgramID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PeriodeAnggaran](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[Start_Period] [datetime] NOT NULL,
	[End_Period] [datetime] NULL,
	[Is_Closed] [bit] NOT NULL,
 CONSTRAINT [PK_PeriodeAnggaran] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Monthly_Balance](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[KA_CODE] [nvarchar](15) COLLATE Latin1_General_CI_AS NOT NULL,
	[MONTH] [nvarchar](2) COLLATE Latin1_General_CI_AS NOT NULL,
	[YEAR] [nvarchar](4) COLLATE Latin1_General_CI_AS NOT NULL,
	[INIT_BALANCE] [numeric](18, 2) NOT NULL,
	[DEBIT] [numeric](18, 2) NOT NULL,
	[KREDIT] [numeric](18, 2) NOT NULL,
	[FINAL_BALANCE] [numeric](18, 2) NOT NULL,
	[USER_INSERT] [nvarchar](50) COLLATE Latin1_General_CI_AS NULL,
	[USER_UPDATE] [nvarchar](50) COLLATE Latin1_General_CI_AS NULL,
	[TGL_INSERT] [datetime] NULL,
	[TGL_UPDATE] [datetime] NULL,
 CONSTRAINT [PK_Monthly_Balance] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[levelMA](
	[id] [int] IDENTITY(0,1) NOT NULL,
	[level] [nvarchar](1) COLLATE Latin1_General_CI_AS NOT NULL,
 CONSTRAINT [PK_levelMA] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[schema_migrations](
	[version] [varchar](255) COLLATE Latin1_General_CI_AS NOT NULL
)

GO

CREATE UNIQUE NONCLUSTERED INDEX [unique_schema_migrations] ON [dbo].[schema_migrations] 
(
	[version] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[toros](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[created_at] [datetime] NULL,
	[updated_at] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spRadMenuDataSource]	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	select distinct a.ProgramID,a.ParentProgramID,a.ProgramName,a.IsBeginGroup,a.IsDiscontinue,a.IsVisible,a.RowIndex,a.IsParentProgram,a.NavigateUrl from RSCM_BKU.dbo.AppProgram a
inner join RSCM_BKU.dbo.AppUserGroupProgram b
	on a.ProgramID = b.ProgramID 
inner join RSCM_BKU.dbo.AppUserUserGroup c
	on b.UserGroupID = c.UserGroupID 
where c.UserID = 'toro' and a.IsVisible = 1 
order by a.ParentProgramID,a.RowIndex 
asc
END

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kel_anggaran](
	[KA_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[KA_CODE] [nvarchar](15) COLLATE Latin1_General_CI_AS NOT NULL,
	[KA_NAME] [nvarchar](256) COLLATE Latin1_General_CI_AS NOT NULL,
	[GT_CODE] [nvarchar](15) COLLATE Latin1_General_CI_AS NOT NULL,
	[PREFIX] [nvarchar](10) COLLATE Latin1_General_CI_AS NULL,
	[IS_DETAIL] [bit] NOT NULL,
	[KA_LEVEL] [nvarchar](10) COLLATE Latin1_General_CI_AS NOT NULL,
	[PARENT_CODE] [nvarchar](15) COLLATE Latin1_General_CI_AS NULL,
	[TYPE] [nvarchar](1) COLLATE Latin1_General_CI_AS NULL,
	[IS_ACTIVE] [bit] NOT NULL,
	[IS_KAS] [bit] NULL,
	[USER_INSERT] [nvarchar](50) COLLATE Latin1_General_CI_AS NULL,
	[TGL_INSERT] [datetime] NULL,
	[USER_UPDATE] [nvarchar](50) COLLATE Latin1_General_CI_AS NULL,
	[TGL_UPDATE] [datetime] NULL,
 CONSTRAINT [PK4] PRIMARY KEY NONCLUSTERED 
(
	[KA_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON),
 CONSTRAINT [IX_Kel_anggaran] UNIQUE NONCLUSTERED 
(
	[KA_CODE] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW dbo.RadMenuDataSource
AS
SELECT DISTINCT dbo.AppProgram.ProgramID, dbo.AppProgram.ParentProgramID, dbo.AppProgram.ProgramName, dbo.AppProgram.NavigateUrl, dbo.AppUser.UserID
FROM         dbo.AppProgram INNER JOIN
                      dbo.AppUserGroupProgram ON dbo.AppProgram.ProgramID = dbo.AppUserGroupProgram.ProgramID INNER JOIN
                      dbo.AppUserUserGroup ON dbo.AppUserGroupProgram.UserGroupID = dbo.AppUserUserGroup.UserGroupID CROSS JOIN
                      dbo.AppUser CROSS JOIN
                      dbo.AppUserGroup

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RAB](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[KA_CODE] [nvarchar](15) COLLATE Latin1_General_CI_AS NOT NULL,
	[PERIOD_ID] [bigint] NOT NULL,
	[RAB] [numeric](15, 2) NOT NULL,
 CONSTRAINT [PK_RAB] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KAS](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[KA_CODE] [nvarchar](15) COLLATE Latin1_General_CI_AS NOT NULL,
	[KA_NAME] [nvarchar](256) COLLATE Latin1_General_CI_AS NOT NULL,
	[SALDO_AWAL] [numeric](15, 2) NOT NULL,
	[PERIODE_ID] [bigint] NOT NULL,
 CONSTRAINT [PK_KAS] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW dbo.ParentId_DataSource_ComboBox
AS
SELECT     KA_CODE, KA_NAME
FROM         dbo.Kel_anggaran
WHERE KA_LEVEL < 3 AND IS_DETAIL = 0
UNION
SELECT     '' AS KA_CODE, '' AS KA_NAME

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW dbo.Kas_DataSource_ComboBox
AS
SELECT     KA_CODE, KA_NAME
FROM         dbo.Kel_anggaran
WHERE     (IS_KAS = 1)

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW dbo.SaldoAwal
AS
SELECT     SUM(dbo.KAS.SALDO_AWAL) AS SALDO_AWAL, dbo.PeriodeAnggaran.Is_Closed
FROM         dbo.KAS INNER JOIN
                      dbo.PeriodeAnggaran ON dbo.KAS.PERIODE_ID = dbo.PeriodeAnggaran.id
GROUP BY dbo.PeriodeAnggaran.Is_Closed
HAVING      (dbo.PeriodeAnggaran.Is_Closed = 0)

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Trans](
	[BKU_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[KA_CODE] [nvarchar](15) COLLATE Latin1_General_CI_AS NOT NULL,
	[TRANS_NUMBER] [nvarchar](18) COLLATE Latin1_General_CI_AS NOT NULL,
	[TRANS_DATE] [datetime] NOT NULL,
	[DESCRIPT] [nvarchar](100) COLLATE Latin1_General_CI_AS NULL,
	[DEBIT_AMOUNT] [numeric](15, 2) NULL,
	[CREDIT_AMOUNT] [numeric](15, 2) NULL,
	[CEK_BG_NUMBER] [nvarchar](15) COLLATE Latin1_General_CI_AS NULL,
	[PERIOD_ID] [bigint] NULL,
	[ISVERIFIED] [bit] NOT NULL,
	[IS_CLOSED] [bit] NOT NULL,
	[KAS_ID] [nvarchar](15) COLLATE Latin1_General_CI_AS NOT NULL,
	[USER_INSERT] [nvarchar](50) COLLATE Latin1_General_CI_AS NULL,
	[TGL_INSERT] [datetime] NULL,
	[USER_UPDATE] [nvarchar](50) COLLATE Latin1_General_CI_AS NULL,
	[TGL_UPDATE] [datetime] NULL,
 CONSTRAINT [PK3] PRIMARY KEY NONCLUSTERED 
(
	[BKU_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW dbo.transaksiBKU
AS
SELECT     dbo.Trans.TRANS_NUMBER, dbo.Trans.TRANS_DATE, dbo.Trans.DESCRIPT, dbo.Trans.KA_CODE, dbo.Kel_anggaran.KA_NAME, dbo.Group_MA.GT_CODE, 
                      dbo.Trans.DEBIT_AMOUNT, dbo.Trans.CREDIT_AMOUNT, dbo.Trans.IS_CLOSED, dbo.Trans.ISVERIFIED, dbo.Kel_anggaran.IS_ACTIVE
FROM         dbo.Trans INNER JOIN
                      dbo.Kel_anggaran ON dbo.Trans.KA_CODE = dbo.Kel_anggaran.KA_CODE INNER JOIN
                      dbo.Group_MA ON dbo.Kel_anggaran.GT_CODE = dbo.Group_MA.GT_CODE INNER JOIN
                      dbo.KAS ON dbo.Trans.KAS_ID = dbo.KAS.KA_CODE
WHERE     (dbo.Trans.IS_CLOSED = 0)

GO
ALTER TABLE [dbo].[AUTO_NUMBERING] ADD  CONSTRAINT [DF_AUTO_NUMBERING_LAST_NUMBER]  DEFAULT ((0)) FOR [LAST_NUMBER]
GO
ALTER TABLE [dbo].[AppUserUserGroup] ADD  CONSTRAINT [DF_appUserUserGroup_UserGroupID]  DEFAULT ((0)) FOR [UserGroupID]
GO
ALTER TABLE [dbo].[AppUser] ADD  CONSTRAINT [DF_AppUser_SRLanguageID]  DEFAULT ('id-ID') FOR [SRLanguage]
GO
ALTER TABLE [dbo].[AppProgram] ADD  CONSTRAINT [DF_Table_1_MenuID]  DEFAULT ('') FOR [ProgramID]
GO
ALTER TABLE [dbo].[AppProgram] ADD  CONSTRAINT [DF_Table_1_MenuCaption]  DEFAULT ('') FOR [ProgramName]
GO
ALTER TABLE [dbo].[AppProgram] ADD  CONSTRAINT [DF_Table_1_MenuLevel]  DEFAULT ((0)) FOR [RootLevel]
GO
ALTER TABLE [dbo].[AppProgram] ADD  CONSTRAINT [DF_Table_1_MenuIndex]  DEFAULT ((0)) FOR [RowIndex]
GO
ALTER TABLE [dbo].[AppProgram] ADD  CONSTRAINT [DF_Table_1_MenuTooltip]  DEFAULT ('') FOR [Note]
GO
ALTER TABLE [dbo].[AppProgram] ADD  CONSTRAINT [DF_AppProgram_IsParentProgram]  DEFAULT ((0)) FOR [IsParentProgram]
GO
ALTER TABLE [dbo].[AppProgram] ADD  CONSTRAINT [DF_AppProgram_IsProgram]  DEFAULT ((1)) FOR [IsProgram]
GO
ALTER TABLE [dbo].[AppProgram] ADD  CONSTRAINT [DF_AppProgram_IsBeginGroup]  DEFAULT ((0)) FOR [IsBeginGroup]
GO
ALTER TABLE [dbo].[AppProgram] ADD  CONSTRAINT [DF_AppProgram_IsDiscontinue1]  DEFAULT ((0)) FOR [IsVisible]
GO
ALTER TABLE [dbo].[AppProgram] ADD  CONSTRAINT [DF_appProgram_IsDiscontinue]  DEFAULT ((0)) FOR [IsDiscontinue]
GO
ALTER TABLE [dbo].[Monthly_Balance] ADD  CONSTRAINT [DF_Monthly_Balance_INIT_BALANCE]  DEFAULT ((0)) FOR [INIT_BALANCE]
GO
ALTER TABLE [dbo].[Monthly_Balance] ADD  CONSTRAINT [DF_Monthly_Balance_DEBIT]  DEFAULT ((0)) FOR [DEBIT]
GO
ALTER TABLE [dbo].[Monthly_Balance] ADD  CONSTRAINT [DF_Monthly_Balance_KREDIT]  DEFAULT ((0)) FOR [KREDIT]
GO
ALTER TABLE [dbo].[Monthly_Balance] ADD  CONSTRAINT [DF_Monthly_Balance_FINAL_BALANCE]  DEFAULT ((0)) FOR [FINAL_BALANCE]
GO
ALTER TABLE [dbo].[Kel_anggaran]  WITH CHECK ADD  CONSTRAINT [FK_Kel_anggaran_Group_MA] FOREIGN KEY([GT_CODE])
REFERENCES [dbo].[Group_MA] ([GT_CODE])
GO
ALTER TABLE [dbo].[Kel_anggaran] CHECK CONSTRAINT [FK_Kel_anggaran_Group_MA]
GO
ALTER TABLE [dbo].[Kel_anggaran] ADD  CONSTRAINT [DF_Kel_anggaran_TYPE]  DEFAULT (N'D') FOR [TYPE]
GO
ALTER TABLE [dbo].[RAB]  WITH CHECK ADD  CONSTRAINT [FK_RAB_PeriodeAnggaran] FOREIGN KEY([PERIOD_ID])
REFERENCES [dbo].[PeriodeAnggaran] ([id])
GO
ALTER TABLE [dbo].[RAB] CHECK CONSTRAINT [FK_RAB_PeriodeAnggaran]
GO
ALTER TABLE [dbo].[KAS]  WITH CHECK ADD  CONSTRAINT [FK_KAS_PeriodeAnggaran] FOREIGN KEY([PERIODE_ID])
REFERENCES [dbo].[PeriodeAnggaran] ([id])
GO
ALTER TABLE [dbo].[KAS] CHECK CONSTRAINT [FK_KAS_PeriodeAnggaran]
GO
ALTER TABLE [dbo].[Trans]  WITH CHECK ADD  CONSTRAINT [FK_Trans_Kel_anggaran] FOREIGN KEY([KA_CODE])
REFERENCES [dbo].[Kel_anggaran] ([KA_CODE])
GO
ALTER TABLE [dbo].[Trans] CHECK CONSTRAINT [FK_Trans_Kel_anggaran]
GO
ALTER TABLE [dbo].[Trans]  WITH CHECK ADD  CONSTRAINT [FK_Trans_PeriodeAnggaran] FOREIGN KEY([PERIOD_ID])
REFERENCES [dbo].[PeriodeAnggaran] ([id])
GO
ALTER TABLE [dbo].[Trans] CHECK CONSTRAINT [FK_Trans_PeriodeAnggaran]
GO
ALTER TABLE [dbo].[Trans] ADD  CONSTRAINT [DF_Trans_DEBIT_AMOUNT]  DEFAULT ((0)) FOR [DEBIT_AMOUNT]
GO
ALTER TABLE [dbo].[Trans] ADD  CONSTRAINT [DF_Trans_CREDIT_AMOUNT]  DEFAULT ((0)) FOR [CREDIT_AMOUNT]
GO
ALTER TABLE [dbo].[Trans] ADD  CONSTRAINT [DF_Trans_ISVERIFIED]  DEFAULT ((0)) FOR [ISVERIFIED]
GO
ALTER TABLE [dbo].[Trans] ADD  CONSTRAINT [DF_Trans_IS_CLOSED]  DEFAULT ((0)) FOR [IS_CLOSED]
GO
