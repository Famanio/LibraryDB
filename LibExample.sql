-- Adminer 4.8.1 MySQL 8.0.30 dump

SET NAMES utf8;
SET time_zone = '+00:00';
SET foreign_key_checks = 0;
SET sql_mode = 'NO_AUTO_VALUE_ON_ZERO';

SET NAMES utf8mb4;

DROP DATABASE IF EXISTS `Library`;
CREATE DATABASE `Library` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `Library`;

DELIMITER ;;

CREATE PROCEDURE `BookChange`(IN `currentID` INT, IN `newID` INT, IN `bookGenre` VARCHAR(64), IN `bookEdition` VARCHAR(64), IN `bookAgeRat` VARCHAR(16), IN `bookLocation` VARCHAR(64), IN `bookISBN` VARCHAR(32), IN `bookPublisher` VARCHAR(255), IN `bookAuthor` VARCHAR(255), IN `bookName` VARCHAR(255), IN `bookPubDate` DATE, IN `bookNumOfPage` INT, IN `bookCost` FLOAT, IN `bookAmount` INT)
BEGIN
	DECLARE genreID INT;
    DECLARE editionID INT;
    DECLARE ratingID INT;
    
	SELECT genre_id INTO genreID FROM Genre WHERE LOCATE(bookGenre, Genre.genre) >= 1;

 	SELECT edition_id INTO editionID FROM Edition WHERE LOCATE(bookEdition, Edition.type) >= 1;

	SELECT rating_id INTO ratingID FROM Rating WHERE LOCATE(bookAgeRat, Rating.age_rating) >= 1;
    
    IF NOT EXISTS (SELECT * FROM Storage WHERE LOCATE(bookLocation, CONCAT_WS(" ", storage_id, location)) >= 1) THEN
    INSERT INTO Storage (storage_id, location) VALUES (NULL, bookLocation);
    END IF;

	UPDATE Books SET book_id = newID, genre_id = genreID, edition_id = editionID, rating_id = ratingID, storage_id = (SELECT storage_id FROM Storage WHERE location = bookLocation), ISBN = bookISBN, publisher = bookPublisher, author = bookAuthor, book_name = bookName, pub_date = bookPubDate, num_of_page = bookNumOfPage, cost = bookCost, amount = bookAmount WHERE Books.book_id = currentID;
END;;

CREATE PROCEDURE `BookInsert`(IN `bookGenre` VARCHAR(64), IN `bookEdition` VARCHAR(64), IN `bookAgeRat` VARCHAR(16), IN `bookLocation` VARCHAR(64), IN `bookISBN` VARCHAR(32), IN `bookPublisher` VARCHAR(255), IN `bookAuthor` VARCHAR(255), IN `bookName` VARCHAR(255), IN `bookPubDate` DATE, IN `bookNumOfPage` INT, IN `bookCost` FLOAT, IN `bookAmount` INT)
BEGIN
	DECLARE genreID INT;
    DECLARE editionID INT;
    DECLARE ratingID INT;
    
 	SELECT genre_id INTO genreID FROM Genre WHERE LOCATE(bookGenre, Genre.genre) >= 1;

 	SELECT edition_id INTO editionID FROM Edition WHERE LOCATE(bookEdition, Edition.type) >= 1;

	SELECT rating_id INTO ratingID FROM Rating WHERE LOCATE(bookAgeRat, Rating.age_rating) >= 1;
    
    IF NOT EXISTS (SELECT * FROM Storage WHERE LOCATE(bookLocation, CONCAT_WS(" ", storage_id, location)) >= 1) THEN
    INSERT INTO Storage (storage_id, location) VALUES (NULL, bookLocation);
    END IF;

INSERT INTO Books (book_id, genre_id, edition_id, rating_id, storage_id, ISBN, publisher, author, book_name, pub_date, num_of_page, cost, amount) VALUES (NULL, genreID, editionID, ratingID, (SELECT storage_id FROM Storage WHERE location = bookLocation), bookISBN, bookPublisher, bookAuthor, bookName, bookPubDate, bookNumOfPage, bookCost, bookAmount);

END;;

