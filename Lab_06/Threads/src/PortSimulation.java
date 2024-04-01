import java.util.concurrent.ExecutorService;
import java.util.concurrent.Executors;

class Port {
    private int currentContainers = 0;
    private int capacity = 100; // Вместимость порта

    public int getCurrentContainers() {
        return currentContainers;
    }

    public synchronized void loadContainers(int amount) {
        while (currentContainers + amount > capacity) {
            try {
                wait(); // Ожидаем, если порт переполнен
            } catch (InterruptedException e) {
                Thread.currentThread().interrupt();
            }
        }
        currentContainers += amount;
        System.out.println(Thread.currentThread().getName() + " загрузил " + amount + " контейнеров. В порту: " + currentContainers);
        notifyAll(); // Уведомляем другие потоки о доступности порта
    }

    public synchronized void unloadContainers(int amount) {
        while (currentContainers < amount) {
            try {
                wait(); // Ожидаем, если в порту недостаточно контейнеров
            } catch (InterruptedException e) {
                Thread.currentThread().interrupt();
            }
        }
        currentContainers -= amount;
        System.out.println(Thread.currentThread().getName() + " разгрузил " + amount + " контейнеров. В порту: " + currentContainers);
        notifyAll(); // Уведомляем другие потоки о доступности порта
    }
}



public class PortSimulation {
    public static void main(String[] args) {
        Port port = new Port();
        ExecutorService executor = Executors.newFixedThreadPool(3); // Количество причалов

        // Создание и запуск кораблей
        Ship ship1 = new Ship("Корабль 1", 50, 20, 30, port);
        Ship ship2 = new Ship("Корабль 2", 40, 30, 15, port);
        Ship ship3 = new Ship("Корабль 3", 60, 25, 35, port);

        executor.execute(ship1);
        executor.execute(ship2);
        executor.execute(ship3);

        executor.shutdown();
    }
}
