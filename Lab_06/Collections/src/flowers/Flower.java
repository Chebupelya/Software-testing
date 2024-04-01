package flowers;

public class Flower {
    private String name;
    private double price;
    private int freshnessLevel;
    private double stemLength;

    public Flower(String name, double price, int freshnessLevel, double stemLength) {
        this.name = name;
        this.price = price;
        this.freshnessLevel = freshnessLevel;
        this.stemLength = stemLength;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public double getPrice() {
        return price;
    }

    public void setPrice(double price) {
        this.price = price;
    }

    public int getFreshnessLevel() {
        return freshnessLevel;
    }

    public void setFreshnessLevel(int freshnessLevel) {
        this.freshnessLevel = freshnessLevel;
    }

    public double getStemLength() {
        return stemLength;
    }

    public void setStemLength(double stemLength) {
        this.stemLength = stemLength;
    }

    // Геттеры и сеттеры

    public String toString() {
        return name;
    }
}
