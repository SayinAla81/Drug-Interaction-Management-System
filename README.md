# Medical Data Management System

## Overview
This project aims to efficiently manage medical data related to **drugs** and **diseases**, including tasks such as checking drug interactions, managing allergies, and calculating prescription prices. The system uses advanced data structures for efficient search, insertion, deletion, and modification of drug and disease information. The core of the solution is based on a **Binary Hashing Tree (BHT)** data structure for fast and efficient data handling.

## Purpose of Optimized Data Structure
The main goal behind developing this **optimized data structure** is to enhance the performance of the system when dealing with large datasets. To achieve this, I combined two powerful techniques:
- **Hashing**: For fast retrieval of data by mapping keys (e.g., drug names, disease names) to hash codes, ensuring constant time complexity for searches.
- **Binary Tree**: For maintaining an ordered structure, allowing fast insertions, deletions, and traversal with logarithmic time complexity.

By combining these two methods, the **Binary Hashing Tree (BHT)** provides the best of both worlds:
- **Efficient Search**: With hashing, searching for drugs or diseases becomes very fast.
- **Efficient Insertions and Deletions**: The binary tree structure ensures that the data remains balanced, allowing for quick insertions and deletions while maintaining ordered data.
- **Scalability**: The BHT ensures that even as the dataset grows, the operations remain efficient, offering scalability without significant performance degradation.

## Features
The program allows the user to perform a variety of tasks related to medical prescriptions and drug and diseases in the prescription.
4. **Invoice Price Calculation**: Calculate the total cost of drugs in a prescription.
5. **Price Inflation**: Increase the price of all drugs by a specified inflation rate.
6. **Add Information to Data Structure**: Insert new drugs or diseases into the system.
7. **Delete Information from Data Structure**: Remove existing drugs or diseases from the system.
8. **Search in Data Structure**: Search for a drug or disease and retrieve related information, including interactions and allergic reactions.
9. **Logging**: Record and display all user actions, including inserted, deleted, and searched data.

## Data Structures Used
- **Binary Tree**: The system uses binary trees to maintain an ordered structure of drugs and diseases. This helps in efficient insertions, deletions, and lookups, with logarithmic time complexity (O(log n)).
- **Hashing**: To optimize the search operation, hashing is combined with the binary tree structure. This allows for fast retrieval of data with constant time complexity (O(1)) for hash lookups.
- **Combination of Binary Tree and Hashing**: The integration of hashing and binary trees results in a **Binary Hashing Tree (BHT)**, which enhances the efficiency of all operations, including insertions, deletions, and searches.

### Benefits:
- **Improved Efficiency**: By using hashing for fast lookups and binary trees for balanced data storage, the system ensures quick access and management of data even as the dataset grows.
- **Scalability**: The binary tree ensures that the system can handle large datasets without performance issues, while the hashing provides quick access to specific records.
- **Optimized Performance**: The BHT reduces the complexity of operations, ensuring optimal time for processing even with multiple tasks running concurrently.

## Usage

After launching the program, you will be presented with a menu of tasks that you can choose from. You can interact with the system by selecting a task number from the options shown on the console.

### Main Tasks

1. **Read Information from Files**  
   Load drug, disease, allergy, and effect data from external text files into the system.

2. **Drug Interactions in Drug Prescription**  
   Check for interactions between drugs in a prescription. The system will alert if any interactions are detected between the selected drugs.

3. **Drug Allergies in Prescription with Patients**  
   Check for allergies between prescribed drugs and diseases that the patient might have.

4. **Invoice Price of Prescription Drugs**  
   Calculate the total cost of the prescription drugs based on their prices.

5. **Increase Prices of All Drugs**  
   Apply a percentage increase to the prices of all drugs in the system, simulating price inflation.

6. **Add Information in Data Structure**  
   Insert new drugs or diseases into the system. This can be done manually through user input.

7. **Delete Information in Data Structure**  
   Remove a drug or disease from the system. The program allows you to delete records based on their names.

8. **Searching in Data Structure**  
   Search for a drug or disease in the system and view its associated data (e.g., effects or allergies).

9. **Log**  
   View a log of all actions taken within the system, such as drug additions, deletions, and other modifications.

10. **Exit**  
    Exit the program.

### Example of Usage

When you run the program, you will be prompted to enter the task number you want to perform. For example:


Once you select a task, the program will execute the respective operation, such as reading from files or checking drug interactions, and it will display the result.

## Data Structures Used

For efficient data management, we have used a **combination of Binary Trees and Hashing**. This approach ensures quick access and manipulation of data. Here's a brief overview of the custom data structures:

- **Binary Tree for Drugs**: Stores drugs in a binary tree structure for efficient searching, insertion, and deletion.
- **Binary Tree for Diseases**: Similar to the binary tree used for drugs, this structure stores diseases and their associated data.
- **Hashing**: Integrated with the binary tree to enhance search efficiency for drugs and diseases. This allows for faster lookups when dealing with large datasets.

### Why Binary Tree and Hashing?

The combination of binary trees and hashing optimizes the system in the following ways:

- **Faster Searching**: Searching for drugs or diseases is more efficient due to the binary tree’s logarithmic time complexity combined with the constant time complexity of hash lookups.
- **Efficient Insertions and Deletions**: The binary tree provides efficient insertions and deletions, making it easy to modify the system's data.
- **Scalability**: This structure can handle a large amount of data while maintaining performance.

## Acknowledgements

- The binary tree and hashing approach was chosen for its performance and scalability in managing medical data.
- This system is designed to assist healthcare professionals with managing prescriptions and drug interactions.

