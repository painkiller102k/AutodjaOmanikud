# 🚗 AutodjaOmanikud

### 🛠️ Autoteeninduse haldussüsteem

**AutodjaOmanikud** on C# ja Windows Forms abil loodud autoteeninduse haldussüsteem, mis võimaldab hallata autoomanikke, sõidukeid, hooldusteenuseid ja teeninduse andmeid.

Rakendus kasutab **Entity Framework Core'i** andmebaasiga suhtlemiseks ning võimaldab andmeid lisada, muuta, kustutada ja otsida.

---

## ✨ Projekti ülevaade

Rakendus on loodud autoteeninduse igapäevaste andmete haldamiseks.

Süsteemis saab:

* 👤 hallata autoomanikke
* 🚗 hallata sõidukeid
* 🔧 hallata hooldusteenuste tüüpe
* 📅 registreerida hooldusi ja teenindusi
* 💳 märkida teenuseid tasutuks või tasumata
* 🔎 otsida teeninduse andmeid
* 💰 arvutada konkreetse omaniku tasumata summa
* 🗃️ hallata andmeid Entity Framework Core'i abil

---

## 🛠️ Kasutatud tehnoloogiad

| Tehnoloogia               | Kasutus                           |
| ------------------------- | --------------------------------- |
| **C#**                    | Rakenduse programmeerimine        |
| **.NET 8**                | Projekti platvorm                 |
| **Windows Forms**         | Graafiline kasutajaliides         |
| **Entity Framework Core** | Andmebaasiga suhtlemine           |
| **SQL Server**            | Andmete salvestamine              |
| **EF Core Migrations**    | Andmebaasi struktuuri haldamine   |
| **LINQ**                  | Andmete otsimine ja filtreerimine |

Projekt on seadistatud kasutama `net8.0-windows7.0` sihtplatvormi.

---

## ⚙️ Peamised funktsioonid

### 👤 Autoomanikud

Võimalik on:

* lisada uus omanik
* muuta omaniku andmeid
* kustutada omanik
* vaadata omaniku telefoninumbrit
* näha omanikuga seotud sõidukeid

Omaniku kustutamisel eemaldatakse seotud sõidukid samuti andmebaasist.

### 🚗 Sõidukid

Iga sõiduki kohta saab salvestada:

* marki
* mudelit
* registreerimisnumbrit
* omanikku

Sõidukeid saab lisada, muuta ja kustutada ning need on seotud konkreetse autoomanikuga.

### 🔧 Teenuste tüübid

Teenuse tüübi jaoks saab määrata:

* teenuse nime
* hinna

Näiteks võib süsteemi lisada erinevaid hooldus- ja remonditeenuseid.

Teenuste tüüpe saab samuti lisada, muuta ja kustutada.

### 📅 Hooldused ja teenindused

Teeninduse kirje sisaldab:

* autoomanikku
* sõidukit
* teenuse tüüpi
* teenuse hinda
* kuupäeva ja kellaaega
* makse staatust

Teeninduse andmeid saab lisada, muuta ja kustutada.

### 🔎 Otsing

Teeninduse andmeid saab otsida näiteks:

* auto margi järgi
* mudeli järgi
* registreerimisnumbri järgi
* teenuse nime järgi
* autoomaniku nime järgi

Otsing toimub otse andmebaasi päringu kaudu.

### 💰 Tasumata summa

Rakendus võimaldab arvutada valitud autoomaniku kõikide tasumata teenuste kogusumma.

Süsteem võtab arvesse ainult teenuseid, mille makse staatus on märgitud tasumata.

---

## 🗄️ Andmemudel

Rakenduse andmed on jagatud erinevateks omavahel seotud mudeliteks.

```text
Owner
  │
  └─── Cars
          │
          └─── Services
                   │
                   └─── ServiceType
```

### Seosed

