CREATE DATABASE  IF NOT EXISTS `demo` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `demo`;
-- MySQL dump 10.13  Distrib 8.0.36, for Win64 (x86_64)
--
-- Host: localhost    Database: demo
-- ------------------------------------------------------
-- Server version	8.0.36

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `material_type`
--

DROP TABLE IF EXISTS `material_type`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `material_type` (
  `id_material_type` int NOT NULL AUTO_INCREMENT,
  `name_material_type` varchar(50) NOT NULL,
  `defect_type` double(3,2) NOT NULL,
  PRIMARY KEY (`id_material_type`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `material_type`
--

LOCK TABLES `material_type` WRITE;
/*!40000 ALTER TABLE `material_type` DISABLE KEYS */;
INSERT INTO `material_type` VALUES (1,'Тип материала 1',0.10),(2,'Тип материала 2',0.95),(3,'Тип материала 3',0.28),(4,'Тип материала 4',0.55),(5,'Тип материала 5',0.34);
/*!40000 ALTER TABLE `material_type` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `partners`
--

DROP TABLE IF EXISTS `partners`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `partners` (
  `id_partner` int NOT NULL AUTO_INCREMENT,
  `type_partner` varchar(3) NOT NULL,
  `name_partner` varchar(50) NOT NULL,
  `director_surname` varchar(100) NOT NULL,
  `director_name` varchar(50) NOT NULL,
  `director_patronymic` varchar(50) NOT NULL,
  `email_partner` varchar(100) NOT NULL,
  `phome_number` varchar(15) NOT NULL,
  `address_index` int NOT NULL,
  `address_locality` varchar(50) NOT NULL,
  `address_city` varchar(50) NOT NULL,
  `address_street` varchar(50) NOT NULL,
  `address_home` varchar(20) NOT NULL,
  `inn_partner` varchar(11) NOT NULL,
  `rating_partner` int NOT NULL,
  PRIMARY KEY (`id_partner`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `partners`
--

LOCK TABLES `partners` WRITE;
/*!40000 ALTER TABLE `partners` DISABLE KEYS */;
INSERT INTO `partners` VALUES (1,'ЗАО','База Строитель','Иванова','Александра','Ивановна','aleksandraivanova@ml.ru','493 123 45 67',652050,' Кемеровская область',' город Юрга',' ул. Лесная','15','2222455179',7),(2,'ООО','Паркет 29','Петров','Василий','Петрович','vppetrov@vl.ru','987 123 56 78',164500,' Архангельская область',' город Северодвинск',' ул. Строителей','18','3333888520',7),(3,'ПАО','Стройсервис','Соловьев','Андрей','Николаевич','ansolovev@st.ru','812 223 32 00',188910,' Ленинградская область',' город Приморск',' ул. Парковая','21','4440391035',7),(4,'ОАО','Ремонт и отделка','Воробьева','Екатерина','Валерьевна','ekaterina.vorobeva@ml.ru','444 222 33 11',143960,' Московская область',' город Реутов',' ул. Свободы','51','1111520857',5),(5,'ЗАО','МонтажПро','Степанов','Степан','Сергеевич','stepanov@stepan.ru','912 888 33 33',309500,' Белгородская область',' город Старый Оскол',' ул. Рабочая','122','5552431140',10);
/*!40000 ALTER TABLE `partners` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `partners_products`
--

DROP TABLE IF EXISTS `partners_products`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `partners_products` (
  `id_partners_products` int NOT NULL AUTO_INCREMENT,
  `article_product` char(7) NOT NULL,
  `id_partner` int NOT NULL,
  `count_product` int NOT NULL,
  `date_sale` date NOT NULL,
  PRIMARY KEY (`id_partners_products`),
  KEY `article_product` (`article_product`),
  KEY `id_partner` (`id_partner`),
  CONSTRAINT `partners_products_ibfk_1` FOREIGN KEY (`article_product`) REFERENCES `products` (`article_product`),
  CONSTRAINT `partners_products_ibfk_2` FOREIGN KEY (`id_partner`) REFERENCES `partners` (`id_partner`)
) ENGINE=InnoDB AUTO_INCREMENT=17 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `partners_products`
--

LOCK TABLES `partners_products` WRITE;
/*!40000 ALTER TABLE `partners_products` DISABLE KEYS */;
INSERT INTO `partners_products` VALUES (1,'8758385',1,15500,'2023-03-23'),(2,'7750282',1,12350,'2023-12-18'),(3,'7028748',1,37400,'2024-06-07'),(4,'8858958',2,35000,'2022-12-02'),(5,'5012543',2,1250,'2023-05-17'),(6,'7750282',2,1000,'2024-06-07'),(7,'8758385',2,7550,'2024-07-01'),(8,'8758385',3,7250,'2023-01-22'),(9,'8858958',3,2500,'2024-07-05'),(10,'7028748',4,59050,'2023-03-20'),(11,'7750282',4,37200,'2024-03-12'),(12,'5012543',4,4500,'2024-05-14'),(13,'7750282',5,50000,'2023-09-19'),(14,'7028748',5,670000,'2023-11-10'),(15,'8758385',5,35000,'2024-04-15'),(16,'8858958',5,25000,'2024-06-12');
/*!40000 ALTER TABLE `partners_products` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `product_type`
--

DROP TABLE IF EXISTS `product_type`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `product_type` (
  `id_product_type` int NOT NULL AUTO_INCREMENT,
  `name_product_type` varchar(50) NOT NULL,
  `coefficient_product_type` double(3,2) NOT NULL,
  PRIMARY KEY (`id_product_type`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `product_type`
--

LOCK TABLES `product_type` WRITE;
/*!40000 ALTER TABLE `product_type` DISABLE KEYS */;
INSERT INTO `product_type` VALUES (1,'Ламинат',2.35),(2,'Массивная доска',5.15),(3,'Паркетная доска',4.34),(4,'Пробковое покрытие',1.50);
/*!40000 ALTER TABLE `product_type` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `products`
--

DROP TABLE IF EXISTS `products`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `products` (
  `article_product` char(7) NOT NULL,
  `id_product_type` int NOT NULL,
  `name_product` varchar(255) NOT NULL,
  `min_cost` double(6,2) NOT NULL,
  PRIMARY KEY (`article_product`),
  KEY `id_product_type` (`id_product_type`),
  CONSTRAINT `products_ibfk_1` FOREIGN KEY (`id_product_type`) REFERENCES `product_type` (`id_product_type`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `products`
--

LOCK TABLES `products` WRITE;
/*!40000 ALTER TABLE `products` DISABLE KEYS */;
INSERT INTO `products` VALUES ('5012543',4,'Пробковое напольное клеевое покрытие 32 класс 4 мм',5450.59),('7028748',1,'Ламинат Дуб серый 32 класс 8 мм с фаской',3890.41),('7750282',1,'Ламинат Дуб дымчато-белый 33 класс 12 мм',1799.33),('8758385',3,'Паркетная доска Ясень темный однополосная 14 мм',4456.90),('8858958',3,'Инженерная доска Дуб Французская елка однополосная 12 мм',7330.99);
/*!40000 ALTER TABLE `products` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2025-01-15 18:12:41
