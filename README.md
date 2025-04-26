# CustomBinderDemo

This repository demonstrates the use of a custom model binder in an ASP.NET Core application.

## Features

- Custom model binding for complex objects.
- Example usage of model binders in controllers.
- Easy-to-follow code structure for learning purposes.

## Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download) (version 8.0 or later)
- Basic knowledge of ASP.NET Core.

## Getting Started

1. Clone the repository:
    ```bash
    git clone https://github.com/your-username/CustomBinderDemo.git
    cd CustomBinderDemo
    ```

2. Build the project:
    ```bash
    dotnet build
    ```

3. Run the application:
    ```bash
    dotnet run
    ```

4. Use a tool like [Postman](https://www.postman.com/), [Bruno](https://www.usebruno.com/), or `curl` to test the 
custom decimal model binder. Send a `GET` request to the following endpoint:

    ```
    https://localhost:7030/api/test?test=123,45
    ```

    For example, using `curl`:

    ```bash
    curl "https://localhost:7030/api/test?test=123,45"
    ```

    This will trigger the custom model binder that will parse the given number in the query string using the `es-CR` 
    culture, which uses the comma as the decimal separator.

## Project Structure

- **Controllers/**: Contains the API controllers.
- **ModelBinders/**: Custom model binder implementations.

## Contributing

Contributions are welcome! Please fork the repository and submit a pull request.

## License

This project is licensed under the [MIT License](LICENSE).
