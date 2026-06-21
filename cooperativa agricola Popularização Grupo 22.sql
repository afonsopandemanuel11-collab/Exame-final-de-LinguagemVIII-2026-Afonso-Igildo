
-- SCRIPT DE POPULARIZAÇÃO DA BASE DE DADOS - cooperativa_agricola

SET FOREIGN_KEY_CHECKS = 0;

TRUNCATE TABLE distribuicoes_lucro;
TRUNCATE TABLE comercializacao_entregas;
TRUNCATE TABLE comercializacoes;
TRUNCATE TABLE entregas;
TRUNCATE TABLE precos_comercializacao;
TRUNCATE TABLE cooperativistas;
TRUNCATE TABLE epocas_agricolas;
TRUNCATE TABLE produtos_agricolas;
TRUNCATE TABLE categorias_produto;

SET FOREIGN_KEY_CHECKS = 1;

INSERT INTO categorias_produto (id, nome, descricao) VALUES
(1, 'Cereais', 'Milho, feijão, trigo e outros cereais'),
(2, 'Tubérculos', 'Mandioca, batata-doce, inhame'),
(3, 'Hortícolas', 'Tomate, couve, cenoura, alho'),
(4, 'Oleaginosas', 'Amendoim, girassol'),
(5, 'Frutas', 'Manga, banana, laranja, maracujá');

INSERT INTO produtos_agricolas (id, codigo, nome, unidade_medida, categoria_id, descricao, activo) VALUES
(1, 'PROD-001', 'Milho', 'kg', 1, 'Milho branco e amarelo', 1),
(2, 'PROD-002', 'Feijão Frade', 'kg', 1, 'Feijão frade seco', 1),
(3, 'PROD-003', 'Mandioca', 'kg', 2, 'Mandioca fresca', 1),
(4, 'PROD-004', 'Tomate', 'kg', 3, 'Tomate de época', 1),
(5, 'PROD-005', 'Amendoim', 'kg', 4, 'Amendoim com casca', 1),
(6, 'PROD-006', 'Banana', 'cacho', 5, 'Banana nanica', 1),
(7, 'PROD-007', 'Batata-doce', 'kg', 2, 'Batata-doce alaranjada', 1),
(8, 'PROD-008', 'Cebola', 'kg', 3, 'Cebola branca', 1);

