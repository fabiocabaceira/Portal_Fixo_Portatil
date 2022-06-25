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
FKPID 		INT,
PRIMARY KEY (id)
)ENGINE=INNODB;

CREATE TABLE ClientesEmpresas(
sigla 		VARCHAR(4)					NOT NULL,
id 			INT							NOT NULL		AUTO_INCREMENT,
FKCeID 		INT,
PRIMARY KEY (id)
)ENGINE=INNODB;

CREATE TABLE CertAtribuidos (
id 			INT 			UNIQUE 		NOT NULL		AUTO_INCREMENT,
grau		VARCHAR(2)					NOT NULL,
dtavalidade	DATE 						NOT NULL,
dtaemissao 	DATE						NOT NULL,
FKCaID1 		INT										, 
FKCaID2			INT										, 
PRIMARY KEY (id)
)ENGINE=INNODB;

CREATE TABLE Parcerias(
id 			INT				UNIQUE 		NOT NULL		AUTO_INCREMENT,
inicio 		DATE						NOT NULL,
fim			DATE						NOT NULL,
empresa		VARCHAR(32)					NOT NULL,
FKPaID 		INT ,
PRIMARY KEY (id)
)ENGINE=INNODB;

CREATE TABLE Empregados(
id 				INT 			UNIQUE 		NOT NULL	AUTO_INCREMENT,
nome			VARCHAR(16)					NOT NULL,
apelido			VARCHAR(16)					NOT NULL,
nif				INT(9)			UNIQUE		NOT NULL,
cargo 			VARCHAR(16)					NOT NULL,
dtaNascimento	DATE						NOT NULL    ,
FKEID 		INT,
PRIMARY KEY (id)
)ENGINE=INNODB;

CREATE TABLE ViaturaDeEmpresa(
id 				INT 			UNIQUE		NOT NULL	AUTO_INCREMENT,
marca 			VARCHAR(16) 				NOT NULL,
modelo			VARCHAR(99)					NOT NULL,
matricula		VARCHAR(6)					NOT NULL,
ano 			INT						NOT NULL,
FKVdeID 		INT,
PRIMARY KEY (id)
)ENGINE=INNODB;

CREATE TABLE Servico(
id 				INT				UNIQUE		NOT NULL	AUTO_INCREMENT,
tipoDeServico	VARCHAR(99)					NOT NULL,
FKSID 		INT,
PRIMARY KEY (id)
)ENGINE=INNODB;

CREATE TABLE ServicoContratado(
id 				INT				UNIQUE		NOT NULL	AUTO_INCREMENT,
valor			DOUBLE						NOT NULL,
datainicio		DATE						NOT NULL,
datafim			DATE						NOT NULL,
FKScID 		INT,
PRIMARY KEY (id) 
)ENGINE=INNODB;

CREATE TABLE ChefeDeServico(
id 				INT				UNIQUE		NOT NULL	AUTO_INCREMENT,
FKCdsID 		INT,
PRIMARY KEY (id) 
)ENGINE=INNODB;


ALTER TABLE Particular
ADD CONSTRAINT FKPrID FOREIGN KEY (id)
					REFERENCES Clientes(id);
                    
ALTER TABLE ClientesEmpresas
ADD CONSTRAINT FKCeID FOREIGN KEY (id)
					REFERENCES Clientes(id);
                    
ALTER TABLE servicocontratado
ADD CONSTRAINT FKScID FOREIGN KEY (id)
					REFERENCES Clientes(id);
                    
ALTER TABLE servico
ADD CONSTRAINT FKSID FOREIGN KEY (id)
					REFERENCES servicocontratado(id);
                    
ALTER TABLE parcerias
ADD CONSTRAINT FKPaID FOREIGN KEY (id)
					REFERENCES servico(id);
                    
ALTER TABLE empregados
ADD CONSTRAINT FKEID FOREIGN KEY (id)
					REFERENCES servico(id);
                    
ALTER TABLE ChefeDeServico
ADD CONSTRAINT FKCdsID FOREIGN KEY (id)
					REFERENCES empregados(id);
                    
ALTER TABLE ViaturaDeEmpresa
ADD CONSTRAINT FKVdeID FOREIGN KEY (id)
					REFERENCES empregados(id);
                    
ALTER TABLE CertAtribuidos
ADD CONSTRAINT FKCaID1 FOREIGN KEY (id)
					REFERENCES servico(id);
                    
ALTER TABLE CertAtribuidos
ADD CONSTRAINT FKCaID2 FOREIGN KEY (id)
					REFERENCES clientes(id);



