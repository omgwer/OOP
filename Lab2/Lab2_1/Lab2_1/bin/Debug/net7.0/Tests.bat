@rem 1 Невалидное значение 
@call .\Lab2_1.exe < invalidFile1.txt  > tmp.txt
@if not %errorlevel% == 1 echo "Test 1 Fail"
@if %errorlevel% == 1 echo "Test 1 Success"

@rem 2 Позитивный кейс пустая строка
@call .\Lab2_1.exe < emptyFile.txt > tmp.txt  
@if not %errorlevel% == 0 echo "Test 2 Fail"
@if %errorlevel% == 0 echo "Test 2 Success    
@fc .\tmp.txt .\emptyFile.txt                   
                          
@rem 3 Позитивный кейс преобразование одной строки
@call .\Lab2_1.exe < inputFile1.txt > tmp.txt   
@if not %errorlevel% == 0 echo "Test 3 Fail"
@if %errorlevel% == 0 echo "Test 3 Success" 
@fc .\tmp.txt .\ethalonFile1.txt 

@rem 4 Позитивный кейс преобразование нескольких строки
@call .\Lab2_1.exe < inputFile2.txt > tmp.txt    
@if not %errorlevel% == 0 echo "Test 4 Fail"
@if %errorlevel% == 0 echo "Test 4 Success" 
@fc .\tmp.txt .\ethalonFile2.txt                          

@goto end                                


:error
@echo "Error in test!"

:ok
@echo "Test success!"

:end
@pause