INSERT INTO cooperativistas (id, nome, numero_socio, bilhete_id, telefone, email, quota_percent, data_adesao, activo) VALUES
(1, 'Emília Francisco António', 'COOP-001', 'BI001001', '923000001', 'emilia@exemplo.ao', 1.50, '2022-01-15', 1),
(2, 'Mateus Carlitos Pinto', 'COOP-002', 'BI001002', '923000002', 'mateus@exemplo.ao', 1.50, '2022-01-15', 1),
(3, 'Luyeye Pedro Lopes', 'COOP-003', 'BI001003', '923000003', 'luyeye@exemplo.ao', 1.50, '2022-01-20', 1),
(4, 'Maurício António Nicolau Nunda', 'COOP-004', 'BI001004', '923000004', 'mauricio@exemplo.ao', 2.00, '2022-01-20', 1),
(5, 'Sílvia Imaculada Mayenga', 'COOP-005', 'BI001005', '923000005', 'silvia@exemplo.ao', 1.50, '2022-02-01', 1),
(6, 'Simão Kanda Pedro', 'COOP-006', 'BI001006', '923000006', 'simao@exemplo.ao', 1.50, '2022-02-01', 1),
(7, 'Celeste Maquiesse Bengui Canga', 'COOP-007', 'BI001007', '923000007', 'celeste@exemplo.ao', 1.50, '2022-02-10', 1),
(8, 'Lukanu Waku Pedro Garcia', 'COOP-008', 'BI001008', '923000008', 'lukanu@exemplo.ao', 1.50, '2022-02-10', 1),
(9, 'Ivete Sofia Afonso Cabuico', 'COOP-009', 'BI001009', '923000009', 'ivete@exemplo.ao', 2.00, '2022-02-15', 1),
(10, 'Ndeka Vicente', 'COOP-010', 'BI001010', '923000010', 'ndeka@exemplo.ao', 1.50, '2022-02-15', 1),
(11, 'Afonso Maconda Mbuta António', 'COOP-011', 'BI001011', '923000011', 'afonso.maconda@exemplo.ao', 1.50, '2022-03-01', 1),
(12, 'Figueiredo Pedro Carlos', 'COOP-012', 'BI001012', '923000012', 'figueiredo@exemplo.ao', 1.50, '2022-03-01', 1),
(13, 'Alberto Médico', 'COOP-013', 'BI001013', '923000013', 'alberto@exemplo.ao', 1.50, '2022-03-10', 1),
(14, 'Filipe Miranda António', 'COOP-014', 'BI001014', '923000014', 'filipe@exemplo.ao', 1.50, '2022-03-10', 1),
(15, 'Adalberto Domingos André', 'COOP-015', 'BI001015', '923000015', 'adalberto@exemplo.ao', 1.50, '2022-03-15', 1),
(16, 'Daniel Kiviokele', 'COOP-016', 'BI001016', '923000016', 'daniel@exemplo.ao', 1.50, '2022-03-15', 1),
(17, 'Ana Lufulakio Muanda', 'COOP-017', 'BI001017', '923000017', 'ana@exemplo.ao', 1.50, '2022-04-01', 1),
(18, 'Celso João André Manuel', 'COOP-018', 'BI001018', '923000018', 'celso@exemplo.ao', 1.50, '2022-04-01', 1),
(19, 'Justino Lucas João', 'COOP-019', 'BI001019', '923000019', 'justino@exemplo.ao', 2.00, '2022-04-10', 1),
(20, 'Vital Salaquiaco João Manuel', 'COOP-020', 'BI001020', '923000020', 'vital@exemplo.ao', 1.50, '2022-04-10', 1),
(21, 'Domingos Vicente Mafila', 'COOP-021', 'BI001021', '923000021', 'domingos.mafila@exemplo.ao', 1.50, '2022-04-15', 1),
(22, 'Matos Martins Ricardo', 'COOP-022', 'BI001022', '923000022', 'matos@exemplo.ao', 1.50, '2022-04-15', 1),
(23, 'Celma Rosa Alfredo Dissungua', 'COOP-023', 'BI001023', '923000023', 'celma@exemplo.ao', 1.50, '2022-05-01', 1),
(24, 'Manuel Inácio Cumbi Mambo', 'COOP-024', 'BI001024', '923000024', 'manuel.cumbi@exemplo.ao', 1.50, '2022-05-01', 1),
(25, 'Armando Manuel Lumano', 'COOP-025', 'BI001025', '923000025', 'armando@exemplo.ao', 1.50, '2022-05-10', 1),
(26, 'Paulo Bunga Nicolau', 'COOP-026', 'BI001026', '923000026', 'paulo@exemplo.ao', 1.50, '2022-05-10', 1),
(27, 'Eugénio Adão Teca', 'COOP-027', 'BI001027', '923000027', 'eugenio@exemplo.ao', 1.50, '2022-05-15', 1),
(28, 'Zacarias Domingos Sebastião', 'COOP-028', 'BI001028', '923000028', 'zacarias@exemplo.ao', 1.50, '2022-05-15', 1),
(29, 'José Estevão Bige Afonso', 'COOP-029', 'BI001029', '923000029', 'jose.estevão@exemplo.ao', 2.00, '2022-06-01', 1),
(30, 'Vangajala Faustino Emanuel', 'COOP-030', 'BI001030', '923000030', 'vangajala@exemplo.ao', 1.50, '2022-06-01', 1),
(31, 'Manuel Lopes Pedro Nicolau', 'COOP-031', 'BI001031', '923000031', 'manuel.lopes@exemplo.ao', 1.50, '2022-06-10', 1),
(32, 'Muanza Dilu Lutonadio', 'COOP-032', 'BI001032', '923000032', 'muanza@exemplo.ao', 1.50, '2022-06-10', 1),
(33, 'Makuzulo da Consolação António João', 'COOP-033', 'BI001033', '923000033', 'makuzulo@exemplo.ao', 1.50, '2022-06-15', 1),
(34, 'Nsukula Domingos Mpangi', 'COOP-034', 'BI001034', '923000034', 'nsukula@exemplo.ao', 1.50, '2022-06-15', 1),
(35, 'José Wazia Augusto', 'COOP-035', 'BI001035', '923000035', 'jose.wazia@exemplo.ao', 1.50, '2022-07-01', 1),
(36, 'Lourenço Nunes Vieira', 'COOP-036', 'BI001036', '923000036', 'lourenco@exemplo.ao', 1.50, '2022-07-01', 1),
(37, 'Dongala Capitão Alberto', 'COOP-037', 'BI001037', '923000037', 'dongala@exemplo.ao', 1.50, '2022-07-10', 1),
(38, 'Sebastião Afonso', 'COOP-038', 'BI001038', '923000038', 'sebastiao@exemplo.ao', 1.50, '2022-07-10', 1),
(39, 'Ângela Igraça Gomes Cotelo', 'COOP-039', 'BI001039', '923000039', 'angela@exemplo.ao', 1.50, '2022-07-15', 1),
(40, 'Guilhermina Lemos David', 'COOP-040', 'BI001040', '923000040', 'guilhermina@exemplo.ao', 1.50, '2022-07-15', 1),
(41, 'Afonso Pande Manuel', 'COOP-041', 'BI001041', '923000041', 'afonso.pande@exemplo.ao', 1.50, '2022-08-01', 1),
(42, 'Igildo Alfredo Mufundo', 'COOP-042', 'BI001042', '923000042', 'igildo@exemplo.ao', 1.50, '2022-08-01', 1),
(43, 'Domingos Paulo Mateus António', 'COOP-043', 'BI001043', '923000043', 'domingos.paulo@exemplo.ao', 2.00, '2022-08-10', 1),
(44, 'Fernando Armando Quirimbo', 'COOP-044', 'BI001044', '923000044', 'fernando@exemplo.ao', 1.50, '2022-08-10', 1),
(45, 'Emanuel Mazunda José Filipe', 'COOP-045', 'BI001045', '923000045', 'emanuel@exemplo.ao', 1.50, '2022-08-15', 1),
(46, 'Nsikivuila Víctor Miloco André', 'COOP-046', 'BI001046', '923000046', 'nsikivuila@exemplo.ao', 1.50, '2022-09-01', 1),
(47, 'Alcides Pedro Veloso António', 'COOP-047', 'BI001047', '923000047', 'alcides@exemplo.ao', 1.50, '2022-09-01', 1),
(48, 'Simões Simão Mateus', 'COOP-048', 'BI001048', '923000048', 'simoes@exemplo.ao', 1.50, '2022-09-10', 1),
(49, 'Augusto Joni Sebastião', 'COOP-049', 'BI001049', '923000049', 'augusto@exemplo.ao', 1.50, '2022-09-10', 1),
(50, 'Henriques Kunietama Miguel Filipe', 'COOP-050', 'BI001050', '923000050', 'henriques@exemplo.ao', 2.00, '2022-09-15', 1),
(51, 'Henriques Gabriel', 'COOP-051', 'BI001051', '923000051', 'henriques.gabriel@exemplo.ao', 1.50, '2022-09-15', 1);