* Ühel **Owner** objektil võib olla mitu **Car** objekti.
* Iga **Car** kuulub konkreetsele omanikule.
* Ühel autol võib olla mitu **Service** kirjet.
* Iga **Service** kasutab ühte **ServiceType** kirjet.

Entity Framework Core abil kasutatakse nende seoste laadimiseks näiteks `Include()` ja `ThenInclude()` meetodeid.

---

## 📁 Projekti struktuur

```text
AutodjaOmanikud/
│
├── Data/
│   └── Andmebaasi konfiguratsioon
│
├── Models/
│   ├── Owner.cs
│   ├── Car.cs
│   ├── Service.cs
│   └── ServiceType.cs
│
├── Migrations/
│   └── Entity Framework migratsioonid
│
├── Properties/
│
├── Form1.cs
├── Form1.Designer.cs
├── Form1.resx
├── Form1.en.resx
│
├── Program.cs
├── App.config
│
├── AutodjaOmanikud.csproj
└── AutodjaOmanikud.sln
```

Repository sisaldab eraldi `Data`, `Models` ja `Migrations` kaustu ning Windows Forms vormi faile.

---

## 🚀 Projekti käivitamine

### 1. Klooni repository

```bash
git clone https://github.com/painkiller102k/AutodjaOmanikud.git
```

### 2. Ava projekt

Ava fail:

```text
AutodjaOmanikud.sln
```

Visual Studios.

### 3. Kontrolli andmebaasi ühendust

Enne käivitamist kontrolli `App.config` failis olevat andmebaasi ühenduse seadistust.

### 4. Uuenda andmebaasi

Package Manager Console'is:

```powershell
Update-Database
```

See rakendab olemasolevad Entity Framework Core migratsioonid andmebaasile.

### 5. Käivita rakendus

Visual Studios vajuta:

```text
F5
```

või käivita projekt **Start** nupuga.

---

## 🧩 CRUD-operatsioonid

Projekt kasutab klassikalisi CRUD-operatsioone:

| Operatsioon | Näide                                  |
| ----------- | -------------------------------------- |
| **Create**  | Uue omaniku, auto või teenuse lisamine |
| **Read**    | Andmete kuvamine tabelites             |
| **Update**  | Olemasolevate andmete muutmine         |
| **Delete**  | Andmete kustutamine                    |

Entity Framework Core'i kaudu kasutatakse andmete lisamiseks, muutmiseks ja kustutamiseks `Add()`, `Find()`, `Remove()` ja `SaveChanges()` meetodeid.

---

## 🖥️ Kasutajaliides

Rakendus on ehitatud **Windows Forms** tehnoloogia abil ning kasutab tabelvaateid ja vormielemente andmete sisestamiseks ja kuvamiseks.

Peamised kasutajaliidese komponendid:

* `DataGridView`
* `TextBox`
* `ComboBox`
* `CheckBox`
* `DateTimePicker`
* `Button`

Andmed kuvatakse tabelites ning valitud kirje põhjal saab vormivälju muuta.

---

## 🎓 Projekti eesmärk

Projekt on loodud õppetöö raames eesmärgiga praktiseerida:

* C# programmeerimist
* objektorienteeritud programmeerimist
* Windows Forms rakenduste loomist
* Entity Framework Core kasutamist
* SQL Server andmebaasidega töötamist
* CRUD-operatsioone
* relatsiooniliste andmete ja seoste haldamist
* LINQ päringute kasutamist
* Entity Framework Migrations kasutamist


---

## 📌 Projekti staatus

🟢 **Valmis / õppeprojekt**

Projekt on loodud praktilise C# ja Entity Framework Core kogemuse arendamiseks ning demonstreerib täisfunktsionaalse Windows Forms + andmebaasi lahenduse loomist.

---

### ⭐ Tehnoloogiad

`C#` · `.NET 8` · `WinForms` · `Entity Framework Core` · `SQL Server` · `LINQ` · `Migrations`
