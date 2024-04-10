## Program Execution
The `Main` method is the entry point of the program. It performs the following steps:
1. Calls the `StartDialogue` method to initiate a dialogue with the user and collect product details.
2. Creates a `Cart` object with the collected products.
3. Generates a receipt using the `CreateReceipt` method of the `Cart` object.
4. Prints the receipt to the console using the `WriteReceipt` method of the `Cart` object.

## StartDialogue Method
The `StartDialogue` method is responsible for interacting with the user to gather information about the products to be added to the shopping cart. It performs the following actions:
1. Initializes an empty dictionary to store products and their quantities.
2. Enters a loop to repeatedly prompt the user for product details until the user decides to finish.
3. Prompts the user to enter the name, price, quantity, import status, and exemption status of the product.
4. Validates user input for price, quantity, import status, and exemption status.
5. Creates instances of the `Exempt` or `Normal` classes (subclass of `Product`) based on the exemption status provided by the user.
6. Adds the product to the dictionary of products, updating the quantity if the product already exists.
7. Continues the loop or exits based on user input.

## Class Design
- The `Product` class represents a generic product with properties such as name, price, import status, and quantity.
- The `Exempt` and `Normal` classes are subclasses of `Product` representing exempt and non-exempt products, respectively.
- The `Cart` class contains a dictionary of products and their quantities. It has methods to create a receipt (`CreateReceipt`) and print the receipt to the console (`WriteReceipt`).

## Usage
To use the program:
1. Run the program.
2. Follow the prompts to enter product details, including name, price, quantity, import status, and exemption status.
3. Repeat step 2 for each product or type 'done' to finish and get the receipt.
4. The program will display the receipt showing the quantity, prices, taxes, and total amount for each product entered.

## Note
- The program assumes user input adheres to the specified format and handles invalid input by prompting the user to correct it.
- The user can input both exempt and non-exempt products, and the program calculates taxes accordingly.
- The program provides a simple command-line interface for interaction with the user.