INSERT INTO epocas_agricolas (id, nome, tipo, ano, data_inicio, data_fim, encerrada) VALUES
(1, 'Época das Chuvas 2024/2025', 'Chuvas', '2024', '2024-10-01', '2025-03-31', 1),
(2, 'Época da Seca 2025', 'Seca', '2025', '2025-04-01', '2025-09-30', 0),
(3, 'Época das Chuvas 2025/2026', 'Chuvas', '2025', '2025-10-01', '2026-03-31', 0),
(4, 'Época da Seca 2024', 'Seca', '2024', '2024-04-01', '2024-09-30', 1),
(5, 'Época das Chuvas 2023/2024', 'Chuvas', '2023', '2023-10-01', '2024-03-31', 1);

INSERT INTO precos_comercializacao (produto_id, epoca_id, preco_unitario, data_definicao) VALUES
-- Época 1 (Chuvas 2024/2025)
(1, 1, 150.00, '2024-10-05'),
(2, 1, 280.00, '2024-10-05'),
(3, 1, 120.00, '2024-10-05'),
(4, 1, 90.00, '2024-10-05'),
(5, 1, 350.00, '2024-10-05'),
(6, 1, 180.00, '2024-10-05'),
(7, 1, 110.00, '2024-10-05'),
(8, 1, 95.00, '2024-10-05'),
-- Época 2 (Seca 2025)
(1, 2, 180.00, '2025-04-03'),
(2, 2, 320.00, '2025-04-03'),
(3, 2, 140.00, '2025-04-03'),
(4, 2, 110.00, '2025-04-03'),
(5, 2, 400.00, '2025-04-03'),
(6, 2, 200.00, '2025-04-03'),
(7, 2, 130.00, '2025-04-03'),
(8, 2, 105.00, '2025-04-03'),
-- Época 3 (Chuvas 2025/2026)
(1, 3, 160.00, '2025-10-05'),
(2, 3, 300.00, '2025-10-05'),
(3, 3, 130.00, '2025-10-05'),
(4, 3, 100.00, '2025-10-05'),
(5, 3, 380.00, '2025-10-05'),
(6, 3, 190.00, '2025-10-05'),
(7, 3, 120.00, '2025-10-05'),
(8, 3, 100.00, '2025-10-05'),
-- Época 4 (Seca 2024)
(1, 4, 140.00, '2024-04-03'),
(2, 4, 250.00, '2024-04-03'),
(3, 4, 110.00, '2024-04-03'),
(4, 4, 85.00, '2024-04-03'),
(5, 4, 320.00, '2024-04-03'),
(6, 4, 170.00, '2024-04-03'),
-- Época 5 (Chuvas 2023/2024)
(1, 5, 130.00, '2023-10-05'),
(2, 5, 240.00, '2023-10-05'),
(3, 5, 100.00, '2023-10-05'),
(4, 5, 80.00, '2023-10-05'),
(5, 5, 300.00, '2023-10-05'),
(6, 5, 160.00, '2023-10-05');

