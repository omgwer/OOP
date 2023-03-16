@rem 1 Ошибка параметров командной строки нет аргументов
@call .\Lab1_3.exe
@if not %errorlevel% == 1 echo "Test 1 Fail"
@if %errorlevel% == 1 echo "Test 1 Success"
                                     
@rem 2 Ошибка параметров командной строки файл не существует
@call .\Lab1_3.exe errorfile.txt        
@if not %errorlevel% == 1 echo "Test 2 Fail"
@if %errorlevel% == 1 echo "Test 2 Success"

@rem 3 Ошибка параметров командной строки количество строк != 3
@call .\Lab1_3.exe negative1.txt     
@if not %errorlevel% == 1 echo "Test 3 Fail"
@if %errorlevel% == 1 echo "Test 3 Success"

@rem 4 Ошибка параметров командной строки количество параметров в строке != 3
@call .\Lab1_3.exe negative2.txt         
@if not %errorlevel% == 1 echo "Test 4 Fail"
@if %errorlevel% == 1 echo "Test 4 Success"

@rem 5 Ошибка параметров командной строки одно из чисел нельзя преобразовать
@call .\Lab1_3.exe negative3.txt             
@if not %errorlevel% == 1 echo "Test 5 Fail"
@if %errorlevel% == 1 echo "Test 5 Success"

@rem 6 Позитивный кейс
@call .\Lab1_3.exe lab1_3.txt > out.txt   
@if not %errorlevel% == 0 echo "Test 6 Fail"
@if %errorlevel% == 0 echo "Test 6 Success"

@goto end

:error
@echo "Error in test!"
@goto end

:ok
@rem @cls
@echo "Test success!"
@goto end

:end
@pause