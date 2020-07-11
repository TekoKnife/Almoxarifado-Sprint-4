-- phpMyAdmin SQL Dump
-- version 5.0.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Tempo de geração: 10-Jul-2020 às 01:20
-- Versão do servidor: 10.4.11-MariaDB
-- versão do PHP: 7.4.3

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Banco de dados: `contrato`
--
CREATE DATABASE IF NOT EXISTS `contrato` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci;
USE `contrato`;

-- --------------------------------------------------------

--
-- Estrutura da tabela `almoxarifados`
--

CREATE TABLE `almoxarifados` (
  `Codigo` int(11) NOT NULL,
  `Produto` varchar(30) NOT NULL,
  `Quantidade` varchar(30) NOT NULL,
  `createAt` timestamp NOT NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COMMENT='{\r\n  "validation": {\r\n    "id": "",\r\n    "nome": "NotEmpty",\r\n    "sobrenome": "NotEmpty",\r\n    "email": "Email",\r\n    "celular": "Phone",\r\n    "cnpj": "NotEmpty",\r\n    "createat": "",\r\n    "codigo": "",\r\n    "produto": "NotEmpty",\r\n    "quantidade": "NotEmpty"\r\n  },\r\n  "required": []\r\n}';

--
-- Extraindo dados da tabela `almoxarifados`
--

INSERT INTO `almoxarifados` (`Codigo`, `Produto`, `Quantidade`, `createAt`) VALUES
(1, 'Agua', '150', '2020-07-09 23:11:29'),
(2, 'Maça', '50', '2020-07-09 23:12:42');

-- --------------------------------------------------------

--
-- Estrutura da tabela `contatos`
--

CREATE TABLE `contatos` (
  `ID` int(11) NOT NULL,
  `Nome` varchar(50) NOT NULL,
  `Sobrenome` text NOT NULL,
  `Email` text NOT NULL,
  `Celular` varchar(15) NOT NULL,
  `CNPJ` varchar(15) NOT NULL,
  `createAt` timestamp NOT NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COMMENT='{\r\n  "validation": {\r\n    "id": "",\r\n    "nome": "NotEmpty",\r\n    "sobrenome": "NotEmpty",\r\n    "email": "Email",\r\n    "celular": "Phone",\r\n    "cnpj": "NotEmpty",\r\n    "createat": ""\r\n  },\r\n  "required": []\r\n}';

--
-- Extraindo dados da tabela `contatos`
--

INSERT INTO `contatos` (`ID`, `Nome`, `Sobrenome`, `Email`, `Celular`, `CNPJ`, `createAt`) VALUES
(9, 'Julio', 'Gaher', 'JulioGaher@gmail.com', '32813387213', '36721376123671', '2020-07-08 19:20:47'),
(10, 'Gabriel', 'Henrique', 'gh@gmail.com', '43247384327', '48323274387487', '2020-07-09 17:38:59'),
(11, 'Henrique', 'Joao', 'su@gmail.com', '32873871238', '32617217632176', '2020-07-09 18:12:42'),
(12, 'ewqewewq', 'ewqeqwewqe', 'wed@gmail.com', '32132131231', '32132321321312', '2020-07-09 22:51:20');

--
-- Índices para tabelas despejadas
--

--
-- Índices para tabela `almoxarifados`
--
ALTER TABLE `almoxarifados`
  ADD PRIMARY KEY (`Codigo`);

--
-- Índices para tabela `contatos`
--
ALTER TABLE `contatos`
  ADD PRIMARY KEY (`ID`);

--
-- AUTO_INCREMENT de tabelas despejadas
--

--
-- AUTO_INCREMENT de tabela `almoxarifados`
--
ALTER TABLE `almoxarifados`
  MODIFY `Codigo` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT de tabela `contatos`
--
ALTER TABLE `contatos`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=13;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
