
DROP DATABASE if exists bdmensagens;
CREATE DATABASE bdmensagens;
USE bdmensagens;

CREATE TABLE Utilizadores(
ID				INT			AUTO_INCREMENT,
nome			VARCHAR(30) 	NOT NULL,
genero			ENUM('M','F')	NOT NULL DEFAULT 'M',
dtaNascimento	DATE 			NOT NULL,
email 			VARCHAR(150) 	NOT NULL,
morada			VARCHAR(120) 	NOT NULL,
nif				CHAR(9),
login           VARCHAR(15) 	NOT NULL,
senha			VARCHAR(64) 	NOT NULL,
dtaRegisto		DATETIME 		NOT NULL,
CONSTRAINT pk_utilizadores_id PRIMARY KEY(ID),
CONSTRAINT uk_utilizadores_nif UNIQUE(nif)
) ENGINE=InnoDB;

CREATE TABLE Mensagens(

ID 			INT		AUTO_INCREMENT,
assunto		VARCHAR(20) NOT NULL,
mensagem	TEXT 		NOT NULL,
dtaRegisto	DATETIME    NOT NULL,
IDUTILIZADOR 	INT 	NOT NULL,
CONSTRAINT pk_mensagem_id PRIMARY KEY(ID), 
CONSTRAINT fk_mensagem_idutilizador FOREIGN KEY(IDUTILIZADOR) REFERENCES UTILIZADORES(ID))ENGINE=INNODB;

INSERT INTO Utilizadores VALUES (NULL,'Ana Pedro','F','2000-01-01','ana.pedro@gmail.com','Leiria',
'123456789', 'Ana,Pedro','A#123!na',NOW());
INSERT INTO Utilizadores VALUES(NULL,'AntonioJose', 'M', '1998-01-01', 'antonio.pedro@gmail.com',
'Leiria','987654321','antonio.pedro',Sha2('A#123!ntonio',256), NOW());

INSERT INTO Utilizadores VALUES(NULL,'Miguel Sousa', 'F', '1995-01-01', 'vasco.sousa@gmail.com',
'Leiria','434343434', 'miguel.sousa', Sha2('M#i!123guel',256), NOW()),(NULL,'Andreia Santos','F','2001-01-1','andreia.santos@gmai.com',
'Leiria','111111111','andreia santos', Sha2('A#n!123dreia',256),NOW());

UPDATE Utilizadores
SET nome = UPPER(nome)
WHERE nome;


UPDATE Utilizadores
SET morada = 'Rua dos Estudantes, Leiria'
WHERE id = 1;

UPDATE Utilizadores
SET nif = '123456790'
WHERE id = 4;

INSERT INTO Mensagens VALUES(NULL,'Bases de Dados', 'Duvida no comandos
INSERT', NOW(), 1);

DELETE FROM Utilizadores
WHERE id = 1;


