CREATE DATABASE IF NOT EXISTS cooperativa_agricola
  CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;

USE cooperativa_agricola;

CREATE TABLE IF NOT EXISTS utilizadores (
    id INT AUTO_INCREMENT PRIMARY KEY,
    nome VARCHAR(100) NOT NULL,
    username VARCHAR(50) NOT NULL UNIQUE,
    password VARCHAR(255) NOT NULL,
    perfil ENUM('Administrador', 'Funcionario') NOT NULL DEFAULT 'Funcionario',
    ativo TINYINT(1) NOT NULL DEFAULT 1
);

CREATE TABLE IF NOT EXISTS cooperativistas (
    id INT AUTO_INCREMENT PRIMARY KEY,
    nome VARCHAR(150) NOT NULL,
    numero_socio VARCHAR(20) NOT NULL UNIQUE,
    bilhete_id VARCHAR(30) NOT NULL,
    telefone VARCHAR(20) NULL,
    email VARCHAR(100) NULL,
    quota_percent DECIMAL(5,2) NOT NULL,
    data_adesao DATE NOT NULL,
    activo TINYINT(1) NOT NULL DEFAULT 1,
    INDEX idx_coop_activo (activo)
);

CREATE TABLE IF NOT EXISTS epocas_agricolas (
    id INT AUTO_INCREMENT PRIMARY KEY,
    nome VARCHAR(100) NOT NULL,
    tipo TINYINT NOT NULL,
    ano INT NOT NULL,
    data_inicio DATE NOT NULL,
    data_fim DATE NOT NULL,
    encerrada TINYINT(1) NOT NULL DEFAULT 0,
    INDEX idx_epoca_encerrada (encerrada)
);

CREATE TABLE IF NOT EXISTS categorias_produto (
    id INT AUTO_INCREMENT PRIMARY KEY,
    nome VARCHAR(80) NOT NULL UNIQUE,
    descricao VARCHAR(255) NULL
);

CREATE TABLE IF NOT EXISTS produtos_agricolas (
    id INT AUTO_INCREMENT PRIMARY KEY,
    codigo VARCHAR(20) NOT NULL UNIQUE,
    nome VARCHAR(100) NOT NULL,
    unidade_medida VARCHAR(20) NOT NULL,
    categoria_id INT NOT NULL,
    activo TINYINT(1) NOT NULL DEFAULT 1,
    CONSTRAINT fk_prod_categoria FOREIGN KEY (categoria_id) REFERENCES categorias_produto(id),
    INDEX idx_prod_activo (activo)
);

CREATE TABLE IF NOT EXISTS entregas (
    id INT AUTO_INCREMENT PRIMARY KEY,
    cooperativista_id INT NOT NULL,
    produto_id INT NOT NULL,
    epoca_id INT NOT NULL,
    data_entrega DATE NOT NULL,
    quantidade DECIMAL(12,2) NOT NULL,
    observacoes VARCHAR(255) NULL,
    CONSTRAINT fk_entrega_coop FOREIGN KEY (cooperativista_id) REFERENCES cooperativistas(id),
    CONSTRAINT fk_entrega_prod FOREIGN KEY (produto_id) REFERENCES produtos_agricolas(id),
    CONSTRAINT fk_entrega_epoca FOREIGN KEY (epoca_id) REFERENCES epocas_agricolas(id),
    INDEX idx_entrega_epoca (epoca_id),
    INDEX idx_entrega_coop (cooperativista_id)
);

CREATE TABLE IF NOT EXISTS precos_comercializacao (
    id INT AUTO_INCREMENT PRIMARY KEY,
    produto_id INT NOT NULL,
    epoca_id INT NOT NULL,
    preco_unitario DECIMAL(12,2) NOT NULL,
    data_definicao DATE NOT NULL,
    CONSTRAINT fk_preco_prod FOREIGN KEY (produto_id) REFERENCES produtos_agricolas(id),
    CONSTRAINT fk_preco_epoca FOREIGN KEY (epoca_id) REFERENCES epocas_agricolas(id),
    UNIQUE KEY uk_preco_prod_epoca (produto_id, epoca_id)
);

CREATE TABLE IF NOT EXISTS comercializacoes (
    id INT AUTO_INCREMENT PRIMARY KEY,
    epoca_id INT NOT NULL,
    data_venda DATE NOT NULL,
    descricao VARCHAR(255) NULL,
    CONSTRAINT fk_com_epoca FOREIGN KEY (epoca_id) REFERENCES epocas_agricolas(id)
);

CREATE TABLE IF NOT EXISTS comercializacao_entregas (
    comercializacao_id INT NOT NULL,
    entrega_id INT NOT NULL,
    PRIMARY KEY (comercializacao_id, entrega_id),
    CONSTRAINT fk_ce_com FOREIGN KEY (comercializacao_id) REFERENCES comercializacoes(id) ON DELETE CASCADE,
    CONSTRAINT fk_ce_entrega FOREIGN KEY (entrega_id) REFERENCES entregas(id)
);

CREATE TABLE IF NOT EXISTS distribuicoes_lucro (
    id INT AUTO_INCREMENT PRIMARY KEY,
    cooperativista_id INT NOT NULL,
    comercializacao_id INT NOT NULL,
    valor_apurado DECIMAL(14,2) NOT NULL,
    valor_lucro DECIMAL(14,2) NOT NULL,
    quota_aplicada DECIMAL(5,2) NOT NULL,
    data_distribuicao DATE NOT NULL,
    CONSTRAINT fk_dist_coop FOREIGN KEY (cooperativista_id) REFERENCES cooperativistas(id),
    CONSTRAINT fk_dist_com FOREIGN KEY (comercializacao_id) REFERENCES comercializacoes(id) ON DELETE CASCADE
);

INSERT IGNORE INTO utilizadores (nome, username, password, perfil) VALUES
('Administrador', 'admin', 'admin123', 'Administrador'),
('Funcionário Demo', 'funcionario', 'func123', 'Funcionario');

INSERT IGNORE INTO categorias_produto (nome, descricao) VALUES
('Cereais', 'Produtos cerealíferos'),
('Leguminosas', 'Feijão, soja e similares'),
('Hortícolas', 'Produtos hortícolas');
