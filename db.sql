PGDMP      5                }           pokemon_app    17.4    17.4     �           0    0    ENCODING    ENCODING        SET client_encoding = 'UTF8';
                           false            �           0    0 
   STDSTRINGS 
   STDSTRINGS     (   SET standard_conforming_strings = 'on';
                           false            �           0    0 
   SEARCHPATH 
   SEARCHPATH     8   SELECT pg_catalog.set_config('search_path', '', false);
                           false            �           1262    25001    pokemon_app    DATABASE     ~   CREATE DATABASE pokemon_app WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE_PROVIDER = libc LOCALE = 'Polish_Poland.1250';
    DROP DATABASE pokemon_app;
                     postgres    false            �            1259    25003    Trainers    TABLE     �   CREATE TABLE public."Trainers" (
    "Id" integer NOT NULL,
    "Name" text NOT NULL,
    "Surname" text NOT NULL,
    "Age" integer NOT NULL,
    "Birthday" date NOT NULL,
    "LegalAge" boolean NOT NULL
);
    DROP TABLE public."Trainers";
       public         heap r       postgres    false            �            1259    25002    trainers_id_seq    SEQUENCE     �   CREATE SEQUENCE public.trainers_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 &   DROP SEQUENCE public.trainers_id_seq;
       public               postgres    false    218            �           0    0    trainers_id_seq    SEQUENCE OWNED BY     G   ALTER SEQUENCE public.trainers_id_seq OWNED BY public."Trainers"."Id";
          public               postgres    false    217            W           2604    25006    Trainers Id    DEFAULT     n   ALTER TABLE ONLY public."Trainers" ALTER COLUMN "Id" SET DEFAULT nextval('public.trainers_id_seq'::regclass);
 >   ALTER TABLE public."Trainers" ALTER COLUMN "Id" DROP DEFAULT;
       public               postgres    false    218    217    218            �          0    25003    Trainers 
   TABLE DATA           \   COPY public."Trainers" ("Id", "Name", "Surname", "Age", "Birthday", "LegalAge") FROM stdin;
    public               postgres    false    218   I       �           0    0    trainers_id_seq    SEQUENCE SET     >   SELECT pg_catalog.setval('public.trainers_id_seq', 20, true);
          public               postgres    false    217            Y           2606    25010    Trainers trainers_pkey 
   CONSTRAINT     X   ALTER TABLE ONLY public."Trainers"
    ADD CONSTRAINT trainers_pkey PRIMARY KEY ("Id");
 B   ALTER TABLE ONLY public."Trainers" DROP CONSTRAINT trainers_pkey;
       public                 postgres    false    218            �   a   x�̱
� F����b�k"5�m�-"���}�|�X9`ڊwB�b[%;I��:���[�ԁE�V�Ҍ9��`r�N�~����������     