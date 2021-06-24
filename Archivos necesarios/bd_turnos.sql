-- phpMyAdmin SQL Dump
-- version 5.0.2
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 24-05-2020 a las 20:58:23
-- Versión del servidor: 10.4.11-MariaDB
-- Versión de PHP: 7.4.6

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `bd_turnos`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `documentacion`
--

CREATE TABLE `documentacion` (
  `TURNO` int(50) NOT NULL,
  `NOMBRE` varchar(100) NOT NULL,
  `CURP` varchar(100) NOT NULL,
  `AREA` varchar(100) NOT NULL,
  `TELEFONO` int(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `documentacion`
--

INSERT INTO `documentacion` (`TURNO`, `NOMBRE`, `CURP`, `AREA`, `TELEFONO`) VALUES
(10, 'MATEO SIONE VALADEZ ROJAS', 'VARA9292IDID9292D', 'RECOGER DOCUMENTACIÓN', 232323232),
(11, 'FELICITAS CRISANTO MARTINEZ', 'OANDS223SODSOI', 'RECOGER DOCUMENTACIÓN', 232323232);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `pagos`
--

CREATE TABLE `pagos` (
  `TURNO` int(50) NOT NULL,
  `NOMBRE` varchar(100) NOT NULL,
  `CURP` varchar(100) NOT NULL,
  `AREA` varchar(100) NOT NULL,
  `TELEFONO` int(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `pagos`
--

INSERT INTO `pagos` (`TURNO`, `NOMBRE`, `CURP`, `AREA`, `TELEFONO`) VALUES
(5, 'RAFAEL ROJAS CAMACHO', 'CARO8280DJAIS39', 'CONSULTAS Y PAGOS', 243434343);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tramites`
--

CREATE TABLE `tramites` (
  `TURNO` int(50) NOT NULL,
  `NOMBRE` varchar(100) NOT NULL,
  `CURP` varchar(100) NOT NULL,
  `AREA` varchar(100) NOT NULL,
  `TELEFONO` int(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `tramites`
--

INSERT INTO `tramites` (`TURNO`, `NOMBRE`, `CURP`, `AREA`, `TELEFONO`) VALUES
(9, 'MARICARMEN ROJAS CAMACHO', 'ROCM34344MVZASDI03', 'TRÁMITES', 0),
(10, 'FELIPE NERY VALADEZ AY', 'AODAS992932IDI', 'TRÁMITES', 223232323);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `usuarios`
--

CREATE TABLE `usuarios` (
  `Id_usuario` int(5) NOT NULL,
  `Nombre` varchar(50) NOT NULL,
  `Usuario` varchar(50) NOT NULL,
  `Password` varchar(50) NOT NULL,
  `Tipo_usuario` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `usuarios`
--

INSERT INTO `usuarios` (`Id_usuario`, `Nombre`, `Usuario`, `Password`, `Tipo_usuario`) VALUES
(1, 'Historial General', 'admin', '12345', 'Admingral'),
(2, 'Administrador Trámites', 'tramites', '7890', 'AdminTramites'),
(3, 'Administrador Pagos', 'pagos', '4567', 'AdminPagos'),
(4, 'Administrador Documentación', 'documentacion', '121', 'AdminDocumentacion');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `visitantes`
--

CREATE TABLE `visitantes` (
  `ID` int(50) NOT NULL,
  `NOMBRE` varchar(100) NOT NULL,
  `CURP` varchar(100) NOT NULL,
  `AREA` varchar(100) NOT NULL,
  `TELEFONO` int(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `visitantes`
--

INSERT INTO `visitantes` (`ID`, `NOMBRE`, `CURP`, `AREA`, `TELEFONO`) VALUES
(30, 'MARICARMEN ROJAS CAMACHO', 'ROCM34344MVZASDI03', 'TRÁMITES', 0),
(31, 'MATEO SIONE VALADEZ ROJAS', 'VARA9292IDID9292D', 'RECOGER DOCUMENTACIÓN', 232323232),
(32, 'RAFAEL ROJAS CAMACHO', 'CARO8280DJAIS39', 'CONSULTAS Y PAGOS', 243434343),
(33, 'FELIPE NERY VALADEZ AY', 'AODAS992932IDI', 'TRÁMITES', 223232323),
(34, 'FELICITAS CRISANTO MARTINEZ', 'OANDS223SODSOI', 'RECOGER DOCUMENTACIÓN', 232323232);

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `documentacion`
--
ALTER TABLE `documentacion`
  ADD PRIMARY KEY (`TURNO`);

--
-- Indices de la tabla `pagos`
--
ALTER TABLE `pagos`
  ADD PRIMARY KEY (`TURNO`);

--
-- Indices de la tabla `tramites`
--
ALTER TABLE `tramites`
  ADD PRIMARY KEY (`TURNO`);

--
-- Indices de la tabla `usuarios`
--
ALTER TABLE `usuarios`
  ADD PRIMARY KEY (`Id_usuario`);

--
-- Indices de la tabla `visitantes`
--
ALTER TABLE `visitantes`
  ADD PRIMARY KEY (`ID`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `documentacion`
--
ALTER TABLE `documentacion`
  MODIFY `TURNO` int(50) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=12;

--
-- AUTO_INCREMENT de la tabla `pagos`
--
ALTER TABLE `pagos`
  MODIFY `TURNO` int(50) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT de la tabla `tramites`
--
ALTER TABLE `tramites`
  MODIFY `TURNO` int(50) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT de la tabla `usuarios`
--
ALTER TABLE `usuarios`
  MODIFY `Id_usuario` int(5) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT de la tabla `visitantes`
--
ALTER TABLE `visitantes`
  MODIFY `ID` int(50) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=35;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
