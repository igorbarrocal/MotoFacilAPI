# 📄 IDEIA DO PROJETO - CP2 - ADVANCED BUSINESS DEVELOPMENT WITH .NET
Criar uma API RESTful em .NET 8 com foco em cadastro e login de usuários, utilizando autenticação segura e arquitetura limpa, que será a base do sistema da Mottu para gestão de motos em pátios.
## 👥 INTEGRANTES DO GRUPO

- RM558238 - Cauan da Cruz Ferreira
- RM555217 - Igor Dias Barrocal  
- RM557820 - Renan Dorneles

---

## 📘 TÍTULO DO PROJETO  
**Sistema de Mapeamento Inteligente de Motos no Pátio – Filial São Paulo**

---

## 🎯 PROBLEMA A SER RESOLVIDO

A Mottu precisa saber com precisão onde cada moto está posicionada em seus pátios espalhados pelo Brasil e México. O processo atual de registro e localização é feito de forma manual, sujeita a erros e inconsistências. Isso impacta diretamente na agilidade da operação, causando atrasos na entrega das motos e dificultando o controle e a auditoria do fluxo de veículos.

---

## 💡 SOLUÇÃO PROPOSTA

Desenvolveremos uma aplicação robusta baseada na **API MotoFacilAPI** para registrar, atualizar e consultar a localização de motos nos pátios da Mottu.

O sistema permitirá:

- Cadastro de usuários com login e autenticação segura  
- Registro de motos com dados como placa, modelo, cor e status  
- Associação da moto a uma posição exata dentro do pátio  
- Visualização da planta do pátio com mapa interativo  
- Filtragem e busca de motos por chassi, placa ou zona  
- Geração de relatórios operacionais  

A solução ainda prevê integração futura com sensores ESP32 para mapeamento físico do pátio em tempo real e visão computacional para leitura automática de placas.

---

## 📐 ENTIDADES PRINCIPAIS

- **Usuário**: dados de autenticação e controle de acesso  
- **Moto**: placa, modelo, cor, status, localização atual  
- **Pátio**: nome da filial, dimensões, zonas mapeadas  
- **Zona**: subdivisão interna do pátio (ex: A, B, C)  
- **Localização**: coordenadas reais e virtuais no mapa  

---

## 🛠 TECNOLOGIAS E ESTRUTURA

- .NET 8  
- EF Core com banco Oracle  
- Swagger para documentação  
- Clean Architecture  
- DTOs, MappingConfig e Migrations  
- Autenticação com JWT  
- Projeto base: [github.com/igorbarrocal/MotoFacilAPI](https://github.com/igorbarrocal/MotoFacilAPI)

---

## 📌 OBSERVAÇÕES FINAIS

Este projeto representa um módulo estratégico dentro da transformação digital da Mottu, otimizando o controle de suas operações logísticas. A arquitetura adotada garante flexibilidade para evoluções futuras como:

- Controle de acesso por perfis  
- Histórico de localização da moto  
- Integração com ESP32 e visão computacional  

Nosso objetivo é entregar um backend pronto para produção, com documentação clara e padrões profissionais de desenvolvimento.
