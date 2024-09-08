# test
## Запуск проекта
### Запуск сервера
Для работы сервера необходимо установить Docker по ссылке https://www.docker.com/products/docker-desktop/. После установки необходимо открыть терминал в любой папке и выполнить команду `docker run -p 8888:8888 orlovanton01/server-image:latest`  
При успешном запуске контейнера появится сообщение `Сервер запущен и ожидает подключения...`
## Запуск клиента и тестов
Для работы клиента и тестов необходимо установить .NET с сайта https://dotnet.microsoft.com/ru-ru/download. После установки необходимо перейти в ветвь `client-and-tests` (ссылка https://github.com/orlovanton01/test/tree/client-and-tests), нажать `Code->Download ZIP`. После загрузки необходимо распаковать архив и перейти в папку клиента или тестов
## Запуск клиента
Необходимо открыть в терминале папку 'Client' и выполнить команду `dotnet run`. При успешном подключении в консоли вы увидите сообщения, полученные от сервера. Также в консоли сервера будут сообщения о том, что то или иное сообщение отправлено
## Запуск тестов
Необходимо открыть в терминале папку 'Tests' и поочерёдно выполнить команды ```dotnet add package xunit` dotnet add package FluentAssertions dotnet add package xunit.runner.visualstudio dotnet test```. При успешном запуске будете выведено сообщение о том, что тесты пройдены успешно
## Файлы исходного кода
Для просмотра исходного кода для сервера необходимо открыть файл `Program.cs` в каталоге `Server` ветви `main` (ссылка https://github.com/orlovanton01/test/tree/main), для исходного кода клиента необходимо открыть тот же файл в каталоге `Client` ветви `client-and-tests` (ссылка в разделе `Запуск клиента и тестов`). Для просмотра исходного кода тестов необходимо в той же ветке перейти в каталог `Tests` и открыть файл `UnitTest1.cs`
