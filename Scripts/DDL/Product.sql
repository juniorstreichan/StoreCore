CREATE TABLE public."Product" (
	"Id" int NOT NULL GENERATED BY DEFAULT AS IDENTITY,
	"Description" varchar(255) NULL,
	"Price" numeric NULL,
	CONSTRAINT product_pk PRIMARY KEY ("Id")
);