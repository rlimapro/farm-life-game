<p align="center">
  <img src="https://i.ibb.co/N684vg82/title.png" width="360" alt="Farm Life Logo" />
</p>

<p align="center">
  Cultive, colha e evolua em um simulador de fazenda casual e relaxante em 2D.
</p>

<p align="center">
  <img src="https://img.shields.io/badge/Unity-6-000000?style=flat-square&logo=unity&logoColor=white" alt="Unity 6" />
  <img src="https://img.shields.io/badge/C%23-239120?style=flat-square&logo=csharp&logoColor=white" alt="C#" />
  <img src="https://img.shields.io/badge/Pixel%20Art-16--bit-FF4500?style=flat-square" alt="Pixel Art" />
  <img src="https://img.shields.io/badge/Status-Em%20Desenvolvimento-yellow?style=flat-square" alt="Status" />
</p>

--------------------------------------

## 📖 Sobre o Projeto

**Farm Life** é um simulador de fazenda casual em 2D com perspectiva *top-down*, desenvolvido em Pixel Art 16-bit. O jogo foi idealizado para entusiastas de "Cozy Games" e foca em uma experiência relaxante, não violenta e de ritmo cadenciado.

No jogo, você assume o papel de um ex-engenheiro de software que decidiu abandonar a rotina exaustiva dos grandes centros urbanos e dar um "commit final" em sua carreira corporativa. Ao investir suas economias em uma propriedade rural simples, seu objetivo é revitalizar as terras e buscar a prosperidade através do manejo focado no loop clássico e altamente satisfatório de **"plantar, vender e evoluir"**.

---

## ✨ Mecânicas e Funcionalidades

- [x] **Movimentação em Grid** — Controle do personagem em 4 direções com precisão baseada em grid e indicador visual de alvo (*targeter*).
- [x] **Loop de Cultivo Completo** — Sistema prático para arar a terra, plantar sementes, regar diariamente e colher.
- [x] **Ciclo de Dia e Noite (Sono)** — As plantas processam o crescimento e a variação natural após o jogador ir dormir na cama.
- [x] **Economia Integrada** — Interface de Loja (Shop) para converter sua colheita em moedas de Ouro ($) e comprar novos insumos.
- [x] **Inventário Rápido** — Barra de acesso rápido (Hotbar) para alternar dinamicamente entre ferramentas e sementes usando teclado ou mouse.
- [x] **Persistência de Dados** — Salvamento automático do progresso do grid, dinheiro e inventário ao trocar de cena ou dormir.

---

## 🖼️ Screenshots

> ⚠️ **Nota:** O jogo encontra-se atualmente em fase de desenvolvimento. Capturas de tela da gameplay, menus e sistemas visuais serão adicionadas em breve!

---

## 🏗️ Estrutura Técnica e Assets

O jogo utiliza os recursos nativos do ecossistema Unity para garantir performance em jogos 2D.

| Componente | Implementação / Tecnologia |
|---|---|
| **Engine** | Unity (Perspectiva 2D Top-Down) |
| **Linguagem** | C# (Scripts de controle, economia e persistência) |
| **Cenário** | Tilemaps para construção eficiente com estilo Pixel Art 16-bit |
| **Câmera** | Sistema de câmera suave (*Smooth Follow*) confinada aos limites do mapa |
| **Física** | Física 2D simples com detecção de colisão em obstáculos (árvores, cercas, limites) |
| **Interface (UI)** | HUD persistente exibindo Relógio (Tempo/Dia), Contador de Dinheiro e Hotbar |
| **Áudio** | Trilha sonora em loop contínuo e SFX de feedback (rega, arado e colheita) |

---

## 👨‍💻 Desenvolvedor

José Rian Mendes Lima - _Desenvolvimento Geral & Design_

---

## 📄 Licença

Este projeto foi desenvolvido para fins acadêmicos.
