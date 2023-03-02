@rem Ошибка параметров командной строки нет аргументов у исполняемого файла
@call .\Lab1.exe
@if not errorlevel 1 goto error

@rem Ошибка параметров командной строки один аргумент у исполняемого файла
@call .\Lab1.exe firstFile.txt
@if not errorlevel 1 goto error

@rem Ошибка параметров командной строки 3 аргумента у исполняемого файла
@call .\Lab1.exe firstFile.txt someCommand thirdCommand
@if not errorlevel 1 goto error

@rem Ошибка параметров командной строки невалидный аргумент у исполняемого файла
@call .\Lab1.exe someone Lorem
@if not errorlevel 1 goto error
                               
@rem Ошибка открытия FileStream отстутствует файл
@call .\Lab1.exe test.txt someone
@if not errorlevel 1 goto error

@rem Ошибка открытия FileStream невозможно прочитать файл
@call .\Lab1.exe Lab1.exe test
@if not errorlevel 1 goto error

@rem Подстрока не найдена
@call .\Lab1.exe firstFile.txt someoneTextNotFound
@if not errorlevel 1 goto error

@rem Искомая подстрока отличается Upper\Lower case
@call .\Lab1.exe firstFile.txt lorem
@if not errorlevel 1 goto error   

@rem Пустой файл
@call .\Lab1.exe emptyFile.txt Someone
@if not errorlevel 1 goto error                  


@rem Позитивные тесты
@rem Поиск подстроки в файле строк в файле больше одной
@call .\Lab1.exe secondFile.txt Lorem > tmp.txt
@if errorlevel 0 goto ok
@fc .\tmp.txt .\SearchFirstResult.txt

@rem Поиск подстроки в файле
@call .\Lab1.exe firstFile.txt Lorem > tmp.txt
@if errorlevel 0 goto ok 
@fc .\tmp.txt .\SearchSecondResult.txt

:error
@echo "Error in test!"
@goto end

:ok
@cls
@echo "Test success!"
@goto end

:end
@pause