INSERT INTO entregas (cooperativista_id, produto_id, epoca_id, data_entrega, quantidade, observacoes) VALUES
-- Cooperativista 1: Emília Francisco António
(1, 1, 1, '2024-11-10', 450.000, 'Milho de primeira qualidade'),
(1, 2, 1, '2024-11-15', 180.000, NULL),
(1, 4, 1, '2024-12-01', 120.000, NULL),

(2, 1, 1, '2024-11-12', 380.000, NULL),
(2, 3, 1, '2024-11-20', 520.000, 'Mandioca fresca'),
(2, 5, 1, '2024-12-05', 90.000, NULL),

(3, 1, 1, '2024-11-10', 420.000, NULL),
(3, 6, 1, '2024-11-25', 60.000, 'Bananas em bom estado'),

(4, 2, 1, '2024-11-14', 200.000, NULL),
(4, 4, 1, '2024-11-28', 150.000, NULL),
(4, 7, 1, '2024-12-10', 130.000, NULL),

(5, 1, 1, '2024-11-16', 350.000, NULL),
(5, 3, 1, '2024-12-02', 480.000, NULL),

(6, 2, 1, '2024-11-18', 160.000, NULL),
(6, 5, 1, '2024-12-04', 70.000, NULL),

(7, 1, 1, '2024-11-19', 400.000, NULL),
(7, 4, 1, '2024-12-06', 110.000, NULL),

(8, 2, 1, '2024-11-20', 190.000, NULL),
(8, 6, 1, '2024-12-08', 65.000, NULL),

(9, 1, 1, '2024-11-21', 430.000, NULL),
(9, 3, 1, '2024-12-09', 510.000, NULL),

(10, 2, 1, '2024-11-22', 170.000, NULL),
(10, 5, 1, '2024-12-11', 80.000, NULL),

