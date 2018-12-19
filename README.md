# NhibernateMvcDemo
This is  the DemoProject How to Configure Postgre sql with Nhibernate in mvc project 
here is the database for this project ..just copy past this postgreSql Script in your Project for creating role and assing
/*
 * psql -U postgres -f create_testdb.sql
 *
 */
 
CREATE ROLE veeresh LOGIN 
  PASSWORD 'veeresh123'
  NOINHERIT CREATEDB
   VALID UNTIL 'infinity';
 
CREATE ROLE user1 LOGIN
  PASSWORD 'user1'
  NOSUPERUSER NOINHERIT NOCREATEDB NOCREATEROLE;
 
 
CREATE TABLESPACE testdb_data OWNER veeresh LOCATION E'c:\\TestDB\\data\\TestDB\\data';
CREATE TABLESPACE testdb_index OWNER veeresh LOCATION E'c:\\TestDB\\data\\TestDB\\index';
 
CREATE DATABASE testdb
  WITH ENCODING='UTF8'
       OWNER=veeresh
       TABLESPACE=testdb_data;
 
GRANT ALL ON DATABASE testdb TO veeresh;
GRANT CONNECT ON DATABASE testdb TO user1;
 
\c testdb
 
CREATE SCHEMA testdb AUTHORIZATION veeresh;
GRANT USAGE ON SCHEMA testdb TO user1;
--------------------------------then after you have to create this two table -------------------------------------
1.
CREATE TABLE testdb.persons
(
  person_id bigserial NOT NULL,
  person_name character varying(36) NOT NULL,
 
  CONSTRAINT persons_pk PRIMARY KEY (person_id))
WITH (
  OIDS=FALSE
);
ALTER TABLE testdb.persons OWNER TO veeresh;
GRANT ALL ON TABLE testdb.persons TO user1;
GRANT ALL ON TABLE testdb.persons TO user1;
 
ALTER TABLE testdb.persons_person_id_seq OWNER TO veeresh;
GRANT ALL ON TABLE testdb.persons_person_id_seq TO veeresh;
GRANT USAGE ON TABLE testdb.persons_person_id_seq TO user1;
2.
CREATE TABLE testdb.cars
(
  car_id bigserial NOT NULL,
  model_name character varying(36) NOT NULL,
  year integer,
  person_id bigint,
  CONSTRAINT cars_pk PRIMARY KEY (car_id),
  CONSTRAINT person_fk FOREIGN KEY (person_id)
      REFERENCES testdb.persons (person_id) MATCH SIMPLE
      ON UPDATE CASCADE ON DELETE CASCADE 
)
WITH (
  OIDS=FALSE
);
ALTER TABLE testdb.cars OWNER TO veeresh;
GRANT ALL ON TABLE testdb.cars TO user1;
GRANT ALL ON TABLE testdb.cars TO user1;
 
ALTER TABLE testdb.cars_car_id_seq OWNER TO veeresh;
GRANT ALL ON TABLE testdb.cars_car_id_seq TO veeresh;
GRANT USAGE ON TABLE testdb.cars_car_id_seq TO user1;
