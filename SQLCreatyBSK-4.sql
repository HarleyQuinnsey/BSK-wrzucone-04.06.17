drop table Historia;
drop table Uzytkownik;
drop table Faktura;
drop table Pracownik;
drop table Potrawa;
drop table Restauracja;
--drop table Uprawnienia;

Create table Restauracja (
Nazwa varchar(100) primary key, 
Adres varchar(100), 
Ilosc_miejsc int
)

Create table Pracownik (
PESEL char(11) primary key,
ImieNazwisko varchar(100), 
Stanowisko varchar(100), 
Pensja int, 
KtoregoLokalu varchar(100) references Restauracja
)

Create table Uzytkownik (
LoginUsera varchar(20) primary key,
HasloUsera varchar(255),
PESELpracownika char(11) references Pracownik,
CzyAktywny bit
)


Create table Potrawa (
ID_Potrawy int identity(1,1) primary key, 
Nazwa varchar(100), 
Opis varchar(100), 
Cena int, 
WKtorymLokalu varchar(100) references Restauracja
)

Create table Faktura (
Nr_Faktury int identity(1,1) primary key, 
Kwota int, 
DataWystawienia date, 
NazwaTowaru varchar(100),
WystawionaPrzezPracownika char(11) references Pracownik
)

Create table Historia (
ID int identity(1,1) primary key,
Dawca varchar(20) references Uzytkownik,--loginDawcy
Biorca varchar(20) references Uzytkownik,--loginBiorcy
RodzajOperacji varchar(20),--przekazanie lub przejêcie
Uprawnienia varchar(150),--uprawnienia, które przekazujemy/przejmujemy
WszystkiePosiadaneUprawnienia varchar(150),
RodziceWDrzewie varchar(1000),
Flagi varchar(50),--uprawnienia, które dajemy
CzyAktualne bit,
Blokada bit
)

Insert into Restauracja values('SurfBurger', 'ul.Koniewskiego 87-554 Warszawa','20');
Insert into Restauracja values('SurfBurger2', 'ul.Koniczynowa 82-432 £ódŸ','10');
Insert into Restauracja values('SurfBurger3', 'ul.Piêkna 80-254 Gdañsk','20');
Insert into Restauracja values('SurfBurger4', 'ul.Szubiñska 80-233 Gdañsk','15');
Insert into Restauracja values('SurfBurger5', 'ul.Damroki 89-133 Gdynia','20');

Insert into Pracownik values('95041213411', 'AdamGlun', 'kelner', '2100', 'Surfburger');
Insert into Pracownik values('95051919811', 'EustachyMucha', 'kelner', '2100', 'Surfburger2');
Insert into Pracownik values('95031211111', 'PiotrPieniazek', 'admin', '5000', 'Surfburger3');
Insert into Pracownik values('94091215941', 'MagdalenaPienko', 'kelnerka', '2100', 'Surfburger3');
Insert into Pracownik values('93092211943', 'MagdalenaZebra', 'kelnerka', '2100', 'Surfburger2');
Insert into Pracownik values('69112712942', 'BarbaraMetka', 'sprz¹taczka', '1700', 'Surfburger');
Insert into Pracownik values('59102716951', 'OliviaSadowska', 'sprz¹taczka', '1700', 'Surfburger3');
Insert into Pracownik values('63112519971', 'AleksanderSzymaniuk', 'kelner', '2100', 'Surfburger5');

Insert into Uzytkownik values('admin', 'D6-1D-00-4C-03-45-7B-AC-7B-90-C1-E8-D4-F5-11-13-BE-16-23-46-B2-7A-F5-30-7C-AF-FE-21-EF-88-59-7F-F1-5A-B1-56-9E-07-15-53-02-FF-7B-0A-F2-9F-7F-04-31-53-10-04-56-8D-A3-84-9A-57-08-17-68-15-A7-0F', '95031211111', 1);
Insert into Uzytkownik values('adam', '63-2E-52-A8-40-30-AA-38-86-53-A4-2F-88-57-14-44-A6-5E-0D-87-79-50-9D-0A-E4-5C-D9-17-0E-7D-F7-9E-A7-FD-E3-E7-F4-4B-1D-21-2A-A3-23-CC-79-F3-CA-B9-01-6E-CD-28-5B-1A-11-E3-63-49-73-F0-F9-EB-4B-82', '95041213411', 1);
Insert into Uzytkownik values('eustachy', 'D9-1F-99-06-71-43-30-44-49-8F-D2-4A-9C-04-5C-A7-16-CF-95-BB-BE-2B-37-3C-4D-48-B3-26-20-58-DE-37-77-1F-6F-78-05-3D-20-FE-E2-5A-36-0A-66-3F-98-53-06-FC-8F-16-2D-E1-CC-C7-22-15-4A-A7-D7-FF-8D-D8', '95051919811', 1);
Insert into Uzytkownik values('magda', '36-B4-1F-BD-59-8A-DA-71-8D-A4-52-F5-B3-99-15-F5-B5-48-EB-96-A8-8B-46-D5-ED-26-A2-A9-90-4C-3F-19-97-11-BC-45-8B-C4-58-38-80-BE-F8-03-66-DD-74-11-B3-8B-23-2E-AF-1C-F9-17-C2-09-6B-13-C4-02-6A-2E', '94091215941', 1);
Insert into Uzytkownik values('basia', '9E-3B-30-F7-BC-94-E9-73-14-AB-8B-D6-37-85-9B-88-50-7D-09-BF-AF-CA-9B-83-96-1C-3E-93-6F-42-36-4E-0D-BA-A1-32-B6-32-8B-95-75-7E-E6-39-B1-4F-A0-46-EC-53-61-B3-8A-8D-58-97-E7-4B-F9-8A-C4-D4-77-B4', '69112712942', 1);

