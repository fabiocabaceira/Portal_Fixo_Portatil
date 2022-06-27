/*
TeSP_PSI_2022_CDBD
Sistema de Informação para a Gestão da Empresa Certavac
Fábio Filipe Cabaceira, estudante n.º 2213128
Miguel Pereira Agostinho , estudante n.º 2213127
...
*/

/*O script registos.sql deve conter os comandos para a inserção de dados nas tabelas da base de
dados;
*/

/* Inserção de dados na tabela Clientes*/

INSERT INTO Clientes(nome,email,nif,rua,localidade,telefone)
VALUES ('Gina', 'ginaregina@gmail.com','246407026', 'R Pombal 79', 'Guarda','289547296');

INSERT INTO Clientes(nome,email,nif,rua,localidade,telefone)
VALUES ('Luis', 'luisbortone@gmail.com','246185490', 'Rua Alegria 46', 'Porto','289272509');

INSERT INTO Clientes(nome,email,nif,rua,localidade,telefone)
VALUES ('Joao', 'joaobortone@gmail.com','278055095', ' Rua Condes Torre 30', 'Portalegre','289912996');

INSERT INTO Clientes(nome,email,nif,rua,localidade,telefone)
VALUES ('Miguel', 'miguelbortone@gmail.com','257443720', 'Estrada Logo Deus 88', 'Aveiro','289368631');

INSERT INTO Clientes(nome,email,nif,rua,localidade,telefone)
VALUES ('Tiago', 'tiagobortonea@gmail.com','291409520', 'R José Peixoto 81', 'Évora','289000222');

INSERT INTO Clientes(nome,email,nif,rua,localidade,telefone)
VALUES ('Rodrigo', 'rodrigoregina@gmail.com','252891465', 'R Rampa Alta 72', 'Porto','289228293');


/* Inserção de dados na tabela Particular*/

INSERT INTO Particular (apelido, clienteid)
VALUES ('Regina', '1');

INSERT INTO Particular (apelido, clienteid)
VALUES ('Bortone', '2');

INSERT INTO Particular (apelido, clienteid)
VALUES ('Bortone', '3');

INSERT INTO Particular (apelido, clienteid)
VALUES ('Bortone', '4');

INSERT INTO Particular (apelido, clienteid)
VALUES ('Bortone', '5');

INSERT INTO Particular (apelido, clienteid)
VALUES ('Regina', '6');


/* Inserção de dados na tabela ClientesEmpresas*/


INSERT INTO ClientesEmpresas (sigla,clienteid)
VALUES ('MEI', '1');

INSERT INTO ClientesEmpresas (sigla,clienteid)
VALUES ('ME', '2');

INSERT INTO ClientesEmpresas (sigla,clienteid)
VALUES ('EPP', '3');

INSERT INTO ClientesEmpresas (sigla,clienteid)
VALUES ('SA', '4');

INSERT INTO ClientesEmpresas (sigla,clienteid)
VALUES ('CRM', '5');

INSERT INTO ClientesEmpresas (sigla,clienteid)
VALUES ('ERP', '6');


/* Inserção de dados na tabela Parcerias*/

INSERT INTO Parcerias(inicio,fim,empresa)
VALUES ('2022-02-6','2032-02-6', 'Fnac');

INSERT INTO Parcerias(inicio,fim,empresa)
VALUES ('2021-04-7','2031-04-7', 'Worten');

INSERT INTO Parcerias(inicio,fim,empresa)
VALUES ('2020-03-4','2030-03-4', 'Electrolandia');

INSERT INTO Parcerias(inicio,fim,empresa)
VALUES ('2019-01-9','2029-01-9', 'Peças');

INSERT INTO Parcerias(inicio,fim,empresa)
VALUES ('2018-06-8','2028-06-8', 'Monitoria');

INSERT INTO Parcerias(inicio,fim,empresa)
VALUES ('2017-02-2','2027-02-2', 'Caminhodosratos');


/* Inserção de dados na tabela Servico*/

INSERT INTO Servico(tipoDeServico)
VALUES ('certificação energética em fase de projeto');

INSERT INTO Servico(tipoDeServico)
VALUES ('certificação energética dos edifícios (ce)');

INSERT INTO Servico(tipoDeServico)
VALUES ('auditoria energética (ae)');

INSERT INTO Servico(tipoDeServico)
VALUES ('estudos de racionalização energética e da qai');

INSERT INTO Servico(tipoDeServico)
VALUES ('supervisão de manutenção de sistemas avac');

