﻿/// 
/// Проектище
///

Процедура СделатьХорошо(Знач А, Знач Б)

	Если Истина = Ложь Тогда
		Сообщить(ТекущаяДата());
	КонецЕсли;

КонецПроцедуры

Запрос = Новый Запрос;
Запрос.Текст = "
	|ВЫБРАТЬ ПЕРВЫЕ 1 1
	// Пояснение внутри строки
	|ИЗ Справочник.Справочник1
	|ГДЕ НЕ ПометкаУдаления" // Пояснение после строки


;

СделатьХорошо(12, '20150101');