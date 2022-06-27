/*
TeSP_PSI_2022_CDBD
Sistema de Informação para a Gestão da Empresa Certavac
Fábio Filipe Cabaceira, estudante n.º 2213128
Miguel Pereira Agostinho , estudante n.º 2213127
...
*/

/* O script tabelas.sql deve conter os comandos para a criação da base de dados e tabelas, usando
como nome desta, o código da equipa de projeto (ex: base de dados E15 para a equipa E15);
*/


CREATE DATABASE PLTVE;
USE PLTVE;

CREATE TABLE Clientes (
id 			INT 			UNIQUE		NOT NULL	   	AUTO_INCREMENT,
nome 		VARCHAR(16) 				NOT NULL,
email		VARCHAR(32),
nif			INT(9) 			UNIQUE 		NOT NULL,
rua 		VARCHAR(64) 	 			NOT NULL,
localidade 	VARCHAR(16) 				NOT NULL,
telefone	INT(9) 			UNIQUE 		NOT NULL, 
PRIMARY KEY (id)
)ENGINE=INNODB;

CREATE TABLE Particular(
apelido 	VARCHAR(16)					NOT NULL,
id 			INT							NOT NULL		AUTO_INCREMENT,
clienteid		INT,
PRIMARY KEY (id)
)ENGINE=INNODB;

CREATE TABLE ClientesEmpresas(
sigla 		VARCHAR(4)					NOT NULL,
id 			INT							NOT NULL		AUTO_INCREMENT,
clienteid 		INT,
PRIMARY KEY (id)
)ENGINE=INNODB;

CREATE TABLE CertAtribuidos (
id 			INT 			UNIQUE 		NOT NULL		AUTO_INCREMENT,
grau		VARCHAR(2)					NOT NULL,
dtavalidade	DATE 						NOT NULL,
dtaemissao 	DATE						NOT NULL,
idservico 		INT										, 
idcliente		INT										, 
PRIMARY KEY (id)
)ENGINE=INNODB;

CREATE TABLE Parcerias(
id 			INT				UNIQUE 		NOT NULL		AUTO_INCREMENT,
inicio 		DATE						NOT NULL,
fim			DATE						NOT NULL,
empresa		VARCHAR(32)					NOT NULL,
servicoid 		INT ,
PRIMARY KEY (id)
)ENGINE=INNODB;

CREATE TABLE Empregados(
id 				INT 			UNIQUE 		NOT NULL	AUTO_INCREMENT,
nome			VARCHAR(16)					NOT NULL,
apelido			VARCHAR(16)					NOT NULL,
nif				INT(9)			UNIQUE		NOT NULL,
cargo 			VARCHAR(16)					NOT NULL,
dtaNascimento	DATE						NOT NULL    ,
servicoid 		INT,
PRIMARY KEY (id)
)ENGINE=INNODB;

CREATE TABLE ViaturaDeEmpresa(
id 				INT 			UNIQUE		NOT NULL	AUTO_INCREMENT,
marca 			VARCHAR(16) 				NOT NULL,
modelo			VARCHAR(99)					NOT NULL,
matricula		VARCHAR(6)					NOT NULL,
ano 			INT						NOT NULL,
empregadoid 		INT,
PRIMARY KEY (id)
)ENGINE=INNODB;

CREATE TABLE Servico(
id 				INT				UNIQUE		NOT NULL	AUTO_INCREMENT,
tipoDeServico	VARCHAR(99)					NOT NULL,
servicocontratadoid 		INT,
PRIMARY KEY (id)
)ENGINE=INNODB;

CREATE TABLE ServicoContratado(
id 				INT				UNIQUE		NOT NULL	AUTO_INCREMENT,
valor			DOUBLE						NOT NULL,
datainicio		DATE						NOT NULL,
datafim			DATE						NOT NULL,
clienteid 		INT,
PRIMARY KEY (id) 
)ENGINE=INNODB;

CREATE TABLE ChefeDeServico(
id 				INT				UNIQUE		NOT NULL	AUTO_INCREMENT,
empregadoid 		INT,
PRIMARY KEY (id) 
)ENGINE=INNODB;


ALTER TABLE Particular
ADD CONSTRAINT FKPrID FOREIGN KEY (clienteid)
					REFERENCES Clientes(id);
                    
ALTER TABLE ClientesEmpresas
ADD CONSTRAINT FKCeID FOREIGN KEY (clienteid)
					REFERENCES Clientes(id);
                    
ALTER TABLE ServicoContratado
ADD CONSTRAINT FKScID FOREIGN KEY (clienteid)
					REFERENCES Clientes(id);
                    
ALTER TABLE Servico
ADD CONSTRAINT FKSID FOREIGN KEY (servicocontratadoid)
					REFERENCES ServicoContratado(id);
                    
ALTER TABLE Parcerias
ADD CONSTRAINT FKPaID FOREIGN KEY (servicoid)
					REFERENCES Servico(id);
                    
ALTER TABLE Empregados
ADD CONSTRAINT FKEID FOREIGN KEY (servicoid)
					REFERENCES Servico(id);
                    
ALTER TABLE ChefeDeServico
ADD CONSTRAINT FKCdsID FOREIGN KEY (empregadoid)
					REFERENCES Empregados(id);
                    
ALTER TABLE ViaturaDeEmpresa
ADD CONSTRAINT FKVdeID FOREIGN KEY (empregadoid)
					REFERENCES Empregados(id);
                    
ALTER TABLE CertAtribuidos
ADD CONSTRAINT FKCaID1 FOREIGN KEY (idservico)
					REFERENCES Servico(id);
                    
ALTER TABLE CertAtribuidos
ADD CONSTRAINT FKCaID2 FOREIGN KEY (idcliente)
					REFERENCES Clientes(id);



