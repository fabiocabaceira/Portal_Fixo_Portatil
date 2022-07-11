-- 1
SELECT 	nomeemp,
		empregados.numdep,
        nomedep, 
        localizacao
FROM 	empregados INNER JOIN departamentos 
ON empregados.numdep=departamentos.numdep
ORDER BY localizacao ASC;

-- 2
SELECT 	nomeemp, 
		salario,
        departamentos.nomedep,
        departamentos.localizacao
FROM empregados
INNER JOIN departamentos
 ON empregados.numdep = departamentos.numdep
WHERE salario>1500
ORDER BY nomeemp ASC;

-- 3 
SELECT 	nomeemp, 
		funcao,
		salario,
        nomedep
FROM empregados
INNER JOIN departamentos ON empregados.numdep = departamentos.numdep
WHERE funcao NOT IN ('analista')
ORDER BY salario DESC, nomeemp ASC;



