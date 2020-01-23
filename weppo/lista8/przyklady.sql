-- ZADANIE 1
CREATE TABLE osoba (
  id SERIAL PRIMARY KEY,
  name VARCHAR NOT NULL,
  surname VARCHAR NOT NULL,
  age INT NOT NULL,
  sex VARCHAR (1)
);

CREATE SEQUENCE osoba_id
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE;

SELECT nextval('osoba_id');

INSERT INTO osoba (name, surname, age, sex)
VALUES
  ('Szymon', 'Zienkiewicz ', 21, 'M');
  
-- ZADANIE 4\
CREATE TABLE miejsce_pracy (
  id SERIAL PRIMARY KEY,
  name VARCHAR NOT NULL
);

ALTER TABLE osoba ADD COLUMN id_praca REFERENCES miejsce_pracy(id);

-- ZADANIE 5
CREATE TABLE osoba_miejsca (
  id_osoba INT NOT NULL REFERENCES osoba(id),
  id_praca INT NOT NULL REFERENCES miejsce_pracy(id)
);