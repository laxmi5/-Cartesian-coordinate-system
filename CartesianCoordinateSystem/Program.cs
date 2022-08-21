using System;

public class Program
{
    public static void Main()
    {
        int[,] array = new int[10, 10];

        DisplayArray(array);

        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine("Enter Bottom Left Corner coordinates, Width, Height");
            var coordinate = Console.ReadLine();
            if (!string.IsNullOrEmpty(coordinate))
            {
                UpdateCoordinates(coordinate, array);
            }
        }
    }

    private static void CalculateDotProduct(int[,] prevArray, int[,] array)
    {
        int[] arr = new int[10];
        for (int i = 0; i < 10; i++)
        {
            int dotprduct = 0;
            for (int j = 0; j < 10; j++)
            {
                dotprduct += prevArray[i, j] * array[i, j];
            }
            arr[i] = dotprduct;
        }

        Console.Write("\n");

        foreach (int i in arr)
        {
            Console.Write(i + " ");
        }
        Console.Write("\n\n");

    }

    private static void UpdateCoordinates(string coordinate, int[,] arr)
    {
        int[,] prev = (int[,])arr.Clone();

        double[] axis = CalculateAxis(coordinate);
        int strX = Convert.ToInt32(axis[0]);
        int strY = Convert.ToInt32(axis[1]);
        int endX = Convert.ToInt32(axis[2]);
        int endY = Convert.ToInt32(axis[3]);

        for (int i = strX - 1; i < strX + endX && i < 10; i++)
        {
            for (int j = strY - 1; j < strY + endY && j < 10; j++)
            {
                arr[i, j] = ToggleBinaryValue(arr[i, j]);
            }
        }

        Console.WriteLine("\n");
        DisplayArray(arr);
        CalculateDotProduct(prev, arr);
    }

    private static int ToggleBinaryValue(int v)
    {
        if (v == 0) { return 1; }
        else { return 0; }
    }

    private static double[] CalculateAxis(string coordinate)
    {
        string[] strlist = coordinate.Split(" ");
        double[] arr = new double[4];
        arr[0] = Math.Ceiling(Convert.ToDouble(strlist[0]) / 10);
        arr[1] = Math.Ceiling(Convert.ToDouble(strlist[1]) / 10);

        double width = Math.Floor(Convert.ToDouble(strlist[2]) / 10);
        if (arr[0] + width > 10)
        {
            width = Math.Floor((100 - Convert.ToDouble(strlist[0])) / 10);
        }
        arr[2] = width;
        double height = Math.Floor(Convert.ToDouble(strlist[3]) / 10);
        if (arr[0] + height > 10)
        {
            height = Math.Floor((100 - Convert.ToDouble(strlist[1])) / 10);
        }
        arr[3] = height;
        return arr;
    }

    private static void DisplayArray(int[,] arr)
    {
        for (int i = arr.GetLength(0) - 1; i >= 0; i--)
        {
            for (int j = 0; j < arr.GetLength(1); j++)
            {
                Console.Write("{0} ", arr[j, i]);
            }
            Console.WriteLine("\n");
        }
    }
}