import java.sql.SQLException;

public class Main {
    public static void main(String[] args) throws SQLException {
        ClockQueries clockQueries = new ClockQueries();

        // Вывести марки механических часов с ценой не выше 100.0
        clockQueries.getMechanicalClocksByPrice(100);

        clockQueries.getClockBrandsByType("Quartz");

        // Закрыть соединение
        clockQueries.closeConnection();
    }
}
