CREATE TABLE [dbo].[CLIENTE](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Rut] [nvarchar](20) NOT NULL,
	[Nombre] [nvarchar](200) NOT NULL,
	[Apellido] [nvarchar](200) NOT NULL,
	[TipoCliente] [nvarchar](20) NOT NULL,
	[Estado] [int] NOT NULL,
 CONSTRAINT [PK_CLIENTE] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [IX_CLIENTE_RUT] UNIQUE NONCLUSTERED 
(
	[Rut] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

INSERT INTO [dbo].[CLIENTE]
           ([Rut]
           ,[Nombre]
           ,[Apellido]
           ,[TipoCliente]
           ,[Estado])
     VALUES
           ('123335559'
           ,'Pedro'
           , 'Perez'
           , 'Alto'
           , 1)
GO
