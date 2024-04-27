package pages.KufarTest;

import org.openqa.selenium.By;
import org.openqa.selenium.Keys;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.chrome.ChromeDriver;
import org.openqa.selenium.support.ui.ExpectedConditions;
import org.openqa.selenium.support.ui.WebDriverWait;
import org.testng.Assert;
import org.testng.AssertJUnit;
import org.testng.annotations.*;
import pages.BringItOnPage;
import pages.SavedPastePage;

import java.time.Duration;
import java.util.List;

public class KufarAddToCartTest {
    private WebDriver driver;

    @BeforeClass
    public void setUp() {

        driver = new ChromeDriver();
        driver.get("https://www.kufar.by/l/r~minsk");
    }

    @Test
    public void testAddToCart() throws InterruptedException {
        // Выполните поиск товара
        WebElement searchBox = driver.findElement(By.xpath("//*[@id=\"header\"]/div[1]/div[2]/div/div/div/div/input"));
        searchBox.sendKeys("AM3+");
        WebElement searchInputButton = driver.findElement(By.className("styles_search_button__HMLQM"));
        searchInputButton.click();
        // Подождите несколько секунд для загрузки результатов поиска
        try {
            Thread.sleep(3000);
        } catch (InterruptedException e) {
            e.printStackTrace();
        }

        WebElement searchResults = driver.findElement(By.className("styles_cards___qpff"));
        WebElement test = driver.findElement(By.xpath("//*[@id=\"main-content\"]/div[6]/div[1]/div/div[2]/div[2]/div/div/section[1]/a"));
        test.click();
        List<WebElement> list = searchResults.findElements(By.tagName("section"));
        System.out.println(list);
        WebElement first = list.get(4).findElement(By.tagName("a"));
        System.out.println(first);
        if (!list.isEmpty()) {
            Thread.sleep(3000);
            new WebDriverWait(driver, Duration.ofSeconds(20)).until(ExpectedConditions.elementToBeClickable(list.get(4)));

            //WebElement firstItemLink = searchResults.get(15).findElement(By.tagName("a"));
            //firstItemLink.click();
        } else {
            System.out.println("Результаты поиска не найдены");
        }
        WebElement addToCartButton = driver.findElement(By.xpath("//*[@id=\"main-content\"]/div[4]/div/div/div/div[2]/div/div/section[4]/a"));
        addToCartButton.click();

        // Подождите несколько секунд, чтобы корзина успела обновиться
        try {
            Thread.sleep(3000);
        } catch (InterruptedException e) {
            e.printStackTrace();
        }

        // Проверьте, что товар успешно добавлен в корзину
        WebElement cartItem = driver.findElement(By.xpath("//div[@data-qa-id='cart-item']"));
        assert cartItem != null : "Товар не был добавлен в корзину";
    }

    @AfterClass
    public void tearDown() {
        driver.quit();
    }

}
