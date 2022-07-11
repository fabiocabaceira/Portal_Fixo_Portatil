SELECT * FROM clientes;

SElECT * FROM clientes
ORDER BY nome;

SELECT nome,email,ncontribuinte
FROM clientes
ORDER BY email;

SELECT * FROM produtos;

SELECT artigo,descricao,preco
FROM produtos
ORDER BY preco DESC;

SELECT artigo,descricao,preco
FROM produtos
ORDER BY descricao;

SELECT * FROM produtos
WHERE idcategoria = 33
ORDER BY stock DESC;

SELECT * FROM produtos
WHERE idcategoria IN (33,45)
ORDER BY idcategoria ASC, preco DESC;

SELECT * FROM produtos 
WHERE idcategoria IN (4,5,6)
ORDER BY stock DESC;

SELECT * 
FROM categorias
WHERE idcategoriapai IS NULL
ORDER BY designacao;

SELECT *
FROM clientes
WHERE nome LIKE 'A%';

SELECT *
FROM clientes 
WHERE nome LIKE 'Jóse%'
ORDER BY nome;

SELECT *
FROM clientes
WHERE nome LIKE '%Silva%'
ORDER BY nome ASC;

SELECT nome, email, ncontribuinte
FROM clientes
WHERE YEAR(dataregisto) = 2017
ORDER BY nome ASC;

SELECT nome, email, ncontribuinte
FROM clientes
WHERE YEAR(dataregisto)=2017 AND nome LIKE 'José%'
ORDER BY nome ASC; 

SELECT nome, email, ncontribuinte 
FROM clientes
WHERE nome LIKE '%José%' OR nome LIKE '%Miguel%'
ORDER BY nome ASC;

SELECT *
FROM vendas
WHERE YEAR(datavenda) = 2018
ORDER BY datavenda DESC;

SELECT *
FROM vendas 
WHERE YEAR(datavenda) = 2018 AND MONTH(datavenda) = 1
ORDER BY total DESC;

SELECT datavenda, total, idcliente
FROM vendas
WHERE idcliente=80 OR idcliente=107
ORDER BY datavenda DESC, total DESC;

SELECT idcliente,datavenda,total
FROM vendas
WHERE total>999
ORDER BY total;

SELECT idcliente, datavenda, total
FROM vendas 
WHERE total BETWEEN 50 AND 100 AND MONTH(datavenda) = 1 AND YEAR(datavenda) = 2018
ORDER BY idcliente ASC;

SELECT idcliente,datavenda,total,round(total*1.23,2) AS totalIVA
FROM vendas
WHERE datavenda BETWEEN '2018-01-01' AND '2028-06-30'
ORDER BY idcliente, totalIVA;





