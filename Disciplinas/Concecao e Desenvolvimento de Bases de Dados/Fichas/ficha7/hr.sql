
DROP DATABASE IF EXISTS HR;
CREATE DATABASE HR;
USE HR;

/* script e criação de tabelas */

-- Criar a tabela departamento
CREATE TABLE  departamentos(
	numdep		INT UNSIGNED AUTO_INCREMENT,
	nomedep		VARCHAR(20) NOT NULL,
	localizacao	VARCHAR(20) NOT NULL,
    CONSTRAINT pk_departamentos_numdep PRIMARY KEY(numdep),
    CONSTRAINT uk_departamentos_nome_dep UNIQUE(nomedep)
) ENGINE=InnoDB;

-- Criar a tabela empregado
CREATE TABLE empregados(
	numemp			INT UNSIGNED AUTO_INCREMENT,
	nomeemp			VARCHAR(20) NOT NULL,
	funcao			VARCHAR(20) NOT NULL,
	chefe			INT UNSIGNED,
	dtaContratacao	DATE NOT NULL,
	salario			DECIMAL(7,2),
	comissao		DECIMAL(7,2),
	numdep			INT UNSIGNED NOT NULL,
    CONSTRAINT pk_empregados_numemp PRIMARY KEY(numemp), 
    CONSTRAINT fk_empregados_chefe FOREIGN KEY(chefe) REFERENCES empregados(numemp),
    CONSTRAINT fk_empregados_numdep FOREIGN KEY(numdep) REFERENCES departamentos(numdep)
)ENGINE=InnoDB;

-- criar a tabela escala_salarial
CREATE TABLE escala_salarial(
	escala		INT UNSIGNED,
	minsal		MEDIUMINT UNSIGNED NOT NULL,
	maxsal		MEDIUMINT UNSIGNED NOT NULL,
    CONSTRAINT pk_escala_salarial PRIMARY KEY(escala)
)ENGINE=InnoDB;

/* INSERÇÃO DE DADOS NAS TABELAS */

-- Inserir dados na tabela DEPARTAMENTO
INSERT INTO departamentos (numdep,nomedep,localizacao) VALUES 
(10,'Contabilidade','Lisboa'),
(20,'Pesquisa','Leiria'),
(30,'Vendas','Santarém'),
(40,'Operações','Coimbra');

-- Inserir dados na tabela EMPREGADO
INSERT INTO empregados(numemp,nomeemp,funcao,chefe,dtaContratacao,salario,comissao,numdep) VALUES
(7839,'Frederico','Presidente',NULL,'1981-11-17',5000,NULL,10),
(7566,'João','Director',7839,'1981-04-02',2975,NULL,20),
(7782,'Carlos','Director',7839,'1981-06-09',2450,NULL,10),
(7698,'Bernardo','Director',7839,'1981-05-01',2850,NULL,30),
(7788,'Sebastião','Analista',7566,'1987-04-19',3000,NULL,20),
(7844,'Tiago','Vendedor',7698,'1981-09-08',1500,0,30),
(7900,'Jaime','Escriturário',7698,'1981-12-03',950,NULL,30),
(7902,'Fernando','Analista',7566,'1981-12-03',3000,NULL,20),
(7369,'Silva','Escriturário',7902,'1980-12-17',800,NULL,20),
(7499,'Alexandre','Vendedor',7698,'1981-02-20',1600,300,30),
(7521,'Armando','Vendedor',7698,'1981-02-22',1250,500,30),
(7654,'Marco','Vendedor',7698,'1981-09-28',1250,1400,30),
(7876,'António','Escriturário',7788,'1987-05-23',1100,NULL,20),
(7934,'Mário','Escriturário',7782,'1982-01-23',1300,NULL,10);

-- Inserir dados na tabela ESCALA_SALARIAL
INSERT INTO escala_salarial (escala,minsal,maxsal) VALUES 
(1,700,1200),
(2,1201,1400),
(3,1401,2000),
(4,2001,3000),
(5,3001,9999);



