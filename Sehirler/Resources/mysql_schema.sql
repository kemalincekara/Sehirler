-- phpMyAdmin SQL Dump
-- version 4.6.5.2
-- https://www.phpmyadmin.net/
--
-- Anamakine: 127.0.0.1
-- Üretim Zamanı: 05 Tem 2017, 10:22:52
-- Sunucu sürümü: 10.1.21-MariaDB
-- PHP Sürümü: 5.6.30

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Veritabanı: `sehirler`
--

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `sehiril`
--

CREATE TABLE `sehiril` (
  `ID` int(11) NOT NULL,
  `SehirAd` varchar(15) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `sehirilce`
--

CREATE TABLE `sehirilce` (
  `ID` int(11) NOT NULL,
  `SehirID` int(11) NOT NULL,
  `IlceAd` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `sehirmahalle`
--

CREATE TABLE `sehirmahalle` (
  `ID` int(11) NOT NULL,
  `SemtID` int(11) NOT NULL,
  `MahalleAd` varchar(70) NOT NULL,
  `PostaKodu` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `sehirsemt`
--

CREATE TABLE `sehirsemt` (
  `ID` int(11) NOT NULL,
  `IlceID` int(11) NOT NULL,
  `SemtAd` varchar(30) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dökümü yapılmış tablolar için indeksler
--

--
-- Tablo için indeksler `sehiril`
--
ALTER TABLE `sehiril`
  ADD PRIMARY KEY (`ID`);

--
-- Tablo için indeksler `sehirilce`
--
ALTER TABLE `sehirilce`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `SehirID` (`SehirID`);

--
-- Tablo için indeksler `sehirmahalle`
--
ALTER TABLE `sehirmahalle`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `SemtID` (`SemtID`);

--
-- Tablo için indeksler `sehirsemt`
--
ALTER TABLE `sehirsemt`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `IlceID` (`IlceID`);

--
-- Dökümü yapılmış tablolar için AUTO_INCREMENT değeri
--

--
-- Tablo için AUTO_INCREMENT değeri `sehiril`
--
ALTER TABLE `sehiril`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT;
--
-- Tablo için AUTO_INCREMENT değeri `sehirilce`
--
ALTER TABLE `sehirilce`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT;
--
-- Tablo için AUTO_INCREMENT değeri `sehirmahalle`
--
ALTER TABLE `sehirmahalle`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT;
--
-- Tablo için AUTO_INCREMENT değeri `sehirsemt`
--
ALTER TABLE `sehirsemt`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT;
--
-- Dökümü yapılmış tablolar için kısıtlamalar
--

--
-- Tablo kısıtlamaları `sehirilce`
--
ALTER TABLE `sehirilce`
  ADD CONSTRAINT `sehirilce_ibfk_1` FOREIGN KEY (`SehirID`) REFERENCES `sehiril` (`ID`);

--
-- Tablo kısıtlamaları `sehirmahalle`
--
ALTER TABLE `sehirmahalle`
  ADD CONSTRAINT `sehirmahalle_ibfk_1` FOREIGN KEY (`SemtID`) REFERENCES `sehirsemt` (`ID`);

--
-- Tablo kısıtlamaları `sehirsemt`
--
ALTER TABLE `sehirsemt`
  ADD CONSTRAINT `sehirsemt_ibfk_1` FOREIGN KEY (`IlceID`) REFERENCES `sehirilce` (`ID`);

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
