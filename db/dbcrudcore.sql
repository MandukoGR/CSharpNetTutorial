-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 20-05-2022 a las 02:40:33
-- Versión del servidor: 10.4.24-MariaDB
-- Versión de PHP: 8.1.6

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `dbcrudcore`
--

DELIMITER $$
--
-- Procedimientos
--
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_Editar` (IN `U_IdContacto` INT, IN `U_Nombre` VARCHAR(100) CHARSET utf8, IN `U_Telefono` VARCHAR(100) CHARSET utf8, IN `U_Correo` VARCHAR(100) CHARSET utf8)   update contacto set Nombre = U_Nombre, Telefono = U_telefono, Correo = U_Correo where IdContacto = U_IdContacto$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_Eliminar` (IN `U_IdContacto` INT)   delete from contacto where IdContacto = U_IdContacto$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_Guardar` (IN `U_Nombre` VARCHAR(100) CHARSET utf8, IN `U_Telefono` VARCHAR(100) CHARSET utf8, IN `U_Correo` VARCHAR(100) CHARSET utf8)   insert into contacto(Nombre, Telefono, Correo) values(U_Nombre, U_Telefono, U_Correo)$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_Listar` ()   select * from CONTACTO$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_Obtener` (IN `U_IdContacto` INT)   select * from CONTACTO where IdContacto = U_IdContacto$$

DELIMITER ;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `contacto`
--

CREATE TABLE `contacto` (
  `IdContacto` int(11) NOT NULL,
  `Nombre` varchar(50) DEFAULT NULL,
  `Telefono` varchar(50) DEFAULT NULL,
  `Correo` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `contacto`
--

INSERT INTO `contacto` (`IdContacto`, `Nombre`, `Telefono`, `Correo`) VALUES
(1, 'Armando', '4424499417', 'armando@outlook.com');

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `contacto`
--
ALTER TABLE `contacto`
  ADD PRIMARY KEY (`IdContacto`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `contacto`
--
ALTER TABLE `contacto`
  MODIFY `IdContacto` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
