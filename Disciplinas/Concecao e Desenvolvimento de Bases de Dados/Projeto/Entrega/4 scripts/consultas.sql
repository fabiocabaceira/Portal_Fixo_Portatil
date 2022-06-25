/*
TeSP_PSI_2022_CDBD
Sistema de Informação para a Gestão da Empresa Certavac
Fábio Filipe Cabaceira, estudante n.º 2213128
Miguel Pereira Agostinho , estudante n.º 2213127
...
*/

/* O script consultas.sql deve conter as consultas importantes para ajudar a gerir o sistema;
*/

/*	7 consultas simultaneamente com filtragens de dados + junções + ordenação +
	formatação das colunas
    
	2 consultas usando subconsultas
    
	2 consultas usando grupo */
    
    
    
    /* 7 consultas simultaneamente com filtragens de dados + junções + ordenação +
	formatação das colunas */
    
    SELECT Clientes.nome, Particular.apelido
    FROM Clientes 
    INNER JOIN Particular ON Clientes.id=Particular.id;
    
	SELECT Clientes.nome, Particular.apelido, Clientes.email
    FROM Clientes 
	INNER JOIN Particular ON Clientes.id=Particular.id;
    
	SELECT Clientes.nome, Particular.apelido, Clientes.rua, Clientes.localidade
    FROM Clientes 
    INNER JOIN Particular ON Clientes.id=Particular.id;
    
     SELECT Servico.tipoDeServico, ServicoContratado.valor, ServicoContratado.datainicio, ServicoContratado.datafim
    FROM Servico 
    INNER JOIN ServicoContratado ON Servico.id=ServicoContratado.id;
    
     SELECT Clientes.nome, Particular.apelido
    FROM Clientes 
    INNER JOIN Particular ON Clientes.id=Particular.id;
    
     SELECT Clientes.nome, Particular.apelido
    FROM Clientes 
    INNER JOIN Particular ON Clientes.id=Particular.id;
    
     SELECT Clientes.nome, Particular.apelido
    FROM Clientes 
    INNER JOIN Particular ON Clientes.id=Particular.id;
    

    
    