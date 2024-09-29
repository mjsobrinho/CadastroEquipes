set nocount on


IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'tb_pessoas')
BEGIN
   
		CREATE TABLE [dbo].[tb_pessoas](
			[cpf] [varchar](11) NOT NULL,
			[nome] [varchar](100) NOT NULL,
			[dt_nasc] [datetime] NOT NULL,
			[sexo] [varchar](10) NOT NULL,
		PRIMARY KEY CLUSTERED 
		(
			[cpf] ASC
		)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
	) ON [PRIMARY]

	print 'tb_pessoas - Criada'
END
Else
Begin
	Print 'tb_pessoas Já existe '
End

IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'tb_equipes')
BEGIN
   
	   CREATE TABLE [dbo].[tb_equipes](
		[id_equipe] [uniqueidentifier] NOT NULL,
		[nm_equipe] [varchar](100) NOT NULL,
		[idad_mini] [int] NOT NULL,
		[sexo] [varchar](10) NOT NULL,
	PRIMARY KEY CLUSTERED 
	(
		[id_equipe] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
	) ON [PRIMARY]

	
	print 'tb_equipes - Criada'
END
Else
Begin
	Print 'tb_equipes Já existe '
End

	
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'tb_equipes_pessoas')
Begin
	CREATE TABLE [dbo].[tb_equipes_pessoas](
		[id_equipe] [uniqueidentifier] NOT NULL,
		[cpf] [varchar](11) NOT NULL,
		[idade] [int] NOT NULL,
	PRIMARY KEY CLUSTERED 
	(
		[id_equipe] ASC,
		[cpf] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
	) ON [PRIMARY]

	ALTER TABLE [dbo].[tb_equipes_pessoas]  WITH CHECK ADD FOREIGN KEY([id_equipe])
	REFERENCES [dbo].[tb_equipes] ([id_equipe])

	ALTER TABLE [dbo].[tb_equipes_pessoas]  WITH CHECK ADD FOREIGN KEY([cpf])
	REFERENCES [dbo].[tb_pessoas] ([cpf])

	
	Print 'tb_equipes_pessoas -  Criadas '

End
Else
Begin
	Print 'tb_equipes_pessoas já existe '
End


--Populas dados iniciais nas tabelas
insert into tb_pessoas (cpf, nome, dt_nasc, sexo) values ('10724554041', 'Alex Ribeiro Netoto', '1990-05-15T00:00:00.000Z', 'M')
insert into tb_pessoas (cpf, nome, dt_nasc, sexo) values ('11144477735', 'João Silvao', '1985-11-25T00:00:00.000Z', 'M')
insert into tb_pessoas (cpf, nome, dt_nasc, sexo) values ('12345678909', 'Maria Souza', '2000-02-10T00:00:00.000Z', 'F')
insert into tb_pessoas (cpf, nome, dt_nasc, sexo) values ('72084284090', 'Ana Costa', '1995-08-30T00:00:00.000Z', 'F')
insert into tb_pessoas (cpf, nome, dt_nasc, sexo) values ('98765432100', 'Paulo Lima', '2000-02-10 00:00:00.000', 'M')



INSERT INTO tb_equipes (id_equipe,  nm_equipe, idad_mini, sexo)values ('3DDE2E39-D050-422A-9479-26327B2D6A33', 'Capgemini Delta', '20', 'M' )
INSERT INTO tb_equipes (id_equipe,  nm_equipe, idad_mini, sexo)values ('D529D242-1406-4F35-A2AB-50374776E06D', 'Capgemini Premium', '35', 'F' )
INSERT INTO tb_equipes (id_equipe,  nm_equipe, idad_mini, sexo)values ('5186DEE1-8050-41F7-BE5B-603106C6D175', 'Capgemini Master', '18', 'F' )
INSERT INTO tb_equipes (id_equipe,  nm_equipe, idad_mini, sexo)values ('9A4499DF-FCD4-4FC2-9002-9AE146F8C1B93', 'Capgemini Junior', '40', 'F' )
INSERT INTO tb_equipes (id_equipe,  nm_equipe, idad_mini, sexo)values ('FE56E8A8-C618-4C96-B716-AB2E307CBEFF', 'Capgemini Pleno', '10', 'F' )

insert into tb_equipes_pessoas(id_equipe, cpf, idade) values ('3DDE2E39-D050-422A-9479-26327B2D6A33', '11144477735', 39)
insert into tb_equipes_pessoas(id_equipe, cpf, idade) values  ('FE56E8A8-C618-4C96-B716-AB2E307CBEFF', '12345678909', 24)