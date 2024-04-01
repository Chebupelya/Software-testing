import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.SQLException;

public class DatabaseConnection {
    public static Connection getConnection() {
        // Обновите URL, имя пользователя и пароль
        String url = "jdbc:sqlserver://localhost:1433;databaseName=javajdbc";
        String username = "Node";
        String password = "1234";

        Connection connection = null;

        try {
            // Обновите на драйвер SQL Server
            Class.forName("com.microsoft.sqlserver.jdbc.SQLServerDriver");
            connection = DriverManager.getConnection(url, username, password);
            if (connection != null) {
                System.out.println("Успешное подключение к базе данных.");
            }
            return connection;
        } catch (ClassNotFoundException e) {
            e.printStackTrace();
            return null;
        } catch (SQLException e) {
            e.printStackTrace();
            return null;
        }
    }
}
