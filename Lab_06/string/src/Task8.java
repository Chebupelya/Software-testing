import java.util.*;

class Task8 implements Comparator<String> {
    private final static Comparator<String> instance = new Task8();
    private final static String CONSONANTS = "BCDFGHJKLMNPQRSTVXZWYЙЦКНГШЩЗХЪФВПРЛДЖЧСМТЬБ";

    public static Comparator<String> getInstance() {
        return instance;
    }

    public static boolean isConsonant(Character c) {
        return CONSONANTS.indexOf(Character.toUpperCase(c)) > -1;
    }

    private Character getFirstConsonant(String string) {
        for (int i = 0; i < string.length(); ++i)
            if (isConsonant(string.charAt(i)))
                return string.charAt(i);
        return Character.MIN_VALUE;
    }

    @Override
    public int compare(String a, String b) {
        Character consonantA = getFirstConsonant(a);
        Character consonantB = getFirstConsonant(b);
        return consonantA.compareTo(consonantB);
    }
}

