-- MySQL Script generated by MySQL Workbench
-- 03/02/15 01:01:35
-- Model: New Model    Version: 1.0
-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL,ALLOW_INVALID_DATES';

-- -----------------------------------------------------
-- Schema sampdb
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema sampdb
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `sampdb` DEFAULT CHARACTER SET latin1 ;
USE `sampdb` ;

-- -----------------------------------------------------
-- Table `sampdb`.`absence`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `sampdb`.`absence` (
  `student_id` INT(10) UNSIGNED NOT NULL,
  `date` DATE NOT NULL,
  PRIMARY KEY (`student_id`, `date`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = latin1;


-- -----------------------------------------------------
-- Table `sampdb`.`apothegm`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `sampdb`.`apothegm` (
  `attribution` VARCHAR(40) NULL DEFAULT NULL,
  `phrase` TEXT NULL DEFAULT NULL,
  FULLTEXT INDEX `phrase` (`phrase` ASC),
  FULLTEXT INDEX `attribution` (`attribution` ASC),
  FULLTEXT INDEX `phrase_2` (`phrase` ASC, `attribution` ASC))
ENGINE = MyISAM
DEFAULT CHARACTER SET = latin1;


-- -----------------------------------------------------
-- Table `sampdb`.`grade_event`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `sampdb`.`grade_event` (
  `date` DATE NOT NULL,
  `category` ENUM('T','Q') NOT NULL,
  `event_id` INT(10) UNSIGNED NOT NULL AUTO_INCREMENT,
  PRIMARY KEY (`event_id`))
ENGINE = InnoDB
AUTO_INCREMENT = 9
DEFAULT CHARACTER SET = latin1;


-- -----------------------------------------------------
-- Table `sampdb`.`member`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `sampdb`.`member` (
  `member_id` INT(10) UNSIGNED NOT NULL AUTO_INCREMENT,
  `last_name` VARCHAR(20) NOT NULL,
  `first_name` VARCHAR(20) NOT NULL,
  `suffix` VARCHAR(5) NULL DEFAULT NULL,
  `expiration` DATE NULL DEFAULT NULL,
  `email` VARCHAR(100) NULL DEFAULT NULL,
  `street` VARCHAR(50) NULL DEFAULT NULL,
  `city` VARCHAR(50) NULL DEFAULT NULL,
  `state` VARCHAR(2) NULL DEFAULT NULL,
  `zip` VARCHAR(10) NULL DEFAULT NULL,
  `phone` VARCHAR(20) NULL DEFAULT NULL,
  `interests` VARCHAR(255) NULL DEFAULT NULL,
  PRIMARY KEY (`member_id`))
ENGINE = InnoDB
AUTO_INCREMENT = 104
DEFAULT CHARACTER SET = latin1;


-- -----------------------------------------------------
-- Table `sampdb`.`president`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `sampdb`.`president` (
  `last_name` VARCHAR(15) NOT NULL,
  `first_name` VARCHAR(15) NOT NULL,
  `suffix` VARCHAR(5) NULL DEFAULT NULL,
  `city` VARCHAR(20) NOT NULL,
  `state` VARCHAR(2) NOT NULL,
  `birth` DATE NOT NULL,
  `death` DATE NULL DEFAULT NULL,
  `pres_id` INT(10) UNSIGNED NOT NULL AUTO_INCREMENT,
  PRIMARY KEY (`pres_id`))
ENGINE = InnoDB
AUTO_INCREMENT = 45
DEFAULT CHARACTER SET = latin1;


-- -----------------------------------------------------
-- Table `sampdb`.`pres_term`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `sampdb`.`pres_term` (
  `pres_id` INT(10) UNSIGNED NOT NULL,
  `term_start_date` DATE NOT NULL,
  `term_End_date` DATE NULL DEFAULT NULL,
  `number_of_election_won` INT(11) NOT NULL,
  `reason_for_leaving_office` TEXT NULL DEFAULT NULL,
  `term_id` INT(10) UNSIGNED NOT NULL AUTO_INCREMENT,
  PRIMARY KEY (`pres_id`, `term_id`),
  INDEX `term_id` (`term_id` ASC),
  CONSTRAINT `pres_term_ibfk_1`
    FOREIGN KEY (`term_id`)
    REFERENCES `sampdb`.`president` (`pres_id`))
ENGINE = InnoDB
AUTO_INCREMENT = 45
DEFAULT CHARACTER SET = latin1;


-- -----------------------------------------------------
-- Table `sampdb`.`score`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `sampdb`.`score` (
  `student_id` INT(10) UNSIGNED NOT NULL,
  `event_id` INT(10) UNSIGNED NOT NULL,
  `score` INT(11) NOT NULL,
  PRIMARY KEY (`event_id`, `student_id`),
  INDEX `student_id` (`student_id` ASC))
ENGINE = InnoDB
DEFAULT CHARACTER SET = latin1;


-- -----------------------------------------------------
-- Table `sampdb`.`student`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `sampdb`.`student` (
  `name` VARCHAR(20) NOT NULL,
  `sex` ENUM('F','M') NOT NULL,
  `student_id` INT(10) UNSIGNED NOT NULL AUTO_INCREMENT,
  PRIMARY KEY (`student_id`))
ENGINE = InnoDB
AUTO_INCREMENT = 36
DEFAULT CHARACTER SET = latin1;

USE `sampdb` ;

-- -----------------------------------------------------
-- Placeholder table for view `sampdb`.`pres_age`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `sampdb`.`pres_age` (`last_name` INT, `first_name` INT, `birth` INT, `death` INT, `age` INT);

-- -----------------------------------------------------
-- Placeholder table for view `sampdb`.`pres_age_in_office`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `sampdb`.`pres_age_in_office` (`last_name` INT, `first_name` INT, `birth` INT, `age` INT);

-- -----------------------------------------------------
-- Placeholder table for view `sampdb`.`vstudent`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `sampdb`.`vstudent` (`student_id` INT, `name` INT, `date` INT, `score` INT, `category` INT);

-- -----------------------------------------------------
-- function count_over_age
-- -----------------------------------------------------

DELIMITER $$
USE `sampdb`$$
CREATE DEFINER=`root`@`localhost` FUNCTION `count_over_age`(aage int) RETURNS int(11)
    READS SQL DATA
begin 
return (select count(*) from pres_age where age > aage); 
end$$

DELIMITER ;

-- -----------------------------------------------------
-- procedure show_over_age
-- -----------------------------------------------------

DELIMITER $$
USE `sampdb`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `show_over_age`(anage int)
begin
select last_name, first_name, birth,death,age 
from pres_age
where age > anage   
order by age desc ; 
  
 
end$$

DELIMITER ;

-- -----------------------------------------------------
-- View `sampdb`.`pres_age`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `sampdb`.`pres_age`;
USE `sampdb`;
CREATE  OR REPLACE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `sampdb`.`pres_age` AS select `sampdb`.`president`.`last_name` AS `last_name`,`sampdb`.`president`.`first_name` AS `first_name`,`sampdb`.`president`.`birth` AS `birth`,`sampdb`.`president`.`death` AS `death`,timestampdiff(YEAR,`sampdb`.`president`.`birth`,`sampdb`.`president`.`death`) AS `age` from `sampdb`.`president`;

-- -----------------------------------------------------
-- View `sampdb`.`pres_age_in_office`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `sampdb`.`pres_age_in_office`;
USE `sampdb`;
CREATE  OR REPLACE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `sampdb`.`pres_age_in_office` AS select `sampdb`.`president`.`last_name` AS `last_name`,`sampdb`.`president`.`first_name` AS `first_name`,`sampdb`.`president`.`birth` AS `birth`,timestampdiff(YEAR,`sampdb`.`president`.`birth`,`sampdb`.`pres_term`.`term_start_date`) AS `age` from (`sampdb`.`pres_term` join `sampdb`.`president` on((`sampdb`.`president`.`pres_id` = `sampdb`.`pres_term`.`pres_id`))) group by `age`;

-- -----------------------------------------------------
-- View `sampdb`.`vstudent`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `sampdb`.`vstudent`;
USE `sampdb`;
CREATE  OR REPLACE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `sampdb`.`vstudent` AS select `sampdb`.`student`.`student_id` AS `student_id`,`sampdb`.`student`.`name` AS `name`,`sampdb`.`grade_event`.`date` AS `date`,`sampdb`.`score`.`score` AS `score`,`sampdb`.`grade_event`.`category` AS `category` from ((`sampdb`.`grade_event` join `sampdb`.`score`) join `sampdb`.`student` on(((`sampdb`.`grade_event`.`event_id` = `sampdb`.`score`.`event_id`) and (`sampdb`.`score`.`student_id` = `sampdb`.`student`.`student_id`)))) order by `sampdb`.`student`.`name`;

SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;