CREATE PROCEDURE `BookLendingChange`(IN `currentLendingID` INT, IN `lendingID` INT, IN `librarianInfo` VARCHAR(255), IN `readerInfo` VARCHAR(255), IN `bookInfo` VARCHAR(255), IN `lendingAmount` INT, IN `issueDate` DATE, IN `returnDate` DATE)
BEGIN
	DECLARE librarianID INT;
    DECLARE readerID INT;
    DECLARE bookID INT;
    
	SELECT lib_id INTO librarianID FROM Librarian WHERE LOCATE(librarianInfo, CONCAT_WS(" ", lib_id, surname, name, patronymic)) >= 1;

    SELECT reader_id INTO readerID FROM Reader WHERE LOCATE(readerInfo, CONCAT_WS(" ", reader_id, surname, name, patronymic)) >= 1;
    
    SELECT book_id INTO bookID FROM Books WHERE LOCATE(bookInfo, CONCAT_WS(" ", book_name, ISBN)) >= 1;

    UPDATE Book_lending SET lending_id = lendingID, librarian_id = librarianID, reader_id = readerID, book_id = bookID, lend_amount = lendingAmount, date_of_issue = issueDate, return_date = returnDate WHERE lending_id = currentLendingID;

END;;

CREATE PROCEDURE `BookLendingInsert`(IN `librarianInfo` VARCHAR(255), IN `readerInfo` VARCHAR(255), IN `bookInfo` VARCHAR(255), IN `lendAmount` INT, IN `returnDate` DATE)
BookLendingInsert:BEGIN
	DECLARE librarianID INT;
    DECLARE readerID INT;
    DECLARE bookID INT;
    
	SELECT lib_id INTO librarianID FROM Librarian WHERE LOCATE(librarianInfo, CONCAT_WS(" ", lib_id, surname, name, patronymic)) >= 1;

    SELECT reader_id INTO readerID FROM Reader WHERE LOCATE(readerInfo, CONCAT_WS(" ", reader_id, surname, name, patronymic)) >= 1;
    
    SELECT book_id INTO bookID FROM Books WHERE LOCATE(bookInfo, CONCAT_WS(" ", book_name, ISBN)) >= 1;
    
    INSERT INTO Book_lending (lending_id, librarian_id, reader_id, book_id, lend_amount, date_of_issue, return_date) VALUES (NULL, librarianID, readerID, bookID, lendAmount, NOW(), returnDate);
    
END;;

CREATE PROCEDURE `BookLendingSearch`(IN `searchQuery` VARCHAR(255))
BEGIN
	SELECT lending_id AS "ID выдачи", CONCAT_WS(" ",Librarian.surname, Librarian.name, Librarian.patronymic) AS "Библиотекарь", CONCAT_WS(" ",Reader.surname, Reader.name, Reader.patronymic) AS "Читатель", Books.book_name AS "Книга", lend_amount AS "Кол-во", DATE_FORMAT(date_of_issue, '%d.%m.%Y') AS "Дата выдачи", DATE_FORMAT(return_date, '%d.%m.%Y') AS "Дата возврата" FROM Book_lending 
	INNER JOIN Librarian ON Librarian.lib_id = Book_lending.librarian_id
	INNER JOIN Reader ON Reader.reader_id = Book_lending.reader_id
	INNER JOIN Books ON Books.book_id = Book_lending.book_id
	WHERE LOCATE(searchQuery, CONCAT_WS(" ", lending_id, Librarian.surname, Librarian.name, Librarian.patronymic, Reader.surname, Reader.name, Reader.patronymic, Books.book_name, lend_amount, date_of_issue, DATE_FORMAT(date_of_issue, '%d.%m.%Y'), DATE_FORMAT(return_date, '%d.%m.%Y'))) >= 1 ORDER BY return_date;
END;;

CREATE PROCEDURE `BookSearch`(IN `searchQuery` VARCHAR(255))
BEGIN
SELECT 
book_id AS "ID книги",
book_name AS "Название книги",
author AS "Автор", 
Genre.genre AS "Жанр", 
Edition.type AS "Издание", 
Rating.age_rating AS "Возрастной рейтинг",
Storage.location AS "Расположениие", 
ISBN AS "ISBN", 
publisher AS "Издатель", 
DATE_FORMAT(pub_date, '%d.%m.%Y') AS "Дата издания", 
num_of_page AS "Кол-во стр.", 
cost AS "Стоимость (руб.)", 
amount AS "Кол-во" 
FROM Books
	INNER JOIN Genre ON Genre.genre_id = Books.genre_id
	INNER JOIN Edition ON Edition.edition_id = Books.edition_id
    INNER JOIN Rating ON Rating.rating_id = Books.rating_id
	INNER JOIN Storage ON Storage.storage_id = Books.storage_id
