# GreenTeam
```mermaid
sequenceDiagram
Client --Аутентификационные данные--> AuthMicroService: Authentication Request
AuthMicroService --> Client: Authentication Response
Client -> AuthMicroService:Another authentication Response
AuthMicroService --> Client: Another authentication Response
```
