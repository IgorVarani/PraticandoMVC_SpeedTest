CREATE DATABASE MVC_Mercado;
GO
USE MVC_Mercado;
GO

-- TABLES --

CREATE TABLE Item(
	ItemID		INT PRIMARY KEY IDENTITY,
	NomeItem	NVARCHAR(99) NOT NULL
);
GO

CREATE TABLE Usuario(
	UsuarioID	INT PRIMARY KEY IDENTITY,
	NomeUsuario	NVARCHAR(99) NOT NULL,
	Email		NVARCHAR(99) UNIQUE NOT NULL,
	Senha		VARBINARY(32) NOT NULL
);
GO

CREATE TABLE Inter_ItemUsuario(
	Inter_ItemUsuarioID	INT PRIMARY KEY IDENTITY,
	
	ItemID		INT NOT NULL,
	UsuarioID	INT NOT NULL,

	CONSTRAINT FK_Inter_Item FOREIGN KEY (ItemID) REFERENCES Item(ItemID),
	CONSTRAINT FK_Inter_Usuario FOREIGN KEY (UsuarioID) REFERENCES Usuario(UsuarioID)
);
GO

-- INSERTS --

INSERT INTO Item(NomeItem) VALUES
    ('Coca-Cola'),
    ('Pepsi');
GO

INSERT INTO Usuario(NomeUsuario, Email, Senha) VALUES
    ('Igor', 'igor@email.com', HASHBYTES('SHA2_256', '123')),
    ('Should Be', 'should@email.com', HASHBYTES('SHA2_256', '123'));
GO