WHERE LOCATE(searchQuery, CONCAT_WS(" ", book_id, book_name, author, Genre.genre, Edition.type, Rating.age_rating, Storage.location, ISBN, publisher, DATE_FORMAT(pub_date, '%d.%m.%Y'), num_of_page, cost, amount)) >= 1
ORDER BY Books.book_name;
END;;

CREATE PROCEDURE `SelectBookByID`(IN `ID` INT)
BEGIN
SELECT 
book_id,
book_name,
author, 
Genre.genre, 
Edition.type, 
Rating.age_rating,
Storage.location, 
ISBN, 
publisher, 
DATE_FORMAT(pub_date, '%d.%m.%Y'), 
num_of_page, 
cost, 
amount
FROM Books
	INNER JOIN Genre ON Genre.genre_id = Books.genre_id
	INNER JOIN Edition ON Edition.edition_id = Books.edition_id
    INNER JOIN Rating ON Rating.rating_id = Books.rating_id
	INNER JOIN Storage ON Storage.storage_id = Books.storage_id
WHERE book_id = ID;
END;;

CREATE PROCEDURE `SelectBookLending`()
BEGIN
	SELECT lending_id AS "ID выдачи", CONCAT_WS(" ",Librarian.surname, Librarian.name, Librarian.patronymic) AS "Библиотекарь", CONCAT_WS(" ",Reader.surname, Reader.name, Reader.patronymic) AS "Читатель", Books.book_name AS "Книга", lend_amount AS "Кол-во", DATE_FORMAT(date_of_issue, '%d.%m.%Y') AS "Дата выдачи", DATE_FORMAT(return_date, '%d.%m.%Y') AS "Дата возврата" FROM Book_lending
	INNER JOIN Librarian ON Librarian.lib_id = Book_lending.librarian_id
	INNER JOIN Reader ON Reader.reader_id = Book_lending.reader_id
	INNER JOIN Books ON Books.book_id = Book_lending.book_id
ORDER BY return_date;
END;;

CREATE PROCEDURE `SelectBookLendingByID`(IN `ID` INT)
BEGIN
SELECT lending_id, CONCAT_WS(" ",Librarian.surname, Librarian.name, Librarian.patronymic), CONCAT_WS(" ",Reader.surname, Reader.name, Reader.patronymic), Books.book_name, lend_amount, DATE_FORMAT(date_of_issue, '%d.%m.%Y'), DATE_FORMAT(return_date, '%d.%m.%Y') FROM Book_lending
	INNER JOIN Librarian ON Librarian.lib_id = Book_lending.librarian_id
	INNER JOIN Reader ON Reader.reader_id = Book_lending.reader_id
	INNER JOIN Books ON Books.book_id = Book_lending.book_id
WHERE lending_id = ID;
END;;

CREATE PROCEDURE `SelectBooks`()
    COMMENT 'Выбор книг с заменой FKeys'
BEGIN
SELECT 
book_id AS "ID книги",
book_name AS "Название книги",
author AS "Автор", 
Genre.genre AS "Жанр", 
Edition.type AS "Издание", 
Rating.age_rating AS "Возрастной рейтинг",
Storage.location AS "Расположениие", 
ISBN AS "ISBN", 
publisher AS "Издатель", 
DATE_FORMAT(pub_date, '%d.%m.%Y') AS "Дата издания", 
num_of_page AS "Кол-во стр.", 
cost AS "Стоимость (руб.)", 
amount AS "Кол-во" 
FROM Books
	INNER JOIN Genre ON Genre.genre_id = Books.genre_id
	INNER JOIN Edition ON Edition.edition_id = Books.edition_id
    INNER JOIN Rating ON Rating.rating_id = Books.rating_id
	INNER JOIN Storage ON Storage.storage_id = Books.storage_id
ORDER BY Books.book_name;
END;;

