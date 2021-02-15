# Azure Function Subscriber de Service Bus Queue e Azure Storage Queue
O projeto é um exemplo simples de um Subscriber desenvolvido como uma Azure Function em .NET Core 3.1.

Temos duas Functions, uma escutando uma fila no Service Bus, e outra escutando uma fila no Azure Storage Queue.

Algumas implementações que estão no projeto:
- Injeção de Dependencia na Azure Function
- MediatR para chamar os dois Commands (CQRS) de exemplo
- Notifications nos dois Commands de exemplo, simulando o disparo de notificações
- xUnit e Moq para testar as mensagens recebidas pelas Functions
- Leitura do appSettings.json para obter as Connections Strings das filas
