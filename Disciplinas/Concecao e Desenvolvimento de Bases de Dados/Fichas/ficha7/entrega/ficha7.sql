-- 2
SELECT funcao
FROM empregados
ORDER BY funcao ASC;

-- 3
SELECT numdep
FROM empregados
ORDER BY numdep DESC;

-- 4
SELECT nomeemp, salario, IFNULL(comissao,'O empregado não tem comissao') AS COMISSAO
FROM empregados
ORDER BY salario DESC, nomeemp ASC;

-- 5
SELECT numemp, nomeemp, salario
FROM empregados
WHERE salario>2000
ORDER BY salario DESC;

-- 6
SELECT CONCAT('O ', UPPER(nomeemp), ' é ', UPPER(funcao), ' no departamento ', UPPER(numdep), ', desde ', DATE_FORMAT(dtacontratacao,'%d-%m-%Y')) AS 'Quem, Onde, Quando'
FROM empregados;

-- 7
SELECT CONCAT('O ', nomeemp, ' ganha ', salario, ' mas queria ganhar ', round(salario*3,2), '(3xmais)') AS '3 VEZES MAIS' 
FROM empregados;

-- 8
SELECT nomeemp, salario, comissao
FROM empregados
WHERE salario<comissao
ORDER BY nomeemp ASC;

-- 9
SELECT nomeemp, funcao
FROM empregados 
WHERE funcao = 'Vendedor' OR funcao = 'Director'
ORDER BY nomeemp ASC;

-- 10
SELECT nomeemp, numdep
FROM empregados
WHERE numdep=10 OR numdep=20
ORDER BY numdep ASC;

-- 11
SELECT nomeemp
FROM empregados 
WHERE nomeemp LIKE 'M%'
ORDER BY nomeemp ASC;

-- 12
SELECT nomeemp
FROM empregados
WHERE nomeemp LIKE '%DO'
ORDER BY nomeemp ASC;

-- 13
SELECT nomeemp
FROM empregados
WHERE nomeemp LIKE 'M%O'
ORDER BY nomeemp ASC;

-- 14
SELECT nomeemp
FROM empregados
WHERE nomeemp LIKE '%O%'
ORDER BY nomeemp ASC;

-- 15
SELECT nomeemp
FROM empregados 
WHERE INSTR(nomeemp, 'A')>1
ORDER BY nomeemp;

-- 16
SELECT nomeemp
FROM empregados
WHERE nomeemp NOT LIKE '%O%';

-- 17
SELECT nomeemp, IFNULL(comissao, 'Sem Comissão') AS Comissão
FROM empregados
WHERE comissao IS NULL
ORDER BY nomeemp ASC;

-- 18
SELECT nomeemp
FROM empregados
WHERE chefe IS NULL;

-- 19 
SELECT nomeemp, salario
FROM empregados 
WHERE comissao IS NULL AND salario>2000
ORDER BY salario DESC;

-- 20 
SELECT nomeemp, salario, round(salario * 1.15) AS SALARIO_AUMENTADO
FROM empregados
ORDER BY salario DESC;

-- 21
SELECT nomeemp, dtacontratacao, adddate(dtacontratacao, INTERVAL 1 YEAR) AS datarevisão 
FROM empregados
ORDER BY nomeemp DESC;

-- 22
SELECT nomeemp, timestampdiff(YEAR, dtaContratacao, CURDATE() ) AS 'Tempo de serviço (em anos)' 
FROM empregados 
WHERE chefe IS NULL;

-- 23

SELECT nomeemp, CASE WHEN salario<1500 THEN 'Menos que 1500' 
					WHEN salario>1500 THEN TRUNCATE(salario,0)
					ELSE 'Valor Exato'
				END AS estado
FROM empregados;
									




