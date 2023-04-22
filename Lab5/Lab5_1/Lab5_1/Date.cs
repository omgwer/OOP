using Lab5_1.Dictionary;

namespace Lab5_1;
// Дата в формате день-месяц-год. Год в диапазоне от 1970 до 9999
public class Date
{
    private uint timestamp;
    // инициализируем дату заданными днем, месяцем и годом.
    // примечание: год >= 1970
    public Date(uint day, Month month, uint year)
    {
        throw new NotImplementedException();
    }
    // инициализируем дату количеством дней, прошедших после 1 января 1970 года
    // например, 2 = 3 января 1970, 32 = 2 февраля 1970 года и т.д.
    public Date(uint timestamp = 0)
    {
        throw new NotImplementedException();
    }

    // возвращает день месяца (от 1 до 31)
    uint GetDay()
    {
        throw new NotImplementedException();
    }

    // возвращает месяц
    Month GetMonth()
    {
        throw new NotImplementedException();
    }

    // возвращает год
    uint GetYear()
    {
        throw new NotImplementedException();
    }

    // возвращает день недели
    WeekDay GetWeekDay()
    {
        throw new NotImplementedException();
    }

    // возвращает информацию о корректности хранимой даты.
    // Например, после вызова CDate date(99, static_cast<Month>(99), 10983);
    // или после:
    //	CDate date(1, January, 1970); --date;
    // метод date.IsValid() должен вернуть false;
    bool IsValid()
    {
        throw new NotImplementedException();
    }
}