-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL,ALLOW_INVALID_DATES';

-- -----------------------------------------------------
-- Schema shortcutdevice
-- -----------------------------------------------------
DROP SCHEMA IF EXISTS `shortcutdevice` ;

-- -----------------------------------------------------
-- Schema shortcutdevice
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `shortcutdevice` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci ;
USE `shortcutdevice` ;

-- -----------------------------------------------------
-- Table `shortcutdevice`.`Preset`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `shortcutdevice`.`Preset` ;

CREATE TABLE IF NOT EXISTS `shortcutdevice`.`Preset` (
  `id` INT NOT NULL AUTO_INCREMENT COMMENT '',
  `name` VARCHAR(30) NOT NULL COMMENT '',
  `color` VARCHAR(30) NOT NULL COMMENT '',
  UNIQUE INDEX `name_UNIQUE` (`name` ASC)  COMMENT '',
  PRIMARY KEY (`id`)  COMMENT '',
  UNIQUE INDEX `id_UNIQUE` (`id` ASC)  COMMENT '')
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `shortcutdevice`.`Button`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `shortcutdevice`.`Button` ;

CREATE TABLE IF NOT EXISTS `shortcutdevice`.`Button` (
  `id` INT NOT NULL AUTO_INCREMENT COMMENT '',
  `assignment` VARCHAR(50) NOT NULL COMMENT '',
  `name` VARCHAR(50) NOT NULL COMMENT '',
  PRIMARY KEY (`id`)  COMMENT '')
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `shortcutdevice`.`Preset_has_Button`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `shortcutdevice`.`Preset_has_Button` ;

CREATE TABLE IF NOT EXISTS `shortcutdevice`.`Preset_has_Button` (
  `Preset_id` INT NOT NULL COMMENT '',
  `Button_id` INT NOT NULL COMMENT '',
  PRIMARY KEY (`Preset_id`, `Button_id`)  COMMENT '',
  INDEX `fk_Preset_has_Button1_Button1_idx` (`Button_id` ASC)  COMMENT '',
  INDEX `fk_Preset_has_Button1_Preset1_idx` (`Preset_id` ASC)  COMMENT '',
  CONSTRAINT `fk_Preset_has_Button1_Preset1`
    FOREIGN KEY (`Preset_id`)
    REFERENCES `shortcutdevice`.`Preset` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Preset_has_Button1_Button1`
    FOREIGN KEY (`Button_id`)
    REFERENCES `shortcutdevice`.`Button` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `shortcutdevice`.`Preset_has_Button`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `shortcutdevice`.`Preset_has_Button` ;

CREATE TABLE IF NOT EXISTS `shortcutdevice`.`Preset_has_Button` (
  `Preset_id` INT NOT NULL COMMENT '',
  `Button_id` INT NOT NULL COMMENT '',
  PRIMARY KEY (`Preset_id`, `Button_id`)  COMMENT '',
  INDEX `fk_Preset_has_Button1_Button1_idx` (`Button_id` ASC)  COMMENT '',
  INDEX `fk_Preset_has_Button1_Preset1_idx` (`Preset_id` ASC)  COMMENT '',
  CONSTRAINT `fk_Preset_has_Button1_Preset1`
    FOREIGN KEY (`Preset_id`)
    REFERENCES `shortcutdevice`.`Preset` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Preset_has_Button1_Button1`
    FOREIGN KEY (`Button_id`)
    REFERENCES `shortcutdevice`.`Button` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;

USE `shortcutdevice` ;

-- -----------------------------------------------------
-- Placeholder table for view `shortcutdevice`.`PresetWithButtons`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `shortcutdevice`.`PresetWithButtons` (`presetId` INT, `presetName` INT, `presetColor` INT, `buttonId` INT, `buttonAssignment` INT, `buttonName` INT);

-- -----------------------------------------------------
-- View `shortcutdevice`.`PresetWithButtons`
-- -----------------------------------------------------
DROP VIEW IF EXISTS `shortcutdevice`.`PresetWithButtons` ;
DROP TABLE IF EXISTS `shortcutdevice`.`PresetWithButtons`;
USE `shortcutdevice`;
CREATE  OR REPLACE VIEW `PresetWithButtons` AS
    SELECT 
        p.id AS presetId,
        p.name AS presetName,
        p.color AS presetColor,
        b.id AS buttonId,
        b.assignment AS buttonAssignment,
        b.name AS buttonName
    FROM
        shortcutdevice.Preset p
            INNER JOIN
        shortcutdevice.Preset_has_Button pb ON (p.id = pb.Preset_id)
            INNER JOIN
        shortcutdevice.Button b ON (pb.Button_id = b.id);


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
