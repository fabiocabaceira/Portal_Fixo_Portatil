CREATE DATABASE BDMensagens;
Use BDMensagens;
CREATE TABLE Utilizadores(
Id 			   INT 				AUTO_INCREMENT,
Nome 		  VARCHAR(30) 		NOT NULL,
Genero 		  ENUM('masculino', 'femenino'),
dtaNascimento DATE				NOT NULL,
Email 		  VARCHAR(256)		NOT NULL,
Morada  	  VARCHAR(120)		NOT NULL,
Telefone	  VARCHAR(15)		NOT NULL,
Nif 		  CHAR(9)			NOT NULL,
Login 		  VARCHAR(8)		NOT NULL,
Password	  VARCHAR(64)		NOT NULL,
DtaRegisto    DATETIME			NOT NULL,
CONSTRAINT pk_mensagens_id PRIMARY KEY(Id),
CONSTRAINT uk_mensagens_Nif UNIQUE KEY(Nif)
) ENGINE=innoDB;
CREATE TABLE MENSAGENS(
Id				INT,
Assunto			VARCHAR(30)	   	NOT NULL, 
Mensagem		TEXT			NOT NULL,
DtaRegisto	 	DATETIME		NOT NULL,
IdUtilizador 	INT				NOT NULL,
CONSTRAINT pk_mensagens_id PRIMARY KEY(ID),
CONSTRAINT fk_mensagens_idUt FOREIGN KEY(ID) REFERENCES utilizadores(Id)
)ENGINE=innoDB;



