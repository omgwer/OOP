@rem 1 Ошибка параметров командной строки нет аргументов у исполняемого файла
@call .\Lab1_2.exe
@if not %errorlevel% == 1 echo "Test 1 Fail"
@if %errorlevel% == 1 echo "Test 1 Success"

@rem 2 Ошибка параметров командной строки у исполняемого файла  1 параметр
@call .\Lab1_2.exe 4
@if not %errorlevel% == 1 echo "Test 2 Fail"
@if %errorlevel% == 1 echo "Test 2 Success"

@rem 3 Ошибка параметров командной строки у исполняемого файла  4 параметра
@call .\Lab1_2.exe 4 3 5 4
@if not %errorlevel% == 1 echo "Test 3 Fail"
@if %errorlevel% == 1 echo "Test 3 Success"

@rem 4 Ошибка параметров командной строки невалидное значение для первого параметра 1
@call .\Lab1_2.exe 1 3 1
@if not %errorlevel% == 1 echo "Test 4 Fail"
@if %errorlevel% == 1 echo "Test 4 Success"

@rem 5 Ошибка параметров командной строки невалидное значение для первого параметра 37
@call .\Lab1_2.exe 37 2 101
@if not %errorlevel% == 1 echo "Test 5 Fail"
@if %errorlevel% == 1 echo "Test 5 Success"  

@rem 6 Ошибка параметров командной строки невалидное значение для второго параметра 1
@call .\Lab1_2.exe 2 1 101
@if not %errorlevel% == 1 echo "Test 6 Fail"
@if %errorlevel% == 1 echo "Test 6 Success"    

@rem 7 Ошибка параметров командной строки невалидное значение для второго параметра 37
@call .\Lab1_2.exe 2 37 101
@if not %errorlevel% == 1 echo "Test 7 Fail"
@if %errorlevel% == 1 echo "Test 7 Success"
                                                  
@rem 8 Ошибка параметров командной строки значение третьего аргумента не соответствует введенной степени счисления
@call .\Lab1_2.exe 2 10 123
@if not %errorlevel% == 1 echo "Test 8 Fail"
@if %errorlevel% == 1 echo "Test 8 Success"
                                           
@rem 9 Ошибка параметров командной строки значение третьего аргумента > maxInt
@call .\Lab1_2.exe 10 16 2147483648
@if not %errorlevel% == 1 echo "Test 9 Fail"
@if %errorlevel% == 1 echo "Test 9 Success"   
                                   
@rem 10 Ошибка параметров командной строки значение третьего аргумента < minInt
@call .\Lab1_2.exe 10 16 -2147483649
@if not %errorlevel% == 1 echo "Test 10 Fail"
@if %errorlevel% == 1 echo "Test 10 Success"
@rem 1 Позитивный кейс
@call .\Lab1_2.exe 2 10 10101 > tmp.txt
@if not errorlevel 0 goto error
@fc .\tmp.txt .\et1.txt
                             
@rem 2 Позитивный кейс преобразование граничных значений
@call .\Lab1_2.exe 10 2 2147483647 > tmp.txt
@if not errorlevel 0 goto error
@fc .\tmp.txt .\et2.txt
              
@rem 3 Позитивный кейс преобразование граничных значений
@call .\Lab1_2.exe 10 16 -2147483648 > tmp.txt
@if not errorlevel 0 goto error
@fc .\tmp.txt .\et3.txt  

@goto end

:error
@echo "Error in test!"
@goto end

:ok                                            
@rem  @cls
@echo "Test success!"
@goto end

:end
@pause