@rem 1 Ошибка параметров командной строки нет аргументов
@call .\Lab1_3.exe
@if not errorlevel 1 goto error

@rem 2 Ошибка параметров командной строки файл не существует
@call .\Lab1_3.exe errorfile.txt
@if not errorlevel 1 goto error

@rem 3 Ошибка параметров командной строки количество строк != 3
@call .\Lab1_3.exe negative1.txt
@if not errorlevel 1 goto error

@rem 4 Ошибка параметров командной строки количество параметров в строке != 3
@call .\Lab1_3.exe negative2.txt
@if not errorlevel 1 goto error

@rem 5 Ошибка параметров командной строки одно из чисел нельзя преобразовать
@call .\Lab1_3.exe negative3.txt
@if not errorlevel 1 goto error

@rem 6 Позитивный кейс
@call .\Lab1_3.exe lab1_3.txt > out.txt
@if errorlevel 0 goto ok



:error
@echo "Error in test!"
@goto end

:ok
@rem @cls
@echo "Test success!"
@goto end

:end
@pause