create table Miejscowosc
(
    id    bigint identity
        constraint PK_Miejscowosc
            primary key,
    Nazwa varchar(50)
)
go

create table Student
(
    id            bigint identity
        constraint PK_Student
            primary key,
    Imię          varchar(50),
    Nazwisko      varchar(50),
    DataUrodzenia date,
    Miejscowosc   bigint
        constraint FK_Miejscowosc
            references Miejscowosc
)
go
