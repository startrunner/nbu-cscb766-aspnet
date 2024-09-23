# FixMyHouse - Описание на базата от данни

![database-schema](./docs-images/database-schema.png)

### Artisans - Таблица с Майстори

`Name`, `Bio` - име, кратко описание

`Picture` - име на файла със снимка на майстора

### Services - Таблица с видове услуги

`Name`, `Description` - име, кратко описание на услуга

`Picture` - има на файла с илюстрация на услуга

### ArtisanServices - Бридж таблица между майстори и видове услуги

`CustomizationDefaults`e JSON колона, която описва полетата за персонализиране на услугата и има подобна схема:

`({id, name, description} & ({ type: "checkbox", valueIfTrue: decimal } | {type: "whole-number" & valueMultiplier: decimal } | { type: "options", availableOptions: [...] }))[]`

Т.е, това е сериализиран масив от "discriminated union" тип, като има различен вариант за всеки тип поле.

### ServiceReservations - Таблица с резервирани услуги

`CustomizationBooleans` е JSON колона със сериализиран `Dictionary<Guid, bool>` за всички стойности `bool` полета на съответната услуга. Ключът на речника е Id-то на съответното поле.

`CustomizationGuids` е JSON колона със сериализиран `Dictionary<Guid, Guid>` за всички `Guid` полета на съответната услуга - това са dropdown полетата, т.к всяка опция от един dropdown има id. Ключът на речника е Id-то на съответното поле.

`CustomizationWholeNumbers` е JSON колона със сериализиран `Dictionary<Guid, int>` за всички целочислени полета на съответната услуга. Ключът на речника е Id-то на съответното поле.

`CalculatedPrice` е обикновена `decimal` колона и се изчислява от приложението по време на резервиране на услугата.

### Други бележки

**Има доста други таблици от ASP.Net Core Identity, но те са стандартни.**