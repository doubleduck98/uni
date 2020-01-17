--
-- PostgreSQL database dump
--

-- Dumped from database version 10.10 (Ubuntu 10.10-0ubuntu0.18.04.1)
-- Dumped by pg_dump version 10.10 (Ubuntu 10.10-0ubuntu0.18.04.1)

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

--
-- Name: plpgsql; Type: EXTENSION; Schema: -; Owner: -
--

CREATE EXTENSION IF NOT EXISTS plpgsql WITH SCHEMA pg_catalog;


--
-- Name: EXTENSION plpgsql; Type: COMMENT; Schema: -; Owner: -
--

COMMENT ON EXTENSION plpgsql IS 'PL/pgSQL procedural language';


SET default_tablespace = '';

SET default_with_oids = false;

--
-- Name: miejsce_pracy; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE public.miejsce_pracy (
    id integer NOT NULL,
    name character varying NOT NULL
);


--
-- Name: miejsce_pracy_id_seq; Type: SEQUENCE; Schema: public; Owner: -
--

CREATE SEQUENCE public.miejsce_pracy_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


--
-- Name: miejsce_pracy_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: -
--

ALTER SEQUENCE public.miejsce_pracy_id_seq OWNED BY public.miejsce_pracy.id;


--
-- Name: osoba; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE public.osoba (
    id integer NOT NULL,
    name character varying NOT NULL,
    surname character varying NOT NULL,
    pesel bigint NOT NULL,
    sex character varying(1),
    id_miejsce_pracy integer
);


--
-- Name: osoba_id_seq; Type: SEQUENCE; Schema: public; Owner: -
--

CREATE SEQUENCE public.osoba_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


--
-- Name: osoba_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: -
--

ALTER SEQUENCE public.osoba_id_seq OWNED BY public.osoba.id;


--
-- Name: miejsce_pracy id; Type: DEFAULT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.miejsce_pracy ALTER COLUMN id SET DEFAULT nextval('public.miejsce_pracy_id_seq'::regclass);


--
-- Name: osoba id; Type: DEFAULT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.osoba ALTER COLUMN id SET DEFAULT nextval('public.osoba_id_seq'::regclass);


--
-- Data for Name: miejsce_pracy; Type: TABLE DATA; Schema: public; Owner: -
--

COPY public.miejsce_pracy (id, name) FROM stdin;
1	fajne korpo
2	niefajne korpo
7	kierowca wyscigowy
\.


--
-- Data for Name: osoba; Type: TABLE DATA; Schema: public; Owner: -
--

COPY public.osoba (id, name, surname, pesel, sex, id_miejsce_pracy) FROM stdin;
8	Lewis	Hamilton	85010789344	M	2
9	Charles	Leclerc	96747385846	M	2
2	Max	Verstappen	97042185733	M	2
1	Szymon	Zienkiewicz 	98111699742	M	1
12	Kimi	Raikkonen	791017	M	7
\.


--
-- Name: miejsce_pracy_id_seq; Type: SEQUENCE SET; Schema: public; Owner: -
--

SELECT pg_catalog.setval('public.miejsce_pracy_id_seq', 7, true);


--
-- Name: osoba_id_seq; Type: SEQUENCE SET; Schema: public; Owner: -
--

SELECT pg_catalog.setval('public.osoba_id_seq', 12, true);


--
-- Name: miejsce_pracy miejsce_pracy_pkey; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.miejsce_pracy
    ADD CONSTRAINT miejsce_pracy_pkey PRIMARY KEY (id);


--
-- Name: osoba osoba_pkey; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.osoba
    ADD CONSTRAINT osoba_pkey PRIMARY KEY (id);


--
-- Name: osoba osoba_id_praca_fkey; Type: FK CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.osoba
    ADD CONSTRAINT osoba_id_praca_fkey FOREIGN KEY (id_miejsce_pracy) REFERENCES public.miejsce_pracy(id);


--
-- PostgreSQL database dump complete
--

