#------------------------------------------------------------
#        Script MySQL.
#------------------------------------------------------------


#------------------------------------------------------------
# Table: recettes
#------------------------------------------------------------

CREATE TABLE USER_recettes(
        id                   Int  Auto_increment  NOT NULL ,
        nom                  Varchar (50) NOT NULL ,
        etapes               Varchar (50) NOT NULL ,
        temps_de_preparation Datetime NOT NULL ,
        temps_de_cuisson     Datetime NOT NULL ,
        temps_de_repos       Datetime NOT NULL ,
        categorie            Varchar (50) NOT NULL
	,CONSTRAINT USER_recettes_PK PRIMARY KEY (id)
)ENGINE=InnoDB;


#------------------------------------------------------------
# Table: ustensils
#------------------------------------------------------------

CREATE TABLE USER_ustensils(
        id       Int  Auto_increment  NOT NULL ,
        nom      Varchar (50) NOT NULL ,
        type     Varchar (50) NOT NULL ,
        quantite Varchar (50) NOT NULL
	,CONSTRAINT USER_ustensils_PK PRIMARY KEY (id)
)ENGINE=InnoDB;


#------------------------------------------------------------
# Table: stock
#------------------------------------------------------------

CREATE TABLE USER_stock(
        id       Int  Auto_increment  NOT NULL ,
        type     Varchar (50) NOT NULL ,
        quantite Varchar (50) NOT NULL
	,CONSTRAINT USER_stock_PK PRIMARY KEY (id)
)ENGINE=InnoDB;


#------------------------------------------------------------
# Table: Ingrédients
#------------------------------------------------------------

CREATE TABLE USER_Ingredients(
        id       Int  Auto_increment  NOT NULL ,
        nom      Varchar (50) NOT NULL ,
        quantite Varchar (50) NOT NULL ,
        id_stock Int NOT NULL
	,CONSTRAINT USER_Ingredients_PK PRIMARY KEY (id)

	,CONSTRAINT USER_Ingredients_USER_stock_FK FOREIGN KEY (id_stock) REFERENCES USER_stock(id)
)ENGINE=InnoDB;


#------------------------------------------------------------
# Table: composer
#------------------------------------------------------------

CREATE TABLE USER_composer(
        id          Int NOT NULL ,
        id_recettes Int NOT NULL
	,CONSTRAINT USER_composer_PK PRIMARY KEY (id,id_recettes)

	,CONSTRAINT USER_composer_USER_Ingredients_FK FOREIGN KEY (id) REFERENCES USER_Ingredients(id)
	,CONSTRAINT USER_composer_USER_recettes0_FK FOREIGN KEY (id_recettes) REFERENCES USER_recettes(id)
)ENGINE=InnoDB;


#------------------------------------------------------------
# Table: utiliser
#------------------------------------------------------------

CREATE TABLE USER_utiliser(
        id          Int NOT NULL ,
        id_recettes Int NOT NULL
	,CONSTRAINT USER_utiliser_PK PRIMARY KEY (id,id_recettes)

	,CONSTRAINT USER_utiliser_USER_ustensils_FK FOREIGN KEY (id) REFERENCES USER_ustensils(id)
	,CONSTRAINT USER_utiliser_USER_recettes0_FK FOREIGN KEY (id_recettes) REFERENCES USER_recettes(id)
)ENGINE=InnoDB;

