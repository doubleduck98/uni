-- ZADANIE 1
CREATE TABLE osoba (
  id SERIAL PRIMARY KEY,
  name VARCHAR NOT NULL,
  surname VARCHAR NOT NULL,
  PESEL BIGINT NOT NULL,
  sex VARCHAR (1)
);
INSERT INTO osoba (name, surname, pesel, sex)
VALUES
  ('Szymon', 'Zienkiewicz ', 98111699742, 'M');
-- ZADANIE 4\
CREATE TABLE miejsce_pracy (
  id SERIAL PRIMARY KEY,
  name VARCHAR NOT NULL
);
ALTER TABLE osoba ADD COLUMN id_praca SERIAL REFERENCES miejsce_pracy(id);