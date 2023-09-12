CREATE TABLE IF NOT EXISTS `person` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `address` varchar(100) NOT NULL,
  `first_name` varchar(80) NOT NULL,
  `gender` varchar(6) NOT NULL,
  `last_name` varchar(80) NOT NULL,
  PRIMARY KEY (`id`)
) 

CREATE TABLE IF NOT EXISTS `veiculo` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `modelo` varchar(100)  NULL,
  `marca` varchar(80)  NULL,
  `valor` decimal(11,3) NOT NULL,
  PRIMARY KEY (`id`)
)

CREATE TABLE IF NOT EXISTS `seguro` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `idperson` bigint(20) NOT NULL,
  `idveiculo` bigint(20) NOT NULL,
  `valorseguro` decimal(11,3) NOT NULL,
  PRIMARY KEY (`id`)
) 