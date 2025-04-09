--
-- PostgreSQL database dump
--

-- Dumped from database version 17.4
-- Dumped by pg_dump version 17.4

-- Started on 2025-04-09 10:21:12

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

DROP DATABASE pokemon_app;
--
-- TOC entry 4850 (class 1262 OID 25001)
-- Name: pokemon_app; Type: DATABASE; Schema: -; Owner: postgres
--

CREATE DATABASE pokemon_app WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE_PROVIDER = libc LOCALE = 'Polish_Poland.1250';


ALTER DATABASE pokemon_app OWNER TO postgres;

\connect pokemon_app

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

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- TOC entry 218 (class 1259 OID 25003)
-- Name: Trainers; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Trainers" (
    "Id" integer NOT NULL,
    "Name" text NOT NULL,
    "Surname" text NOT NULL,
    "Age" integer NOT NULL,
    "Birthday" date NOT NULL,
    "LegalAge" boolean NOT NULL
);


ALTER TABLE public."Trainers" OWNER TO postgres;

--
-- TOC entry 217 (class 1259 OID 25002)
-- Name: trainers_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.trainers_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.trainers_id_seq OWNER TO postgres;

--
-- TOC entry 4851 (class 0 OID 0)
-- Dependencies: 217
-- Name: trainers_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.trainers_id_seq OWNED BY public."Trainers"."Id";


--
-- TOC entry 4695 (class 2604 OID 25006)
-- Name: Trainers Id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Trainers" ALTER COLUMN "Id" SET DEFAULT nextval('public.trainers_id_seq'::regclass);


--
-- TOC entry 4844 (class 0 OID 25003)
-- Dependencies: 218
-- Data for Name: Trainers; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public."Trainers" ("Id", "Name", "Surname", "Age", "Birthday", "LegalAge") VALUES (16, 'Ash', 'Ketchum', 8, '2016-06-16', false);
INSERT INTO public."Trainers" ("Id", "Name", "Surname", "Age", "Birthday", "LegalAge") VALUES (19, 'Brock', 'Takeshi', 24, '2001-02-19', true);
INSERT INTO public."Trainers" ("Id", "Name", "Surname", "Age", "Birthday", "LegalAge") VALUES (20, 'Misty', 'Kasumi', 13, '2011-06-14', false);


--
-- TOC entry 4852 (class 0 OID 0)
-- Dependencies: 217
-- Name: trainers_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.trainers_id_seq', 20, true);


--
-- TOC entry 4697 (class 2606 OID 25010)
-- Name: Trainers trainers_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Trainers"
    ADD CONSTRAINT trainers_pkey PRIMARY KEY ("Id");


-- Completed on 2025-04-09 10:21:13

--
-- PostgreSQL database dump complete
--

