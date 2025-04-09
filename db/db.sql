-- PostgreSQL database initialization script for docker-entrypoint-initdb.d

-- Ustawienia środowiska
SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET transaction_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

-- Tworzenie tabeli Trainers
CREATE TABLE public."Trainers" (
    "Id" integer NOT NULL,
    "Name" text NOT NULL,
    "Surname" text NOT NULL,
    "Age" integer NOT NULL,
    "Birthday" date NOT NULL,
    "LegalAge" boolean NOT NULL
);

-- Tworzenie sekwencji
CREATE SEQUENCE public.trainers_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;

ALTER SEQUENCE public.trainers_id_seq OWNED BY public."Trainers"."Id";

-- Domyślna wartość Id na sekwencję
ALTER TABLE ONLY public."Trainers"
    ALTER COLUMN "Id" SET DEFAULT nextval('public.trainers_id_seq'::regclass);

-- Klucz główny
ALTER TABLE ONLY public."Trainers"
    ADD CONSTRAINT trainers_pkey PRIMARY KEY ("Id");

-- Wstawianie przykładowych danych
INSERT INTO public."Trainers" ("Id", "Name", "Surname", "Age", "Birthday", "LegalAge") VALUES
    (16, 'Ash', 'Ketchum', 8, '2016-06-16', false),
    (19, 'Brock', 'Takeshi', 24, '2001-02-19', true),
    (20, 'Misty', 'Kasumi', 13, '2011-06-14', false);

-- Ustawienie aktualnej wartości sekwencji
SELECT pg_catalog.setval('public.trainers_id_seq', 20, true);
