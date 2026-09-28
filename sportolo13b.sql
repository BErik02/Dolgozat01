-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Gép: 127.0.0.1
-- Létrehozás ideje: 2026. Sze 28. 10:47
-- Kiszolgáló verziója: 10.4.32-MariaDB
-- PHP verzió: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Adatbázis: `sportolo13b`
--

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `eredmeny`
--

CREATE TABLE `eredmeny` (
  `id` int(11) NOT NULL,
  `competition` varchar(100) NOT NULL,
  `description` text NOT NULL,
  `resultTime` datetime NOT NULL,
  `updateTime` datetime NOT NULL,
  `sportoloId` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- A tábla adatainak kiíratása `eredmeny`
--

INSERT INTO `eredmeny` (`id`, `competition`, `description`, `resultTime`, `updateTime`, `sportoloId`) VALUES
(2, 'Megyei bajnokság', 'Aranyérem 100 m gátfutásban, 13.42 mp.', '2025-05-18 15:00:00', '2025-05-18 15:00:00', 2),
(3, 'Országos diákolimpia', 'Ezüstérem magasugrásban, 178 cm.', '2025-06-01 10:15:00', '2025-06-01 10:15:00', 3),
(4, 'Úszó verseny', '100 m gyors, 2. hely, 58.3 mp.', '2025-06-10 09:00:00', '2025-06-10 09:00:00', 5),
(5, 'Atlétikai kupa', 'Súlylökés, 3. hely, 11.8 m.', '2025-06-22 14:20:00', '2025-06-22 14:20:00', 6),
(8, 'Budapest Maraton', '2:58:12-es idővel 14. hely az abszolút mezőnyben.', '2025-05-04 12:30:00', '2025-05-04 12:30:00', 1),
(9, 'Megyei bajnokság', 'Aranyérem 100 m gátfutásban, 13.42 mp.', '2025-05-18 15:00:00', '2025-05-18 15:00:00', 2),
(10, 'Országos diákolimpia', 'Ezüstérem magasugrásban, 178 cm.', '2025-06-01 10:15:00', '2025-06-01 10:15:00', 3),
(11, 'Úszó verseny', '100 m gyors, 2. hely, 58.3 mp.', '2025-06-10 09:00:00', '2025-06-10 09:00:00', 5),
(15, 'asda', 'faf', '0000-00-00 00:00:00', '0000-00-00 00:00:00', 12),
(20, 'ad', 'er', '0000-00-00 00:00:00', '0000-00-00 00:00:00', 1),
(22, 'wad', 'asdsa', '0000-00-00 00:00:00', '0000-00-00 00:00:00', 1),
(23, 'wad', 'asdsaadada', '0000-00-00 00:00:00', '0000-00-00 00:00:00', 2);

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `sportolo`
--

CREATE TABLE `sportolo` (
  `id` int(11) NOT NULL,
  `name` varchar(50) NOT NULL,
  `email` varchar(100) NOT NULL,
  `age` int(11) NOT NULL,
  `password` varchar(100) NOT NULL,
  `registrationTime` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- A tábla adatainak kiíratása `sportolo`
--

INSERT INTO `sportolo` (`id`, `name`, `email`, `age`, `password`, `registrationTime`) VALUES
(1, 'Kovács Bence', 'kovacs.bence@example.com', 21, 'jelszo123', '2025-01-12 09:15:00'),
(2, 'Nagy Petra', 'nagy.petra@example.com', 19, 'titkosjelszo', '2025-02-03 14:30:00'),
(3, 'Szabó Márk', 'szabo.mark@example.com', 24, 'sport2025', '2025-02-20 08:00:00'),
(4, 'Tóth Zsófia', 'toth.zsofia@example.com', 22, 'futas!42', '2025-03-15 17:45:00'),
(5, 'Horváth Dávid', 'horvath.david@example.com', 20, 'uszas99', '2025-04-01 11:20:00'),
(6, 'Varga Lili', 'varga.lili@example.com', 23, 'atletika7', '2025-04-18 16:05:00'),
(7, 'Kovács Bence', 'kovacs.bence@example.com', 21, 'jelszo123', '2025-01-12 09:15:00'),
(8, 'Nagy Petra', 'nagy.petra@example.com', 19, 'titkosjelszo', '2025-02-03 14:30:00'),
(9, 'Szabó Márk', 'szabo.mark@example.com', 24, 'sport2025', '2025-02-20 08:00:00'),
(10, 'Tóth Zsófia', 'toth.zsofia@example.com', 22, 'futas!42', '2025-03-15 17:45:00'),
(11, 'Horváth Dávid', 'horvath.david@example.com', 20, 'uszas99', '2025-04-01 11:20:00'),
(12, 'Varga Lili', 'varga.lili@example.com', 23, 'atletika7', '2025-04-18 16:05:00');

--
-- Indexek a kiírt táblákhoz
--

--
-- A tábla indexei `eredmeny`
--
ALTER TABLE `eredmeny`
  ADD PRIMARY KEY (`id`),
  ADD KEY `fk_sportolo_eredmeny` (`sportoloId`);

--
-- A tábla indexei `sportolo`
--
ALTER TABLE `sportolo`
  ADD PRIMARY KEY (`id`);

--
-- A kiírt táblák AUTO_INCREMENT értéke
--

--
-- AUTO_INCREMENT a táblához `eredmeny`
--
ALTER TABLE `eredmeny`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=24;

--
-- AUTO_INCREMENT a táblához `sportolo`
--
ALTER TABLE `sportolo`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=13;

--
-- Megkötések a kiírt táblákhoz
--

--
-- Megkötések a táblához `eredmeny`
--
ALTER TABLE `eredmeny`
  ADD CONSTRAINT `fk_sportolo_eredmeny` FOREIGN KEY (`sportoloId`) REFERENCES `sportolo` (`id`) ON DELETE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
