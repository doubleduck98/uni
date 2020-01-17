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
-- Name: plpgsql; Type: EXTENSION; Schema: -; Owner: 
--

CREATE EXTENSION IF NOT EXISTS plpgsql WITH SCHEMA pg_catalog;


--
-- Name: EXTENSION plpgsql; Type: COMMENT; Schema: -; Owner: 
--

COMMENT ON EXTENSION plpgsql IS 'PL/pgSQL procedural language';


SET default_tablespace = '';

SET default_with_oids = false;

--
-- Name: miejsce_pracy; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.miejsce_pracy (
    id integer NOT NULL,
    name character varying NOT NULL
);


ALTER TABLE public.miejsce_pracy OWNER TO postgres;

--
-- Name: miejsce_pracy_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.miejsce_pracy_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.miejsce_pracy_id_seq OWNER TO postgres;

--
-- Name: miejsce_pracy_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.miejsce_pracy_id_seq OWNED BY public.miejsce_pracy.id;


--
-- Name: osoba; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.osoba (
    id integer NOT NULL,
    name character varying NOT NULL,
    surname character varying NOT NULL,
    pesel bigint NOT NULL,
    sex character varying(1),
    id_miejsce_pracy integer
);


ALTER TABLE public.osoba OWNER TO postgres;

--
-- Name: osoba_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.osoba_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.osoba_id_seq OWNER TO postgres;

--
-- Name: osoba_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.osoba_id_seq OWNED BY public.osoba.id;


--
-- Name: osoba_miejsca; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.osoba_miejsca (
    id_osoba integer NOT NULL,
    id_praca integer NOT NULL
);


ALTER TABLE public.osoba_miejsca OWNER TO postgres;

--
-- Name: miejsce_pracy id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.miejsce_pracy ALTER COLUMN id SET DEFAULT nextval('public.miejsce_pracy_id_seq'::regclass);


--
-- Name: osoba id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.osoba ALTER COLUMN id SET DEFAULT nextval('public.osoba_id_seq'::regclass);


--
-- Data for Name: miejsce_pracy; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.miejsce_pracy (id, name) FROM stdin;
1	fajne korpo
2	niefajne korpo
7	kierowca wyscigowy
11	inzynier wyscigowy
\.


--
-- Data for Name: osoba; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.osoba (id, name, surname, pesel, sex, id_miejsce_pracy) FROM stdin;
8	Lewis	Hamilton	85010789344	M	2
9	Charles	Leclerc	96747385846	M	2
2	Max	Verstappen	97042185733	M	2
1	Szymon	Zienkiewicz 	98111699742	M	1
16	Peter	Bonnington	83021388943	M	11
12	Kimi	Raikkonen	79101700234	M	7
\.


--
-- Data for Name: osoba_miejsca; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.osoba_miejsca (id_osoba, id_praca) FROM stdin;
16	11
\.


--
-- Name: miejsce_pracy_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.miejsce_pracy_id_seq', 11, true);


--
-- Name: osoba_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.osoba_id_seq', 16, true);


--
-- Name: miejsce_pracy miejsce_pracy_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.miejsce_pracy
    ADD CONSTRAINT miejsce_pracy_pkey PRIMARY KEY (id);


--
-- Name: osoba osoba_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.osoba
    ADD CONSTRAINT osoba_pkey PRIMARY KEY (id);


--
-- Name: osoba osoba_id_praca_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.osoba
    ADD CONSTRAINT osoba_id_praca_fkey FOREIGN KEY (id_miejsce_pracy) REFERENCES public.miejsce_pracy(id);


--
-- Name: osoba_miejsca osoba_miejsca_id_osoba_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.osoba_miejsca
    ADD CONSTRAINT osoba_miejsca_id_osoba_fkey FOREIGN KEY (id_osoba) REFERENCES public.osoba(id);


--
-- Name: osoba_miejsca osoba_miejsca_id_praca_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.osoba_miejsca
    ADD CONSTRAINT osoba_miejsca_id_praca_fkey FOREIGN KEY (id_praca) REFERENCES public.miejsce_pracy(id);


--
-- PostgreSQL database dump complete
--

