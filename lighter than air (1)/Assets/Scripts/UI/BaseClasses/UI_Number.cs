using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UI_Number : MonoBehaviour
{
    //The number to display
    [Range(0, 9)]
    public int number = 0;

    //The Sprite to display when the number is equal to zero
    public Sprite zero;

    //The Sprite to display when the number is equal to one
    public Sprite one;

    //The Sprite to display when the number is equal to two
    public Sprite two;

    //The Sprite to display when the number is equal to three
    public Sprite three;

    //The Sprite to display when the number is equal to four
    public Sprite four;

    //The Sprite to display when the number is equal to five
    public Sprite five;

    //The Sprite to display when the number is equal to six
    public Sprite six;

    //The Sprite to display when the number is equal to seven
    public Sprite seven;

    //The Sprite to display when the number is equal to eight
    public Sprite eight;

    //The Sprite to display when the number is equal to nine
    public Sprite nine;

    //Sets the number
    public void SetNumber(int newNumber)
    {
        //Set the number to the specified new number
        number = newNumber;

        //Depending on the number
        switch(number)
        {
            //Display the zero Sprite
            case 0: GetComponent<Image>().sprite = zero;
                break;

            //Display the one Sprite
            case 1: GetComponent<Image>().sprite = one;
                break;

            //Display the two Sprite
            case 2: GetComponent<Image>().sprite = two;
                break;

            //Display the three Sprite
            case 3: GetComponent<Image>().sprite = three;
                break;

            //Display the four Sprite
            case 4: GetComponent<Image>().sprite = four;
                break;

            //Display the five Sprite
            case 5: GetComponent<Image>().sprite = five;
                break;

            //Display the six Sprite
            case 6: GetComponent<Image>().sprite = six;
                break;

            //Display the seven Sprite
            case 7: GetComponent<Image>().sprite = seven;
                break;

            //Display the eight Sprite
            case 8: GetComponent<Image>().sprite = eight;
                break;

            //Display the nine Sprite
            case 9: GetComponent<Image>().sprite = nine;
                break;
        }
    }
}
