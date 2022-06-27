/*
TeSP_PSI_2022_CDBD
Sistema de Informação para a Gestão da Empresa Certavac
Fábio Filipe Cabaceira, estudante n.º 2213128
Miguel Pereira Agostinho , estudante n.º 2213127
...
*/

-- O script consultas.sql deve conter as consultas importantes para ajudar a gerir o sistema;


/*	7 consultas simultaneamente com filtragens de dados + junções + ordenação +
	formatação das colunas
    
	2 consultas usando subconsultas
    
	2 consultas usando grupo */
    
    
    
    
   -- Q1: A que clientes foram prestados os serviços?
 SELECT Clientes.nome AS CLIENTE, servicocontratado.datainicio AS INICIO, servicocontratado.datafim AS FIM
    FROM servicocontratado
    INNER JOIN clientes ON servicocontratado.id = Clientes.id
    WHERE Clientes.id < 7
    ORDER BY Clientes.nome;
    
-- Q2: Que tipo de serviço foi prestado em cada venda? 
SELECT Clientes.nome AS CLIENTE, servicocontratado.datainicio AS INICIO, servicocontratado.datafim AS FIM, servico.tipodeservico AS SERVICOPRESTADO
    FROM servicocontratado
    INNER JOIN clientes ON servicocontratado.id = Clientes.id
    INNER JOIN servico ON servicocontratado.id = servico.id
    WHERE Clientes.id < 7
    ORDER BY servicocontratado.datainicio;
    
-- Q3: Quanto pagou cada cliente em cada venda? 
   SELECT clientes.nome AS NOME, particular.apelido AS APELIDO, Servico.tipoDeServico AS TIPODESERVICO, ServicoContratado.valor AS VALOR, ServicoContratado.datainicio AS INICIO, ServicoContratado.datafim AS FIM
    FROM Servico 
    INNER JOIN ServicoContratado ON Servico.id=ServicoContratado.id
    INNER JOIN Clientes ON servico.id=clientes.id
    INNER JOIN Particular ON servico.id=particular.id
    WHERE ServicoContratado.id < 7
    ORDER BY ServicoContratado.datainicio;
    
     -- Q4: Quanto faturou a empresa em cada ano?   
 
 SELECT SUM(servicocontratado.valor)FATURACAOANUAL FROM servicocontratado;
    
    
    -- A que clientes foram atribuidos certificados
     SELECT Clientes.nome AS NOMES, certatribuidos.grau AS GRAU
    FROM Clientes 
    INNER JOIN certatribuidos ON Clientes.id=certatribuidos.id
    WHERE certatribuidos.id < 7
    ORDER BY certatribuidos.grau;
    
    -- Q5: Quando comecaram e acabacaram as parcerias? 
     SELECT Parcerias.empresa AS EMPRESA, servico.tipodeservico AS TIPODESERVICO
    FROM Parcerias 
    INNER JOIN servico ON parcerias.id=servico.id
    WHERE parcerias.id < 7
    ORDER BY Parcerias.empresa;
    
     -- Q6: Que empregado conduz o Mercedes Classe S
    SELECT empregados.nome AS NOMES, empregados.apelido AS APELIDO, ViaturaDeEmpresa.modelo AS MODELO
    FROM Empregados 
    INNER JOIN ViaturaDeEmpresa ON empregados.id=ViaturaDeEmpresa.id
    WHERE viaturaDeEmpresa.modelo = 'Classe S'
    ORDER BY empregados.nome;
    
   -- Q7: Quantos empregados conduzem viaturas?
    SELECT empregados.nome AS Empregado, viaturadeempresa.modelo AS Viatura
    FROM Empregados
    INNER JOIN viaturadeempresa ON empregados.id=viaturadeempresa.id
    WHERE empregados.id < 7
    ORDER BY empregados.nome;
    
    
	-- 2 consultas usando subconsultas
    
	SELECT Clientes.nome , Clientes.rua
FROM Clientes
WHERE clientes.rua = 
    (SELECT clientes.rua
     FROM clientes
     WHERE clientes.rua = 'Rua Alegria 46');
     
SELECT viaturadeempresa.modelo , viaturadeempresa.matricula
FROM viaturadeempresa
WHERE viaturadeempresa.matricula = 
    (SELECT viaturadeempresa.matricula
     FROM viaturadeempresa
     WHERE viaturadeempresa.matricula = 'AA08AM');
     
     
-- 2 consultas usando grupo

SELECT COUNT(*), clientes.localidade, clientes.nome
FROM clientes
GROUP BY clientes.localidade, clientes.nome;

SELECT COUNT(*), empregados.cargo, empregados.nome
FROM empregados
GROUP BY empregados.cargo;

 
 
    
    

    
    