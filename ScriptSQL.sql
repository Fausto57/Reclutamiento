Create database Expediente;
Use Expediente;

CREATE TABLE Prospectos (
    id BIGINT UNSIGNED AUTO_INCREMENT PRIMARY KEY,
    Nombre VARCHAR(50) NOT NULL,
    ApellidoPaterno VARCHAR(50) NOT NULL,
    ApellidoMaterno VARCHAR(50),
    Calle VARCHAR(50) NOT NULL,
    Numero VARCHAR(50) NOT NULL,
    Colonia VARCHAR(50) NOT NULL,
    CodigoPostal VARCHAR(50) NOT NULL,
    Telefono VARCHAR(50) NOT NULL,
    RFC VARCHAR(50) NOT NULL,
    Estatus VARCHAR(50) NOT NULL,
    Descripcion VARCHAR(100),
    Documentos blob
);

ALTER TABLE Prospectos
       MODIFY Documentos blob;