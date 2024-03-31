const express = require("express");
const bodyParser = require("body-parser");

const app = express();
app.use(bodyParser.json());
/* 
  IMPORTANTE:
  Este código é apenas para fins de demonstração e não representa boas práticas de segurança.
*/
const usuarios = {
  "jim@joesrobotshop.com": {
    primeiroNome: "Jim",
    ultimoNome: "Cooper",
    email: "jim@joesrobotshop.com",
    senha: "very-secret",
  },
  "joe@joesrobotshop.com": {
    primeiroNome: "Joe",
    ultimoNome: "Eames",
    email: "joe@joesrobotshop.com",
    senha: "super-secret",
  },
};
let carrinho = [];

// Use isso para adicionar um atraso de 1 segundo a todas as solicitações
// app.use(function (req, res, next) {
//   setTimeout(next, 1000);
// });

app.get("/api/produtos", (req, res) => {
  let produtos = [
    {
      id: 1,
      descricao: "Uma cabeça de robô com um olho anormalmente grande e pescoço telescópico -- excelente para explorar espaços altos.",
      nome: "Ciclope Grande",
      nomeImagem: "head-big-eye.png",
      categoria: "Cabeças",
      preco: 1220.5,
      desconto: 0.2,
    },
    {
      id: 17,
      descricao: "Uma base com mola - ótima para alcançar lugares altos.",
      nome: "Base com Mola",
      nomeImagem: "base-spring.png",
      categoria: "Bases",
      preco: 1190.5,
      desconto: 0,
    },
    {
      id: 6,
      descricao: "Um braço articulado com garra -- ótimo para alcançar cantos ou trabalhar em espaços apertados.",
      nome: "Braço Articulado",
      nomeImagem: "arm-articulated-claw.png",
      categoria: "Braços",
      preco: 275,
      desconto: 0,
    },
    {
      id: 2,
      descricao: "Uma cabeça de robô amigável com dois olhos e um sorriso -- ótima para uso doméstico.",
      nome: "Robô Amigável",
      nomeImagem: "head-friendly.png",
      categoria: "Cabeças",
      preco: 945.0,
      desconto: 0.2,
    },
    {
      id: 3,
      descricao: "Uma cabeça grande com três olhos e uma boca trituradora -- ótima para esmagar metais leves ou triturar documentos.",
      nome: "Triturador",
      nomeImagem: "head-shredder.png",
      categoria: "Cabeças",
      preco: 1275.5,
      desconto: 0,
    },
    {
      id: 16,
      descricao: "Uma base com uma única roda e acelerômetro capaz de atingir altas velocidades e navegar em terrenos mais acidentados que a variedade de duas rodas.",
      nome: "Base de Roda Única",
      nomeImagem: "base-single-wheel.png",
      categoria: "Bases",
      preco: 1190.5,
      desconto: 0.1,
    },
    {
      id: 13,
      descricao: "Um torso simples com um bolsão para carregar itens.",
      nome: "Torso com Bolsão",
      nomeImagem: "torso-pouch.png",
      categoria: "Torsos",
      preco: 785,
      desconto: 0,
    },
    {
      id: 7,
      descricao: "Um braço com duas garras independentes -- ótimo quando você precisa de uma mão extra. Precisa de quatro mãos? Equipe seu robô com dois destes braços.",
      nome: "Braço com Duas Garras",
      nomeImagem: "arm-dual-claw.png",
      categoria: "Braços",
      preco: 285,
      desconto: 0,
    },
    {
      id: 4,
      descricao: "Uma cabeça simples com um único olho -- simples e barata.",
      nome: "Ciclope Pequeno",
      nomeImagem: "head-single-eye.png",
      categoria: "Cabeças",
      preco: 750.0,
      desconto: 0,
    },
    {
      id: 9,
      descricao: "Um braço com uma hélice -- bom para propulsão ou como ventilador.",
      nome: "Braço com Hélice",
      nomeImagem: "arm-propeller.png",
      categoria: "Braços",
      preco: 230,
      desconto: 0.1,
    },
    {
      id: 15,
      descricao: "Uma base de foguete capaz de voo controlado em alta velocidade.",
      nome: "Base de Foguete",
      nomeImagem: "base-rocket.png",
      categoria: "Bases",
      preco: 1520.5,
      desconto: 0,
    },
    {
      id: 10,
      descricao: "Um braço curto e atarracado com uma garra -- simples, mas barato.",
      nome: "Braço Atarracado com Garra",
      nomeImagem: "arm-stubby-claw.png",
      categoria: "Braços",
      preco: 125,
      desconto: 0,
    },
    {
      id: 11,
      descricao: "Um torso que pode dobrar levemente na cintura e equipado com um medidor de calor.",
      nome: "Torso Flexível com Medidor",
      nomeImagem: "torso-flexible-gauged.png",
      categoria: "Torsos",
      preco: 1575,
      desconto: 0,
    },
    {
      id: 14,
      descricao: "Uma base com duas rodas e acelerômetro para estabilidade.",
      nome: "Base de Duas Rodas",
      nomeImagem: "base-double-wheel.png",
      categoria: "Bases",
      preco: 895,
      desconto: 0,
    },
    {
      id: 5,
      descricao: "Uma cabeça de robô com três olhos oscilantes -- excelente para vigilância.",
      nome: "Vigilância",
      nomeImagem: "head-surveillance.png",
      categoria: "Cabeças",
      preco: 1255.5,
      desconto: 0,
    },
    {
      id: 8,
      descricao: "Um braço telescópico com uma pinça.",
      nome: "Braço com Pinça",
      nomeImagem: "arm-grabber.png",
      categoria: "Braços",
      preco: 205.5,
      desconto: 0,
    },
    {
      id: 12,
      descricao: "Um torso menos flexível com um medidor de bateria.",
      nome: "Torso com Medidor",
      nomeImagem: "torso-gauged.png",
      categoria: "Torsos",
      preco: 1385,
      desconto: 0,
    },
    {
      id: 18,
      descricao: "Uma base barata com três rodas, capaz apenas de velocidades lentas e que só funciona em superfícies lisas.",
      nome: "Base de Três Rodas",
      nomeImagem: "base-triple-wheel.png",
      categoria: "Bases",
      preco: 700.5,
      desconto: 0,
    },
  ];
  res.send(produtos);
});

