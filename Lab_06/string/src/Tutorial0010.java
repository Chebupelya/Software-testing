import java.util.*;

public class Tutorial0010 {
    public static boolean startsWithVovel(String s) {
        return s.length() > 0 && !Task8.isConsonant(s.charAt(0));
    }

    public static void main(String[] args) {
        String text = "Здравствуйте. У меня имеется следующее задание: слова английского текста, начинающиеся с гласных букв, рассортировать в алфавитном порядке по первой согласной букве слова.\n" +
                "Написал код, но работает он некорректно, сортировка не получается вообще. Помогите, пожалуйста, решить проблему.\n" +
                "Заранее спасибо.";
        List<String> words = new LinkedList<String>(Arrays.asList(text.split("[\\s\\p{Punct}]+")));
        Collections.sort(words, Task8.getInstance());

        for (ListIterator<String> iterator = words.listIterator(); iterator.hasNext(); ) {
            if (!startsWithVovel(iterator.next()))
                iterator.remove();
        }

        System.out.println(words);
    }
}
