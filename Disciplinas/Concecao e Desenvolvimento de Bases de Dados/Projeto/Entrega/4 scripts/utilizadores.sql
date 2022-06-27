/*
TeSP_PSI_2022_CDBD
Sistema de Informação para a Gestão da Empresa Certavac
Fábio Filipe Cabaceira, estudante n.º 2213128
Miguel Pereira Agostinho , estudante n.º 2213127
...
*/

/* Por fim, o script utilizadores.sql com os comandos para a criação de vistas que imponham
limitações no acesso aos dados; comandos para atribuir privilégios adequados à utilização dessas
vistas.
*/

/*Para o caso de já existir utilizadores com este nome*/
/*DROP USER 'vendas'@'%';
DROP USER 'admin'@'%';
DROP USER 'certificador'@'%';*/

/*Cria os utilizadores*/
CREATE USER 'vendas'@'%'
	IDENTIFIED BY 'v3nd4s#ddr';
CREATE USER 'admin'@'%'
	IDENTIFIED BY '4dm1n%ads';
CREATE USER 'certificador'@'%'
	IDENTIFIED BY 'c3rt1&cdr';
    
/*Definição de permissões*/
/*do utilizador vendas*/
GRANT SELECT, INSERT, UPDATE
ON PLTVE.servico
TO 'vendas'@'%';
GRANT SELECT, INSERT, UPDATE
ON PLTVE.particular
TO 'vendas'@'%';
GRANT SELECT, INSERT, UPDATE
ON PLTVE.clientesempresas
TO 'vendas'@'%';
/*do administrador*/
GRANT ALL PRIVILEGES
ON PLTVE.*
TO 'admin'@'%' WITH GRANT OPTION;
/*do utilizador certificador*/
GRANT SELECT, INSERT, UPDATE
ON PLTVE.certatribuidos
TO 'certificador'@'%';
GRANT SELECT, INSERT, UPDATE
ON PLTVE.servico
TO 'certificador'@'%';
GRANT SELECT, INSERT, UPDATE
ON PLTVE.clientes
TO 'certificador'@'%';
GRANT SELECT, INSERT, UPDATE
ON PLTVE.clientesempresas
TO 'certificador'@'%';
GRANT SELECT, INSERT, UPDATE
ON PLTVE.particular
TO 'certificador'@'%';
GRANT SELECT, INSERT, UPDATE
ON PLTVE.empregados
TO 'certificador'@'%';
GRANT SELECT, INSERT, UPDATE
ON PLTVE.clientes
TO 'vendas'@'%';