(11, 1, 1, '2024-11-23', 390.000, NULL),
(11, 7, 1, '2024-12-12', 140.000, NULL),
(12, 2, 1, '2024-11-24', 210.000, NULL),
(12, 4, 1, '2024-12-13', 130.000, NULL),
(13, 1, 1, '2024-11-25', 370.000, NULL),
(13, 6, 1, '2024-12-14', 55.000, NULL),
(14, 3, 1, '2024-11-26', 490.000, NULL),
(14, 5, 1, '2024-12-15', 75.000, NULL),
(15, 1, 1, '2024-11-27', 410.000, NULL),
(15, 2, 1, '2024-12-16', 185.000, NULL),
(16, 4, 1, '2024-11-28', 140.000, NULL),
(16, 7, 1, '2024-12-17', 120.000, NULL),
(17, 1, 1, '2024-11-29', 360.000, NULL),
(17, 3, 1, '2024-12-18', 500.000, NULL),
(18, 2, 1, '2024-11-30', 195.000, NULL),
(18, 5, 1, '2024-12-19', 85.000, NULL),
(19, 1, 1, '2024-12-01', 440.000, NULL),
(19, 6, 1, '2024-12-20', 70.000, NULL),
(20, 3, 1, '2024-12-02', 470.000, NULL),
(20, 4, 1, '2024-12-21', 125.000, NULL),
(21, 1, 1, '2024-12-03', 400.000, NULL),
(21, 2, 1, '2024-12-22', 175.000, NULL),
(22, 5, 1, '2024-12-04', 65.000, NULL),
(22, 7, 1, '2024-12-23', 135.000, NULL),
(23, 1, 1, '2024-12-05', 380.000, NULL),
(23, 3, 1, '2024-12-24', 460.000, NULL),
(24, 2, 1, '2024-12-06', 200.000, NULL),
(24, 4, 1, '2024-12-25', 115.000, NULL),
(25, 1, 1, '2024-12-07', 420.000, NULL),
(25, 6, 1, '2024-12-26', 60.000, NULL),
(26, 3, 1, '2024-12-08', 530.000, NULL),
(26, 5, 1, '2024-12-27', 95.000, NULL),
(27, 1, 1, '2024-12-09', 370.000, NULL),
(27, 2, 1, '2024-12-28', 190.000, NULL),
(28, 4, 1, '2024-12-10', 145.000, NULL),
(28, 7, 1, '2024-12-29', 125.000, NULL),
(29, 1, 1, '2024-12-11', 450.000, NULL),
(29, 3, 1, '2024-12-30', 490.000, NULL),
(30, 2, 1, '2024-12-12', 185.000, NULL),
(30, 5, 1, '2024-12-31', 80.000, NULL),
(31, 1, 1, '2024-12-13', 390.000, NULL),
(31, 6, 1, '2025-01-02', 55.000, NULL),
(32, 3, 1, '2024-12-14', 480.000, NULL),
(32, 4, 1, '2025-01-03', 130.000, NULL),
(33, 1, 1, '2024-12-15', 410.000, NULL),
(33, 2, 1, '2025-01-04', 170.000, NULL),
(34, 5, 1, '2024-12-16', 75.000, NULL),
(34, 7, 1, '2025-01-05', 140.000, NULL),
(35, 1, 1, '2024-12-17', 360.000, NULL),
(35, 3, 1, '2025-01-06', 510.000, NULL),
(36, 2, 1, '2024-12-18', 210.000, NULL),
(36, 4, 1, '2025-01-07', 120.000, NULL),
(37, 1, 1, '2024-12-19', 430.000, NULL),
(37, 6, 1, '2025-01-08', 65.000, NULL),
(38, 3, 1, '2024-12-20', 460.000, NULL),
(38, 5, 1, '2025-01-09', 85.000, NULL),
(39, 1, 1, '2024-12-21', 380.000, NULL),
(39, 2, 1, '2025-01-10', 195.000, NULL),
(40, 4, 1, '2024-12-22', 135.000, NULL),
(40, 7, 1, '2025-01-11', 130.000, NULL),
(41, 1, 1, '2024-12-23', 400.000, NULL),
(41, 3, 1, '2025-01-12', 520.000, NULL),
(42, 2, 1, '2024-12-24', 180.000, NULL),
(42, 5, 1, '2025-01-13', 70.000, NULL),
(43, 1, 1, '2024-12-25', 440.000, NULL),
(43, 6, 1, '2025-01-14', 60.000, NULL),
(44, 3, 1, '2024-12-26', 490.000, NULL),
(44, 4, 1, '2025-01-15', 140.000, NULL),
(45, 1, 1, '2024-12-27', 370.000, NULL),
(45, 2, 1, '2025-01-16', 200.000, NULL),
(46, 5, 1, '2024-12-28', 90.000, NULL),
(46, 7, 1, '2025-01-17', 125.000, NULL),
(47, 1, 1, '2024-12-29', 420.000, NULL),
(47, 3, 1, '2025-01-18', 480.000, NULL),
(48, 2, 1, '2024-12-30', 190.000, NULL),
(48, 4, 1, '2025-01-19', 115.000, NULL),
(49, 1, 1, '2024-12-31', 390.000, NULL),
(49, 6, 1, '2025-01-20', 55.000, NULL),
(50, 3, 1, '2025-01-01', 510.000, NULL),
(50, 5, 1, '2025-01-21', 80.000, NULL),
(51, 1, 1, '2025-01-02', 450.000, NULL),
(51, 2, 1, '2025-01-22', 185.000, NULL);

