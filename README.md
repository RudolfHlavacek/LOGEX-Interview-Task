# Interview Task for company LOGEX

## Vytvořte konzolovou aplikaci.

### Slovní popis:
Do vstupu přijde libovolný počet záznamů ve formátu XXX_Jméno.Přijmení (např.: "121_Pavel.Novák" nebo "1_Petr.Ospalý")
Aplikace dokáže spočítat kolik záznamů má stejné číslo (XXX) a vypsat počet a všechna přijmení do řádku.
Čísla budou seřazena od nejpočetnějšího zastoupení po nejméně početná. Přijmení budou seřazena podle abecedy.
Počáteční číslo XXX nemůsí být zadáno 3 ciframy. Čísla "001","01","1" jsou brána jako totožná.

Příklad:

### Vstup:
    020_Jan.Krutý
    21_Petr.Malý
    021_Pavel.Novák
    514_Karel.Ospalý

### Výstup:
    021 2x: Malý, Novák
    020 1x: Krutý
    514 1x: Ospalý

Odevzdání: Solution pro Microsoft Visual studio.