app.post("/api/carrinho", (req, res) => {
  carrinho = req.body;
  setTimeout(() => res.status(201).send(), 20);
});

app.get("/api/carrinho", (req, res) => {
  res.send(carrinho)
});

app.post("/api/register", (req, res) => {
  setTimeout(() => {
    const user = req.body;
    if (user.primeiroNome && user.ultimoNome && user.email && user.senha) {
      usuarios[user.email] = user;
      res.status(201).send({
        primeiroNome: user.primeiroNome,
        ultimoNome: user.ultimoNome,
        email: user.email,
      });
    } else {
      res.status(500).send("Invalid user info");
    }
  }, 800)
});

/* 
    IMPORTANTE:
    O código abaixo é apenas para fins de demonstração e não representa boas práticas de segurança.
    Em uma aplicação de produção, as credenciais do usuário seriam armazenadas criptograficamente
    em um servidor de banco de dados e a senha NUNCA deve ser armazenada como texto simples.
*/
app.post("/api/login", (req, res) => {
  const usuario = usuarios[req.body.email];
  if (usuario && usuario.senha === req.body.senha) {
    res.status(200).send({
      usuarioId: usuario.usuarioId,
      primeiroNome: usuario.primeiroNome,
      ultimoNome: usuario.ultimoNome,
      email: usuario.email,
    });
  } else {
    res.status(401).send("Credenciais de usuário inválidas.");
  }
});

app.listen(8081, () => console.log("Servidor da API ouvindo na porta 8081!"));
