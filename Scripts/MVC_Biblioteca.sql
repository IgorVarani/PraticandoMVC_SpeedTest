CREATE DATABASE MVC_Biblioteca;
GO

USE MVC_Biblioteca;
GO

--TABLES--
CREATE TABLE Livro(
	LivroID		INT PRIMARY KEY IDENTITY,
	NomeLivro	NVARCHAR(99) UNIQUE NOT NULL
);
GO

CREATE TABLE Usuario(
	UsuarioID		INT PRIMARY KEY IDENTITY,
	NomeUsuario		NVARCHAR(99) NOT NULL,
	Email			NVARCHAR(99) UNIQUE NOT NULL,
	Senha			VARBINARY(32) NOT NULL
);
GO

CREATE TABLE Inter_LivroUsuario(
	Inter_LivroUsuarioID	INT PRIMARY KEY IDENTITY,

	LivroID INT NOT NULL,
	UsuarioID INT NOT NULL,

	CONSTRAINT FK_Inter_Livro FOREIGN KEY (LivroID) REFERENCES Livro(LivroID),
	CONSTRAINT FK_Inter_Usuario FOREIGN KEY (UsuarioID) REFERENCES Usuario(UsuarioID),
);
GO

--INSERTS--
INSERT INTO Livro(NomeLivro) VALUES
('Moby Dick'),
('Hamlet')
GO

INSERT INTO Usuario(NomeUsuario, Email, Senha) VALUES
('Igor', 'igor@email.com', HASHBYTES('SHA2_256', '123')),
('Should Be', 'should@email.com', HASHBYTES('SHA2_256', '123'))
GO