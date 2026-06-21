-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Tempo de geração: 18-Jun-2026 às 14:19
-- Versão do servidor: 10.4.32-MariaDB
-- versão do PHP: 8.0.30

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Banco de dados: `cooperativa_agricola`
--

DELIMITER $$
--
-- Procedimentos
--
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_distribuir_lucros` (IN `p_comercializacao_id` INT)   BEGIN
    DECLARE v_total_lucro DECIMAL(14,2);

    -- Soma total apurado de todas as entregas desta comercialização
    SELECT SUM(e.quantidade * pc.preco_unitario)
    INTO v_total_lucro
    FROM comercializacao_entregas ce
    JOIN entregas e ON e.id = ce.entrega_id
    JOIN precos_comercializacao pc
         ON pc.produto_id = e.produto_id AND pc.epoca_id = e.epoca_id
    WHERE ce.comercializacao_id = p_comercializacao_id;

    -- Para cada cooperativista que entregou nesta comercialização, calcular apurado e lucro
    INSERT INTO distribuicoes_lucro
        (cooperativista_id, comercializacao_id, valor_apurado, valor_lucro, quota_aplicada, data_distribuicao)
    SELECT
        c.id,
        p_comercializacao_id,
        SUM(e.quantidade * pc.preco_unitario)          AS valor_apurado,
        (SUM(e.quantidade * pc.preco_unitario)
            * c.quota_percent / 100)                   AS valor_lucro,
        c.quota_percent,
        CURDATE()
    FROM comercializacao_entregas ce
    JOIN entregas e ON e.id = ce.entrega_id
    JOIN cooperativistas c ON c.id = e.cooperativista_id
    JOIN precos_comercializacao pc
         ON pc.produto_id = e.produto_id AND pc.epoca_id = e.epoca_id
    WHERE ce.comercializacao_id = p_comercializacao_id
    GROUP BY c.id, c.quota_percent
    ON DUPLICATE KEY UPDATE
        valor_apurado  = VALUES(valor_apurado),
        valor_lucro    = VALUES(valor_lucro),
        quota_aplicada = VALUES(quota_aplicada);
END$$

DELIMITER ;

-- --------------------------------------------------------

--
-- Estrutura da tabela `categorias_produto`
--

CREATE TABLE `categorias_produto` (
  `id` int(11) NOT NULL,
  `nome` varchar(80) NOT NULL,
  `descricao` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Extraindo dados da tabela `categorias_produto`
--

INSERT INTO `categorias_produto` (`id`, `nome`, `descricao`) VALUES
(1, 'Cereais', 'Milho, feijão, trigo e outros cereais'),
(2, 'Tubérculos', 'Mandioca, batata-doce, inhame'),
(3, 'Hortícolas', 'Tomate, couve, cenoura, alho'),
(4, 'Oleaginosas', 'Amendoim, girassol'),
(5, 'Frutas', 'Manga, banana, laranja, maracujá');

-- --------------------------------------------------------

--
-- Estrutura da tabela `comercializacao_entregas`
--

CREATE TABLE `comercializacao_entregas` (
  `comercializacao_id` int(11) NOT NULL,
  `entrega_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci COMMENT='Entregas incluídas em cada comercialização';

--
-- Extraindo dados da tabela `comercializacao_entregas`
--

INSERT INTO `comercializacao_entregas` (`comercializacao_id`, `entrega_id`) VALUES
(1, 1),
(1, 2),
(1, 3),
(1, 4),
(1, 5),
(1, 6),
(1, 7),
(1, 8),
(1, 9),
(1, 10);

-- --------------------------------------------------------

--
-- Estrutura da tabela `comercializacoes`
--