CREATE PROCEDURE `SelectDebtors`()
BEGIN
SELECT CONCAT_WS(" ",Reader.surname, Reader.name, Reader.patronymic) AS "Должник", DATE_FORMAT(date_of_issue, '%d.%m.%Y') AS "Дата выдачи", DATE_FORMAT(return_date, 	'%d.%m.%Y') AS "Дата возврата", TIMESTAMPDIFF(DAY, return_date, NOW()) AS "Задолжность (дн.)" FROM Book_lending
	INNER JOIN Librarian ON Librarian.lib_id = Book_lending.librarian_id
	INNER JOIN Reader ON Reader.reader_id = Book_lending.reader_id
	INNER JOIN Books ON Books.book_id = Book_lending.book_id
WHERE TIMESTAMPDIFF(DAY, return_date, NOW()) > 0
ORDER BY TIMESTAMPDIFF(DAY, return_date, NOW()) DESC;
END;;

CREATE PROCEDURE `SelectEndedBooks`()
BEGIN
	SELECT book_id AS "ID книги", book_name AS "Название книги", author AS "Автор", Genre.genre AS "Жанр", Edition.type AS "Издание", Rating.age_rating AS "Возрастной рейтинг", Storage.location AS "Расположениие", ISBN AS "ISBN", publisher AS "Издатель", DATE_FORMAT(pub_date, '%d.%m.%Y') AS "Дата издания", num_of_page AS "Кол-во стр.", cost AS "Стоимость (руб.)", amount AS "Кол-во" FROM Books INNER JOIN Genre ON Genre.genre_id = Books.genre_id INNER JOIN Edition ON Edition.edition_id = Books.edition_id INNER JOIN Rating ON Rating.rating_id = Books.rating_id INNER JOIN Storage ON Storage.storage_id = Books.storage_id WHERE amount = 0 ORDER BY Books.book_name;
END;;

CREATE PROCEDURE `SelectUnderageReaders`()
BEGIN
	SELECT CONCAT_WS(" ",surname, name, patronymic) AS "Читатель", DATE_FORMAT(date_of_birth, '%d.%m.%Y') AS "Дата рождения" FROM Reader WHERE TIMESTAMPDIFF(DAY, date_of_birth, NOW()) < 6570;
END;;

DELIMITER ;

