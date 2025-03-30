# ![CouitaTools](CouitaTools.svg)

**CouitaTools Pro** - Многофункциональная утилита для выполнения сложных операций над системой и уничтожения вирусов. Мы регулярно выпускаем обновления, чтобы обеспечить защиту от новейших угроз. 

# Текущая версия:

[![2.0b](https://img.shields.io/badge/CouitaTools_Pro-2.0b-blue.svg)](https://github.com/CouitaCommunity/CouitaTools)
[![4.7.2](https://img.shields.io/badge/.NET-4.7.2-blue.svg)](https://dotnet.microsoft.com/en-us/download/dotnet-framework/net472)

Эта версия CouitaTools полностью переписана на **C#** с улучшенными наименованиями функций и переменных. Исходный код этой ветки публикуется одновременно с обновлением оригинального репозитория.

# Лицензия

CouitaTools использует модифицированную MIT License. Перед модификацией данного проекта настоятельно рекомендуем ознакомиться с ней.

# Важно знать
Файлы из сборки данного репозитория **нельзя** напрямую сравнивать с релизными версиями CouitaTools Pro по техническим причинам:

1. Разные языки реализации

2. Особенности компиляции: используется .NET-платформа, а не нативные C/C++ решения

Оригинальный репозиторий **не гарантирует** бинарной идентичности с официальными релизами.
Различия в хешах файлов не являются признаком модификации.

Рекомендуем скачивать CouitaTools Pro **только** через проверенные официальные источники.

# Инструкция по сборке CouitaTools C# (.NET Framework 4.7.2)
### 1. Клонирование репозитория

Git:
```shell
git clone https://github.com/nedefined/CouitaTools.git
```

Github CLI:
```shell
gh auth login
```
```shell
gh repo clone nedefined/CouitaTools
```
После этого переходим в нужную папку:
```
cd CouitaTools/src
```
### 2. Восстановление зависимостей
**Автоматически** при открытии решения в Visual Studio, или:
```shell
dotnet restore
```

### 3. Сборка
Используя Develpment Powershell For VS 20?? из-под папки src:
```shell
msbuild /p:Configuration=Release /p:Platform="Any CPU"
```

Через Visual Studio:
```
Release - Any CPU >  Сборка > Собрать решение
```
### 4. Где найти результат?
В случае успеха собранный EXE-файл появится в:
```
bin\Release\CouitaTools.exe
```
