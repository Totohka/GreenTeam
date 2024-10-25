# GreenTeam
```mermaid
sequenceDiagram
Client(User) -->> AuthMicroService: Authentication data (UserPass, API-Key, OAuth)
AuthMicroService -->> Client(User): Authentication Response (Access/refresh tokens)
Client(User) -->> SecretMicroService: Access/refresh token + requets data
SecretMicroService -->> Client(User): Responce secret data
```
```mermaid
sequenceDiagram
Client(Admin) -->> AuthMicroService: Authentication data (UserPass, API-Key, OAuth)
AuthMicroService -->> Client(Admin): Authentication Response (Access/refresh tokens)
Client(Admin) -->> AuditMicroService: Access/refresh token
AuditMicroService -->> Client(Admin): Responce audit data
Client(Admin) -->> PermissionService: Access/refresh token + policy access
PermissionService -->> Client(Admin): Responce
```
## C4 - Component
![c4Encryptarium](https://github.com/user-attachments/assets/b0dae691-9670-4906-b87a-46bc72ca60d4)

## Электронная подпись
![image](https://github.com/user-attachments/assets/e628fa87-56aa-47ba-94a4-c0a6f8bd13c6)
