# Antes de ler

Este ficheiro utiliza **markdown**, assim para uma **melhor experiência de leitura**, vai-a a este site [Markdown Online](https://dillinger.io/) e **copie todo o texto deste ficheiro** para o site.

## Importante!

Para o **correto funcionamento** do programa faça os seguintes passos:

> Mude o local da pasta **ServerDB**, que está dentro do zip, para o C:\\

> Inicie o Server.exe **primeiro** (localizado Projeto-Topicos-Seguranca\App\bin\Debug\Server.exe )

> Inicie o App.exe em **segundo** (localizado Projeto-Topicos-Seguranca\App\bin\Debug\App.exe )


### Notas a ter em consideração:

Quando inicia a app mais do que uma vez, para quando quer testar *n* pessoas ao mesmo tempo faça as operações em **um de cada vez**, porque caso contrário poderá ocorrer erros inesperados, não consegimos descobrir o porquê.

Houve uma **alteração** no design da app, esta foi a mudança do **tipo de mensagem** de "outras pessoas". 
Nós não conseguimos chegar ao resultado pretendido para o design deste tipo, logo tivemos de recorrer a utilizar o **tipo de mensagem** "minhaMensagem".

Existe um **"bug"** em que o loader **não** aparece , também acontece, mais raramente, nas notificações, nós tentá-mos encontrar o problema mas não o achá-mos, no entanto, com o **Server** aberto você consegue vêr as mensagens do cliente, por isso, se não vir o loader veja o **Server** e espere um bocadinho para vêr se registou a ação ou não.

Ao **escrever** a mensagem no chat não escreva o caractér **;**.

Se quiser abrir a **solução da app**, esta está localizada em *Projeto-Topicos-Seguranca\App\App.sln*.


### Extras no projeto:

Achámos mais fácil dizer tudo o que o projeto tem, poderá haver algum extra que nós não considerámos como extra mas se calhar até é.

- Encriptação assimétrica **diferente** para quando o cliente envia uma mensagem ao servidor e quando o servidor envia uma mensagem ao cliente, **i.e**, o cliente tem uma chave assimétrica pública e o servidor também tem a dele;

- Encriptação simétrica **diferente** para o cliente e o servidor como acontece na encriptação assimétrica;

- Na encriptação simétrica **toda a vez** que uma mensagem é enviado pê-lo o cliente ou servidor é também feito um **novo vetor de inicialização** para as strings serem sempre diferentes, esta funcionalidade foi recomendada pela documentação da microsoft;

- Possível utilizar **n** clientes, **fazendo como as notas dizem**;

- Todas as ações do cliente são **primeiro validadas** pelo servidor, **i.e**, por exemplo, quando o cliente envia uma mensagem, esta é primeiro enviada ao servidor e só depois da resposta do servidor é que ela é , dependendo da resposta, adicionada ao chat;

- Extras UI (**Sistema de notificicações personalizado**, **Sistema de loading personalizado**);

- No lado do cliente **todo** o programa é **assincrono**;

- Todas as ações que o cliente tenta fazer são primeiro **validadas** para vêr se este pode fazê-las ou não, caso não, este é notificado, **i.e**, por exeaplo, o cliente envia uma mensagem ao servidor, se este tentar enviar outra irá ser notificado que não pode enquanto a outra mensagem não é enviada;

- O servidor **tem** uma **base de dados** com os clientes e **tem** um **ficheiro** com todas as mensagens já enviadas pelos clientes.

- O cliente tem como ações: **dar login**, **registar**, **enviar mensagens** e **dar logout**.

Mesmo assim, como já referido anteriormente, **pode ter escapado** alguma coisa extra. Isto porque esta lista foi feita no mesmo dia da entrega do projeto. 

### Comentários das funções

Para simplificar os comentários das funções e em geral da app, decidimos utilizar **regiões (Custom UI)**, pois assim, consegue dar collapse de coisas desnecessárias, no entanto, se quiser vê-las pode abri-las à mesma, só que não devidamente comentadas.

Algumas coisas **não estão comentadas** por serem óbvias, por exemplo: 
- Acabar com uns whiles;
- Propriedas que são utilizadas por outras classes e precisam de ser visiveis;
- Validações se as strings são empty ou nullas;
- etc.

Assim se vir alguma coisa fora da região (Custom UI) e não estiver comentada já sabe qual é a razão.