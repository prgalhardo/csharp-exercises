using System;

namespace ShippingCalculator;

public class ShippingCalculator
{
    /// <summary>
    /// This function evaluates the order price passed as an input parameter and returns the shipping price following the exercise's logic
    /// </summary>
    /// <param name="orderPrice"> A value of type double, the order price </param>
    /// <returns>The shipping price value (integer type), following the exercise logic </returns>
    /// <exception cref="ArgumentException">If the order price be equal to or less than zero</exception>

    // 1 - Calcular o Frete por preço do pedido na função `CalculateShippingPrice`
    public double calculateShippingPrice(double orderPrice)
    {
        if (orderPrice <= 50) {
            return 25;
        }
        if (orderPrice > 50 && orderPrice <= 100) {
            return 20;
        }
        if (orderPrice > 100 && orderPrice <= 200) {
            return 15;
        }
        else {
            return 0;
        }   
    }

    // 2 - Calcular o Frete por peso na função `CalculateShippingWeight`
    public double calculateShippingWeight(double weight)
    {
        if (weight <= 1.5) {
            return 3.80;
        }
        if (weight > 1.5 && weight <= 3.5) {
            return 5.70;
        }
        if (weight > 3.5 && weight <= 7.0) {
            return 7.20;
        }
        if (weight > 7.0 && weight <= 10.0) {
            return 9.40;
        }
        else {
            return weight * 1.90;
        }
    }

    // 3 - Calcular o Frete final na função `CalculateShipping`
    public double calculateShipping(double orderPrice, double weight) {
        double shippingPrice = calculateShippingPrice(orderPrice) + calculateShippingWeight(weight);
        if (shippingPrice > 45) {
            shippingPrice = shippingPrice * 0.85;
        }
        return shippingPrice;
    }

    // 4 - Calcular o Frete final para um array de preços e um array de pesos na função `CalculateShippingFromArray`
    public double calculateShippingFromArray(double[] itemPrices, double[] itemWeights)
    {
        if (itemPrices.Length != itemWeights.Length) {
            throw new ArgumentException("O comprimento do array de preços precisa ser igual ao comprimento do array de pesos.");
        }

        double totalPrice = 0;
        double totalWeight = 0;

        for (int i = 0; i < itemPrices.Length; i++) {
            totalPrice += itemPrices[i];
            totalWeight += itemWeights[i];
        }

        return calculateShipping(totalPrice, totalWeight);
    }

    // 5 - Calcular o Frete final para um array de preços e um array de pesos na função `CalculateShippingFromArray` (De uma outra maneira)
    public double anotherCalculateShippingFromArray(double[] itemPrices, double[] itemWeights)
    {
        double totalPrice = itemPrices.Sum();
        double totalWeight = itemWeights.Sum();
        double totalShippingPrice = calculateShipping(totalPrice, totalWeight);

        return totalShippingPrice;
    }

}