Insert into Historia values ('', 'admin', 'stan', '','S0S1S2S3S4S5U0U1U2U3U4U5D0D1D2D3D4D5I0I1I2I3I4I5P0P1P2P3P4P5', '', '', 1,0);
--Insert into Historia values ('admin', 'admin', 'przekaz', 'S0S1S2S3S4S5U0U1U2U3U4U5D0D1D2D3D4D5I0I1I2I3I4I5P0P1P2P3P4P5','S0S1S2S3S4S5U0U1U2U3U4U5D0D1D2D3D4D5I0I1I2I3I4I5P0P1P2P3P4P5', '95031211111,', '', 1,0);
--Insert into Historia values ('admin', 'adam', 'stworzenie konta', '', '', '', '', 0,0);
--Insert into Historia values ('admin', 'eustachy', 'stworzenie konta', '', '', '', '', 0,0);
--Insert into Historia values ('admin', 'magda', 'stworzenie konta', '', 'P1P2P3P4', '', '', 1,0);
--Insert into Historia values ('admin', 'basia', 'stworzenie konta', '', '', '', '', 1,0);
--Insert into Historia values ('admin', 'adam', 'przekaz', 'S2U2D2I2', 'S2U2D2I2', '95031211111,', '', 1,0);
--Insert into Historia values ('admin', 'eustachy', 'przekaz', 's1d2i4', 's1d2i4', '95031211111,', '',0,0);
--Insert into Historia values ('admin', 'eustachy', 'przekaz', 'S2', 's1d2i4S2', '95031211111,', '', 1,0);

Insert into Faktura values ('50', '03.04.2017', '2x burger nacho', '95041213411');
Insert into Faktura values ('35', '04.04.2017', 'burger nacho z dowozem', '95041213411');
Insert into Faktura values ('18', '04.04.2017', 'burger w³oski', '95041213411');
Insert into Faktura values ('23', '05.04.2017', 'burger farmerski, pepsi0.5l', '95051919811');
Insert into Faktura values ('50', '05.04.2017', '2x burger koza', '95051919811');


Insert into Potrawa values ('burger_nacho', 'bu³ka grahamka, wo³owina 200g, sos serowy, nachosy, boczek', '25', 'SurfBurger');
Insert into Potrawa values ('burger_w³oski', 'bu³ka grahamka, wo³owina 200g, sos pomidorowy, papryka, salami w³oskie', '18', 'SurfBurger2');
Insert into Potrawa values ('burger_farmerski', 'bu³ka grahamka, wo³owina 200g, sos musztardowy, pomidor, cebula', '23', 'SurfBurger3');
Insert into Potrawa values ('burger_koza', 'bu³ka grahamka, wo³owina 200g, sos barbecue, ser kozi, rukola', '25', 'SurfBurger');
Insert into Potrawa values ('pepsi0.5l', '-', '25', 'SurfBurger');
Insert into Potrawa values ('dowóz', '-', '10', 'SurfBurger');


DROP VIEW TECHNICZNE 
CREATE VIEW TECHNICZNE AS
SELECT ID, Biorca AS Uzytkownik, WszystkiePosiadaneUprawnienia, Flagi
FROM Historia
WHERE CzyAktualne=1;

--UPDATE Historia SET CzyAktualne = 0 WHERE Biorca = 'eustachy' and Uprawnienia = 's1d2i4';
--Insert into Historia values ('eustachy', 'magda', 'przekaz', 's1', 's1', '95051919811,', 1);
--UPDATE Historia SET WszystkiePosiadaneUprawnienia = 'd2i4S2' WHERE Biorca = 'eustachy' and CzyAktualne = 1;
--UPDATE Historia SET WszystkiePosiadaneUprawnienia = 'S1' WHERE Biorca = 'magda' and CzyAktualne = 1;