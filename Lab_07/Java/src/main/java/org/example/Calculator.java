package org.example;

public class Calculator {
    public static double add(double number1, double number2) {
        return number1 + number2;
    }

    public static double sub(double number1, double number2) {
        return number1 - number2;
    }

    public static double mult(double number1, double number2) {
        return number1 * number2;
    }

    public static double div(double number1, double number2) {
        if (number2 == 0) {
            throw new ArithmeticException("Division by zero is not allowed.");
        }
        return number1 / number2;
    }

    public static double pow(double number1, int degree) {
        if(degree == 0)
            return 1;
        double result = number1;
        for (int i = 1; i < degree; i++) {
            result *= number1;
        }
        return result;
    }

    public static double findSquareRoot(double number, double epsilon) {
        if(number < 0){
            throw new ArithmeticException("A number less than zero.");
        }
        if (number == 0) {
            return 0;
        }

        double guess = number / 2.0;
        double previousGuess = 0.0;

        while (Math.abs(guess - previousGuess) > epsilon) {
            previousGuess = guess;
            guess = 0.5 * (guess + number / guess);
        }

        return guess;
    }

}
