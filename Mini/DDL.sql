USE [DC_EDU_SH]
GO
/****** Object:  Table [dbo].[TB_INSPLISTBYROH]    Script Date: 2022-07-12 오후 6:53:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TB_INSPLISTBYROH](
	[PLANTCODE] [varchar](10) NOT NULL,
	[ITEMCODE] [varchar](20) NOT NULL,
	[INSPCODE] [varchar](10) NOT NULL,
	[REMARK] [varchar](200) NULL,
	[USEFLAG] [varchar](1) NOT NULL,
	[MAKEDATE] [datetime] NOT NULL,
	[MAKER] [varchar](10) NOT NULL,
	[EDITDATE] [datetime] NULL,
	[EDITOR] [varchar](10) NULL,
 CONSTRAINT [PK_TB_INSPLISTBYROH] PRIMARY KEY CLUSTERED 
(
	[PLANTCODE] ASC,
	[ITEMCODE] ASC,
	[INSPCODE] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TB_IQIMASTER]    Script Date: 2022-07-12 오후 6:53:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TB_IQIMASTER](
	[PLANTCODE] [varchar](10) NOT NULL,
	[INSPCODE] [varchar](10) NOT NULL,
	[INSPNAME] [varchar](30) NOT NULL,
	[INSPTYPE] [varchar](10) NOT NULL,
	[POSpec] [varchar](50) NOT NULL,
	[LSL] [float] NOT NULL,
	[USL] [float] NOT NULL,
	[REMARK] [varchar](200) NULL,
	[USEFLAG] [varchar](1) NOT NULL,
	[MAKEDATE] [datetime] NOT NULL,
	[MAKER] [varchar](10) NOT NULL,
	[EDITDATE] [datetime] NULL,
	[EDITOR] [varchar](10) NULL,
 CONSTRAINT [PK_TB_IQIMASTER] PRIMARY KEY CLUSTERED 
(
	[PLANTCODE] ASC,
	[INSPCODE] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TB_ROHIQI]    Script Date: 2022-07-12 오후 6:53:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TB_ROHIQI](
	[PLANTCODE] [varchar](10) NOT NULL,
	[LOTNO] [varchar](30) NOT NULL,
	[INSPSEQ] [varchar](20) NOT NULL,
	[REQDATE] [datetime] NOT NULL,
	[REQUESTER] [varchar](20) NOT NULL,
	[ITEMCODE] [varchar](20) NOT NULL,
	[INSPQTY] [float] NOT NULL,
	[INSPECTOR] [varchar](20) NULL,
	[INSPDATETIME] [datetime] NULL,
	[INSPRESULT] [varchar](1) NULL,
	[INSPVALUE] [varchar](50) NULL,
	[MAKEDATE] [datetime] NOT NULL,
	[MAKER] [varchar](10) NOT NULL,
	[EDITDATE] [datetime] NULL,
	[EDITOR] [varchar](10) NULL,
 CONSTRAINT [PK_TB_ROHIQI] PRIMARY KEY CLUSTERED 
(
	[PLANTCODE] ASC,
	[LOTNO] ASC,
	[INSPSEQ] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TB_ROHIQIREC]    Script Date: 2022-07-12 오후 6:53:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TB_ROHIQIREC](
	[PLANTCODE] [varchar](10) NOT NULL,
	[LOTNO] [varchar](30) NOT NULL,
	[INSPCODE] [varchar](10) NOT NULL,
	[INSPSEQ] [varchar](20) NOT NULL,
	[REQDATE] [datetime] NOT NULL,
	[REQUESTER] [varchar](20) NOT NULL,
	[ITEMCODE] [varchar](20) NOT NULL,
	[INSPQTY] [float] NOT NULL,
	[INSPECTOR] [varchar](20) NULL,
	[INSPDATETIME] [datetime] NULL,
	[INSPRESULT] [varchar](1) NULL,
	[INSPVALUE] [varchar](50) NULL,
	[MAKEDATE] [datetime] NOT NULL,
	[MAKER] [varchar](10) NOT NULL,
 CONSTRAINT [PK_TB_ROHIQIREC] PRIMARY KEY CLUSTERED 
(
	[PLANTCODE] ASC,
	[LOTNO] ASC,
	[INSPCODE] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[TB_IQIMASTER] ADD  CONSTRAINT [DF_TB_IQIMASTER_USEFLAG]  DEFAULT ('Y') FOR [USEFLAG]
GO
ALTER TABLE [dbo].[TB_IQIMASTER] ADD  CONSTRAINT [DF_TB_IQIMASTER_MAKEDATE]  DEFAULT (getdate()) FOR [MAKEDATE]
GO
ALTER TABLE [dbo].[TB_ROHIQI] ADD  CONSTRAINT [DF_TB_ROHIQI_MAKEDATE]  DEFAULT (getdate()) FOR [MAKEDATE]
GO
ALTER TABLE [dbo].[TB_ROHIQIREC] ADD  CONSTRAINT [DF_TB_ROHIQIREC_MAKEDATE]  DEFAULT (getdate()) FOR [MAKEDATE]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'공장 코드' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_INSPLISTBYROH', @level2type=N'COLUMN',@level2name=N'PLANTCODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'품번' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_INSPLISTBYROH', @level2type=N'COLUMN',@level2name=N'ITEMCODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'검사 코드' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_INSPLISTBYROH', @level2type=N'COLUMN',@level2name=N'INSPCODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'비고' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_INSPLISTBYROH', @level2type=N'COLUMN',@level2name=N'REMARK'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'사용여부' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_INSPLISTBYROH', @level2type=N'COLUMN',@level2name=N'USEFLAG'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'등록 일시' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_INSPLISTBYROH', @level2type=N'COLUMN',@level2name=N'MAKEDATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'등록자' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_INSPLISTBYROH', @level2type=N'COLUMN',@level2name=N'MAKER'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'등록자' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_INSPLISTBYROH', @level2type=N'COLUMN',@level2name=N'EDITDATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'수정자' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_INSPLISTBYROH', @level2type=N'COLUMN',@level2name=N'EDITOR'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'공장 코드' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_IQIMASTER', @level2type=N'COLUMN',@level2name=N'PLANTCODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'검사 코드' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_IQIMASTER', @level2type=N'COLUMN',@level2name=N'INSPCODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'검사 명칭' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_IQIMASTER', @level2type=N'COLUMN',@level2name=N'INSPNAME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'검사 유형' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_IQIMASTER', @level2type=N'COLUMN',@level2name=N'INSPTYPE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'관련 규정' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_IQIMASTER', @level2type=N'COLUMN',@level2name=N'POSpec'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'LSL' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_IQIMASTER', @level2type=N'COLUMN',@level2name=N'LSL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'관리 상한선' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_IQIMASTER', @level2type=N'COLUMN',@level2name=N'USL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'비고' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_IQIMASTER', @level2type=N'COLUMN',@level2name=N'REMARK'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'사용여부' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_IQIMASTER', @level2type=N'COLUMN',@level2name=N'USEFLAG'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'등록 일시' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_IQIMASTER', @level2type=N'COLUMN',@level2name=N'MAKEDATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'등록자' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_IQIMASTER', @level2type=N'COLUMN',@level2name=N'MAKER'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'수정일시' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_IQIMASTER', @level2type=N'COLUMN',@level2name=N'EDITDATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'수정자' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_IQIMASTER', @level2type=N'COLUMN',@level2name=N'EDITOR'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'공장 코드' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_ROHIQI', @level2type=N'COLUMN',@level2name=N'PLANTCODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Lot No' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_ROHIQI', @level2type=N'COLUMN',@level2name=N'LOTNO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'검사 시퀀스' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_ROHIQI', @level2type=N'COLUMN',@level2name=N'INSPSEQ'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'요청 일시' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_ROHIQI', @level2type=N'COLUMN',@level2name=N'REQDATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'요청자 ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_ROHIQI', @level2type=N'COLUMN',@level2name=N'REQUESTER'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'품번' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_ROHIQI', @level2type=N'COLUMN',@level2name=N'ITEMCODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'검사 수량' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_ROHIQI', @level2type=N'COLUMN',@level2name=N'INSPQTY'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'검사원 ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_ROHIQI', @level2type=N'COLUMN',@level2name=N'INSPECTOR'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'검사 일시' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_ROHIQI', @level2type=N'COLUMN',@level2name=N'INSPDATETIME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'검사 결과' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_ROHIQI', @level2type=N'COLUMN',@level2name=N'INSPRESULT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'검사 값' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_ROHIQI', @level2type=N'COLUMN',@level2name=N'INSPVALUE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'등록일시' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_ROHIQI', @level2type=N'COLUMN',@level2name=N'MAKEDATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'등록자' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_ROHIQI', @level2type=N'COLUMN',@level2name=N'MAKER'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'수정 일시' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_ROHIQI', @level2type=N'COLUMN',@level2name=N'EDITDATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'수정자' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_ROHIQI', @level2type=N'COLUMN',@level2name=N'EDITOR'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'원자재 수입검사 요청 및 결과' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_ROHIQI'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'공장 코드' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_ROHIQIREC', @level2type=N'COLUMN',@level2name=N'PLANTCODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Lot No' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_ROHIQIREC', @level2type=N'COLUMN',@level2name=N'LOTNO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'검사 코드' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_ROHIQIREC', @level2type=N'COLUMN',@level2name=N'INSPCODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'검사 시퀀스' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_ROHIQIREC', @level2type=N'COLUMN',@level2name=N'INSPSEQ'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'요청 일시' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_ROHIQIREC', @level2type=N'COLUMN',@level2name=N'REQDATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'요청자 ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_ROHIQIREC', @level2type=N'COLUMN',@level2name=N'REQUESTER'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'품번' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_ROHIQIREC', @level2type=N'COLUMN',@level2name=N'ITEMCODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'검사 수량' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_ROHIQIREC', @level2type=N'COLUMN',@level2name=N'INSPQTY'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'검사원 ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_ROHIQIREC', @level2type=N'COLUMN',@level2name=N'INSPECTOR'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'검사 일시' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_ROHIQIREC', @level2type=N'COLUMN',@level2name=N'INSPDATETIME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'검사 결과' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_ROHIQIREC', @level2type=N'COLUMN',@level2name=N'INSPRESULT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'검사 값' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_ROHIQIREC', @level2type=N'COLUMN',@level2name=N'INSPVALUE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'등록 일시' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_ROHIQIREC', @level2type=N'COLUMN',@level2name=N'MAKEDATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'등록자' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_ROHIQIREC', @level2type=N'COLUMN',@level2name=N'MAKER'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'원자재 수입검사 결과 이력' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_ROHIQIREC'
GO
