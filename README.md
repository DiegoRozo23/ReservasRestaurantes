# Sistema de Reservas y Reseñas para Restaurantes

Este proyecto es una API REST desarrollada con ASP.NET Core y Entity Framework Core, diseñada para gestionar un sistema de reservas en restaurantes, incluyendo la gestión de usuarios, reservas, mesas y reseñas.

---

## Características

- **Gestión de Usuarios:** Registro, autenticación y manejo de datos de los usuarios.
- **Reservas:** Permite a los usuarios realizar, consultar y cancelar reservas en restaurantes.
- **Restaurantes:** Manejo de información sobre restaurantes, incluyendo capacidad, ubicación y tipo de cocina.
- **Mesas:** Gestión de mesas disponibles en cada restaurante.
- **Reseñas:** Los usuarios pueden dejar reseñas y calificar restaurantes.
- **JWT Authentication:** Seguridad en la API mediante tokens JWT.
- **Swagger:** Documentación interactiva de la API para facilitar pruebas y desarrollo.

---

## Tecnologías Utilizadas

- [.NET 8](https://dotnet.microsoft.com/)
- [ASP.NET Core](https://docs.microsoft.com/aspnet/core)
- [Entity Framework Core](https://docs.microsoft.com/ef/core)
- [SQL Server](https://www.microsoft.com/sql-server)
- [JWT (Json Web Tokens)](https://jwt.io/)
- [Swagger](https://swagger.io/)

---

## Estructura del Proyecto

- **Models:**  
  Define las entidades principales del dominio:
  - `Usuario`
  - `Restaurante`
  - `Reserva` (incluye el enum `EstadoReserva`)
  - `Resena`
  - `Mesa`
  - Otros modelos para autenticación, como `LoginRequest` y `AuthResponse`.

- **Data:**  
  Contiene el `ApplicationDbContext`, que configura las conexiones y los DbSet para interactuar con la base de datos.

- **Controllers:**

  Los Controllers actúan como punto de entrada para las solicitudes de la API y se encargan de:

  - **Recibir y validar solicitudes:** Interpretan los datos de entrada, gestionan la autenticación y la autorización, y aseguran que la información recibida cumple con los requisitos esperados.
  - **Invocar la lógica de negocio:** Llaman a los servicios correspondientes para procesar la solicitud y aplicar la lógica de negocio.
  - **Devolver respuestas estructuradas:** Retornan los datos en formatos predefinidos (por lo general, en JSON) junto con los códigos de estado HTTP apropiados.

  Cada controller está diseñado para mantener una arquitectura limpia y modular, facilitando la escalabilidad y el mantenimiento del sistema a lo largo del tiempo.


- **Services:**  
  Incluye la lógica de negocio para:
  - Autenticación (`AuthService`)
  - Gestión de reservas (`ReservaService`)
  - Gestión de restaurantes (`RestauranteService`)
  - Gestión de usuarios (`UsuarioService`)
  - Gestión de reseñas (`ResenaService`)
  - Gestión de mesas (`MesaService`)

- **Program.cs:**  
  Configura el pipeline HTTP, registra servicios (como autenticación, autorización, Swagger, y DbContext), y define el comportamiento de la aplicación en tiempo de ejecución.

---
## DTOs (Data Transfer Objects)

Para estructurar de manera clara los datos de entrada y salida de la API, se han definido varios DTOs. Estos objetos permiten:

- **Separar la lógica de presentación de la lógica de negocio:** Facilitan la validación y transformación de datos entre el cliente y la API.
- **Controlar la exposición de datos sensibles:** Limitando la información que se envía o recibe en cada operación.
- **Simplificar el mapeo entre las entidades del modelo y los datos transferidos:** Mejorando la claridad y mantenibilidad del código.


