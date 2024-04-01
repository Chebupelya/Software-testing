import java.util.*;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class Main {
    public static int n = 1;
    public static void main(String[] args) {
        String text = "Мой исходный текст здесь. Замените его на реальный текст.";

       System.out.println("\n-------\n"+"Task " + n++);
       Task1("абоба абоба. абоба. шлак шлак. шлак");

        System.out.println("\n-------\n"+"Task " + n++);
        Task2(text+"Однослова. Два слова.");

        System.out.println("\n-------\n"+"Task " + n++);
        Task3(" вот нелюбил и вс. это задание меня нелюбило.");
        Task3("абоба мой. абоба. шлак шлак. шлак и не абоба.");

        System.out.println("\n-------\n"+"Task " + n++);
        Task4(text+" ты ли это?", 5);

        System.out.println("\n-------\n"+"Task " + n++);
        Task5(text);

        System.out.println("\n-------\n"+"Task " + n++);
        Task6(text);
    }

    public static void Task1(String text) {
        // Разделяем текст на предложения
        String[] sentences = text.split("\\.");

        int maxSentenceCount = 0; // Максимальное количество предложений с одинаковыми словами
        Set<String> maxCommonWords = new HashSet<>(); // Множество для хранения наибольшего набора общих слов

        for (String sentence : sentences) {
            String[] words = sentence.trim().split("\\s+");
            Set<String> uniqueWords = new HashSet<>(); // Множество для хранения уникальных слов в текущем предложении

            for (String word : words) {
                uniqueWords.add(word);
            }

            if (uniqueWords.size() >= maxSentenceCount) {
                maxSentenceCount = uniqueWords.size();
                maxCommonWords = uniqueWords;
            }
        }

        System.out.println("Наибольшее количество предложений с одинаковыми словами: " + maxSentenceCount);
        System.out.println("Общие слова в предложениях: " + maxCommonWords);
    }

    public static void Task2(String text) {
        String[] sentences = text.split("[.!?]");

        Arrays.sort(sentences, Comparator.comparingInt(s -> s.split("\\s+").length));

        for (String sentence : sentences) {
            System.out.println(sentence);
        }
    }

    public static void Task3(String text) {
        String[] sentences = text.split("\\.");

        // делим первое предложение на слова
        String[] firstSentenceWords = sentences[0].trim().split("\\s+");

        // cоздаю множество для уникальных слов
        Set<String> uniqueWords = new HashSet<>();

        // добавляю все слова из первого предложения в множество
        Collections.addAll(uniqueWords, firstSentenceWords);

        // перебераю остальные предложения
        for (int i = 1; i < sentences.length; i++) {
            String[] sentenceWords = sentences[i].trim().split("\\s+");
            for (String word : sentenceWords) {
                // если слово есть в множестве, удалим его
                if (uniqueWords.contains(word)) {
                    uniqueWords.remove(word);
                }
            }
        }

        if (!uniqueWords.isEmpty()) {
            System.out.println("Слово, которого нет ни в одном из остальных предложений: " + uniqueWords.iterator().next());
        } else {
            System.out.println("Все слова в первом предложении встречаются в остальных предложениях.");
        }
    }

    public static void Task4(String text, int length) {
        // создаю регулярное выражение для поиска вопроса
        Pattern pattern = Pattern.compile("[А-ЯA-Z][^.!?]*\\?");

        // создаею объект Matcher для поиска
        Matcher matcher = pattern.matcher(text);

        while (matcher.find()) {
            // извлекаю найденное вопросительное предложение
            String questionSentence = matcher.group().trim();

            // разбиваю предложение на слова и ищю слова заданной длины
            String[] words = questionSentence.split("\\s+");
            Set<String> uniqueWords = new HashSet<>();

            for (String word : words) {
                word = word.replaceAll("[^а-яА-Яa-zA-Z]", ""); // Убираем знаки пунктуации
                if (word.length() == length) {
                    uniqueWords.add(word);
                }
            }

            // вывожу уникальные слова нужной длины без повторений
            System.out.println("Слова заданной длины " + length + " в вопросительном предложении: " + uniqueWords);
        }
    }

    public static void Task5(String text) {
        String[] sentences = text.split("[.!?]");

        for (int i = 0; i < sentences.length; i++) {
            String sentence = sentences[i].trim();
            String[] words = sentence.split("\\s+");

            if (words.length >= 2) {
                // меняю местами первое и последнее слово
                String firstWord = words[0];
                words[0] = words[words.length - 1];
                words[words.length - 1] = firstWord;

                // собираю предложение обратно
                StringBuilder newSentence = new StringBuilder();
                for (String word : words) {
                    newSentence.append(word).append(" ");
                }

                // меняю исходное предложение на новое в тексте
                sentences[i] = newSentence.toString().trim();
            }
        }

        for (String sentence : sentences) {
            System.out.println(sentence);
        }
    }

    public static void Task6(String text) {
        String[] words = text.split("\\s+");
        // Преобразуем слова в нижний регистр перед сортировкой
        for (int i = 0; i < words.length; i++) {
            words[i] = words[i].toLowerCase();
        }
        Arrays.sort(words);

        char currentLetter = ' ';
        for (String word : words) {
            if (word.charAt(0) != currentLetter) {
                currentLetter = word.charAt(0);
                System.out.println();
            }
            System.out.print(word + " ");
        }
    }
}

