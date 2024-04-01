import bouquet.Bouquet;
import flowers.Flower;
import accessories.Accessory;

import java.util.List;

public class Main {
    public static void main(String[] args) {
        Flower rose = new Flower("Роза", 5.0, 9, 30.0);
        Flower tulip = new Flower("Тюльпан", 3.0, 8, 25.0);

        Accessory ribbon = new Accessory("Горшок", 2.0);
        Accessory vase = new Accessory("Ваза", 10.0);

        // создание букета и добавление цветов и аксессуаров
        Bouquet bouquet = new Bouquet();
        bouquet.addFlower(rose);
        bouquet.addFlower(tulip);
        bouquet.addAccessory(ribbon);
        bouquet.addAccessory(vase);

        // расчет стоимости букета
        double totalCost = bouquet.calculateTotalCost();
        System.out.println("Общая стоимость букета: $" + totalCost);

        // сортировка цветов по уровню свежести
        bouquet.sortByFreshness();

        // поиск цветов по длине стебля
        double minLength = 26.0;
        double maxLength = 31.0;
        List<Flower> selectedFlowers = bouquet.findFlowersByStemLength(minLength, maxLength);
        System.out.println("Цветы с длиной стебля между " + minLength + " and " + maxLength + ":\n" + selectedFlowers);
    }
}