CREATE TABLE `comercializacoes` (
  `id` int(11) NOT NULL,
  `epoca_id` int(11) NOT NULL,
  `data_venda` date NOT NULL,
  `descricao` varchar(255) DEFAULT NULL,
  `total_apurado` decimal(14,2) GENERATED ALWAYS AS (NULL) VIRTUAL COMMENT 'Calculado pela aplicação via view/stored procedure',
  `created_at` datetime NOT NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci COMMENT='Operações de comercialização de produtos no mercado';

--
-- Extraindo dados da tabela `comercializacoes`
--

INSERT INTO `comercializacoes` (`id`, `epoca_id`, `data_venda`, `descricao`, `created_at`) VALUES
(1, 1, '2025-01-15', 'Comercialização principal - Época Chuvas 2024', '2026-06-06 22:35:22');

-- --------------------------------------------------------

--
-- Estrutura da tabela `cooperativistas`
--

CREATE TABLE `cooperativistas` (
  `id` int(11) NOT NULL,
  `nome` varchar(120) NOT NULL,
  `numero_socio` varchar(20) NOT NULL,
  `bilhete_id` varchar(30) NOT NULL,
  `telefone` varchar(20) DEFAULT NULL,
  `email` varchar(100) DEFAULT NULL,
  `quota_percent` decimal(5,2) NOT NULL COMMENT 'Percentagem de participação (soma de todos deve ser 100)',
  `data_adesao` date NOT NULL,
  `activo` tinyint(1) NOT NULL DEFAULT 1,
  `created_at` datetime NOT NULL DEFAULT current_timestamp(),
  `updated_at` datetime NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp()
) ;

--
-- Extraindo dados da tabela `cooperativistas`
--

INSERT INTO `cooperativistas` (`id`, `nome`, `numero_socio`, `bilhete_id`, `telefone`, `email`, `quota_percent`, `data_adesao`, `activo`, `created_at`, `updated_at`) VALUES
(1, 'António Mateus Lopes', 'COOP-001', 'BI001234', '923111001', 'antonio@exemplo.ao', 25.00, '2022-01-15', 1, '2026-06-06 22:33:15', '2026-06-06 22:33:15'),
(2, 'Maria das Graças Silva', 'COOP-002', 'BI001235', '923111002', 'maria@exemplo.ao', 20.00, '2022-01-15', 1, '2026-06-06 22:33:15', '2026-06-06 22:33:15'),
(3, 'Pedro Augusto Mbemba', 'COOP-003', 'BI001236', '923111003', 'pedro@exemplo.ao', 20.00, '2022-02-01', 1, '2026-06-06 22:33:15', '2026-06-06 22:33:15'),
(4, 'Rosa Esperança Teca', 'COOP-004', 'BI001237', '923111004', 'rosa@exemplo.ao', 15.00, '2022-02-10', 1, '2026-06-06 22:33:15', '2026-06-06 22:33:15'),
(5, 'Domingos Luvualu Neto', 'COOP-005', 'BI001238', '923111005', 'domingos@exemplo.ao', 10.00, '2022-03-05', 1, '2026-06-06 22:33:15', '2026-06-06 22:33:15'),
(6, 'Filomena Pinto Kassoma', 'COOP-006', 'BI001239', '923111006', 'filomena@exemplo.ao', 10.00, '2022-03-20', 1, '2026-06-06 22:33:15', '2026-06-06 22:33:15');

-- --------------------------------------------------------

--
-- Estrutura da tabela `distribuicoes_lucro`
--

CREATE TABLE `distribuicoes_lucro` (
  `id` int(11) NOT NULL,
  `cooperativista_id` int(11) NOT NULL,
  `comercializacao_id` int(11) NOT NULL,
  `valor_apurado` decimal(14,2) NOT NULL COMMENT 'Valor total apurado pelo cooperativista nesta comercialização',
  `valor_lucro` decimal(14,2) NOT NULL COMMENT 'Valor do lucro proporcional à quota',
  `quota_aplicada` decimal(5,2) NOT NULL COMMENT 'Snapshot da quota no momento da distribuição',
  `data_distribuicao` date NOT NULL DEFAULT curdate(),
  `created_at` datetime NOT NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci COMMENT='Distribuição de lucros por cooperativista por comercialização';

--
-- Extraindo dados da tabela `distribuicoes_lucro`
--

INSERT INTO `distribuicoes_lucro` (`id`, `cooperativista_id`, `comercializacao_id`, `valor_apurado`, `valor_lucro`, `quota_aplicada`, `data_distribuicao`, `created_at`) VALUES
(1, 1, 1, 131000.00, 32750.00, 25.00, '2025-01-20', '2026-06-06 22:35:32'),
(2, 2, 1, 114000.00, 22800.00, 20.00, '2025-01-20', '2026-06-06 22:35:32'),
(3, 3, 1, 105000.00, 21000.00, 20.00, '2025-01-20', '2026-06-06 22:35:32'),
(4, 4, 1, 97500.00, 14625.00, 15.00, '2025-01-20', '2026-06-06 22:35:32'),
(5, 5, 1, 50400.00, 5040.00, 10.00, '2025-01-20', '2026-06-06 22:35:32'),
(6, 6, 1, 42000.00, 4200.00, 10.00, '2025-01-20', '2026-06-06 22:35:32');

-- --------------------------------------------------------

--
-- Estrutura da tabela `entregas`
--

CREATE TABLE `entregas` (
  `id` int(11) NOT NULL,
  `cooperativista_id` int(11) NOT NULL,
  `produto_id` int(11) NOT NULL,
  `epoca_id` int(11) NOT NULL,
  `data_entrega` date NOT NULL,
  `quantidade` decimal(12,3) NOT NULL COMMENT 'Quantidade na unidade de medida do produto',
  `observacoes` varchar(500) DEFAULT NULL,
  `created_at` datetime NOT NULL DEFAULT current_timestamp()
) ;

--
-- Extraindo dados da tabela `entregas`
--

INSERT INTO `entregas` (`id`, `cooperativista_id`, `produto_id`, `epoca_id`, `data_entrega`, `quantidade`, `observacoes`, `created_at`) VALUES
(1, 1, 1, 1, '2024-11-10', 500.000, NULL, '2026-06-06 22:35:14'),
(2, 1, 2, 1, '2024-11-15', 200.000, NULL, '2026-06-06 22:35:14'),
(3, 2, 1, 1, '2024-11-12', 400.000, NULL, '2026-06-06 22:35:14'),
(4, 2, 3, 1, '2024-11-20', 600.000, NULL, '2026-06-06 22:35:14'),
(5, 3, 1, 1, '2024-11-10', 350.000, NULL, '2026-06-06 22:35:14'),
(6, 3, 5, 1, '2024-11-25', 150.000, NULL, '2026-06-06 22:35:14'),
(7, 4, 4, 1, '2024-12-01', 300.000, NULL, '2026-06-06 22:35:14'),
(8, 4, 1, 1, '2024-12-05', 250.000, NULL, '2026-06-06 22:35:14'),
(9, 5, 2, 1, '2024-11-18', 180.000, NULL, '2026-06-06 22:35:14'),
(10, 6, 5, 1, '2024-11-30', 120.000, NULL, '2026-06-06 22:35:14');

-- --------------------------------------------------------

--
-- Estrutura da tabela `epocas_agricolas`
--

CREATE TABLE `epocas_agricolas` (
  `id` int(11) NOT NULL,
  `nome` varchar(80) NOT NULL,
  `tipo` enum('Chuvas','Seca') NOT NULL,
  `ano` year(4) NOT NULL,
  `data_inicio` date NOT NULL,
  `data_fim` date NOT NULL,
  `encerrada` tinyint(1) NOT NULL DEFAULT 0,
  `created_at` datetime NOT NULL DEFAULT current_timestamp()
) ;

--
-- Extraindo dados da tabela `epocas_agricolas`
--

INSERT INTO `epocas_agricolas` (`id`, `nome`, `tipo`, `ano`, `data_inicio`, `data_fim`, `encerrada`, `created_at`) VALUES
(1, 'Época das Chuvas 2024', 'Chuvas', '2024', '2024-10-01', '2025-03-31', 1, '2026-06-06 22:33:39'),
(2, 'Época da Seca 2025', 'Seca', '2025', '2025-04-01', '2025-09-30', 0, '2026-06-06 22:33:39'),
(3, 'Época das Chuvas 2024', 'Chuvas', '2024', '2024-10-01', '2025-03-31', 1, '2026-06-06 22:34:54'),
(4, 'Época da Seca 2025', 'Seca', '2025', '2025-04-01', '2025-09-30', 0, '2026-06-06 22:34:54');

-- --------------------------------------------------------

--
-- Estrutura da tabela `precos_comercializacao`
--

CREATE TABLE `precos_comercializacao` (
  `id` int(11) NOT NULL,
  `produto_id` int(11) NOT NULL,
  `epoca_id` int(11) NOT NULL,
  `preco_unitario` decimal(10,2) NOT NULL COMMENT 'Preço por unidade de medida (AOA)',
  `data_definicao` date NOT NULL DEFAULT curdate()
) ;

--
-- Extraindo dados da tabela `precos_comercializacao`
--

INSERT INTO `precos_comercializacao` (`id`, `produto_id`, `epoca_id`, `preco_unitario`, `data_definicao`) VALUES
(1, 1, 1, 150.00, '2024-10-05'),
(2, 2, 1, 280.00, '2024-10-05'),
(3, 3, 1, 90.00, '2024-10-05'),
(4, 4, 1, 200.00, '2024-10-05'),
(5, 5, 1, 350.00, '2024-10-05'),
(6, 1, 2, 180.00, '2025-04-03'),
(7, 2, 2, 320.00, '2025-04-03'),
(8, 3, 2, 110.00, '2025-04-03'),
(9, 5, 2, 400.00, '2025-04-03');

-- --------------------------------------------------------

--
-- Estrutura da tabela `produtos_agricolas`
--

CREATE TABLE `produtos_agricolas` (
  `id` int(11) NOT NULL,
  `codigo` varchar(20) NOT NULL,
  `nome` varchar(120) NOT NULL,
  `unidade_medida` varchar(20) NOT NULL COMMENT 'kg, litro, saco, caixa…',
  `categoria_id` int(11) NOT NULL,
  `descricao` varchar(255) DEFAULT NULL,
  `activo` tinyint(1) NOT NULL DEFAULT 1,
  `created_at` datetime NOT NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci COMMENT='Produtos agrícolas que a cooperativa gere';

--
-- Extraindo dados da tabela `produtos_agricolas`
--

INSERT INTO `produtos_agricolas` (`id`, `codigo`, `nome`, `unidade_medida`, `categoria_id`, `descricao`, `activo`, `created_at`) VALUES
(1, 'PROD-001', 'Milho', 'kg', 1, NULL, 1, '2026-06-06 22:33:28'),
(2, 'PROD-002', 'Feijão Frade', 'kg', 1, NULL, 1, '2026-06-06 22:33:28'),
(3, 'PROD-003', 'Mandioca', 'kg', 2, NULL, 1, '2026-06-06 22:33:28'),
(4, 'PROD-004', 'Tomate', 'kg', 3, NULL, 1, '2026-06-06 22:33:28'),
(5, 'PROD-005', 'Amendoim', 'kg', 4, NULL, 1, '2026-06-06 22:33:28'),
(6, 'PROD-006', 'Banana', 'cacho', 5, NULL, 1, '2026-06-06 22:33:28');

-- --------------------------------------------------------

--
-- Estrutura da tabela `utilizadores`
--

CREATE TABLE `utilizadores` (
  `id` int(11) NOT NULL,
  `nome` varchar(100) NOT NULL,
  `username` varchar(50) NOT NULL,
  `password` varchar(255) NOT NULL,
  `perfil` enum('Admin','Operador') NOT NULL DEFAULT 'Operador',
  `ativo` tinyint(1) NOT NULL DEFAULT 1,
  `created_at` datetime NOT NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Extraindo dados da tabela `utilizadores`
--

INSERT INTO `utilizadores` (`id`, `nome`, `username`, `password`, `perfil`, `ativo`, `created_at`) VALUES
(1, 'Administrador', 'admin', 'admin123', 'Admin', 1, '2026-06-07 07:55:35'),
(2, 'Operador', 'operador', 'admin123', 'Operador', 1, '2026-06-07 07:55:35'),
(3, 'Eu', 'eu', 'admin123', 'Admin', 1, '2026-06-07 07:55:35');

-- --------------------------------------------------------

--
-- Estrutura stand-in para vista `vw_apuramento_por_cooperativista`
-- (Veja abaixo para a view atual)
--
CREATE TABLE `vw_apuramento_por_cooperativista` (
`cooperativista_id` int(11)
,`cooperativista` varchar(120)
,`numero_socio` varchar(20)
,`quota_percent` decimal(5,2)
,`epoca_id` int(11)
,`epoca` varchar(80)
,`tipo_epoca` enum('Chuvas','Seca')
,`ano` year(4)
,`valor_total_apurado` decimal(44,5)
);

-- --------------------------------------------------------

--
-- Estrutura stand-in para vista `vw_entregas_resumo`
-- (Veja abaixo para a view atual)
--
CREATE TABLE `vw_entregas_resumo` (
`entrega_id` int(11)
,`cooperativista` varchar(120)
,`numero_socio` varchar(20)
,`quota_percent` decimal(5,2)
,`produto_codigo` varchar(20)
,`produto` varchar(120)
,`unidade_medida` varchar(20)
,`epoca` varchar(80)
,`tipo_epoca` enum('Chuvas','Seca')
,`ano` year(4)
,`data_entrega` date
,`quantidade` decimal(12,3)
,`preco_unitario` decimal(10,2)
,`valor_entrega` decimal(22,5)
);

-- --------------------------------------------------------

--
-- Estrutura stand-in para vista `vw_relatorio_lucros`
-- (Veja abaixo para a view atual)
--
CREATE TABLE `vw_relatorio_lucros` (
`distribuicao_id` int(11)
,`cooperativista` varchar(120)
,`numero_socio` varchar(20)
,`quota_aplicada` decimal(5,2)
,`data_venda` date
,`epoca` varchar(80)
,`tipo_epoca` enum('Chuvas','Seca')
,`valor_apurado` decimal(14,2)
,`valor_lucro` decimal(14,2)
,`data_distribuicao` date
);

-- --------------------------------------------------------

--
-- Estrutura para vista `vw_apuramento_por_cooperativista`
--
DROP TABLE IF EXISTS `vw_apuramento_por_cooperativista`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `vw_apuramento_por_cooperativista`  AS SELECT `c`.`id` AS `cooperativista_id`, `c`.`nome` AS `cooperativista`, `c`.`numero_socio` AS `numero_socio`, `c`.`quota_percent` AS `quota_percent`, `ea`.`id` AS `epoca_id`, `ea`.`nome` AS `epoca`, `ea`.`tipo` AS `tipo_epoca`, `ea`.`ano` AS `ano`, sum(`e`.`quantidade` * `pc`.`preco_unitario`) AS `valor_total_apurado` FROM (((`entregas` `e` join `cooperativistas` `c` on(`c`.`id` = `e`.`cooperativista_id`)) join `epocas_agricolas` `ea` on(`ea`.`id` = `e`.`epoca_id`)) join `precos_comercializacao` `pc` on(`pc`.`produto_id` = `e`.`produto_id` and `pc`.`epoca_id` = `e`.`epoca_id`)) GROUP BY `c`.`id`, `c`.`nome`, `c`.`numero_socio`, `c`.`quota_percent`, `ea`.`id`, `ea`.`nome`, `ea`.`tipo`, `ea`.`ano` ;

-- --------------------------------------------------------

--
-- Estrutura para vista `vw_entregas_resumo`
--
DROP TABLE IF EXISTS `vw_entregas_resumo`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `vw_entregas_resumo`  AS SELECT `e`.`id` AS `entrega_id`, `c`.`nome` AS `cooperativista`, `c`.`numero_socio` AS `numero_socio`, `c`.`quota_percent` AS `quota_percent`, `p`.`codigo` AS `produto_codigo`, `p`.`nome` AS `produto`, `p`.`unidade_medida` AS `unidade_medida`, `ea`.`nome` AS `epoca`, `ea`.`tipo` AS `tipo_epoca`, `ea`.`ano` AS `ano`, `e`.`data_entrega` AS `data_entrega`, `e`.`quantidade` AS `quantidade`, `pc`.`preco_unitario` AS `preco_unitario`, `e`.`quantidade`* `pc`.`preco_unitario` AS `valor_entrega` FROM ((((`entregas` `e` join `cooperativistas` `c` on(`c`.`id` = `e`.`cooperativista_id`)) join `produtos_agricolas` `p` on(`p`.`id` = `e`.`produto_id`)) join `epocas_agricolas` `ea` on(`ea`.`id` = `e`.`epoca_id`)) left join `precos_comercializacao` `pc` on(`pc`.`produto_id` = `e`.`produto_id` and `pc`.`epoca_id` = `e`.`epoca_id`)) ;

-- --------------------------------------------------------

--
-- Estrutura para vista `vw_relatorio_lucros`
--
DROP TABLE IF EXISTS `vw_relatorio_lucros`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `vw_relatorio_lucros`  AS SELECT `dl`.`id` AS `distribuicao_id`, `c`.`nome` AS `cooperativista`, `c`.`numero_socio` AS `numero_socio`, `dl`.`quota_aplicada` AS `quota_aplicada`, `com`.`data_venda` AS `data_venda`, `ea`.`nome` AS `epoca`, `ea`.`tipo` AS `tipo_epoca`, `dl`.`valor_apurado` AS `valor_apurado`, `dl`.`valor_lucro` AS `valor_lucro`, `dl`.`data_distribuicao` AS `data_distribuicao` FROM (((`distribuicoes_lucro` `dl` join `cooperativistas` `c` on(`c`.`id` = `dl`.`cooperativista_id`)) join `comercializacoes` `com` on(`com`.`id` = `dl`.`comercializacao_id`)) join `epocas_agricolas` `ea` on(`ea`.`id` = `com`.`epoca_id`)) ;

--
-- Índices para tabelas despejadas
--

--
-- Índices para tabela `categorias_produto`
--
ALTER TABLE `categorias_produto`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `nome` (`nome`);

--
-- Índices para tabela `comercializacao_entregas`
--
ALTER TABLE `comercializacao_entregas`
  ADD PRIMARY KEY (`comercializacao_id`,`entrega_id`),
  ADD KEY `fk_ce_entrega` (`entrega_id`);

--
-- Índices para tabela `comercializacoes`
--
ALTER TABLE `comercializacoes`
  ADD PRIMARY KEY (`id`),
  ADD KEY `fk_comercializacao_epoca` (`epoca_id`);

--
-- Índices para tabela `cooperativistas`
--
ALTER TABLE `cooperativistas`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `numero_socio` (`numero_socio`),
  ADD UNIQUE KEY `bilhete_id` (`bilhete_id`);

--
-- Índices para tabela `distribuicoes_lucro`
--
ALTER TABLE `distribuicoes_lucro`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `uq_dist_coop_com` (`cooperativista_id`,`comercializacao_id`),
  ADD KEY `fk_dist_comercializacao` (`comercializacao_id`);

--
-- Índices para tabela `entregas`
--
ALTER TABLE `entregas`
  ADD PRIMARY KEY (`id`),
  ADD KEY `fk_entrega_cooperativista` (`cooperativista_id`),
  ADD KEY `fk_entrega_produto` (`produto_id`),
  ADD KEY `fk_entrega_epoca` (`epoca_id`);

--
-- Índices para tabela `epocas_agricolas`
--
ALTER TABLE `epocas_agricolas`
  ADD PRIMARY KEY (`id`);

--
-- Índices para tabela `precos_comercializacao`
--
ALTER TABLE `precos_comercializacao`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `uq_preco_produto_epoca` (`produto_id`,`epoca_id`),
  ADD KEY `fk_preco_epoca` (`epoca_id`);

--
-- Índices para tabela `produtos_agricolas`
--
ALTER TABLE `produtos_agricolas`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `codigo` (`codigo`),
  ADD KEY `fk_produto_categoria` (`categoria_id`);

--
-- Índices para tabela `utilizadores`
--
ALTER TABLE `utilizadores`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `username` (`username`);

--
-- AUTO_INCREMENT de tabelas despejadas
--

--
-- AUTO_INCREMENT de tabela `categorias_produto`
--
ALTER TABLE `categorias_produto`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT de tabela `comercializacoes`
--
ALTER TABLE `comercializacoes`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT de tabela `cooperativistas`
--
ALTER TABLE `cooperativistas`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de tabela `distribuicoes_lucro`
--
ALTER TABLE `distribuicoes_lucro`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT de tabela `entregas`
--
ALTER TABLE `entregas`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de tabela `epocas_agricolas`
--
ALTER TABLE `epocas_agricolas`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de tabela `precos_comercializacao`
--
ALTER TABLE `precos_comercializacao`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de tabela `produtos_agricolas`
--
ALTER TABLE `produtos_agricolas`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- AUTO_INCREMENT de tabela `utilizadores`
--
ALTER TABLE `utilizadores`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- Restrições para despejos de tabelas
--

--
-- Limitadores para a tabela `comercializacao_entregas`
--
ALTER TABLE `comercializacao_entregas`
  ADD CONSTRAINT `fk_ce_comercializacao` FOREIGN KEY (`comercializacao_id`) REFERENCES `comercializacoes` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `fk_ce_entrega` FOREIGN KEY (`entrega_id`) REFERENCES `entregas` (`id`) ON UPDATE CASCADE;

--
-- Limitadores para a tabela `comercializacoes`
--
ALTER TABLE `comercializacoes`
  ADD CONSTRAINT `fk_comercializacao_epoca` FOREIGN KEY (`epoca_id`) REFERENCES `epocas_agricolas` (`id`) ON UPDATE CASCADE;

--
-- Limitadores para a tabela `distribuicoes_lucro`
--
ALTER TABLE `distribuicoes_lucro`
  ADD CONSTRAINT `fk_dist_comercializacao` FOREIGN KEY (`comercializacao_id`) REFERENCES `comercializacoes` (`id`) ON UPDATE CASCADE,
  ADD CONSTRAINT `fk_dist_cooperativista` FOREIGN KEY (`cooperativista_id`) REFERENCES `cooperativistas` (`id`) ON UPDATE CASCADE;

--
-- Limitadores para a tabela `entregas`
--
ALTER TABLE `entregas`
  ADD CONSTRAINT `fk_entrega_cooperativista` FOREIGN KEY (`cooperativista_id`) REFERENCES `cooperativistas` (`id`) ON UPDATE CASCADE,
  ADD CONSTRAINT `fk_entrega_epoca` FOREIGN KEY (`epoca_id`) REFERENCES `epocas_agricolas` (`id`) ON UPDATE CASCADE,
  ADD CONSTRAINT `fk_entrega_produto` FOREIGN KEY (`produto_id`) REFERENCES `produtos_agricolas` (`id`) ON UPDATE CASCADE;

--
-- Limitadores para a tabela `precos_comercializacao`
--
ALTER TABLE `precos_comercializacao`
  ADD CONSTRAINT `fk_preco_epoca` FOREIGN KEY (`epoca_id`) REFERENCES `epocas_agricolas` (`id`) ON UPDATE CASCADE,
  ADD CONSTRAINT `fk_preco_produto` FOREIGN KEY (`produto_id`) REFERENCES `produtos_agricolas` (`id`) ON UPDATE CASCADE;

--
-- Limitadores para a tabela `produtos_agricolas`
--
ALTER TABLE `produtos_agricolas`
  ADD CONSTRAINT `fk_produto_categoria` FOREIGN KEY (`categoria_id`) REFERENCES `categorias_produto` (`id`) ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
