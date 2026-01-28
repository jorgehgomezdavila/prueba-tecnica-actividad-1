/*
 * Actividad 1 - Script de Base de Datos
 * Autor: Jorge Humberto Gomez De Avila (DESARROLLADOR FULLSTACK)
 * Descripción:Esquema para el historial de búsquedas de la API Rick & Morty.
 */

-- 1. Crear Base de Datos si no existe
CREATE DATABASE IF NOT EXISTS RickMortyDB;
USE RickMortyDB;

-- 2. Crear Tabla de Historial de Búsquedas
CREATE TABLE IF NOT EXISTS SearchHistory (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    EndpointCalled VARCHAR(50) NOT NULL COMMENT 'Nombre del endpoint interno consumido',
    SearchTerm VARCHAR(200) NULL COMMENT 'Filtros aplicados en la búsqueda (JSON o Texto)',
    DateAccessed DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Fecha y hora de la consulta'
);

-- 3. Insertar un dato de prueba (Opcional)
INSERT INTO SearchHistory (EndpointCalled, SearchTerm, DateAccessed)
VALUES ('GetCharacters', 'Initial Load', NOW());

-- Verificación
SELECT * FROM SearchHistory;