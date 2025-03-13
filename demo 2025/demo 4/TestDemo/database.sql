CREATE DATABASE  IF NOT EXISTS `testdemo` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `testdemo`;
-- MySQL dump 10.13  Distrib 8.0.36, for Win64 (x86_64)
--
-- Host: localhost    Database: testdemo
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
-- Table structure for table `categories`
--

DROP TABLE IF EXISTS `categories`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `categories` (
  `id_category` int NOT NULL AUTO_INCREMENT,
  `name_category` varchar(100) NOT NULL,
  PRIMARY KEY (`id_category`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `categories`
--

LOCK TABLES `categories` WRITE;
/*!40000 ALTER TABLE `categories` DISABLE KEYS */;
INSERT INTO `categories` VALUES (1,'Букеты'),(2,'В горшке'),(3,'Горшки');
/*!40000 ALTER TABLE `categories` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `manufacters`
--

DROP TABLE IF EXISTS `manufacters`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `manufacters` (
  `id_manufacter` int NOT NULL AUTO_INCREMENT,
  `name_manufacter` varchar(100) NOT NULL,
  PRIMARY KEY (`id_manufacter`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `manufacters`
--

LOCK TABLES `manufacters` WRITE;
/*!40000 ALTER TABLE `manufacters` DISABLE KEYS */;
INSERT INTO `manufacters` VALUES (1,'GardenPlast'),(2,'Gloria Garden'),(3,'InGreen'),(4,'Santino'),(5,'Цветочный сад');
/*!40000 ALTER TABLE `manufacters` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `orders`
--

DROP TABLE IF EXISTS `orders`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `orders` (
  `id_order` int NOT NULL AUTO_INCREMENT,
  `date_order` date NOT NULL,
  `date_delivery` date NOT NULL,
  `id_point` int NOT NULL,
  `surname_client` varchar(100) DEFAULT NULL,
  `name_client` varchar(100) DEFAULT NULL,
  `patronymic_client` varchar(100) DEFAULT NULL,
  `code_order` int NOT NULL,
  `status_order` varchar(100) NOT NULL,
  PRIMARY KEY (`id_order`),
  KEY `id_point` (`id_point`),
  CONSTRAINT `orders_ibfk_1` FOREIGN KEY (`id_point`) REFERENCES `points` (`id_point`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `orders`
--

LOCK TABLES `orders` WRITE;
/*!40000 ALTER TABLE `orders` DISABLE KEYS */;
INSERT INTO `orders` VALUES (1,'2022-05-14','2022-05-20',1,NULL,NULL,NULL,901,'Завершен'),(2,'2022-05-16','2022-05-22',11,'Николаев','Даниил','Денисович',902,'Новый'),(3,'2022-05-16','2022-05-22',2,'Сазонов','Руслан','Германович',903,'Новый'),(4,'2022-05-19','2022-05-25',11,'Одинцов','Серафим','Артёмович',904,'Новый'),(5,'2022-05-19','2022-05-25',2,'Степанов','Михаил','Артёмович',905,'Новый'),(6,'2022-05-20','2022-05-26',15,NULL,NULL,NULL,906,'Новый'),(7,'2022-05-22','2022-05-28',3,NULL,NULL,NULL,907,'Новый'),(8,'2022-05-22','2022-05-28',19,NULL,NULL,NULL,908,'Новый'),(9,'2022-05-24','2022-05-30',5,NULL,NULL,NULL,909,'Новый'),(10,'2022-05-24','2022-05-30',19,NULL,NULL,NULL,910,'Завершен');
/*!40000 ALTER TABLE `orders` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `points`
--

DROP TABLE IF EXISTS `points`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `points` (
  `id_point` int NOT NULL AUTO_INCREMENT,
  `index_point` int NOT NULL,
  `city_point` varchar(100) NOT NULL,
  `street_point` varchar(100) NOT NULL,
  `home_point` varchar(100) NOT NULL,
  PRIMARY KEY (`id_point`)
) ENGINE=InnoDB AUTO_INCREMENT=37 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `points`
--

LOCK TABLES `points` WRITE;
/*!40000 ALTER TABLE `points` DISABLE KEYS */;
INSERT INTO `points` VALUES (1,344288,'г. Лесной','ул. Чехова','1'),(2,614164,'г.Лесной','  ул. Степная','30'),(3,394242,'г. Лесной','ул. Коммунистическая','43'),(4,660540,'г. Лесной','ул. Солнечная','25'),(5,125837,'г. Лесной','ул. Шоссейная','40'),(6,125703,'г. Лесной','ул. Партизанская','49'),(7,625283,'г. Лесной','ул. Победы','46'),(8,614611,'г. Лесной','ул. Молодежная','50'),(9,454311,'г.Лесной','ул. Новая','19'),(10,660007,'г.Лесной','ул. Октябрьская','19'),(11,603036,'г. Лесной','ул. Садовая','4'),(12,450983,'г.Лесной','ул. Комсомольская','26'),(13,394782,'г. Лесной','ул. Чехова','3'),(14,603002,'г. Лесной','ул. Дзержинского','28'),(15,450558,'г. Лесной','ул. Набережная','30'),(16,394060,'г.Лесной','ул. Фрунзе','43'),(17,410661,'г. Лесной','ул. Школьная','50'),(18,625590,'г. Лесной','ул. Коммунистическая','20'),(19,625683,'г. Лесной','ул. 8 Марта','8'),(20,400562,'г. Лесной','ул. Зеленая','32'),(21,614510,'г. Лесной','ул. Маяковского','47'),(22,410542,'г. Лесной','ул. Светлая','46'),(23,620839,'г. Лесной','ул. Цветочная','8'),(24,443890,'г. Лесной','ул. Коммунистическая','1'),(25,603379,'г. Лесной','ул. Спортивная','46'),(26,603721,'г. Лесной','ул. Гоголя','41'),(27,410172,'г. Лесной','ул. Северная','13'),(28,420151,'г. Лесной','ул. Вишневая','32'),(29,125061,'г. Лесной','ул. Подгорная','8'),(30,630370,'г. Лесной','ул. Шоссейная','24'),(31,614753,'г. Лесной','ул. Полевая','35'),(32,426030,'г. Лесной','ул. Маяковского','44'),(33,450375,'г. Лесной','ул. Клубная','44'),(34,625560,'г. Лесной','ул. Некрасова','12'),(35,630201,'г. Лесной','ул. Комсомольская','17'),(36,190949,'г. Лесной','ул. Мичурина','26');
/*!40000 ALTER TABLE `points` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `products`
--

DROP TABLE IF EXISTS `products`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `products` (
  `article_product` varchar(100) NOT NULL,
  `name_product` varchar(100) NOT NULL,
  `unit_product` varchar(10) NOT NULL,
  `cost_product` int NOT NULL,
  `max_discount` int NOT NULL,
  `id_manufacter` int NOT NULL,
  `id_supplier` int NOT NULL,
  `id_category` int NOT NULL,
  `now_discount` int NOT NULL,
  `quantity_product` int NOT NULL,
  `desc_product` text NOT NULL,
  `image_product` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`article_product`),
  KEY `id_manufacter` (`id_manufacter`),
  KEY `id_supplier` (`id_supplier`),
  KEY `id_category` (`id_category`),
  CONSTRAINT `products_ibfk_1` FOREIGN KEY (`id_manufacter`) REFERENCES `manufacters` (`id_manufacter`),
  CONSTRAINT `products_ibfk_2` FOREIGN KEY (`id_supplier`) REFERENCES `suppliers` (`id_supplier`),
  CONSTRAINT `products_ibfk_3` FOREIGN KEY (`id_category`) REFERENCES `categories` (`id_category`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `products`
--

LOCK TABLES `products` WRITE;
/*!40000 ALTER TABLE `products` DISABLE KEYS */;
INSERT INTO `products` VALUES ('A357H6','Цветок в горшке','шт.',222,15,3,2,2,3,2,'Суккулент микс 5х15см',NULL),('A357H7','qweqwertyuiop[','шт.',1267,12,1,1,1,12,12,'qweqwe',NULL),('B653G6','Цветок в горшке','шт.',171,30,5,1,2,2,9,'Пуансеттия микс 13 см',NULL),('C346F5','Цветок в горшке','шт.',177,15,4,2,2,5,4,'Хамедорея Бридбл 9х35 см','C346F5.jpg'),('C638J8','Цветок в горшке','шт.',222,10,2,2,2,2,15,'Многолетнее растение Пуансеттия микс',NULL),('D325D4','Горшок','шт.',292,10,4,1,3,2,12,'Горшок Santino с автополивом Arte-dea 14.7 x 17 см бледно-зеленый','D325D4.jpg'),('F256G6','Цветок в горшке','шт.',577,30,3,1,2,3,2,'Орхидея Фаленопсис промо ø12 h40 - 55 см','F256G6.jpg'),('F325D4','Горшок с поддоном','шт.',984,5,2,2,3,4,3,'Gloria Garden Горшок с поддоном Гербера br59951 (Набор)','F325D4.jpg'),('F537H7','Цветок в горшке','шт.',277,5,5,1,2,3,6,'Многолетнее растение Пуансеттия микс Айс Пунш h20см',NULL),('G432G6','Букет','шт.',910,6,5,2,1,3,3,'Букет из 9 красных роз длиной 50 см в крафте','G432G6.jpg'),('G543F5','Цветок в горшке','шт.',533,15,2,1,2,3,6,'Замиокулькас 12х30 см',NULL),('G632H6','Цветок в горшке','шт.',390,6,4,1,2,2,8,'Цикламен 15х35 см',NULL),('G634F5','Цветок в горшке','шт.',111,5,5,1,2,2,15,'Пуансеттия Промо красная 10х30 см',NULL),('G643F4','Цветок в горшке','шт.',455,10,4,2,2,3,24,'Орхидея Фаленопсис микс 1 стебель ø12 h50 см',NULL),('G643F5','Цветок в горшке','шт.',355,10,1,1,2,5,1,'Фиттония микс 8х10 см',NULL),('G689G5','Цветок в горшке','шт.',145,15,1,1,2,4,3,'Драцена маргината 11х50 см',NULL),('G843H5','Кашпо','шт.',335,15,1,1,3,3,9,'Кашпо «Орхидея», 1,6 л, 14 х 14 см','G843H5.jpg'),('H346F5','Цветок в горшке','шт.',133,6,3,2,2,3,5,'Каланхое микс h11см',NULL),('H436H7','Цветок в горшке','шт.',298,10,5,2,2,4,23,'Пуансеттия, 15х35см',NULL),('H475R5','Цветок в горшке','шт.',398,5,3,2,2,3,12,'Орхидея Фаленопсис микро h20см',NULL),('H542F5','Искусственные цветы','шт.',400,10,5,1,1,2,5,'Искусственные цветы подсолнух/Искусственные цветы для декора','H542F5.jpg'),('J326V5','Цветок в горшке','шт.',211,5,1,2,2,4,4,'Плант микс 9х25 см',NULL),('J532V5','Цветок в горшке','шт.',185,15,5,1,2,2,6,'Пуансеттия, 30х12 см','J532V5.jpg'),('J632F6','Цветок в горшке','шт.',288,5,1,2,2,3,6,'Спатифиллиум Чопин 9х35 см',NULL),('J735J7','Цветок в горшке','шт.',262,15,5,2,2,3,4,'Пуансеттия микс 15 см',NULL),('K532T5','Цветок в горшке','шт.',111,30,4,2,2,5,7,'Кактус грузони шаровидный микс 5х8 см',NULL),('L732G6','Цветок в горшке','шт.',150,5,5,1,2,4,9,'Каланхое \"Каландива\" микс',NULL),('M642E5','Цветок в горшке','шт.',111,10,3,2,2,5,2,'Кактус микс 5х10 см',NULL),('R635F5','Цветок в горшке','шт.',188,6,5,2,2,3,7,'Кактус мамиллярия 5х14 см',NULL),('S432T5','Кашпо','шт.',309,5,3,2,3,3,15,'Кашпо InGreen Фиджи ING1555, 5 л, 23х20.8 см шоколадный','S432T5.jpg'),('А112Т4','Кашпо','шт.',300,30,1,2,3,5,6,'Кашпо GardenPlast Лаванда 14 х 26 см фиолетовый','А112Т4.jpg');
/*!40000 ALTER TABLE `products` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `productsorder`
--

DROP TABLE IF EXISTS `productsorder`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `productsorder` (
  `id_order` int NOT NULL,
  `article_product` varchar(100) NOT NULL,
  `count_product` int NOT NULL,
  PRIMARY KEY (`id_order`,`article_product`),
  KEY `article_product` (`article_product`),
  CONSTRAINT `productsorder_ibfk_1` FOREIGN KEY (`id_order`) REFERENCES `orders` (`id_order`),
  CONSTRAINT `productsorder_ibfk_2` FOREIGN KEY (`article_product`) REFERENCES `products` (`article_product`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `productsorder`
--

LOCK TABLES `productsorder` WRITE;
/*!40000 ALTER TABLE `productsorder` DISABLE KEYS */;
INSERT INTO `productsorder` VALUES (1,'G843H5',2),(1,'А112Т4',2),(2,'D325D4',3),(2,'S432T5',3),(3,'F325D4',1),(3,'G432G6',1),(4,'C346F5',1),(4,'H542F5',5),(5,'G643F4',5),(5,'J326V5',5),(6,'G634F5',2),(6,'R635F5',2),(7,'G643F5',1),(7,'G689G5',1),(8,'A357H6',10),(8,'K532T5',10),(9,'C638J8',5),(9,'F537H7',4),(10,'H346F5',20),(10,'L732G6',20);
/*!40000 ALTER TABLE `productsorder` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `roles`
--

DROP TABLE IF EXISTS `roles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `roles` (
  `id_role` int NOT NULL AUTO_INCREMENT,
  `name_role` varchar(100) NOT NULL,
  PRIMARY KEY (`id_role`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `roles`
--

LOCK TABLES `roles` WRITE;
/*!40000 ALTER TABLE `roles` DISABLE KEYS */;
INSERT INTO `roles` VALUES (1,'Администратор'),(2,'Клиент'),(3,'Менеджер');
/*!40000 ALTER TABLE `roles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `suppliers`
--

DROP TABLE IF EXISTS `suppliers`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `suppliers` (
  `id_supplier` int NOT NULL AUTO_INCREMENT,
  `name_supplier` varchar(100) NOT NULL,
  PRIMARY KEY (`id_supplier`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `suppliers`
--

LOCK TABLES `suppliers` WRITE;
/*!40000 ALTER TABLE `suppliers` DISABLE KEYS */;
INSERT INTO `suppliers` VALUES (1,'Мир цветов'),(2,'Цветовик');
/*!40000 ALTER TABLE `suppliers` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `users`
--

DROP TABLE IF EXISTS `users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `users` (
  `id_user` int NOT NULL AUTO_INCREMENT,
  `id_role` int NOT NULL,
  `surname_user` varchar(100) NOT NULL,
  `name_user` varchar(100) NOT NULL,
  `patronymic_user` varchar(100) NOT NULL,
  `login_user` varchar(100) NOT NULL,
  `password_user` varchar(100) NOT NULL,
  PRIMARY KEY (`id_user`),
  KEY `id_role` (`id_role`),
  CONSTRAINT `users_ibfk_1` FOREIGN KEY (`id_role`) REFERENCES `roles` (`id_role`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `users`
--

LOCK TABLES `users` WRITE;
/*!40000 ALTER TABLE `users` DISABLE KEYS */;
INSERT INTO `users` VALUES (1,1,'Калачева','Валерия','Даниловна','zpv1r94d5ous@gmail.com','2L6KZG'),(2,1,'Макарова','Вероника','Евгеньевна','9eln76uth4iz@mail.com','uzWC67'),(3,1,'Михайлова','Василиса','Ярославовна','60f2ix5d4zbu@tutanota.com','8ntwUp'),(4,3,'Горшков','Марк','Матвеевич','ridvnptec8ym@yahoo.com','YOyhfR'),(5,3,'Смирнов','Данила','Артёмович','dt3ifc1qz4kw@mail.com','RSbvHv'),(6,3,'Зимин','Михаил','Филиппович','co30fa4np6se@mail.com','rwVDh9'),(7,2,'Николаев','Даниил','Денисович','arucwkyzls62@outlook.com','LdNyos'),(8,2,'Сазонов','Руслан','Германович','nmxos1diph5e@tutanota.com','gynQMT'),(9,2,'Одинцов','Серафим','Артёмович','xbvi3ktjde7c@yahoo.com','AtnDjr'),(10,2,'Степанов','Михаил','Артёмович','lqgbwpmrc3do@tutanota.com','JlFRCZ');
/*!40000 ALTER TABLE `users` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2025-03-10 13:57:49
