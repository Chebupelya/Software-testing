import java.util.concurrent.ExecutorService;
import java.util.concurrent.Executors;

public class Main {
    public static void main(String[] args) {
        Port port = new Port();
        ExecutorService executor = Executors.newFixedThreadPool(3); // 3 причала

        Ship ship1 = new Ship("Корабль 1", 70, 30, 40, port);
        Ship ship2 = new Ship("Корабль 2", 90, 40, 20, port);
        Ship ship3 = new Ship("Корабль 3", 80, 35, 45, port);

        executor.execute(ship1);
        executor.execute(ship2);
        executor.execute(ship3);

        executor.shutdown();

        while (!executor.isTerminated()) {
            Thread.yield();
        }

        System.out.println("Все корабли завершили работу. Остаток контейнеров в порту: " + port.getCurrentContainers());
    }
}
