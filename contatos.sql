-- phpMyAdmin SQL Dump
-- version 5.0.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Tempo de geração: 08-Jul-2020 às 18:56
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
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COMMENT='{\r\n  "validation": {\r\n    "id": "",\r\n    "nome": "",\r\n    "sobrenome": "",\r\n    "email": "",\r\n    "celular": "",\r\n    "cnpj": "",\r\n    "createat": ""\r\n  },\r\n  "required": []\r\n}';

--
-- Extraindo dados da tabela `contatos`
--

INSERT INTO `contatos` (`ID`, `Nome`, `Sobrenome`, `Email`, `Celular`, `CNPJ`, `createAt`) VALUES
(3, 'Frederer', 'Julio', 'fredjulio@gmail.com', '43854843932', '548349823', '2020-06-11 22:33:46'),
(4, 'Julio', 'Gahe', 'dsyaggysda@gmail.com', '4390240923', '4309432493943', '2020-06-11 22:36:38'),
(5, 'Gabriel', 'Henrique', 'gh', '43242343284', '32378123712372', '2020-07-08 16:51:15');

--
-- Índices para tabelas despejadas
--

--
-- Índices para tabela `contatos`
--
ALTER TABLE `contatos`
  ADD PRIMARY KEY (`ID`);

--
-- AUTO_INCREMENT de tabelas despejadas
--

--
-- AUTO_INCREMENT de tabela `contatos`
--
ALTER TABLE `contatos`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