INSERT INTO Servico(tipoDeServico)
VALUES ('fiscalização em obra');


/* Inserção de dados na tabela ServicoContratado*/

INSERT INTO ServicoContratado(valor,datainicio,datafim)
VALUES ('1000', '2022-03-3','2022-09-3');

INSERT INTO ServicoContratado(valor,datainicio,datafim)
VALUES ('2000', '2022-04-3','2022-10-3');

INSERT INTO ServicoContratado(valor,datainicio,datafim)
VALUES ('3000', '2022-05-3','2022-11-3');

INSERT INTO ServicoContratado(valor,datainicio,datafim)
VALUES ('4000', '2022-06-3','2022-12-3');

INSERT INTO ServicoContratado(valor,datainicio,datafim)
VALUES ('5000', '2022-02-3','2022-08-3');

INSERT INTO ServicoContratado(valor,datainicio,datafim)
VALUES ('6000', '2022-01-3','2022-07-3');

/* Inserção de dados na tabela Empregados*/

INSERT INTO Empregados(nome,apelido,nif,cargo,dtaNascimento, servicoid)
VALUES ('Ana', 'Marques', '285293591', 'Sócio-gerente', '1990-08-21', '1' );

INSERT INTO Empregados(nome,apelido,nif,cargo,dtaNascimento, servicoid)
VALUES ('Cristóvão', 'Marques', '267420781', 'Sócio-gerente', '1990-05-8', '2' );

INSERT INTO Empregados(nome,apelido,nif,cargo,dtaNascimento, servicoid)
VALUES ('Miguel', 'Marques', '289241782', 'Programador', '2003-09-9', '3' );

INSERT INTO Empregados(nome,apelido,nif,cargo,dtaNascimento)
VALUES ('Luis', 'Inácio', '282408436', 'Programador', '1973-09-15' );

INSERT INTO Empregados(nome,apelido,nif,cargo,dtaNascimento)
VALUES ('Beatriz', 'Salvador', '246651440', 'Secretária', '1976-03-5' );

INSERT INTO Empregados(nome,apelido,nif,cargo,dtaNascimento)
VALUES ('Manuel', 'Alexandre', '227438256', 'Técnico', '1980-02-6');


/* Inserção de dados na tabela ViaturaDeEmpresa*/

INSERT INTO ViaturaDeEmpresa(marca,modelo,matricula,ano)
VALUES ('Porsche', 'Porsche Panamera','AA33XQ', '2018');

INSERT INTO ViaturaDeEmpresa(marca,modelo,matricula,ano)
VALUES ('Peugeot', '508 Peugeot sport engineered','2533XQ', '2022');

INSERT INTO ViaturaDeEmpresa(marca,modelo,matricula,ano)
VALUES ('Peugeot', 'Peugeot e-expert combi','AA08AM', '2022');

INSERT INTO ViaturaDeEmpresa(marca,modelo,matricula,ano)
VALUES ('BMW', 'BMW i4','AB02AF', '2022');

INSERT INTO ViaturaDeEmpresa(marca,modelo,matricula,ano)
VALUES ('BMW', 'BMW iX3 ','AC06AC', '2022');

INSERT INTO ViaturaDeEmpresa(marca,modelo,matricula,ano)
VALUES ('Mercedes', 'Classe S','AE02AE', '2022');


/* Inserção de dados na tabela CertAtribuidos*/

INSERT INTO CertAtribuidos (grau, dtavalidade, dtaemissao, idservico, idcliente)
VALUES ('A+', '2024-06-10', '2014-06-10', '1', '1' );

INSERT INTO CertAtribuidos (grau, dtavalidade, dtaemissao, idservico, idcliente)
VALUES ('A', '2025-07-10', '2015-07-10', '2', '2'  );

INSERT INTO CertAtribuidos (grau, dtavalidade, dtaemissao, idservico, idcliente)
VALUES ('B', '2026-08-10', '2016-08-10', '3', '3'  );

INSERT INTO CertAtribuidos (grau, dtavalidade, dtaemissao, idservico, idcliente)
VALUES ('C', '2027-09-10', '2017-09-10', '4', '4'  );

INSERT INTO CertAtribuidos (grau, dtavalidade, dtaemissao, idservico, idcliente)
VALUES ('D', '2028-10-10', '2018-10-10', '5', '5'  );

INSERT INTO CertAtribuidos (grau, dtavalidade, dtaemissao, idservico, idcliente)
VALUES ('E', '2029-11-10', '2019-11-10', '6', '6'  );







