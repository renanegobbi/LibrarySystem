﻿USE [SistemBiblioteca]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 12/03/2023 22:48:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 12/03/2023 22:48:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 12/03/2023 22:48:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 12/03/2023 22:48:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC,
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 12/03/2023 22:48:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](128) NOT NULL,
	[RoleId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 12/03/2023 22:48:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](128) NOT NULL,
	[Email] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEndDateUtc] [datetime] NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[UserName] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Emprestimos]    Script Date: 12/03/2023 22:48:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Emprestimos](
	[Id] [uniqueidentifier] NOT NULL,
	[UsuarioID] [uniqueidentifier] NOT NULL,
	[LivroID] [uniqueidentifier] NOT NULL,
	[DataRetirada] [datetime] NOT NULL,
	[DataDevolucao] [datetime] NULL,
 CONSTRAINT [PK_dbo.Emprestimos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Enderecos]    Script Date: 12/03/2023 22:48:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Enderecos](
	[Id] [uniqueidentifier] NOT NULL,
	[Logradouro] [nvarchar](200) NOT NULL,
	[Numero] [nvarchar](50) NOT NULL,
	[Complemento] [nvarchar](250) NULL,
	[Cep] [nchar](8) NOT NULL,
	[Bairro] [nvarchar](max) NOT NULL,
	[Cidade] [nvarchar](max) NOT NULL,
	[Estado] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_dbo.Enderecos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Livros]    Script Date: 12/03/2023 22:48:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Livros](
	[Id] [uniqueidentifier] NOT NULL,
	[Imagem] [nvarchar](100) NOT NULL,
	[Titulo] [nvarchar](200) NOT NULL,
	[Descricao] [nvarchar](1000) NOT NULL,
	[Editora] [nvarchar](200) NOT NULL,
	[AnoPublicacao] [datetime] NOT NULL,
	[DataCadastro] [datetime] NOT NULL,
 CONSTRAINT [PK_dbo.Livros] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 12/03/2023 22:48:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[Id] [uniqueidentifier] NOT NULL,
	[Nome] [nvarchar](200) NOT NULL,
	[Cpf] [nvarchar](11) NOT NULL,
 CONSTRAINT [PK_dbo.Usuarios] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__MigrationHistory] ([MigrationId], [ContextKey], [Model], [ProductVersion]) VALUES (N'202303130143565_InitialCreate', N'SistemaBiblioteca.Infra.Migrations.Configuration', 0x1F8B0800000000000400E55DD96EE436167D1F60FE41A8A7998153E565BAD1639413B8BD248569BB1B5DEE206F062DB1CA426BA968716C04F9B279984F9A5F1852A224EEA22496AA9C461E52E6722E7979EFE5269EFEDF7FFE3BFFE1390C9C2798A47E1C9D4D8EA6871307466EECF9D1FA6C9267ABEFDE4D7EF8FEAF7F995F79E1B3F37355EE04974335A3F46CF298659BD3D92C751F6108D269E8BB499CC6AB6CEAC6E10C78F1ECF8F0F05FB3A3A31944101384E538F3CF7994F9212CFE407F5EC4910B37590E829BD883414AD251CEB240756E4108D30D70E1D964E9A7194A7AEF3F047E9C41174C17D12A01D34B90812902CAE0733671CE031FA0B62D61B09A38208AE20C64A8E5A75F52B8CC92385A2F37280104772F1B88CAAD409042D2A3D3A6B869E70E8F71E7664DC50ACACDD32C0E3B021E9D106DCDF8EABD743EA9B589F47985F49EBDE05E173A3D9B5C859B04A66830E289C38B3BBD08125C54A6F4F779EA47304DA7E5884D1B1CFAF781A3AE79509B13B23AFCDF81739107599EC0B308E659028203E7538EAAB9FF862F77F157189D457910D0DD411D42794C024AFA94C41B98642F9FE18A7472E14D9C195B6FC657ACAB5175CACEFF98FBE8F72D920D1E02581BCB4C5BFD4B9A83C48F179783503EF84FC9500CEC189F61E627C00315104A8377C8017B815DC2A738C85D108B685CE55BF0E4AF0B5392F56BE27C8641919B3EFA9BD259A745CE3D654D13E73A89C3CF715055A333EFEF40B286C8DFEF625589659C276E87A6918193368EE4A99A27C9161A282B236BE27CD6B8AAD681892A87F86E0141FEF7ED7AEC22046B18561068964053E0C4B901CF1F60B4CE1ED1E4788826BD6BFF197A550AC1FD12F968C64495B224EFEE52777E9607B146EEF176E45EC2D44D7CCA8DE55DDE8AEC2BCFCFE2048CDFE9F3282E2D1448E3578F687881C26A9A253DC0942188092FC36364155ED431B20A52BD02501D308784200252FFF876C3D06D8C6D676CBFB8D8AC7461E0C88ACCDE06DF63DEE58D5E37371B3733F26002DD96B5415D48D24092A76E5D55609047364DB0E29215DCB7EB931FE2355A3DA331DBC1347D9B87502BF7CD7602421C6E0218C228D3F6D950788B2CB8D1C878C749281187F5EE3DF013AD52D1CFAD68D5F780A70BEF5B927B9566C87E47903B6C5B65123A951B2A3EB6F60A9D0B0F1649185B173E6FEA1397F374730BB36955715A425E2708EEB738F93AA5110F1CE37A4D403D360DA827470FAB93776FDE02EFE4ED3FE1C99BF183AB6CE970CCFBAF9DA808F4ABA4376FB76DCE6874A4C64C8FF73D29D698B3982BAC05244506AD062A3C0C65DFAC2BD4FD376DDC52D1BCA5457187FA784225626C6FA8DABB5DB9BD2CCEBEB5EDBFA5BD96207A15023FB010450DA45CC4D1CA4F4258F7F27D8C6C16449DDBFC09A4291A5AEF27903E5A58CFE8852DA19B27C8A0961908754B543BD23E3DC61144CBFD07EC35E3C9B2363477BFC5D7C0CDE2E42AC2B506E37D88DDAF719EA1851D3E53FB92B9ADF70D2A002BCD39775DB4D1BD46C60CBD8B388FB20A70116527C73D2E8860B2EB55CC4500FC50BF8CC1CDBCAFCA89EB182A5BB990A1CB743D72413B6F3F326861554ED1C2325BDF4252A66B0B31924103493145FB8A5C7DF3CA22D65682C578D89F9C0BD83FFB0CAD72784A8D4B1406E18F3082098A55DE27906530899A1130090EBB581114C387856E7D022A24FD0C82DCB6A85EDE50F8BE7D6F2860F7DF1B8A66A2E427DFC34B0F830D525518C11B9597EFBDDA7D8E6BD9D8EEC074736CE1E3C40095BB9CA769ECFA8517D01F1A3057306CF3D13ACD69BD822CFB525F62A2FE20FBF637C8A2511B509704A5E850EBA3C00695FE9C8985FE87008DCC1326D81101DE9EA4C8BDFC28136DD98F5C7F0382B6BE71150DA71D3C00B5083EE7126E608443459B064C64D79F12890DA8E570DED9A6A0F98CB212BDF1C86EF05403ADBDCE6B86BA3E51363721ED073A231A91A687239891460B26D2A92FDB766B4AD56D41EB680BB7AE768C48B891A02CA8BEC968C31D663F5CCFC6341EAEF7FD458F6032923379D5E8EA0EE89BF165AF89CC6D4773B62F416F4EECB71285D45D1DC18ED49A30112E3FA01FD99AE8A391B601979E93C847BC8F3DC98E5814F064E3BF558B92F47644939228C36C5E53DC0F8D6E53E430CB68D0F9932DCB36C51D8A29E0C9F679FB36C5F6766C9B6295F1BA6CAA3C7F341A73EE30D2B245B1E798BB9BF5C4AE8E6D4E8C26F6CC9ACA4301FC9C0AD58049751FC67FFF57BFB7124ECE505BC9E1594ACE2178EBC0029630937D02DA1C494876648299B140E563060906397068A95E7DF52801A8F70A2D10D5D258DA917A63D00242EE0B040076E5D902C2BB940EB071BB560D15DFB468813AB5ACBA5DD22292654B07D8EA4A480B4B662E0E96720ACEB0D84F90A972CA4FF3795F353926ABBBD598B3E0F3260763140ED36EFE1896EDAF812EA41F648BDA683DF5313EF7A17AD278A84627BA939EED6BA576728D4AA4A71766E717BD95C19F58D09A6882D6603DC83E811335D1B62937DD96539D20314EA30ACD069CC291C44D6B4A612ED4D55A516E2E8DB7978C95146360A017D94652A198AA0F76355345ED16CDC8B648C69BA4FE9AE1B6430ACD547DB0AB1962882D8A91ACF34D57FAFDD5C2AEE92D39527533552F42EBBCF9ACA4052009F399823F607E03361B3F5A537C0224C55996640217DF2DBBBFA90F4B8C99CBE8995F32D792F043C735E472F1030B0F5EFB499AE147840F00DFCB5D78A1504CB9E4562C842AB1E2AA5A1CCB6A5D54D5C1BF150B7D09C902BD2817772F04F31AF51D3F2229D400A533AF58D9C1BC0F200089E40B8C8B38C8C348BD1953D7A6EE2D6810CD75861AABBE4CA39194376C6A1CF66D3E0DC6E67443A41EE8F390549688399F71A326EC33059BE19C9937432323254B5CEBF6596EF8BA9BA6A2DE76ACB27A75CE20903473943BF2869C46A9D23AD84EF3229CB19B26D91CAB7EE14D23D589E638DC836D1A8DCBEAE623CDB36DDE459A9CBDF1907A956FDD47AA338DEE5EA2ACB91D3F299F45D3F5CB147384E289330D5024ECCD18371B30FB13B562AF69324D2BAB6E6798E997B6CCDC4AA577301AF27696311B92D6C170E8A7B08C01D1191DF0F0735706072798D7AF1EAFD210555A875690A7A84C43485A87304F1E9632519EA4ED8D6BA9F64403DD8A398AEDEE5AFAEA5B8AA24088A2401E45773454E286716BC3561F78F71F3A35847A13525EE1B03B10F9B58E1AA5FAFC8146517D12B1C3458BFC48CFE2F00D1CBAB1BC8EBCB363626499D411837AAA25805179E6A8EC6B3A1A93CD3147E49ECCD1905C568756D20FE39846D219BDF0141A9597E8B01F139EC2313B3321B7CB02497814C7AE9384EC1ED89236F3791D7670E2BB39661727667739D3A91ED1F101758FE735E5A9BEC5C8585E970E0B8F0A8C6D9DCED99818A9F74BCCBAB649EE88455E280960247D2FED4B793762D1BECA7BF361F6A5C0D06C0DE9B740DCEE50F780498DC93CF0612600DD0327355E372BDEAAAD08D7277C915A7A7D8DC25D97CCC9D5453B27B3709751169938951A9185BD600B2B0D6AF96B7011F81087FAAAC00D88FC154CB3F251DBE4F8F0E8982371DE1F42E5599A7A81E4EA47CEAACC8ED808AF53F3C8FF35877EE1682B1FFBC350EA621151F8DC6B1179F0F96CF27B0171EA2C7EB9AF510E9C8F091AE153E7D0F963280172AF96108C41ED9091287B68859559235196A10D78DDAAA205AED5F3C72BB44C96A2377A0289FB081291A4771003AF14F6B807AC40B0AB6A7077688E3FD75A93A5F4B883EC9CA7C73504B3C03EFBAA2D9D6681B536BA14C96B8329EAED977B5410B31C20FD9D37E9CEEFCE22FD5274ECD4B943910987518E24D6CE986AF84BF76B500D269F85376CFE139847AD59034B2C2A857DD3C3C644DE50798B59EC8E34A19180F76E200768D5C8BF85E0F9EF03793D8761B15C9D5DB0FAB15C8EEE47F269F0B8FB0896673CED018D754ADC69FCAB483ED0C7B48281C93E299E82867158701B9DDFD05CE5C57600576563E1C0E167590F3BB5A6AC3AA035FDB8105FAFAB3154818A80FEB66B409733033EF89915564065E4ECCDFC370851C2EE670BCF8A0A55EC7D7DB094CC7D669B5C0DE0E0A62959FCFCA83B18CFE1671E83AA9A3B9C8424C7FB6384A442CFADF46883B892763D31092C6A831C5D644AEB0067950D6DD8FAE495B18C599B3A252462D6B07769F75B630E1B4613463F151E9D186C8C37E4DA67177F02DEAFA1FC4CBB3200F5A7D4BB3681D7C6D835D802EAF343034AAEC3E9D42E2BD72806A0FEA2FBF5D36E5965DA6A8E5B764BB03536BB88B1CC5749A5659D9686D04BEC98336B6C23517D25B6CF44461DC8B1AC5B09D918ED98056B6C2B517DEBB5CF56624E7765DD48763DDBECC2448C679B9D535889CFEEF931255FD4895F72E969A9CA4FDECE26DE035E7796BB661DBD0C2F886C740519245D062FE70652515AE918AD64E82A6A1925DF9596EE4AAA1E25E70C2F825D050A62D86C99A892785F4E41A112D6F8AB526053442D54CD7DA113DC4AB0A517D84D1859DF682592327AB10A4E189D6C326B6A6593327AD90AD69511B9BC44E22E49A0931F545015355C77FB45D42523A2DA9F0E5BE5E0EADE552E26B28FA9877773CB145B52121F193B60CB2A4882A2E419DC434A2D65078CD5C04456C50B1BCB8AD80683D6704530615EF114C4B222EC13660D57834DB7E8409025BEE4400BEB3CC257F1E55F9730F5D70DC41C6146D06596D4759945B48AAB953DD7A2AA08774D750333E0A1F5F67992F92BE066281BDFC217FFA04D71B389278107E82DA28F79B6C933D465183E04CCAD1FDE21E8E4172C606C9BE71F37C53FC966A30BA8993EFE7AE163F43EF703AF6EF7B5E4624C0181B71EE4CE1B8F6586EFBED72F35D26D1C190211F5D53BA63B186E0204967E8C96E009F6691B32BF0F700DDC97E61A5405D23E10ACDAE7973E5827204C0946531FFD896CD80B9FBFFF3F649048788A8E0000, N'6.4.4')
