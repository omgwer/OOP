@rem 1 Ошибка параметров командной строки нет аргументов
@call .\Lab1_3.exe
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