INSERT INTO comercializacoes (id, epoca_id, data_venda, descricao, created_at) VALUES
(1, 1, '2025-01-15', 'Comercialização principal - Época Chuvas 2024/2025', '2025-01-15 10:00:00'),
(2, 2, '2025-06-20', 'Comercialização da Seca 2025 (previsão)', '2025-06-20 09:30:00'),
(3, 1, '2025-02-28', 'Comercialização extra - Chuvas 2024/2025', '2025-02-28 11:15:00');

INSERT INTO comercializacao_entregas (comercializacao_id, entrega_id)
SELECT 1, id FROM entregas WHERE epoca_id = 1;

INSERT INTO comercializacao_entregas (comercializacao_id, entrega_id)
SELECT 3, id FROM entregas WHERE epoca_id = 1 AND id % 2 = 1;

CALL sp_distribuir_lucros(1);

CALL sp_distribuir_lucros(3);

SELECT '=== COOPERATIVISTAS ===' AS '';
SELECT COUNT(*) AS total_cooperativistas FROM cooperativistas;

SELECT '=== ENTREGAS ===' AS '';
SELECT COUNT(*) AS total_entregas FROM entregas;

SELECT '=== COMERCIALIZAÇÕES ===' AS '';
SELECT COUNT(*) AS total_comercializacoes FROM comercializacoes;

SELECT '=== DISTRIBUIÇÕES DE LUCRO ===' AS '';
SELECT COUNT(*) AS total_distribuicoes FROM distribuicoes_lucro;

SELECT 
    c.nome AS cooperativista,
    COUNT(e.id) AS total_entregas,
    SUM(e.quantidade * pc.preco_unitario) AS valor_total_apurado
FROM cooperativistas c
JOIN entregas e ON e.cooperativista_id = c.id
JOIN precos_comercializacao pc ON pc.produto_id = e.produto_id AND pc.epoca_id = e.epoca_id
GROUP BY c.id, c.nome
ORDER BY valor_total_apurado DESC
LIMIT 10;

SELECT 
    c.nome AS cooperativista,
    COUNT(dl.id) AS num_distribuicoes,
    SUM(dl.valor_apurado) AS total_apurado,
    SUM(dl.valor_lucro) AS total_lucro
FROM cooperativistas c
JOIN distribuicoes_lucro dl ON dl.cooperativista_id = c.id
GROUP BY c.id, c.nome
ORDER BY total_lucro DESC
LIMIT 10;

SELECT '=== POPULAÇÃO CONCLUÍDA COM SUCESSO ===' AS '';

COMMIT;