GO
SET IDENTITY_INSERT [dbo].[AspNetUserClaims] ON 

INSERT [dbo].[AspNetUserClaims] ([Id], [UserId], [ClaimType], [ClaimValue]) VALUES (1, N'd2b1b6f3-29dc-4652-a7b6-2235cbbeba7f', N'Administrador', N'Ler,Adicionar,Atualizar,Excluir')
INSERT [dbo].[AspNetUserClaims] ([Id], [UserId], [ClaimType], [ClaimValue]) VALUES (2, N'ba221ee4-eef5-449b-80c3-ebb5729da68a', N'Funcionario', N'Ler,Atualizar')
SET IDENTITY_INSERT [dbo].[AspNetUserClaims] OFF
GO
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'ba221ee4-eef5-449b-80c3-ebb5729da68a', N'func@email.com', 1, N'AAQP7yHYiEArHokOcvBKAnY5T57h0lEBu/SLL+OxHVdQdvysWyR5Is1HBKkoIf1T5w==', N'9BF16A790919F0438F0DF590100217B1', NULL, 1, 0, NULL, 1, 5, N'func@email.com')
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'd2b1b6f3-29dc-4652-a7b6-2235cbbeba7f', N'admin@email.com', 1, N'APbtZMgyM1tLOVyAjVeOmar1URrC/YKXFNfJMWGVXHhP602WXAcENRYLdYu1ytthhw==', N'50CFF3804DAA8B41BFC67DA412B23C52', NULL, 1, 0, NULL, 1, 5, N'admin@email.com')
GO
INSERT [dbo].[Emprestimos] ([Id], [UsuarioID], [LivroID], [DataRetirada], [DataDevolucao]) VALUES (N'89985109-d8b5-4df2-935f-15406a2179a3', N'f993d13f-db9f-4838-accd-ea8294f39265', N'67e9e01b-3dbe-4c8e-8589-02c9705a076b', CAST(N'2023-03-12T22:43:59.147' AS DateTime), CAST(N'2023-03-12T22:43:59.147' AS DateTime))
INSERT [dbo].[Emprestimos] ([Id], [UsuarioID], [LivroID], [DataRetirada], [DataDevolucao]) VALUES (N'4587f291-773c-49d9-990d-1ac0263e2acc', N'9c3db18e-b07d-49db-af45-9dcc6084c4c2', N'c434bed4-0702-4815-aa63-e4657c171dbe', CAST(N'2023-03-12T22:43:59.147' AS DateTime), CAST(N'2023-03-12T22:43:59.147' AS DateTime))
INSERT [dbo].[Emprestimos] ([Id], [UsuarioID], [LivroID], [DataRetirada], [DataDevolucao]) VALUES (N'cb6eddd3-5d9c-46b2-b39a-2e0a6bb3487f', N'5653593b-7fe4-4130-b56f-6768d03b0180', N'98ed42ab-8b0b-4c6f-8981-3b43cb9f6047', CAST(N'2023-03-12T22:43:59.147' AS DateTime), CAST(N'2023-03-12T22:43:59.147' AS DateTime))
INSERT [dbo].[Emprestimos] ([Id], [UsuarioID], [LivroID], [DataRetirada], [DataDevolucao]) VALUES (N'5f913ec9-fad5-430e-8d55-35e3ef0cac46', N'f8e98551-55eb-4b79-81c1-a813f339b550', N'67e9e01b-3dbe-4c8e-8589-02c9705a076b', CAST(N'2023-03-12T22:43:59.147' AS DateTime), CAST(N'2023-03-12T22:43:59.147' AS DateTime))
INSERT [dbo].[Emprestimos] ([Id], [UsuarioID], [LivroID], [DataRetirada], [DataDevolucao]) VALUES (N'6ee50808-f670-4a6e-9d87-386fc7c9e199', N'f6b4de6c-d56f-4f87-b088-b03c3718f2a3', N'ec3b7e7b-17bb-493f-9eee-bccc7eaed409', CAST(N'2023-03-12T22:43:59.147' AS DateTime), CAST(N'2023-03-12T22:43:59.147' AS DateTime))
INSERT [dbo].[Emprestimos] ([Id], [UsuarioID], [LivroID], [DataRetirada], [DataDevolucao]) VALUES (N'c4fa6c59-8b0a-46a7-b2e8-46a48b517ec4', N'6a7785e5-fbb9-44ef-a2e5-85ac15f05e4a', N'98ed42ab-8b0b-4c6f-8981-3b43cb9f6047', CAST(N'2023-03-12T22:43:59.143' AS DateTime), CAST(N'2023-03-12T22:43:59.143' AS DateTime))
INSERT [dbo].[Emprestimos] ([Id], [UsuarioID], [LivroID], [DataRetirada], [DataDevolucao]) VALUES (N'52452c6a-9189-472f-bd6b-4a654e5ce3ab', N'9c3db18e-b07d-49db-af45-9dcc6084c4c2', N'8be92b9d-ca90-44d6-92c2-f68e9bd91d38', CAST(N'2023-03-12T22:43:59.147' AS DateTime), CAST(N'2023-03-12T22:43:59.147' AS DateTime))
INSERT [dbo].[Emprestimos] ([Id], [UsuarioID], [LivroID], [DataRetirada], [DataDevolucao]) VALUES (N'bf8e07ef-8aeb-4d09-83b2-54aee491abf8', N'df3b8162-50f6-4b81-8682-086de0b69f83', N'98ed42ab-8b0b-4c6f-8981-3b43cb9f6047', CAST(N'2023-03-12T22:43:59.147' AS DateTime), NULL)
INSERT [dbo].[Emprestimos] ([Id], [UsuarioID], [LivroID], [DataRetirada], [DataDevolucao]) VALUES (N'b22ceab7-eb1a-4b51-b141-5fa2eec66afd', N'64669daf-eb4c-4202-b5d0-8fa85a757f40', N'c434bed4-0702-4815-aa63-e4657c171dbe', CAST(N'2023-03-12T22:43:59.147' AS DateTime), CAST(N'2023-03-12T22:43:59.147' AS DateTime))
INSERT [dbo].[Emprestimos] ([Id], [UsuarioID], [LivroID], [DataRetirada], [DataDevolucao]) VALUES (N'a299fea0-ab78-4007-b1a3-85ef41e508f4', N'09688eca-8d42-4aeb-8da2-a27ff83792c7', N'8be92b9d-ca90-44d6-92c2-f68e9bd91d38', CAST(N'2023-03-12T22:43:59.147' AS DateTime), CAST(N'2023-03-12T22:43:59.147' AS DateTime))
INSERT [dbo].[Emprestimos] ([Id], [UsuarioID], [LivroID], [DataRetirada], [DataDevolucao]) VALUES (N'fe91276b-d8c3-4a04-8df1-9f16edc6546c', N'6a7785e5-fbb9-44ef-a2e5-85ac15f05e4a', N'ec3b7e7b-17bb-493f-9eee-bccc7eaed409', CAST(N'2023-03-12T22:43:59.147' AS DateTime), NULL)
INSERT [dbo].[Emprestimos] ([Id], [UsuarioID], [LivroID], [DataRetirada], [DataDevolucao]) VALUES (N'f20f1a26-2844-4683-9a74-bd0b2448d99e', N'df3b8162-50f6-4b81-8682-086de0b69f83', N'8be92b9d-ca90-44d6-92c2-f68e9bd91d38', CAST(N'2023-03-12T22:43:59.147' AS DateTime), CAST(N'2023-03-12T22:43:59.147' AS DateTime))
INSERT [dbo].[Emprestimos] ([Id], [UsuarioID], [LivroID], [DataRetirada], [DataDevolucao]) VALUES (N'1726d834-cfd4-4b69-b2b2-e08c73b388d7', N'f8e98551-55eb-4b79-81c1-a813f339b550', N'29f42bf3-ba78-469a-9f1d-a9d734489334', CAST(N'2023-03-12T22:43:59.143' AS DateTime), NULL)
INSERT [dbo].[Emprestimos] ([Id], [UsuarioID], [LivroID], [DataRetirada], [DataDevolucao]) VALUES (N'634c095d-70c9-4f16-b1f9-f82619165162', N'f993d13f-db9f-4838-accd-ea8294f39265', N'c434bed4-0702-4815-aa63-e4657c171dbe', CAST(N'2023-03-12T22:43:59.147' AS DateTime), CAST(N'2023-03-12T22:43:59.147' AS DateTime))
GO
INSERT [dbo].[Enderecos] ([Id], [Logradouro], [Numero], [Complemento], [Cep], [Bairro], [Cidade], [Estado]) VALUES (N'df3b8162-50f6-4b81-8682-086de0b69f83', N'Rua Desembargador Simão Aureliano de Barros Filho', N'20000', N'Lot Jd Petrópolis', N'78144750', N'Petrópolis', N'Várzea Grande', N'MT')
INSERT [dbo].[Enderecos] ([Id], [Logradouro], [Numero], [Complemento], [Cep], [Bairro], [Cidade], [Estado]) VALUES (N'5653593b-7fe4-4130-b56f-6768d03b0180', N'Avenida Doutor Antônio Gouveia', N'70000', N'Estátua do Governador', N'57030170', N'Pajuçara', N'Maceió', N'AL')
INSERT [dbo].[Enderecos] ([Id], [Logradouro], [Numero], [Complemento], [Cep], [Bairro], [Cidade], [Estado]) VALUES (N'6a7785e5-fbb9-44ef-a2e5-85ac15f05e4a', N'Rua José Maria dos Santos', N'40000', N'Cj Monte Alegre', N'57057370', N'Pinheiro', N'Maceió', N'AL')
INSERT [dbo].[Enderecos] ([Id], [Logradouro], [Numero], [Complemento], [Cep], [Bairro], [Cidade], [Estado]) VALUES (N'198d7318-f792-4903-88f5-8957beb71073', N'Rua Santa Rosa', N'11000', N'Parque Horto', N'57075045', N'Santos Dumont', N'Maceió', N'AL')
INSERT [dbo].[Enderecos] ([Id], [Logradouro], [Numero], [Complemento], [Cep], [Bairro], [Cidade], [Estado]) VALUES (N'64669daf-eb4c-4202-b5d0-8fa85a757f40', N'Rua Adalberto Ferreira da Silva', N'90000', N'Praça do Relógio', N'57303739', N'Guaribas', N'Arapiraca', N'AL')
INSERT [dbo].[Enderecos] ([Id], [Logradouro], [Numero], [Complemento], [Cep], [Bairro], [Cidade], [Estado]) VALUES (N'a101f89d-f28b-4d21-a06b-9161245198e2', N'Rua Antônio Felinto', N'12000', N'Universidade', N'57039520', N'Riacho Doce', N'Maceió', N'AL')
INSERT [dbo].[Enderecos] ([Id], [Logradouro], [Numero], [Complemento], [Cep], [Bairro], [Cidade], [Estado]) VALUES (N'9c3db18e-b07d-49db-af45-9dcc6084c4c2', N'Travessa Nogueira', N'30000', N'Cj Luiz Pedro V', N'57040187', N'Cidade Universitária', N'Maceió', N'AL')
INSERT [dbo].[Enderecos] ([Id], [Logradouro], [Numero], [Complemento], [Cep], [Bairro], [Cidade], [Estado]) VALUES (N'09688eca-8d42-4aeb-8da2-a27ff83792c7', N'Rua Maria Sampaio da Silva', N'80000', N'Praça Mauá', N'57315109', N'Senador Arnon de Melo', N'Arapiraca', N'AL')
INSERT [dbo].[Enderecos] ([Id], [Logradouro], [Numero], [Complemento], [Cep], [Bairro], [Cidade], [Estado]) VALUES (N'f8e98551-55eb-4b79-81c1-a813f339b550', N'Quadra D0', N'10000', N'Lot Cascadura', N'57073444', N'Cidade Universitária', N'Maceió', N'AL')
INSERT [dbo].[Enderecos] ([Id], [Logradouro], [Numero], [Complemento], [Cep], [Bairro], [Cidade], [Estado]) VALUES (N'f6b4de6c-d56f-4f87-b088-b03c3718f2a3', N'Rua Carteiro José Florentino', N'60000', N'Praça 7', N'57082382', N'Santa Lúcia', N'Maceió', N'AL')
INSERT [dbo].[Enderecos] ([Id], [Logradouro], [Numero], [Complemento], [Cep], [Bairro], [Cidade], [Estado]) VALUES (N'8eaa1372-7b95-4c5f-983e-cffa61bc9bca', N'Rua Eronildes de Oliveira', N'10000', N'Parque da Cidade', N'57071340', N'Clima Bom', N'Maceió', N'AL')
INSERT [dbo].[Enderecos] ([Id], [Logradouro], [Numero], [Complemento], [Cep], [Bairro], [Cidade], [Estado]) VALUES (N'f993d13f-db9f-4838-accd-ea8294f39265', N'Rua Paulo Afonso', N'50000', N'de 71 a 587 - lado ímpar', N'57304000', N'Primavera', N'Arapiraca', N'AL')
GO
INSERT [dbo].[Livros] ([Id], [Imagem], [Titulo], [Descricao], [Editora], [AnoPublicacao], [DataCadastro]) VALUES (N'67e9e01b-3dbe-4c8e-8589-02c9705a076b', N'ac8b9091-dc10-45ad-a27c-405fbe2e4826_CleanArchitecture.jpg', N'Clean Architecture: A Craftsman''s Guide to Software Structure and Design', N'Martin''s Clean Architecture não apresenta apenas opções. Baseando-se em mais de meio século de experiência em ambientes de software de todos os tipos imagináveis, Martin diz quais escolhas fazer e por que elas são críticas para o seu sucesso. Como você espera do tio Bob, este livro está repleto de soluções diretas e objetivas para os desafios reais que você enfrentará - aqueles que farão ou destruirão seus projetos.', N'Pearson', CAST(N'2017-12-12T00:00:00.000' AS DateTime), CAST(N'2023-03-12T22:43:59.140' AS DateTime))
INSERT [dbo].[Livros] ([Id], [Imagem], [Titulo], [Descricao], [Editora], [AnoPublicacao], [DataCadastro]) VALUES (N'98ed42ab-8b0b-4c6f-8981-3b43cb9f6047', N'c8f0e891-bed5-43ed-9aae-28c17c28a8fb_PatternsOfEnterprise.jpg', N'Patterns of Enterprise Application Architecture', N'A prática de desenvolvimento de aplicativos corporativos se beneficiou do surgimento de muitas novas tecnologias facilitadoras. Plataformas orientadas a objetos multicamadas, como Java e .NET, tornaram-se comuns. Essas novas ferramentas e tecnologias são capazes de criar aplicativos poderosos, mas não são facilmente implementadas. Falhas comuns em aplicativos corporativos geralmente ocorrem porque seus desenvolvedores não entendem as lições de arquitetura que os desenvolvedores de objetos experientes aprenderam. Padrões de Arquitetura de Aplicativo Corporativofoi escrito em resposta direta aos rígidos desafios enfrentados pelos desenvolvedores de aplicativos corporativos.', N'Addison-Wesley Professional', CAST(N'2002-11-15T00:00:00.000' AS DateTime), CAST(N'2023-03-12T22:43:59.140' AS DateTime))
INSERT [dbo].[Livros] ([Id], [Imagem], [Titulo], [Descricao], [Editora], [AnoPublicacao], [DataCadastro]) VALUES (N'29f42bf3-ba78-469a-9f1d-a9d734489334', N'8f1139fd-37df-41d9-a21c-80ec214d3b75_CleanCode.jpg', N'Clean Code', N'Clean Code ou código limpo se refere a um conjunto de boas práticas na escrita de software que você pode aplicar para obter uma maior legibilidade e manutenabilidade do seu código.', N'Pearson', CAST(N'2008-08-01T00:00:00.000' AS DateTime), CAST(N'2023-03-12T22:43:59.140' AS DateTime))
INSERT [dbo].[Livros] ([Id], [Imagem], [Titulo], [Descricao], [Editora], [AnoPublicacao], [DataCadastro]) VALUES (N'ec3b7e7b-17bb-493f-9eee-bccc7eaed409', N'0283c6c0-9f6b-42a6-bffd-bac1c7bac4a4_DomainDrivenDesign.jpg', N'Domain-Driven Design: Tackling Complexity in the Heart of Software (English Edition)', N'O Domain-Driven Design preenche essa necessidade. Este não é um livro sobre tecnologias específicas. Ele oferece aos leitores uma abordagem sistemática do design orientado por domínio, apresentando um amplo conjunto de melhores práticas de design, técnicas baseadas em experiência e princípios fundamentais que facilitam o desenvolvimento de projetos de software voltados para domínios complexos.', N'Addison-Wesley Professional', CAST(N'2003-08-22T00:00:00.000' AS DateTime), CAST(N'2023-03-12T22:43:59.140' AS DateTime))
INSERT [dbo].[Livros] ([Id], [Imagem], [Titulo], [Descricao], [Editora], [AnoPublicacao], [DataCadastro]) VALUES (N'c434bed4-0702-4815-aa63-e4657c171dbe', N'09303e33-5f0d-4f9b-a5af-48d6b1bc83f7_Refactoring.jpg', N'Refactoring: Improving the Design of Existing Code', N'A refatoração melhora o design do código existente e aumenta a capacidade de manutenção do software, além de tornar o código existente mais fácil de entender. O signatário original do Manifesto Ágil e líder em desenvolvimento de software, Martin Fowler, fornece um catálogo de refatorações que explica por que você deve refatorar; como reconhecer código que precisa de refatoração; e como realmente fazê-lo com sucesso, não importa o idioma que você usa.', N'Profissional Addison-Wesley', CAST(N'2018-11-20T00:00:00.000' AS DateTime), CAST(N'2023-03-12T22:43:59.140' AS DateTime))
INSERT [dbo].[Livros] ([Id], [Imagem], [Titulo], [Descricao], [Editora], [AnoPublicacao], [DataCadastro]) VALUES (N'8be92b9d-ca90-44d6-92c2-f68e9bd91d38', N'9dc7068d-ab05-4e9d-bd90-805daede65d8_DesignPatterns.jpg', N'Design Patterns', N'Os padrões permitem que os designers criem designs mais flexíveis, elegantes e reutilizáveis, sem ter que redescobrir as próprias soluções de design. Altamente influente, Design Patterns é um clássico moderno que apresenta o que são os padrões e como eles podem ajudá-lo a projetar software orientado a objetos e fornece um catálogo de soluções simples para aqueles que já programam em pelo menos uma linguagem de programação orientada a objetos.', N'Profissional Addison-Wesley', CAST(N'1994-10-31T00:00:00.000' AS DateTime), CAST(N'2023-03-12T22:43:59.140' AS DateTime))
GO
INSERT [dbo].[Usuarios] ([Id], [Nome], [Cpf]) VALUES (N'df3b8162-50f6-4b81-8682-086de0b69f83', N'Ronaldo Kuster', N'56991398004')
INSERT [dbo].[Usuarios] ([Id], [Nome], [Cpf]) VALUES (N'5653593b-7fe4-4130-b56f-6768d03b0180', N'Vinícius Barbosa', N'35446468465')
INSERT [dbo].[Usuarios] ([Id], [Nome], [Cpf]) VALUES (N'6a7785e5-fbb9-44ef-a2e5-85ac15f05e4a', N'Alberto Celestino', N'10878482024')
INSERT [dbo].[Usuarios] ([Id], [Nome], [Cpf]) VALUES (N'198d7318-f792-4903-88f5-8957beb71073', N'Bárbara Rodrigues', N'56492088409')
INSERT [dbo].[Usuarios] ([Id], [Nome], [Cpf]) VALUES (N'64669daf-eb4c-4202-b5d0-8fa85a757f40', N'Vânia Meireles', N'31680717499')
INSERT [dbo].[Usuarios] ([Id], [Nome], [Cpf]) VALUES (N'a101f89d-f28b-4d21-a06b-9161245198e2', N'Osmar Branco', N'29281994461')
INSERT [dbo].[Usuarios] ([Id], [Nome], [Cpf]) VALUES (N'9c3db18e-b07d-49db-af45-9dcc6084c4c2', N'Flavio Amaro', N'75037919002')
INSERT [dbo].[Usuarios] ([Id], [Nome], [Cpf]) VALUES (N'09688eca-8d42-4aeb-8da2-a27ff83792c7', N'Eliana Yamada', N'08505584414')
INSERT [dbo].[Usuarios] ([Id], [Nome], [Cpf]) VALUES (N'f8e98551-55eb-4b79-81c1-a813f339b550', N'João Silva', N'13490372069')
INSERT [dbo].[Usuarios] ([Id], [Nome], [Cpf]) VALUES (N'f6b4de6c-d56f-4f87-b088-b03c3718f2a3', N'Fabiano Moura', N'40002863405')
INSERT [dbo].[Usuarios] ([Id], [Nome], [Cpf]) VALUES (N'8eaa1372-7b95-4c5f-983e-cffa61bc9bca', N'Gisele Fagundes', N'97034954437')
INSERT [dbo].[Usuarios] ([Id], [Nome], [Cpf]) VALUES (N'f993d13f-db9f-4838-accd-ea8294f39265', N'Higor Albor', N'52443660095')
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[Emprestimos]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Emprestimos_dbo.Livros_LivroID] FOREIGN KEY([LivroID])
REFERENCES [dbo].[Livros] ([Id])
GO
ALTER TABLE [dbo].[Emprestimos] CHECK CONSTRAINT [FK_dbo.Emprestimos_dbo.Livros_LivroID]
GO
ALTER TABLE [dbo].[Emprestimos]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Emprestimos_dbo.Usuarios_UsuarioID] FOREIGN KEY([UsuarioID])
REFERENCES [dbo].[Usuarios] ([Id])
GO
ALTER TABLE [dbo].[Emprestimos] CHECK CONSTRAINT [FK_dbo.Emprestimos_dbo.Usuarios_UsuarioID]
GO
ALTER TABLE [dbo].[Enderecos]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Enderecos_dbo.Usuarios_Id] FOREIGN KEY([Id])
REFERENCES [dbo].[Usuarios] ([Id])
GO
ALTER TABLE [dbo].[Enderecos] CHECK CONSTRAINT [FK_dbo.Enderecos_dbo.Usuarios_Id]
GO 