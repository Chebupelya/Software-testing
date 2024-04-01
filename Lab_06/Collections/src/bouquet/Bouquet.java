package bouquet;

import flowers.Flower;
import accessories.Accessory;

import java.util.ArrayList;
import java.util.Collections;
import java.util.Comparator;
import java.util.List;

public class Bouquet {
    private List<Flower> flowers = new ArrayList<>();
    private List<Accessory> accessories = new ArrayList<>();

    public void addFlower(Flower flower) {
        flowers.add(flower);
    }

    public void addAccessory(Accessory accessory) {
        accessories.add(accessory);
    }

    public double calculateTotalCost() {
        double totalCost = 0;
        for (Flower flower : flowers) {
            totalCost += flower.getPrice();
        }
        for (Accessory accessory : accessories) {
            totalCost += accessory.getPrice();
        }
        return totalCost;
    }

    public void sortByFreshness() {
        Collections.sort(flowers, new Comparator<Flower>() {
            @Override
            public int compare(Flower flower1, Flower flower2) {
                return Integer.compare(flower2.getFreshnessLevel(), flower1.getFreshnessLevel());
            }
        });
    }
    public List<Flower> findFlowersByStemLength(double minLength, double maxLength) {
        List<Flower> result = new ArrayList<>();
        for (Flower flower : flowers) {
            if (flower.getStemLength() >= minLength && flower.getStemLength() <= maxLength) {
                result.add(flower);
            }
        }
        return result;
    }
}
