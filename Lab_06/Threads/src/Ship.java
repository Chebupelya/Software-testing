class Ship implements Runnable {
    private String name;
    private int capacity;
    private int loadAmount;
    private int unloadAmount;
    private Port port;

    public Ship(String name, int capacity, int loadAmount, int unloadAmount, Port port) {
        this.name = name;
        this.capacity = capacity;
        this.loadAmount = loadAmount;
        this.unloadAmount = unloadAmount;
        this.port = port;
    }

    @Override
    public void run() {
        System.out.println(name + " прибыл в порт.");
        port.loadContainers(loadAmount);
        port.unloadContainers(unloadAmount);
        System.out.println(name + " ушел из порта.");
    }
}