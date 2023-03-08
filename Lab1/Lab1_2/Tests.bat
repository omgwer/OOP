@rem Ошибка параметров командной строки нет аргументов у исполняемого файла
@call .\Lab1_2.exe
@if not errorlevel 1 goto error

@rem Ошибка параметров командной строки один аргумент у исполняемого файла  1 параметр
@call .\Lab1_2.exe 4
@if not errorlevel 1 goto error

@rem Ошибка параметров командной строки один аргумент у исполняемого файла  4 параметра
@call .\Lab1_2.exe 4 3 5 4
@if not errorlevel 1 goto error

@rem Ошибка параметров командной строки один аргумент у исполняемого файла  4 параметра
@call .\Lab1_2.exe 4 3 5 4
@if not errorlevel 1 goto error

@rem Позитивный кейс
@call .\Lab1_2.exe 2 8 10
@if not errorlevel 0 goto ok

:error
@echo "Error in test!"
@goto end

:ok
@cls
@echo "Test success!"
@goto end

:end
@pause