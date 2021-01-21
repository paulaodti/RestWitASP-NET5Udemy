CREATE TABLE `user` (
	`id` INT(10) NOT NULL AUTO_INCREMENT,
	`user_name` VARCHAR(50) NOT NULL COLLATE 'latin1_swedish_ci',
	`password` VARCHAR(130) NOT NULL COLLATE 'latin1_swedish_ci',
	`full_name` VARCHAR(120) NOT NULL COLLATE 'latin1_swedish_ci',
	`refresh_token` VARCHAR(500) NULL DEFAULT '0' COLLATE 'latin1_swedish_ci',
	`refresh_token_expiry_time` DATETIME NULL DEFAULT NULL,
	PRIMARY KEY (`id`) USING BTREE,
	UNIQUE INDEX `user_name` (`user_name`) USING BTREE
)
COLLATE='latin1_swedish_ci'
ENGINE=InnoDB
;