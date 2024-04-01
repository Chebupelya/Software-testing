import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;

public class ClockQueries {
    private Connection connection;

    public ClockQueries() {
        connection = DatabaseConnection.getConnection();
    }

    public void closeConnection() {
        try {
            if (connection != null) {
                connection.close();
            }
        } catch (SQLException e) {
            e.printStackTrace();
        }
    }

    // Вывести марки заданного типа часов
    public void getClockBrandsByType(String clockType) throws SQLException {
        System.out.println("Вывод брэнда часов по типу "+clockType+":");
        try {
            String sql = "SELECT brand FROM Watches WHERE type = ?";
            PreparedStatement statement = connection.prepareStatement(sql);
            statement.setString(1, clockType);

            ResultSet resultSet = statement.executeQuery();
            if (!resultSet.isBeforeFirst()) {
                System.out.println("No results found.");
            } else {
                while (resultSet.next()) {
                    String brand = resultSet.getString("brand");
                    System.out.println(brand);
                }
            } }catch(SQLException e){
                e.printStackTrace();
            }
        }
    // Вывести информацию о механических часах с ценой не выше заданной
    public void getMechanicalClocksByPrice(int maxPrice) {
        System.out.println("Вывод мех часов ценой <= "+maxPrice+":");

        try {
            String sql = "SELECT * FROM Watches WHERE type = 'Mechanical' AND price <= ?";
            PreparedStatement statement = connection.prepareStatement(sql);
            statement.setInt(1, maxPrice);

            ResultSet resultSet = statement.executeQuery();

            while (resultSet.next()) {
                int id = resultSet.getInt("watch_id"); // Corrected to "watch_id"
                int price = resultSet.getInt("price");
                String brand = resultSet.getString("brand");
                // Add output for other fields as needed
                System.out.println("ID: " + id + ", брэнд: " + brand+", цена: "+price);
            }
        } catch (SQLException e) {
            e.printStackTrace();
        }
    }


}