DROP TABLE IF EXISTS `Book_lending`;
CREATE TABLE `Book_lending` (
  `lending_id` int NOT NULL AUTO_INCREMENT COMMENT 'ID записи выдачи',
  `librarian_id` int(8) unsigned zerofill NOT NULL COMMENT 'ID библиотекаря',
  `reader_id` int(8) unsigned zerofill NOT NULL COMMENT 'ID читателя',
  `book_id` int NOT NULL COMMENT 'ID выданной книги',
  `lend_amount` int unsigned NOT NULL COMMENT 'Выданное кол-во',
  `date_of_issue` date NOT NULL COMMENT 'Дата выдачи',
  `return_date` date NOT NULL COMMENT 'Дата возврата',
  PRIMARY KEY (`lending_id`),
  KEY `book_lending_ibfk_1` (`book_id`),
  KEY `librarian_id` (`librarian_id`),
  KEY `reader_id` (`reader_id`),
  CONSTRAINT `book_lending_ibfk_1` FOREIGN KEY (`book_id`) REFERENCES `Books` (`book_id`) ON DELETE RESTRICT ON UPDATE CASCADE,
  CONSTRAINT `book_lending_ibfk_2` FOREIGN KEY (`librarian_id`) REFERENCES `Librarian` (`lib_id`) ON DELETE RESTRICT ON UPDATE CASCADE,
  CONSTRAINT `book_lending_ibfk_3` FOREIGN KEY (`reader_id`) REFERENCES `Reader` (`reader_id`) ON DELETE RESTRICT ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='Выдача книг';

TRUNCATE `Book_lending`;
INSERT INTO `Book_lending` (`lending_id`, `librarian_id`, `reader_id`, `book_id`, `lend_amount`, `date_of_issue`, `return_date`) VALUES
(2,	00437036,	00000679,	8,	1,	'2022-11-13',	'2022-12-26'),
(5,	00000001,	08084508,	1,	1,	'2022-11-13',	'2022-12-07'),
(6,	00001346,	34667321,	5,	2,	'2022-12-13',	'2023-01-12'),
(7,	00000001,	02497498,	2,	20,	'2022-09-10',	'2022-12-12'),
(8,	00000023,	00000123,	6,	2,	'2022-12-13',	'2022-12-26');

DELIMITER ;;

CREATE TRIGGER `lending_after_insert` AFTER INSERT ON `Book_lending` FOR EACH ROW
UPDATE Books SET Books.amount = (Books.amount - new.lend_amount) WHERE Books.book_id = NEW.book_id;;

CREATE TRIGGER `lending_before_update` BEFORE UPDATE ON `Book_lending` FOR EACH ROW
UPDATE Books SET Books.amount = (Books.amount + OLD.lend_amount) 
WHERE Books.book_id = OLD.book_id;;

CREATE TRIGGER `lending_after_update` AFTER UPDATE ON `Book_lending` FOR EACH ROW
UPDATE Books SET Books.amount = (Books.amount - NEW.lend_amount) 
WHERE Books.book_id = NEW.book_id;;

CREATE TRIGGER `lending_before_delete` BEFORE DELETE ON `Book_lending` FOR EACH ROW
UPDATE Books SET Books.amount = (Books.amount + OLD.lend_amount) 
WHERE Books.book_id = OLD.book_id;;

DELIMITER ;

DROP TABLE IF EXISTS `Books`;
CREATE TABLE `Books` (
  `book_id` int NOT NULL AUTO_INCREMENT COMMENT 'ID книги',
  `genre_id` int NOT NULL COMMENT 'ID жанра',
  `edition_id` int NOT NULL COMMENT 'ID типа издания',
  `rating_id` int NOT NULL COMMENT 'ID возрастного рейтинга',
  `storage_id` int NOT NULL COMMENT 'ID склада',
  `ISBN` varchar(32) COLLATE utf8mb4_general_ci NOT NULL COMMENT 'Международный книжный код',
  `publisher` varchar(255) COLLATE utf8mb4_general_ci NOT NULL COMMENT 'Издатель',
  `author` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT 'Автор',
  `book_name` varchar(255) COLLATE utf8mb4_general_ci NOT NULL COMMENT 'Название книги',
  `pub_date` date NOT NULL COMMENT 'Дата публикации',
  `num_of_page` int NOT NULL COMMENT 'Кол-во стр.',
  `cost` float NOT NULL COMMENT 'Стоимость в рублях',
  `amount` int unsigned NOT NULL COMMENT 'Кол-во',
  PRIMARY KEY (`book_id`),
  KEY `books_ibfk_1` (`edition_id`),
  KEY `books_ibfk_5` (`rating_id`),
  KEY `books_ibfk_6` (`genre_id`),
  KEY `books_ibfk_7` (`storage_id`),
  CONSTRAINT `books_ibfk_1` FOREIGN KEY (`edition_id`) REFERENCES `Edition` (`edition_id`) ON DELETE RESTRICT ON UPDATE CASCADE,
  CONSTRAINT `books_ibfk_5` FOREIGN KEY (`rating_id`) REFERENCES `Rating` (`rating_id`) ON DELETE RESTRICT ON UPDATE CASCADE,
  CONSTRAINT `books_ibfk_6` FOREIGN KEY (`genre_id`) REFERENCES `Genre` (`genre_id`) ON DELETE RESTRICT ON UPDATE CASCADE,
  CONSTRAINT `books_ibfk_7` FOREIGN KEY (`storage_id`) REFERENCES `Storage` (`storage_id`) ON DELETE RESTRICT ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='Книги';

TRUNCATE `Books`;
INSERT INTO `Books` (`book_id`, `genre_id`, `edition_id`, `rating_id`, `storage_id`, `ISBN`, `publisher`, `author`, `book_name`, `pub_date`, `num_of_page`, `cost`, `amount`) VALUES
(1,	13,	1,	2,	5,	'978-5-699-52229-3',	'Эксбо',	'Пушкин Александр Сергеевич',	'Полное собрание стихотворений в одном томе',	'2012-01-01',	768,	399,	199),
(2,	4,	1,	3,	1,	'978-5-9268-2710-8',	'Речь',	'Лермонтов Михаил Юрьевич',	'Герой нашего времени',	'2018-01-01',	320,	450,	280),
(4,	4,	1,	3,	3,	'978-5-9268-2585-2',	'Речь',	'Толстой Лев Николаевич',	'Война и мир. В 4-х томах',	'2017-01-01',	336,	3000,	400),
(5,	4,	1,	4,	3,	'978-5-9268-2545-6',	'Речь',	'Достоевский Федор Михайлович',	'Преступление и наказание',	'2017-01-01',	512,	540,	148),
(6,	4,	1,	3,	6,	'978-5-17-089255-6',	'АСТ',	'Тургенев Иван Сергеевич',	'Отцы и дети',	'2022-01-01',	288,	250,	298),
(8,	6,	1,	1,	6,	'978-5-45-732284-4',	'Азбука',	'Куприн Александр Иванович',	'Куст сирени',	'2020-01-01',	10,	100,	0);

DROP TABLE IF EXISTS `Edition`;
CREATE TABLE `Edition` (
  `edition_id` int NOT NULL AUTO_INCREMENT COMMENT 'Код издания',
  `type` varchar(64) COLLATE utf8mb4_general_ci NOT NULL COMMENT 'Тип издания',
  PRIMARY KEY (`edition_id`),
  UNIQUE KEY `type` (`type`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='Издание';

TRUNCATE `Edition`;
INSERT INTO `Edition` (`edition_id`, `type`) VALUES
(5,	'Журнал'),
(2,	'Справочник'),
(3,	'Учебник'),
(1,	'Художественная литература'),
(4,	'Энциклопедия');

DROP TABLE IF EXISTS `Genre`;
CREATE TABLE `Genre` (
  `genre_id` int NOT NULL AUTO_INCREMENT COMMENT 'Код жанра',
  `genre` varchar(64) COLLATE utf8mb4_general_ci NOT NULL COMMENT 'Название жанра',
  PRIMARY KEY (`genre_id`),
  UNIQUE KEY `genre` (`genre`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='Жанр';

TRUNCATE `Genre`;
INSERT INTO `Genre` (`genre_id`, `genre`) VALUES
(3,	'Драма'),
(1,	'Комедия'),
(8,	'Легенда'),
(9,	'Научная литература'),
(12,	'Научно-популярная литература'),
(5,	'Повесть'),
(6,	'Рассказ'),
(4,	'Роман'),
(7,	'Сказка'),
(11,	'Справочная литература'),
(13,	'Стих'),
(2,	'Трагедия'),
(10,	'Учебная литература');

DROP TABLE IF EXISTS `Librarian`;
CREATE TABLE `Librarian` (
  `lib_id` int(8) unsigned zerofill NOT NULL COMMENT 'ID библиотекаря',
  `surname` varchar(64) COLLATE utf8mb4_general_ci NOT NULL COMMENT 'Фамилия',
  `name` varchar(64) COLLATE utf8mb4_general_ci NOT NULL COMMENT 'Имя',
  `patronymic` varchar(64) COLLATE utf8mb4_general_ci NOT NULL COMMENT 'Отчество',
  PRIMARY KEY (`lib_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='Библиотекари';

TRUNCATE `Librarian`;
INSERT INTO `Librarian` (`lib_id`, `surname`, `name`, `patronymic`) VALUES
(00000001,	'Ананьев',	'Евгений',	'Данилович'),
(00000002,	'Виноградова',	'Арина',	'Михайловна'),
(00000023,	'Швецова',	'Анна',	'Андреевна'),
(00001346,	'Чернов',	'Андрей',	'Вячеславович'),
(00437036,	'Осипов',	'Василий',	'Никитич');

DROP TABLE IF EXISTS `Rating`;
CREATE TABLE `Rating` (
  `rating_id` int NOT NULL AUTO_INCREMENT COMMENT 'ID рейтинга',
  `age_rating` varchar(16) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT 'Возрастной рейтинг',
  PRIMARY KEY (`rating_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='Возрастной рейтинг книги';

TRUNCATE `Rating`;
INSERT INTO `Rating` (`rating_id`, `age_rating`) VALUES
(1,	'0+'),
(2,	'6+'),
(3,	'12+'),
(4,	'16+'),
(5,	'18+'),
(6,	'Не определён');

DROP TABLE IF EXISTS `Reader`;
CREATE TABLE `Reader` (
  `reader_id` int(8) unsigned zerofill NOT NULL COMMENT 'ID читателя',
  `surname` varchar(64) COLLATE utf8mb4_general_ci NOT NULL COMMENT 'Фамилия',
  `name` varchar(64) COLLATE utf8mb4_general_ci NOT NULL COMMENT 'Имя',
  `patronymic` varchar(64) COLLATE utf8mb4_general_ci NOT NULL COMMENT 'Отчество',
  `date_of_birth` date NOT NULL COMMENT 'Дата рождения',
  `home_address` text COLLATE utf8mb4_general_ci NOT NULL COMMENT 'Дом. адресс',
  `phone_num` varchar(15) COLLATE utf8mb4_general_ci NOT NULL COMMENT 'Телефон',
  `reg_date` date NOT NULL COMMENT 'Дата рег.',
  PRIMARY KEY (`reader_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='Читатели';

TRUNCATE `Reader`;
INSERT INTO `Reader` (`reader_id`, `surname`, `name`, `patronymic`, `date_of_birth`, `home_address`, `phone_num`, `reg_date`) VALUES
(00000123,	'Тихонов',	'Руслан',	'Михайлович',	'1976-11-03',	'г. Уездный, ул. Степная, д.25, кв.14',	'+380712657871',	'2022-12-08'),
(00000679,	'Николаев',	'Роман',	'Никитич',	'2003-04-30',	'с. Огненное, д.17',	'0715988756',	'2022-09-30'),
(00004987,	'Овчинникова',	'Олеся',	'Романовна',	'2005-01-21',	'ул. Именная, д.7',	'+380714573434',	'2019-12-29'),
(00445986,	'Мельникова',	'Алиса',	'Кирилловна',	'1994-03-23',	'ул. Обычная, д.51б, кв. 113',	'071-675-76-67',	'2021-11-01'),
(01232351,	'Уткина',	'Марианна',	'Олеговна',	'1961-07-09',	'ул. Уставших студентов, д.5, кв.38',	'0715863729',	'2020-02-05'),
(02497498,	'Дорохов',	'Матвей',	'Тимофеевич',	'1985-11-01',	'с. Далёкое, ул. Ближняя, д.2',	'0714998712',	'2021-11-29'),
(08084508,	'Назаров',	'Роман',	'Тимурович',	'2008-08-14',	'пр-т. Уставших преподавателей, д.7, кв.11',	'0711234567',	'2022-12-01'),
(09874578,	'Гуляев',	'Артём',	'Львович',	'2010-06-08',	'пр-т Косой, д. 5б, кв. 17',	'0711883423',	'2022-12-13'),
(34667321,	'Никифоров',	'Александр',	'Даниилович',	'2006-08-09',	'ул. Очередная, д.45, кв.135',	'071-512-12-54',	'2022-12-12'),
(34667322,	'Никифоров',	'Арсений',	'Даниилович',	'2006-08-09',	'ул. Очередная, д.45, кв.135',	'071-512-12-55',	'2022-12-12');

DROP TABLE IF EXISTS `Storage`;
CREATE TABLE `Storage` (
  `storage_id` int NOT NULL AUTO_INCREMENT COMMENT 'Код места хранения',
  `location` varchar(64) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT 'Складское размещение',
  PRIMARY KEY (`storage_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='Хранение';

TRUNCATE `Storage`;
INSERT INTO `Storage` (`storage_id`, `location`) VALUES
(1,	'Зал: 1 стеллаж, 1 ряд, 1 полка. Склад: каб.11'),
(2,	'Зал: 1 стеллаж, 2 ряд, 1 полка. Склад: каб.13'),
(3,	'Зал: 2 стеллаж, 1 ряд, 1 полка. Склад: каб.13'),
(4,	'Зал: 2 стеллаж, 1 ряд, 2 полка. Склад: каб.14'),
(5,	'Зал: 3 стеллаж, 2 ряд, 1 полка. Склад: каб.14'),
(6,	'Зал: 1 стеллаж, 1 ряд, 2 полка. Склад: каб.11'),
(7,	'ца');

-- 2022-12-13 21:02:26
